using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace SPC02
{
    class Utilities
    {
        private static Dictionary<string, string> save;
       static Utilities()
        {
            string json = File.ReadAllText("saved/save.json");
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            save = data.ToObject<Dictionary<string, string>>();
        }
        public static string Getsave(string key)
        {
            if (save.ContainsKey(key)) return save[key];
            return "";
        }
        public static string GetFormattedsave(string key, params object[] parameter)
        {
            if (save.ContainsKey(key))
            {
                return String.Format(save[key], parameter);
            }
            return "";
        }
            public static string GetFormattedsave(string key, object parameter)
        {
            if (save.ContainsKey(key))
            {
                return GetFormattedsave(key, new object[] { parameter});
            }
            return "";
        }

   }
}
