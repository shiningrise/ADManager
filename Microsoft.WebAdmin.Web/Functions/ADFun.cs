using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ActiveDirectory;

namespace Microsoft.WebAdmin.Web
{
    public class ADFun
    {
        public static string GetSuitableAccountName(string accountName)
        {
            bool f = false;
            string tempAccount = accountName;
            int i = 0;
            do
            {
                f = ADManager.IsUserExists(tempAccount);
                if (!f)
                {
                    break;
                }
                else
                {
                    i++;
                    tempAccount = accountName + i.ToString();
                }
            } while (f);
            return tempAccount;
        }
    }
}