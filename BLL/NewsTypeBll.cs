using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DAL;
using Model;

namespace BLL
{
    public class NewsTypeBll
    {
        /// <summary>
        /// 添加新闻分类
        /// </summary>
        /// <param name="newsType"></param>
        /// <returns></returns>
        public static int AddNewsType(NewsType newsType) {
            return NewsTypeDal.AddNewsType(newsType);
        }

        /// <summary>
        /// 查询新闻分类
        /// </summary>
        /// <param name="newsTypeId"></param>
        /// <returns></returns>
        public static List<NewsType> GetNewsTypebyId(int newsTypeId) {
            string sql = "select * from NewsType where NewsTypeId="+newsTypeId;
            return NewsTypeDal.GetNewsType(sql);
        }

        /// <summary>
        /// 查询所有的新闻类型
        /// </summary>
        /// <returns></returns>
        public static List<NewsType> GetAllNewsType() {
            string sql = "select * from NewsType";
            return NewsTypeDal.GetNewsType(sql);
        }

        /// <summary>
        /// 修改新闻类型
        /// </summary>
        /// <param name="newsType"></param>
        /// <returns></returns>
        public static int UpdateNewsType(NewsType newsType) {
            return NewsTypeDal.UpdateNewsType(newsType);
        }

        /// <summary>
        /// 删除新闻分类
        /// </summary>
        /// <param name="newsTypeId"></param>
        /// <returns></returns>
        public static int DeleteNewsType(int newsTypeId) {
            return NewsTypeDal.DeleteNewsType(newsTypeId);
        }
    }
}
