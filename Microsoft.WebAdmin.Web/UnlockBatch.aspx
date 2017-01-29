<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UnlockBatch.aspx.cs" Inherits="Microsoft.WebAdmin.Web.UnlockBatch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlace" runat="server">

 <br />
    <br />
    <fieldset style="width: 95%">
        <legend>账号解锁</legend>
        <table style="text-align: left; width: 85%">
            <tr style="text-align: left;">
                <td>
                </td>
                <td style="text-align: right;">
                    请输入需要解锁的账号：
                </td>
                <td>
                    <asp:TextBox ID="txtCDSID" runat="server"></asp:TextBox>
                    <asp:Button ID="btnQuery" runat="server" Text="查 询" OnClick="btnQuery_Click" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="width: 100%;">
                    <asp:GridView ID="gvDetail" runat="server" OnPageIndexChanging="gvPhaseList_PageIndexChanging"
                        AutoGenerateColumns="False" AllowPaging="True" OnRowDataBound="gvApplyRequest_RowDataBound"
                        CssClass="gridview_fh" EnableModelValidation="True" PageSize="20" PagerStyle-ForeColor="Blue" PagerSettings-Mode="NumericFirstLast">
                        <Columns>
                            <asp:TemplateField HeaderText="登录账号">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkLogon" runat="server" ForeColor="blue" Text='<%# Bind("accountID") %>'>
                                    </asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="DisplayName" HeaderText="账号名字">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Tel" HeaderText="电 话">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="department" HeaderText="部 门">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDelay" Text="解锁" CommandName="unlock" OnCommand="btnGet_Command"
                                        Width="60px" CommandArgument='<%# Bind("accountID") %>' runat="server" ForeColor="blue" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="6" style="text-align: center; color: red;">
                    <asp:Label ID="labmsg" Text="" runat="server" />
                </td>
            </tr>
        </table>
    </fieldset>
   
</asp:Content>
