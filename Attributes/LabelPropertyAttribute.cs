namespace INISerializer.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class LabelPropertyAttribute : Attribute
{
    public string Label { get; init; }
    public LabelPropertyAttribute()
        => Label = "property";
    public LabelPropertyAttribute(string lable) => Label = lable;
}