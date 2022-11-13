namespace INISerializer.Attributes;

[AttributeUsage(
      AttributeTargets.Property
    | AttributeTargets.Struct
    | AttributeTargets.Field
    | AttributeTargets.Class
    | AttributeTargets.Enum)]
public class INIIgnoreAttribute : Attribute
{
    public bool IsIgnore { get; init; }
    public INIIgnoreAttribute()
        => IsIgnore = false;
    public INIIgnoreAttribute(bool isIgnore)
        => IsIgnore = isIgnore;
}