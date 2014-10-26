using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tools;

namespace Web.Admin
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            bool isfileOk = false;
            string filePath = Server.MapPath("/Upload/");
            if (fileupload1.HasFile)
            {
                string fileName = DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
                string fileExtension = System.IO.Path.GetExtension(fileupload1.FileName).ToLower();
                string[] allowExtension = { ".jpg", ".gif", ".png", ".jpeg", ".bmp",".rar",".txt",".zip",".mp3",".wav",".wma",".ogg" };
                for (int i = 0; i < allowExtension.Length; i++)
                {
                    if (allowExtension[i] == fileExtension)
                    {
                        isfileOk = true;
                        break;
                    }
                }
                if (fileupload1.PostedFile.ContentLength > 1024000*1000)
                {
                    isfileOk = false;
                }
                if (isfileOk)
                {
                    try
                    {
                        fileupload1.PostedFile.SaveAs(filePath + fileName + fileExtension);
                        string imgUrl = "Upload/" + fileName + fileExtension;
                        lblStatus.Text = "上传成功！";
                        Response.Write("<script>parent.document.form1.hfImgUrl.value='"+imgUrl+"';</script>");
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