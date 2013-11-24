using System.Collections.Generic;

namespace ApiTransformer
{
    public class ApiObject
    {
        public ApiObject()
        {
            Responses = new List<ResponseObject>();
        }
        public string Method { get; set; }
        public string Resource { get; set; }
        public List<ResponseObject> Responses { get; set; }
        public ResponseObject Request { get; set; }
    }
}