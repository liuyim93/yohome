using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DAL;
using Model;

namespace BLL
{
    public class ImgBll
    {
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static int AddImg(Img img) {
            return ImgDal.AddImg(img);
        }

        /// <summary>
        /// 根据ID查询图片
        /// </summary>
        /// <param name="imgId"></param>
        /// <returns></returns>
        public static List<Img> GetImgbyId(int imgId) {
            string sql = "select * from Img where ImgId="+imgId;
            return ImgDal.GetImg(sql);
        }

        /// <summary>
        /// 修改图片
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static int UpdateImg(Img img) {
            return ImgDal.UpdateImg(img);
        }

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="imgId"></param>
        /// <returns></returns>
        public static int DeleteImg(int imgId) {
            return ImgDal.DeleteImg(imgId);
        }

        /// <summary>
        /// 根据图片类型查询图片（datatable）
        /// </summary>
        /// <param name="imgTypeId"></param>
        /// <returns></returns>
        public static DataTable getImgbytypeId(int imgTypeId) {
            string sql = "select Img.*,ImgType.TypeName from Img,ImgType where Img.ImgTypeId=ImgType.ImgTypeId and Img.ImgTypeId="+imgTypeId+" order by Rank desc";
            return ImgDal.getImg(sql);
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="imgId"></param>
        /// <param name="isShow"></param>
        /// <returns></returns>
        public static int UpdateStatus(int imgId,int isShow) {
            return ImgDal.UpdateStatus(imgId,isShow);
        }

        /// <summary>
        /// 根据类型名 查询图片(datatable)
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static DataTable getImgbytypeName(string typeName) {
            string sql = "select * from Img where IsShow=1 and ImgTypeId=(select ImgTypeId from ImgType where TypeName='"+typeName+"')";
            return ImgDal.getImg(sql);
        }
        /// <summary>
        /// 根据类型名 查询图片
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static List<Img> GetImgbytypeName(string typeName) {
            string sql = "select * from Img where IsShow=1 and ImgTypeId=(select ImgTypeId from ImgType where TypeName='" + typeName + "')";
            return ImgDal.GetImg(sql);
        }

        /// <summary>
        /// 修改图片地址
        /// </summary>
        /// <param name="imgId"></param>
        /// <param name="imgUrl"></param>
        /// <returns></returns>
        public static int UpdateImgUrl(int imgId,string imgUrl) {
            return ImgDal.UpdateImgUrl(imgId,imgUrl);
        }
    }

}
