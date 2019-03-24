using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace RestSharpClient.ApiClient
{
    public class ApiService : IApiService
    {
        public T PostMethod<T>(object requestObject, string uri, Dictionary<string, string> headers = null)
        {
            var client = new RestClient(uri);
            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            var result = GetResult<T>(client, request, requestObject, headers);

            return result;
        }

        public T GetMethod<T>(string uri, Dictionary<string, string> headers = null)
        {
            var client = new RestClient(uri);
            var request = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };
            var result = GetResult<T>(client, request, null, headers);

            return result;
        }

        public T PutMethod<T>(object requestObject, string uri, Dictionary<string, string> headers = null)
        {
            var client = new RestClient(uri);
            var request = new RestRequest(Method.PUT) { RequestFormat = DataFormat.Json };
            var result = GetResult<T>(client, request, requestObject, headers);

            return result;
        }

        public T DeleteMethod<T>(string uri, Dictionary<string, string> headers = null)
        {
            var client = new RestClient(uri);
            var request = new RestRequest(Method.DELETE) { RequestFormat = DataFormat.Json };
            var result = GetResult<T>(client, request, null, headers);

            return result;
        }

        private T GetResult<T>(RestClient client, RestRequest request, object requestObject = null, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }

            if (requestObject != null)
            {
                request.AddJsonBody(requestObject);
            }

            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<T>(response.Content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

        }
    }
}
