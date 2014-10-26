<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteInfo.aspx.cs" Inherits="web.Admin.SiteInfo" %>
<%@ Register Src="UserControl/Head.ascx" TagName="head" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><asp:Literal ID="ltlTitle" runat="server"></asp:Literal></title>
    <uc1:head ID="head1" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_up bg_color"></div>
        <div class="right_title">网站信息设置</div>
        <div class="right_main bg_color"><b>基本设置</b><asp:HiddenField ID="hfId" runat="server" /></div>
        <div class="right_main"><div class="right_main_txt">网站标题：</div><div class="right_main_input"><asp:TextBox ID="txtSiteTitle" runat="server"></asp:TextBox></div></div>
        <div class="right_main">
            <div class="right_main_txt">网站关键词：</div>
            <div class="right_main_input"><asp:TextBox ID="txtKeyWords" runat="server"></asp:TextBox></div>
        </div>
        <div class="right_main" style="height:85px;">
            <div class="right_main_txt">网站描述：</div>
            <div class="right_main_input"><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">网站LOGO：</div>
            <div class="right_main_input"><asp:TextBox ID="txtLogo" runat="server"></asp:TextBox></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">网站LOGO上传：</div>
            <div class="right_main_input"><iframe src="Upload.aspx" frameborder="0" scrolling="no" height="23" width="500"></iframe><asp:HiddenField ID="hfImgUrl" runat="server" /></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">网站地址：</div>
            <div class="right_main_input"><asp:TextBox ID="txtUrl" runat="server"></asp:TextBox></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">公司名称：</div>
            <div class="right_main_input"><asp:TextBox ID="txtCompany" runat="server"></asp:TextBox></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">公司地址：</div>
            <div class="right_main_input"><asp:TextBox ID="txtAdress" runat="server"></asp:TextBox></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">邮政编码：</div>
            <div class="right_main_input"><asp:TextBox ID="txtPostCode" runat="server"></asp:TextBox></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">联系人：</div>
            <div class="right_main_input"><asp:TextBox ID="txtLinkMan" runat="server"></asp:TextBox></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">电话号码：</div>
            <div class="right_main_input"><asp:TextBox ID="txtTel" runat="server"></asp:TextBox></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">手机号码：</div>
            <div class="right_main_input">
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">公司传真：</div>
            <div class="right_main_input"><asp:TextBox ID="txtFax" runat="server"></asp:TextBox></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">电子邮箱：</div>
            <div class="right_main_input"><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">备案号：</div>
            <div class="right_main_input"><asp:TextBox ID="txtRecord" runat="server"></asp:TextBox></div>
        </div>
        <div class="right_main">
            <div class="right_main_txt">背景音乐：</div>
            <div class="right_main_input"><asp:TextBox ID="txtBgsound" runat="server"></asp:TextBox><iframe src="Upload1.aspx" width="350" height="23" frameborder="0" scrolling="no"></iframe><asp:HiddenField ID="hfImgUrl2" runat="server" /></div>
        </div>
        <div class="right_main" style="height:85px;">
            <div class="right_main_txt">统计代码：</div>
            <div class="right_main_input"><asp:TextBox ID="txtStatCode" runat="server" TextMode="MultiLine"></asp:TextBox></div>
        </div>
        <div class="right_btn">
            <div class="right_main_txt"></div>
            <div class="right_main_input"><asp:Button ID="btnSubmit" runat="server" Text="保存" OnClick="btnSubmit_Click" /></div>
        </div>
    </form>
</body>
</html>
