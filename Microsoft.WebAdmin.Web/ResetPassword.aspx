<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Microsoft.WebAdmin.Web.ResetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlace" runat="server">

  <br />
    <br />
    <fieldset>
        <legend>密码重置</legend>
        <table style="text-align: center; width: 88%;margin-left: auto;margin-right: auto;">
            <tr>

             <td style="text-align: right; width:42%;"  colspan="2">
                   请输入AD账号：
                </td>
                <td style="text-align: left;"  colspan="2">   
                    <asp:TextBox ID="txtUserID" runat="server" Style="width: 128px" AutoCompleteType="Disabled"></asp:TextBox>
                    <asp:ImageButton ID="chkUserID" runat="server" ImageUrl="~/Themes/images/checknames.png"
                        OnClientClick="return chkUserIDEmpty()" OnClick="chkUserID_Click" Height="16px" />
                         <asp:Image ID="imgTip" runat="server" ImageUrl="" Visible="false"/>
                          &nbsp;&nbsp;
                        <asp:Label ID="labchkUserMsg" runat="server" Text=""></asp:Label> 
                </td>
            </tr>
             <tr style="text-align: center;">
                <td style="text-align: right;width:25%;">
                    姓氏：
                </td>
                <td style="text-align: left;width:25%;">
                    <asp:Label ID="labFirstName" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: right;width:25%;">
                    名字：
                </td>
                <td style="text-align: left;width:25%;">
                    <asp:Label ID="labLastName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
             <tr  style="text-align: center;" >
                <td style="text-align: right;">
                    显示名称：
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="labDisplayName" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: right;">
                    缩写：
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="labInitals" runat="server" Text=""></asp:Label>
                </td>
            </tr>
             <tr  style="text-align: center;" >
                <td style="text-align: right;">
                    员工编号：
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="labUserID" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: right;">
                    职位：
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="labTitle" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr  style="text-align: center;" >
                <td style="text-align: right;">
                    账号类型：
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="labAccountType" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: right;">
                    电话号码：
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="labTel" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr  style="text-align: center;">
                <td style="text-align: right;">
                    汇报对象：
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="labReportManager" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: right;">
                    担保人：
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="labBondsman" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr  style="text-align: center;">
                <td style="text-align: right;">
                    公司名称：
                </td>
                <td colspan="3" style="text-align: left;" >
                    <asp:Label ID="labCompany" runat="server" Text="" Width="100%"></asp:Label>
                </td>
            </tr>
            <tr  style="text-align: center;">
                <td style="text-align: right;">
                    公司地址：
                </td>
                <td colspan="3" style="text-align: left;">
                    <asp:Label ID="labCompanyAddress" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr  style="text-align: center;" >
                <td style="text-align: right;">
                    部门：
                </td>
                <td colspan="3" style="text-align: left;">
                    <asp:Label ID="labDeptment" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr  style="text-align: center;" >
                <td style="text-align: right;">
                    城市：
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="labCity" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: right;">
                    邮编：
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="labZipCode" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr   style="text-align: center;">
                <td style="text-align: right;">
                    邮箱：
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="labMail" runat="server" Text=""></asp:Label>
                </td>
                
            </tr>
            <tr   style="text-align: center;">
                <td style="text-align: right;">
                    办公地点：
                </td>
                <td colspan="3" style="text-align: left;">
                    <asp:Label ID="labOffice" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align:center;color:Red;">
                    <asp:Label  ID="labmsg" Text="" runat="server"/>
                </td>
            </tr>
            <tr>
                <td style="height: 40px;">
                </td>
            </tr>
            <tr style="text-align: center;">
                <td colspan="8"  style="font-size:16px;color:Red;">
                    密码将被重置为初始密码
                </td>
            </tr>
            <tr style="text-align: center;">
                <td colspan="8">
                    <asp:Button ID="BtnSubmit" runat="server" Text="密码重置" OnClick="BtnSubmit_Click" OnClientClick="return chkUserIDEmpty()" />
                </td>
            </tr>
            <tr>
            <td colspan="4" style="height:10px;"></td>
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
