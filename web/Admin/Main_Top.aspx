<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main_Top.aspx.cs" Inherits="web.Admin.Main_Top" %>
<%@ Register Src="UserControl/Head.ascx" TagName="head" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <uc1:head ID="head1" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="top">
        <div class="top_logo"><img src="Images/dwzx_logo2.png" alt="" width="210" height="64" /></div> 
        <div class="top_right">  
            <div class="top_right_t">
                <span><a href="/" target="_blank"><img src="Images/top_home.jpg" alt="网站首页" /></a></span>
                <ul>
                    <li><a href="Main.aspx" target="_top">后台管理首页</a></li>
                    <li><img src="Images/top_dot.jpg" alt="" width="2" height="18" align="absmiddle" /></li>
                    <li> <a href="UpdatePwd.aspx" target="main">修改密码</a></li>
                    <li><img src="Images/top_dot.jpg" height="18" width="2" alt="" align="absmiddle" /></li>
                    <li><a href="Index.aspx" target="_top">退出登录</a></li>
                </ul>
            </div>
            <div class="top_right_m"></div>
            <div class="top_right_b">
                <b>欢迎信息</b>：欢迎您&nbsp;<asp:Label ID="lblName" runat="server"></asp:Label>&nbsp;!&nbsp;您现在登录的是后台管理系统!&nbsp;&nbsp;当前时间：<label id="time"></label>
            </div>
    </div>
  </div>
        <script type="text/javascript">
            function showtime() {
                var time_div = document.getElementById('time');
                var now = new Date();         
                time_div.innerHTML = now.getFullYear() + "年" + (now.getMonth()+1) + "月" + now.getDate() + "日 " + now.getHours() + ":" + now.getMinutes() + ":" + now.getSeconds();
                setTimeout(showtime,1000);
            }
            showtime();
        </script>
    </form>
</body>
</html>
