<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Microsoft.WebAdmin.Web.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlace" runat="server">
<script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<asp:HiddenField ID="HiddenUserName" runat="server" />
    

<script language="javascript" type="text/javascript">
    $(function () {
        var username = document.getElementById("<%=HiddenUserName.ClientID %>").value;
        if (username.length > 0) {
            $.ajax({
                type: "POST",
                url: "Index.aspx/GetCnt",
                data: "{'username':'" + username + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    if (msg.d == "0") {
                        if (confirm("您还未设置过问题与答案,当忘记密码时可以通过回答问题直接进入,现在要进行设置吗?")) {
                            window.location.href = './LoginQuestion.aspx?s=i';
                        } 
                    } 
                }
            })
        } 
    });

</script>
</asp:Content>
