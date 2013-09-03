using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private Stopwatch _stopWatch;
        public HttpRestClient(string url, string securityToken)
        {
            _securityToken = securityToken;
            _client = new RestSharp.RestClient(url);
            _stopWatch = new Stopwatch();
        }
        public HttpRestClientResponse Execute(string url, string body, ContentType contentType, HTTPRequestMethodType method)
        {
            IRestRequest request = new RestRequest(Map(method));

            if(_securityToken != "")
                request.AddHeader("Authorization", _securityToken);

            request.AddHeader("Content-Type", contentType.MediaTag);
            request.AddParameter(contentType.MediaTag, body, ParameterType.RequestBody);

            _stopWatch.Start();
            var response = _client.Execute(request);
            _stopWatch.Stop();

            var result = new HttpRestClientResponse() { Content = response.Content,
                                                        ResultCode = response.StatusCode.ToString(),
                                                        ResultCodeDescription = response.StatusDescription,
                                                        ExecTime = _stopWatch.ElapsedMilliseconds};

            if (response.RawBytes != null)
                result.Size = response.RawBytes.Length;

            _stopWatch.Reset();
            return result;
        }

        private Method Map(HTTPRequestMethodType method)
        {
            if (method is HttpRequestGETMethodType)
                return Method.GET;
            else if (method is HttpRequestPOSTMethodType)
                return Method.POST;
            else
                return Method.GET;
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

        static public HTTPRequestMethodType[] RequestMehtodType
        {
            get
            {
                var result = new List<HTTPRequestMethodType>();
                result.Add(new HttpRequestPOSTMethodType());
                result.Add(new HttpRequestGETMethodType());

                return result.ToArray();
            }
        }
    }

    public abstract class HTTPRequestMethodType
    {
        public virtual string Type
        {
            get
            {
                return "GET";
            }
        }
    }

    public class HttpRequestPOSTMethodType : HTTPRequestMethodType
    {
        public override string Type
        {
            get
            {
                return "POST";
            }
        } 
    }

    public class HttpRequestGETMethodType : HTTPRequestMethodType
    {
        public override string Type
        {
            get
            {
                return "GET";
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
        public string ResultCodeDescription { get; set; }
        public long ExecTime { get; set; }
        public int Size { get; set; }
    }
}
