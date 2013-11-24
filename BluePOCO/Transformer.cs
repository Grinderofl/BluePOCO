using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BluePOCO
{
    public class Transformer
    {
        private static readonly List<string> AllowedMethodValues = new List<string>()
        {
            "POST",
            "GET",
            "PUT",
            "DELETE"
        };
        public static List<ApiObject> GetMethodList(string source)
        {
            var list = new List<ApiObject>();
            ApiObject currentObject = null;
            ResponseObject currentResponseObject = null;
            foreach (var line in source.Split(new string[] {"\r\n", "\n"}, StringSplitOptions.RemoveEmptyEntries))
            {
                
                if (line.Trim().StartsWith("#"))
                {
                    if (AllowedMethodValues.Any(line.Contains))
                    {
                        if (currentObject == null || !string.IsNullOrWhiteSpace(currentObject.Method))
                            currentObject = new ApiObject() {Method = AllowedMethodValues.First(line.Contains)};
                        else
                            currentObject.Method = AllowedMethodValues.First(line.Contains);
                    }
                    if (line.Contains("/"))
                    {
                        var stripped = line.Substring(line.IndexOf("/", System.StringComparison.Ordinal));
                        if (currentObject == null || !string.IsNullOrWhiteSpace(currentObject.Resource))
                            currentObject = new ApiObject() {Resource = stripped};
                        else
                            currentObject.Resource = stripped;
                    }
                    if (currentObject != null && !string.IsNullOrWhiteSpace(currentObject.Method) &&
                        !string.IsNullOrWhiteSpace(currentObject.Resource))
                    {
                        list.Add(currentObject);
                    }
                    currentResponseObject = null;
                }
                if (line.StartsWith("+") && currentObject != null)
                {
                    currentResponseObject = new ResponseObject()
                    {
                        Code = Regex.Match(line, @"\d+").Value,
                        Type = Regex.Match(line, @"(?<=\().+?(?=\))").Value
                    };
                    if (line.ToLower().Contains("request"))
                        currentObject.Request = currentResponseObject;
                    else
                        currentObject.Responses.Add(currentResponseObject);
                }
                else if (currentResponseObject != null)
                {
                    currentResponseObject.Json += line;
                }
            }
            return list;
        }


    }

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

    public class ResponseObject
    {
        public string Code { get; set; }
        public string Type { get; set; }
        public string Json { get; set; }
    }
}
