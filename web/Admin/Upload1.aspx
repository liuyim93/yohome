<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload1.aspx.cs" Inherits="web.Admin.Upload1" %>

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
        <asp:FileUpload ID="fileupload2" runat="server" />&nbsp;&nbsp;<asp:Button ID="btnUpload2" runat="server" Text="上传" OnClick="btnUpload2_Click" />&nbsp;&nbsp;<asp:Label ID="lblStatus2" runat="server"></asp:Label>        
    </div>
    </form>
</body>
</html>
