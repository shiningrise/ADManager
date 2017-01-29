using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WebAdmin.Business;

namespace Microsoft.WebAdmin.Web.DicMange
{
    public partial class Dic_Company : System.Web.UI.Page
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
            CacheHelp h=new CacheHelp();
            List<CompanyEntity> lst = h.Companys.Where(company => company.companyName.Contains(filter)).ToList();
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
            txtCompany.Text = "";
            txtAddress.Text = "";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtNo.Text;
                if (id.Length==0)
                {
                    //new company
                    CompanyEntity ent = new CompanyEntity();
                    ent.address = txtAddress.Text;
                    ent.companyName = txtCompany.Text;
                    ent.zipCode = txtZipCode.Text;

                    
                    DicManager dm=new DicManager();
                    bool f= dm.SaveCompany(ent);
                    if (f)
                    {
                        EditDiv.Visible = false; 
                        MessageBox.ShowAndRedirect(Page, this.GetType(), string.Format("{0} 创建成功.",ent.companyName), Page.ResolveUrl("~") + "DicManage/Dic_Company.aspx");
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
                    if (int.TryParse(id,out iid))
                    {
                        CompanyEntity ent = new CompanyEntity();
                        ent.ID = iid;
                        ent.companyName = txtCompany.Text;
                        ent.address = txtAddress.Text;
                        ent.zipCode = txtZipCode.Text;
                        DicManager dm = new DicManager();
                        bool f = dm.UpdateCompany(ent);
                        if (f)
                        {
                            MessageBox.ShowAndRedirect(Page, this.GetType(), string.Format("{0} 更新成功!", ent.companyName), Page.ResolveUrl("~") + "DicManage/Dic_Company.aspx");
                        }
                        else
                        {
                            labmsg.Text = "信息更新失败!";
                        }
                    }
                }
                CacheHelp ch = new CacheHelp();
                ch.RefreshCompany();
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
            if (e.Row.RowType==DataControlRowType.DataRow)
            {
                string companyName = DataBinder.Eval(e.Row.DataItem, "companyname").ToString();
                LinkButton btnDel = e.Row.Cells[4].FindControl("btnDel") as LinkButton;
                btnDel.OnClientClick = string.Format("return confirm('确定删除公司 {0} 吗?');",companyName);
            }
        }
        protected void btnGet_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument!=null)
            {
                string id = e.CommandArgument.ToString();
                if (id.Length>0)
                {
                    if (e.CommandName=="Dels")
                    {
                        //delete company   
                        CompanyEntity ent = new CompanyEntity();
                        ent.ID = Convert.ToInt16(id);

                        DicManager dm = new DicManager();
                        dm.DeleteCompany(ent);
                    }
                    if (e.CommandName=="Edits")
                    {
                        CacheHelp h=new CacheHelp();
                        List<CompanyEntity> lst= h.Companys.Where(a=>a.ID==Convert.ToInt16(id)).ToList();
                        CompanyEntity ent=new CompanyEntity();
                        if (lst.Count>0)
	                    {
                            ent=lst[0];
	                    }

                        EditDiv.Visible = true;
                        txtNo.Text = ent.ID.ToString();
                        txtAddress.Text = ent.address;
                        txtCompany.Text = ent.companyName;
                        txtZipCode.Text = ent.zipCode;
                    }

                    CacheHelp ch = new CacheHelp();
                    ch.RefreshCompany();
                    BindGVData();
                }
            }
        } 
    }
}