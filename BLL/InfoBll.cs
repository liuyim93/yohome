using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model;
using DAL;

namespace BLL
{
    public class InfoBll
    {
        /// <summary>
        /// 修改单篇文章内容
        /// </summary>
        /// <param name="infoId"></param>
        /// <param name="details"></param>
        /// <returns></returns>
        public static int UpdateDetail(int infoId,string details) {
            return InfoDal.UpdateDetail(infoId,details);   
        }

        /// <summary>
        /// 查询单篇文章内容
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public static List<Info> GetInfobyId(int infoId) {
            string sql = "select * from Info where InfoId="+infoId;
            return InfoDal.GetInfo(sql);
        }

        /// <summary>
        /// 根据类型名查询单篇文章内容
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static List<Info> GetInfobyName(string typeName) {
            string sql = "select top 1 * from Info where TypeName='"+typeName+"'";
            return InfoDal.GetInfo(sql);
        }
    }
}
