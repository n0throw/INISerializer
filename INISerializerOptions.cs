namespace INISerializer;

public class INISerializerOptions
{
    public bool IgnorePrivate { get; set; }
    public bool IgnoreComments { get; set; }
    public bool IgnoreAttributes { get; set; }
    public bool IgnoreCollectible { get; set; }

    public INISerializerOptions(bool ignorePrivate = false, bool ignoreComments = false, bool ignoreAttributes = false, bool ignoreCollectible = false)
    {
        IgnorePrivate = ignorePrivate;
        IgnoreComments = ignoreComments;
        IgnoreAttributes = ignoreAttributes;
        IgnoreCollectible = ignoreCollectible;
    }
}
