using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class InfoDal
    {
        /// <summary>
        /// 修改单篇文章内容
        /// </summary>
        /// <param name="infoId"></param>
        /// <param name="details"></param>
        /// <returns></returns>
        public static int UpdateDetail(int infoId,string details) {
            string sql = "update Info set Details=@Details where InfoId=@InfoId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@Details",details),
                new OleDbParameter("@InfoId",infoId));
        }

        /// <summary>
        /// 查询单篇文章
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<Info> GetInfo(string sql) {
            List<Info> list = new List<Info>();
            DataSet ds = SqlHelper.GetDs(sql);
            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count>0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Info info = new Info();
                        info.InfoId = Convert.ToInt32(row["InfoId"]);
                        info.TypeName=row["TypeName"].ToString();
                        info.Remark=row["Remark"].ToString();
                        info.Rank=Convert.ToInt32(row["Rank"]);
                        info.FatherId = Convert.ToInt32(row["FatherId"]);
                        info.Details=row["Details"].ToString();
                        list.Add(info);
                    }
                }
            }
            return list;
        }
    }
}
