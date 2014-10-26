using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Model;

namespace DAL
{
    public class ProductDal
    {
        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public static int AddProduct(Product pro) {
            string sql = "insert into Products (Title,Intro,Details,CreateTime,ImgUrl,ProTypeId,IndexShow,IsShow,BigImgUrl)values(@Title,@Intro,@Details,@CreateTime,@ImgUrl,@ProTypeId,@IndexShow,@IsShow,@BigImgUrl)";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@Title",pro.Title),
                new OleDbParameter("@Intro",pro.Intro),
                new OleDbParameter("@Details",pro.Details),
                new OleDbParameter("@CreateTime",pro.CreateTime),
                new OleDbParameter("@ImgUrl",pro.ImgUrl),
                new OleDbParameter("@ProTypeId",pro.ProTypeId),
                new OleDbParameter("@IndexShow",pro.IndexShow),
                new OleDbParameter("@IsShow",pro.IsShow),
                new OleDbParameter("@BigImgUrl",pro.BigImgUrl));
        }

        /// <summary>
        /// 查询产品
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<Product> GetProduct(string sql) {
            List<Product> list = new List<Product>();
            DataSet ds = SqlHelper.GetDs(sql);
            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count>0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Product pro = new Product();
                        pro.ProId = Convert.ToInt32(row["ProId"]);
                        pro.Title=row["Title"].ToString();
                        pro.Intro=row["Intro"].ToString();
                        pro.Details=row["Details"].ToString();
                        pro.CreateTime=row["CreateTime"].ToString();
                        pro.ImgUrl=row["ImgUrl"].ToString();
                        pro.ProTypeId = Convert.ToInt32(row["ProTypeId"]);
                        pro.IndexShow = Convert.ToInt32(row["IndexShow"]);
                        pro.IsShow = Convert.ToInt32(row["IsShow"]);
                        pro.BigImgUrl=row["BigImgUrl"].ToString();
                        list.Add(pro);
                    }
                }                
            }
            return list;
        }

        /// <summary>
        /// 修改产品
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public static int UpdateProduct(Product pro) {
            string sql = "update [Products] set [Title]=@Title,[Intro]=@Intro,[Details]=@Details,[CreateTime]=@CreateTime,[ImgUrl]=@ImgUrl,[ProTypeId]=@ProTypeId,[IndexShow]=@IndexShow,[IsShow]=@IsShow,[BigImgUrl]=@BigImgUrl where [ProId]=@ProId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@Title",pro.Title),
                new OleDbParameter("@Intro",pro.Intro),
                new OleDbParameter("@Details",pro.Details),
                new OleDbParameter("@CreateTime",pro.CreateTime),
                new OleDbParameter("@ImgUrl",pro.ImgUrl),
                new OleDbParameter("@ProTypeId",pro.ProTypeId),
                new OleDbParameter("@IndexShow",pro.IndexShow),
                new OleDbParameter("@IsShow",pro.IsShow),
                new OleDbParameter("@BigImgUrl",pro.BigImgUrl),
                new OleDbParameter("@ProId", pro.ProId));
        }

        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="proId"></param>
        /// <returns></returns>
        public static int DeleteProduct(int proId) {
            string sql = "delete from Products where ProId=@ProId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@ProId",proId));
            }

        /// <summary>
        /// 查询产品（datatable）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable getProduct(string sql) {
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
        /// 修改状态
        /// </summary>
        /// <param name="proId"></param>
        /// <param name="isShow"></param>
        /// <returns></returns>
        public static int UpdateStatus(int proId,int isShow) {
            string sql = "update Products set IsShow=@IsShow where ProId=@ProId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@IsShow",isShow),
                new OleDbParameter("@ProId",proId));
        }

        /// <summary>
        /// 修改 推荐
        /// </summary>
        /// <param name="proId"></param>
        /// <param name="indexShow"></param>
        /// <returns></returns>
        public static int UpdateIndex(int proId,int indexShow) {
            string sql = "update Products set IndexShow=@IndexShow where ProId=@ProId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@IndexShowd",indexShow),
                new OleDbParameter("@ProId",proId));
        }
    }
}
