using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model;
using System.Data.OleDb;

namespace DAL
{
    public class ImgDal
    {
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static int AddImg(Img img) {
            string sql = "insert into Img(ImgUrl,ImgTypeId,Title,LinkUrl,Remark,Rank,CreateTime,IsShow)values(@ImgUrl,@ImgTypeId,@Title,@LinkUrl,@Remark,@Rank,@CreateTime,@IsShow)";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@ImgUrl",img.ImgUrl),
                new OleDbParameter("@ImgTypeId",img.ImgTypeId),
                new OleDbParameter("@Title",img.Title),
                new OleDbParameter("@LinkUrl",img.LinkUrl),
                new OleDbParameter("@Remark",img.Remark),
                new OleDbParameter("@Rank",img.Rank),
                new OleDbParameter("@CreateTime",img.CreateTime),
                new OleDbParameter("@IsShow",img.IsShow));
        }

        /// <summary>
        /// 查询图片
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<Img> GetImg(string sql) {
            List<Img> list = new List<Img>();
            DataSet ds = SqlHelper.GetDs(sql);
            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count>0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Img img = new Img();
                        img.ImgId = Convert.ToInt32(row["ImgId"]);
                        img.ImgTypeId = Convert.ToInt32(row["ImgTypeId"]);
                        img.Title=row["Title"].ToString();
                        img.LinkUrl=row["LinkUrl"].ToString();
                        img.Remark=row["Remark"].ToString();
                        img.Rank = Convert.ToInt32(row["Rank"]);
                        img.CreateTime=row["CreateTime"].ToString();
                        img.IsShow = Convert.ToInt32(row["IsShow"]);
                        img.ImgUrl=row["ImgUrl"].ToString();
                        list.Add(img);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 修改图片
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static int UpdateImg(Img img) {
            string sql = "update Img set ImgUrl=@ImgUrl,ImgTypeId=@ImgTypeId,Title=@Title,LinkUrl=@LinkUrl,Remark=@Remark,Rank=@Rank,CreateTime=@CreateTime,IsShow=@IsShow where ImgId=@ImgId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@ImgUrl",img.ImgUrl),
                new OleDbParameter("@ImgTypeId",img.ImgTypeId),
                new OleDbParameter("@Title",img.Title),
                new OleDbParameter("@LinkUrl",img.LinkUrl),
                new OleDbParameter("@Remark",img.Remark),
                new OleDbParameter("@Rank",img.Rank),
                new OleDbParameter("@CreateTime",img.CreateTime),
                new OleDbParameter("@IsShow",img.IsShow),
                new OleDbParameter("@ImgId",img.ImgId));
        }
        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="imgId"></param>
        /// <returns></returns>
        public static int DeleteImg(int imgId) {
            string sql = "delete from Img where ImgId=@ImgId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@ImgId",imgId));
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="imgId"></param>
        /// <param name="isShow"></param>
        /// <returns></returns>
        public static int UpdateStatus(int imgId,int isShow) {
            string sql = "update Img set IsShow=@IsShow where ImgId=@ImgId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@IsShow",isShow),
                new OleDbParameter("@ImgId",imgId));
        }

        /// <summary>
        /// 查询图片（datatable）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable getImg(string sql) {
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
        /// 修改图片链接
        /// </summary>
        /// <param name="imgId"></param>
        /// <param name="imgUrl"></param>
        /// <returns></returns>
        public static int UpdateImgUrl(int imgId,string imgUrl) {
            string sql = "update Img set ImgUrl=@ImgUrl whre ImgId=@ImgId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@ImgUrl",imgUrl),
                new OleDbParameter("@ImgId",imgId));
        }
    }
}
