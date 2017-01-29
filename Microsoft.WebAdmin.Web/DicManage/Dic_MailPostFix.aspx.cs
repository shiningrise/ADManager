using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WebAdmin.Business;
namespace Microsoft.WebAdmin.Web.DicManage
{
    public partial class Dic_MailPostFix : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGVData();
            }
        }

        private void BindGVData()
        {
            string filter = txtQuery.Text.Trim();
            CacheHelp h = new CacheHelp();
            List<MailPostFixEntity> lst = h.MailPostFixs.Where(company => company.MailName.Contains(filter)).ToList();
            gvDetail.DataSource = lst;
            gvDetail.DataBind();
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            EditDiv.Visible = false;
            BindGVData();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            EditDiv.Visible = true;
            txtNo.Text = "";
            txtMailName.Text = "";
            txtDescription.Text = "";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtNo.Text;
                if (id.Length == 0)
                {
                    //new company
                    MailPostFixEntity ent = new MailPostFixEntity();
                    ent.MailName = txtMailName.Text;
                    ent.Description = txtDescription.Text;


                    DicManager dm = new DicManager();
                    bool f = dm.SaveMailPostFix(ent);
                    if (f)
                    {
                        EditDiv.Visible = false;
                        MessageBox.ShowAndRedirect(Page, this.GetType(), string.Format("{0} 创建成功.", ent.MailName), Page.ResolveUrl("~") + "DicManage/Dic_MailPostFix.aspx");
                    }
                    else
                    {
                        labmsg.Text = "信息创建失败！";
                    }
                }
                else
                {
                    //update company info
                    int iid = 0;
                    if (int.TryParse(id, out iid))
                    {
                        MailPostFixEntity ent = new MailPostFixEntity();
                        ent.ID = iid;
                        ent.MailName = txtMailName.Text;
                        ent.Description = txtDescription.Text;

                        DicManager dm = new DicManager();
                        bool f = dm.UpdateMailPostFix(ent);
                        if (f)
                        {
                            MessageBox.ShowAndRedirect(Page, this.GetType(), string.Format("{0} 更新成功!", ent.MailName), Page.ResolveUrl("~") + "DicManage/Dic_MailPostFix.aspx");
                        }
                        else
                        {
                            labmsg.Text = "信息更新失败!";
                        }
                    }
                }
                CacheHelp ch = new CacheHelp();
                ch.RefreshMailPostFix();
            }
            catch (Exception ee)
            {
                labmsg.Text = ee.Message;
            }
        }

        protected void gvPhaseList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDetail.PageIndex = e.NewPageIndex;
            BindGVData();
        }

        protected void gvApplyRequest_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string companyName = DataBinder.Eval(e.Row.DataItem, "mailName").ToString();
                LinkButton btnDel = e.Row.Cells[4].FindControl("btnDel") as LinkButton;
                btnDel.OnClientClick = string.Format("return confirm('确定删除邮箱 {0} 吗?');", companyName);
            }
        }
        protected void btnGet_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                string id = e.CommandArgument.ToString();
                if (id.Length > 0)
                {
                    if (e.CommandName == "Dels")
                    {
                        //delete company   
                        MailPostFixEntity ent = new MailPostFixEntity();
                        ent.ID = Convert.ToInt16(id);

                        DicManager dm = new DicManager();
                        dm.DeleteMailPostFix(ent);
                    }
                    if (e.CommandName == "Edits")
                    {
                        CacheHelp h = new CacheHelp();
                        List<MailPostFixEntity> lst = h.MailPostFixs.Where(a => a.ID == Convert.ToInt16(id)).ToList();
                        MailPostFixEntity ent = new MailPostFixEntity();
                        if (lst.Count > 0)
                        {
                            ent = lst[0];
                        }

                        EditDiv.Visible = true;
                        txtNo.Text = ent.ID.ToString();
                        txtMailName.Text = ent.MailName;
                        txtDescription.Text = ent.Description;
                    }

                    CacheHelp ch = new CacheHelp();
                    ch.RefreshMailPostFix();
                    BindGVData();
                }
            }
        } 
    }
}