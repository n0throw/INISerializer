using INISerializer.Model;

namespace INISerializer;

public static partial class INISerializer
{
    public static string Serialize<TValue>(TValue value, INISerializerOptions? options = null)
    {
        INIType type = INIType.GetTypeFromObject(options, typeof(TValue));
        INIDocument document = new(value, type);

        return document.ToString();
    }

    public static string Serialize(object? value, Type inputType, INISerializerOptions? options = null)
    {
        INIType type = INIType.GetTypeFromObject(options, inputType);
        INIDocument document = new(value, type);

        return document.ToString();
    }

    public static INIDocument SerializeToDocument<TValue>(TValue value, INISerializerOptions? options = null)
    {
        INIType type = INIType.GetTypeFromObject(options, typeof(TValue));
        return new(value, type);
    }

    public static INIDocument SerializeToDocument(object? value, Type inputType, INISerializerOptions? options = null)
    {
        INIType type = INIType.GetTypeFromObject(options, inputType);
        return new(value, type);
    }
}