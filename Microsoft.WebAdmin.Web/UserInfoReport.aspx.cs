using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ActiveDirectory;
using System.Configuration;
using org.in2bits.MyXls;
using System.IO;

namespace Microsoft.WebAdmin.Web
{
    public partial class UserInfoReport : System.Web.UI.Page
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
                Form.DefaultButton = btnExport.UniqueID;
            }
        }

        //根据公司名字去查询公司地址
        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCompany.SelectedValue.Length > 0)
            {
                int companyID = Convert.ToInt32(ddlCompany.SelectedValue);
                CacheHelp h = new CacheHelp();
                ddlDeptment.DataSource = from v in h.Deptments
                                         where v.CompanyID == companyID
                                         select new { v.ID, v.DeptName };
                ddlDeptment.DataBind();
                WebAdminFun.BindDDLNotice(ddlDeptment);
            }
            else
            {
            }
        }

        protected void chkBondMan_Click(object sender, ImageClickEventArgs e)
        {
            labmsg.Text = "";
            string bondMan = txtBondsman.Text.Trim();
            if (!ADManager.IsUserExists(bondMan))
            {
                imgTip1.Visible = true;
                imgTip1.ImageUrl = "~/Themes/images/no.jpg";
                labmsg.Text = "汇报对象:" + bondMan + "不存在.";
                return;
            }
            else
            {
                imgTip1.Visible = true;
                imgTip1.ImageUrl = "~/Themes/images/yes.jpg";
            }
        }

        protected void chkReportManager_Click(object sender, ImageClickEventArgs e)
        {
            labmsg.Text = "";
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

        protected void btnExport_Click(object sender, EventArgs e)
        {
            labmsg.Text = "";
            string dept = ddlDeptment.SelectedValue;
            string accountType = ddlAccountType.SelectedValue;
            string reportManager = txtReportManager.Text.Trim();
            string bondMan = txtBondsman.Text.Trim();

            if (reportManager.Length > 0)
            {
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
            if (bondMan.Length > 0)
            {
                if (!ADManager.IsUserExists(bondMan))
                {
                    imgTip1.Visible = true;
                    imgTip1.ImageUrl = "~/Themes/images/no.jpg";
                    labmsg.Text = "汇报对象:" + bondMan + "不存在.";
                    return;
                }
                else
                {
                    imgTip1.Visible = true;
                    imgTip1.ImageUrl = "~/Themes/images/yes.jpg";
                }
            }

            string orgRootPath = ConfigurationSettings.AppSettings["OrgRootPath"];
            if (!orgRootPath.EndsWith("/"))
            {
                orgRootPath += "/";
            }
            string manager = reportManager.Length == 0 ? "" : ADManager.LoadUser(reportManager).UserDePath.Replace(orgRootPath, "");
            string deptf = dept.Length == 0 ? "" : string.Format("(department={0})", ddlDeptment.SelectedItem.Text);
            string accountTypef = accountType.Length == 0 ? "" : string.Format("(ExtensionAttribute1={0})", accountType);
            string reportManagerf = manager.Length == 0 ? "" : string.Format("(manager={0})", manager);
            string bondManf = bondMan.Length == 0 ? "" : string.Format("(ExtensionAttribute2={0})", bondMan);
            string adSearchFilter = string.Format("(&(objectCategory=Person)(objectClass=User)(!(userAccountControl:1.2.840.113556.1.4.803:=2)){0}{1}{2}{3})", deptf, accountTypef, reportManagerf, bondManf);

            IList<ADUser> tempUsers = ADManager.LoadAllUsersByFilter(adSearchFilter);
            var temp = from u in tempUsers
                       where !u.AccountName.StartsWith("$")
                       orderby u.AccountName
                       select new { userid = u.AccountName, firstname = u.FirstName, lastname = u.LastName, displayname = u.DisplayName, job = u.Title, telphoneNumber = u.TelephoneNumber, manager = u.Manager, bondmanuR = u.ExtensionAttribute2, accounTypeR = u.ExtensionAttribute1, companyName = u.Company, deptname = u.Department, email = u.Email };

            XlsDocument xls = new XlsDocument();
            Worksheet sheet = xls.Workbook.Worksheets.Add("ADUsers");
            try
            {
                sheet.Cells.Add(1, 1, "User ID");
                sheet.Cells.Add(1, 2, "姓氏");
                sheet.Cells.Add(1, 3, "名字");
                sheet.Cells.Add(1, 4, "显示名称");
                sheet.Cells.Add(1, 5, "职位");
                sheet.Cells.Add(1, 6, "电话号码");
                sheet.Cells.Add(1, 7, "汇报对象");
                sheet.Cells.Add(1, 8, "担保人");
                sheet.Cells.Add(1, 9, "账号类型");
                sheet.Cells.Add(1, 10, "公司名称");
                sheet.Cells.Add(1, 11, "部门");
                sheet.Cells.Add(1, 12, "邮箱");


                int i = 2; int j = 1;
                foreach (var u in temp)
                {
                    sheet.Cells.Add(i, j, u.userid);
                    sheet.Cells.Add(i, j + 1, u.firstname);
                    sheet.Cells.Add(i, j + 2, u.lastname);
                    sheet.Cells.Add(i, j + 3, u.displayname);
                    sheet.Cells.Add(i, j + 4, u.job);
                    sheet.Cells.Add(i, j + 5, u.telphoneNumber);
                    sheet.Cells.Add(i, j + 6, u.manager);
                    sheet.Cells.Add(i, j + 7, u.bondmanuR);
                    sheet.Cells.Add(i, j + 8, u.accounTypeR);
                    sheet.Cells.Add(i, j + 9, u.companyName);
                    sheet.Cells.Add(i, j + 10, u.deptname);
                    sheet.Cells.Add(i, j + 11, u.email);
                    j = 1;
                    i++;
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    xls.Save(ms);
                    ms.Flush();
                    ms.Position = 0;
                    sheet = null;
                    xls = null;
                    HttpResponse response = System.Web.HttpContext.Current.Response;
                    response.Clear();
                    response.Charset = "UTF-8";
                    response.ContentType = "application/vnd-excel";
                    System.Web.HttpContext.Current.Response.AddHeader("content-Disposition", string.Format("attachment;filename=DomainUsers_" + DateTime.Now.ToString("yyyyMMdd") + ".xls"));
                    byte[] data = ms.ToArray();
                    System.Web.HttpContext.Current.Response.BinaryWrite(data);
                }
            }
            catch (Exception ee)
            {

            }
            finally
            {
                sheet = null;
                xls = null;
            }

        }
    }
}