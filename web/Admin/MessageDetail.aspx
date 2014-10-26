<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageDetail.aspx.cs" Inherits="web.Admin.MessageDetail" %>
<%@ Register Src="UserControl/Head.ascx" TagName="head" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <uc1:head ID="head" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_up"></div>
        <div class="right_title">留言管理</div>
        <div class="right_main bg_color"><b>留言信息</b></div>
        <div class="right_main">
            <div class="right_main_txt">留言人：</div>
            <div class="right_main_input"><asp:Label ID="lblName" runat="server"></asp:Label></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">电话：</div>
            <div class="right_main_input"><asp:Label ID="lblPhone" runat="server"></asp:Label></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">邮箱：</div>
            <div class="right_main_input"><asp:Label ID="lblEmail" runat="server"></asp:Label></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">店址：</div>
            <div class="right_main_input"><asp:Label ID="lblAdr" runat="server"></asp:Label></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">留言时间：</div>
            <div class="right_main_input"><asp:Label ID="lblTime" runat="server"></asp:Label></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">留言内容：</div>
            <div class="right_main_input"><asp:Label ID="lblDetail" runat="server"></asp:Label></div>
        </div>
        <div class="right_btn">
            <div class="right_main_txt"></div>
            <div class="right_main_input"><asp:LinkButton ID="lbtnBack" runat="server" OnClick="lbtnBack_Click">返回上一页</asp:LinkButton></div>
        </div>
    </form>
</body>
</html>
