using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using Model;
using Tools;

namespace web.Admin
{
    public partial class AddNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindType();
                txtTimer.Value = DateTime.Now.ToString("yyyy-MM-dd");
                if (Request.QueryString["typeId"] != null && Request.QueryString["typeId"] != "")
                {
                    int typeId = Convert.ToInt32(Request.QueryString["typeId"]);
                    List<NewsType> list = NewsTypeBll.GetNewsTypebyId(typeId);
                    if (list.Count > 0)
                    {
                        dropType.SelectedValue = Request.QueryString["typeId"];
                    }
                }
                else {
                    if (Request.QueryString["id"]!=""&&Request.QueryString["id"]!=null)
                    {
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        List<Model.News> list = NewsBll.GetNewsbyId(id);
                        if (list.Count>0)
                        {
                            txtTitle.Text=list[0].Title;
                            txtTimer.Value=list[0].CreateTime;
                            txtImgUrl.Text=list[0].ImgUrl;
                            dropType.SelectedValue=list[0].NewsTypeId.ToString();
                            fck_intro.Value=list[0].Intro;
                            fck_detail.Value=list[0].Details;
                            chkShow.Checked=Convert.ToBoolean(list[0].IsShow);
                            chkTop.Checked = Convert.ToBoolean(list[0].IsTop);
                            chkIndex.Checked = Convert.ToBoolean(list[0].IndexShow);
                            hfId.Value = id.ToString();
                        }
                    }
                }
            }
        }

        public void BindType() {
            dropType.DataSource = NewsTypeBll.GetAllNewsType();
            dropType.DataTextField = "TypeName";
            dropType.DataValueField = "NewsTypeId";
            dropType.DataBind();
            dropType.Items.Insert(0,"--请选择新闻类型--");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Model.News news = new Model.News();
            if (txtTitle.Text == "")
            {
                MessageBox.Alert("标题不能为空!", Page);
                txtTitle.Focus();
            }
            else {
                if (dropType.SelectedItem.Text == "--请选择新闻类型--")
                {
                    MessageBox.Alert("请选择新闻类型！",Page);
                    dropType.Focus();
                }
                else {
                    news.NewsTypeId = Convert.ToInt32(dropType.SelectedValue);
                    if (txtTimer.Value == "")
                    {
                        news.CreateTime = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                    else {
                        news.CreateTime = txtTimer.Value;
                    }
                    if (hfImgUrl.Value == "")
                    {
                        news.ImgUrl = txtImgUrl.Text.Trim();
                    }
                    else {
                        news.ImgUrl = hfImgUrl.Value;
                    }
                    news.Title = txtTitle.Text;                                      
                    news.Intro = fck_intro.Value;
                    news.Details = fck_detail.Value;
                    news.IsShow = Convert.ToInt32(chkShow.Checked);
                    news.IsTop = Convert.ToInt32(chkTop.Checked);
                    news.IndexShow = Convert.ToInt32(chkIndex.Checked);
                    if (hfId.Value == "" || hfId.Value == null)
                    {
                        try
                        {
                            NewsBll.AddNews(news);
                            MessageBox.AlertAndRedirect("添加成功！", "News.aspx", Page);
                        }
                        catch (Exception)
                        {
                            MessageBox.Alert("添加失败！", Page);
                            /*throw;*/
                        }
                    }
                    else {
                        news.NewsId = Convert.ToInt32(hfId.Value);
                        try
                        {
                            NewsBll.UpdateNews(news);
                            MessageBox.AlertAndRedirect("修改成功！","News.aspx",Page);
                        }
                        catch (Exception)
                        {
                            MessageBox.Alert("修改失败！",Page);
                            /*throw;*/
                        }
                    }
                }
            }
        }
    }
}