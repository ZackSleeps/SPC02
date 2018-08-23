using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC02.Core.UAccounts
{
   public class UAccount
    {
        public ulong ID { get; set; }

        public uint points { get; set; }

        public int EXP { get; set; }

        public uint lvlnumber
        {
            get
            {
                
                return (uint)Math.Sqrt(EXP / 90);
            }
        }
    }
}
