using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language
{
    public class Language
    {
        static Language instance;
        public static Language Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Language();
                }
                return instance;
            }
        }

        Dictionary<string, string> strings = new Dictionary<string, string>();
        Language()
        {

        }

        public string GetValue(string key)
        {
            string value="Unknown";
            strings.TryGetValue(key, out value);
            return value;
        }
    }
}
