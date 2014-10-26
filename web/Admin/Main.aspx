<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="web.Admin.Main" %>
<%@ Register Src="UserControl/Head.ascx" TagName="head" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><asp:Literal ID="ltlTitle" runat="server"></asp:Literal></title>
    <uc1:head ID="head1" runat="server" />
</head>
    <frameset rows="85,*">
           <frame src="Main_Top.aspx" scrolling="no" frameborder="0" noresize="noresize" name="top" /> 
           <frameset cols="15%,*">
               <frame src="Main_Left.aspx" scrolling="yes" frameborder="0" noresize="noresize" name="left" marginheight="0" marginwidth="0" />
               <frame src="right.aspx" scrolling="auto" frameborder="0" noresize="noresize" name="main" marginheight="0" marginwidth="0"  />
           </frameset>
    </frameset>
    <noframes>
        <body>
            <form id="form1" runat="server">
            <div>
                您的浏览器不支持框架，请使用IE6以上版本的浏览器！
            </div>
            </form>
        </body>
    </noframes>
</html>
