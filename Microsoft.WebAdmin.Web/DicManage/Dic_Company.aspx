<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Dic_Company.aspx.cs" Inherits="Microsoft.WebAdmin.Web.DicMange.Dic_Company" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlace" runat="server">
<br />
    <br />
    <fieldset style="width: 95%">
        <legend>公司信息浏览</legend>
        <table style="text-align: left; width: 85%">
            <tr style="text-align: left;">
                <td>
                </td>
                <td style="text-align: right;">
                    请输入公司名称：
                </td>
                <td>
                    <asp:TextBox ID="txtQuery" runat="server"></asp:TextBox>
                    <asp:Button ID="btnQuery" runat="server" Text="查 询" OnClick="btnQuery_Click" />
                </td>
                <td> 
                    <asp:Button ID="btnCreate" runat="server" Text="创建" onclick="btnCreate_Click" /> 
                </td>
            </tr>
            <tr>
                <td colspan="5" style="width: 100%;">
                    <asp:GridView ID="gvDetail" runat="server" OnPageIndexChanging="gvPhaseList_PageIndexChanging"
                        AutoGenerateColumns="False" AllowPaging="True" OnRowDataBound="gvApplyRequest_RowDataBound"
                        CssClass="gridview_fh" EnableModelValidation="True" PageSize="20">
                        <Columns>  
                            <asp:BoundField DataField="ID" HeaderText="序号" Visible="false">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CompanyName" HeaderText="公司名称">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Address" HeaderText="公司地址">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ZipCode" HeaderText="邮  编">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                           
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit"  Text="编辑" CommandName="Edits" OnCommand="btnGet_Command" Width="60px"
                                        CommandArgument='<%# Bind("ID") %>' runat="server"   ForeColor="blue" /> 
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDel"  Text="删除" CommandName="Dels" OnCommand="btnGet_Command" Width="60px"
                                        CommandArgument='<%# Bind("ID") %>' runat="server"   ForeColor="blue" /> 
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr style="width:90%;text-align:center;" >
                <td style="width:90%;text-align:center;" colspan="4">
                    <div runat="server" id="EditDiv" visible="false"> 
                        <table>
                            <tr>
                                <td style="width:100px;display:none;">
                                序      号：
                                </td>
                                <td  style="width:300px;display:none;">
                                    <asp:TextBox ID="txtNo" runat="server" Width="300px" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:100px;">
                                公司名字：
                                </td>
                                <td  style="width:300px;">
                                    <asp:TextBox ID="txtCompany" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:100px;">
                                公司地址：
                                </td>
                                <td  style="width:300px;">
                                    <asp:TextBox ID="txtAddress" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr> 
                            <tr>
                                <td style="width:100px;">
                                邮&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 编：
                                </td>
                                <td  style="width:300px;">
                                    <asp:TextBox ID="txtZipCode" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr> 
                            <tr>
                            <td colspan="2" style="height:10px;"></td>
                            </tr>
                            <tr>
                            <td colspan="2">
                                <asp:Button ID="btnUpdate" runat="server" Text="保  存" 
                                    onclick="btnUpdate_Click" />
                            </td>
                            </tr>
                         </table>
                      </div>
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
