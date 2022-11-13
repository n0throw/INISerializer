using System.Collections.ObjectModel;

namespace INISerializer.Types;

public class INIPropertyInfo
{
    public bool InlineComments { get; init; }
    public string Name { get; init; }
    public string Comment { get; init; }

    public readonly ReadOnlyDictionary<string, INIPropertyInfo>? Properties;

    public INIPropertyInfo(bool inlineComments, string name, string comment, Dictionary<string, INIPropertyInfo>? properties = null)
    {
        InlineComments = inlineComments;
        Name = name;
        Comment = comment;

        if (properties is not null)
        {
            if (properties.Count > 0)
                Properties = new(properties);
        }
    }
}
