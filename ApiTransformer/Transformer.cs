using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ApiTransformer
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
            var collection = source.Split(new string[] {"\r\n", "\n"}, StringSplitOptions.RemoveEmptyEntries);
            bool allowAdd = false;
            foreach (var line in collection)
            {
                
                if (line.Trim().StartsWith("#"))
                {
                    if (AllowedMethodValues.Any(line.Contains))
                    {
                        if (currentObject == null || !string.IsNullOrWhiteSpace(currentObject.Method))
                            currentObject = new ApiObject() {Method = AllowedMethodValues.First(line.Contains)};
                        else
                            currentObject.Method = AllowedMethodValues.First(line.Contains);
                        allowAdd = true;
                    }
                    if (line.Contains("/"))
                    {
                        var stripped = line.Substring(line.IndexOf("/", System.StringComparison.Ordinal));
                        stripped = stripped.Replace("]", "");
                        if (currentObject == null || !string.IsNullOrWhiteSpace(currentObject.Resource))
                            currentObject = new ApiObject() {Resource = stripped};
                        else
                            currentObject.Resource = stripped;
                        allowAdd = true;
                    }
                    if (currentObject != null && !string.IsNullOrWhiteSpace(currentObject.Method) &&
                        !string.IsNullOrWhiteSpace(currentObject.Resource) && allowAdd)
                    {
                        list.Add(currentObject);
                        allowAdd = false;
                    }
                    currentResponseObject = null;
                }
                if (line.StartsWith("+") && (line.Contains("Request") || line.Contains("Response"))&& currentObject != null)
                {
                    currentResponseObject = new ResponseObject()
                    {
                        Code = Regex.Match(line, @"\d+").Value,
                        Type = Regex.Match(line, @"(?<=\().+?(?=\))").Value
                    };
                    if (line.ToLower().Contains("request"))
                        currentObject.Request = currentResponseObject;
                    else
                    {
                        if(currentObject.Responses.All(x => x.Code != currentResponseObject.Code))
                            currentObject.Responses.Add(currentResponseObject);
                    }
                        
                }
                else if (currentResponseObject != null)
                {
                    currentResponseObject.Json += line;
                }
            }
            return list;
        }


    }
}
