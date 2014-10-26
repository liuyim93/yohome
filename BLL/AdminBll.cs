using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class AdminBll
    {
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static int AddAdmin(Admin admin) {
            return AdminDal.AddAdmin(admin);
        }

        /// <summary>
        /// 查询管理员
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<Admin> GetAdmin(int adminId) {
            string sql = "select * from Admin where AdminId="+adminId;
            return AdminDal.GetAdmin(sql);
        }

        /// <summary>
        /// 查询管理员（datatable）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable getAdmin(string sql) {
            return AdminDal.getAdmin(sql);
        }

        /// <summary>
        /// 修改管理员密码
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static int UpdatePwd(int adminId,string pwd) {
            return AdminDal.UpdatePwd(pwd,adminId);
        }

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public static int DeleteAdmin(int adminId) {
            return AdminDal.DeleteAdmin(adminId);
        }

        /// <summary>
        /// 修改管理员
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="remark"></param>
        /// <param name="isSuper"></param>
        /// <returns></returns>
        public static int UpdateAdmin(int adminId,string remark,int isSuper) {
            return AdminDal.UpdateAdmin(adminId,remark,isSuper);
        }

        /// <summary>
        /// 管理员登陆
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static List<Admin> AdminLogin(string userName,string pwd) {
            string sql = "select * from Admin where UserName='"+userName+"' and [Password]='"+pwd+"'";
            return AdminDal.GetAdmin(sql);
        }
    }
}
