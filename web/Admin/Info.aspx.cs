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
    public partial class Info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData() {
            if (Request.QueryString["id"]!=""&&Request.QueryString["id"]!=null)
            {
                int infoId = Convert.ToInt32(Request.QueryString["id"]);
                List<Model.Info> list = InfoBll.GetInfobyId(infoId);
                if (list.Count > 0)
                {
                    ltlTitle.Text = list[0].TypeName;
                    fck_detail.Value = list[0].Details;
                }
                else 
                {
                    MessageBox.AlertAndRedirect("您查找的内容不存在！","right.aspx",Page);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int infoId = Convert.ToInt32(Request.QueryString["id"]);
            string detail = fck_detail.Value;
            try
            {
                InfoBll.UpdateDetail(infoId,detail);
                BindData();
                MessageBox.Alert("保存成功！",Page);
            }
            catch (Exception ex)
            {
                MessageBox.Alert("错误："+ex,Page);
                /*throw;*/
            }
        }
    }
}