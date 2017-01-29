using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.ActiveDirectory;

namespace Microsoft.WebAdmin.Web
{
    public partial class LoginQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["s"] != null)
                {
                    string q = Request.QueryString["s"];
                    if (q.ToLower() == "u")
                    {
                        //update the question and answer
                        txtUserName.Text = Session["username"].ToString();
                        txtUserName.Enabled = false;
                        btnGetUserName.Enabled = false;

                        labUserName.Text = "用户名：";
                        labQuestion.Text = "您设置的问题:";
                        labPassword.Text = "请输入您设置的答案:";
                        btnSave.Text = "保  存";
                        DataTable dt = WebAdminFun.GetQuestionByUserName(txtUserName.Text.Trim());
                        if (dt.Rows.Count > 0)
                        {
                            txtQuestion.Text = dt.Rows[0]["question"].ToString().Length == 0 ? "" : "********";
                            txtPassword.Text = dt.Rows[0]["password"].ToString().Length == 0 ? "" : "********";
                        }
                    }
                    if (q.ToLower() == "i")
                    {
                        //update the question and answer
                        txtUserName.Text = Session["username"].ToString();
                        txtUserName.Enabled = false;
                        btnGetUserName.Enabled = false;

                        labUserName.Text = "用户名：";
                        labQuestion.Text = "您设置的问题:";
                        labPassword.Text = "请输入您设置的答案:";
                        btnSave.Text = "保  存";
                        DataTable dt = WebAdminFun.GetQuestionByUserName(txtUserName.Text.Trim());
                        if (dt.Rows.Count > 0)
                        {
                            txtQuestion.Text = dt.Rows[0]["question"].ToString().Length == 0 ? "" : "********";
                            txtPassword.Text = dt.Rows[0]["password"].ToString().Length == 0 ? "" : "********";
                        }
                    }
                }
                else
                {
                    //add the question and answer
                    txtUserName.Text = "";
                    labUserName.Text = "请输入用户名：";
                    txtQuestion.Text = "";
                    labQuestion.Text = "您设置的问题:";
                    txtQuestion.Enabled = false;
                    txtPassword.Text = "";
                    labPassword.Text = "您设置的答案:";
                    btnSave.Text = "重置密码";
                }
            }
        }

        protected void btnGetUserName_Click(object sender, EventArgs e)
        {
            DataTable dt = WebAdminFun.GetQuestionByUserName(txtUserName.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                txtQuestion.Text = dt.Rows[0]["question"].ToString();
                labMsg.Text = "";
            }
            else
            {
                labMsg.Text = string.Format("用户 {0} 暂未设置任何问题.", txtUserName.Text.Trim());
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //update the password infomation
                if (Request.QueryString["s"] != null && (Request.QueryString["s"] == "u" || Request.QueryString["s"] == "i"))
                {

                    if (txtQuestion.Text.Trim().Length == 0 || txtPassword.Text.Trim().Length == 0)
                    {
                        labMsg.Text = "问题和答案都不能为空.";
                        return;
                    }
                    bool b = WebAdminFun.UpdateQuestionByUserName(txtUserName.Text.Trim(), txtQuestion.Text.Trim(), txtPassword.Text.Trim());
                    if (b)
                    { 
                        MessageBox.ShowAndRedirect(Page, this.GetType(), "信息已更新成功.", Page.ResolveClientUrl("~") + "index.aspx");
                    }
                    else
                    {
                        labMsg.Text = "信息更新失败!";
                    }
                }
                else
                {
                    DataTable dt = WebAdminFun.GetQuestionByUserName(txtUserName.Text.Trim());
                    if (dt.Rows.Count > 0)
                    {
                        string password = dt.Rows[0]["password"].ToString();
                        string pass = txtPassword.Text.Trim();
                        if (password == pass)
                        { 
                            string userName = txtUserName.Text.Trim();
                            ADUser user = ADManager.LoadUser(userName);
                            int len = userName.Length;
                            string NewPassword = "Password01!";
                            user.SetPassword(NewPassword); 
                            MessageBox.ShowAndRedirect(Page, this.GetType(), "您的密码已被重置为初始密码,请使用初始密码进行登录.", Page.ResolveClientUrl("~") + "Login.aspx");
                        }
                        else
                        {
                            labMsg.Text = "您的答案不正确,请重新输入.";
                            txtPassword.Text = "";
                        }
                    }
                    else
                    {
                        labMsg.Text = string.Format("用户 {0} 暂未设置任何问题.", txtUserName.Text.Trim());
                    }
                }
            }
            catch (Exception ee)
            {
                labMsg.Text = "用户修改密码报错提示.";
            }
        }
    }
}