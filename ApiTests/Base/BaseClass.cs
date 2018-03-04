
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace ApiTests.models
{
   public class BaseClass
    {
        public const string BaseUrl = "http://159.65.237.98:8182";
        public const string BaseUrlUi = "http://159.65.237.98:80";
        public const string ApplicationUri = "/application.wadl";
        public const string HealthCheckUri = "/healthcheck/";
        public const string ContactsUri = "/api/v1/contacts/";
        public const string ContentType = "Content-type";
        public const string ContentTypeValue = "application/json";
        public const string JsonFirstNameFieldName = "firstName";
        public const string JsonLastNameFieldName = "lastName";
        public const string JsonEmalilFieldName = "email";
        public const string ValidationFirstNameString = "firstName {0} does not match {1}";
        private const string ValidationLastNameString = "lastName {0} does not match {1}";
        private const string ValidationEmailString = "email {0} does not match {1}";
        private const string ValidationIdString = "id {0} does not match {1}";

        public IRestResponse GetApplication()
        {
            var client = new RestClient(BaseUrlUi);
            var request = new RestRequest(Method.GET);
            IRestResponse<Info> response = client.Execute<Info>(request);
            return response;
        }

        public IRestResponse GetHealthCheck()
        {
            var client = new RestClient(BaseUrl + HealthCheckUri);
            var request = new RestRequest(Method.GET);
            IRestResponse<Info> response = client.Execute<Info>(request);
            return response;
        }

        public IRestResponse GetContactById(int id)
        {
            var client = new RestClient(BaseUrl + ContactsUri + id);
            var request = new RestRequest(Method.GET);
            IRestResponse<Info> response = client.Execute<Info>(request);
            return response;
        }

        public IRestResponse AddNewContact(string firstNameValue, string LastNameValue, string EmailValue)
        {
            var client = new RestClient(BaseUrl + ContactsUri);
            var request = new RestRequest(Method.POST);
            request.AddHeader(ContentType, ContentTypeValue);
            request.AddJsonBody(new { firstName = firstNameValue, lastName = LastNameValue, email = EmailValue });
            IRestResponse<Info> response = client.Execute<Info>(request);
            return response;
        }

        public IRestResponse ChangeContact(int id, string firstNameValue, string LastNameValue, string EmailValue)
        {
            var client = new RestClient(BaseUrl + ContactsUri + id);
            var request = new RestRequest(Method.PUT);
            request.AddHeader(ContentType, ContentTypeValue);
            request.AddJsonBody(new { firstName = firstNameValue, lastName = LastNameValue, email = EmailValue });
            IRestResponse<Info> response = client.Execute<Info>(request);
            return response;
        }

        public IRestResponse EditContact(int id, string editableField, string value)
        {
            var client = new RestClient(BaseUrl + ContactsUri + id);
            var request = new RestRequest(Method.PATCH);
            request.AddHeader(ContentType, ContentTypeValue);
            request.AddParameter(ContentTypeValue, "{\"" + editableField + "\":\"" + value + "\"}", ParameterType.RequestBody);
            IRestResponse<Info> response = client.Execute<Info>(request);
            return response;
        }

        public IRestResponse EditContact(int id, string editableField1, string value1, string editableField2, string value2)
        {
            var client = new RestClient(BaseUrl + ContactsUri + id);
            var request = new RestRequest(Method.PATCH);
            request.AddHeader(ContentType, ContentTypeValue);
            request.AddParameter(ContentTypeValue, "{\"" + editableField1 + "\":\"" + value1 + "\"" + ",\n" + "\"" + editableField2 + "\":\"" + value2 + "\"}", ParameterType.RequestBody);
            IRestResponse<Info> response = client.Execute<Info>(request);
            return response;
        }

        public IRestResponse DeleteContact(int id)
        {
            
            var client = new RestClient(BaseUrl + ContactsUri + id);
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

        public void AssertFirstName(string expectedFirstName, string actualFirstName)
        {
            Assert.AreEqual(expectedFirstName, actualFirstName, string.Format(ValidationFirstNameString, expectedFirstName, actualFirstName));
        }

        public void AssertLastName(string expectedLastName, string actualLastName)
        {
            Assert.AreEqual(expectedLastName, actualLastName, string.Format(ValidationLastNameString, expectedLastName, actualLastName));
        }

        public void AssertEmail(string expectedEmail, string actualEmail)
        {
            Assert.AreEqual(expectedEmail, actualEmail, string.Format(ValidationEmailString, expectedEmail, actualEmail));
        }

        public void AssertStatusCode(HttpStatusCode expectedStatusCode, int actualStatusCode)
        {
            Assert.AreEqual((int)expectedStatusCode, actualStatusCode, string.Format(ValidationIdString, (int)expectedStatusCode, actualStatusCode));
        }


    }
}
