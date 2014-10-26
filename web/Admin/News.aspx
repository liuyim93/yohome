<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="web.Admin.News" %>
<%@ Register Src="UserControl/Head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="Webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <uc1:head ID="head1" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="right_up"></div>
        <div class="right_title">新闻管理</div>
        <div class="right_main"><b>新闻列表</b>|<a href="AddNews.aspx" target="main">发布新闻</a></div>
        <div class="right_search">标题：<asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>&nbsp;&nbsp;状态：
            <asp:DropDownList ID="dropStatus" runat="server">
                <asp:ListItem Text="全部" Value="2"></asp:ListItem>
                <asp:ListItem Text="已发布" Value="1"></asp:ListItem>
                <asp:ListItem Text="未发布" Value="0"></asp:ListItem>
            </asp:DropDownList>&nbsp;&nbsp;新闻类型：
            <asp:DropDownList ID="dropNewsType" runat="server"></asp:DropDownList>&nbsp;&nbsp;
            <asp:Button ID="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click" />&nbsp;&nbsp;<asp:Button ID="btnShowAll" runat="server" Text="显示全部" OnClick="btnShowAll_Click" />
        </div>
        <div class="right_table">
            <asp:DataGrid ID="dgNews" runat="server" AutoGenerateColumns="false" Width="98%" CellSpacing="1" DataKeyField="NewsId" OnItemCommand="dgNews_ItemCommand" OnItemDataBound="dgNews_ItemDataBound">
                <Columns>
                    <asp:TemplateColumn HeaderText="序号">
                        <ItemTemplate>
                            <asp:Literal ID="ltlNo" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="状态">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnStatus" runat="server" CommandName="status" CommandArgument='<%#Eval("NewsId") %>' Text='<%#Eval("IsShow") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="标题">
                        <ItemTemplate>
                            <a href="Addnews.aspx?id=<%#Eval("NewsId") %>" target="main"><%#Eval("Title") %></a>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="新闻类型">
                        <ItemTemplate>
                            <asp:Literal ID="ltlType" runat="server" Text='<%#Eval("TypeName") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="更新时间">
                        <ItemTemplate>
                            <asp:Literal ID="ltlTime" runat="server" Text='<%#Eval("CreateTime") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="推荐/置顶">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnTop" runat="server" CommandArgument='<%#Eval("NewsId") %>' CommandName="top">顶</asp:LinkButton><asp:HiddenField ID="hfTop" runat="server" Value='<%#Eval("IsTop") %>' />
                            <asp:LinkButton ID="lbtnIndex" runat="server" CommandArgument='<%#Eval("NewsId") %>' CommandName="index">荐</asp:LinkButton><asp:HiddenField ID="hfIndex" runat="server" Value='<%#Eval("IndexShow") %>' />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="操作">
                        <ItemTemplate>
                            <a href="AddNews.aspx?id=<%#Eval("NewsId") %>" target="main">修改</a>|
                            <asp:LinkButton ID="lbtnDel" runat="server" CommandName="del" CommandArgument='<%#Eval("NewsId") %>' OnClientClick="return confirm('确定要删除吗？')">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="选择">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
            </asp:DataGrid>
            <table width="98%" cellspacing="1">
                <tbody>
                    <tr>
                        <td>
                            <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelectAll_CheckedChanged" />全选/反选&nbsp;&nbsp;<asp:Button ID="btnDelSelect" runat="server" Text="批量删除" OnClick="btnDelSelect_Click" OnClientClick="return confirm('确定要删除吗？')" />
                        </td>
                        <td>
                            <Webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="paginator" CurrentPageButtonClass="cpb"
                         LastPageText="尾页" FirstPageText="首页" PrevPageText="上一页" NextPageText="下一页" 
                            AlwaysShow="true" UrlPaging="true" PageSize="10" 
                            onpagechanged="AspNetPager1_PageChanged"></Webdiyer:AspNetPager>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
