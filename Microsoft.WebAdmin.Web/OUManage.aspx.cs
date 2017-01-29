using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ActiveDirectory;

namespace Microsoft.WebAdmin.Web
{
    public partial class OUManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDDLData();
            }

        }

        private void LoadDDLData()
        {
            ListItem item = new ListItem("Level001", "LDAP://OU=Level001,OU=beifeng,DC=cn,DC=com");
            ListItem item1 = new ListItem("Level002", "LDAP://OU=Level002,OU=beifeng,DC=cn,DC=com");
            ListItem item2 = new ListItem("Level003", "LDAP://OU=Level003,OU=beifeng,DC=cn,DC=com");
            ListItem item3 = new ListItem("Level004", "LDAP://OU=Level004,OU=beifeng,DC=cn,DC=com");

            ddlDestOU.Items.Add(item);
            ddlDestOU.Items.Add(item1);
            ddlDestOU.Items.Add(item2);
            ddlDestOU.Items.Add(item3); 
        }

        protected void chkReportManager_Click(object sender, ImageClickEventArgs e)
        {
            string str = checkUserIsUseful();
            imgTip.Visible = true;
            //all users is exist
            if (str.Length == 0)
            {
                imgTip.ImageUrl = "~/Themes/images/yes.jpg";
                //should change user's OU
                labmsg.Text = "";
            }
            //maybe somebody is not exist
            else
            {
                imgTip.ImageUrl = "~/Themes/images/no.jpg";
                labmsg.Text = string.Format("用户{0}在AD中并不存在,请核对后重新输入.", str);
            } 
        }

        private string checkUserIsUseful()
        {
            bool f = false;
            string[] usersStr = txtQuerySource.Text.Trim().Replace("；", ";").Split(new char[]{';'},StringSplitOptions.RemoveEmptyEntries);
            foreach (string  userID in usersStr)
            {
                f = ADManager.IsUserExists(userID);
                if (!f)
                {
                    return userID;
                }
            }
            return string.Empty; 
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string str = checkUserIsUseful();
            if (str.Length==0)
            {
                try
                {
                    MoveUserOU(txtQuerySource.Text.Trim());
                    MessageBox.ShowAndRedirect(Page, this.GetType(), string.Format("人员移动成功."), Page.ResolveClientUrl("~") + "OUManage.aspx");
                }
                catch (Exception ee)
                {
                    MessageBox.ShowAndClose(Page, this.GetType(), string.Format("人员移动中发生错误,Exception:{0}",ee.Message));
                    throw;
                }
            }
            else
            {
                MessageBox.ShowAndClose(Page, this.GetType(), string.Format("用户{0}在ad中并不存在,请核对后重新输入.", str));
            }
        }

        private void MoveUserOU(string str)
        {
            string[] usersStr = txtQuerySource.Text.Trim().Replace("；", ";").Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string destOUPath = ddlDestOU.SelectedValue;
            foreach (string uStr in usersStr)
            {
                ADUser user = ADManager.LoadUser(uStr);
                user.MoveToOU(destOUPath);
            }
        }
    }
}