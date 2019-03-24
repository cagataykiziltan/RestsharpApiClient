using System;
using RestSharpClient.ApiClient;
using RestSharpClient.Model;

namespace RestSharpClient
{
    class Program
    {
        static void Main(string[] args)
        {

            const string uri = "http://localhost:57287/api";
            IApiService client = new ApiService();
          
            var getUri = string.Format("{0}/{1}?id={2}", uri, "GetMethod", 5);
            var getResult = client.GetMethod<SampleModel>(getUri);

            var postUri = string.Format("{0}/{1}", uri, "PostMethod");
            var postResult = client.PostMethod<Response>(requestObject: "sampleRequest", uri: postUri);

            var putUri = string.Format("{0}/{1}", uri, "PutMethod");
            var putResult = client.PutMethod<Response>(requestObject: "sampleRequest", uri: putUri);

            var deleteUri = string.Format("{0}/{1}?id={2}", uri, "DeleteMethod", 3);
            var deleteResult = client.DeleteMethod<Response>(uri: deleteUri);


            Console.ReadKey();
        }
    }
}
