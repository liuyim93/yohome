<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="web.Admin.Admin_Login" %>
<%@ Register Src="UserControl/Head.ascx" TagName="head" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><asp:Literal ID="ltlTitle" runat="server"></asp:Literal></title>
    <uc1:head ID="head1" runat="server" />
</head>
<body class="login ">
    <form id="form1" runat="server">
        <div class="login_div">
            <p><label>用户名</label><asp:TextBox ID="txtUserName" runat="server" CssClass="login_txt"></asp:TextBox></p>
            <p><label>密&nbsp;&nbsp;码&nbsp;&nbsp;</label><asp:TextBox ID="txtPwd" runat="server" CssClass="login_txt" TextMode="Password"></asp:TextBox></p>
            <p><label>验证码&nbsp;&nbsp;</label><asp:TextBox ID="txtCodeImage" runat="server" Width="80" CssClass="login_txt"></asp:TextBox>&nbsp;<img src="CodeImage.aspx" width="40" height="24" alt="验证码" title="看不清楚？换一张" id="codeimage" align="absmiddle" onclick="this.src='CodeImage.aspx?s='+Math.random();" /></p>
            <div class="login_btn1"><asp:Button ID="btnLogin" runat="server" Text="登陆系统" CssClass="login_btn" OnClick="btnLogin_Click" /></div>
            <div class="copyright">Copyright© 2014-2024 动维在线 All Rights Reserved </div>
        </div>
    </form>
</body>
</html>
