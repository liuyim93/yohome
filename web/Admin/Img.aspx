<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Img.aspx.cs" Inherits="web.Admin.Banner" %>
<%@ Register Src="UserControl/Head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="Webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <uc1:head ID="head" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="right_up"></div>
        <div class="right_title">图片管理<asp:HiddenField ID="hfTypeId" runat="server" /></div>
        <div class="right_main bg_color"><b><asp:Literal ID="ltlTitle" runat="server"></asp:Literal></b>|<asp:HyperLink ID="hlnkAdd" runat="server">添加新图片</asp:HyperLink></div>
        <div class="right_search"></div>
        <div class="right_table">
            <asp:DataGrid ID="dgBanner" runat="server" AutoGenerateColumns="false" DataKeyField="ImgId" OnItemCommand="dgBanner_ItemCommand" OnItemDataBound="dgBanner_ItemDataBound" Width="98%">
                <Columns>
                    <asp:TemplateColumn HeaderText="序号">
                        <ItemTemplate>
                            <asp:Literal ID="ltlNo" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="状态">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnStatus" runat="server" Text='<%#Eval("IsShow") %>' CommandArgument='<%#Eval("ImgId") %>' CommandName="status"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="标题">
                        <ItemTemplate>
                            <a href="AddImg.aspx?id=<%#Eval("ImgId") %>" target="main"><%#Eval("Title") %></a>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="缩略图">
                        <ItemTemplate>
                            <a href="../<%#Eval("ImgUrl") %>" target="_blank"><img src="../<%#Eval("ImgUrl") %>" alt='<%#Eval("Title") %>' width="100" height="50" /></a>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="排序">
                        <ItemTemplate>
                            <asp:Literal ID="ltlRank" runat="server" Text='<%#Eval("Rank") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="添加时间">
                        <ItemTemplate>
                            <asp:Literal ID="ltlCreateTime" runat="server" Text='<%#Eval("CreateTime") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="操作">
                        <ItemTemplate>
                            <a href="AddImg.aspx?id=<%#Eval("ImgId") %>" target="main">修改</a>|
                            <asp:LinkButton ID="lbtnDel" runat="server" CommandArgument='<%#Eval("ImgId") %>' CommandName="del" OnClientClick="return confirm('确定要删除吗？')">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="选择">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
            </asp:DataGrid>
            <table width="98%">
                <tbody>
                    <tr>
                        <td>&nbsp;&nbsp;<asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelectAll_CheckedChanged" />全选/反选&nbsp;&nbsp;<asp:Button ID="btnDelSelect" runat="server" Text="批量删除" OnClick="btnDelSelect_Click" /></td>
                        <td><Webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="paginator" CurrentPageButtonClass="cpb"
                         LastPageText="尾页" FirstPageText="首页" PrevPageText="上一页" NextPageText="下一页" 
                            AlwaysShow="true" UrlPaging="true" PageSize="10" 
                            onpagechanged="AspNetPager1_PageChanged"></Webdiyer:AspNetPager></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
