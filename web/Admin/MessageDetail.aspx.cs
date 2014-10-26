using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;
using Tools;

namespace web.Admin
{
    public partial class MessageDetail : System.Web.UI.Page
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
                int msgId = Convert.ToInt32(Request.QueryString["id"]);
                List<Msg> list = MsgBll.GetMsgbyId(msgId);
                if (list.Count > 0)
                {
                    lblName.Text = list[0].Author;
                    lblPhone.Text = list[0].Phone;
                    lblEmail.Text = list[0].Email;
                    lblAdr.Text = list[0].Adress;
                    lblTime.Text = list[0].CreateTime;
                    lblDetail.Text = list[0].Details;
                    if (list[0].IsRead==0)
                    {
                        try
                        {
                            MsgBll.UpdateRead(msgId,1);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Alert("未知错误:"+ex.Message,Page);
                            /*throw;*/
                        }
                    }
                }
                else {
                    Response.Redirect("Message.aspx");
                }
            }
        }

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Message.aspx");
        }
    }
}