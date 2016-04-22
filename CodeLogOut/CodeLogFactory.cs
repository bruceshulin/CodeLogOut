using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLogOut
{
    public enum LANGUANGEType
    {
        JAVA,
        CSHARP,
        C,
    }
    public class CodeLogFactory
    {
        public string GetNewLogCode(string code,LANGUANGEType lang)
        {
            string new_code = "";
            switch (lang)
            {
                case LANGUANGEType.JAVA:
                    JavaCodeContent javacode = new JavaCodeContent();
                    new_code = javacode.GetCode(code);
                    break;
                case LANGUANGEType.CSHARP:
                    CCsharpContent csharpcode = new CCsharpContent();
                    new_code = csharpcode.GetCode(code);
                    break;
                case LANGUANGEType.C:
                    CCodeContent ccode = new CCodeContent();
                    new_code = ccode.GetCode(code);
                    break;
                default:
                    break;
            }
            return new_code;
        }
    }
}
