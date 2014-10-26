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
    public partial class AddImg1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        public void Bind() {
            string typeName = "盛大开幕图片";
            List<Img>list = ImgBll.GetImgbytypeName(typeName);
            if (list.Count>0)
            {
                hfImgId.Value=list[0].ImgId.ToString();
                imgOpen.ImageUrl="../"+list[0].ImgUrl;
                hfImgUrl.Value=list[0].ImgUrl;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (hfImgId.Value != "")
            {
                int imgId = Convert.ToInt32(hfImgId.Value);
                string imgUrl = hfImgUrl.Value;
                try
                {
                    ImgBll.UpdateImgUrl(imgId, imgUrl);
                    MessageBox.Alert("保存成功！", Page);
                    Bind();
                }
                catch (Exception)
                {
                    MessageBox.Alert("保存失败！", Page);
                }
            }
            else {
                Img img = new Img();
                img.Title = "首页盛大开幕图片";
                img.Rank = 1;
                img.ImgUrl = hfImgUrl.Value;
                string typeName = "盛大开幕图片";
                List<ImgType> list = ImgTypeBll.GetImgTypebyName(typeName);
                if (list.Count > 0)
                {
                    img.ImgTypeId = list[0].ImgTypeId;
                }
                else {
                    img.ImgTypeId = 3;
                }
                img.IsShow = 1;
                img.LinkUrl = "#";
                img.Remark = "";
                img.CreateTime = DateTime.Now.ToString("yyyy-MM-dd");
                try
                {
                    ImgBll.AddImg(img);
                    Bind();
                    MessageBox.Alert("保存成功！",Page);
                }
                catch (Exception)
                {
                    MessageBox.Alert("保存失败！",Page);
                }
            }
        }
    }
}