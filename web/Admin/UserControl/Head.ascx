<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Head.ascx.cs" Inherits="web.Admin.UserControl.Head" %>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" type="text/css" href="Styles/Main.css" />
<script type="text/javascript" src="../Scripts/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="/My97DatePicker/WdatePicker.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        var input = $(".right_main_input input[type='text']");
        var textarea = $(".right_main_input textarea");
        input.focus(function () {
            $(this).css("border", "1px solid #f00");
        });
        input.blur(function () {
            $(this).css("border", "1px solid #7F9DB9");
        });
        textarea.focus(function () {
            $(this).css("border", "1px solid #f00");
        });
        textarea.blur(function () {
            $(this).css("border", "1px solid #7F9DB9");
        });
    });
</script>