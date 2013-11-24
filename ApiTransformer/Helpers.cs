using System;
using System.Reflection;
using System.Text;

namespace ApiTransformer
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
