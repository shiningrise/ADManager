<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ChangePwd.aspx.cs" Inherits="Microsoft.WebAdmin.Web.ChangePwd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlace" runat="server">
<br />
    <br />
    <fieldset>
        <legend>密码修改</legend>
        <table style="text-align: center;margin-left: auto;margin-right: auto;">
            <tr>
                <td style="text-align: right;">
                </td>
                <td style="text-align: left;">
                </td>
                <td style="text-align: right;">
                    当前用户：
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="labUserName" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: right;">
                </td>
                <td style="text-align: left;">
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                </td>
                <td style="text-align: left;">
                </td>
                <td style="text-align: right;">
                    旧密码：
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td style="text-align: right;">
                </td>
                <td style="text-align: left;">
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                </td>
                <td style="text-align: left;">
                </td>
                <td style="text-align: right;">
                    新密码：
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td style="text-align: right;">
                </td>
                <td style="text-align: left;">
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                </td>
                <td style="text-align: left;">
                </td>
                <td style="text-align: right;">
                    确认新密码：
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtNewPwdConfirm" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td style="text-align: right;">
                </td>
                <td style="text-align: left;">
                </td>
            </tr>
            <tr>
                <td style="height: 40px;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="8" style="text-align: center; color: Red;">
                    <asp:Label ID="labmsg" Text="" runat="server" />
                </td>
            </tr>
            <tr style="text-align: center;">
                <td colspan="8">
                    <asp:Button ID="BtnSubmit" runat="server" Text="保 存" OnClick="BtnSubmit_Click"  />
                </td>
            </tr>
             <tr>
            <td colspan="6" style="height:10px;"></td>
            </tr>
            
        </table>
    </fieldset>
</asp:Content>
