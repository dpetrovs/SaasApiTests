
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Collections;
using System.Net;

namespace ApiTests.models
{
   public class BaseClass
    {
        public IRestResponse GetApplication()
        {
            var client = new RestClient(Properties.Settings.Default.UiUrl);
            var request = new RestRequest(Method.GET);
            IRestResponse<Info> response = client.Execute<Info>(request);
            return response;
        }

        public IRestResponse GetHealthCheck()
        {
            var client = new RestClient(Properties.Settings.Default.HealthcheckUrl);
            var request = new RestRequest( Method.GET);
            request.AddHeader("Accept", "*/*");
            var response = client.Execute(request);
            return response;
        }

        public IRestResponse GetContactById(int id)
        {
            var client = new RestClient(Properties.Settings.Default.ContactsUrl + id);
            var request = new RestRequest(Method.GET);
            IRestResponse<Info> response = client.Execute<Info>(request);
            return response;
        }

        public IRestResponse AddNewContact(string json)
        {
            var client = new RestClient(Properties.Settings.Default.ContactsUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader(Properties.Settings.Default.ContentType, Properties.Settings.Default.ContentTypeValue);
            request.AddParameter(Properties.Settings.Default.ContentTypeValue, json, ParameterType.RequestBody);
            IRestResponse<Info> response = client.Execute<Info>(request);
            return response;
        }

        public IRestResponse ChangeContact(int id, string json)
        {
            var client = new RestClient(Properties.Settings.Default.ContactsUrl + id);
            var request = new RestRequest(Method.PUT);
            request.AddHeader(Properties.Settings.Default.ContentType, Properties.Settings.Default.ContentTypeValue);
            request.AddParameter(Properties.Settings.Default.ContentTypeValue, json, ParameterType.RequestBody);
            IRestResponse<Info> response = client.Execute<Info>(request);
            return response;
        }

        public IRestResponse EditContact(int id, string json)
        {
            var client = new RestClient(Properties.Settings.Default.ContactsUrl + id);
            var request = new RestRequest(Method.PATCH);
            request.AddHeader(Properties.Settings.Default.ContentType, Properties.Settings.Default.ContentTypeValue);
            request.AddParameter(Properties.Settings.Default.ContentTypeValue, json, ParameterType.RequestBody);
            IRestResponse<Info> response = client.Execute<Info>(request);
            return response;
        }

        public IRestResponse DeleteContact(int id)
        {
            
            var client = new RestClient(Properties.Settings.Default.ContactsUrl + id);
            var request = new RestRequest(Method.DELETE);
            IRestResponse<Info> response = client.Execute<Info>(request);
            return response;
        }

        public IRestResponse MethodOptionsCheck(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.OPTIONS);
            IRestResponse<Info> response = client.Execute<Info>(request);
            return response;
        }

        public IRestResponse MethodHeadCheck(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.HEAD);
            IRestResponse<Info> response = client.Execute<Info>(request);
            return response;
        }

        public IRestResponse MethodPostCheck(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            IRestResponse<Info> response = client.Execute<Info>(request);
            return response;
        }

        public IRestResponse MethodPutCheck(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.PUT);
            IRestResponse<Info> response = client.Execute<Info>(request);
            return response;
        }

        public IRestResponse MethodPatchCheck(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.PATCH);
            IRestResponse<Info> response = client.Execute<Info>(request);
            return response;
        }

        public IRestResponse MethodDeleteCheck(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.DELETE);
            IRestResponse<Info> response = client.Execute<Info>(request);
            return response;
        }


        public int GetId(string jsonResponse)
        {
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
            return rootObject.data[0].id;
        }

        public string GetFirstName(string jsonResponse)
        {
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
            return rootObject.data[0].info.firstName;
        }

        public string GetLastName(string jsonResponse)
        {
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
            return rootObject.data[0].info.lastName;
        }

        public string GetEmail(string jsonResponse)
        {
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
            return rootObject.data[0].info.email;
        }

        public int GetStatusCodeFromResponseBody(string jsonResponse)
        {
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
            return rootObject.status;
        }
    }
}
