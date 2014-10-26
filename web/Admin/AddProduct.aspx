<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="web.Admin.AddProduct" %>
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
        <div class="right_title">添加内容<asp:HiddenField ID="hfId" runat="server" /><asp:HiddenField ID="hftypeId" runat="server" /></div>
        <div class="right_main bg_color"><b>添加产品</b>|<asp:HyperLink ID="hlnkPro" runat="server">查看产品列表</asp:HyperLink></div>
        <div class="right_main">
            <div class="right_main_txt">产品名称：</div>
            <div class="right_main_input"><asp:TextBox ID="txtTitle" runat="server" Width="200"></asp:TextBox></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">产品类型:</div>
            <div class="right_main_input"><asp:Label ID="lblType" runat="server"></asp:Label></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">发布时间：</div>
            <div class="right_main_input"><input type="text" id="txtTimer" runat="server" onclick="WdatePicker()" /></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">缩略图：</div>
            <div class="right_main_input"><asp:TextBox ID="txtImg" runat="server" Width="160"></asp:TextBox>&nbsp;&nbsp;<asp:FileUpload ID="fileupload2" runat="server" />&nbsp;&nbsp;<asp:Button ID="btnUpload1" runat="server" Text="上传" OnClick="btnUpload1_Click" /><asp:HiddenField ID="hfImgUrl1" runat="server" />&nbsp;&nbsp;<asp:Label ID="lblUploadStatus1" runat="server"></asp:Label></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">产品大图：</div>
            <div class="right_main_input"><asp:TextBox ID="txtBigImg" runat="server" Width="160"></asp:TextBox>&nbsp;&nbsp;<iframe src="Upload.aspx" frameborder="0" height="23" width="500"></iframe><asp:HiddenField ID="hfImgUrl" runat="server" /></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">产品简介：</div>
            <div class="right_main_input"><FCKeditorV2:FCKeditor ID="fck_intro" runat="server" Width="700" Height="300" EnableSourceXHTML="true" BasePath="~/fckeditor/"></FCKeditorV2:FCKeditor></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">产品内容：</div>
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
        <div class="right_btn">
            <div class="right_main_txt"></div>
            <div class="right_main_input"><asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" /></div>
        </div>
    </form>
</body>
</html>
