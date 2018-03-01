using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTests.models
{
    public class Info
    {
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

    public class Refs
    {
        public string patch { get; set; }
        public string get { get; set; }
        public string delete { get; set; }
        public string put { get; set; }
    }

    public class Datum
    {
        public int id { get; set; }
        public Info info { get; set; }
        public Refs refs { get; set; }
    }

    public class RootObject
    {
        public List<Datum> data { get; set; }
        public string message { get; set; }
        public int status { get; set; }
    }
}
