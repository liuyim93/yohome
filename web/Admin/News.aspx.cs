using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using Tools;
using System.Data;

namespace web.Admin
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDrop();
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    string title = "";
                    int status = 2;
                    int type = Convert.ToInt32(Request.QueryString["id"]);
                    dropNewsType.SelectedValue = type.ToString();
                    DataTable dt = NewsBll.getNews(title,status,type);
                    if (dt.Rows.Count > 0)
                    {
                        AspNetPager1.RecordCount = dt.Rows.Count;
                        PagedDataSource pds = new PagedDataSource();
                        pds.DataSource = dt.DefaultView;
                        pds.PageSize = AspNetPager1.PageSize;
                        pds.AllowPaging = true;
                        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                        dgNews.DataSource = pds;
                        dgNews.DataBind();
                    }
                    else
                    {
                        dgNews.DataSource = null;
                        dgNews.DataBind();
                    }
                }
                else {
                    BindData();
                }
            }
        }


        public void BindDrop() {
            dropNewsType.DataSource = NewsTypeBll.GetAllNewsType();
            dropNewsType.DataTextField = "TypeName";
            dropNewsType.DataValueField = "NewsTypeId";
            dropNewsType.DataBind();
            dropNewsType.Items.Insert(0,"显示全部");
        }
        public void BindData() {
            string title = txtTitle.Text.Trim();
            int status = Convert.ToInt32(dropStatus.SelectedValue);
            int type = 0;
            if (dropNewsType.SelectedItem.Text!="显示全部")
            {
                type = Convert.ToInt32(dropNewsType.SelectedValue);
            }
            DataTable dt = NewsBll.getNews(title,status,type);
            if (dt.Rows.Count > 0)
            {
                AspNetPager1.RecordCount = dt.Rows.Count;
                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dt.DefaultView;
                pds.PageSize = AspNetPager1.PageSize;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                dgNews.DataSource = pds;
                dgNews.DataBind();
            }
            else {
                dgNews.DataSource = null;
                dgNews.DataBind();
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnDelSelect_Click(object sender, EventArgs e)
        {
            int selectNum = 0;
            for (int i = 0; i < dgNews.Items.Count; i++)
            {
                CheckBox chk = dgNews.Items[i].FindControl("chkSelect") as CheckBox;
                if (chk.Checked)
                {
                    selectNum++;
                }
            }
            if (selectNum == 0)
            {
                MessageBox.Alert("请选择要删除的项！", Page);
            }
            else
            {
                for (int i = 0; i < dgNews.Items.Count; i++)
                {
                    CheckBox chk = dgNews.Items[i].FindControl("chkSelect") as CheckBox;
                    if (chk.Checked)
                    {
                        int sId = Convert.ToInt32(dgNews.DataKeys[i]);
                        try
                        {
                            NewsBll.DeleteNews(sId);
                        }
                        catch (Exception)
                        {
                            MessageBox.Alert("删除失败！", Page);
                            break;
                        }
                    }
                }
            }
            BindData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            dropStatus.SelectedIndex = 0;
            dropStatus.SelectedIndex = 0;
            DataTable dt = NewsBll.getAllNews();
            if (dt.Rows.Count > 0)
            {
                AspNetPager1.RecordCount = dt.Rows.Count;
                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dt.DefaultView;
                pds.PageSize = AspNetPager1.PageSize;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                dgNews.DataSource = pds;
                dgNews.DataBind();
            }
            else
            {
                dgNews.DataSource = null;
                dgNews.DataBind();
            }
        }

        protected void dgNews_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            switch (e.CommandName.ToLower())
            {
                case "status":
                    int newsId = Convert.ToInt32(e.CommandArgument);
                    List<Model.News> list = NewsBll.GetNewsbyId(newsId);
                    if (list.Count>0)
                    {
                        if (list[0].IsShow == 0)
                        {
                            try
                            {
                                NewsBll.UpdateStatus(newsId, 1);
                                BindData();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Alert("未知错误：" + ex, Page);
                                /*throw;*/
                            }
                        }
                        else 
                        {
                            try
                            {
                                NewsBll.UpdateStatus(newsId,0);
                                BindData();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Alert("未知错误："+ex,Page);
                                /*throw;*/
                            }
                        }
                    }
                    break;
                case "top":
                    int newsId1 = Convert.ToInt32(e.CommandArgument);
                     List<Model.News> list1 = NewsBll.GetNewsbyId(newsId1);
                    if (list1.Count>0)
                    {
                        if (list1[0].IsTop == 0)
                        {
                            try
                            {
                                NewsBll.UpdateTop(newsId1, 1);
                                BindData();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Alert("未知错误：" + ex, Page);
                                /*throw;*/
                            }
                        }
                        else 
                        {
                            try
                            {
                                NewsBll.UpdateTop(newsId1, 0);
                                BindData();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Alert("未知错误："+ex,Page);
                                /*throw;*/
                            }
                        }
                    }
                    break;
                case "index":
                     int newsId2 = Convert.ToInt32(e.CommandArgument);
                     List<Model.News> list2 = NewsBll.GetNewsbyId(newsId2);
                    if (list2.Count>0)
                    {
                        if (list2[0].IndexShow == 0)
                        {
                            try
                            {
                                NewsBll.UpdateIndex(newsId2, 1);
                                BindData();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Alert("未知错误：" + ex, Page);
                                /*throw;*/
                            }
                        }
                        else 
                        {
                            try
                            {
                                NewsBll.UpdateIndex(newsId2, 0);
                                BindData();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Alert("未知错误："+ex,Page);
                                /*throw;*/
                            }
                        }
                    }
                    break;
                case "del":
                    int id = Convert.ToInt32(e.CommandArgument);
                    try
                    {
                        NewsBll.DeleteNews(id);
                        MessageBox.Alert("删除成功！",Page);
                        BindData();
                    }
                    catch (Exception)
                    {
                        MessageBox.Alert("删除失败！",Page);
                        /*throw;*/
                    }
                    break;
                default:
                    break;
            }
        }

        protected void dgNews_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType==ListItemType.Item||e.Item.ItemType==ListItemType.AlternatingItem)
            {
                Literal ltlNo = e.Item.FindControl("ltlNo") as Literal;
                ltlNo.Text = (e.Item.ItemIndex + 1).ToString();
                LinkButton status = e.Item.FindControl("lbtnStatus") as LinkButton;
                if (status.Text == "1")
                {
                    status.Text = "已发布";
                }
                else {
                    status.Text = "未发布";
                    status.ForeColor = System.Drawing.Color.Red;
                }
                LinkButton top = e.Item.FindControl("lbtnTop") as LinkButton;
                HiddenField hfTop = e.Item.FindControl("hfTop") as HiddenField;
                if (hfTop.Value=="1")
                {
                    top.ForeColor = System.Drawing.Color.Red;
                }
                else {
                    top.ForeColor = System.Drawing.Color.Gray;
                }
                top.Text = "顶";
                LinkButton index = e.Item.FindControl("lbtnIndex") as LinkButton;
                HiddenField hfIndex = e.Item.FindControl("hfIndex") as HiddenField;
                if (hfIndex.Value == "1")
                {
                    index.ForeColor = System.Drawing.Color.Red;
                }
                else {
                    index.ForeColor = System.Drawing.Color.Gray;
                }
                index.Text = "荐";
            }
        }

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                int selectNum = 0;
                for (int i = 0; i < dgNews.Items.Count; i++)
                {
                    CheckBox chk = dgNews.Items[i].FindControl("chkSelect") as CheckBox;
                    if (chk.Checked)
                    {
                        selectNum++;
                    }
                }
                if (selectNum == 0)
                {
                    for (int i = 0; i < dgNews.Items.Count; i++)
                    {
                        CheckBox chk = dgNews.Items[i].FindControl("chkSelect") as CheckBox;
                        chk.Checked = true;
                    }
                }
                else
                {
                    for (int i = 0; i < dgNews.Items.Count; i++)
                    {
                        CheckBox chk = dgNews.Items[i].FindControl("chkSelect") as CheckBox;
                        if (chk.Checked)
                        {
                            chk.Checked = false;
                        }
                        else
                        {
                            chk.Checked = true;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < dgNews.Items.Count; i++)
                {
                    CheckBox chk = dgNews.Items[i].FindControl("chkSelect") as CheckBox;
                    chk.Checked = false;
                }
            }
        }
    }
}