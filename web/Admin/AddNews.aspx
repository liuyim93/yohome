<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="web.Admin.AddNews" %>
<%@ Register Src="UserControl/Head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Assembly="FredCK.FCKEditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <uc1:head ID="head" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_up"></div>
        <div class="right_title">添加内容</div>
        <div class="right_main bg_color"><b>添加新闻</b>|<a href="News.aspx" target="main">查看新闻列表</a></div>
        <div class="right_main">
            <div class="right_main_txt">标题：<asp:HiddenField ID="hfId" runat="server" /></div>
            <div class="right_main_input"><asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">新闻类型：</div>
            <div class="right_main_input"><asp:DropDownList ID="dropType" runat="server"></asp:DropDownList></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">发布时间：</div>
            <div class="right_main_input"><input id="txtTimer" runat="server" onclick="WdatePicker()" type="text" /></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">缩略图：</div>
            <div class="right_main_input"><asp:TextBox ID="txtImgUrl" runat="server" Width="150"></asp:TextBox>&nbsp;&nbsp;<iframe src="Upload.aspx" height="23" width="500" frameborder="0"></iframe><asp:HiddenField ID="hfImgUrl" runat="server" /></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">简介：</div>
            <div class="right_main_input"><FCKeditorV2:FCKeditor ID="fck_intro" runat="server" Width="700" Height="300" EnableSourceXHTML="true" BasePath="~/fckeditor/"></FCKeditorV2:FCKeditor></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">内容：</div>
            <div class="right_main_input"><FCKeditorV2:FCKeditor ID="fck_detail" runat="server" Width="700" Height="400" EnableSourceXHTML="true" BasePath="~/fckeditor/"></FCKeditorV2:FCKeditor></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">立即发布：</div>
            <div class="right_main_input"><asp:CheckBox ID="chkShow" runat="server" Checked="true" /></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">首页显示：</div>
            <div class="right_main_input"><asp:CheckBox ID="chkIndex" runat="server" /></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">置顶：</div>
            <div class="right_main_input"><asp:CheckBox ID="chkTop" runat="server" /></div>
        </div>
        <div class="right_btn">
            <div class="right_main_txt"></div>
            <div class="right_main_input"><asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" /></div>
        </div>
    </form>
</body>
</html>
