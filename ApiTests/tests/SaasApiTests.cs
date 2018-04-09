using ApiTests.models;
using ApiTests.Models;
using Newtonsoft.Json;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections;
using System.Net;

namespace ApiTests.tests
{
    [TestFixture]
    public class SaasApiTests : BaseClass
    {
        string firstName, lastName, email, firstNameForEdit, lastNameForEdit, emailForEdit, json;
        int id;
        Dictionary dictionary = new Dictionary();
        Dictionary dictionaryForEdit = new Dictionary();
        IRestResponse createdContactResponse;

        [OneTimeSetUp]
        public void SetUpForEdit()
        {
            firstNameForEdit = Faker.Name.First();
            lastNameForEdit = Faker.Name.Last();
            emailForEdit = Faker.Internet.Email(firstNameForEdit + " " + lastNameForEdit);
        }

        [SetUp]
        public void BaseSetUp()
        {
            firstName = Faker.Name.First();
            lastName = Faker.Name.Last();
            email = Faker.Internet.Email(firstName + " " + lastName);            
            dictionary.Add("firstName", firstName);
            dictionary.Add("lastName", lastName);
            dictionary.Add("email", email);
            json = JsonGenerator.JsonRequest(dictionary);
            createdContactResponse = AddNewContact(json);
            id = GetId(createdContactResponse.Content);
        }

        [TearDown]
        public void BaseTearDown()
        {
            DeleteContact(id);
            dictionary.ClearAll();
        }

        [Test, Category("Positive: Get Contact")]
        public void GetContactByIdTest()
        {
            var getContact = GetContactById(id);
            Assert.AreEqual(HttpStatusCode.OK, getContact.StatusCode);
            Assert.AreEqual(firstName, GetFirstName(getContact.Content));
            Assert.AreEqual(lastName, GetLastName(getContact.Content));
            Assert.AreEqual(email, GetEmail(getContact.Content));
        }

        [Test, Category("Positive: Edit Contact")]
        public void ChangeContactTest()
        {
            dictionaryForEdit.Add("firstName", firstNameForEdit);
            dictionaryForEdit.Add("lastName", lastNameForEdit);
            dictionaryForEdit.Add("email", emailForEdit);
            json = JsonGenerator.JsonRequest(dictionaryForEdit);
            var changeContact = ChangeContact(id, json);
            Assert.AreEqual(HttpStatusCode.OK, changeContact.StatusCode);
            Assert.AreEqual(firstNameForEdit, GetFirstName(changeContact.Content));
            Assert.AreEqual(lastNameForEdit, GetLastName(changeContact.Content));
            Assert.AreEqual(emailForEdit, GetEmail(changeContact.Content));
        }

        [Test, Category("Positive: Edit Contact")]
        public void EditContactFirstNameTest()
        {
            dictionaryForEdit.Add("firstName", firstNameForEdit);
            json = JsonGenerator.JsonRequest(dictionaryForEdit);
            var editContact = EditContact(id, json);
            Assert.AreEqual(HttpStatusCode.OK, editContact.StatusCode);
            Assert.AreEqual(firstNameForEdit, GetFirstName(editContact.Content));
        }

        [Test, Category("Positive: Edit Contact")]
        public void EditContactLastNameTest()
        {
            dictionaryForEdit.Add("lastName", lastNameForEdit);
            json = JsonGenerator.JsonRequest(dictionaryForEdit);
            var editContact = EditContact(id, json);
            Assert.AreEqual(HttpStatusCode.OK, editContact.StatusCode);
            Assert.AreEqual(lastNameForEdit, GetLastName(editContact.Content));
        }

        [Test, Category("Positive: Edit Contact")]
        public void EditContactEmailTest()
        {
            dictionaryForEdit.Add("email", emailForEdit);
            json = JsonGenerator.JsonRequest(dictionaryForEdit);
            var editContact = EditContact(id, json);
            Assert.AreEqual(HttpStatusCode.OK, editContact.StatusCode);
            Assert.AreEqual(emailForEdit, GetEmail(editContact.Content));
        }

        [Test, Category("Positive: Edit Contact")]
        public void EditContactFirstNameEmailTest()
        {
            dictionaryForEdit.Add("firstName", firstNameForEdit);
            dictionaryForEdit.Add("email", emailForEdit);
            json = JsonGenerator.JsonRequest(dictionaryForEdit);
            var editContact = EditContact(id, json);
            Assert.AreEqual(HttpStatusCode.OK, editContact.StatusCode);
            Assert.AreEqual(firstNameForEdit, GetFirstName(editContact.Content));
            Assert.AreEqual(emailForEdit, GetEmail(editContact.Content));
        }

        [Test, Category("Positive: Edit Contact")]
        public void EditContactLastNameEmailTest()
        {
            dictionaryForEdit.Add("lastName", lastNameForEdit);
            dictionaryForEdit.Add("email", emailForEdit);
            json = JsonGenerator.JsonRequest(dictionaryForEdit);
            var editContact = EditContact(id, json);
            Assert.AreEqual(HttpStatusCode.OK, editContact.StatusCode);
            Assert.AreEqual(lastNameForEdit, GetLastName(editContact.Content));
            Assert.AreEqual(emailForEdit, GetEmail(editContact.Content));
        }

        [Test, Category("Positive: Edit Contact")]
        public void EditContactFirstLastNameTest()
        {
            dictionaryForEdit.Add("firstName", firstNameForEdit);
            dictionaryForEdit.Add("lastName", lastNameForEdit);
            json = JsonGenerator.JsonRequest(dictionaryForEdit);
            var editContact = EditContact(id, json);
            Assert.AreEqual(HttpStatusCode.OK, editContact.StatusCode);
            Assert.AreEqual(firstNameForEdit, GetFirstName(editContact.Content));
            Assert.AreEqual(lastNameForEdit, GetLastName(editContact.Content));
        }

        [Test, Category("Negative: POST not all parameters")]
        public void PostFirstNameOnlyTest()
        {
            dictionaryForEdit.Add("firstName", firstNameForEdit);
            json = JsonGenerator.JsonRequest(dictionaryForEdit);
            var postContact = ChangeContact(id, json);
            Assert.AreEqual(HttpStatusCode.BadRequest, postContact.StatusCode);
        }

        [Test, Category("Negative: POST not all parameters")]
        public void PostLastNameOnlyTest()
        {
            dictionaryForEdit.Add("lastName", lastNameForEdit);
            json = JsonGenerator.JsonRequest(dictionaryForEdit);
            var postContact = ChangeContact(id, json);
            Assert.AreEqual(HttpStatusCode.BadRequest, postContact.StatusCode);
        }

        [Test, Category("Negative: POST not all parameters")]
        public void PostEmailOnlyTest()
        {
            dictionaryForEdit.Add("email", emailForEdit);
            json = JsonGenerator.JsonRequest(dictionaryForEdit);
            var postContact = ChangeContact(id, json);
            Assert.AreEqual(HttpStatusCode.BadRequest, postContact.StatusCode);
        }

        [Test, Category("Negative: POST not all parameters")]
        public void PostFirstLastNameOnlyTest()
        {
            dictionaryForEdit.Add("firstName", firstNameForEdit);
            dictionaryForEdit.Add("lastName", lastNameForEdit);
            json = JsonGenerator.JsonRequest(dictionaryForEdit);
            var postContact = ChangeContact(id, json);
            Assert.AreEqual(HttpStatusCode.BadRequest, postContact.StatusCode);
        }

        [Test, Category("Negative: POST not all parameters")]
        public void PostFirstNameEmailOnlyTest()
        {
            dictionaryForEdit.Add("firstName", firstNameForEdit);
            dictionaryForEdit.Add("email", emailForEdit);
            json = JsonGenerator.JsonRequest(dictionaryForEdit);
            var postContact = ChangeContact(id, json);
            Assert.AreEqual(HttpStatusCode.BadRequest, postContact.StatusCode);
        }

        [Test, Category("Negative: POST not all parameters")]
        public void PostLastNameEmailOnlyTest()
        {
            dictionaryForEdit.Add("lastName", lastNameForEdit);
            dictionaryForEdit.Add("email", emailForEdit);
            json = JsonGenerator.JsonRequest(dictionaryForEdit);
            var postContact = ChangeContact(id, json);
            Assert.AreEqual(HttpStatusCode.BadRequest, postContact.StatusCode);
        }

        [Test]
        [Category("Positive: DeleteContact")]
        public void DeleteContactTest()
        {
            dictionaryForEdit.Add("firstName", firstNameForEdit);
            dictionaryForEdit.Add("lastName", lastNameForEdit);
            dictionaryForEdit.Add("email", emailForEdit);
            json = JsonGenerator.JsonRequest(dictionaryForEdit);
            var addContact = AddNewContact(json);
            var addedContactId = GetId(addContact.Content);
            var deleteContact = DeleteContact(addedContactId);
            Assert.AreEqual(HttpStatusCode.OK, deleteContact.StatusCode);
            var getDeletedContact = GetContactById(addedContactId);
            Assert.AreEqual(HttpStatusCode.NotFound, getDeletedContact.StatusCode);
        }
    }

    [TestFixture]
    public class SaasApiTestsMethods : BaseClass
    {
        [Test, Category("Positive: HealthCheck")]
        public void HealthCheckTest()
        {

            var healthCheck = GetHealthCheck();
            Assert.AreEqual(HttpStatusCode.OK, healthCheck.StatusCode);
            Assert.IsTrue(healthCheck.Content.Contains("live"));
        }

        [Test, Category("Positive: Get application")]
        public void GetApplicationTest()
        {
            var getApplication = GetApplication();
            Assert.IsTrue(getApplication.Content.Contains("Software Engineering Course"));
            Assert.AreEqual(HttpStatusCode.OK, getApplication.StatusCode);
        }

        [Test, Category("Negative: Not Allowed Http Methods Check")]
        public void ApplicationOptionsTest()
        {
            var getOptions = MethodOptionsCheck(Properties.Settings.Default.ApplicationUrl);
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, getOptions.StatusCode);
        }

        [Test, Category("Negative: Not Allowed Http Methods Check")]
        public void ApplicationHeadTest()
        {
            var getOptions = MethodHeadCheck(Properties.Settings.Default.ApplicationUrl);
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, getOptions.StatusCode);
        }

        [Test, Category("Negative: Not Allowed Http Methods Check")]
        public void ApplicationPostTest()
        {
            var getOptions = MethodPostCheck(Properties.Settings.Default.ApplicationUrl);
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, getOptions.StatusCode);
        }

        [Test, Category("Negative: Not Allowed Http Methods Check")]
        public void ApplicationPutTest()
        {
            var getOptions = MethodPutCheck(Properties.Settings.Default.ApplicationUrl);
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, getOptions.StatusCode);
        }

        [Test, Category("Negative: Not Allowed Http Methods Check")]
        public void ApplicationPatchTest()
        {
            var getOptions = MethodPatchCheck(Properties.Settings.Default.ApplicationUrl);
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, getOptions.StatusCode);
        }

        [Test, Category("Negative: Not Allowed Http Methods Check")]
        public void ApplicationDeleteTest()
        {
            var getOptions = MethodDeleteCheck(Properties.Settings.Default.ApplicationUrl);
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, getOptions.StatusCode);
        }

        [Test, Category("Negative: Not Allowed Http Methods Check")]
        public void HealthCheckOptionsTest()
        {
            var getOptions = MethodOptionsCheck(Properties.Settings.Default.HealthcheckUrl);
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, getOptions.StatusCode);
        }

        [Test, Category("Negative: Not Allowed Http Methods Check")]
        public void HealthCheckHeadTest()
        {
            var getOptions = MethodHeadCheck(Properties.Settings.Default.HealthcheckUrl);
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, getOptions.StatusCode);
        }

        [Test, Category("Negative: Not Allowed Http Methods Check")]
        public void HealthCheckPostTest()
        {
            var getOptions = MethodPostCheck(Properties.Settings.Default.HealthcheckUrl);
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, getOptions.StatusCode);
        }

        [Test, Category("Negative: Not Allowed Http Methods Check")]
        public void HealthCheckPutTest()
        {
            var getOptions = MethodPutCheck(Properties.Settings.Default.HealthcheckUrl);
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, getOptions.StatusCode);
        }

        [Test, Category("Negative: Not Allowed Http Methods Check")]
        public void HealthCheckPatchTest()
        {
            var getOptions = MethodPatchCheck(Properties.Settings.Default.HealthcheckUrl);
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, getOptions.StatusCode);
        }

        [Test, Category("Negative: Not Allowed Http Methods Check")]
        public void HealthCheckDeleteTest()
        {
            var getOptions = MethodDeleteCheck(Properties.Settings.Default.HealthcheckUrl);
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, getOptions.StatusCode);
        }

        [Test, Category("Negative: Not Allowed Http Methods Check")]
        public void ContactsOptionsTest()
        {
            var getOptions = MethodOptionsCheck(Properties.Settings.Default.ContactsUrl);
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, getOptions.StatusCode);
        }

        [Test, Category("Negative: Not Allowed Http Methods Check")]
        public void ContactsHeadTest()
        {
            var getOptions = MethodHeadCheck(Properties.Settings.Default.ContactsUrl);
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, getOptions.StatusCode);
        }

        [Test, Category("Negative: Not Allowed Http Methods Check")]
        public void ContactsPostTest()
        {
            var getOptions = MethodPostCheck(Properties.Settings.Default.ContactsUrl);
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, getOptions.StatusCode);
        }

        [Test, Category("Negative: Not Allowed Http Methods Check")]
        public void ContactsPutTest()
        {
            var getOptions = MethodPutCheck(Properties.Settings.Default.ContactsUrl);
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, getOptions.StatusCode);
        }

        [Test, Category("Negative: Not Allowed Http Methods Check")]
        public void ContactsPatchTest()
        {
            var getOptions = MethodPatchCheck(Properties.Settings.Default.ContactsUrl);
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, getOptions.StatusCode);
        }

        [Test, Category("Negative: Not Allowed Http Methods Check")]
        public void ContactsDeleteTest()
        {
            var getOptions = MethodDeleteCheck(Properties.Settings.Default.ContactsUrl);
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, getOptions.StatusCode);
        }

        [Test, Category("Negative: Not Allowed Http Methods Check")]
        public void ContactsByIdOptionsTest()
        {
            int id = 1;
            var getOptions = MethodOptionsCheck(Properties.Settings.Default.ContactsUrl + id);
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, getOptions.StatusCode);
        }

        [Test, Category("Negative: Not Allowed Http Methods Check")]
        public void ContactsByIdHeadTest()
        {
            int id = 1;
            var getOptions = MethodHeadCheck(Properties.Settings.Default.ContactsUrl + id);
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, getOptions.StatusCode);
        }
    }
}
