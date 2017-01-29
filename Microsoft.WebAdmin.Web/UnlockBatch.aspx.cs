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
    public partial class UnlockBatch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                labmsg.Text = "";
                BindGVData();
            }
            catch (Exception ee)
            {
                labmsg.Text = string.Format("系统发生错误.Exception:{0}",ee.Message);
            }
        }
        protected void gvPhaseList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDetail.PageIndex = e.NewPageIndex;
            BindGVData();
        }
        private void BindGVData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("accountID");
            dt.Columns.Add("DisplayName");
            dt.Columns.Add("tel");
            dt.Columns.Add("department");
            string userID = txtCDSID.Text.Trim();
            string userFilter = userID.Length == 0 ? "" : string.Format("(name=*{0}*)",userID);
            IList<ADUser> lockedUsers = ADManager.GetLockedUsers(userFilter);
            foreach (ADUser  u in lockedUsers)
            {
                DataRow dr = dt.NewRow();
                dr["accountID"] = u.AccountName;
                dr["displayName"] = u.DisplayName;
                dr["tel"] = u.TelephoneNumber;
                dr["department"] = u.Department;
                dt.Rows.Add(dr);
            }
            gvDetail.DataSource = dt;
            gvDetail.DataBind();
        }


        protected void gvApplyRequest_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType==DataControlRowType.DataRow)
            {
                string accountID = DataBinder.Eval(e.Row.DataItem, "accountID").ToString();

                HyperLink lablink = e.Row.Cells[0].FindControl("lnkLogon") as HyperLink;
                lablink.Text = accountID;
                lablink.NavigateUrl = string.Format("AccountInfo.aspx?id={0}", accountID);
                lablink.Target = "_blank";

                LinkButton btn = e.Row.Cells[4].FindControl("btnDelay") as LinkButton;
                btn.OnClientClick = string.Format("return confirm('确定解锁用户 {0} 吗?')",accountID);
            }
        }
        protected void btnGet_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument!=null)
            {
                string userID = e.CommandArgument.ToString();
                if (userID.Length>0)
                {
                    if (e.CommandName == "unlock")
                    {
                        Response.Redirect(string.Format("~/AccountUnlock.aspx?name={0}",userID));
                    }
                }
            }
        }
    }
}