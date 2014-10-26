using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using Tools;
using System.Web.Security;

namespace web.Admin
{
    public partial class Admin_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
                List<Model.SiteInfo> list = SiteInfoBll.GetSiteInfo();
                if (list.Count>0)
                {
                    ltlTitle.Text = list[0].SiteTitle+"后台管理系统登陆";
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPwd.Text.Trim(),"md5");
            string checkCode = txtCodeImage.Text.Trim();
            if (userName == "")
            {
                MessageBox.Alert("用户名不能为空！", Page);
                txtUserName.Focus();
            }
            else if (pwd == "")
            {
                MessageBox.Alert("密码不能为空！", Page);
                txtPwd.Focus();
            }
            else if (checkCode.ToLower() != Session["CheckCode"].ToString().ToLower())
            {
                MessageBox.Alert("验证码错误！", Page);
                txtCodeImage.Text = "";
                txtCodeImage.Focus();
            }
            else{
                List<Model.Admin>list=AdminBll.AdminLogin(userName,pwd);
                if (list.Count > 0)
                {
                    Session["AdminName"]=userName;
                    Session["AdminId"]=list[0].AdminId;
                    Session["Admin"]=list[0];
                    Response.Redirect("Main.aspx");
                }
                else {
                    MessageBox.Alert("用户名或密码错误！",Page);
                }
            }
        }
     
    }
}