using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.DirectoryServices;
using Microsoft.ActiveDirectory;
using System.Configuration; 

namespace Microsoft.WebadminTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Utility.RootDC);
           // DirectoryEntry de = Utility.GetUser("wangsan");

           //string s= Utility.GetProperty(de, "pwdlastset");
           //Console.WriteLine(s);


            string accountType = "A";

            string accountName = "fbei6";

            string InitPassword = "Password01!";
            //ADUser user = ADManager.CreateUser(ConfigurationManager.AppSettings["ADUserDefaultPath"], accountName, InitPassword);
            ADUser user = ADManager.LoadUser(accountName);
            user.ExtensionAttribute1 = "aa11";
            user.ExtensionAttribute2 = "aa222";
            user.ExtensionAttribute3 = "sss";
            user.FirstName = "bei";
            //user.LastName = "feng";
            //user.UserPrincipalName = accountName + "@cn.com";
            //user.MiddleInitial = "b" + "." + "f";

            user.ExtensionAttribute1 = accountType;
            //user.ExtensionAttribute2 = "aad";
            user.Manager = "admin";
            user.Update();



            DateTime expireDate = DateTime.Now;
            if (accountType == "A" || accountType == "M" || accountType == "S")
            {
                expireDate.AddMonths(3);
            }
            else
            {
                expireDate = new DateTime(1970, 1, 1);
            }
            ADUser.SetAccountExpireDate(accountName, expireDate);
            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}
