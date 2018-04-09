using ApiTests.models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTests.Models
{
    public class JsonGenerator
    {
        public static string JsonRequest(IDictionary dictionary)
        {
            string jsonRequest = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
            return jsonRequest;
        }
    }
}
