<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Microsoft.WebAdmin.Web.Login" %>
<%@ Import Namespace="System.Globalization" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>微软目录管理系统</title>
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
	    color: #FFFFFF;
	    font-size: 50px;
    }
    .STYLE2 {font-size: 36px}
        .style2
        {
            width: 33%;
        }
        .style3
        {
            width: 33%;
            height: 50px;
        }
        .style4
        {
            height: 50px;
        }
        .style5
        {
            height: 39px;
            font-weight: bold;
            font-size: large;
            color: #3399FF;
        }
        .style6
        {
            height: 192px;
        }
        .style7
        {
            font-size: small;
        }
        .style8
        {
            font-size: small;
            font-weight: bold;
        }
        .style9
        {
            height: 57px;
        }
        A:link {text-decoration:none; color: #3399FF;}
        A:visited {text-decoration:none; color: #3399FF;}
        A:hover {text-decoration:none; color: #3399FF;}
        A:active {text-decoration:none; color: #3399FF;}
    -->
</style>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#divChinese").click(function () {
                $.cookie("lang", "zh-cn");
                window.location.href = "login.aspx";
            });
            $("#divEnglish").click(function () {
                $.cookie("lang", "en");
                window.location.href = "login.aspx";
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
       <p></p>
        <p>
            &nbsp;</p>
        <table width="800" height="420" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="800" height="77" colspan="3">
                    <span class="STYLE1">
                        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:WAResource,systemName %>"></asp:Literal>

                       
                    </span>
                </td>
            </tr>
            <tr>
                <td align="center" valign="middle">
                    <table width="465" height="305" border="0" cellspacing="0" cellpadding="0" background="Themes/images/Login/login_bg.gif">
                        <tr>
                            <td valign="bottom">
                                <table width="90%" height="109" border="0" align="center" cellpadding="5" cellspacing="5">
                                    <tr>
                                        <td height="5" class="style2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" align="center" class="style2">
                                            <span style="font-size: 16px; font-weight: bolder">
                                                <asp:Literal ID="Literal2" runat="server"  Text="<%$ Resources:WAResource,userName %>"></asp:Literal>
                                            </span>
                                        </td>
                                        <td width="72%" align="left">
                                            &nbsp;
                                            <asp:TextBox ID="txtuserID" Width="200" Font-Size="16px" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="25" align="center" class="style2">
                                            <span style="font-size: 16px; font-weight: bolder">密&nbsp;码</span>
                                        </td>
                                        <td width="72%" align="left">
                                            &nbsp;
                                            <asp:TextBox ID="txtPwd" Font-Size="16px" runat="server" Width="200" TextMode="Password">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3">
                                        </td>
                                        <td align="left" class="style4" valign="middle">
                                            <div style="vertical-align: middle;">
                                                <div style="float: left;">
                                                    <asp:ImageButton ID="ImgLoginBtn" runat="server" ImageUrl="Themes/images/Login/button.gif"
                                                        Width="166" Height="51" OnClick="ImgLoginBtn_Click"
                                                         />
                                                </div>
                                                <div style="float: left;">
                                                    <br />
                                                    &nbsp; <a href="<%= Page.ResolveClientUrl("~")%>LoginQuestion.aspx" style="text-decoration: none;
                                                        height: 51;">忘记密码?</a>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr style="height: 30px;">
                                        <td height="20px" align="center" colspan="2">
                                            <asp:Label ID="labMsg" runat="server" ForeColor="red" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="48">
                </td>
                <td align="center" valign="middle">
                    <table width="270" height="305" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
                        <tr>
                            <td height="20" class="style5">
                               
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" class="style6">
                                <table align="center" cellpadding="5" cellspacing="5" border="0" width="90%">
                                    <tr>
                                        <td width="227" class="style5" align="center">
                                            欢迎您使用微软目录管理系统！
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="style9">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <span class="style8">提醒：</span> <span class="style7">本管理系统建议议采用Internet Explorer 8 (或以上版本)
                                                的浏览器。请开启浏览器的 Cookies 与 JavaScript 功能。</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="style7">
                                            当前版本：V2.0.0
                                        </td>
                                    </tr>
                                    <tr>
                                    <td style="height:20px;"></td>
                                    </tr>
                                    <tr style="text-align:center;color:#3399FF">
                                     <td  style="width: 300px;color:3399FF;font-size:large;color:#3399FF;" >
                    <b>
                    
                    <div id="divChinese"> 中文</div> & <div id="divEnglish">English</div> </b>
                </td> 
                                    </tr>
                                </table>
                                <br />
                                <br />
                                
                                
                                <br />
                                <br />
                                <div style="text-align: right;">
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>