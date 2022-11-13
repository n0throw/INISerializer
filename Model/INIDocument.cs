using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INISerializer.Model;

public class INIDocument
{

    public INIDocument(Type type)
    {
        object[] attributes = type.GetCustomAttributes(false);

        type.GetFields()[0].;
        type.GetProperties();

        
    }
}
