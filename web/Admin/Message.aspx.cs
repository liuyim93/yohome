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
    public partial class Message : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData() {
            string author = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string adr = txtAdress.Text.Trim();
            int read = Convert.ToInt32(dropStatus.SelectedValue);
            string time1 = txtTimer1.Value;
            string time2 = txtTimer2.Value;
            try
            {
               DataTable dt = MsgBll.getMsg(author,phone,email,adr,time1,time2,read);
               if (dt.Rows.Count > 0)
               {
                   AspNetPager1.RecordCount = dt.Rows.Count;
                   PagedDataSource pds = new PagedDataSource();
                   pds.DataSource = dt.DefaultView;
                   pds.PageSize = AspNetPager1.PageSize;
                   pds.AllowPaging = true;
                   pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                   dgMsg.DataSource = pds;
                   dgMsg.DataBind();
               }
               else {
                   dgMsg.DataSource = dt;
                   dgMsg.DataBind();
               }
            }
            catch (Exception)
            {
                DataTable dt = MsgBll.getAllMsg();
                if (dt.Rows.Count > 0)
                {
                    AspNetPager1.RecordCount = dt.Rows.Count;
                    PagedDataSource pds = new PagedDataSource();
                    pds.DataSource = dt.DefaultView;
                    pds.PageSize = AspNetPager1.PageSize;
                    pds.AllowPaging = true;
                    pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                    dgMsg.DataSource = pds;
                    dgMsg.DataBind();
                }
                else 
                {
                    dgMsg.DataSource = dt;
                    dgMsg.DataBind();
                }
                /*throw;*/
            }
        }

        protected void dgMsg_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName=="del")
            {
                int msgId = Convert.ToInt32(e.CommandArgument);
                try
                {
                    MsgBll.DeleteMsg(msgId);
                    MessageBox.Alert("删除成功！",Page);
                    BindData();
                }
                catch (Exception)
                {
                    MessageBox.Alert("删除失败！",Page);
                    /*throw;*/
                }
            }
        }

        protected void dgMsg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltlNo = e.Item.FindControl("ltlNo") as Literal;
                ltlNo.Text = (e.Item.ItemIndex + 1).ToString();
                Label status = e.Item.FindControl("lblStatus") as Label;
                if (status.Text == "1")
                {
                    status.Text = "已读";                    
                }
                else {
                    status.Text = "未读";
                    status.ForeColor = System.Drawing.Color.Red;
                }
                Literal time = e.Item.FindControl("ltlTime") as Literal;
                if (time.Text!="")
                {
                    time.Text = Convert.ToDateTime(time.Text).ToString("yyyy-MM-dd");
                }
            }
        }

        protected void btnShowAllMsg_Click(object sender, EventArgs e)
        {
            DataTable dt = MsgBll.getAllMsg();
            if (dt.Rows.Count > 0)
            {
                AspNetPager1.RecordCount = dt.Rows.Count;
                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dt.DefaultView;
                pds.PageSize = AspNetPager1.PageSize;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                dgMsg.DataSource = pds;
                dgMsg.DataBind();
            }
            else {
                dgMsg.DataSource = null;
                dgMsg.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                int selectNum = 0;
                for (int i = 0; i < dgMsg.Items.Count; i++)
                {
                    CheckBox chk = dgMsg.Items[i].FindControl("chkSelect") as CheckBox;
                    if (chk.Checked)
                    {
                        selectNum++;
                    }
                }
                if (selectNum == 0)
                {
                    for (int i = 0; i < dgMsg.Items.Count; i++)
                    {
                        CheckBox chk = dgMsg.Items[i].FindControl("chkSelect") as CheckBox;
                        chk.Checked = true;
                    }
                }
                else
                {
                    for (int i = 0; i < dgMsg.Items.Count; i++)
                    {
                        CheckBox chk = dgMsg.Items[i].FindControl("chkSelect") as CheckBox;
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
                for (int i = 0; i < dgMsg.Items.Count; i++)
                {
                    CheckBox chk = dgMsg.Items[i].FindControl("chkSelect") as CheckBox;
                    chk.Checked = false;
                }
            }
        }

        protected void btnDelSelect_Click(object sender, EventArgs e)
        {
            int selectNum = 0;
            for (int i = 0; i < dgMsg.Items.Count; i++)
            {
                CheckBox chk = dgMsg.Items[i].FindControl("chkSelect") as CheckBox;
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
                for (int i = 0; i < dgMsg.Items.Count; i++)
                {
                    CheckBox chk = dgMsg.Items[i].FindControl("chkSelect") as CheckBox;
                    if (chk.Checked)
                    {
                        int sId = Convert.ToInt32(dgMsg.DataKeys[i]);
                        try
                        {
                            MsgBll.DeleteMsg(sId);
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

    }
}