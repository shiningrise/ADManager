using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Microsoft.ActiveDirectory;

namespace Microsoft.WebAdmin.Web
{
    public partial class ReportMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void Page_Init(object sender, EventArgs e)
        {
            if (Session["username"] != null && Session["username"].ToString().Length > 0)
            {
                this.litDate.Text = string.Format("您好:{0}.欢迎您的登陆,今天是{1}", CDisplayName,
                            DateTime.Now.ToString("yyyy-MM-dd"));
                checkUserRole();
            }
            else
            {
                Server.Transfer("login.aspx?r=to");
            }
        }

        public string CDisplayName
        {
            get
            {
                return Session["username"].ToString();
            }
        }
        protected void imgExit_Click(object sender, ImageClickEventArgs e)
        {
            Session["username"] = "";
            Response.Redirect("~/login.aspx");
        }
        public string IsAdmin { get; set; }
        public string IsBondManAdmin { get; set; }
        public string IsHR { get; set; }

        private void checkUserRole()
        {
            string adminRole = ConfigurationManager.AppSettings["adminGroup"];
            string hrRole = ConfigurationManager.AppSettings["hrGroup"];
            string bondManRole = ConfigurationManager.AppSettings["bondmanGroup"];

            if (CDisplayName.Length > 0)
            {
                ADUser u = ADManager.LoadUser(CDisplayName);
                IsAdmin = u.IsInGroup(adminRole) ? "" : "none";
                IsBondManAdmin = u.IsInGroup(bondManRole) ? "" : "none";
                IsHR = u.IsInGroup(hrRole) ? "" : "none";
            }
        }
    }
}