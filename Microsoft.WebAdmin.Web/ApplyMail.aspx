<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ApplyMail.aspx.cs" Inherits="Microsoft.WebAdmin.Web.ApplyMail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlace" runat="server">
 <br />
    <br />
    <fieldset style="width:95%">
        <legend>创建邮箱</legend>
        <table style="text-align: left;margin-left: auto;margin-right: auto;">
            <tr>
                <td style="width:100px;"></td>
                <td style="text-align: right; width: 100px;">
                    请输入User ID：
                </td>
                <td style="text-align: left; width: 200px;">
                    <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
                     <asp:ImageButton ID="chkUserID" runat="server" ImageUrl="~/Themes/images/checknames.png"
                        OnClientClick="return chkUserIDEmpty()" OnClick="chkUserID_Click" />

                    <asp:Image ID="imgTip" runat="server" ImageUrl="" Visible="false"/>
                </td>
                <td style="width:100px;"></td>
            </tr>
            <tr>
                <td style="width:200px;"></td>
                <td style="text-align: right;">
                    请选择邮箱后缀:
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlMailFix" runat="server" Width="100%" DataTextField="MailName"
                        DataValueField="ID">
                        <asp:ListItem Text="microsoft.com" Value="microsoft.com"></asp:ListItem>
                        <asp:ListItem Text="ms.com" Value="ms.com"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width:200px;"></td>
            </tr>
            <tr>
            <td style="height:10px;"></td>
            </tr>
             <tr>
                <td colspan="4" style="text-align:center;color:Red;">
                    <asp:Label  ID="labmsg" Text="" runat="server"/>
                </td>
            </tr>
            <tr style="text-align: right;">
                <td style="width:100px;"></td>
                <td style="text-align: center;" colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" Text="创建邮箱" 
                        onclick="btnSubmit_Click"   OnClientClick="return CheckEmptyValue()"/>
                </td>
                <td style="width:100px;"></td>
            </tr>
        </table>
    </fieldset>
    <script language="javascript" type="text/javascript">
        function CheckEmptyValue() { 
            if (document.getElementById("<%=txtUserID.ClientID %>").value.length == 0) {
                alert("请先输入User ID!");
                return false;
            }
            return true;
        }
    </script>
     <script language="javascript" type="text/javascript">
         function chkUserIDEmpty() {
             if (document.getElementById("<%=txtUserID.ClientID %>").value.length == 0) {
                 alert("请先输入User ID!");
                 return false;
             }
             return true;
         } 
    </script>
</asp:Content>
