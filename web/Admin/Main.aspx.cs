using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using Tools;

namespace web.Admin
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Admin"] == null || Session["Admin"].ToString() == "")
                {
                    Response.Redirect("Index.aspx");                   
                }
                else {
                    List<Model.SiteInfo> list = SiteInfoBll.GetSiteInfo();
                    if (list.Count > 0)
                    {
                        ltlTitle.Text = list[0].SiteTitle + "-后台管理系统";
                    }
                }
            }
        }
    }
}