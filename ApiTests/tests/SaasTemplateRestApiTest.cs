using ApiTests.models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;

namespace ApiTests.tests
{
    [TestFixture]
    public class SaasTemplateRestApiTest : BaseClass
    {
        [Test]
        public void GetContact()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(BaseUrl);
            var request = new RestRequest(ContactsUri, Method.GET);
            IRestResponse<Info> response = client.Execute<Info>(request);
            var jsonResponse = response.Content;
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
            string firstName = rootObject.data[0].info.firstName;
            string lastName = rootObject.data[0].info.lastName;
            string email = rootObject.data[0].info.email;
            Assert.AreEqual(FirstNameBase, firstName, string.Format("firstName {0} does not match {1}", FirstNameBase, firstName));
            Assert.AreEqual(LastNameBase, lastName, string.Format("lastName {0} does not match {1}", LastNameBase, lastName));
            Assert.AreEqual(EmailBase, email, string.Format("Email {0} does not match {1}", EmailBase, email));
        }
        [Test]
        public void PutContact()
        {
            var client = new RestClient(BaseUrl + ContactsUri);
            var request = new RestRequest();
            request.Method = Method.POST;
            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            request.AddJsonBody( new { email = "steven.sigal@testmail.com", firstName = "Steven", lastName = "Sigal" });
            IRestResponse<Info> response = client.Execute<Info>(request);
            var content = response.Content;
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(content);
            Console.WriteLine(content);
            //Assert.AreEqual("200", response.StatusCode);
            string firstName = rootObject.data[0].info.firstName;
            string lastName = rootObject.data[0].info.lastName;
            string email = rootObject.data[0].info.email;
            Console.WriteLine((int) response.StatusCode + " " + firstName + " " + lastName + email);
        }
    }
}
