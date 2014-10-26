using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class SiteInfoBll
    {
        /// <summary>
        /// 修改网站信息
        /// </summary>
        /// <param name="siteInfo"></param>
        /// <returns></returns>
        public static int UpdateSiteInfo(SiteInfo siteInfo) {
            return SiteInfoDal.UpdateSiteInfo(siteInfo);
        }

        /// <summary>
        /// 查询网站信息
        /// </summary>
        /// <returns></returns>
        public static List<SiteInfo> GetSiteInfo() {
            string sql = "select top 1 * from SiteInfo order by SiteInfoId asc";
            return SiteInfoDal.GetSiteInfo(sql);
        }
    }
}
