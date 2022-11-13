using System.Collections.ObjectModel;
using System.Reflection;

using INISerializer.Attributes;
using INISerializer.Types;

namespace INISerializer;

public class INITypeInfo
{
    public readonly ReadOnlyDictionary<string, INIRowInfo> TypesName;

    public INITypeInfo(INISerializerOptions? options, Type inputType)
    {
        options ??= new();
        TypesName = new(GetPropertiesInfo(options, inputType.GetProperties()));
    }

    private static Dictionary<string, INIRowInfo> GetPropertiesInfo(INISerializerOptions options, params PropertyInfo[] properties)
    {
        IEnumerable<PropertyInfo> propertiesInfos = properties.Where(property =>
            property.IsCollectible == !options.IgnoreCollectible);

        Dictionary<string, INIRowInfo> output = new(propertiesInfos.Count());

        string propertyNewName;
        string comment;
        bool isIgnoreProperty;

        foreach (PropertyInfo property in propertiesInfos)
        {
            propertyNewName = property.Name;
            comment = string.Empty;
            isIgnoreProperty = false;

            if (!options.IgnoreAttributes)
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
                        if (!options.IgnoreComments)
                            comment = commentAttribute.Comment;
                    }

                    if (attribute is ININameAttribute nameAttribute)
                        propertyNewName = nameAttribute.Label;
                };

                if (isIgnoreProperty)
                    continue;
            }

            if (options.IgnoreCase)
                propertyNewName = propertyNewName.ToLower();

            output.Add(property.Name, new INIRowInfo(options.InlineComments, propertyNewName, comment));
        }

        return output;
    }
}
