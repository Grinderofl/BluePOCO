using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ApiTransformer;
using JsonCSharpClassGenerator;
using NUnit.Framework;
using RestSharp;

namespace Tests
{
    [TestFixture]
    public class ApiTransformerTest
    {
        private string _data;

        [SetUp]
        public void Setup()
        {
            _data = Helpers.GetEmbeddedResourceText("Tests.Source.txt", Assembly.GetExecutingAssembly());
        }

        [Test]
        public void TestDoohickey()
        {
            var transformed = Transformer.GetMethodList(_data);
            string str = "/users/register";
            //str = string.Join("", str.Split('/').Select(x => x.Length > 0 ? x.Substring(0, 1).ToUpper() + x.Substring(1) : "")) + "Request";

            var item = Enum.GetName(typeof (HttpStatusCode), 200);
            foreach (var i in transformed)
            {
                foreach (var s in i.Responses)
                {
                    var generator = new JsonClassGenerator();
                    using (var ms = new MemoryStream())
                    {
                        using (var sw = new StreamWriter(ms))
                        {
                            generator.OutputStream = sw;
                            generator.Example = s.Json;
                            generator.UsePascalCase = true;
                            generator.UseProperties = true;
                            generator.MainClass = "MyRequest";
                            generator.GenerateClasses();
                            sw.Flush();
                            ms.Position = 0;
                            using (var sr = new StreamReader(ms))
                            {
                                var result = sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
            
        }

        
    }

    
}
