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
    public partial class Upload1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload2_Click(object sender, EventArgs e)
        {
            bool isfileOk = false;
            string filePath = Server.MapPath("/Upload/audio/");
            if (fileupload2.HasFile)
            {
                string fileName = DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
                string fileExtension = System.IO.Path.GetExtension(fileupload2.FileName).ToLower();
                string[] allowExtension = { ".jpg", ".gif", ".png", ".jpeg", ".bmp", ".rar", ".txt", ".zip", ".mp3", ".wav", ".wma", ".ogg" };
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
                        string imgUrl = "Upload/audio/" + fileName + fileExtension;
                        lblStatus2.Text = "上传成功！";
                        Response.Write("<script>parent.document.form1.hfImgUrl2.value='" + imgUrl + "';</script>");
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