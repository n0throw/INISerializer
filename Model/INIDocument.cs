using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using INISerializer.Types;

namespace INISerializer.Model;

public class INIDocument
{
    public INITypeInfo Type { get; set; }
    public List<INISection>? Sections { get; set; }

    public INIDocument(object? value, INITypeInfo type)
    {
        Type = type;

        CreateDocument();
    }

    private void CreateDocument()
    {
        if (Type.TypesName.Count == 0)
            return;
        Sections = new();

        foreach (KeyValuePair<string, INIPropertyInfo> item in Type.TypesName)
        {

        }
    }

    public override string ToString()
    {
        throw new NotImplementedException();
    }

    internal TValue ToType<TValue>()
    {
        throw new NotImplementedException();
    }
}
