using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Model;

namespace DAL
{
    public class ProductTypeDal
    {
        /// <summary>
        /// 添加产品类型
        /// </summary>
        /// <param name="proType"></param>
        /// <returns></returns>
        public static int AddProductType(ProductType proType) {
            string sql = "insert into ProductType (TypeName,FatherId,Rank,Remark)values(@TypeName,@FatherId,@Rank,@Remark)";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@TypeName",proType.TypeName),
                new OleDbParameter("@FatherId",proType.FatherId),
                new OleDbParameter("@Rank",proType.Rank),
                new OleDbParameter("@Remark",proType.Remark));
        }

        /// <summary>
        /// 查询产品类型
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<ProductType> GetProductType(string sql) {
            List<ProductType> list = new List<ProductType>();
            DataSet ds = SqlHelper.GetDs(sql);
            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count>0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ProductType proType = new ProductType();
                        proType.ProTypeId = Convert.ToInt32(row["ProTypeId"]);
                        proType.TypeName=row["TypeName"].ToString();
                        proType.FatherId = Convert.ToInt32(row["FatherId"]);
                        proType.Rank = Convert.ToInt32(row["Rank"]);
                        proType.Remark=row["Remark"].ToString();
                        list.Add(proType);
                    }
                }
            }
            return list;
        }
    }
}
