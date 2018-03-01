
using RestSharp;

namespace ApiTests.models
{
   public class BaseClass
    {
        public const string BaseUrl = "http://159.65.237.98:8182";
        public const string BaseUrlUi = "http://159.65.237.98:80";
        public const string ApplicationUri = "/application.wadl";
        public const string HealthCheckUri = "/healthcheck";
        public const string ContactsUri = "/api/v1/contacts";
        public const string FirstNameBase = "John";
        public const string LastNameBase = "Doe";
        public const string EmailBase = "john.doe@unknown.com";

        public string ResponseContent<T>(RestClient client, RestRequest restRequest) where T : Info
        {
            IRestResponse<Info> response = client.Execute<Info>(restRequest);
            var jsonResponse = response.Content;
            return jsonResponse;
        }
    }
}
