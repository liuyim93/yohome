<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePwd.aspx.cs" Inherits="web.Admin.UpdatePwd" %>
<%@ Register Src="UserControl/Head.ascx" TagName="head" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><asp:Literal ID="ltlTitle" runat="server"></asp:Literal></title>
    <uc1:head ID="head1" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_up"></div>
        <div class="right_title">修改内容</div>
        <div class="right_main bg_color"><b>修改密码</b>
        </div>
        <div class="right_main">
            <div class="right_main_txt">原密码：</div>
            <div class="right_main_input"><asp:TextBox ID="txtpwd" runat="server" TextMode="Password"></asp:TextBox></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">新密码：</div>
            <div class="right_main_input"><asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">确认密码：</div>
            <div class="right_main_input"><asp:TextBox ID="txtPwd1" runat="server" TextMode="Password"></asp:TextBox></div>
        </div>
        <div class="right_btn">
            <div class="right_main_txt"></div>
            <div class="right_main_input"><asp:Button ID="btnSubmit" runat="server" Text="保存" OnClick="btnSubmit_Click" /></div>
        </div>
    </form>
</body>
</html>
