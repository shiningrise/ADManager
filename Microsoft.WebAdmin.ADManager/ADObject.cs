using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;

namespace Microsoft.ActiveDirectory
{
    [Serializable]
    public abstract class ADObject
    {
        protected string _commonName;
        protected string _distinguishedName;
        protected string _domainReference;
        protected string _description;
        protected string _objectGuid;
        protected string _objectSid;

        DirectoryEntry _de;

        /// <summary>
        /// Object GUID of ADObject.
        /// </summary>
        public string ObjectGUID
        {
            get { return _objectGuid; }
            set { _objectGuid = value; }
        }

        /// <summary>
        /// Object SID of ADObject.
        /// </summary>
        public string ObjectSid
        {
            get { return _objectSid; }
            set { _objectSid = value; }
        }

        /// <summary>
        /// Common name of the active directory object.
        /// </summary>
        public string CommonName
        {
            get { return _commonName; }
            set { _commonName = value; }
        }

  

        /// <summary>
        /// Distinguished name of the active directory object. e.g. CN=Administrator,DC=cn,DC=com.
        /// </summary>
        public string DistinguishedName
        {
            get { return _distinguishedName; }
            set { _distinguishedName = value; }
        }

        /// <summary>
        /// Domain reference of the active directory object. e.g. LDAP://192.168.1.1/CN=Administrator,DC=msft,DC=local.
        /// </summary>
        public string DomainReference
        {
            get { return _domainReference; }
            set { _domainReference = value; }
        }

        /// <summary>
        /// Description of the active directory object.
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public DirectoryEntry DE 
        {
            get { return _de ; }
            set { _de = value; }

        }
     

        /// <summary>
        /// Get the <see cref="System.DirectoryServices.DirectoryEntry"/> object.
        /// </summary>
        /// <returns></returns>
        public abstract DirectoryEntry GetDirectoryEntry();



        
    }
}
