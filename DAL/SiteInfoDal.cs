using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class SiteInfoDal
    {
        /// <summary>
        /// 修改网站信息
        /// </summary>
        /// <param name="siteInfo"></param>
        /// <returns></returns>
        public static int UpdateSiteInfo(SiteInfo siteInfo){
            string sql = "update SiteInfo set SiteTitle=@SiteTitle,SiteDes=@SiteDes,SiteKey=@SiteKey,LogoUrl=@LogoUrl,SiteUrl=@SiteUrl,CompanyName=@CompanyName,Adress=@Adress,PostCode=@PostCode,Contacts=@Contacts,Tel=@Tel,Phone=@Phone,Email=@Email,Fax=@Fax,StatCode=@StatCode,Record=@Record,BgsoundUrl=@BgsoundUrl where SiteInfoId=@SiteInfoId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@SiteTitle",siteInfo.SiteTitle),
                new OleDbParameter("@SiteDes",siteInfo.SiteDes),
                new OleDbParameter("@SiteKey",siteInfo.SiteKey),
                new OleDbParameter("@LogoUrl",siteInfo.LogoUrl),
                new OleDbParameter("@SiteUrl",siteInfo.SiteUrl),
                new OleDbParameter("@CompanyName",siteInfo.CompanyName),
                new OleDbParameter("@Adress",siteInfo.Adress),
                new OleDbParameter("@PostCode",siteInfo.PostCode),
                new OleDbParameter("@Contacts",siteInfo.Contacts),
                new OleDbParameter("@Tel",siteInfo.Tel),
                new OleDbParameter("@Phone",siteInfo.Phone),
                new OleDbParameter("@Email",siteInfo.Email),
                new OleDbParameter("@Fax",siteInfo.Fax),
                new OleDbParameter("@StatCode",siteInfo.StatCode),
                new OleDbParameter("@Record",siteInfo.Record),
                new OleDbParameter("@BgsoundUrl",siteInfo.BgsoundUrl),
                new OleDbParameter("@SiteInfoId",siteInfo.SiteInfoId));
        }

        /// <summary>
        /// 查询管理员
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<SiteInfo> GetSiteInfo(string sql) {
            List<SiteInfo> list = new List<SiteInfo>();
            DataSet ds = SqlHelper.GetDs(sql);
            if (ds.Tables[0].Rows.Count>0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    SiteInfo siteInfo = new SiteInfo();
                    siteInfo.SiteInfoId = Convert.ToInt32(row["SiteInfoId"]);
                    siteInfo.SiteTitle = row["SiteTitle"].ToString();
                    siteInfo.SiteDes=row["SiteDes"].ToString();
                    siteInfo.SiteKey=row["SiteKey"].ToString();
                    siteInfo.LogoUrl=row["LogoUrl"].ToString();
                    siteInfo.SiteUrl=row["SiteUrl"].ToString();
                    siteInfo.CompanyName=row["CompanyName"].ToString();
                    siteInfo.Adress=row["Adress"].ToString();
                    siteInfo.Contacts=row["Contacts"].ToString();
                    siteInfo.PostCode=row["PostCode"].ToString();
                    siteInfo.Phone=row["Phone"].ToString();
                    siteInfo.Email=row["Email"].ToString();
                    siteInfo.Fax=row["Fax"].ToString();
                    siteInfo.Record=row["Record"].ToString();
                    siteInfo.StatCode=row["StatCode"].ToString();
                    siteInfo.Tel=row["Tel"].ToString();
                    siteInfo.BgsoundUrl=row["BgsoundUrl"].ToString();
                    list.Add(siteInfo);
                }
            }
            return list;
        }
    }
}
