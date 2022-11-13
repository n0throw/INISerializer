namespace INISerializer.Attributes;

[AttributeUsage(
      AttributeTargets.Property
    | AttributeTargets.Struct
    | AttributeTargets.Field
    | AttributeTargets.Class
    | AttributeTargets.Enum)]
public class ININameAttribute : Attribute
{
    public string Label { get; init; }
    public ININameAttribute(string lable) => Label = lable;
}