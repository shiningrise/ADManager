using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WebAdmin.Business;

namespace Microsoft.WebAdmin.Web.DicManage
{
    public partial class Dic_Deptment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGVData();
                CacheHelp h = new CacheHelp();
                ddlCompany.DataSource = h.Companys;
                ddlCompany.DataBind();
                WebAdminFun.BindDDLNotice0(ddlCompany);
            }
        }

        private void BindGVData()
        {
            string filter = txtQuery.Text.Trim();
            CacheHelp h = new CacheHelp();
            List<DeptmentEntity> lst = h.Deptments.Where(company => company.DeptName.Contains(filter)).ToList();
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
            txtDeptName.Text = "";
            txtDescription.Text = "";
            ddlCompany.SelectedValue = "0";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtNo.Text;
                if (id.Length == 0)
                {
                    //new company
                    DeptmentEntity ent = new DeptmentEntity();
                    ent.DeptName = txtDeptName.Text;
                    ent.CompanyID =Convert.ToInt16( ddlCompany.SelectedValue);
                    ent.Description = txtDescription.Text;
                  

                    DicManager dm = new DicManager();
                    bool f = dm.SaveDeptment(ent);
                    if (f)
                    {
                        EditDiv.Visible = false;
                        MessageBox.ShowAndRedirect(Page, this.GetType(), string.Format("{0} 创建成功.", ent.DeptName), Page.ResolveUrl("~") + "DicManage/Dic_Deptment.aspx");
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
                        DeptmentEntity ent = new DeptmentEntity();
                        ent.ID = iid;
                        ent.DeptName = txtDeptName.Text;
                        ent.CompanyID = Convert.ToInt16(ddlCompany.SelectedValue);
                        ent.Description = txtDescription.Text;

                        DicManager dm = new DicManager();
                        bool f = dm.UpdateDeptment(ent);
                        if (f)
                        {
                            MessageBox.ShowAndRedirect(Page, this.GetType(), string.Format("{0} 更新成功!", ent.DeptName), Page.ResolveUrl("~") + "DicManage/Dic_Deptment.aspx");
                        }
                        else
                        {
                            labmsg.Text = "信息更新失败!";
                        }
                    }
                }
                CacheHelp ch = new CacheHelp();
                ch.RefreshDeptment();
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
                string companyName = DataBinder.Eval(e.Row.DataItem, "deptname").ToString();
                LinkButton btnDel = e.Row.Cells[4].FindControl("btnDel") as LinkButton;
                btnDel.OnClientClick = string.Format("return confirm('确定删除部门 {0} 吗?');", companyName);
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
                        DeptmentEntity ent = new DeptmentEntity();
                        ent.ID = Convert.ToInt16(id);

                        DicManager dm = new DicManager();
                        dm.DeleteDeptment(ent);
                    }
                    if (e.CommandName == "Edits")
                    {
                        CacheHelp h = new CacheHelp();
                        List<DeptmentEntity> lst = h.Deptments.Where(a => a.ID == Convert.ToInt16(id)).ToList();
                        DeptmentEntity ent = new DeptmentEntity();
                        if (lst.Count > 0)
                        {
                            ent = lst[0];
                        }

                        EditDiv.Visible = true;
                        txtNo.Text = ent.ID.ToString();
                        ddlCompany.SelectedValue = ent.CompanyID.ToString();
                        txtDeptName.Text = ent.DeptName;
                        txtDescription.Text = ent.Description;
                    }

                    CacheHelp ch = new CacheHelp();
                    ch.RefreshDeptment();
                    BindGVData();
                }
            }
        } 
    }
}