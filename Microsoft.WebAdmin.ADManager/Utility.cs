using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.Configuration;
 

namespace Microsoft.ActiveDirectory
{
    public static class Utility
    {
        public static string ADPath = ConfigurationSettings.AppSettings["ADPath"];
        public static string OrgRootPath = ConfigurationSettings.AppSettings["OrgRootPath"];
        public static string ADAdmin = ConfigurationSettings.AppSettings["ADAdmin"];
        public static string ADPasword = ConfigurationSettings.AppSettings["ADPasword"];
        public static string ADDomainName = ConfigurationSettings.AppSettings["ADDomainName"];

        //cn\admin
        public static string ADUser = ADDomainName + "\\" + ADAdmin;

        public static string RootDC
        {
            get 
            {
                DirectoryEntry de = GetDirectoryObject();
                string dn = GetProperty(de, ADAttributes.DistinguishedName);
                de.Close();

                return dn;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountName"></param> admin  cn\admin
        /// <returns></returns>
        public static DirectoryEntry GetUser(string accountName)
        {
            int lastIndex = accountName.LastIndexOf("\\");
            if (lastIndex>0)
            {
                accountName = accountName.Substring(lastIndex + 1);
            }

            DirectoryEntry de = GetDirectoryObject();
            DirectorySearcher deSearch = new DirectorySearcher();
            deSearch.SearchRoot = de;
            deSearch.Filter = "(&(objectClass=user)(sAMAccountName="+accountName+"))";
            deSearch.SearchScope = SearchScope.Subtree;
            SearchResult results = deSearch.FindOne();
            if (results!=null)
            {
                return new DirectoryEntry(results.Path, ADUser, ADPasword, AuthenticationTypes.Secure);
            }
            else
            {
                return null;
            } 
        }

        public static DirectoryEntry GetUser(string accountName,string password)
        {
            DirectoryEntry de = GetDirectoryObject(accountName, password);
            DirectorySearcher deSearch = new DirectorySearcher();
            deSearch.SearchRoot = de;
            deSearch.Filter = "(&(objectClass=user)(sAMAccountName=" + accountName + "))";
            deSearch.SearchScope = SearchScope.Subtree;
            SearchResult results = deSearch.FindOne();
            if (results != null)
            {
                return new DirectoryEntry(results.Path, ADUser, ADPasword, AuthenticationTypes.Secure);
            }
            else
            {
                return null;
            } 
        }

       

        internal static DirectoryEntry GetDirectoryObject()
        {
            DirectoryEntry de;
            de = new DirectoryEntry(ADPath, ADUser, ADPasword);
            return de;
        }
        internal static DirectoryEntry GetDirectoryObject(string userName, string Password)
        {
            DirectoryEntry de;
            de = new DirectoryEntry(ADPath, userName, Password);
            return de;
        }
        internal static DirectoryEntry GetDirectoryObject(string distinguishedName)
        {
            DirectoryEntry de;
            de = new DirectoryEntry(string.Format("{0}/{1}", ADPath, distinguishedName),
                                    ADUser, ADPasword,AuthenticationTypes.Secure);
            return de;
        }
        internal static DirectoryEntry GetDirectoryObjectByDomainReference(string objectPath)
        {
            DirectoryEntry de;
            de = new DirectoryEntry(objectPath, ADUser, ADPasword,AuthenticationTypes.Secure);
            return de;
        }

        internal static bool IsAccountActive(int userAccountControl)
        {
            int userAccounControl_Disabled = Convert.ToInt32(AccountOptions.ADS_UF_ACCOUNTDISABLE);
            int flagExists = userAccountControl & userAccounControl_Disabled;
            if (flagExists>0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        internal static void SetUserPassword(DirectoryEntry de,string newPassword)
        {
            de.Invoke("SetPassword",new object[]{newPassword});
        }
        internal static void ChangeUserPassword(DirectoryEntry de, string oldPassword, string newPassword)
        {
            de.Invoke("ChangePassword", new object[] { oldPassword,newPassword});
        }

        internal static DirectoryEntry GetGroup(string commonName)
        { 
            DirectoryEntry de = GetDirectoryObject();
            DirectorySearcher deSearch = new DirectorySearcher();
            deSearch.SearchRoot = de;
            deSearch.Filter = "(&(objectClass=group)(sAMAccountName=" + commonName + "))";
            deSearch.SearchScope = SearchScope.Subtree;
            SearchResult results = deSearch.FindOne();
            if (results != null)
            {
                return new DirectoryEntry(results.Path, ADUser, ADPasword, AuthenticationTypes.Secure);
            }
            else
            {
                return null;
            } 
        }
        internal static DirectoryEntry GetGroupByAccount(string v_groupAccountName)
        {
            int lastIndex = v_groupAccountName.LastIndexOf("\\");
            if (lastIndex > 0)
            {
                v_groupAccountName = v_groupAccountName.Substring(lastIndex + 1);
            }

            DirectoryEntry de = GetDirectoryObject();
            DirectorySearcher deSearch = new DirectorySearcher();
            deSearch.SearchRoot = de;
            deSearch.Filter = "(&(objectClass=user)(sAMAccountName=" + v_groupAccountName + "))";
            deSearch.SearchScope = SearchScope.Subtree;
            SearchResult results = deSearch.FindOne();
            if (results != null)
            {
                return new DirectoryEntry(results.Path, ADUser, ADPasword, AuthenticationTypes.Secure);
            }
            else
            {
                return null;
            } 
        }
        internal static DirectoryEntry GetOrganizationalUnit(string ouName)
        {
            DirectoryEntry de = GetDirectoryObject();
            DirectorySearcher deSearch = new DirectorySearcher();
            deSearch.SearchRoot = de;
            deSearch.Filter = "(&(objectClass=organizationalUnit)(name=" + ouName + "))";
            deSearch.SearchScope = SearchScope.Subtree;
            SearchResult results = deSearch.FindOne();
            if (results != null)
            {
                return new DirectoryEntry(results.Path, ADUser, ADPasword, AuthenticationTypes.Secure);
            }
            else
            {
                return null;
            } 
        }
        public static string GetProperty(DirectoryEntry de, string propertyName)
        {
            if (de.Properties.Contains(propertyName))
            {
                if (propertyName.ToLower() == "objectguid")
                {
                    Guid guid = new Guid((byte[])de.Properties[propertyName][0]);
                    return guid.ToString();
                }
                if (propertyName.ToLower() == "objectsid")
                {
                    string sid = Encoding.ASCII.GetString((byte[])de.Properties[propertyName][0]);
                    return sid;
                }
                if (propertyName.ToLower() == "pwdlastset")
                {
                    return DateTime.FromFileTime(ConvertLargeIntegerToLong(de.Properties["pwdLastSet"].Value)).ToString();
                
                }
                if (propertyName.ToLower() == "manager")
                {
                    string[] manager = de.Properties["manager"].Value.ToString().Split(',');
                    if (manager.Length > 0)
                    {
                        return manager[0].Replace("CN=", "");
                    }
                    else
                    {
                        return string.Empty;
                    }
                }

                return de.Properties[propertyName][0].ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        private static long ConvertLargeIntegerToLong(object largeInteger)
        {
            Type type = largeInteger.GetType();
            int highPart = (int)type.InvokeMember("HighPart", System.Reflection.BindingFlags.GetProperty, null, largeInteger, null);
            int lowPart = (int)type.InvokeMember("HighPart", System.Reflection.BindingFlags.GetProperty, null, largeInteger, null);
            return (long)highPart << 32 | (uint)lowPart;
        }
        internal static void SetProperty(DirectoryEntry de, string propertyName,string propertyValue)
        {
            if (!string.IsNullOrEmpty(propertyValue))
            {
                if (de.Properties.Contains(propertyName))
                {
                    de.Properties[propertyName][0] = propertyValue;
                }
                else
                {
                    de.Properties[propertyName].Add(propertyValue);
                }
            }
            else
	        {
                de.Properties[propertyName].Clear();
	        }
        }
        
    }
}
