using ApiTests.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTests
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Faker.Name.First();
            string lastName = Faker.Name.Last();
            string email = Faker.Internet.Email(firstName + " " + lastName);
            JsonBodyGenerator jsonBodyData = new JsonBodyGenerator();
            jsonBodyData.Add("firstName", firstName);
            jsonBodyData.Add("lastName", lastName);
            jsonBodyData.Add("email", email);

            String jsonbody = JsonConvert.SerializeObject(jsonBodyData, Formatting.Indented);
            Console.WriteLine(jsonbody);
        }
    }
}
