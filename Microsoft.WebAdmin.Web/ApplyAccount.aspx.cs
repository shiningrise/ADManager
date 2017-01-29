using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ActiveDirectory;
using Microsoft.WebAdmin.Business;
using System.Configuration;
namespace Microsoft.WebAdmin.Web
{
    public partial class ApplyAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CacheHelp h = new CacheHelp();
                ddlCompany.DataSource = h.Companys;
                ddlCompany.DataBind();
                WebAdminFun.BindDDLNotice(ddlCompany);

                ddlAccountType.DataSource = h.AccountTypes;
                ddlAccountType.DataBind();
                WebAdminFun.BindDDLNotice(ddlAccountType);

                Form.DefaultButton = btnGetCDSID.UniqueID;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            string userID = txtUserID.Text.Trim();
            try
            {
                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                string accountName = string.Empty;

                string reportManager = txtReportManager.Text.Trim();
                string bondMan = txtBondsman.Text.Trim();
                if (reportManager.Length>0 && !ADManager.IsUserExists(reportManager))
                {
                    MessageBox.ShowAndClose(Page, this.GetType(),  "汇报对象:"+reportManager+" 不存在！");
                    return;
                }
                string strAccType = ddlAccountType.SelectedValue;
                if (strAccType=="A" || strAccType=="M"||strAccType=="S")
                {
                    if (bondMan.Length>0 && !ADManager.IsUserExists(bondMan))
                    {
                        MessageBox.ShowAndClose(Page,this.GetType(),"担保人:"+bondMan+"不存在.");
                        return;
                    }
                }
                if (firstName.Length>0 && lastName.Length>0)
                {
                    string accountType=ddlAccountType.SelectedValue;
                    string s = lastName.Substring(0, 1) + firstName;
                    accountName = ADFun.GetSuitableAccountName(s);

                    string InitPassword = "Password01!";
                    ADUser user = ADManager.CreateUser(ConfigurationManager.AppSettings["ADUserDefaultPath"], accountName, InitPassword);

                    user.ExtensionAttribute3 = txtUserID.Text.Trim();
                    user.FirstName = txtFirstName.Text.Trim();
                    user.LastName = txtLastName.Text.Trim();
                    user.UserPrincipalName = accountName + "@cn.com";
                    user.MiddleInitial = firstName.Substring(0, 1) + "." + lastName.Substring(0, 1);
                    user.TelephoneNumber = txtTel.Text.Trim();
                    user.Company = ddlCompany.SelectedItem.Text;
                    user.Department = ddlDeptment.SelectedItem.Text;
                    user.PostalAddress = labCompanyAddress.Text;
                    user.City = txtCity.Text;
                    user.PostalCode = labZipCode.Text;
                    user.Office = txtOffice.Text;
                    user.ExtensionAttribute1 = accountType;
                    user.ExtensionAttribute2 = txtBondsman.Text.Trim();
                    user.Manager = txtReportManager.Text.Trim();
                    user.Update();



                    DateTime expireDate = DateTime.Now;
                    if (accountType=="A" || accountType=="M"||accountType=="S")
                    {
                        expireDate= expireDate.AddMonths(3);
                    }
                    else
                    {
                        expireDate = new DateTime(1970,1,1);
                    }
                    ADUser.SetAccountExpireDate(accountName, expireDate);

                }
                msg = string.Format("用户{0}创建成功,登陆账号是:{1}",userID,accountName);
                MessageBox.ShowAndRedirect(Page, this.GetType(), msg, Page.ResolveClientUrl("~") + "ApplyAccount.aspx");

            }
            catch (Exception ee)
            {
                msg = string.Format("用户{0}创建失败,Exception:{1}",userID,ee.Message);
                labmsg.Text = msg;
            }

        }

        protected void chkReportManager_Click(object sender, ImageClickEventArgs e)
        {
            labmsg.Text = "";
            string reportManger = txtReportManager.Text.Trim();
            if (!ADManager.IsUserExists(reportManger))
            {
                imgTip.Visible = true;
                imgTip.ImageUrl = "~/themes/images/no.jpg";
                labmsg.Text = string.Format("汇报对象 {0} 不存在!",reportManger);
                return;
            }
            else
            {
                imgTip.Visible = true;
                imgTip.ImageUrl = "~/themes/images/yes.jpg";
            }
        }

        protected void chkBondMan_Click(object sender, ImageClickEventArgs e)
        {
            labmsg.Text = "";
            string bondMan = txtBondsman.Text.Trim();
            if (!ADManager.IsUserExists(bondMan))
            {
                imgTip1.Visible = true;
                imgTip1.ImageUrl = "~/themes/images/no.jpg";
                labmsg.Text = string.Format("担保对象 {0} 不存在!", bondMan);
                return;
            }
            else
            {
                imgTip1.Visible = true;
                imgTip1.ImageUrl = "~/themes/images/yes.jpg";
            }
        }

        protected void btnGetCDSID_Click(object sender, EventArgs e)
        {
            string firstname = txtFirstName.Text.Trim();
            string lastname = txtLastName.Text.Trim();
            if (firstname.Length>0 && lastname.Length>0)
            {
                //bei feng -->fbei fbei0 fbei1
                string s=lastname.Substring(0,1)+firstname;
                txtCDSID.Text = ADFun.GetSuitableAccountName(s);
            }

        }

        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            string compangID = ddlCompany.SelectedValue;
            if (compangID.Length > 0)
            {
                int cID=Convert.ToInt32(compangID);
                CacheHelp h = new CacheHelp();
                var companys = from c in h.Companys
                               where c.ID == cID
                               select new[] { c.address, c.zipCode };
                if (companys.Count()>0)
	            {
                    labCompanyAddress.Text = companys.ToList()[0][0].ToString();
                    labZipCode.Text = companys.ToList()[0][1].ToString();
	            }
                else
                {
                    labCompanyAddress.Text = "";
                    labZipCode.Text = "";
                } 


                List<DeptmentEntity> lst=h.Deptments.Where(a => a.CompanyID == cID).ToList();
                ddlDeptment.DataSource = lst;
                ddlDeptment.DataBind();
                WebAdminFun.BindDDLNotice(ddlDeptment);
            }
        }

        protected void ddlAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string accType = ddlAccountType.SelectedValue.ToUpper();
            if (accType=="A" || accType=="M" ||accType=="S")
            {
                txtBondsman.Enabled = true;
                txtBondsman.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            }
            else
            {
                txtBondsman.Enabled = false;
                txtBondsman.BackColor = System.Drawing.ColorTranslator.FromHtml("#5d6063");
                txtBondsman.Text = "";
            }
        }
    }
}