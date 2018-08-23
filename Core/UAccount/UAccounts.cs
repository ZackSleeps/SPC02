using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC02.Core.UAccounts
{
    public static class UAccounts
    {
        private static List<UAccount> accounts;

        private static string accountsFile = "Resources/accounts.json";

        static UAccounts()
        {
            if (DataStorage.SaveExist(accountsFile))
            {
                accounts = DataStorage.LoadUserAccount(accountsFile).ToList();
            }
            else
            {
                accounts = new List<UAccount>();
                SaveAccounts();
            }
        }
        public static void SaveAccounts()
        {
            DataStorage.SaveUserAccounts(accounts, accountsFile);
        }

        public static UAccount GetAccount(SocketUser user)
        {
            return GetOrCreateAccount(user.Id);
        }
        private static UAccount GetOrCreateAccount(ulong id)
        {
            var result = from a in accounts
                         where a.ID == id
                         select a;
            var account = result.FirstOrDefault();
            if (account == null) account = CreateUserAccount(id);

            return account;
        }

        private static UAccount CreateUserAccount(ulong id)
        {
            var newAccount = new UAccount()
            {
                ID = id,
                points = 0,
                EXP = 0
            };
            accounts.Add(newAccount);
            SaveAccounts();
            return newAccount;
        }
    }
}
