<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main_Left.aspx.cs" Inherits="web.Admin.Main_Left" %>
<%@ Register Src="UserControl/Head.ascx" TagName="head" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <uc1:head  ID="head1" runat="server"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="left">                
        <div class="left_title">
            网站系统设置
        </div>
        <dl id="left_m1">
            <dt><a href="SiteInfo.aspx" target="main">网站信息设置</a></dt>
            <dt><a href="Img.aspx?typeId=2" target="main">友情链接管理</a></dt>
            <dt><a href="Message.aspx" target="main">在线留言管理</a></dt>
            <dt><a href="Img.aspx?typeId=1" target="main">幻灯图片管理</a></dt>
        </dl>
        <div class="left_title">网站信息设置</div>
        <dl id="left_m2">
            <dt><a href="Info.aspx?id=2" target="main">品牌介绍</a></dt>
                <dd>├<a href="Info.aspx?id=2" target="main">湾仔故事介绍</a></dd>
                <dd>├<a href="Info.aspx?id=18" target="main">品牌形象诠释</a></dd>
                <dd>├<a href="Info.aspx?id=19" target="main">我的专业</a></dd>
                <dd>├<a href="Info.aspx?id=20" target="main">湾仔故事公司</a></dd>
                <dd>├<a href="Info.aspx?id=21" target="main">品牌定位和诉求</a></dd>
            <dt><a href="News.aspx" target="main">最新资讯</a></dt>               
                <dd>├<a href="News.aspx?id=2" target="main">新店开张快讯</a>&nbsp;|&nbsp;<a href="AddNews.aspx?typeId=2" target="main">添加</a></dd>
                <dd>├<a href="News.aspx?id=3" target="main">热点活动快讯</a>&nbsp;|&nbsp;<a href="AddNews.aspx?typeId=3" target="main">添加</a></dd>
                <dd>├<a href="News.aspx?id=4" target="main">最新上市新品</a>&nbsp;|&nbsp;<a href="AddNews.aspx?typeId=4" target="main">添加</a></dd>
                <dd>├<a href="News.aspx?id=5" target="main">行业快讯</a>&nbsp;|&nbsp;<a href="AddNews.aspx?typeId=5" target="main">添加</a></dd>
            <dt><a href="Product.aspx?typeId=2" target="main">分店展示</a></dt>
                <dd>├<a href="Product.aspx?typeId=2" target="main">全球连锁店铺</a>&nbsp;|&nbsp;<a href="AddProduct.aspx?typeId=2" target="main">添加</a></dd>
            <dt><a href="Product.aspx?typeId=4" target="main">创新产品</a></dt>
                <dd>├<a href="Product.aspx?typeId=4" target="main">全线产品</a>&nbsp;|&nbsp;<a href="AddProduct.aspx?typeId=4" target="main">添加</a></dd>
                <dd>├<a href="Product.aspx?typeId=5" target="main">本月特推</a>&nbsp;|&nbsp;<a href="AddProduct.aspx?typeId=5" target="main">添加</a></dd>
                <dd>├<a href="Product.aspx?typeId=6" target="main">创新产品</a>&nbsp;|&nbsp;<a href="AddProduct.aspx?typeId=6" target="main">添加</a></dd>
            <dt><a href="Info.aspx?id=4" target="main">加盟必读</a></dt>
                <dd>├<a href="Info.aspx?id=4" target="main">创业心得</a></dd>
                <dd>├<a href="Info.aspx?id=5" target="main">总部支持</a></dd>
                <dd>├<a href="Info.aspx?id=6" target="main">投资及收益预算</a></dd>
                <dd>├<a href="Info.aspx?id=7" target="main">加盟学堂</a></dd>
                <dd>├<a href="Info.aspx?id=8" target="main">答疑解惑</a></dd>
            <dt><a href="Info.aspx?id=22" target="main">合作方式</a></dt>
                <dd>├<a href="Info.aspx?id=22" target="main">合作方式</a></dd>
            <dt><a href="Info.aspx?id=11" target="main">联系我们</a></dt>
                <dd>├<a href="Info.aspx?id=11" target="main">联系方式</a></dd>
                <dd>├<a href="Info.aspx?id=12" target="main">外送服务</a></dd>
                <dd>├<a href="Info.aspx?id=13" target="main">招聘信息</a></dd>
            <dt><a href="Product.aspx?typeId=8" target="main">周边下载</a></dt>
                <dd>├<a href="Product.aspx?typeId=8" target="main">QQ表情</a>&nbsp;|&nbsp;<a href="AddProduct.aspx?typeId=8" target="main">添加</a></dd>
                <dd>├<a href="Product.aspx?typeId=9" target="main">电脑壁纸</a>&nbsp;|&nbsp;<a href="AddProduct.aspx?typeId=9" target="main">添加</a></dd>
            <dt><a href="Info.aspx?id=15" target="main">底部信息</a></dt>
                <dd>├<a href="Info.aspx?id=15" target="main">首页底部信息</a></dd>
                <dd>├<a href="Info.aspx?id=16" target="main">底部信息1</a></dd>
                <dd>├<a href="Info.aspx?id=17" target="main">底部信息2</a></dd>
             <dt><a>其他</a></dt>
                <dd>├<a href="Info.aspx?id=23" target="main">首页视频信息</a></dd>
                <dd>├<a href="AddImg1.aspx" target="main">首页开幕图片</a></dd>
        </dl>
    </div>
    </form>
</body>
</html>
