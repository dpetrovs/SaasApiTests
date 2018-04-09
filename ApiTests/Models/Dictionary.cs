using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTests.Models
{
    public class Dictionary : DictionaryBase
    {
        public void Add(String key, String value)
        {
            Dictionary.Add(key, value);
        }

        public void RemoveElementByKey(String key)
        {
            Dictionary.Remove(key);
        }

        public void ClearAll()
        {
            Dictionary.Clear();
        }
    }
}
