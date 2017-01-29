<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DelMail.aspx.cs" Inherits="Microsoft.WebAdmin.Web.DelMail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlace" runat="server">
 <br />
    <br />
    <fieldset>
        <legend>删除邮箱</legend>
        <table style="text-align: center;width:100%;margin-left: auto;margin-right: auto;">
           <tr style="text-align:center;"> 
                <td style="text-align: right; width:42%;">
                   请输入AD账号：
                </td>
                <td style="text-align: left;">  
                    <asp:TextBox ID="txtUserID" runat="server" style="width: 128px"></asp:TextBox>
                     <asp:ImageButton ID="chkUserID" runat="server"  
                        ImageUrl="~/Themes/images/checknames.png"  
                        OnClientClick="return chkUserIDEmpty()" onclick="chkUserID_Click"/>
                        <asp:Image ID="imgTip" runat="server" ImageUrl="" Visible="false"/>
                          &nbsp;&nbsp;
                        <asp:Label ID="labchkUserMsg" runat="server" Text="" ></asp:Label>  
                </td>
            </tr> 

            <tr style="text-align:center;"> 
                <td style="text-align: right; width:42%;">
                    邮箱：
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="labEmail" runat="server" Text=""></asp:Label>
                </td> 
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;color:Red;">
                    <asp:Label  ID="labmsg" Text="" runat="server"/>
                </td>
            </tr>
            <tr>
                <td style="height: 40px;" colspan="2" >
                </td>
            </tr>
            <tr style="text-align: center;">
                <td  colspan="2">
                    <asp:Button ID="BtnSubmit" runat="server" Text="删 除" OnClick="BtnSubmit_Click" OnClientClick="return chkUserIDEmpty()" />
                </td>
            </tr>
        </table>
    </fieldset>
     <script language="javascript" type="text/javascript">
         function chkUserIDEmpty() {
             if (document.getElementById("<%=txtUserID.ClientID %>").value.length == 0) {
                 alert("请先输入AD账号!");
                 return false;
             }
             return true;
         } 
    </script>
</asp:Content>
