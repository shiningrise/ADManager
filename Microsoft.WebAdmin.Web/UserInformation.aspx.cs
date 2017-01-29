using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ActiveDirectory;

namespace Microsoft.WebAdmin.Web
{
    public partial class UserInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Form.DefaultButton = chkUserID.UniqueID;
            }
        }

        protected void chkUserID_Click(object sender, ImageClickEventArgs e)
        {
            string userID = txtUserID.Text.Trim();
            if (ADManager.IsUserExists(userID))
            {
                GetUserInfo();
                imgTip.Visible = true;
                imgTip.ImageUrl = "~/Themes/images/yes.jpg";
                labchkUserMsg.Text = "";
            }
            else
            { 
                imgTip.Visible = true;
                imgTip.ImageUrl = "~/Themes/images/no.jpg"; 
                labchkUserMsg.Text = "无此账号";
                ClearControls();
            }
        }

        private void ClearControls()
        {
            labFirstName.Text = "";
            labLastName.Text = "";
            labTel.Text = "";
            labCompany.Text = "";
            labDeptment.Text = "";
            labCompanyAddress.Text = "";
            labCity.Text = "";
            labZipCode.Text = "";
            labOffice.Text = "";
            labCountry.Text = "";
            labMail.Text = "";
            labDisplayName.Text = "";
            labInitals.Text = "";
            labTitle.Text = "";
            labUserID.Text = "";
            txtHomeNumber.Text = "";
            txtFax.Text = "";
            txtMobile.Text = "";
            txtTel2.Text = "";
            txtNotes.Text = "";
            labUserExpiredDate.Text = ""; 
            labReportManager.Text = "";
            labAccountType.Text = "";
            labBondsman.Text = "";
        }

        private void GetUserInfo()
        {
            string userID = txtUserID.Text.Trim();
            if (userID.Length > 0)
            {
                ADUser user = ADManager.LoadUser(userID);
                if (user != null)
                {

                    labFirstName.Text = user.FirstName.Length == 0 ? "" : user.FirstName.Substring(0, 1).ToUpper() + user.FirstName.Substring(1).ToLower();
                    labLastName.Text = user.LastName.Length == 0 ? "" : user.LastName.Substring(0, 1).ToUpper() + user.LastName.Substring(1).ToLower();


                    labTel.Text = user.TelephoneNumber;
                    labCompany.Text = user.Company;
                    labDeptment.Text = user.Department;
                    labCompanyAddress.Text = user.PostalAddress;
                    labCity.Text = user.City;
                    labZipCode.Text = user.PostalCode;
                    labOffice.Text = user.Office;
                    labCountry.Text = user.Country;
                    labMail.Text = user.Email;

                    labDisplayName.Text = user.DisplayName;
                    labInitals.Text = user.MiddleInitial;
                    labTitle.Text = user.Title;
                    labUserID.Text = user.ExtensionAttribute3;

                    txtHomeNumber.Text = user.HomePhone;
                    txtFax.Text = user.FacsimileTelephoneNumber;
                    txtMobile.Text = user.Mobile;
                    txtTel2.Text = user.IPPhone;

                    txtNotes.Text = user.Info;
                    DateTime? expireDate = user.GetAccountExpirationDate();
                    string strDate = string.Empty;
                    if (expireDate.HasValue)
                    {
                        DateTime temp = Convert.ToDateTime(expireDate);
                        labUserExpiredDate.Text = temp.Year == 9999 ? "" : temp.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        labUserExpiredDate.Text = "";
                    }
                    

                    labReportManager.Text = user.Manager.ToLower();
                    labAccountType.Text = user.ExtensionAttribute1;
                    labBondsman.Text = user.ExtensionAttribute2.ToLower();
                }
            }
        }
    }
}