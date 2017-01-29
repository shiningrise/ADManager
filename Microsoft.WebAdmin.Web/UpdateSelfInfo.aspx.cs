using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ActiveDirectory;

namespace Microsoft.WebAdmin.Web
{
    public partial class UpdateSelfInfo : System.Web.UI.Page
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
                WebAdminFun.BindDDLNotice(ddlDeptment);
                LoadUserInfo(CDisplayName);

                Form.DefaultButton = BtnSubmit.UniqueID;
            }
        }

        protected void LoadUserInfo(string userID)
        {
            if (userID.Length > 0)
            {
                ADUser user = ADManager.LoadUser(userID);
                if (user != null)
                {
                    CacheHelp ch = new CacheHelp();
                    txtFirstName.Text = user.FirstName.Length == 0 ? "" : user.FirstName.Substring(0, 1).ToUpper() + user.FirstName.Substring(1).ToLower();
                    txtLastName.Text = user.LastName.Length == 0 ? "" : user.LastName.Substring(0, 1).ToUpper() + user.LastName.Substring(1).ToLower();
                    txtTel.Text = user.TelephoneNumber;
                    labCompanyAddress.Text = user.PostalAddress;
                    labZipCode.Text = user.PostalCode;
                    txtOffice.Text = user.Office;
                    labCity.Text = user.City;
                    labMail.Text = user.Email;
                    txtCountry.Text = user.Country;
                    txtDisplayName.Text = user.DisplayName;
                    txtInitals.Text = user.MiddleInitial;
                    txtUserID.Text = user.ExtensionAttribute3;
                    txtTitle.Text = user.Title;
                     
                    txtReportManager.Text = user.Manager.ToLower();
                    txtBondsman.Text = user.ExtensionAttribute2.ToLower();
                    ddlCompany.SelectedValue = ch.Companys.Where(a => a.companyName == user.Company).ToList()[0].ID.ToString();
                    ddlCompany_SelectedIndexChanged(null, null);
                    if (ddlCompany.SelectedValue.Length > 0)
                    {
                        ddlDeptment.SelectedValue = ch.Deptments.Where(a => a.DeptName == user.Department).ToList()[0].ID.ToString();
                    }
                    ddlAccountType.SelectedValue = user.ExtensionAttribute1;
                    hidAccountType.Value = user.ExtensionAttribute1;
                    txtNotes.Text = user.Info.Replace("</", "").Replace(">", "").Replace("<", "").Replace("/>", "");
                    txtHomeNumber.Text = user.HomePhone;
                    txtFax.Text = user.FacsimileTelephoneNumber;
                    txtMobile.Text = user.Mobile;
                    txtTel2.Text = user.IPPhone; 
                }
                else
                {
                    MessageBox.ShowAndClose(Page, this.GetType(), "不存在用户:" + userID);
                }
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string userID = CDisplayName;
                if (userID.Length == 0)
                {
                    MessageBox.ShowAndClose(Page, this.GetType(), "不存在用户:" + userID);
                    return;
                }
                string reportManager = txtReportManager.Text.Trim();
                if (reportManager.Length > 0 && !ADManager.IsUserExists(reportManager))
                {
                    MessageBox.ShowAndClose(Page, this.GetType(), "汇报对象:" + reportManager + "不存在.");
                    return;
                }
                string bondMan = txtBondsman.Text.Trim();
                if (bondMan.Length > 0 && !ADManager.IsUserExists(bondMan))
                {
                    MessageBox.ShowAndClose(Page, this.GetType(), "担保人:" + bondMan + "不存在.");
                    return;
                }
                string firstName = txtFirstName.Text.Trim().ToString();
                string lastName = txtLastName.Text.Trim().ToString();
                ADUser user = ADManager.LoadUser(userID);
                user.TelephoneNumber = txtTel.Text.Trim().ToString();
                user.Office = txtOffice.Text;
                user.Country = txtCountry.Text;
                user.Title = txtTitle.Text;
                user.HomePhone = txtHomeNumber.Text;
                user.FacsimileTelephoneNumber = txtFax.Text;
                user.Mobile = txtMobile.Text;
                user.IPPhone = txtTel2.Text;
                user.ExtensionAttribute3 = txtUserID.Text.Trim().ToString(); 
                user.Update(); 

                MessageBox.ShowAndRedirect(Page, this.GetType(), string.Format("用户{0}信息更新成功.", userID), Page.ResolveClientUrl("~") + "UpdateSelfInfo.aspx");
            }
            catch (Exception ee)
            {
                labmsg.Text = "系统发生异常.Exception:" + ee.Message;
            }
        }
        //根据公司名字去查询公司地址
        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCompany.SelectedValue.Length > 0)
            {
                int companyID = Convert.ToInt32(ddlCompany.SelectedValue);
                CacheHelp h = new CacheHelp();
                var tCompany = from v in h.Companys
                               where v.ID == companyID
                               select new[] { v.address, v.zipCode };
                labCompanyAddress.Text = tCompany.Count() == 0 ? "" : tCompany.ToList()[0][0].ToString();
                labZipCode.Text = tCompany.Count() == 0 ? "" : tCompany.ToList()[0][1].ToString();

                ddlDeptment.DataSource = from v in h.Deptments
                                         where v.CompanyID == companyID
                                         select new { v.ID, v.DeptName };
                ddlDeptment.DataBind();
                WebAdminFun.BindDDLNotice(ddlDeptment);
            }
            else
            {
                labCompanyAddress.Text = "";
            }
        }
     
        protected void chkBondMan_Click(object sender, ImageClickEventArgs e)
        {
            string bondMan = txtBondsman.Text.Trim();
            if (!ADManager.IsUserExists(bondMan))
            { 
                Image1.Visible = true;
                Image1.ImageUrl = "~/Themes/images/no.jpg";
                labmsg.Text = "担保人:" + bondMan + "不存在.";
                return;
            }
            else
            {
                Image1.Visible = true;
                Image1.ImageUrl = "~/Themes/images/yes.jpg";
            }
        }
        protected void chkReportManager_Click(object sender, ImageClickEventArgs e)
        {
            string reportManager = txtReportManager.Text.Trim();
            if (!ADManager.IsUserExists(reportManager))
            {
                imgTip.Visible = true;
                imgTip.ImageUrl = "~/Themes/images/no.jpg";
                labmsg.Text = "汇报对象:" + reportManager + "不存在.";
                return;
            }
            else
            {
                imgTip.Visible = true;
                imgTip.ImageUrl = "~/Themes/images/yes.jpg";
            }
        }
        public string CDisplayName
        {
            get { return Session["username"].ToString(); }
        }
        protected void ddlAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((hidAccountType.Value == "A" || hidAccountType.Value == "M" || hidAccountType.Value == "S") && ddlAccountType.SelectedValue == "F")
            {
                txtBondsman.Text = "";
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~") + "UpdateSelfInfo.aspx");
        }
    }
}