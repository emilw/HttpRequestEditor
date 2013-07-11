using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace HttpRequestEditor
{
    public class HttpRestClient
    {
        private RestSharp.RestClient _client;
        private string _securityToken;
        public HttpRestClient(string url, string securityToken)
        {
            _securityToken = securityToken;
            _client = new RestSharp.RestClient(url);
        }
        public HttpRestClientResponse Get(string url, string body, ContentType contentType)
        {
            IRestRequest request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", _securityToken);
            request.AddHeader("Content-Type", contentType.MediaTag);
            //request.AddParameter(contentType, "", ParameterType.RequestBody);
            //request.RequestFormat = DataFormat.Xml;
            request.AddParameter(contentType.MediaTag, body, ParameterType.RequestBody);
            var response = _client.Execute(request);
            
            var result = new HttpRestClientResponse() { Content = response.Content, ResultCode = response.StatusCode.ToString() };
            return result;
        }

        static public ContentType[] ContentType
        {
            get
            {
                var result = new List<ContentType>();
                result.Add(new ContentType() { Name = "XML", MediaTag = "application/xml" });
                result.Add(new ContentType() { Name = "JSON", MediaTag = "application/json" });

                return result.ToArray();
            }
        }
    }

    public class ContentType
    {
        public string Name { get; set; }
        public string MediaTag { get; set; }
    }


    public class HttpRestClientResponse
    {
        public string Content { get; set; }
        public string ResultCode { get; set; }
    }
}
