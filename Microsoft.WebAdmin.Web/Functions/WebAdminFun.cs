using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.WebAdmin.DataAccess;

namespace Microsoft.WebAdmin.Web 
{
    public static class WebAdminFun
    {
        public static void BindDDLNotice(DropDownList dl)
        {
            dl.Items.Insert(0, new ListItem("-----------请选择-------------",""));
        }
        public static void BindDDLNotice0(DropDownList dl)
        {
            dl.Items.Insert(0, new ListItem("-----------请选择-------------", "0"));
        }
        public static DataTable GetQuestionByUserName(string userName)
        {
            return DbHelperSQL.GetSingleEntity(string.Format("select * from dbo.PasswordManage where username=N'{0}'", userName));
        }
        public static bool UpdateQuestionByUserName(string userName, string question, string password)
        {
            string str = string.Format("declare @cnt nvarchar(10)  select @cnt=COUNT(*) from PasswordManage where username=N'{0}'  if(@cnt='1') begin 	update PasswordManage set question=N'{2}',[password]=N'{1}' where userName=N'{0}'  end  else  begin insert into PasswordManage(username, question,[password]) values (N'{0}',N'{2}',N'{1}') end", userName, password, question);
            return DbHelperSQL.ExecuteSql(str) == 1 ? true : false;
        }
        public static string GetUserHaveSetQuestion(string userName)
        {
            return DbHelperSQL.GetSingle(string.Format("select  count(0)  from PasswordManage where username=N'{0}'", userName)).ToString();
        }
    }
}