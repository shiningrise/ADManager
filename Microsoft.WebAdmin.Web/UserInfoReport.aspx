<%@ Page Title="" Language="C#" MasterPageFile="~/ReportMaster.Master" AutoEventWireup="true" CodeBehind="UserInfoReport.aspx.cs" Inherits="Microsoft.WebAdmin.Web.UserInfoReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlace" runat="server">

  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                              <br />
    <br />
    <fieldset>
        <legend>用户信息导出</legend>
        <table style="text-align: center; width: 70%;margin-left: auto;margin-right: auto;"> 
           <tr style="text-align: left;">
                <td style="text-align: right;"> 
                     <asp:Literal ID="Literal2" runat="server"  Text="<%$ Resources:WAResource,companyName %>"></asp:Literal>
                </td>
                <td  colspan="3">
                    <asp:DropDownList ID="ddlCompany" runat="server" AutoPostBack="true" Width="100%"
                        OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged" DataTextField="CompanyName"
                        DataValueField="ID">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr  style="text-align: center;" >
                <td style="text-align: right;">
                    部门：
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlDeptment" runat="server" Width="100%" DataTextField="DeptName" DataValueField="ID">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right;">
                    账号类型：
                </td>
                <td >  
                    <asp:DropDownList ID="ddlAccountType" runat="server"   DataTextField="AccType" 
                        DataValueField="AccType"   AutoPostBack="true"  Width="100%">
                    </asp:DropDownList> 
                </td> 
            </tr>
             <tr  style="text-align: center;" >
                <td style="text-align: right;">
                    担保人：
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtBondsman" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="chkBondMan" runat="server"  
                        ImageUrl="~/Themes/images/checknames.png" onclick="chkBondMan_Click"  OnClientClick="return chkBondManEmpty()"/>
                        <asp:Image ID="imgTip1" runat="server" ImageUrl="" Visible="false"/>
                </td>
                <td style="text-align: right;">
                    汇报对象：
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtReportManager" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="chkReportManager" runat="server"  
                        ImageUrl="~/Themes/images/checknames.png" onclick="chkReportManager_Click" OnClientClick="return chkReportManagerEmpty()"/>
                        <asp:Image ID="imgTip" runat="server" ImageUrl="" Visible="false"/>
                </td>
            </tr>
            <tr>
            <td colspan="4" style="height:20px;">

            </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center; color: Red;">
                    <asp:Label ID="labmsg" Text="" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="height: 40px;">
                </td>
            </tr>
            <tr style="text-align: center;">
                <td colspan="4">
                    <asp:Button ID="btnExport" runat="server" Text="导  出" 
                        onclick="btnExport_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
                                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                    <ProgressTemplate>
                                                        <div style="filter: alpha(opacity=50); background-color: Gray; position: absolute;
                                                            top: 0px; left: 0px; width: 100%; height: 200%; z-index: 999">
                                                        </div>
                                                        <div style="position: absolute; width: 100%; top: 0px; left: 0px; height: 100%; text-align: center;
                                                            z-index: 1000">
                                                            <div style="width: 100%; height: 100%">
                                                                <table style="height: 100%; width: 100%;" border="0" align="center" cellpadding="0"
                                                                    cellspacing="0" class="INPUTAREA">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Image ID="imageLoading" runat="server" ImageUrl="~/Themes/images/loading.gif" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </ContentTemplate> 
                                            <Triggers>
                                            <asp:PostBackTrigger  ControlID="btnExport" />
                                            </Triggers>
                                        </asp:UpdatePanel>


 
    <script type="text/javascript" language="javascript">
        function chkBondManEmpty() {
            if ((document.getElementById("<%=txtBondsman.ClientID %>").value.length == 0)) {
                alert("请先填写担保人姓名!");
                return false;
            }
            return true;
        }
        function chkReportManagerEmpty() {
            if ((document.getElementById("<%=txtReportManager.ClientID %>").value.length == 0)) {
                alert("请先填写汇报对象姓名!");
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
