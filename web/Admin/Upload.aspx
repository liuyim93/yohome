<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="Web.Admin.Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Styles/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="upload_div">
        <asp:FileUpload ID="fileupload1" runat="server" />&nbsp;&nbsp;<asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="上传" />&nbsp;&nbsp;<asp:Label ID="lblStatus" runat="server"></asp:Label>        
    </div>
    </form>
</body>
</html>
