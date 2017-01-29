using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ActiveDirectory;

namespace Microsoft.WebAdmin.Web
{
    public partial class AccountInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] == null)
                {
                    Response.Redirect("~/Index.aspx");
                }
                else
                {
                    LoadUserInfo(Request.QueryString["ID"]);
                }
            }
        }

        private void LoadUserInfo(string id)
        {
            if (ADManager.IsUserExists(id))
            {
                ADUser user = ADManager.LoadUser(id);
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
            else
            {
                MessageBox.ShowAndRedirect(Page, this.GetType(), string.Format("不存在用户:{0}.", id), Page.ResolveClientUrl("~") + "ViewBondMan.aspx");
            }
        }
    }
}