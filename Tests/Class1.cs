using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BluePOCO;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Class1
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
        }

        
    }

    
}
