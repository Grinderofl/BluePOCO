using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BluePOCO
{
    public class Helpers
    {
        public static string GetEmbeddedResourceText(string resourceName, Assembly resourceAssembly)
        {
            using (var stream = resourceAssembly.GetManifestResourceStream(resourceName))
            {
                var streamLength = (int)stream.Length;
                var data = new byte[streamLength];
                stream.Read(data, 0, streamLength);

                if ((data[0] == 0xEF) && (data[1] == 0xBB) && (data[2] == 0xBF))
                {
                    var scrubbedData = new byte[data.Length - 3];
                    Array.Copy(data, 3, scrubbedData, 0, scrubbedData.Length);
                    data = scrubbedData;
                }

                return Encoding.UTF8.GetString(data);
            }
        }
    }
}
