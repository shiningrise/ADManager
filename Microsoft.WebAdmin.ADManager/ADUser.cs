using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;

namespace Microsoft.ActiveDirectory
{
    [Serializable]
    public class ADUser : ADObject
    {
        private string _firstName;			//givenName
        private string _middleInitial;		//initials
        private string _lastName;			//sn
        private string _displayName;		//Name
        private string _userPrincipalName;	//userPrincipalName (e.g. user@domain.local)
        private string _department;         //Department
        private string _company;            //Company
        private string _city;
        private string _postalAddress;
        private string _streetAddress;		//StreetAddress
        private string _homePostalAddress;  //HomePostalAddress
        private string _title;
        private string _homePhone;
        private string _telephoneNumber;	//TelephoneNumber
        private string _mobile;
        private string _fax;				//FacsimileTelephoneNumber
        private string _email;				//mail
        private string _url;                //web page
        private string _accountName;		//sAMAccountName
        private string _password;
        private string _ipPhone;	        //IP Phones
        private string _pager;              //Pager
        private int _userAccountControl;
        private string _office;
        private string _info;
        private string _postalCode;
        private string _manager;            //manager
        private string _country;            //country

        private string _extensionAttribute1;
        private string _extensionAttribute2;
        private string _extensionAttribute3;
        private string _extensionAttribute4;
        private string _extensionAttribute5;
        private string _extensionAttribute6;
        private string _extensionAttribute7;
        private string _extensionAttribute8;
        private string _extensionAttribute9;
        private string _extensionAttribute10;

        private IList<ADGroup> _groups;     //groups that user belongs to. 

        public ADUser()
        {
            _groups = new List<ADGroup>();
        }

        #region Properties

        /// <summary>
        /// The firt name of user.
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }

        public string Info
        {
            get { return _info; }
            set { _info = value; }
        }

        /// <summary>
        /// The middle initial name of user.
        /// </summary>
        public string MiddleInitial
        {
            get
            {
                return _middleInitial;
            }
            set
            {
                if (value.Length > 6)
                    throw new NotSupportedException("MiddleInitial cannot be more than six characters");

                _middleInitial = value;
            }
        }

        /// <summary>
        /// The last name of user.
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        /// <summary>
        /// The display name of user. e.g. ÕÅÈý
        /// </summary>
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        /// <summary>
        /// The principal name of user. e.g. microsoft@msft.local
        /// </summary>
        public string UserPrincipalName
        {
            get { return _userPrincipalName; }
            set { _userPrincipalName = value; }
        }

        /// <summary>
        /// Department name.
        /// </summary>
        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        /// <summary>
        /// Company name.
        /// </summary>
        public string Company
        {
            get { return _company; }
            set { _company = value; }
        }

        /// <summary>
        /// Postal address of the user.
        /// </summary>
        public string PostalAddress
        {
            get { return _postalAddress; }
            set { _postalAddress = value; }
        }

        /// <summary>
        /// Street address.
        /// </summary>
        public string StreetAddress
        {
            get { return _streetAddress; }
            set { _streetAddress = value; }
        }

        /// <summary>
        /// Home postal address.
        /// </summary>
        public string HomePostalAddress
        {
            get { return _homePostalAddress; }
            set { _homePostalAddress = value; }
        }

        /// <summary>
        /// User title.
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// Home phone of the user.
        /// </summary>
        public string HomePhone
        {
            get { return _homePhone; }
            set { _homePhone = value; }
        }

        /// <summary>
        /// Telephone number.
        /// </summary>
        public string TelephoneNumber
        {
            get { return _telephoneNumber; }
            set { _telephoneNumber = value; }
        }

        /// <summary>
        /// Mobile phone number.
        /// </summary>
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }

        /// <summary>
        /// Fax number.
        /// </summary>
        public string FacsimileTelephoneNumber
        {
            get { return _fax; }
            set { _fax = value; }
        }

        /// <summary>
        /// Email address. e.g. microsoft@msft.local
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        /// Web homepage url.
        /// </summary>
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        /// <summary>
        /// The user account name.
        /// </summary>
        public string AccountName
        {
            get { return _accountName; }
            set { _accountName = value; }
        }

        /// <summary>
        /// User password.
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        /// <summary>
        /// IP phone.
        /// </summary>
        public string IPPhone
        {
            get { return _ipPhone; }
            set { _ipPhone = value; }
        }

        /// <summary>
        /// Pager.
        /// </summary>
        public string Pager
        {
            get { return _pager; }
            set { _pager = value; }
        }

        public string Office
        {
            get { return _office; }
            set { _office = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        /// <summary>
        /// Extension attrbute 1.
        /// </summary>
        public string ExtensionAttribute1
        {
            get { return _extensionAttribute1; }
            set { _extensionAttribute1 = value; }
        }

        /// <summary>
        /// Extension attrbute 2.
        /// </summary>
        public string ExtensionAttribute2
        {
            get { return _extensionAttribute2; }
            set { _extensionAttribute2 = value; }
        }

        /// <summary>
        /// Extension attrbute 3.
        /// </summary>
        public string ExtensionAttribute3
        {
            get { return _extensionAttribute3; }
            set { _extensionAttribute3 = value; }
        }

        /// <summary>
        /// Extension attrbute 4.
        /// </summary>
        public string ExtensionAttribute4
        {
            get { return _extensionAttribute4; }
            set { _extensionAttribute4 = value; }
        }

        /// <summary>
        /// Extension attrbute 5.
        /// </summary>
        public string ExtensionAttribute5
        {
            get { return _extensionAttribute5; }
            set { _extensionAttribute5 = value; }
        }

        /// <summary>
        /// Extension attrbute 6.
        /// </summary>
        public string ExtensionAttribute6
        {
            get { return _extensionAttribute6; }
            set { _extensionAttribute6 = value; }
        }

        /// <summary>
        /// Extension attrbute 7.
        /// </summary>
        public string ExtensionAttribute7
        {
            get { return _extensionAttribute7; }
            set { _extensionAttribute7 = value; }
        }

        /// <summary>
        /// Extension attrbute 8.
        /// </summary>
        public string ExtensionAttribute8
        {
            get { return _extensionAttribute8; }
            set { _extensionAttribute8 = value; }
        }

        /// <summary>
        /// Extension attrbute 9.
        /// </summary>
        public string ExtensionAttribute9
        {
            get { return _extensionAttribute9; }
            set { _extensionAttribute9 = value; }
        }

        /// <summary>
        /// Extension attrbute 10.
        /// </summary>
        public string ExtensionAttribute10
        {
            get { return _extensionAttribute10; }
            set { _extensionAttribute10 = value; }
        }

        /// <summary>
        /// User account active flag. Read-only.
        /// </summary>
        public bool IsAccountActive
        {
            get
            {
                return Utility.IsAccountActive(this.UserAccountControl);
            }
        }

        public string Manager
        {
            get { return _manager; }
            set { _manager = value; }
        }

        /// <summary>
        /// User account control flag.
        /// </summary>
        public int UserAccountControl
        {
            get { return _userAccountControl; }
            set { _userAccountControl = value; }
        }

        public string UserDePath
        {
            get { return DE.Path; }
        }
        #endregion

        public IList<ADGroup> Groups
        {
            get
            {
                if (_groups==null)
                {
                    _groups=new List<ADGroup>();
                }

                if (_groups.Count==0)
                {
                    _groups = ADGroup.LoadGroupsByUser(DomainReference);
                }

                return _groups;
            }
            set
            {
                _groups = value;
            }
        }

        public bool IsInGroup(string groupName)
        {
            for (int i = 0; i < this.Groups.Count; i++)
            {
                if (this.Groups[i].Name.Equals(groupName))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Update the user attribute.
        /// </summary>
        public void Update()
        {
            try
            {
                DirectoryEntry de = Utility.GetUser(_accountName);

                Utility.SetProperty(de, ADAttributes.FirstName, _lastName);
                Utility.SetProperty(de, ADAttributes.MiddleInitial, _middleInitial);
                Utility.SetProperty(de, ADAttributes.LastName, _firstName);
                Utility.SetProperty(de, ADAttributes.DisplayName, _displayName);
                Utility.SetProperty(de, ADAttributes.UserPrincipalName, _userPrincipalName);
                Utility.SetProperty(de, ADAttributes.PostalAddress, _postalAddress);
                Utility.SetProperty(de, ADAttributes.StreetAddress, _streetAddress);
                Utility.SetProperty(de, ADAttributes.HomePostalAddress, _homePostalAddress);
                Utility.SetProperty(de, ADAttributes.Title, _title);
                Utility.SetProperty(de, ADAttributes.HomePhone, _homePhone);
                Utility.SetProperty(de, ADAttributes.TelephoneNumber, _telephoneNumber);
                Utility.SetProperty(de, ADAttributes.Mobile, _mobile);
                Utility.SetProperty(de, ADAttributes.FacsimileTelephoneNumber, _fax);
                Utility.SetProperty(de, ADAttributes.Email, _email);
                Utility.SetProperty(de, ADAttributes.Url, _url);
                Utility.SetProperty(de, ADAttributes.IPPhone, _ipPhone);
                Utility.SetProperty(de, ADAttributes.Pager, _pager);
                Utility.SetProperty(de, ADAttributes.Department, _department);
                Utility.SetProperty(de, ADAttributes.Company, _company);
                Utility.SetProperty(de, ADAttributes.Office, _office);
                Utility.SetProperty(de, ADAttributes.City, _city);
                Utility.SetProperty(de, ADAttributes.PostalCode, _postalCode);
                Utility.SetProperty(de, ADAttributes.Info, _info);
                Utility.SetProperty(de, ADAttributes.Description, _description);

                ////if (_country.ToLower()=="china" || _country=="中国")
                ////{
                ////    Utility.SetProperty(de, ADAttributes.Country, "CN");
                ////}
                ////if (_country.ToLower() == "japan" || _country == "日本")
                ////{
                ////    Utility.SetProperty(de, ADAttributes.Country, "JP");
                ////}
                Utility.SetProperty(de, ADAttributes.Country, _country);
                if (_manager.Length > 0)
                {
                    DirectoryEntry deManager = Utility.GetUser(_manager);
                    if (deManager != null)
                    {
                        string path = deManager.Path;
                        int indexPath = path.IndexOf("CN=");
                        Utility.SetProperty(de, ADAttributes.Manager, path.Substring(indexPath));
                    }
                }
                else
                {
                    Utility.SetProperty(de, ADAttributes.Manager, string.Empty);
                }

                Utility.SetProperty(de, ADAttributes.ExtensionAttribute1, _extensionAttribute1);
                Utility.SetProperty(de, ADAttributes.ExtensionAttribute2, _extensionAttribute2);
                Utility.SetProperty(de, ADAttributes.ExtensionAttribute3, _extensionAttribute3);
                //Utility.SetProperty(de, ADAttributes.ExtensionAttribute4, _extensionAttribute4);
                //Utility.SetProperty(de, ADAttributes.ExtensionAttribute5, _extensionAttribute5);
                //Utility.SetProperty(de, ADAttributes.ExtensionAttribute6, _extensionAttribute6);
                //Utility.SetProperty(de, ADAttributes.ExtensionAttribute7, _extensionAttribute7);
                //Utility.SetProperty(de, ADAttributes.ExtensionAttribute8, _extensionAttribute8);
                //Utility.SetProperty(de, ADAttributes.ExtensionAttribute9, _extensionAttribute9);
                //Utility.SetProperty(de, ADAttributes.ExtensionAttribute10, _extensionAttribute10);

                de.CommitChanges();
                de.Close();
            }
            catch (Exception e)
            {
                throw new Exception("User can not be updated. " + e.Message);
            }
        }
        internal static ADUser Load(DirectoryEntry directoryEntry)
        {
            if (null == directoryEntry)
            {
                return null;
            }

            ADUser user = new ADUser();
            user.DE = directoryEntry;

            user.ObjectGUID = Utility.GetProperty(directoryEntry, ADAttributes.ObjectGuid);
            user.ObjectSid = Utility.GetProperty(directoryEntry, ADAttributes.ObjectSid);
            user.FirstName = Utility.GetProperty(directoryEntry, ADAttributes.LastName);
            user.MiddleInitial = Utility.GetProperty(directoryEntry, ADAttributes.MiddleInitial);
            user.LastName = Utility.GetProperty(directoryEntry, ADAttributes.FirstName);
            user.UserPrincipalName = Utility.GetProperty(directoryEntry, ADAttributes.UserPrincipalName);
            //user.CanonicalName      = Utility.GetProperty(directoryEntry, ADAttributes.CanonicalName);
            user.DisplayName = Utility.GetProperty(directoryEntry, ADAttributes.DisplayName);
            user.CommonName = Utility.GetProperty(directoryEntry, ADAttributes.CommonName);
            user.PostalAddress = Utility.GetProperty(directoryEntry, ADAttributes.PostalAddress);
            user.StreetAddress = Utility.GetProperty(directoryEntry, ADAttributes.StreetAddress);
            user.HomePostalAddress = Utility.GetProperty(directoryEntry, ADAttributes.HomePostalAddress);
            user.Title = Utility.GetProperty(directoryEntry, ADAttributes.Title);
            user.HomePhone = Utility.GetProperty(directoryEntry, ADAttributes.HomePhone);
            user.TelephoneNumber = Utility.GetProperty(directoryEntry, ADAttributes.TelephoneNumber);
            user.Mobile = Utility.GetProperty(directoryEntry, ADAttributes.Mobile);
            user.FacsimileTelephoneNumber = Utility.GetProperty(directoryEntry, ADAttributes.FacsimileTelephoneNumber);
            user.Email = Utility.GetProperty(directoryEntry, ADAttributes.Email);
            user.Url = Utility.GetProperty(directoryEntry, ADAttributes.Url);
            user.AccountName = Utility.GetProperty(directoryEntry, ADAttributes.AccountName);
            user.IPPhone = Utility.GetProperty(directoryEntry, ADAttributes.IPPhone);
            user.Pager = Utility.GetProperty(directoryEntry, ADAttributes.Pager);
            user.Department = Utility.GetProperty(directoryEntry, ADAttributes.Department);
            user.Company = Utility.GetProperty(directoryEntry, ADAttributes.Company);
            user.Office = Utility.GetProperty(directoryEntry, ADAttributes.Office);
            user.Info = Utility.GetProperty(directoryEntry, ADAttributes.Info);
            user.PostalCode = Utility.GetProperty(directoryEntry, ADAttributes.PostalCode);
            user.City = Utility.GetProperty(directoryEntry, ADAttributes.City);
            user.Manager = Utility.GetProperty(directoryEntry, ADAttributes.Manager);
            user.Country = Utility.GetProperty(directoryEntry, ADAttributes.Country);
            user.Description = Utility.GetProperty(directoryEntry, ADAttributes.Description);

            user.ExtensionAttribute1 = Utility.GetProperty(directoryEntry, ADAttributes.ExtensionAttribute1);
            user.ExtensionAttribute2 = Utility.GetProperty(directoryEntry, ADAttributes.ExtensionAttribute2);
            user.ExtensionAttribute3 = Utility.GetProperty(directoryEntry, ADAttributes.ExtensionAttribute3);
            //user.ExtensionAttribute4 = Utility.GetProperty(directoryEntry, ADAttributes.ExtensionAttribute4);
            //user.ExtensionAttribute5 = Utility.GetProperty(directoryEntry, ADAttributes.ExtensionAttribute5);
            //user.ExtensionAttribute6 = Utility.GetProperty(directoryEntry, ADAttributes.ExtensionAttribute6);
            //user.ExtensionAttribute7 = Utility.GetProperty(directoryEntry, ADAttributes.ExtensionAttribute7);
            //user.ExtensionAttribute8 = Utility.GetProperty(directoryEntry, ADAttributes.ExtensionAttribute8);
            //user.ExtensionAttribute9 = Utility.GetProperty(directoryEntry, ADAttributes.ExtensionAttribute9);
            //user.ExtensionAttribute10 = Utility.GetProperty(directoryEntry, ADAttributes.ExtensionAttribute10);
            user.DomainReference = String.Format("{0}/{1}", Utility.ADPath, Utility.GetProperty(directoryEntry, ADAttributes.DistinguishedName));
            user.DistinguishedName = Utility.GetProperty(directoryEntry, ADAttributes.DistinguishedName);

            string temp = Utility.GetProperty(directoryEntry, ADAttributes.UserAccountControl);
            user.UserAccountControl = temp.Length == 0 ? 0 : Convert.ToInt32(temp);

            return user;
        }
        public override DirectoryEntry GetDirectoryEntry()
        {
            if (null ==this.DE)
            {
                this.DE = Utility.GetUser(this._accountName);
            }
            return this.DE;
        }
        internal static ADUser Load(string accountName)
        {
            ADUser user = Load(Utility.GetUser(accountName));
            return user;
        }
        

        internal static IList<ADUser> LoadUsersByGroup(string domainReference)
        {
            return GetUsers(domainReference);
        }
        internal static IList<string> LoadUserAccountNamesByGroup(string domainReference)
        {
            return GetUserAccountnames(domainReference);
        }

        private static IList<string> GetUserAccountnames(string domainReference)
        {
            DirectoryEntry de = Utility.GetDirectoryObjectByDomainReference(domainReference);
            IList<string> users = new List<string>();

            DirectoryEntry entry;
            for (int i = 0; i <= de.Properties[ADAttributes.Member].Count - 1; i++)
            {
                string objectPath = string.Format("{0}/{1}", Utility.ADPath, de.Properties[ADAttributes.Member][i]);
                entry = Utility.GetDirectoryObjectByDomainReference(objectPath);
                if (entry.Properties["objectClass"][0]=="user")
                {
                    string accountName = entry.Properties[ADAttributes.AccountName][0].ToString();
                    users.Add(Utility.ADDomainName + "\\" + accountName);                    
                } 
            }
            return users;
        }

        private static IList<ADUser> GetUsers(string domainReference)
        {
            DirectoryEntry de = Utility.GetDirectoryObjectByDomainReference(domainReference);
            IList<ADUser> users = new List<ADUser>();

            DirectoryEntry entry;
            for (int i = 0; i <=de.Properties[ADAttributes.Member].Count-1; i++)
            {
                string objectPath = string.Format("{0}/{1}",Utility.ADPath,de.Properties[ADAttributes.Member][i]);
                entry = Utility.GetDirectoryObjectByDomainReference(objectPath);
                string accountName = entry.Properties[ADAttributes.AccountName][0].ToString();
                if (Utility.GetUser(accountName)!=null)
                {
                    users.Add(Load(entry));
                }                    
            }
            return users;
        }
        //1970-01-01 -->never
        public static void SetAccountExpireDate(string accountName, DateTime ExpiredDate)
        {
            DirectoryEntry user = null;
            try
            {
                user = Utility.GetUser(accountName);
                user.InvokeSet("AccountExpirationDate", new object[] { ExpiredDate });
                user.CommitChanges();
            }
            catch (Exception ee)
            {

            }
            finally
            {
                if (user!=null)
                {
                    user.Close();
                    user.Dispose();
                }
            }
        }
        public DateTime? GetAccountExpiredDate()
        {
            DateTime expiredDate = DateTime.MaxValue;
            DirectoryEntry user = null;
            try
            {
                user = Utility.GetUser(AccountName);
                object accountExpires = user.Properties["accountExpires"][0];
                var asLong = ConvertLargeIntegerToLong(accountExpires);
                if (asLong == long.MaxValue || asLong <= 0 || DateTime.MaxValue.ToFileTime() <= asLong)
                {

                }
                else
                {
                    expiredDate = DateTime.FromFileTime(asLong);
                } 
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (user!=null)
                {
                    user.Close();
                    user.Dispose();
                }
            }
            return expiredDate;
        }
        private static long ConvertLargeIntegerToLong(object largeInterger)
        {
            Type type = largeInterger.GetType();
            int highPart =(int) type.InvokeMember("HighPart", System.Reflection.BindingFlags.GetProperty, null, largeInterger, null);
            int lowPart = (int)type.InvokeMember("LowPart", System.Reflection.BindingFlags.GetProperty, null, largeInterger, null);
            return (long)highPart << 32 | (uint)lowPart;
        }

        public  DateTime? GetAccountExpirationDate()
        {
            DateTime expireDate = DateTime.MaxValue;
            DirectoryEntry user = null;
            try
            {
                user = Utility.GetUser(this.AccountName);
                object accounExpires = user.Properties["accountExpires"][0];
                var aslong = ConvertLargeIntegerToLong(accounExpires);
                if (aslong==long.MaxValue || aslong<=0 ||DateTime.MaxValue.ToFileTime()<=aslong)
                {

                }
                else
                {
                    expireDate = DateTime.FromFileTime(aslong);
                }
            }
            catch (Exception ee)
            {

                throw;
            }
            finally
            {
                if (user!=null)
                {
                    user.Close();
                    user.Dispose();
                }
            }
            return expireDate;
        }
        public static void SetAccountExpirationDate(string accountName, DateTime ExpiredDate)
        {
            DirectoryEntry user = null;
            try
            {
                user = Utility.GetUser(accountName);
                user.InvokeSet("AccountExpirationDate", new object[] { ExpiredDate });
                user.CommitChanges();
            }
            catch (Exception ee)
            {

                throw;
            }
            finally
            {
                if (user!=null)
                {
                    user.Close();
                    user.Dispose();
                }
            }
        }
        public void Unlock()
        {
            try
            {
                DirectoryEntry ent = Utility.GetUser(AccountName);
                ent.Properties["LockOutTime"].Value = 0;
                ent.CommitChanges();
                ent.Close();
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException ee)
            {
                throw new EntryPointNotFoundException("user's account can not be unlock." + ee.Message);
            }
        }
        public void SetPassword(string newPassword)
        {
            try
            {
                DirectoryEntry ent = Utility.GetUser(AccountName);
                Utility.SetUserPassword(ent, newPassword);
                ent.CommitChanges();
                ent.Close();
            }
            catch (Exception ee)
            {
                throw new Exception("user password can not be reseted."+ee.Message);
            }
        }
        public void MoveToOU(string DestOUPath)
        {
            DirectoryEntry user = null;
            try
            {
                user = Utility.GetUser(AccountName);
                user.MoveTo(new DirectoryEntry(DestOUPath));
            }
            catch (Exception ee)
            {
                throw;
            }
            finally
            {
                if (user!=null)
                {
                    user.Close();
                    user.Dispose();
                }
            } 
        }
        public void ChangePassword(string oldePassword, string newPassword)
        {
            try
            {
                DirectoryEntry de = Utility.GetUser(AccountName);
                Utility.ChangeUserPassword(de, oldePassword, newPassword);
                de.CommitChanges();
                de.Close();
            }
            catch (Exception ee)
            { 
                throw;
            }
        }
    }

}