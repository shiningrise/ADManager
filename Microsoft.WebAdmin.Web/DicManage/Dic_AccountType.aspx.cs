using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WebAdmin.Business;

namespace Microsoft.WebAdmin.Web.DicManage
{
    public partial class Dic_AccountType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGVData();
            }
        }
        protected void gvPhaseList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDetail.PageIndex = e.NewPageIndex;
            BindGVData();
        }

        private void BindGVData()
        {
            string query = txtQuery.Text.Trim(); 
            CacheHelp h=new CacheHelp();
            List<AccountEntity> accounts = h.AccountTypes.Where(account => account.AccType.Contains(query)).ToList();
            this.gvDetail.DataSource = accounts;
            this.gvDetail.DataBind();
        }
        protected void gvApplyRequest_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string companyName = DataBinder.Eval(e.Row.DataItem, "acctype").ToString();
                LinkButton btnDel = e.Row.Cells[5].FindControl("btnDel") as LinkButton;
                btnDel.OnClientClick = string.Format("return confirm('确定删除账号类型 {0} 吗?');", companyName);
            }
        }
        protected void btnGet_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                string ID = e.CommandArgument.ToString();
                if (ID.Length > 0)
                {
                    if (e.CommandName == "Dels")
                    {
                        AccountEntity ent = new AccountEntity();
                        ent.ID = Convert.ToInt16(ID);

                        DicManager dm = new DicManager();
                        dm.DeleteAccountType(ent);

                        CacheHelp h = new CacheHelp();
                        h.RefreshAccountType();
                        BindGVData();
                    }
                    if (e.CommandName == "Edits")
                    {
                        CacheHelp h = new CacheHelp();
                        List<AccountEntity> lst =  h.AccountTypes.Where(a => a.ID == Convert.ToInt16(ID)).ToList();
                        AccountEntity ent = new AccountEntity();
                        if (lst.Count > 0)
                        {
                            ent = lst[0];
                        }
                        //modify the company info
                        EditDiv.Visible = true;
                        txtNo.Text = ent.ID.ToString();
                        txtAccType.Text = ent.AccType;
                        txtAccShorten.Text = ent.AccShorten;
                        txtDescription.Text = ent.Description;

                        //refresh the cache
                         
                        h.RefreshAccountType();
                        BindGVData();
                    }
                }
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            EditDiv.Visible = false;
            BindGVData();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtNo.Text;
                //add company
                if (id.Length == 0)
                {
                    AccountEntity entity = new AccountEntity();
                    entity.AccType = txtAccType.Text.Trim();
                    entity.AccShorten = txtAccShorten.Text.Trim();
                    entity.Description = txtDescription.Text.Trim();

                    DicManager dm = new DicManager();
                    bool f = dm.SaveAccountType(entity);


                    if (f)
                    {
                        EditDiv.Visible = false;
                        MessageBox.ShowAndRedirect(Page, this.GetType(), string.Format("账号类型 {0} 创建成功.", entity.AccType), Page.ResolveClientUrl("~") + "DicManage/Dic_AccountType.aspx");
                    }
                    else
                    {
                        labmsg.Text = "信息创建失败.";
                    }
                }
                else
                {
                    int iid = 0;
                    if (int.TryParse(id, out iid))
                    {
                        AccountEntity entity = new AccountEntity();
                        entity.ID = iid;
                        entity.AccType = txtAccType.Text.Trim();
                        entity.AccShorten = txtAccShorten.Text.Trim();
                        entity.Description = txtDescription.Text.Trim();


                        DicManager dm = new DicManager();
                        bool f = dm.UpdateAccountType(entity);
                        if (f)
                        {
                            MessageBox.ShowAndRedirect(Page, this.GetType(), string.Format("账号类型 {0} 更新成功.", entity.AccType), Page.ResolveClientUrl("~") + "DicManage/Dic_AccountType.aspx");
                        }
                        else
                        {
                            labmsg.Text = "信息更新失败.";
                        }
                    }
                }
                CacheHelp h = new CacheHelp();
                h.RefreshAccountType();
            }
            catch (Exception ee)
            {
                labmsg.Text = ee.Message;
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            EditDiv.Visible = true;
            txtNo.Text = "";
            txtAccShorten.Text = "";
            txtAccType.Text = "";
            txtDescription.Text = "";
        } 
    }
}