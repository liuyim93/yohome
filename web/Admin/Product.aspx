<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="web.Admin.Product" %>
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
        <div class="right_title">产品管理<asp:HiddenField ID="hfTypeId" runat="server" /></div>
        <div class="right_main bg_color"><b>产品列表</b>|<asp:HyperLink ID="hlnkAdd" runat="server">发布新产品</asp:HyperLink></div>
        <div class="right_search">
            &nbsp;&nbsp;产品名称:<asp:TextBox ID="txtName" runat="server"></asp:TextBox>&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click" />&nbsp;&nbsp;<asp:Button ID="btnShowAll" runat="server" Text="显示全部" OnClick="btnShowAll_Click" />
        </div>
        <div class="right_table">
            <asp:DataGrid ID="dgPro" runat="server" AutoGenerateColumns="false" Width="98%" DataKeyField="ProId" OnItemCommand="dgPro_ItemCommand" OnItemDataBound="dgPro_ItemDataBound">
                <Columns>
                    <asp:TemplateColumn HeaderText="序号">
                        <ItemTemplate>
                            <asp:Literal ID="ltlNo" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="状态">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnStatus" runat="server" CommandArgument='<%#Eval("ProId") %>' CommandName="status" Text='<%#Eval("IsShow") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="产品名称">
                        <ItemTemplate>
                            <a href="AddProduct.aspx?id=<%#Eval("ProId") %>" target="main"><%#Eval("Title") %></a>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="缩略图">
                        <ItemTemplate>
                            <a href="../<%#Eval("ImgUrl") %>" target="_blank"><img src="../<%#Eval("ImgUrl") %>" alt="" height="30" /></a>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="产品类型">
                        <ItemTemplate>
                            <asp:Literal ID="ltlProType" runat="server" Text='<%#Eval("TypeName") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="推荐">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnIndex" runat="server" CommandName="index" CommandArgument='<%#Eval("ProId") %>'></asp:LinkButton><asp:HiddenField ID="hfIndex" runat="server" Value='<%#Eval("IndexShow") %>' />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="操作">
                        <ItemTemplate>
                            <a href="AddProduct.aspx?id=<%#Eval("ProId") %>" target="main">修改</a>|
                            <asp:LinkButton ID="lbtnDel" runat="server" CommandName="del" CommandArgument='<%#Eval("ProId") %>' OnClientClick="return confirm('确定要删除吗？')">删除</asp:LinkButton>
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
