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
    public partial class AddImg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["typeId"] != null && Request.QueryString["typeId"] != "")
                {
                    int imgTypeId = Convert.ToInt32(Request.QueryString["typeId"]);
                    hfTypeId.Value = imgTypeId.ToString();
                    hlnkList.NavigateUrl = "Img.aspx?typeId=" + imgTypeId;
                    txtTimer.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    List<ImgType> list = ImgTypeBll.GetImgTypebyId(imgTypeId);
                    if (list.Count > 0)
                    {
                        lblType.Text = list[0].TypeName;
                        ltlTitle.Text = "添加"+list[0].TypeName;
                        hlnkList.Text="查看"+list[0].TypeName+"列表";
                    }
                    else {
                        lblType.Text = "";
                        ltlTitle.Text = "添加图片";
                        hlnkList.Text = "查看图片列表";
                    }                    
                }
                else if(Request.QueryString["id"]!=null&&Request.QueryString["id"]!=""){
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    hfId.Value = id.ToString();
                    List<Model.Img> list = ImgBll.GetImgbyId(id);
                    if (list.Count>0)
                    {
                        txtTitle.Text=list[0].Title;
                        txtImg.Text=list[0].ImgUrl;
                        txtLink.Text=list[0].LinkUrl;
                        txtRank.Text=list[0].Rank.ToString();
                        txtTimer.Value=list[0].CreateTime;                        
                        chkShow.Checked = Convert.ToBoolean(list[0].IsShow);
                        List<ImgType> list_imgType = ImgTypeBll.GetImgTypebyId(list[0].ImgTypeId);
                        if (list_imgType.Count > 0)
                        {
                            lblType.Text = list_imgType[0].TypeName;
                            ltlTitle.Text = "添加" + list_imgType[0].TypeName;
                            hlnkList.Text = "查看" + list_imgType[0].TypeName + "列表";
                        }
                        else {
                            lblType.Text = "";
                        }
                        hlnkList.NavigateUrl = "Img.aspx?typeId=" + list[0].ImgTypeId;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Model.Img img= new Model.Img();
            if (txtTitle.Text == "")
            {
                MessageBox.Alert("标题不能为空！", Page);
                txtTitle.Focus();
            }
            else if (hfId.Value == "" && hfTypeId.Value == "")
            {
                Response.Redirect("right.aspx");
            }
            else{
                img.Title = txtTitle.Text.Trim();
                img.IsShow = Convert.ToInt32(chkShow.Checked);
                img.LinkUrl = txtLink.Text;
                img.Remark = "";
                if (txtTimer.Value == "")
                {
                    img.CreateTime = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else {
                    img.CreateTime = txtTimer.Value;
                }
                if (txtRank.Text == "")
                {
                    img.Rank = 0;
                }
                else {
                    try
                    {
                        img.Rank=Convert.ToInt32(txtRank.Text);
                    }
                    catch (Exception)
                    {
                        img.Rank = 0;
                        /*throw;*/
                    } 
                }                
                //判断缩略图的值
                if (txtImg.Text == "" && hfImgUrl.Value == "")
                {
                    img.ImgUrl = "";
                }
                else if (txtImg.Text != "" && hfImgUrl.Value == "")
                {
                    img.ImgUrl = txtImg.Text;
                }
                else if (txtImg.Text == "" && hfImgUrl.Value != "")
                {
                    img.ImgUrl = hfImgUrl.Value;
                }
                else if (txtImg.Text != hfImgUrl.Value)
                {
                    img.ImgUrl = hfImgUrl.Value;
                }
                else
                {
                    img.ImgUrl = txtImg.Text;
                }
                if (hfTypeId.Value != "")
                {
                    img.ImgTypeId = Convert.ToInt32(hfTypeId.Value);
                    try
                    {
                        ImgBll.AddImg(img);
                        MessageBox.AlertAndRedirect("添加成功！", "Img.aspx?typeId=" + img.ImgTypeId, Page);
                    }
                    catch (Exception)
                    {
                        MessageBox.Alert("添加失败！", Page);
                        /*throw;*/
                    }
                }
                else if(hfId.Value!=""){
                    img.ImgId = Convert.ToInt32(hfId.Value);
                    List<Model.Img> list = ImgBll.GetImgbyId(img.ImgId);
                    if (list.Count>0)
                    {
                        img.ImgTypeId=list[0].ImgTypeId;
                        try
                        {
                            ImgBll.UpdateImg(img);
                            MessageBox.AlertAndRedirect("修改成功！", "Img.aspx?typeId=" + img.ImgTypeId, Page);
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