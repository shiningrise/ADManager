using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ActiveDirectory;
using Microsoft.WebAdmin.Exchange;

namespace Microsoft.WebAdmin.Web
{
    public partial class ApplyMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                Form.DefaultButton = chkUserID.UniqueID;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string userID = txtUserID.Text.Trim();
                bool f = ADManager.IsUserExists(userID);
                if (f)
                {
                    string mailStr = userID + "@" + ddlMailFix.SelectedItem.Text;
                    //check the mail box is available
                    if (ExchangeManager.MailExist(userID))
                    {
                        MessageBox.ShowAndClose(Page, this.GetType(), string.Format("邮箱:{0}已被使用,请核对后重新输入.", mailStr));
                        return;
                    } 

                    //create user's mailbox in exchange
                    string mailAddress = ExchangeManager.EnableMailBox(userID); 
                    MessageBox.ShowAndRedirect(Page, this.GetType(), string.Format("用户{0}的邮箱已创建:{1}.", userID, mailAddress), Page.ResolveClientUrl("~") + "ApplyMail.aspx");
                }
                else
                {
                    MessageBox.ShowAndClose(Page, this.GetType(), "输入的User ID用户不存在!"); 
                }
            }
            catch (Exception ee)
            {
                labmsg.Text = string.Format("系统发生错误.Exception:{0}", ee.Message);
            }
        }

        protected void chkUserID_Click(object sender, ImageClickEventArgs e)
        {
            string userID = txtUserID.Text.Trim();
            if (ADManager.IsUserExists(userID))
            { 
                labmsg.Text = "";
                imgTip.Visible = true;
                imgTip.ImageUrl = "~/Themes/images/yes.jpg";
            }
            else
            { 
                imgTip.Visible = true;
                imgTip.ImageUrl = "~/Themes/images/no.jpg";
                labmsg.Text = "无此账号";
            }
        }
    }
}