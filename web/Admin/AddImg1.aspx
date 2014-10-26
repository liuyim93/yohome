<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddImg1.aspx.cs" Inherits="web.Admin.AddImg1" %>
<%@ Register Src="UserControl/Head.ascx" TagName="head" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <uc1:head  ID="head1" runat="server"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="right_up"></div>
        <div class="right_title">图片管理<asp:HiddenField ID="hfImgId" runat="server" /></div>
        <div class="right_main bg_color"><b>首页盛大开幕图片管理</b></div>
        <div class="right_main">
            <div class="right_main_txt">图片预览：</div>
            <div class="right_main_input"><asp:Image ID="imgOpen" runat="server" Width="236" Height="130" />&nbsp;&nbsp;<span style="color:#f00">建议图片尺寸：236*130px,图片格式不限</span></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">上传图片：</div>
            <div class="right_main_input"><iframe src="Upload.aspx" height="23" width="500" frameborder="0"></iframe><asp:HiddenField ID="hfImgUrl" runat="server" /></div>
        </div>
        <div class="right_btn">
            <div class="right_main_txt"></div>
            <div class="right_main_input"><asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" /></div>
        </div>
    </form>
</body>
</html>
