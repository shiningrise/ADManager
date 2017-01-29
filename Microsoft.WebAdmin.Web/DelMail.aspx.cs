using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WebAdmin.Exchange;
using Microsoft.ActiveDirectory;

namespace Microsoft.WebAdmin.Web
{
    public partial class DelMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Form.DefaultButton = chkUserID.UniqueID;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string userID = txtUserID.Text.Trim();
                if (userID.Length > 0)
                {
                    if (ADManager.IsUserExists(userID))
                    {
                        ADUser user = ADManager.LoadUser(userID);
                        if (user.Email.Length == 0)
                        {
                            MessageBox.ShowAndClose(Page, this.GetType(), string.Format("输入的用户{0}不存在邮箱!", userID));
                            return;
                        }
                        else
                        {
                            bool f = ExchangeManager.DisableMailBox(user.Email);
                            if (f)
                            { 
                                MessageBox.ShowAndRedirect(Page, this.GetType(), string.Format("邮箱:{0}已删除!", user.Email), Page.ResolveClientUrl("~") + "DelMail.aspx");
                            }
                            else
                            {
                                MessageBox.ShowAndClose(Page, this.GetType(), string.Format("邮箱删除发生错误.!")); 
                                //need log the exception
                            }
                        }
                    }
                    else
                    {
                        MessageBox.ShowAndClose(Page, this.GetType(), string.Format("输入的用户{0}不存在!", userID));
                    }
                }
            }
            catch (Exception ee)
            {
                //MessageBox.ShowAndClose(Page, this.GetType(), string.Format("系统发生异常.Exception:"+ee.Message));
                labmsg.Text = "系统发生错误.Exceptioin:" + ee.Message;
            }
        }

        protected void chkUserID_Click(object sender, ImageClickEventArgs e)
        {
            labchkUserMsg.Text = "";
            string userID = txtUserID.Text.Trim();
            if (userID.Length > 0)
            {
                if (ADManager.IsUserExists(userID))
                {
                    ADUser user = ADManager.LoadUser(userID);
                    if (user.Email.Length == 0)
                    { 
                        imgTip.Visible = true;
                        imgTip.ImageUrl = "~/Themes/images/no.jpg"; 
                        labchkUserMsg.Text = string.Format("输入的用户{0}不存在邮箱!", userID);
                        return;
                    }
                    else
                    {
                        labEmail.Text = user.Email;
                        imgTip.Visible = true;
                        imgTip.ImageUrl = "~/Themes/images/yes.jpg";
                        labchkUserMsg.Text = "";
                    }
                }
                else
                { 
                    imgTip.Visible = true;
                    imgTip.ImageUrl = "~/Themes/images/no.jpg"; 
                    labchkUserMsg.Text = "无此账号";
                    labEmail.Text = "";
                }
            }
        }
    }
}