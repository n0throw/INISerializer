namespace INISerializer.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class LabelFieldAttribute : Attribute
{
    public string Label { get; init; }
    public LabelFieldAttribute()
        => Label = "field";
    public LabelFieldAttribute(string lable) => Label = lable;
}