using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Model;

namespace DAL
{
    public class NewsTypeDal
    {
        /// <summary>
        /// 添加新闻分类
        /// </summary>
        /// <param name="newsType"></param>
        /// <returns></returns>
        public static int AddNewsType(NewsType newsType) {
            string sql = "insert into NewsType (TypeName,Remark,Rank)values(@TypeName,@Remark,@Rank)";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@TypeName",newsType.TypeName),
                new OleDbParameter("@Remark",newsType.Remark),
                new OleDbParameter("@Rank",newsType.Rank));
        }

        /// <summary>
        /// 查询新闻分类
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<NewsType> GetNewsType(string sql) {
            List<NewsType> list = new List<NewsType>();
            DataSet ds = SqlHelper.GetDs(sql);
            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count>0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        NewsType newsType = new NewsType();
                        newsType.NewsTypeId = Convert.ToInt32(row["NewsTypeId"]);
                        newsType.TypeName=row["TypeName"].ToString();
                        newsType.Remark=row["Remark"].ToString();
                        newsType.Rank=Convert.ToInt32(row["Rank"]);
                        list.Add(newsType);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 修改新闻分类
        /// </summary>
        /// <param name="newsType"></param>
        /// <returns></returns>
        public static int UpdateNewsType(NewsType newsType) {
            string sql = "update NewsType set TypeName=@TypeName,Remark=@Remark,Rank=@Rank where NewsTypeId=@NewsTypeId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@TypeName",newsType.TypeName),
                new OleDbParameter("@Remark",newsType.Remark),
                new OleDbParameter("@Rank",newsType.Rank),
                new OleDbParameter("@NewsTypeId",newsType.NewsTypeId));
        }

        /// <summary>
        /// 删除新闻分类
        /// </summary>
        /// <param name="newsTypeId"></param>
        /// <returns></returns>
        public static int DeleteNewsType(int newsTypeId) {
            string sql = "delete from NewsType where NewsTypeId=@NewsTypeId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@NewsTypeId",newsTypeId));
        }
    }
}
