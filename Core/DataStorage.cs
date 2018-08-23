using SPC02.Core.UAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace SPC02.Core
{
    public static class DataStorage
    {
        // Save all UsersA
        //Serializing an Object
        public static void SaveUserAccounts(IEnumerable<UAccount> accounts, string filePath)
        {
            string json = JsonConvert.SerializeObject(accounts);
            File.WriteAllText(filePath, json);
        }

        // Get All UserA
        public static IEnumerable<UAccount> LoadUserAccount(string filePath)
        {
            if (!File.Exists(filePath)) return null;
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<UAccount>>(json);
        }
        public static bool SaveExist(string filePath)
        {
            return File.Exists(filePath);
        }

        internal static string GetPairCount()
        {
            throw new NotImplementedException();
        }
    }
}
