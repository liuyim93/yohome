using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DAL;
using Model;

namespace BLL
{
    public class ProductTypeBll
    {
        /// <summary>
        /// 添加产品类型
        /// </summary>
        /// <param name="proType"></param>
        /// <returns></returns>
        public static int AddProductType(ProductType proType) {
            return ProductTypeDal.AddProductType(proType);
        }

        /// <summary>
        /// 根据ID 查询产品分类
        /// </summary>
        /// <param name="proTypeId"></param>
        /// <returns></returns>
        public static List<ProductType> GetProductType(int proTypeId) {
            string sql = "select * from ProductType where ProTypeId="+proTypeId;
            return ProductTypeDal.GetProductType(sql);
        }
    }
}
