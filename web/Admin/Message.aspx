<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="web.Admin.Message" %>
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
        <div class="right_title">留言管理</div>
        <div class="right_main bg_color"><b>留言管理</b></div>
        <div class="right_search">姓名：<asp:TextBox ID="txtName" runat="server" CssClass="searchtxt"></asp:TextBox>&nbsp;&nbsp;电话：<asp:TextBox ID="txtPhone" runat="server" CssClass="searchtxt"></asp:TextBox>&nbsp;&nbsp;Email：<asp:TextBox ID="txtEmail" runat="server" CssClass="searchtxt"></asp:TextBox>&nbsp;&nbsp;店址：<asp:TextBox ID="txtAdress" runat="server" CssClass="searchtxt"></asp:TextBox><br />
            状态：<asp:DropDownList ID="dropStatus" runat="server" Width="60">
                        <asp:ListItem Text="全部" Value="2"></asp:ListItem>        
                        <asp:ListItem Text="未读" Value="0"></asp:ListItem>
                        <asp:ListItem Text="已读" Value="1"></asp:ListItem>
                  </asp:DropDownList>&nbsp;&nbsp;  
            留言时间：<input type="text" id="txtTimer1" runat="server" onclick="WdatePicker()" class="searchtxt" />—<input type="text" id="txtTimer2" runat="server" onclick="WdatePicker()" class="searchtxt" />&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click" />&nbsp;&nbsp;<asp:Button ID="btnShowAllMsg" runat="server" Text="显示全部" OnClick="btnShowAllMsg_Click" />
        </div>
        <div class="right_table">
        <asp:DataGrid ID="dgMsg" runat="server" AutoGenerateColumns="false" Width="98%" OnItemCommand="dgMsg_ItemCommand" OnItemDataBound="dgMsg_ItemDataBound" DataKeyField="MsgId">
            <Columns>
                <asp:TemplateColumn HeaderText="序号" HeaderStyle-CssClass="table_th" ItemStyle-Width="4%">
                    <ItemTemplate>
                        <asp:Literal ID="ltlNo" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="留言人">
                    <ItemTemplate>
                        <asp:Literal ID="ltlName" runat="server" Text='<%#Eval("Author") %>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="留言内容">
                    <ItemTemplate>
                        <asp:Literal ID="ltlMsg" runat="server" Text='<%#Eval("Details").ToString().Length>100?Eval("Details").ToString().Substring(0,100)+"...":Eval("Details") %>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="手机">
                    <ItemTemplate>
                        <asp:Literal ID="ltlPhone" runat="server" Text='<%#Eval("Phone") %>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="电子邮箱">
                    <ItemTemplate>
                        <asp:Literal ID="ltlEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="店址">
                    <ItemTemplate>
                        <asp:Literal ID="ltlAdress" runat="server" Text='<%#Eval("Adress") %>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="留言时间">
                    <ItemTemplate>
                        <asp:Literal ID="ltlTime" runat="server" Text='<%#Eval("CreateTime") %>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="状态">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("IsRead") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="操作">
                    <ItemTemplate>
                        <a href="MessageDetail.aspx?id=<%#Eval("MsgId") %>" target="main">查看</a>|<asp:LinkButton ID="lbtnDel" runat="server" OnClientClick='return confirm("确定要删除吗？");' CommandArgument='<%#Eval("MsgId") %>' CommandName="del" >删除</asp:LinkButton>
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
            <tr>
                <td><asp:CheckBox ID="chkSelectAll" runat="server" OnCheckedChanged="chkSelectAll_CheckedChanged" AutoPostBack="true" />全选/反选&nbsp;&nbsp;<asp:Button ID="btnDelSelect" runat="server" Text="批量删除" OnClick="btnDelSelect_Click" OnClientClick='return confirm("确定要删除吗？")' /></td>
                <td style="text-align:right;padding-right:10px;"><Webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="paginator" CurrentPageButtonClass="cpb"
                         LastPageText="尾页" FirstPageText="首页" PrevPageText="上一页" NextPageText="下一页" 
                            AlwaysShow="true" UrlPaging="true" PageSize="10" OnPageChanged="AspNetPager1_PageChanged" 
                            ></Webdiyer:AspNetPager></td>
            </tr>
        </table>        
        </div>
    </form>
</body>
</html>
