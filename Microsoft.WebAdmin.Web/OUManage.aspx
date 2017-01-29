<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="OUManage.aspx.cs" Inherits="Microsoft.WebAdmin.Web.OUManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlace" runat="server">
 <br />
    <br />
    <br />
    <table>
        <tr>
            <td style="text-align: right;">
                请输入要转移的人员账号(多个账号以分号;分开):
            </td>
            <td style="text-align: left;">
                <asp:TextBox ID="txtQuerySource" runat="server" Width="350px" 
                    TextMode="MultiLine"></asp:TextBox>
                <asp:ImageButton ID="chkReportManager" runat="server" ImageUrl="~/Themes/images/checknames.png"
                    OnClick="chkReportManager_Click" OnClientClick="return checkUserEmpty()" />
                <asp:Image ID="imgTip" runat="server" ImageUrl="" Visible="false" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                请选择目的OU:
            </td>
            <td style="text-align: left;">
                <asp:DropDownList ID="ddlDestOU" runat="server" Width="150px"  >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            <br />
                <asp:Button ID="btnSave" runat="server" Text="提 交" onclick="btnSave_Click"  
                            OnClientClick="return checkFormEmpty()"/>
            </td>

        </tr>
        <tr>
             <td colspan="2" style="text-align:center;color:Red;">
                <asp:Label  ID="labmsg" Text="" runat="server"/>
             </td>
        </tr>
    </table>
    <script type="text/javascript">
        function checkUserEmpty() {
            if ((document.getElementById("<%=txtQuerySource.ClientID %>").value.length == 0)) {
                alert("请先填写需要进行移动的人员的账号.");
                return false;
            }
            return true;
        }
        function checkFormEmpty() {
            if ((document.getElementById("<%=txtQuerySource.ClientID %>").value.length == 0)) {
                alert("请先填写需要进行移动的人员的账号.");
                return false;
            }
            if ((document.getElementById("<%=ddlDestOU.ClientID %>").value.length == 0)) {
                alert("请先选择要迁移到的OU.");
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
