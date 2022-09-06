using System;
using RestSharp;

namespace aqaframework.Helpers
{
    public class ApiHelper
    {
        public RestClient client;

        public ApiHelper()
        {
            client = new RestClient(Configuration.Instance.apiProfileUrl);
        }

        private RestRequest createRequest(string endpoint, Method method)
        {
            return new RestRequest(endpoint, method);
        }

        public RestRequest createPostRequest(string endpoint)
        {
            return createRequest(endpoint, Method.Post);
        }

        public RestRequest createGetRequest(string endpoint)
        {
            return createRequest(endpoint, Method.Get);
        }
    }
}

