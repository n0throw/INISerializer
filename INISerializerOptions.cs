namespace INISerializer;

public class INISerializerOptions
{
    public bool IgnoreCase { get; set; }
    public bool IgnoreComments { get; set; }
    public bool InlineComments { get; set; }
    public bool IgnoreAttributes { get; set; }
    public bool IgnoreCollectible { get; set; }

    public INISerializerOptions(
        bool ignoreCase = false,
        bool ignoreComments = false,
        bool inlineComments = false,
        bool ignoreAttributes = false,
        bool ignoreCollectible = false)
    {
        IgnoreCase = ignoreCase;
        IgnoreComments = ignoreComments;
        InlineComments = inlineComments;
        IgnoreAttributes = ignoreAttributes;
        IgnoreCollectible = ignoreCollectible;
    }
}
