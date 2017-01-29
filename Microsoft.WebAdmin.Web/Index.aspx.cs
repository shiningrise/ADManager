using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;

namespace Microsoft.WebAdmin.Web
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"]!=null && Session["username"].ToString().Length>0)
                {
                    HiddenUserName.Value = Session["username"].ToString();
                }
            }
        }

        [WebMethod]
        public static string GetCnt(string username)
        {
            DataTable dt = WebAdminFun.GetQuestionByUserName(username);
            if (dt.Rows.Count>0)
            {
                if (dt.Rows[0]["question"].ToString().Length==0
                    && dt.Rows[0]["password"].ToString().Length==0)
                {
                    return "0";
                }
                else
                {
                    return "1";
                }
            }
            else
            {
                return "0";
            }

        }
    }
}