using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonCSharpClassGenerator;

namespace ApiTransformer
{
    public class ClassGenerator
    {
        public static string Generate(string json, string className)
        {
            var generator = new JsonClassGenerator();
            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(ms))
                {
                    generator.OutputStream = sw;
                    generator.Example = json;
                    generator.UsePascalCase = true;
                    generator.UseProperties = true;
                    generator.MainClass = className;
                    generator.UseNestedClasses = true;
                    generator.GenerateClasses();
                    sw.Flush();
                    ms.Position = 0;
                    using (var sr = new StreamReader(ms))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
    }
}
