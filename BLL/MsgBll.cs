using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model;
using DAL;

namespace BLL
{
    public class MsgBll
    {
        /// <summary>
        /// 添加留言
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static int AddMsg(Msg msg) {
            return MsgDal.AddMsg(msg);
        }

        /// <summary>
        /// 查询留言详情
        /// </summary>
        /// <param name="msgId"></param>
        /// <returns></returns>
        public static List<Msg> GetMsgbyId(int msgId) {
            string sql = "select * from Msg where MsgId="+msgId;
            return MsgDal.GetMsg(sql);
        }

        /// <summary>
        /// 根据条件查询留言
        /// </summary>
        /// <param name="author">留言人</param>
        /// <param name="phone">电话</param>
        /// <param name="email">邮箱</param>
        /// <param name="adr">店址</param>
        /// <param name="time1">留言时间（小）</param>
        /// <param name="time2">留言时间（大）</param>
        /// <param name="read">留言状态</param>
        /// <returns></returns>
        public static DataTable getMsg(string author,string phone,string email,string adr,string time1,string time2,int read) {
            string sql = "select * from Msg where Author like '%"+author+"%' and Phone like '%"+phone+"%' and Email like '%"+email+"%' and Adress like '%"+adr+"%'";
            if (time1 != "" && time2 != "")
            {
                sql += " and CreateTime>'" + time1 + "' and CreateTime<'" + time2 + "'";
            }
            else {
                if (time1 == "" && time2 != "")
                {
                    sql += " and  CreateTime<'" + time2 + "'";
                }
                else if (time1!=""&&time2=="")
                {
                    sql += " and CreateTime>'"+time1+"'";
                }
            }
            if (read!=2)
            {
                sql += "and IsRead="+read;
            }
            sql += " order by CreateTime desc";
            return MsgDal.getMsg(sql);
        }

        /// <summary>
        /// 查询所有的留言
        /// </summary>
        /// <returns></returns>
        public static DataTable getAllMsg() {
            string sql = "select * from Msg order by CreateTime desc";
            return MsgDal.getMsg(sql);
        }

        /// <summary>
        /// 删除留言
        /// </summary>
        /// <param name="msgId"></param>
        /// <returns></returns>
        public static int DeleteMsg(int msgId) {
            return MsgDal.DeleteMsg(msgId);
        }

        /// <summary>
        /// 修改留言状态
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        public static int UpdateRead(int msgId,int read) {
            return MsgDal.UpdateRead(msgId,read);
        }
    }
}
