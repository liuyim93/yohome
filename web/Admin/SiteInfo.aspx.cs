using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using Tools;
using System.Data;

namespace web.Admin
{
    public partial class SiteInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["AdminId"] != null && Session["AdminId"].ToString() != "")
                {
                    BindData();
                    List<Model.SiteInfo> list = SiteInfoBll.GetSiteInfo();
                    if (list.Count > 0)
                    {
                        ltlTitle.Text = list[0].SiteTitle + "-后台管理系统";
                    }
                }
                else {                  
                }
            }
        }

        public void BindData() {
            List<Model.SiteInfo> list = SiteInfoBll.GetSiteInfo();
            if (list.Count>0)
            {
                hfId.Value=list[0].SiteInfoId.ToString();
                txtSiteTitle.Text=list[0].SiteTitle.ToString();
                txtKeyWords.Text=list[0].SiteKey.ToString();
                txtDescription.Text=list[0].SiteDes;                
                txtUrl.Text=list[0].SiteUrl;
                txtCompany.Text=list[0].CompanyName;
                txtAdress.Text=list[0].Adress;
                txtPostCode.Text=list[0].PostCode;
                txtLinkMan.Text=list[0].Contacts;
                txtTel.Text=list[0].Tel;
                txtPhone.Text=list[0].Phone;
                txtFax.Text=list[0].Fax;
                txtEmail.Text=list[0].Email;
                txtRecord.Text=list[0].Record;
                txtStatCode.Text=list[0].StatCode;
                txtBgsound.Text=list[0].BgsoundUrl;
                if (list[0].LogoUrl != "")
                {
                    txtLogo.Text = "/" + list[0].LogoUrl;
                }
                else {
                    txtLogo.Text = "";
                }
                hfImgUrl.Value=list[0].LogoUrl;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.SiteInfo site=new Model.SiteInfo();
            site.SiteInfoId = Convert.ToInt32(hfId.Value);
            site.SiteTitle = txtSiteTitle.Text;
            site.SiteKey = txtKeyWords.Text;
            site.SiteDes = txtDescription.Text;
            site.LogoUrl = hfImgUrl.Value;
            site.CompanyName = txtCompany.Text.Trim();
            site.SiteUrl = txtUrl.Text.Trim();
            site.Adress = txtAdress.Text;
            site.PostCode = txtPostCode.Text;
            site.Contacts = txtLinkMan.Text;
            site.Tel = txtTel.Text;
            site.Phone = txtPhone.Text;
            site.Fax = txtFax.Text;
            site.Email = txtEmail.Text;
            site.Record = txtRecord.Text;
            site.StatCode = txtStatCode.Text;
            if (hfImgUrl.Value == "")
            {
                site.LogoUrl = txtBgsound.Text.Trim();
            }
            else {
                site.LogoUrl = hfImgUrl.Value;
            }
            if (hfImgUrl2.Value == "")
            {
                site.BgsoundUrl = txtBgsound.Text.Trim();
            }
            else {
                site.BgsoundUrl = hfImgUrl2.Value;
            }
            try
            {
                SiteInfoBll.UpdateSiteInfo(site);
                BindData();
                MessageBox.Alert("保存成功！",Page);                
            }
            catch (Exception)
            {
                MessageBox.Alert("保存失败！",Page);
                throw;
            }
        }
    }
}