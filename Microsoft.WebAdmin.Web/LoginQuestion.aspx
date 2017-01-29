<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginQuestion.aspx.cs" Inherits="Microsoft.WebAdmin.Web.LoginQuestion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>WebAdmin管理系统</title>
    <style type="text/css">
    <!--
    body,td,th {
	    font-family: 新宋体;
	    font-size: 14px;
	    color: #666666;
    }
    body {
	    background-image: url(Themes/images/Login/bg.gif);
	    background-repeat: repeat-x;
	    margin-left: 0px;
	    margin-top: 0px;
	    margin-right: 0px;
	    margin-bottom: 0px;
    }
    .STYLE1 {
	    color: #184f88;
	    font-size: 25px;
    }
    .STYLE2 {font-size: 36px}
        -->
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <table width="80%" style="height: 220px;" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr >
        <td style="height:200px;"  colspan="3"></td>
        </tr>
            <tr>
                <td width="80%" colspan="3" style="height:100px;"   >
                    <span class="STYLE1">忘记密码?回答问题重置密码:</span>
                </td>
            </tr>
            <tr style="text-align:center;">
                <td align="center" valign="middle">
                </td>
                <td>
                    <table>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="labUserName" runat="server" Text="请输入登录用户名:"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                                <asp:Button ID="btnGetUserName" runat="server" Text="查  询" OnClientClick="return checkUserNameEmpty();"
                                    OnClick="btnGetUserName_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="labQuestion" runat="server" Text="您上次设置的问题是:"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtQuestion" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="labPassword" runat="server" Text="请输入相关的密码:"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center;">
                                <asp:Label ID="labMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;" colspan="2">
                                <asp:Button ID="btnSave" runat="server" Text="保  存" onclick="btnSave_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <a href="<%= Page.ResolveClientUrl("~")%>Index.aspx">返回首页</a>
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="center" valign="middle">
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">
        function checkUserNameEmpty() {
            if (document.getElementById("<%=txtUserName.ClientID %>").value.length == 0) {
                alert("请先输入登录用户名!");
                return false;
            }
            return true;
        }
    </script>
    </form>
</body>
</html>
