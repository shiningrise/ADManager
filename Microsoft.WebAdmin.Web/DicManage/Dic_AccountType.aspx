﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Dic_AccountType.aspx.cs" Inherits="Microsoft.WebAdmin.Web.DicManage.Dic_AccountType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlace" runat="server">
<br />
    <br />
    <fieldset style="width: 95%">
        <legend>账号类型浏览</legend>
        <table style="text-align: left; width: 85%">
            <tr style="text-align: left;">
                <td>
                </td>
                <td style="text-align: right;">
                    请输入账号类型名称：
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
                            <asp:BoundField DataField="AccType" HeaderText="账号类型简写">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AccShorten" HeaderText="账号类型">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                           <asp:BoundField DataField="Description" HeaderText="账号描述">
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
                                账号类型简写：
                                </td>
                                <td  style="width:300px;">
                                    <asp:TextBox ID="txtAccType" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                             <tr>
                                <td style="width:100px;">
                                账号类型：
                                </td>
                                <td  style="width:300px;">
                                    <asp:TextBox ID="txtAccShorten" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:100px;">
                                账号描述：
                                </td>
                                <td  style="width:300px;">
                                    <asp:TextBox ID="txtDescription" runat="server" Width="300px"></asp:TextBox>
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
    <style type="text/css">
        table.gridview_fh td, th
        {
            border-collapse: collapse;
            border: solid 1px #93c2f1;
            font-size: 10pt;
        }
        table.gridview_fh
        {
            border-collapse: collapse;
            border: solid 1px #93c2f1;
            width: 98%;
            font-size: 10pt;
        }
        
        table.gridview_fh td, th
        {
            border-collapse: collapse;
            border: solid 1px #93c2f1;
            font-size: 10pt;
        }
    </style>
</asp:Content>
