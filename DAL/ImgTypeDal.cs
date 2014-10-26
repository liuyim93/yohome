using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Model;

namespace DAL
{
    public class ImgTypeDal
    {
        /// <summary>
        /// 添加图片类型
        /// </summary>
        /// <param name="imgType"></param>
        /// <returns></returns>
        public static int AddImgType(ImgType imgType) {
            string sql = "insert into ImgType (TypeName,Remark)values(@TypeName,@Remark)";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@TypeName",imgType.TypeName),
                new OleDbParameter("@Remark",imgType.Remark));
        }

        /// <summary>
        /// 查询图片类型
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<ImgType> GetImgType(string sql) {
            List<ImgType> list = new List<ImgType>();
            DataSet ds = SqlHelper.GetDs(sql);
            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count>0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ImgType imgType=new ImgType();
                        imgType.ImgTypeId=Convert.ToInt32(row["ImgTypeId"]);
                        imgType.TypeName=row["TypeName"].ToString();
                        imgType.Remark=row["Remark"].ToString();
                        list.Add(imgType);
                    }
                }
            }
            return list;
        }
    }
}
