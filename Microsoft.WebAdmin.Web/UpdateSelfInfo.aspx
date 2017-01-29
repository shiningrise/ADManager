<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UpdateSelfInfo.aspx.cs" Inherits="Microsoft.WebAdmin.Web.UpdateSelfInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlace" runat="server">

 <br />
    <br />
    <fieldset>
        <legend>变更用户信息</legend>
        <table style="text-align: center;margin-left: auto;margin-right: auto;">
            <tr>
                <td style="text-align: right;">
                    姓氏：
                </td>
                <td style="text-align: left;background:#98bcb2;">
                    <asp:TextBox ID="txtFirstName" runat="server" onpaste="return false;" onkeyup="chkEN(this,event)" Enabled="false"></asp:TextBox>
                </td>
                <td style="text-align: right;">
                    名字：
                </td>
                <td style="text-align: left;background:#98bcb2;">
                    <asp:TextBox ID="txtLastName" runat="server" onpaste="return false;" onkeyup="chkEN(this,event)"  Enabled="false"> </asp:TextBox>
                </td>
            </tr>
             <tr>
                <td style="text-align: right;">
                    显示名称：
                </td>
                <td style="text-align: left;background:#98bcb2;">
                    <asp:TextBox ID="txtDisplayName" runat="server"  Enabled="false"></asp:TextBox>
                </td>
                <td style="text-align: right;">
                    缩写：
                </td>
                <td style="text-align: left;background:#98bcb2;">
                    <asp:TextBox ID="txtInitals" runat="server"    Enabled="false"> </asp:TextBox>
                </td>
            </tr>
             <tr>
                 <td style="text-align: right;">
                    城市：
                </td>
                <td style="background:#98bcb2;">
                    <asp:Label ID="labCity" runat="server" Text=""   Enabled="false"></asp:Label>
                </td>
                 <td style="text-align: right;">
                    账号类型：
                </td>
                <td style="background:#98bcb2;text-align:left;">
                    <asp:DropDownList ID="ddlAccountType" runat="server" Width="77%" DataTextField="AccShorten"  
                        DataValueField="AccType" AutoPostBack="True" OnSelectedIndexChanged="ddlAccountType_SelectedIndexChanged"
                        Enabled="false">
                    </asp:DropDownList> 
                </td> 
            </tr> 
             <tr style="text-align: left;">
                <td style="text-align: right;">
                    员工编号：
                </td>
                <td style="text-align: left;background:#c79ead;">
                    <asp:TextBox ID="txtUserID" runat="server"  ></asp:TextBox>
                </td> 
                <td style="text-align: right;">
                    国家：
                </td>
                <td style="background:#c79ead;"> 
                    <asp:TextBox ID="txtCountry" runat="server"  ></asp:TextBox>
                </td> 
            </tr>
              <tr>
                <td style="text-align: right;">
                    办公电话2：
                </td>
                <td style="text-align: left;background:#c79ead;">
                    <asp:TextBox ID="txtTel2" runat="server"   ></asp:TextBox>
                </td>
                <td style="text-align: right;">
                    传真：
                </td>
                <td style="text-align: left;background:#c79ead;">
                    <asp:TextBox ID="txtFax" runat="server"   > </asp:TextBox>
                </td>
            </tr> 
              <tr>
                <td style="text-align: right;">
                    家庭：
                </td>
                <td style="text-align: left;background:#c79ead;">
                    <asp:TextBox ID="txtHomeNumber" runat="server"  ></asp:TextBox>
                </td>
                <td style="text-align: right;">
                    移动电话：
                </td>
                <td style="text-align: left;background:#c79ead;">
                    <asp:TextBox ID="txtMobile" runat="server"     > </asp:TextBox>
                </td>
            </tr>  

            <tr style="text-align: left;">
                <td style="text-align: right;">
                    电话号码：
                </td>
                <td style="background:#c79ead;">
                    <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
                </td>
                <td style="text-align: right;">
                    职位：
                </td>
                <td style="text-align: left;background:#c79ead;">
                    <asp:TextBox ID="txtTitle" runat="server"  ></asp:TextBox>
                </td>
            </tr>
            <tr style="text-align: left;">
                <td style="text-align: right;">
                    办公地点：
                </td>
                <td colspan="3"  style="background:#c79ead;">
                    <asp:TextBox ID="txtOffice" runat="server" Width="90%"></asp:TextBox>
                </td> 
            </tr>
            <tr style="text-align: left;">
                <td style="text-align: right;">
                    汇报对象：
                </td>
                <td style="background:#99f;">
                    <asp:TextBox ID="txtReportManager" runat="server" Enabled="false" ></asp:TextBox>
                    <asp:ImageButton ID="chkReportManager" runat="server" ImageUrl="~/Themes/images/checknames.png"
                        OnClick="chkReportManager_Click" OnClientClick="return chkReportManagerEmpty()" />
                    <asp:Image ID="imgTip" runat="server" ImageUrl="" Visible="false" />
                </td>
                <td style="text-align: right;">
                    担保人：
                </td>
                <td style="background:#98bcb2;">
                    <asp:TextBox ID="txtBondsman" runat="server" Enabled="false"></asp:TextBox>
                    <asp:ImageButton ID="chkBondMan" runat="server" ImageUrl="~/Themes/images/checknames.png"
                        OnClick="chkBondMan_Click" OnClientClick="return chkBondManEmpty()" />
                    <asp:Image ID="Image1" runat="server" ImageUrl="" Visible="false" />
                </td>
            </tr>
            <tr style="text-align: left;">
                <td style="text-align: right;">
                    公司名称：
                </td>
                <td colspan="3" style="background:#98bcb2;">
                    <asp:DropDownList ID="ddlCompany" runat="server" AutoPostBack="true" Width="90%"
                        OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged" DataTextField="CompanyName"
                        DataValueField="ID"   Enabled="false">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="text-align: left;">
                <td style="text-align: right;">
                    公司地址：
                </td>
                <td colspan="3" style="background:#98bcb2;">
                    <asp:Label ID="labCompanyAddress" runat="server" Text="" ></asp:Label>
                </td>
            </tr>
           
            <tr style="text-align: left;">
                <td style="text-align: right;">
                    部门：
                </td>
                <td colspan="3"  style="background:#99f;">
                    <asp:DropDownList ID="ddlDeptment" runat="server" Width="90%" DataTextField="DeptName"
                        DataValueField="ID"   Enabled="false">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="text-align: left;">
                <td style="text-align: right;">
                    邮编：
                </td>
                <td  style="background:#98bcb2;" colspan="3">
                    <asp:Label ID="labZipCode" runat="server" Text="" ></asp:Label>
                </td>
            </tr>
            
            <tr style="text-align: left;">
                <td style="text-align: right;">
                    邮箱：
                </td>
                <td  style="background:#98bcb2;">
                    <asp:Label ID="labMail" runat="server" Text=""></asp:Label>
                </td>
               
            </tr>
             <tr style="text-align: left;">
                <td style="text-align: right;">
                    备注：
                </td>
                <td  colspan="3"   style="background:#98bcb2;"> 
                    <asp:TextBox ID="txtNotes" runat="server" Text="" TextMode="MultiLine"  Width="450px" Height="100px" Enabled="false"></asp:TextBox>
                </td> 
            </tr>
            <tr>
                <td style="height: 8px;">
                </td>
            </tr>
            <tr style="text-align: right;">
                <td>
                </td>
                <td style="text-align: left;">
                    注：姓氏和名字只能为字母.
                    <asp:HiddenField ID="hidAccountType" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="height: 20px;">
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
                    <asp:Button ID="BtnSubmit" runat="server" Text="保 存" OnClick="BtnSubmit_Click" OnClientClick="return CheckEmptyValue()" /> 
                </td>
            </tr>
            <tr>
                <td colspan="8" style="height:10px;"> 
                </td>
            </tr>
            <tr>
                <td> 
                </td>
                <td style="text-align:left;" colspan="8" >
                 <div style="width:30px;height:20px;background:#98bcb2;float:left;"></div> &nbsp; Field Can be updated only by WebAdmin administrator. 
                </td>
            </tr>
             <tr> 
                <td> 
                </td>
                <td style="text-align:left;" colspan="8" > 
                 <div style="width:30px;height:20px;background:#99f;float:left;"></div> &nbsp; Field Can be updated only by HR. 
                </td>
            </tr>
             <tr> 
                <td> 
                </td>
                <td style="text-align:left;" colspan="8" > 
                 <div style="width:30px;height:20px;background:#c79ead;float:left;"></div> &nbsp; Field Can be updated by common user. 
                </td>
            </tr>
            <tr>
            <td style="height:20px;"></td>
            </tr>
        </table> 
    </fieldset>
    <br />
    <script language="javascript" type="text/javascript">
        String.prototype.Trim = function () {
            return this.replace(/(^\s*)|(\s*$)/g, "");
        }
        function CheckEmptyValue() {
            var accType = document.getElementById("<%=ddlAccountType.ClientID %>").value.Trim();
            var accTypeOld = document.getElementById("<%=hidAccountType.ClientID %>").value.Trim();
            var bondMan = document.getElementById("<%=txtBondsman.ClientID %>").value;


            if (document.getElementById("<%=ddlCompany.ClientID %>").value.length == 0) {
                alert("请选择公司名称!");
                return false;
            }
            if (document.getElementById("<%=ddlDeptment.ClientID %>").value.length == 0) {
                alert("请选择部门!");
                return false;
            }

            if (accType == accTypeOld) {
                return true;
            }
            if (((accTypeOld == "A") || (accTypeOld == "M") || (accTypeOld == "S")) && (accType == "F") && (bondMan.length > 0)) {
                alert("A/M/S账号类型变更为F类型需删除担保人!");
                return false;
            }
            if (((accType == "A") || (accType == "M") || (accType == "S")) && (accTypeOld == "F") && (bondMan.length == 0)) {
                alert("F账号类型变更为A/M/S类型需填写担保人!");
                return false;
            }
            return true;
        }
        function chkEN(target, val) {
            if (val.keyCode >= 65 && val.keyCode <= 90) {
                return true;
            }
            else {
                alert("姓和名只能输入字母!");
                target.value = "";
                return false;
            }
        }
        function CheckName() {
            if ((document.getElementById("<%=txtFirstName.ClientID %>").value.length == 0)
                || (document.getElementById("<%=txtLastName.ClientID %>").value.length == 0)) {
                alert("请先填写姓氏和名字!");
                return false;
            }
            return true;
        }
        function chkBondManEmpty() {
            if ((document.getElementById("<%=txtBondsman.ClientID %>").value.length == 0)
                || (document.getElementById("<%=txtBondsman.ClientID %>").value.length == 0)) {
                alert("请先填写担保人姓名!");
                return false;
            }
            return true;
        }
        function chkReportManagerEmpty() {
            if ((document.getElementById("<%=txtReportManager.ClientID %>").value.length == 0)
                || (document.getElementById("<%=txtReportManager.ClientID %>").value.length == 0)) {
                alert("请先填写汇报对象姓名!");
                return false;
            }
            return true;
        }
        
    </script>
</asp:Content>
