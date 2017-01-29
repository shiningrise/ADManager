using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;

namespace Microsoft.ActiveDirectory
{
    public static  class ADManager
    {
        public static bool IsUserValid(string accountName, string password)
        {
            try
            {
                DirectoryEntry deUser =Utility.GetUser(accountName, password);
                deUser.Close();
                return true;
            }
            catch (Exception ee)
            {
                return false;
            }
        }
        public static ADUser LoadUser(string accountName)
        {
            return ADUser.Load(accountName);
        }
        public static bool IsUserExists(string accountName)
        {
            DirectoryEntry de = Utility.GetDirectoryObject();
            DirectorySearcher deSearch = new DirectorySearcher();
            deSearch.SearchRoot = de;
            deSearch.Filter = "(&(objectClass=user)(sAMAccountName="+accountName+"))";
            SearchResultCollection results = deSearch.FindAll();
            if (results.Count==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool IsGroupExists(string commonName)
        {
            DirectoryEntry de = Utility.GetDirectoryObject();
            DirectorySearcher deSearch = new DirectorySearcher();
            deSearch.SearchRoot = de;
            deSearch.Filter = "(&(objectClass=group)(cn=" + commonName + "))";
            SearchResultCollection results = deSearch.FindAll();
            if (results.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool IsOUExists(string ouName)
        {
            DirectoryEntry de = Utility.GetDirectoryObject();
            DirectorySearcher deSearch = new DirectorySearcher();
            deSearch.SearchRoot = de;
            deSearch.Filter = "(&(objectClass=organizationalUnit)(name=" + ouName + "))";
            SearchResultCollection results = deSearch.FindAll();
            if (results.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static ADUser CreateUser(string path, string acountName, string Password)
        {
            return CreateUser(path, acountName,acountName, Password);
        }
        public static ADUser CreateUser(string path, string commonName, string accountName, string password)
        {
            return CreateUser(path, commonName, accountName, password, AccountOptions.ADS_UF_NORMAL_ACCOUNT);
        }
        public static ADUser CreateUser(string path, string commonName, string accountName, string password,AccountOptions accountOptions)
        {
            DirectoryEntry enty = Utility.GetDirectoryObject(path);
            DirectoryEntries children = enty.Children;
            DirectoryEntry userEnty = children.Add("CN=" + commonName, "user");
            userEnty.Properties[ADAttributes.AccountName].Add(accountName);
            userEnty.Properties[ADAttributes.AccountName].Value = accountName;
            userEnty.CommitChanges();

            userEnty.Invoke("SetPassword", new object[] {password });
            userEnty.Properties[ADAttributes.UserAccountControl].Value = accountOptions;
            userEnty.CommitChanges();

            return ADUser.Load(accountName);
        }
        public static void SetUserAccountOptions(string accountName, AccountOptions accountOption)
        {
            DirectoryEntry entry = ADUser.Load(accountName).GetDirectoryEntry();
            entry.Properties[ADAttributes.UserAccountControl][0] = accountOption;
            entry.CommitChanges();
            entry.Close();
        }

        public static IList<ADUser> GetLockedUsers(string userNameFilter)
        {
            IList<ADUser> list = new List<ADUser>();
            ADUser user;
            bool includeSubtree=true;
            string filter=string.Format("(&(objectCategory=Person)(objectClass=User)(lockoutTime>=1){0})",userNameFilter);
            DirectorySearcher search=new DirectorySearcher();
            search.SearchRoot=Utility.GetDirectoryObject();
            search.Filter=filter;
            if (includeSubtree)
	        {
                search.SearchScope=SearchScope.Subtree;
	        }
            else
	        {
                search.SearchScope=SearchScope.OneLevel;
	        }
            SearchResultCollection seColl=search.FindAll();
            foreach (SearchResult item in seColl)
	        {
                DirectoryEntry de=new DirectoryEntry(item.Path,Utility.ADUser,Utility.ADPasword,AuthenticationTypes.Secure);
                user=ADUser.Load(de);
                list.Add(user);
	        }
            return list;
        }
        public static IList<ADUser> LoadAllUsersByFilter(string filter)
        {
            return LoadUsers(GetFilterObjects(filter));
        }
        private static SearchResultCollection GetFilterObjects(string filter)
        {
            DirectoryEntry de=Utility.GetDirectoryObject();
            DirectorySearcher deSearch=new DirectorySearcher();
            deSearch.SearchRoot=de;
            deSearch.Filter=filter;
            deSearch.PageSize=1000;
            deSearch.SearchScope=SearchScope.Subtree;
            return deSearch.FindAll();
        }
        public static IList<ADUser> LoadAllUsers()
        {
            return LoadAllUsers(null);
        }
        public static IList<ADUser> LoadAllUsers(string objectPath)
        {
            return LoadAllUsers(objectPath, true);
        }
        public static IList<ADUser> LoadAllUsers(string objectPath, bool includeSubTree)
        {
            return LoadUsers(GetUsers(objectPath, includeSubTree));
        }
        private static IList<ADUser> LoadUsers(SearchResultCollection seCollection)
        {
            IList<ADUser> list = new List<ADUser>();
            ADUser user;
            foreach (SearchResult searchResult in seCollection)
            {
                DirectoryEntry de = new DirectoryEntry(searchResult.Path, Utility.ADUser, Utility.ADPasword, AuthenticationTypes.Secure);
                user = ADUser.Load(de);

                list.Add(user);
            }
            return list;
        }
        private static SearchResultCollection GetUsers()
        {
            return GetUsers(null, true);
        }
        private static SearchResultCollection GetUsers(string distinguishedName)
        {
            return GetUsers(distinguishedName, true);
        }
        private static SearchResultCollection GetUsers(string distinguishedName, bool includeSubTree)
        {
            string filter = "(&(objectClass=user)(objectCategory=person))";
            return GetObjects(distinguishedName, filter, includeSubTree);
        }
        private static SearchResultCollection GetObjects(string distinguishedName,   string filter,bool includeSubTree)
        {
            DirectoryEntry de;
            if (string.IsNullOrEmpty(distinguishedName))
            {
                de = Utility.GetDirectoryObject();
            }
            else
            {
                de = Utility.GetDirectoryObject(distinguishedName);
            }
            DirectorySearcher deSearch = new DirectorySearcher();
            deSearch.SearchRoot = de;
            deSearch.Filter = filter;
            //deSearch.SizeLimit = 2000;
            deSearch.PageSize = 1000;
            if (includeSubTree)
            {
                deSearch.SearchScope = SearchScope.Subtree;
            }
            else
            {
                deSearch.SearchScope = SearchScope.OneLevel;
            }
            return deSearch.FindAll();
        }
    }

}
