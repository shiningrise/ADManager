using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ActiveDirectory;

namespace Microsoft.WebAdmin.Web
{
    public partial class ChangeUserInfo : System.Web.UI.Page
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

                Form.DefaultButton = chkUserID.UniqueID;
            }
        }

        protected void chkUserID_Click(object sender, ImageClickEventArgs e)
        {
            labchkUserMsg.Text = "";
            string userID = txtUserID.Text.Trim();
            if (userID.Length > 0)
            {
                ADUser user = ADManager.LoadUser(userID);
                if (user != null)
                { 
                    if (!user.IsAccountActive)
                    {
                        ClearControl();
                        imgTip.Visible = true;
                        imgTip.ImageUrl = "~/Themes/images/no.jpg";

                        labchkUserMsg.Text = "用户已被禁用";
                        return;
                    }

                    txtFirstName.Text = user.FirstName.Length == 0 ? "" : user.FirstName.Substring(0, 1).ToUpper() + user.FirstName.Substring(1).ToLower();
                    txtLastName.Text = user.LastName.Length == 0 ? "" : user.LastName.Substring(0, 1).ToUpper() + user.LastName.Substring(1).ToLower();

                    txtTel.Text = user.TelephoneNumber;
                    labCompanyAddress.Text = user.PostalAddress;
                    labZipCode.Text = user.PostalCode;
                    txtOffice.Text = user.Office;
                    txtCity.Text = user.City;
                    labMail.Text = user.Email; 
                    txtReportManager.Text = user.Manager.ToLower();
                    txtBondsman.Text = user.ExtensionAttribute2.ToLower();
                   
                    CacheHelp h=new CacheHelp();
                    int companyID = h.Companys.Where(a => a.companyName == user.Company).ToList().FirstOrDefault().ID;
                    ddlCompany.SelectedValue = companyID.ToString();
                    
                    ddlCompany_SelectedIndexChanged(sender, e);
                    if (ddlCompany.SelectedValue.Length > 0)
                    {
                        ddlDeptment.SelectedValue = h.Deptments.Where(a => a.DeptName == user.Department).ToList().FirstOrDefault().ID.ToString();
                    }

                    ddlAccountType.SelectedValue = user.ExtensionAttribute1;
                    hidAccountType.Value = user.ExtensionAttribute1;
                    txtDisplayName.Text = user.DisplayName;
                    txtInitals.Text = user.MiddleInitial;
                    txtTitle.Text = user.Title;
                    txtNotes.Text = user.Info;
                    imgTip.Visible = true;
                    imgTip.ImageUrl = "~/Themes/images/yes.jpg";
                }
                else
                {
                    ClearControl();
                    imgTip.Visible = true;
                    imgTip.ImageUrl = "~/Themes/images/no.jpg";
                    labchkUserMsg.Text = "此用户不存在";
                }
            }
        }

        private void ClearControl()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtTel.Text = "";
            labCompanyAddress.Text = "";
            labZipCode.Text = "";
            txtOffice.Text = "";
            txtCity.Text = "";
            labMail.Text = ""; 
            txtReportManager.Text = "";
            txtBondsman.Text = "";
            ddlCompany.SelectedValue = "";
            ddlDeptment.SelectedValue = "";
            ddlAccountType.SelectedValue = "";
            hidAccountType.Value = "";
            txtDisplayName.Text = "";
            txtInitals.Text = "";
            txtTitle.Text = "";
            txtNotes.Text = "";
        } 

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string userID = txtUserID.Text.Trim();
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
                string strAcctype = ddlAccountType.SelectedValue;
                if (strAcctype == "A" || strAcctype == "M" || strAcctype == "S")
                {
                    if (bondMan.Length > 0 && !ADManager.IsUserExists(bondMan))
                    {
                        MessageBox.ShowAndClose(Page, this.GetType(), "担保人:" + bondMan + "不存在.");
                        return;
                    }
                }



                string firstName = txtFirstName.Text.Trim().ToString();
                string lastName = txtLastName.Text.Trim().ToString();
                ADUser user = ADManager.LoadUser(userID);
                user.FirstName = firstName.Length == 0 ? "" : firstName.Substring(0, 1).ToUpper() + firstName.Substring(1).ToLower();
                user.LastName = lastName.Length == 0 ? "" : lastName.Substring(0, 1).ToUpper() + lastName.Substring(1).ToLower();
                user.TelephoneNumber = txtTel.Text.Trim().ToString();
                user.Company = ddlCompany.SelectedItem.Text;
                user.Department = ddlDeptment.SelectedItem.Text;
                user.PostalAddress = labCompanyAddress.Text;
                user.City = txtCity.Text;
                user.PostalCode = labZipCode.Text;
                user.Office = txtOffice.Text;
                string initals = lastName.Length == 0 ? "" : lastName.Substring(0, 1).ToUpper() + ".";
                user.MiddleInitial = initals;
                user.DisplayName = string.Format("{0}, {1} ({2})", firstName.Length == 0 ? "" : firstName.Substring(0, 1).ToUpper() +
                   (firstName.Length == 0 ? "" : firstName.Substring(1).ToLower()),
                   (lastName.Length == 0 ? "" : lastName.Substring(0, 1).ToUpper()) +
                   (lastName.Length == 0 ? "" : lastName.Substring(1).ToLower()), initals);


                user.Manager = txtReportManager.Text;
                user.ExtensionAttribute1 = ddlAccountType.SelectedValue;
                user.ExtensionAttribute2 = txtBondsman.Text;
                user.DisplayName = txtDisplayName.Text;
                user.MiddleInitial = txtInitals.Text;
                user.Title = txtTitle.Text;
                user.Info = txtNotes.Text;
                user.Update();

                MessageBox.ShowAndRedirect(Page, this.GetType(), string.Format("用户{0}信息更新成功.", userID), Page.ResolveClientUrl("~") + "ChangeUserInfo.aspx");
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
                //MessageBox.ShowAndClose(Page, this.GetType(), "担保人:" + bondMan + "不存在.");
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
                //MessageBox.ShowAndClose(Page, this.GetType(), "汇报对象:" + reportManager + "不存在.");
                Image2.Visible = true;
                Image2.ImageUrl = "~/Themes/images/no.jpg";
                labmsg.Text = "汇报对象:" + reportManager + "不存在.";
                return;
            }
            else
            {
                Image2.Visible = true;
                Image2.ImageUrl = "~/Themes/images/yes.jpg";
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


            string accType = ddlAccountType.SelectedValue.ToUpper();
            if (accType == "A" || accType == "M" || accType == "S")
            {
                txtBondsman.Enabled = true;
                txtBondsman.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            }
            else
            {
                txtBondsman.Enabled = false;
                //txtBondsman.Attributes.Add("background-color (css)", "grey");
                txtBondsman.BackColor = System.Drawing.ColorTranslator.FromHtml("#5d6063");
                txtBondsman.Text = "";
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~") + "ChangeUserInfo.aspx");
        }
    }
}