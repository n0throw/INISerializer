using System.Collections.ObjectModel;
using System.Reflection;

using INISerializer.Attributes;
using INISerializer.Types;

namespace INISerializer;

public class INITypeInfo
{
    private static readonly ReadOnlyCollection<Type> baseTypes =new(new Type[]
    {
        typeof(double),
        typeof(string),
        typeof(short),
        typeof(float),
        typeof(char),
        typeof(long),
        typeof(bool),
        typeof(int)
    });

    public readonly ReadOnlyDictionary<string, INIPropertyInfo> TypesName;
    public readonly INISerializerOptions Options;

    public INITypeInfo(INISerializerOptions? options, Type inputType)
    {
        Options = options is null ? new() : options;

        TypesName = new(GetPropertiesInfo(inputType.GetProperties()));
    }

    private Dictionary<string, INIPropertyInfo> GetPropertiesInfo(params PropertyInfo[] properties)
    {
        IEnumerable<PropertyInfo> propertiesInfos = properties.Where(property =>
            property.IsCollectible == !Options.IgnoreCollectible);

        Dictionary<string, INIPropertyInfo> output = new(propertiesInfos.Count());

        string propertyNewName;
        string comment;
        bool isIgnoreProperty;
        Dictionary<string, INIPropertyInfo>? INIpropertyInfos;

        foreach (PropertyInfo property in propertiesInfos)
        {
            INIpropertyInfos = null;
            propertyNewName = property.Name;
            comment = string.Empty;
            isIgnoreProperty = false;

            if (!Options.IgnoreAttributes)
            {
                foreach (object attribute in property.GetCustomAttributes(false))
                {
                    if (attribute is INIIgnoreAttribute ignoreAttribute)
                    {
                        if (ignoreAttribute.IsIgnore)
                        {
                            isIgnoreProperty = true;
                            break;
                        }
                    }

                    if (attribute is INICommentAttribute commentAttribute)
                    {
                        if (!Options.IgnoreComments)
                            comment = commentAttribute.Comment;
                    }

                    if (attribute is ININameAttribute nameAttribute)
                        propertyNewName = nameAttribute.Label;
                };

                if (isIgnoreProperty)
                    continue;
            }

            if (Options.IgnoreCase)
                propertyNewName = propertyNewName.ToLower();

            if (!baseTypes.Contains(property.GetType()))
                INIpropertyInfos = new(new INITypeInfo(Options, property.GetType()).TypesName);

            output.Add(property.Name, new INIPropertyInfo(Options.InlineComments, propertyNewName, comment, INIpropertyInfos));
        }

        return output;
    }
}
