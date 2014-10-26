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
    public partial class Banner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["typeId"] == null || Request.QueryString["typeId"] == "")
                {
                    Response.Redirect("right.aspx");
                }
                else {
                    int imgTypeId = Convert.ToInt32(Request.QueryString["typeId"]);
                    hfTypeId.Value = imgTypeId.ToString();
                    List<ImgType> list = ImgTypeBll.GetImgTypebyId(imgTypeId);
                    if (list.Count>0)
                    {
                        ltlTitle.Text=list[0].TypeName+"管理";
                    }
                    hlnkAdd.NavigateUrl = "AddImg.aspx?typeId=" + imgTypeId;
                    BindData();
                }
            }
        }

        public void BindData() {
            int typeId = Convert.ToInt32(hfTypeId.Value);
            DataTable dt = ImgBll.getImgbytypeId(typeId);
            if (dt.Rows.Count > 0)
            {
                AspNetPager1.RecordCount = dt.Rows.Count;
                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dt.DefaultView;
                pds.PageSize = AspNetPager1.PageSize;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                dgBanner.DataSource = pds;
                dgBanner.DataBind();
            }
            else
            {
                dgBanner.DataSource = null;
                dgBanner.DataBind();
            }
        }

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                int selectNum = 0;
                for (int i = 0; i < dgBanner.Items.Count; i++)
                {
                    CheckBox chk = dgBanner.Items[i].FindControl("chkSelect") as CheckBox;
                    if (chk.Checked)
                    {
                        selectNum++;
                    }
                }
                if (selectNum == 0)
                {
                    for (int i = 0; i < dgBanner.Items.Count; i++)
                    {
                        CheckBox chk = dgBanner.Items[i].FindControl("chkSelect") as CheckBox;
                        chk.Checked = true;
                    }
                }
                else
                {
                    for (int i = 0; i < dgBanner.Items.Count; i++)
                    {
                        CheckBox chk = dgBanner.Items[i].FindControl("chkSelect") as CheckBox;
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
                for (int i = 0; i < dgBanner.Items.Count; i++)
                {
                    CheckBox chk = dgBanner.Items[i].FindControl("chkSelect") as CheckBox;
                    chk.Checked = false;
                }
            }
        }

        protected void btnDelSelect_Click(object sender, EventArgs e)
        {
            int selectNum = 0;
            for (int i = 0; i < dgBanner.Items.Count; i++)
            {
                CheckBox chk = dgBanner.Items[i].FindControl("chkSelect") as CheckBox;
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
                for (int i = 0; i < dgBanner.Items.Count; i++)
                {
                    CheckBox chk = dgBanner.Items[i].FindControl("chkSelect") as CheckBox;
                    if (chk.Checked)
                    {
                        int sId = Convert.ToInt32(dgBanner.DataKeys[i]);
                        try
                        {
                            ImgBll.DeleteImg(sId);
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

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void dgBanner_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "status")
            {
                int imgId = Convert.ToInt32(e.CommandArgument);
                List<Model.Img> list = ImgBll.GetImgbyId(imgId);
                if (list.Count > 0)
                {
                    int status = 0;
                    if (list[0].IsShow == 0)
                    {
                        status = 1;
                    }
                    else
                    {
                        status = 0;
                    }
                    try
                    {
                        ImgBll.UpdateStatus(imgId, status);
                        BindData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Alert("未知错误：" + ex, Page);
                        /*throw;*/
                    }
                }
            }
            else if(e.CommandName.ToLower()=="del"){
                int id = Convert.ToInt32(e.CommandArgument);
                try
                {
                    ImgBll.DeleteImg(id);
                    MessageBox.Alert("删除成功！", Page);
                    BindData();
                }
                catch (Exception)
                {
                    MessageBox.Alert("删除失败！", Page);
                    /*throw;*/
                }
            }
        }

        protected void dgBanner_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType==ListItemType.AlternatingItem||e.Item.ItemType==ListItemType.Item)
            {
                LinkButton status = e.Item.FindControl("lbtnStatus") as LinkButton;
                if (status.Text == "1")
                {
                    status.Text = "已发布";
                }
                else {
                    status.Text = "未发布";
                    status.ForeColor = System.Drawing.Color.Red;
                }

                Literal ltlNo = e.Item.FindControl("ltlNo") as Literal;
                ltlNo.Text = (e.Item.ItemIndex + 1).ToString();
            }
        }
    }
}