using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.WebAdmin.DataAccess;

namespace Microsoft.WebAdmin.Business
{
    public class DicManager
    {
        public List<CompanyEntity> GetCompanys()
        {
            List<CompanyEntity> lst = new List<CompanyEntity>();
            string sql = "select * from  Dic_Company";
            DataTable dt =DbHelperSQL.GetSingleEntity(sql);
            foreach (DataRow dr in dt.Rows)
	        {
                CompanyEntity ent = new CompanyEntity();
                ent.ID = Convert.ToInt16(dr["id"]);
                ent.companyName = dr["companyName"].ToString();
                ent.address = dr["address"].ToString();
                ent.zipCode = dr["zipcode"].ToString();
                lst.Add(ent);
	        }
            return lst;
        }
        public bool UpdateCompany(CompanyEntity ent)
        {
            string sql = string.Format("update dic_company set companyname=N'{0}' ,address=N'{1}',zipcode='{2}' where id='{3}'",ent.companyName,ent.address,ent.zipCode,ent.ID);
            return DbHelperSQL.ExecuteSql(sql) == 1 ? true : false;
        }
        public bool SaveCompany(CompanyEntity ent)
        {
            string sql = string.Format("insert into dic_company (companyname,address,zipcode) values(N'{0}',N'{1}',N'{2}')",ent.companyName,ent.address,ent.zipCode);
            return DbHelperSQL.ExecuteSql(sql) == 1 ? true : false;
        }
        public bool DeleteCompany(CompanyEntity ent)
        {
            string sql = string.Format("delete from dic_company where id='{0}'",ent.ID);
            return DbHelperSQL.ExecuteSql(sql) == 1 ? true : false;
        }
        public List<AccountEntity> GetAccountTypes()
        {
            List<AccountEntity> lst = new List<AccountEntity>();
            string sql = "select * from  Dic_AccountType";
            DataTable dt = DbHelperSQL.GetSingleEntity(sql);
            foreach (DataRow dr in dt.Rows)
            {
                AccountEntity ent = new AccountEntity();
                ent.ID = Convert.ToInt16(dr["id"]);
                ent.AccType = dr["acctype"].ToString();
                ent.AccShorten = dr["accshorten"].ToString();
                ent.Description = dr["Description"].ToString();
                lst.Add(ent);
            } 
            return lst;
        }
        public bool UpdateAccountType(AccountEntity ent)
        {
            string sql = string.Format("update Dic_AccountType set acctype=N'{0}' ,accshorten=N'{1}',description=N'{2}' where id='{3}'", ent.AccType, ent.AccShorten, ent.Description, ent.ID);
            return DbHelperSQL.ExecuteSql(sql) == 1 ? true : false;
        }
        public bool SaveAccountType(AccountEntity ent)
        {
            string sql = string.Format("insert into Dic_AccountType (acctype,accshorten,description) values(N'{0}',N'{1}',N'{2}')", ent.AccType, ent.AccShorten, ent.Description);
            return DbHelperSQL.ExecuteSql(sql) == 1 ? true : false;
        }
        public bool DeleteAccountType(AccountEntity ent)
        {
            string sql = string.Format("delete from Dic_AccountType where id='{0}'", ent.ID);
            return DbHelperSQL.ExecuteSql(sql) == 1 ? true : false;
        }
        public List<DeptmentEntity> GetDeptments()
        {
            List<DeptmentEntity> lst = new List<DeptmentEntity>();
            string sql = "select a.id,deptname,b.id as companyid,a.description , b.companyName from  Dic_Deptment a left join Dic_company b on a.companyid=b.id";
            DataTable dt = DbHelperSQL.GetSingleEntity(sql);
            foreach (DataRow dr in dt.Rows)
            {
                DeptmentEntity ent = new DeptmentEntity();
                ent.ID = Convert.ToInt16(dr["id"]);
                ent.CompanyID =Convert.ToInt16( dr["companyID"]);
                ent.CompanyName = dr["companyname"].ToString();
                ent.DeptName = dr["deptname"].ToString();
                ent.Description = dr["Description"].ToString();
                lst.Add(ent);
            }
            return lst;
        }
        public bool UpdateDeptment(DeptmentEntity ent)
        {
            string sql = string.Format("update Dic_Deptment set companyid=N'{0}' ,deptname=N'{1}',description=N'{2}' where id='{3}'", ent.CompanyID, ent.DeptName, ent.Description, ent.ID);
            return DbHelperSQL.ExecuteSql(sql) == 1 ? true : false;
        }
        public bool SaveDeptment(DeptmentEntity ent)
        {
            string sql = string.Format("insert into Dic_Deptment (companyID,deptName,description) values(N'{0}',N'{1}',N'{2}')", ent.CompanyID, ent.DeptName, ent.Description);
            return DbHelperSQL.ExecuteSql(sql) == 1 ? true : false;
        }
        public bool DeleteDeptment(DeptmentEntity ent)
        {
            string sql = string.Format("delete from Dic_Deptment where id='{0}'", ent.ID);
            return DbHelperSQL.ExecuteSql(sql) == 1 ? true : false;
        }
        public List<MailPostFixEntity> GetMailPostFix()
        {
            List<MailPostFixEntity> lst = new List<MailPostFixEntity>();
            string sql = "select * from  Dic_MailPostFix";
            DataTable dt = DbHelperSQL.GetSingleEntity(sql);
            foreach (DataRow dr in dt.Rows)
            {
                MailPostFixEntity ent = new MailPostFixEntity();
                ent.ID = Convert.ToInt16(dr["id"]); 
                ent.MailName = dr["mailname"].ToString();
                ent.Description = dr["Description"].ToString();
                lst.Add(ent);
            }
            return lst; 
        }
        public bool UpdateMailPostFix(MailPostFixEntity ent)
        {
            string sql = string.Format("update Dic_MailPostFix set mailname=N'{0}' ,description=N'{1}' where id='{2}'", ent.MailName, ent.Description, ent.ID);
            return DbHelperSQL.ExecuteSql(sql) == 1 ? true : false;
        }
        public bool SaveMailPostFix(MailPostFixEntity ent)
        {
            string sql = string.Format("insert into Dic_MailPostFix (mailname, description) values(N'{0}',N'{1}' )", ent.MailName, ent.Description);
            return DbHelperSQL.ExecuteSql(sql) == 1 ? true : false;
        }
        public bool DeleteMailPostFix(MailPostFixEntity ent)
        {
            string sql = string.Format("delete from Dic_MailPostFix where id='{0}'", ent.ID);
            return DbHelperSQL.ExecuteSql(sql) == 1 ? true : false;
        }
    }
}
