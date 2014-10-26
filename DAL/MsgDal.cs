using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class MsgDal
    {
        /// <summary>
        /// 添加留言
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static int AddMsg(Msg msg) {
            string sql = "insert into Msg (Author,Phone,Email,Adress,Details,CreateTime,IsRead)values(@Author,@Phone,@Email,@Adress,@Details,@CreateTime,@IsRead)";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@Author",msg.Author),
                new OleDbParameter("@Phone",msg.Phone),
                new OleDbParameter("@Email",msg.Email),
                new OleDbParameter("@Adress",msg.Adress),
                new OleDbParameter("@Details",msg.Details),
                new OleDbParameter("@CreateTime",msg.CreateTime),
                new OleDbParameter("@IsRead",msg.IsRead));
        }

        /// <summary>
        /// 查询留言
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<Msg> GetMsg(string sql) {
            List<Msg> list = new List<Msg>();
            DataSet ds = SqlHelper.GetDs(sql);
            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count>0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Msg msg = new Msg();
                        msg.MsgId = Convert.ToInt32(row["MsgId"]);
                        msg.Author=row["Author"].ToString();
                        msg.Phone=row["Phone"].ToString();
                        msg.Email=row["Email"].ToString();
                        msg.Adress=row["Adress"].ToString();
                        msg.Details=row["Details"].ToString();
                        msg.CreateTime=row["CreateTime"].ToString();
                        msg.IsRead = Convert.ToInt32(row["IsRead"]);
                        list.Add(msg);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 查询留言（datatable）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable getMsg(string sql) {
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
        /// 删除留言
        /// </summary>
        /// <param name="msgId"></param>
        /// <returns></returns>
        public static int DeleteMsg(int msgId) {
            string sql = "delete from Msg where MsgId=@MsgId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@MsgId",msgId));
        }

        /// <summary>
        /// 修改留言状态
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="isRead"></param>
        /// <returns></returns>
        public static int UpdateRead(int msgId,int isRead) {
            string sql = "update Msg set IsRead=@IsRead where MsgId=@MsgId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@IsRead",isRead),
                new OleDbParameter("@MsgId",msgId));
        }
    }
}
