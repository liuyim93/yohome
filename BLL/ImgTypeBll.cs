using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model;
using DAL;

namespace BLL
{
    public class ImgTypeBll
    {
        /// <summary>
        /// 查询图片类型
        /// </summary>
        /// <param name="imgTypeId"></param>
        /// <returns></returns>
        public static List<ImgType> GetImgTypebyId(int imgTypeId) {
            string sql = "select * from ImgType where ImgTypeId="+imgTypeId;
            return ImgTypeDal.GetImgType(sql);
        }

        /// <summary>
        /// 根据名称查询图片类型
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static List<ImgType> GetImgTypebyName(string typeName) {
            string sql = "select * from ImgType where TypeName='"+typeName+"'";
            return ImgTypeDal.GetImgType(sql);
        }
    }
}
