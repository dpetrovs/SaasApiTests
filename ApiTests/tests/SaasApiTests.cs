using ApiTests.models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;

namespace ApiTests.tests
{
    [TestFixture]
    public class SaasApiTests : BaseClass
    {
        [Test]
        public void GetApplicationTest()
        {
            var getApplication = GetApplication();
            Assert.IsTrue(getApplication.Content.Contains("Software Engineering Course"));
            AssertStatusCode(HttpStatusCode.OK, (int)getApplication.StatusCode);
        }

        [Test]
        public void HealthCheckTest()
        {
            var healthCheck = GetHealthCheck();
            AssertStatusCode(HttpStatusCode.OK, (int)healthCheck.StatusCode);
            Assert.IsTrue(healthCheck.Content.Contains("live"));
        }

        [Test]
        public void GetContactByIdTest()
        {
            string firstName = "John";
            string lastName = "Doe";
            string email = "john.doe@unknown.com";
            int id = 1;

            var getContact = GetContactById(id);
            AssertStatusCode(HttpStatusCode.OK, GetStatusCodeFromResponseBody(getContact.Content));
            Assert.AreEqual(firstName, GetFirstName(getContact.Content));
            Assert.AreEqual(lastName, GetLastName(getContact.Content));
            Assert.AreEqual(email, GetEmail(getContact.Content));
        }

        [Test]
        public void AddNewContactTest()
        {
            string firstName = "Hulk";
            string lastName = "Hogan";
            string email = "hulkHogan@testmail.com";

            var addContact = AddNewContact(firstName, lastName, email);
            AssertStatusCode(HttpStatusCode.OK, GetStatusCodeFromResponseBody(addContact.Content));
            Assert.AreEqual(firstName, GetFirstName(addContact.Content));
            Assert.AreEqual(lastName, GetLastName(addContact.Content));
            Assert.AreEqual(email, GetEmail(addContact.Content));
        }

        [Test]
        public void ChangeContactTest()
        {
            string firstName = "HulkChanged";
            string lastName = "HogaChanged1";
            string email = "hulkHoganChanged@testmail.com";
            int id = 13;

            var changeContact = ChangeContact(id, firstName, lastName, email);
            AssertStatusCode(HttpStatusCode.OK, GetStatusCodeFromResponseBody(changeContact.Content));
            Assert.AreEqual(firstName, GetFirstName(changeContact.Content));
            Assert.AreEqual(lastName, GetLastName(changeContact.Content));
            Assert.AreEqual(email, GetEmail(changeContact.Content));
        }

        [Test]
        public void EditContactFirstNameTest()
        {
            string firstName = "HulkEdited";
            int id = 13;

            var editContact = EditContact(id, JsonFirstNameFieldName, firstName);
            AssertStatusCode(HttpStatusCode.OK, GetStatusCodeFromResponseBody(editContact.Content));
            Assert.AreEqual(firstName, GetFirstName(editContact.Content));
        }

        [Test]
        public void EditContactLastNameTest()
        {
            string lastName = "HoganEdited";
            int id = 13;

            var editContact = EditContact(id, JsonLastNameFieldName, lastName);
            AssertStatusCode(HttpStatusCode.OK, GetStatusCodeFromResponseBody(editContact.Content));
            Assert.AreEqual(lastName, GetLastName(editContact.Content));
        }

        [Test]
        public void EditContactEmailTest()
        {
            string email = "hulkhogan_edited@testmail.com";
            int id = 13;

            var editContact = EditContact(id, JsonEmalilFieldName, email);
            AssertStatusCode(HttpStatusCode.OK, GetStatusCodeFromResponseBody(editContact.Content));
            Assert.AreEqual(email, GetEmail(editContact.Content));
        }

        [Test]
        public void EditContactFirstNameEmailTest()
        {
            string firstName = "Sandra";
            string email = "sandrabullock@testmail.com";
            int id = 13;

            var editContact = EditContact(id, JsonEmalilFieldName, email, JsonFirstNameFieldName, firstName);
            AssertStatusCode(HttpStatusCode.OK, GetStatusCodeFromResponseBody(editContact.Content));
            Assert.AreEqual(firstName, GetFirstName(editContact.Content));
            Assert.AreEqual(email, GetEmail(editContact.Content));
        }

        [Test]
        public void EditContactLastNameEmailTest()
        {
            string lastName = "Tarantino";
            string email = "quentintarantino@testmail.com";
            int id = 13;

            var editContact = EditContact(id, JsonEmalilFieldName, email, JsonLastNameFieldName, lastName);
            AssertStatusCode(HttpStatusCode.OK, GetStatusCodeFromResponseBody(editContact.Content));
            Assert.AreEqual(lastName, GetLastName(editContact.Content));
            Assert.AreEqual(email, GetEmail(editContact.Content));
        }

        [Test]
        public void EditContactFirstLastNameTest()
        {
            string firstName = "Luciano";
            string lastName = "Pavarotti";
            int id = 13;

            var editContact = EditContact(id, JsonFirstNameFieldName, firstName, JsonLastNameFieldName, lastName);
            AssertStatusCode(HttpStatusCode.OK, GetStatusCodeFromResponseBody(editContact.Content));
            Assert.AreEqual(firstName, GetFirstName(editContact.Content));
            Assert.AreEqual(lastName, GetLastName(editContact.Content));
        }

        [Test]
        public void DeleteContactTest()
        {
            int id = 22;

            var deleteContact = DeleteContact(id);
            Assert.AreEqual(HttpStatusCode.OK, deleteContact.StatusCode);
            var getDeletedContact = GetContactById(id);
            Assert.AreEqual(HttpStatusCode.NotFound, getDeletedContact.StatusCode);
        }
    }
}
