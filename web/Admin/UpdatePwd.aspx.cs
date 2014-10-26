using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using Model;
using Tools;
using System.Web.Security;

namespace web.Admin
{
    public partial class UpdatePwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminId"]==null||Session["AdminId"]=="")
            {
                Response.Redirect("right.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtpwd.Text == "")
            {
                MessageBox.Alert("原密码不能为空！", Page);
                txtpwd.Focus();
            }
            else if (txtNewPwd.Text == "")
            {
                MessageBox.Alert("请输入新密码！", Page);
                txtNewPwd.Focus();
            }
            else if (txtNewPwd.Text.Trim() != txtPwd1.Text.Trim())
            {
                MessageBox.Alert("新密码不一致！", Page);
                txtNewPwd.Focus();
            }
            else if (txtNewPwd.Text.Length < 6)
            {
                MessageBox.Alert("密码长度不能小于6个字符！", Page);
                txtNewPwd.Focus();
            }
            else {
                int adminId=Convert.ToInt32(Session["AdminId"]);
                string pwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtpwd.Text.Trim(),"md5");
                string newPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtNewPwd.Text.Trim(),"md5");
                List<Model.Admin> list = AdminBll.GetAdmin(adminId);
                if (list.Count>0)
                {
                    if (pwd != list[0].Password)
                    {
                        MessageBox.Alert("原密码错误！", Page);
                        txtpwd.Focus();
                    }
                    else {
                        try
                        {
                            AdminBll.UpdatePwd(adminId,newPwd);
                            MessageBox.Alert("修改成功！",Page);
                        }
                        catch (Exception)
                        {
                            MessageBox.Alert("修改失败！",Page);
                        }
                    }
                }
            }
        }
    }
}