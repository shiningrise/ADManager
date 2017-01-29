using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ActiveDirectory;

namespace Microsoft.WebAdmin.Web
{
    public partial class ResetPassword : System.Web.UI.Page
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
                GetUserInfo(userID);
                imgTip.Visible = true;
                imgTip.ImageUrl = "~/Themes/images/yes.jpg";
                labchkUserMsg.Text = "";
            }
            else
            {
                //MessageBox.ShowAndClose(Page, this.GetType(), string.Format("用户{0}不存在!", userID));
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
            labMail.Text = "";
            labDisplayName.Text = "";
            labInitals.Text = "";
            labUserID.Text = "";
            labTitle.Text = ""; 
            labReportManager.Text = "";
            labAccountType.Text = "";
            labBondsman.Text = "";
        }
        

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string userID = txtUserID.Text.Trim();
            try
            {               
                if (ADManager.IsUserExists(userID))
                {
                    GetUserInfo(userID);
                    ADUser user = ADManager.LoadUser(userID);
                    user.SetPassword("Password01!");
                    MessageBox.ShowAndRedirect(Page, this.GetType(), string.Format("用户{0}的密码已重置.",userID), Page.ResolveClientUrl("~") + "ResetPassword.aspx");
                }
            }
            catch (Exception ee)
            {
                MessageBox.ShowAndClose(Page, this.GetType(),string.Format("用户{0}不存在.",userID));
            }
        }
        private void GetUserInfo(string userID)
        {
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
                    labMail.Text = user.Email;

                    labDisplayName.Text = user.DisplayName;
                    labInitals.Text = user.MiddleInitial;
                    labUserID.Text = user.ExtensionAttribute3;
                    labTitle.Text = user.Title;

                    
                    labReportManager.Text = user.Manager.ToLower();
                    labAccountType.Text = user.ExtensionAttribute1;
                    labBondsman.Text = user.ExtensionAttribute2.ToLower();
                }
            }
        }
        public string CDisplayName
        {
            get { return Session["username"].ToString(); }
        }
    }
}