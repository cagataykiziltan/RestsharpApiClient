using System.Collections.Generic;

namespace RestSharpClient.ApiClient
{
    public interface IApiService
    {
        T PostMethod<T>(object requestObject, string uri, Dictionary<string, string> headers = null);

        T GetMethod<T>(string uri, Dictionary<string, string> headers = null);

        T PutMethod<T>(object requestObject, string uri, Dictionary<string, string> headers = null);

        T DeleteMethod<T>(string uri, Dictionary<string, string> headers = null);
    }
}