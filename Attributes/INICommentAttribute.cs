namespace INISerializer.Attributes;

[AttributeUsage(
      AttributeTargets.Property
    | AttributeTargets.Struct
    | AttributeTargets.Field
    | AttributeTargets.Class
    | AttributeTargets.Enum)]
public class INICommentAttribute : Attribute
{
    public string Comment { get; init; }
    public INICommentAttribute(string comment) => Comment = comment;
}