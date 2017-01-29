using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;

namespace Microsoft.ActiveDirectory
{
    [Serializable]
    public class ADOrganizationalUnit:ADObject
    { 
        private string _name;
        private string _street;
        private string _city;
        private string _province;
        private string _postalCode;
        private string _country;
        private string _fax;
        private string _telephoneNumber;
        private string _extensionName;

        private ADUser _managedBy;

        #region Properties

        /// <summary>
        /// Name of OU.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// OU's manager.
        /// </summary>
        public ADUser ManagedBy
        {
            get { return _managedBy; }
            set { _managedBy = value; }
        }

        /// <summary>
        /// Street address of OU.
        /// </summary>
        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }

        /// <summary>
        /// City of OU.
        /// </summary>
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        /// <summary>
        /// State/Province of OU.
        /// </summary>
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }

        /// <summary>
        /// Postal code of OU.
        /// </summary>
        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }

        /// <summary>
        /// County/Region of OU
        /// </summary>
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        /// <summary>
        /// Fax of OU.
        /// </summary>
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }

        /// <summary>
        /// Telephone number of OU.
        /// </summary>
        public string TelephoneNumber
        {
            get { return _telephoneNumber; }
            set { _telephoneNumber = value; }
        }

        /// <summary>
        /// Extesion name of OU.
        /// </summary>
        public string ExtensionName
        {
            get { return _extensionName; }
            set { _extensionName = value; }
        }

        #endregion

        /// <summary>
        /// Update the organizationalUnit.
        /// </summary>
        public void Update()
        {
            try
            {
                DirectoryEntry de = Utility.GetOrganizationalUnit(_name);

                Utility.SetProperty(de, ADAttributes.Description, _description);
                Utility.SetProperty(de, ADAttributes.Street, _street);
                Utility.SetProperty(de, ADAttributes.City, _city);
                Utility.SetProperty(de, ADAttributes.StateProvince, _province);
                Utility.SetProperty(de, ADAttributes.PostalCode, _postalCode);
                Utility.SetProperty(de, ADAttributes.Country, _country);
                Utility.SetProperty(de, ADAttributes.FacsimileTelephoneNumber, _fax);
                Utility.SetProperty(de, ADAttributes.TelephoneNumber, _telephoneNumber);
                Utility.SetProperty(de, ADAttributes.ExtensionName, _extensionName);

                if (_managedBy != null)
                    //Utility.SetProperty(de, ADAttributes.ManagedBy, _managedBy.DistinguishedName);

                de.CommitChanges();
            }
            catch (Exception e)
            {
                throw new Exception("OU cannot be updated. " + e.Message);
            }
        }

        /// <summary>
        /// Get the <see cref="System.DirectoryServices.DirectoryEntry"/> object.
        /// </summary>
        /// <returns></returns>
        public override DirectoryEntry GetDirectoryEntry()
        {
            return Utility.GetOrganizationalUnit(this._name);
        }

        #region Internal methods

        internal static ADOrganizationalUnit Load(string ouName)
        {
            return Load(Utility.GetOrganizationalUnit(ouName));
        }

        internal static ADOrganizationalUnit Load(DirectoryEntry de)
        {
            ADOrganizationalUnit ou = new ADOrganizationalUnit();

            ou.ObjectGUID = Utility.GetProperty(de, ADAttributes.ObjectGuid);
            ou.ObjectSid = Utility.GetProperty(de, ADAttributes.ObjectSid);
            ou.Name = Utility.GetProperty(de, ADAttributes.Name);
            ou.DistinguishedName = Utility.GetProperty(de, ADAttributes.DistinguishedName);
            ou.DomainReference = String.Format("{0}/{1}", Utility.ADPath, Utility.GetProperty(de, ADAttributes.DistinguishedName));
            ou.Description = Utility.GetProperty(de, ADAttributes.Description);
            ou.Street = Utility.GetProperty(de, ADAttributes.Street);
            ou.City = Utility.GetProperty(de, ADAttributes.City);
            ou.Province = Utility.GetProperty(de, ADAttributes.StateProvince);
            ou.PostalCode = Utility.GetProperty(de, ADAttributes.PostalCode);
            ou.Country = Utility.GetProperty(de, ADAttributes.Country);
            ou.Fax = Utility.GetProperty(de, ADAttributes.FacsimileTelephoneNumber);
            ou.TelephoneNumber = Utility.GetProperty(de, ADAttributes.TelephoneNumber);
            ou.ExtensionName = Utility.GetProperty(de, ADAttributes.ExtensionName);
            //ou.CanonicalName        = Utility.GetProperty(de, ADAttributes.CanonicalName);

            string managedBy = Utility.GetProperty(de, ADAttributes.ManagedBy);
            if (!String.IsNullOrEmpty(managedBy))
            {
                //ou.ManagedBy = ADUser.Load(Utility.GetDirectoryObjectByDomainReference(String.Format("{0}/{1}", Utility.ADPath, managedBy)));
            }
            else
            {
                ou.ManagedBy = null;
            }

            return ou;
        }

        #endregion
    }
}