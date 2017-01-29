using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Microsoft.WebAdmin.Business;

namespace Microsoft.WebAdmin.Web
{
    public class CacheHelp
    {
        public List<CompanyEntity> Companys
        {
            get
            {
                if (HttpRuntime.Cache["company"]==null)
                {
                    DicManager dic = new DicManager();
                    HttpRuntime.Cache["company"]= dic.GetCompanys();
                }
                return (List<CompanyEntity>)HttpRuntime.Cache["company"];
            }
        }
        public void RefreshCompany()
        {
            HttpRuntime.Cache.Remove("company");
        }
        public List<AccountEntity> AccountTypes
        {
            get
            {
                if (HttpRuntime.Cache["AccountType"] == null)
                {
                    DicManager dic = new DicManager();
                    HttpRuntime.Cache["AccountType"] = dic.GetAccountTypes();
                }
                return (List<AccountEntity>)HttpRuntime.Cache["AccountType"];
            }
        }
        public void RefreshAccountType()
        {
            HttpRuntime.Cache.Remove("AccountType");
        }
        public List<DeptmentEntity> Deptments
        {
            get
            {
                if (HttpRuntime.Cache["Deptment"] == null)
                {
                    DicManager dic = new DicManager();
                    HttpRuntime.Cache["Deptment"] = dic.GetDeptments();
                }
                return (List<DeptmentEntity>)HttpRuntime.Cache["Deptment"];
            }
        }
        public void RefreshDeptment()
        {
            HttpRuntime.Cache.Remove("Deptment");
        }
        public List<MailPostFixEntity> MailPostFixs
        {
            get
            {
                if (HttpRuntime.Cache["MailPostFix"] == null)
                {
                    DicManager dic = new DicManager();
                    HttpRuntime.Cache["MailPostFix"] = dic.GetMailPostFix();
                }
                return (List<MailPostFixEntity>)HttpRuntime.Cache["MailPostFix"];
            }
        }
        public void RefreshMailPostFix()
        {
            HttpRuntime.Cache.Remove("MailPostFix");
        }

    }
}