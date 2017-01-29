using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ActiveDirectory;
using System.Globalization;

namespace Microsoft.WebAdmin.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImgLoginBtn_Click(object sender, ImageClickEventArgs e)
        {
            string userName = txtuserID.Text.Trim();
            string password = txtPwd.Text.Trim();
            if (userName.Length==0 || password.Length==0)
            {
                //labMsg.Text = "用户名或密码不可为空!";
                labMsg.Text = Resources.WAResource.userNameIsEmpty;
            }
            else
            {
                bool f = ADManager.IsUserValid(userName, password);
                if (f)
                {
                    Session["username"] = userName;
                    //Server.Transfer("index.aspx");
                    Response.Redirect("index.aspx");
                }
                else
                {
                    labMsg.Text = "用户名或密码不正确,请重新输入.";
                }
            }
        }
    }
}