using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Microsoft.WebAdmin.Web
{
    public class MessageBox
    {
        public static void ShowAndRedirect(Control ctrl, Type type, string message, string redirectUrl)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(ctrl, type, Guid.NewGuid().ToString(), string.Format("alert('{0}');window.location.href='{1}';", message,redirectUrl), true);
        }
        public static void ShowAndClose(Control ctrl, Type type, string message)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(ctrl,type,Guid.NewGuid().ToString(),string.Format("alert('{0}')",message),true);
        }
    }
}