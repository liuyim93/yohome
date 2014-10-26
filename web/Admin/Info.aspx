<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="web.Admin.Info" %>
<%@ Register Src="UserControl/Head.ascx" TagName="head" TagPrefix="uc1" %>
<%@Register Assembly="FredCK.FCKEditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <uc1:head ID="head1" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_up"></div>
        <div class="right_title">添加单篇文章</div>
        <div class="right_main bg_color"><b>修改内容</b></div>
        <div class="right_main">
            <div class="right_main_txt">标题：</div>
            <div class="right_main_input"><asp:Literal ID="ltlTitle" runat="server"></asp:Literal></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">内容：</div>
            <div class="right_main_input">
                <FCKeditorV2:FCKeditor ID="fck_detail" runat="server" Width="700" Height="350" EnableSourceXHTML="true" BasePath="~/fckeditor/"></FCKeditorV2:FCKeditor>
            </div>
        </div>
        <div class="right_btn">
            <div class="right_main_txt"></div>
            <div class="right_main_input"><asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" /></div>
        </div>
    </form>
</body>
</html>
