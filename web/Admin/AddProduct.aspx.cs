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
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["typeId"] != null && Request.QueryString["typeId"] != "")
                {
                    int proTypeId = Convert.ToInt32(Request.QueryString["typeId"]);
                    List<Model.ProductType> list = ProductTypeBll.GetProductType(proTypeId);
                    if (list.Count > 0)
                    {
                        lblType.Text = list[0].TypeName;
                        hftypeId.Value = proTypeId.ToString();
                        hlnkPro.NavigateUrl = "Product.aspx?typeId=" + hftypeId.Value;
                        txtTimer.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                }
                else if(Request.QueryString["id"]!=null&&Request.QueryString["id"]!=""){
                    int proId = Convert.ToInt32(Request.QueryString["id"]);
                    hfId.Value = proId.ToString();
                    List<Model.Product> list = ProductBll.GetProductbyId(proId);
                    if (list.Count>0)
                    {
                        txtTitle.Text=list[0].Title;
                        txtTimer.Value=list[0].CreateTime;
                        txtImg.Text=list[0].ImgUrl;                       
                        txtBigImg.Text=list[0].BigImgUrl;                       
                        fck_intro.Value=list[0].Intro;
                        fck_detail.Value=list[0].Details;
                        chkIndex.Checked = Convert.ToBoolean(list[0].IndexShow);
                        chkShow.Checked = Convert.ToBoolean(list[0].IsShow);
                        List<ProductType> list_proType = ProductTypeBll.GetProductType(list[0].ProTypeId);
                        if (list_proType.Count > 0)
                        {
                            lblType.Text = list_proType[0].TypeName;
                        }
                        else {
                            lblType.Text = "";
                        }
                        hlnkPro.NavigateUrl="Product.aspx?typeId="+list[0].ProTypeId;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Model.Product pro = new Model.Product();
            if (txtTitle.Text == "")
            {
                MessageBox.Alert("产品名称不能为空！", Page);
                txtTitle.Focus();
            }
            else if (hfId.Value == "" && hftypeId.Value == "")
            {
                Response.Redirect("right.aspx");
            }
            else {               
                pro.Title = txtTitle.Text;
                pro.IsShow = Convert.ToInt32(chkShow.Checked);
                pro.IndexShow = Convert.ToInt32(chkIndex.Checked);
                pro.Intro = fck_intro.Value;
                pro.Details = fck_detail.Value;
                if (txtTimer.Value == "")
                {
                    pro.CreateTime = DateTime.Now.ToString("yyy-MM-dd");
                }
                else
                {
                    pro.CreateTime = txtTimer.Value;
                }
                //判断缩略图的值
                if (txtImg.Text == "" && hfImgUrl1.Value == "")
                {
                    pro.ImgUrl = "";
                }
                else if (txtImg.Text != "" && hfImgUrl1.Value == "")
                {
                    pro.ImgUrl = txtImg.Text;
                }
                else if (txtImg.Text == "" && hfImgUrl1.Value != "")
                {
                    pro.ImgUrl = hfImgUrl1.Value;
                }
                else if (txtImg.Text != hfImgUrl1.Value)
                {
                    pro.ImgUrl = hfImgUrl1.Value;
                }
                else {
                    pro.ImgUrl = txtImg.Text;
                }
                //判断大图的值
                if (txtBigImg.Text == "" && hfImgUrl.Value == "")
                {
                    pro.BigImgUrl = "";
                }
                else if (txtBigImg.Text != "" && hfImgUrl.Value == "")
                {
                    pro.BigImgUrl = txtBigImg.Text;
                }
                else if (txtBigImg.Text == "" && hfImgUrl.Value != "")
                {
                    pro.BigImgUrl = hfImgUrl.Value;
                }
                else if (txtBigImg.Text != hfImgUrl.Value)
                {
                    pro.BigImgUrl = hfImgUrl.Value;
                }
                else {
                    pro.BigImgUrl = txtBigImg.Text;
                }

                //判断产品类型的值
                if (hftypeId.Value != "")
                {
                    pro.ProTypeId = Convert.ToInt32(hftypeId.Value);
                    try
                    {
                        ProductBll.AddProduct(pro);
                        MessageBox.AlertAndRedirect("添加成功！", "Product.aspx?typeId=" + pro.ProTypeId, Page);
                    }
                    catch (Exception)
                    {
                        MessageBox.Alert("添加失败！", Page);
                        throw;
                    }
                }
                else if(hfId.Value!=""){
                    int id = Convert.ToInt32(hfId.Value);
                    pro.ProId = id;
                    List<Model.Product> list = ProductBll.GetProductbyId(id);
                    if (list.Count>0)
                    {
                        pro.ProTypeId=list[0].ProTypeId;
                        try
                        {
                            ProductBll.UpdateProduct(pro);
                            MessageBox.AlertAndRedirect("修改成功！","Product.aspx?typeId="+pro.ProTypeId,Page);
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

        protected void btnUpload1_Click(object sender, EventArgs e)
        {
            bool isfileOk = false;
            string filePath = Server.MapPath("/Upload/");
            if (fileupload2.HasFile)
            {
                string fileName = DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
                string fileExtension = System.IO.Path.GetExtension(fileupload2.FileName).ToLower();
                string[] allowExtension = { ".jpg", ".gif", ".png", ".jpeg", ".bmp", ".rar", ".txt", ".zip" };
                for (int i = 0; i < allowExtension.Length; i++)
                {
                    if (allowExtension[i] == fileExtension)
                    {
                        isfileOk = true;
                        break;
                    }
                }
                if (fileupload2.PostedFile.ContentLength > 1024000 * 1000)
                {
                    isfileOk = false;
                }
                if (isfileOk)
                {
                    try
                    {
                        fileupload2.PostedFile.SaveAs(filePath + fileName + fileExtension);
                        string imgUrl = "Upload/" + fileName + fileExtension;
                        lblUploadStatus1.Text = "上传成功！";
                        txtImg.Text = imgUrl;
                        lblUploadStatus1.ForeColor = System.Drawing.Color.Red;
                        hfImgUrl1.Value = imgUrl;
                        /*Response.Write("<script>parent.document.form1.hfImgUrl.value='" + imgUrl + "';</script>");*/
                    }
                    catch (Exception)
                    {
                        MessageBox.Alert("上传失败！", Page);
                    }
                }
                else
                {
                    MessageBox.Alert("文件类型错误或文件大小超过10M", Page);
                }
            }
            else
            {
                MessageBox.Alert("请选择文件！", Page);
            }
        }
    }
}