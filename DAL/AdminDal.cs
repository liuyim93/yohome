using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Model;


namespace DAL
{
    public class AdminDal
    {
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static int AddAdmin(Admin admin) {
            string sql = "insert into Admin(AdminId,UserName,[Password],Remark,CreateTime,IsSuper)values(@AdminId,@UserName,@Password,@Remark,@CreateTime,@IsSuper)";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@AdminId",admin.AdminId),
            new OleDbParameter("@UserName",admin.UserName),
            new OleDbParameter("@Password",admin.Password),
            new OleDbParameter("@Remark",admin.Remark),
            new OleDbParameter("@CreateTime",admin.CreateTime),
            new OleDbParameter("@IsSuper",admin.IsSuper));
        }

        /// <summary>
        /// 查询管理员
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<Admin> GetAdmin(string sql) {
            List<Admin> list = new List<Admin>();
            DataSet ds = SqlHelper.GetDs(sql);
            if (ds.Tables[0].Rows.Count>0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Admin admin = new Admin();
                    admin.AdminId = Convert.ToInt32(row["AdminId"]);
                    admin.CreateTime=row["CreateTime"].ToString();
                    admin.IsSuper = Convert.ToInt32(row["IsSuper"]);
                    admin.UserName=row["UserName"].ToString();
                    admin.Password=row["Password"].ToString();
                    admin.Remark=row["Remark"].ToString();
                    list.Add(admin);
                }
            }
            return list;
        }

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public static int DeleteAdmin(int adminId) {
            string sql = "delete from Admin where AdminId=@AdminId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@AdminId",adminId));
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public static int UpdatePwd(string pwd,int adminId) {
            string sql = "update Admin set [Password]=@Password where AdminId=@AdminId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@Password",pwd),
                new OleDbParameter("@AdminId",adminId));
        }

        /// <summary>
        /// 查询管理员（datatable）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable getAdmin(string sql) {
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
        /// 修改管理员
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="remark"></param>
        /// <param name="isSuper"></param>
        /// <returns></returns>
        public static int UpdateAdmin(int adminId,string remark,int isSuper) {
            string sql = "update Admin set Remark=@Remark,IsSuper=@IsSuper where AdminId=@AdminId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@Remark",remark),
                new OleDbParameter("@IsSuper",isSuper),
                new OleDbParameter("@AdminId",adminId));
        }
    }
}
