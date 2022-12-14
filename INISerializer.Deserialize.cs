using INISerializer.Model;

namespace INISerializer;

public static partial class INISerializer
{
	public static TValue? Deserialize<TValue>(string ini, INISerializerOptions? options = null)
	{
		if (ini is null)
			throw new ArgumentNullException(nameof(ini));

		INITypeInfo type = new(options, typeof(TValue));
		INIDocument document = new(ini, type);

		return document.ToType<TValue>();
	}

	public static object? Deserialize(string ini, Type returnType, INISerializerOptions? options = null)
	{
		if (ini is null)
			throw new ArgumentNullException(nameof(ini));
		if (returnType is null)
			throw new ArgumentNullException(nameof(returnType));

        INITypeInfo type = new(options, returnType);
        INIDocument document = new(ini, type);

        return document.ToType<object?>();
    }

	public static TValue? Deserialize<TValue>(INIDocument document, INISerializerOptions? options = null)
	{
		if (document is null)
            throw new ArgumentNullException(nameof(document));

        INITypeInfo type = new(options, typeof(TValue));
		document.Type = type;

        return document.ToType<TValue>();
	}


	public static object? Deserialize(INIDocument document, Type returnType, INISerializerOptions? options = null)
	{
		if (document is null)
            throw new ArgumentNullException(nameof(document));

        if (returnType is null)
            throw new ArgumentNullException(nameof(returnType));

        INITypeInfo type = new(options, returnType);
        document.Type = type;

        return document.ToType<object?>();
    }
}
