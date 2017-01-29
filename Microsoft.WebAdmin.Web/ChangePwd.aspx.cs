using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ActiveDirectory;

namespace Microsoft.WebAdmin.Web
{
    public partial class ChangePwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                labUserName.Text = CDisplayName;
                Page.Form.DefaultButton = BtnSubmit.UniqueID;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = CDisplayName;
                string password = txtOldPassword.Text.Trim();
                if (ADManager.IsUserValid(userName,password))
                {
                    string newpwd = txtNewPwd.Text.Trim();
                    string newpwsCOnfirm = txtNewPwdConfirm.Text.Trim();
                    if (newpwd!=newpwsCOnfirm)
                    {
                        labmsg.Text = "两次输入的密码不相同.";
                        return;
                    }
                    else
                    {
                        ADUser user = ADManager.LoadUser(userName);
                        user.ChangePassword(password, newpwd);
                        labmsg.Text = "密码更新成功.";
                    }
                }
                else
                {
                    labmsg.Text = "输入的旧密码不正确,请重新输入.";
                    return;
                }
            }
            catch (Exception ee)
            {
                labmsg.Text = "密码更新失败.Exception:"+ee.Message;
                throw;
            } 
        }

        public string CDisplayName
        {
            get { return Session["username"].ToString(); }
        }
    }
}