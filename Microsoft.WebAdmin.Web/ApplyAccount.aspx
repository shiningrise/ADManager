<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ApplyAccount.aspx.cs" Inherits="Microsoft.WebAdmin.Web.ApplyAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlace" runat="server">
    <br />
    <br />
    <fieldset>
        <legend>创建账号</legend>
        <table style="text-align: center;margin-left: auto;margin-right: auto;">
            <tr>
                <td style="text-align: right;">
                    员工编号：
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtUserID" runat="server"  ></asp:TextBox>
                </td>
                <td style="text-align: right;">
                    姓氏：
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtFirstName" runat="server" onchange="onlyEng(this)"></asp:TextBox>
                </td>
               
            </tr>

            <tr style="text-align: left;">
             <td style="text-align: right;">
                    名字：
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtLastName" runat="server"  onchange="onlyEng(this)"></asp:TextBox>
                </td>
                <td style="text-align: right;">
                    User ID：
                </td>
                <td style="text-align: left;">
                   <div>  
                        <asp:TextBox ID="txtCDSID" runat="server"  width="70px" Text="" ReadOnly="true"></asp:TextBox>
                        <asp:Button ID="btnGetCDSID" runat="server" Text="获取User ID" OnClick="btnGetCDSID_Click"
                            OnClientClick="return CheckName()" Width="100px" />
                   </div>
                </td>
            </tr>
            <tr style="text-align: left;">
                <td style="text-align: right;">
                    汇报对象：
                </td>
                <td>
                    <asp:TextBox ID="txtReportManager" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="chkReportManager" runat="server"  
                        ImageUrl="~/Themes/images/checknames.png" onclick="chkReportManager_Click" OnClientClick="return chkReportManagerEmpty()"/>
                        <asp:Image ID="imgTip" runat="server" ImageUrl="" Visible="false"/>
                </td>
                 <td style="text-align: right;">
                    担保人：
                </td>
                <td>
                    <asp:TextBox ID="txtBondsman" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="chkBondMan" runat="server"  
                        ImageUrl="~/Themes/images/checknames.png" onclick="chkBondMan_Click"  
                        OnClientClick="return chkBondManEmpty()" style="width: 16px"/>
                        <asp:Image ID="imgTip1" runat="server" ImageUrl="" Visible="false"/>
                </td>
            </tr>
            <tr style="text-align: left;">
                <td style="text-align: right;">
                    职  位：
                </td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" Text=""></asp:TextBox>
                </td>
                <td style="text-align: right;">
                    城市：
                </td>
                <td>  
                     <asp:TextBox ID="txtCity" runat="server"  ></asp:TextBox>
                </td> 
            </tr>
 

            <tr style="text-align: left;">
                <td style="text-align: right;">
                    电话号码：
                </td>
                <td>
                    <asp:TextBox ID="txtTel" runat="server" Text="86-21-53298400"></asp:TextBox>
                </td>
                
                <td style="text-align: right;">
                    账号类型：
                </td>
                <td >  
                    <asp:DropDownList ID="ddlAccountType" runat="server"   DataTextField="AccType" 
                        DataValueField="AccType"   AutoPostBack="true" 
                        onselectedindexchanged="ddlAccountType_SelectedIndexChanged">
                    </asp:DropDownList> 
                </td>
                <td style="text-align: right;">
                </td>
            </tr>
            <tr style="text-align: left;">
                <td style="text-align: right;">
                    公司名称：
                </td>
                <td  colspan="3">
                    <asp:DropDownList ID="ddlCompany" runat="server" AutoPostBack="true" Width="100%"
                        OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged" DataTextField="CompanyName"
                        DataValueField="ID">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="text-align: left;">
            <td style="text-align: right;">
                    公司地址：
                </td>
                <td colspan="3">
                    <asp:Label ID="labCompanyAddress" runat="server" Text=""></asp:Label>
                </td>

                </tr>
            <tr style="text-align: left;">
             <td style="text-align: right;">
                    部门：
                </td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlDeptment" runat="server" Width="100%" DataTextField="DeptName"
                        DataValueField="ID">
                    </asp:DropDownList>
                </td>
            </tr>

            <tr style="text-align: left;">
                <td style="text-align: right;">
                   办公地点：
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtOffice" runat="server" Width="100%"></asp:TextBox>
                </td>
                
            </tr>
            <tr style="text-align: left;">
                
                <td style="text-align: right;" >
                    邮编：
                </td>
                <td colspan="3">
                    <asp:Label ID="labZipCode" runat="server" Text=""></asp:Label>
                </td>
               
            </tr>
            <tr style="text-align: left;">
                <td style="text-align: right;">
                    备注：
                </td>
                <td  colspan="3"> 
                    <asp:TextBox ID="txtNotes" runat="server" Text="" TextMode="MultiLine"  Width="450px" Height="100px"></asp:TextBox>
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
                </td>
            </tr>
            <tr style="text-align: right;">
                <td colspan="8" style="text-align:center;color:Red;">
                <asp:Label  ID="labmsg" Text="" runat="server"/>
                </td>
            </tr>
            <tr>
                <td style="height: 40px;">
                </td>
            </tr>
            <tr style="text-align: center;">
                <td colspan="8">
                    <asp:Button ID="BtnSubmit" runat="server" Text="提 交" OnClick="BtnSubmit_Click" OnClientClick="return CheckEmptyValue()" />
                </td>
            </tr>
        </table>
    </fieldset>

    <script type="text/javascript">
        function chkReportManagerEmpty() {
            if (document.getElementById("<%=txtReportManager.ClientID %>").value.length == 0) {
                alert("请先填写汇报对象!");
                return false;
            }
            return true;
        }
        function chkBondManEmpty() {
            if (document.getElementById("<%=txtBondsman.ClientID %>").value.length == 0) {
                alert("请先填写担保人姓名!");
                return false;
            }
            return true;
        }
        function onlyEng(target) {
            var txt = target.value;
            txt = txt.replace(/[^a-zA-Z]/g, '');
            target.value = txt;
        }
        function CheckEmptyValue(){
            var accType=document.getElementById("<%=ddlAccountType.ClientID %>").value;
            if (document.getElementById("<%=txtCDSID.ClientID %>").value) {
                alert("请先获取User ID!");
                return false;
            }
            if (accType.length==0) {
                alert("请先选择账号类型!");
                return false;
            }
            if (document.getElementById("<%=ddlCompany.ClientID %>").value) {
                alert("请先选择公司名称!");
                return false;
            }
            if (document.getElementById("<%=ddlDeptment.ClientID %>").value) {
                alert("请先选择部门名称!");
                return false;
            }
            if (((accType=="A")||(accType=="M")||(accType=="S"))
                && (document.getElementById("<%=txtBondsman.ClientID %>").value.length==0)) {
                alert("请填写担保人!");
                return false;
            }
            return true;
        }
        function CheckName() {
            if ((document.getElementById("<%=txtFirstName.ClientID %>").value.length == 0)
                || (document.getElementById("<%=txtLastName.ClientID %>").value.length == 0)) {
                alert("请先填写姓氏和名字!");
                return false;
            }
            return true;
        }
        function CheckEmptyValue() {
            var accType = document.getElementById("<%=ddlAccountType.ClientID %>").value;
            if (document.getElementById("<%=txtCDSID.ClientID %>").value.length == 0) {
                alert("请先获取User ID!");
                return false;
            }
            if (accType.length == 0) {
                alert("请选择账号类型!");
                return false;
            }
            if (document.getElementById("<%=ddlCompany.ClientID %>").value.length == 0) {
                alert("请选择公司名称!");
                return false;
            }
            if (document.getElementById("<%=ddlDeptment.ClientID %>").value.length == 0) {
                alert("请选择部门!");
                return false;
            }

            if (((accType == "A") || (accType == "M") || (accType == "S"))
                 && (document.getElementById("<%=txtBondsman.ClientID %>").value.length == 0)) {
                alert("请填写担保人!");
                return false;
            }
            if (((accType == "A") || (accType == "M") || (accType == "S"))
                 && (document.getElementById("<%=txtNotes.ClientID %>").value.length == 0)) {
                alert("请在备注中输入该人员所属公司信息(公司名称、职务、经理名称)!");
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
