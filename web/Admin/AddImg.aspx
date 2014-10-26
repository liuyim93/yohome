<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddImg.aspx.cs" Inherits="web.Admin.AddImg" %>
<%@ Register Src="UserControl/Head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Assembly="FredCK.FCKEditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <uc1:head ID="head1" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="right_up"></div>
        <div class="right_title">添加内容<asp:HiddenField ID="hfId" runat="server" /><asp:HiddenField ID="hfTypeId" runat="server" /></div>
        <div class="right_main bg_color"><b><asp:Literal ID="ltlTitle" runat="server"></asp:Literal></b>|<asp:HyperLink ID="hlnkList" runat="server"></asp:HyperLink></div>
        <div class="right_main">
            <div class="right_main_txt">标题：</div>
            <div class="right_main_input"><asp:TextBox ID="txtTitle" runat="server" Width="200"></asp:TextBox></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">图片类型：</div>
            <div class="right_main_input"><asp:Label ID="lblType" runat="server"></asp:Label></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">图片地址：</div>
            <div class="right_main_input"><asp:TextBox ID="txtImg" runat="server" Width="160"></asp:TextBox><iframe src="Upload.aspx" frameborder="0" height="23" width="500"></iframe><asp:HiddenField ID="hfImgUrl" runat="server" /></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">链接地址：</div>
            <div  class="right_main_input"><asp:TextBox ID="txtLink" runat="server"></asp:TextBox></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">添加时间：</div>
            <div class="right_main_input"><input type="text" id="txtTimer" runat="server" onclick="WdatePicker()" /></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">排序：</div>
            <div class="right_main_input"><asp:TextBox ID="txtRank" runat="server" Width="60"></asp:TextBox></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">立即发布：</div>
            <div class="right_main_input"><asp:CheckBox ID="chkShow" runat="server" Checked="true" /></div>
        </div>
        <div class="right_btn">
            <div class="right_main_txt"></div>
            <div class="right_main_input"><asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" /></div>
        </div>
    </form>
</body>
</html>
