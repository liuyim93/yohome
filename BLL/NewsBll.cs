using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DAL;
using Model;

namespace BLL
{
    public class NewsBll
    {
        /// <summary>
        /// 添加新闻
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public static int AddNews(News news) {
            return NewsDal.AddNews(news);
        }

        /// <summary>
        /// 修改新闻
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public static int UpdateNews(News news) {
            return NewsDal.UpdateNews(news);
        }

        /// <summary>
        /// 删除新闻
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public static int DeleteNews(int newsId) {
            return NewsDal.DeleteNews(newsId);
        }

        /// <summary>
        /// 查询所有的新闻（datatable）
        /// </summary>
        /// <returns></returns>
        public static DataTable getAllNews() {
            string sql = "select News.*,NewsType.TypeName from News,NewsType where News.NewsTypeId=NewsType.NewsTypeId order by CreateTime desc";
            return NewsDal.getNews(sql);
        }

        /// <summary>
        /// 搜索新闻
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="status">是否发布</param>
        /// <param name="type">新闻类型</param>
        /// <returns></returns>
        public static DataTable getNews(string title,int status,int type) {
            string sql = "select News.*,NewsType.TypeName from News,NewsType where News.Title like '%"+title+"%' and News.NewsTypeId=NewsType.NewsTypeId";
            if (status!=2)
            {
                sql += " and News.IsShow="+status;
            }
            if (type!=0)
            {
                sql += " and News.NewsTypeId="+type;
            }
            sql += " order by CreateTime desc";
            return NewsDal.getNews(sql);
        }

        /// <summary>
        /// 查询新闻
        /// </summary>
        /// <param name="newsId">新闻ID</param>
        /// <returns></returns>
        public static List<News> GetNewsbyId(int newsId) {
            string sql = "select * from News where NewsId="+newsId;
            return NewsDal.GetNews(sql);
        }

        /// <summary>
        /// 修改新闻状态
        /// </summary>
        /// <param name="newsId"></param>
        /// <param name="isShow">是否显示</param>
        /// <returns></returns>
        public static int UpdateStatus(int newsId,int isShow) {
            return NewsDal.UpdateStatus(newsId,isShow);
        }

        /// <summary>
        /// 修改 置顶
        /// </summary>
        /// <param name="newsId"></param>
        /// <param name="isTop">是否置顶</param>
        /// <returns></returns>
        public static int UpdateTop(int newsId,int isTop) {
            return NewsDal.UpdateTop(newsId,isTop);
        }

        /// <summary>
        /// 修改 首页显示
        /// </summary>
        /// <param name="newsId"></param>
        /// <param name="indexShow">首页显示</param>
        /// <returns></returns>
        public static int UpdateIndex(int newsId,int indexShow) {
            return NewsDal.UpdateIndex(newsId,indexShow);
        }

        /// <summary>
        /// 查询首页显示的6条新闻
        /// </summary>
        /// <returns></returns>
        public static List<News> GetIndexNews(string typeName) {
            string sql = "select top 6 * from News where IndexShow=1 and IsShow=1 order by CreateTime desc";
            return NewsDal.GetNews(sql);
        }

        /// <summary>
        /// 查询首页显示的 新店开张资讯
        /// </summary>
        /// <returns></returns>
        public static List<News> GetIndexNews_Brand(string typeName) {
            string sql = "select top 6 * from News where IndexShow=1 and IsShow=1 and NewsTypeId=(select NewsTypeId from NewsType where TypeName='"+typeName+"') order by CreateTime desc";
            return NewsDal.GetNews(sql);
        }

        /// <summary>
        /// 查询置顶的一条新闻
        /// </summary>
        /// <param name="newsTypeId"></param>
        /// <returns></returns>
        public static DataTable getTopNews(int newsTypeId) {
            string sql = "select top 1 * from News where IsShow=1 and IsTop=1 and NewsTypeId="+newsTypeId+" order by CreateTime desc";
            return NewsDal.getNews(sql);
        }

        /// <summary>
        /// 查询除置顶以外的其他新闻
        /// </summary>
        /// <returns></returns>
        public static DataTable getNews_else(int newsId,int newsTypeId) {
            string sql = "select * from News where IsShow=1 and NewsTypeId="+newsTypeId+" and NewsId<>"+newsId+" order by CreateTime desc";
            return NewsDal.getNews(sql);
        }

        /// <summary>
        /// 根据新闻类型查询（按置顶、时间排序）
        /// </summary>
        /// <param name="newsTypeId"></param>
        /// <returns></returns>
        public static DataTable getNewsbytypeId(int newsTypeId) {
            string sql = "select * from News where IsShow=1 and NewsTypeId="+newsTypeId+" order by IsTop,CreateTime desc";
            return NewsDal.getNews(sql);
        }

        /// <summary>
        /// 查询上一条新闻
        /// </summary>
        /// <param name="newsId"></param>
        /// <param name="newsTypeId"></param>
        /// <returns></returns>
        public static List<News> GetNews_prev(int newsId,int newsTypeId) {
            string sql = "select top 1 * from News where IsShow=1 and NewsId>"+newsId+" and NewsTypeId="+newsTypeId+" order by NewsId asc";
            return NewsDal.GetNews(sql);
        }

        /// <summary>
        /// 查询下一条新闻
        /// </summary>
        /// <param name="newsId"></param>
        /// <param name="newsTypeId"></param>
        /// <returns></returns>
        public static List<News> GetNews_next(int newsId,int newsTypeId) {
            string sql = "select top 1 * from News where IsShow=1 and NewsId<" + newsId + " and NewsTypeId=" + newsTypeId + " order by NewsId desc";
            return NewsDal.GetNews(sql);
        }
    }
}
