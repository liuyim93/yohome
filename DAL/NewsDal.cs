using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Model;

namespace DAL
{
    public class NewsDal
    {
        /// <summary>
        /// 添加新闻
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public static int AddNews(News news) {
            string sql = "insert into News (NewsTypeId,ImgUrl,CreateTime,Title,Intro,Details,IsShow,IndexShow,IsTop)values(@NewsTypeId,@ImgUrl,@CreateTime,@Title,@Intro,@Details,@IsShow,@IndexShow,@IsTop)";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@NewsTypeId",news.NewsTypeId),
                new OleDbParameter("@ImgUrl",news.ImgUrl),
                new OleDbParameter("@CreateTime",news.CreateTime),
                new OleDbParameter("@Title",news.Title),
                new OleDbParameter("@Intro",news.Intro),
                new OleDbParameter("@Details",news.Details),
                new OleDbParameter("@IsShow",news.IsShow),
                new OleDbParameter("@IndexShow",news.IndexShow),
                new OleDbParameter("@IsTop",news.IsTop));
        }


        /// <summary>
        /// 查询新闻
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<News> GetNews(string sql) {
            List<News> list = new List<News>();
            DataSet ds = SqlHelper.GetDs(sql);
            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count>0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        News news = new News();
                        news.NewsId = Convert.ToInt32(row["NewsId"]);
                        news.NewsTypeId = Convert.ToInt32(row["NewsTypeId"]);
                        news.ImgUrl=row["ImgUrl"].ToString();
                        news.CreateTime=row["CreateTime"].ToString();
                        news.Title=row["Title"].ToString();
                        news.Intro=row["Intro"].ToString();
                        news.Details=row["Details"].ToString();
                        news.IsTop = Convert.ToInt32(row["IsTop"]);
                        news.IsShow = Convert.ToInt32(row["IsShow"]);
                        news.IndexShow = Convert.ToInt32(row["IndexShow"]);
                        list.Add(news);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 修改新闻
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public static int UpdateNews(News news) {
            string sql = "update News set NewsTypeId=@NewsTypeId,ImgUrl=@ImgUrl,CreateTime=@CreateTime,Title=@Title,Intro=@Intro,Details=@Details,IsShow=@IsShow,IndexShow=@IndexShow,IsTop=@IsTop where NewsId=@NewsId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@NewsTypeId",news.NewsTypeId),
                new OleDbParameter("@ImgUrl",news.ImgUrl),
                new OleDbParameter("@CreateTime",news.CreateTime),
                new OleDbParameter("@Title",news.Title),
                new OleDbParameter("@Intro",news.Intro),
                new OleDbParameter("@Details",news.Details),
                new OleDbParameter("@IsShow",news.IsShow),
                new OleDbParameter("@IndexShow",news.IndexShow),
                new OleDbParameter("@IsTop",news.IsTop),
                new OleDbParameter("@NewsId",news.NewsId));
        }

        /// <summary>
        /// 删除新闻
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public static int DeleteNews(int newsId) {
            string sql = "delete from News where NewsId=@NewsId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@NewsId",newsId));
        }

        /// <summary>
        /// 查询新闻（datatable）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable getNews(string sql) {
            DataSet ds = SqlHelper.GetDs(sql);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else {
                return null;
            }
        }

        /// <summary>
        /// 修改新闻状态
        /// </summary>
        /// <param name="newsId"></param>
        /// <param name="isShow">是否显示</param>
        /// <returns></returns>
        public static int UpdateStatus(int newsId,int isShow) {
            string sql = "update News set IsShow=@IsShow where NewsId=@NewsId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@IsShow",isShow),
                new OleDbParameter("@NewsId",newsId));
        }
        
        /// <summary>
        /// 修改新闻置顶
        /// </summary>
        /// <param name="newsId"></param>
        /// <param name="isTop">是否置顶</param>
        /// <returns></returns>
        public static int UpdateTop(int newsId,int isTop) {
            string sql = "update News set IsTop=@IsTop where NewsId=@NewsId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@IsTop",isTop),
                new OleDbParameter("@NewsId",newsId));
        }

        /// <summary>
        /// 修改 推荐
        /// </summary>
        /// <param name="newsId"></param>
        /// <param name="indexShow">首页显示</param>
        /// <returns></returns>
        public static int UpdateIndex(int newsId,int indexShow) {
            string sql = "update News set IndexShow=@IndexShow where NewsId=@NewsId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@IndexShow",indexShow),
                new OleDbParameter("@NewsId",newsId));
        }
    }
}
