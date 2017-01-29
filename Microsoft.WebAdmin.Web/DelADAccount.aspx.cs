using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ActiveDirectory;

namespace Microsoft.WebAdmin.Web
{
    public partial class DelADAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Form.DefaultButton = chkUserID.UniqueID;
            }
        }

        protected void chkUserID_Click(object sender, ImageClickEventArgs e)
        {
            string userID = txtUserID.Text.Trim();
            labchkUserMsg.Text = string.Empty;
            ADUser user = ADManager.LoadUser(userID);
            if (user== null)
            {
                imgTip.Visible = true;
                imgTip.ImageUrl = "~/Themes/images/no.jpg";
                labchkUserMsg.Text = "无此账号.";
                ClearControlValue();
            }
            else
            {
                if (user.IsAccountActive)
                {
                    GetUserInfo(user);
                    imgTip.Visible = true;
                    imgTip.ImageUrl = "~/Themes/images/yes.jpg";
                    labchkUserMsg.Text = "";
                }
                else
                {
                    imgTip.Visible = true;
                    imgTip.ImageUrl = "~/Themes/images/no.jpg";
                    labchkUserMsg.Text = "此账号已被禁用.";
                }
            }

        }

        private void GetUserInfo( ADUser user)
        {
            string userID = user.AccountName;
            labFirstName.Text = user.FirstName.Length == 0 ? "" : user.FirstName.Substring(0, 1).ToUpper() + user.FirstName.Substring(1).ToLower();
            labLastName.Text = user.LastName.Length == 0 ? "" : user.LastName.Substring(0, 1).ToUpper() + user.LastName.Substring(1).ToLower();

            labTel.Text = user.TelephoneNumber;
            labCompany.Text = user.Company;
            labDeptment.Text = user.Department;
            labCompanyAddress.Text = user.PostalAddress;
            labCity.Text = user.City;
            labZipCode.Text = user.PostalCode;
            labOffice.Text = user.Office;
            labNotes.Text = user.Info;
            labMail.Text = user.Email;
            labReportManager.Text = user.Manager.ToLower();
            labBondsman.Text = user.ExtensionAttribute2.ToLower();
            labAccountType.Text = user.ExtensionAttribute1;
            labUserID.Text = user.ExtensionAttribute3;
            labTitle.Text = user.Title; 
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string userID = txtUserID.Text.Trim();
                if (ADManager.IsUserExists(userID))
                {
                    ADManager.SetUserAccountOptions(userID, AccountOptions.ADS_UF_ACCOUNTDISABLE);
                    MessageBox.ShowAndRedirect(Page, this.GetType(), string.Format("用户{0}已被禁用.",userID), Page.ResolveClientUrl("~") + "DelADAccount.aspx");
                }
                else
                {
                    MessageBox.ShowAndClose(Page, this.GetType(),string.Format( "用户{0}不存在.",userID));
                }
            }
            catch (Exception ee)
            {
                throw;
            }
        }
        private void ClearControlValue()
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
            labNotes.Text = "";
            labMail.Text = "";
            labReportManager.Text = "";
            labBondsman.Text = "";
            labAccountType.Text = "";
            labUserID.Text = "";
            labTitle.Text = "";
        }
    }
}