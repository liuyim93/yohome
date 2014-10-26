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
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["typeId"] == "" || Request.QueryString["typeId"] == null)
                {
                    Response.Redirect("right.aspx");
                }
                else {
                    int proTypeId = Convert.ToInt32(Request.QueryString["typeId"]);
                    hfTypeId.Value = proTypeId.ToString();
                    hlnkAdd.NavigateUrl = "AddProduct.aspx?typeId="+proTypeId;
                    BindData();
                }
            }
        }

        public void BindData() {
            string title = txtName.Text.Trim();
            int typeId = Convert.ToInt32(hfTypeId.Value);
            DataTable dt = ProductBll.getProduct(title,typeId);
            if (dt.Rows.Count > 0)
            {
                AspNetPager1.RecordCount = dt.Rows.Count;
                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dt.DefaultView;
                pds.PageSize = AspNetPager1.PageSize;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                dgPro.DataSource = pds;
                dgPro.DataBind();
            }
            else {
                dgPro.DataSource = null;
                dgPro.DataBind();
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            BindData();
        }

        protected void dgPro_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            switch (e.CommandName.ToLower())
            {
                case "status":
                    int proId = Convert.ToInt32(e.CommandArgument);
                    List<Model.Product> list = ProductBll.GetProductbyId(proId);
                    if (list.Count>0)
                    {
                        int status = 0;
                        if (list[0].IsShow == 1)
                        {
                            status = 0;
                        }
                        else {
                            status = 1;
                        }
                        try
                        {
                            ProductBll.UpdateStatus(proId,status);
                            BindData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Alert("未知错误：" + ex, Page);
                            /*throw;*/
                        }
                    }
                    break;
                case "index":
                    int proId1 = Convert.ToInt32(e.CommandArgument);
                    List<Model.Product> list1 = ProductBll.GetProductbyId(proId1);
                    if (list1.Count>0)
                    {
                        int status1 = 0;
                        if (list1[0].IndexShow == 1)
                        {
                            status1 = 0;
                        }
                        else {
                            status1 = 1;
                        }
                        try
                        {
                            ProductBll.UpdateIndex(proId1,status1);
                            BindData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Alert("未知错误：" + ex, Page);
                            /*throw;*/
                        }
                    }
                    break;
                case "del":
                    int id = Convert.ToInt32(e.CommandArgument);
                    try
                    {
                        ProductBll.DeleteProduct(id);
                        MessageBox.Alert("删除成功！",Page);
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

        protected void dgPro_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType==ListItemType.Item||e.Item.ItemType==ListItemType.AlternatingItem)
            {
                Literal ltlNo = e.Item.FindControl("ltlNo") as Literal;
                ltlNo.Text = (e.Item.ItemIndex + 1).ToString();

                HiddenField index = e.Item.FindControl("hfIndex") as HiddenField;
                LinkButton lbtnIndex = e.Item.FindControl("lbtnIndex") as LinkButton;
                lbtnIndex.Text = "推荐";
                if (index.Value == "1")
                {
                    lbtnIndex.ForeColor = System.Drawing.Color.Red;
                }
                else {
                    lbtnIndex.ForeColor = System.Drawing.Color.Gray;
                }

                LinkButton status = e.Item.FindControl("lbtnStatus") as LinkButton;
                if (status.Text == "1")
                {
                    status.Text = "已发布";
                }
                else {
                    status.Text = "未发布";
                    status.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void btnDelSelect_Click(object sender, EventArgs e)
        {
            int selectNum = 0;
            for (int i = 0; i < dgPro.Items.Count; i++)
            {
                CheckBox chk = dgPro.Items[i].FindControl("chkSelect") as CheckBox;
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
                for (int i = 0; i < dgPro.Items.Count; i++)
                {
                    CheckBox chk = dgPro.Items[i].FindControl("chkSelect") as CheckBox;
                    if (chk.Checked)
                    {
                        int sId = Convert.ToInt32(dgPro.DataKeys[i]);
                        try
                        {
                            ProductBll.DeleteProduct(sId);
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

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                int selectNum = 0;
                for (int i = 0; i < dgPro.Items.Count; i++)
                {
                    CheckBox chk = dgPro.Items[i].FindControl("chkSelect") as CheckBox;
                    if (chk.Checked)
                    {
                        selectNum++;
                    }
                }
                if (selectNum == 0)
                {
                    for (int i = 0; i < dgPro.Items.Count; i++)
                    {
                        CheckBox chk = dgPro.Items[i].FindControl("chkSelect") as CheckBox;
                        chk.Checked = true;
                    }
                }
                else
                {
                    for (int i = 0; i < dgPro.Items.Count; i++)
                    {
                        CheckBox chk = dgPro.Items[i].FindControl("chkSelect") as CheckBox;
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
                for (int i = 0; i < dgPro.Items.Count; i++)
                {
                    CheckBox chk = dgPro.Items[i].FindControl("chkSelect") as CheckBox;
                    chk.Checked = false;
                }
            }
        }
    }
}