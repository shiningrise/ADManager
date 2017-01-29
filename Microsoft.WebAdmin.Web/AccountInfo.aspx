<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AccountInfo.aspx.cs" Inherits="Microsoft.WebAdmin.Web.AccountInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlace" runat="server">
 <br />
    <br />
    <fieldset>
        <legend>被担保人信息</legend>
        <table style="text-align: center; width: 88%;"> 
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
                    职位：
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="labTitle" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: right;">
                    员工编号：
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="labUserID" runat="server" Text=""></asp:Label>
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
             <tr>
                <td style="text-align: right;">
                    办公电话2：
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="txtTel2" runat="server"   ></asp:Label>
                </td>
                <td style="text-align: right;">
                    传真：
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="txtFax" runat="server"   > </asp:Label>
                </td>
            </tr> 
              <tr>
                <td style="text-align: right;">
                    家庭：
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="txtHomeNumber" runat="server"  ></asp:Label>
                </td>
                <td style="text-align: right;">
                    移动电话：
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="txtMobile" runat="server"     > </asp:Label>
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
                <td   style="text-align: left;">
                    <asp:Label ID="labDeptment" runat="server" Text=""></asp:Label>
                </td>
                 <td style="text-align: right;">
                    国家：
                </td>
                <td   style="text-align: left;">
                    <asp:Label ID="labCountry" runat="server" Text=""></asp:Label>
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
                <td   style="text-align: left;">
                    <asp:Label ID="labOffice" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: right;">
                    账户过期日期：
                </td>
                <td   style="text-align: left;">
                    <asp:Label ID="labUserExpiredDate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="text-align: left;">
                <td style="text-align: right;vertical-align:top;">
                    备注：
                </td>
                <td  colspan="3"> 
                    <asp:TextBox ID="txtNotes" TextMode="MultiLine" runat="server" Text="" Width="450px" Height="100px" Enabled="false" ></asp:TextBox>
                </td> 
            </tr>
            
            <tr>
                <td style="height: 40px;">
                </td>
            </tr>
            <tr style="text-align: center;">
                <td colspan="8"  style="font-size:16px;color:Red;">
                    <asp:Label ID="labExpiredMsg" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="text-align: center;">
                <td colspan="8">
                    <a href="javascript:window.opener=null;window.open('','_self');window.close();"  style="color:Blue;background-color:White;">关  闭</a>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
