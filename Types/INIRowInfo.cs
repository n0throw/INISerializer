namespace INISerializer.Types;

public class INIRowInfo
{
    public bool InlineComments { get; init; }
    public string Name { get; init; }
    public string Comment { get; init; }

    public INIRowInfo(bool inlineComments, string name, string comment)
    {
        InlineComments = inlineComments;
        Name = name;
        Comment = comment;
    }
}
