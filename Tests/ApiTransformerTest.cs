using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ApiTransformer;
using NUnit.Framework;

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
            str = string.Join("", str.Split('/').Select(x => x.Length > 0 ? x.Substring(0, 1).ToUpper() + x.Substring(1) : "")) + "Request";
        }

        
    }

    
}
