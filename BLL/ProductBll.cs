using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DAL;
using Model;

namespace BLL
{
    public class ProductBll
    {
        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public static int AddProduct(Product pro) {
            return ProductDal.AddProduct(pro);
        }

        /// <summary>
        /// 根据ID查询产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Product> GetProductbyId(int id) {
            string sql = "select * from Products where Products.ProId="+id;
            return ProductDal.GetProduct(sql);
        }

        /// <summary>
        /// 修改产品
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public static int UpdateProduct(Product pro) {
            return ProductDal.UpdateProduct(pro);
        }

        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="proId"></param>
        /// <returns></returns>
        public static int DeleteProduct(int proId) {
            return ProductDal.DeleteProduct(proId);
        }

        /// <summary>
        /// 查询所有的产品
        /// </summary>
        /// <returns></returns>
        public static DataTable getAllProduct() {
            string sql = "select Products.*,ProductType.* from Products,ProductType order by CreateTime desc";
            return ProductDal.getProduct(sql);
        }

        /// <summary>
        /// 根据产品类型ID 查询产品
        /// </summary>
        /// <param name="proTypeId"></param>
        /// <returns></returns>
        public static DataTable getProductbyTypeId(int proTypeId) {
            string sql = "select Products.*,ProductType.* from Products,ProductType where Products.ProTypeId=ProductType.ProTypeId and Products.ProTypeId="+proTypeId+" order by CreateTime desc";
            return ProductDal.getProduct(sql);
        }

        /// <summary>
        /// 搜索产品
        /// </summary>
        /// <param name="title"></param>
        /// <param name="proTypeId"></param>
        /// <returns></returns>
        public static DataTable getProduct(string title,int proTypeId) {
            string sql = "select Products.*,ProductType.* from Products,ProductType where Products.Title like '%"+title+"%' and Products.ProTypeId=ProductType.ProTypeId and Products.ProTypeId="+proTypeId+" order by CreateTime desc";
            return ProductDal.getProduct(sql);
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="proId"></param>
        /// <param name="isShow"></param>
        /// <returns></returns>
        public static int UpdateStatus(int proId,int isShow) {
            return ProductDal.UpdateStatus(proId,isShow);
        }

        /// <summary>
        /// 修改 推荐
        /// </summary>
        /// <param name="proId"></param>
        /// <param name="indexShow"></param>
        /// <returns></returns>
        public static int UpdateIndex(int proId,int indexShow) {
            return ProductDal.UpdateIndex(proId,indexShow);
        }

        /// <summary>
        /// 查询首页显示的10条产品
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetIndexPro(string typeName) {
            string sql = "select top 10 * from Products where IsShow=1 and IndexShow=1 and ProTypeId=(select ProTypeId from ProductType where TypeName='"+typeName+"') order by CreateTime desc";
            return ProductDal.GetProduct(sql);
        }

        /// <summary>
        /// 上一条产品
        /// </summary>
        /// <param name="proId"></param>
        /// <param name="proTypeId"></param>
        /// <returns></returns>
        public static List<Product> GetPro_prev(int proId,int proTypeId) {
            string sql = "select top 1 * from Products where IsShow=1 and ProId>"+proId+" and ProTypeId="+proTypeId+" order by ProId asc";
            return ProductDal.GetProduct(sql);
        }

        /// <summary>
        /// 下一条产品
        /// </summary>
        /// <param name="proId"></param>
        /// <param name="proTypeId"></param>
        /// <returns></returns>
        public static List<Product> GetPro_next(int proId,int proTypeId) {
            string sql = "select top 1 * from Products where IsShow=1 and ProId<"+proId+" and ProTypeId="+proTypeId+" order by ProId desc";
            return ProductDal.GetProduct(sql);
        }
    }
}
