using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;

namespace Microsoft.ActiveDirectory
{
 
    [Serializable]
	public class ADGroup : ADObject
	{
		private string _name;
		private string _accountName;
        private string _email;
        private string _notes;
        private GroupScope _groupScope;
        private GroupType _groupType;
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
		private ADUser _managedBy;

		private IList<ADUser> _users;	// the users in the group
        private IList<string> _usersAccountNames;	// the users in the group
		private IList<ADGroup> _groups;	// the sub groups in the group if have.

        public ADGroup()
        {
            _groupScope = GroupScope.ADS_GROUP_TYPE_GLOBAL_GROUP;
            _groupType = GroupType.Security;
            _users = new List<ADUser>();
            _groups = new List<ADGroup>();
        }
		
		#region Properties

		/// <summary>
		/// Name of group.
		/// </summary>
		public string Name
		{
            get { return _name; }
            set { _name = value; }
		}
		
		/// <summary>
		/// Account Name of group.
		/// </summary>
		public string AccountName
		{
            get { return _accountName; }
            set { _accountName = value; }
		}
		
		/// <summary>
		/// Email address.
		/// </summary>
		public string Email
		{
            get { return _email; }
            set { _email = value; }
		}

        /// <summary>
        /// Comment notes.
        /// </summary>
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public GroupScope GroupScope
        {
            get { return _groupScope; }
            set { _groupScope = value; }
        }

        public GroupType GroupType
        {
            get { return _groupType; }
            set { _groupType = value; }
        }

        #region Extension attributes

        public string ExtensionAttribute1
        {
            get { return _extensionAttribute1; }
            set { _extensionAttribute1 = value; }
        }

        public string ExtensionAttribute2
        {
            get { return _extensionAttribute2; }
            set { _extensionAttribute2 = value; }
        }

        public string ExtensionAttribute3
        {
            get { return _extensionAttribute3; }
            set { _extensionAttribute3 = value; }
        }

        public string ExtensionAttribute4
        {
            get { return _extensionAttribute4; }
            set { _extensionAttribute4 = value; }
        }

        public string ExtensionAttribute5
        {
            get { return _extensionAttribute5; }
            set { _extensionAttribute5 = value; }
        }

        public string ExtensionAttribute6
        {
            get { return _extensionAttribute6; }
            set { _extensionAttribute6 = value; }
        }

        public string ExtensionAttribute7
        {
            get { return _extensionAttribute7; }
            set { _extensionAttribute7 = value; }
        }

        public string ExtensionAttribute8
        {
            get { return _extensionAttribute8; }
            set { _extensionAttribute8 = value; }
        }

        public string ExtensionAttribute9
        {
            get { return _extensionAttribute9; }
            set { _extensionAttribute9 = value; }
        }

        public string ExtensionAttribute10
        {
            get { return _extensionAttribute10; }
            set { _extensionAttribute10 = value; }
        }

        #endregion

        /// <summary>
        /// Group's manager.
        /// </summary>
        public ADUser ManagedBy
        {
            get { return _managedBy; }
            set { _managedBy = value; }
        }

		/// <summary>
		/// The users in the group.
		/// </summary>
		public IList<ADUser> Users
		{
            get
            {
                if (_users.Count == 0)
                    _users = ADUser.LoadUsersByGroup(_domainReference);

                return _users;
            }
            set
            {
                _users = value;
            }
		}


        /// <summary>
        /// The users in the group.
        /// </summary>
        public IList<string> UserAccounts
        {
            get
            {
                if (_usersAccountNames.Count == 0)
                    _usersAccountNames = ADUser.LoadUserAccountNamesByGroup(_domainReference);

                return _usersAccountNames;
            }
            set
            {
                _usersAccountNames = value;
            }
        }

		/// <summary>
		/// The sub group members of the group if have.
		/// </summary>
		public IList<ADGroup> Groups
		{
			get
			{
                if (_groups == null)
                    _groups = ADGroup.LoadSubGroups(_domainReference);

                return _groups;
			}
            set
            {
                _groups = value;
            }
		}

		#endregion

		/// <summary>
		/// Judge the user is member of the group or not by specified account.
		/// </summary>
		/// <param name="accountName">the user account name.</param>
		/// <returns>if exists, return true. else return false.</returns>
		public bool HasUser(string accountName)
		{
            for (int i = 0; i < this.Users.Count; i++)
            {
                if (this.Users[i].AccountName.Equals(accountName))
                    return true;
            }

            return false;
		}

        

        /// <summary>
        /// Update the group.
        /// </summary>
        public void Update()
        {
            try
            {
                DirectoryEntry de = GetDirectoryEntry();

                Utility.SetProperty(de, ADAttributes.Email, _email);
                Utility.SetProperty(de, ADAttributes.Info, _notes);
                Utility.SetProperty(de, ADAttributes.Description, _description);
                //Utility.SetProperty(de, ADAttributes.GroupScope, Convert.ToInt32(_groupScope).ToString());
                //Utility.SetProperty(de, ADAttributes.AccountType, Convert.ToInt32(_groupType).ToString());
                Utility.SetProperty(de, ADAttributes.ExtensionAttribute1, _extensionAttribute1);
                Utility.SetProperty(de, ADAttributes.ExtensionAttribute2, _extensionAttribute2);
                Utility.SetProperty(de, ADAttributes.ExtensionAttribute3, _extensionAttribute3);
                Utility.SetProperty(de, ADAttributes.ExtensionAttribute4, _extensionAttribute4);
                Utility.SetProperty(de, ADAttributes.ExtensionAttribute5, _extensionAttribute5);
                Utility.SetProperty(de, ADAttributes.ExtensionAttribute6, _extensionAttribute6);
                Utility.SetProperty(de, ADAttributes.ExtensionAttribute7, _extensionAttribute7);
                Utility.SetProperty(de, ADAttributes.ExtensionAttribute8, _extensionAttribute8);
                Utility.SetProperty(de, ADAttributes.ExtensionAttribute9, _extensionAttribute9);
                Utility.SetProperty(de, ADAttributes.ExtensionAttribute10, _extensionAttribute10);

                if (_managedBy != null)
                    Utility.SetProperty(de, ADAttributes.ManagedBy, _managedBy.DistinguishedName);

                de.CommitChanges();
                de.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Group cannot be updated. " + e.Message);
            }
        }

        /// <summary>
        /// Get the <see cref="System.DirectoryServices.DirectoryEntry"/> object.
        /// </summary>
        /// <returns></returns>
        public override DirectoryEntry GetDirectoryEntry()
        {
            return Utility.GetGroup(this._commonName);
        }

        #region Internal static mothods

        internal static IList<ADGroup> LoadGroupsByUser(string distinguishedName)
		{
			return GetGroups(distinguishedName);
		}

        private static IList<ADGroup> GetGroups(string distinguishedName)
        {
            DirectoryEntry de = Utility.GetDirectoryObjectByDomainReference(distinguishedName);
            IList<ADGroup> groups = new List<ADGroup>();

            DirectoryEntry entry;
            for (int i = 0; i <= de.Properties[ADAttributes.MemberOf].Count - 1; i++)
            {
                if (de.Properties[ADAttributes.MemberOf]!=null)
                {
                    string objectPath = string.Format("{0}/{1}", Utility.ADPath, de.Properties[ADAttributes.MemberOf][i]);
                    entry = Utility.GetDirectoryObjectByDomainReference(objectPath);
                    groups.Add(Load(entry));    
                }
            }
            return groups;
        }

        internal static ADGroup Load(string commonName)
        {
            return Load(Utility.GetGroup(commonName));
        }

        internal static ADGroup LoadByAccount(string groupAccountName)
        {
            return Load(Utility.GetGroupByAccount(groupAccountName));
        }


        internal static ADGroup Load(DirectoryEntry de)
        {
            ADGroup group = new ADGroup();

            group.ObjectGUID        = Utility.GetProperty(de, ADAttributes.ObjectGuid);
            group.ObjectSid         = Utility.GetProperty(de, ADAttributes.ObjectSid);
            group.CommonName        = Utility.GetProperty(de, ADAttributes.CommonName);
            group.Name              = Utility.GetProperty(de, ADAttributes.Name);
            group.AccountName       = Utility.GetProperty(de, ADAttributes.AccountName);
            group.DomainReference   = String.Format("{0}/{1}", Utility.ADPath, Utility.GetProperty(de, ADAttributes.DistinguishedName));
            group.DistinguishedName = Utility.GetProperty(de, ADAttributes.DistinguishedName);
            group.Description       = Utility.GetProperty(de, ADAttributes.Description);
            group.Email             = Utility.GetProperty(de, ADAttributes.Email);
            group.Notes             = Utility.GetProperty(de, ADAttributes.Info);
            group.GroupScope        = (GroupScope)Enum.Parse(typeof(GroupScope), Utility.GetProperty(de, ADAttributes.GroupScope));
            group.GroupType         = (GroupType)Enum.Parse(typeof(GroupType), Utility.GetProperty(de, ADAttributes.AccountType));
            //group.CanonicalName     = Utility.GetProperty(de, ADAttributes.CanonicalName);
            group.ExtensionAttribute1 = Utility.GetProperty(de, ADAttributes.ExtensionAttribute1);
            group.ExtensionAttribute2 = Utility.GetProperty(de, ADAttributes.ExtensionAttribute2);
            group.ExtensionAttribute3 = Utility.GetProperty(de, ADAttributes.ExtensionAttribute3);
            group.ExtensionAttribute4 = Utility.GetProperty(de, ADAttributes.ExtensionAttribute4);
            group.ExtensionAttribute5 = Utility.GetProperty(de, ADAttributes.ExtensionAttribute5);
            group.ExtensionAttribute6 = Utility.GetProperty(de, ADAttributes.ExtensionAttribute6);
            group.ExtensionAttribute7 = Utility.GetProperty(de, ADAttributes.ExtensionAttribute7);
            group.ExtensionAttribute8 = Utility.GetProperty(de, ADAttributes.ExtensionAttribute8);
            group.ExtensionAttribute9 = Utility.GetProperty(de, ADAttributes.ExtensionAttribute9);
            group.ExtensionAttribute10 = Utility.GetProperty(de, ADAttributes.ExtensionAttribute10);

            string managedBy = Utility.GetProperty(de, ADAttributes.ManagedBy);
            if (!String.IsNullOrEmpty(managedBy))
                group.ManagedBy = ADUser.Load(Utility.GetDirectoryObjectByDomainReference(String.Format("{0}/{1}", Utility.ADPath, managedBy)));
            else
                group.ManagedBy = null;

            return group;
        }

		internal static IList<ADGroup> LoadSubGroups(string domainReference)
		{
            DirectoryEntry de = Utility.GetDirectoryObjectByDomainReference(domainReference);
            IList<ADGroup> groups = new List<ADGroup>();

			DirectoryEntry entry;
            string commonName;
			for (int i = 0; i <= de.Properties[ADAttributes.Member].Count - 1; i++)
			{
                string objectPath = String.Format("{0}/{1}", Utility.ADPath, de.Properties[ADAttributes.Member][i]);
				entry = Utility.GetDirectoryObjectByDomainReference(objectPath);
				commonName = entry.Properties[ADAttributes.CommonName][0].ToString();
				
				if (Utility.GetGroup(commonName) != null)
					groups.Add(Load(entry));
			}

            return groups;
        }

        #endregion

        
	}
}
 