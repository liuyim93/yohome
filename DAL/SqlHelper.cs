using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;

namespace DAL
{
    public class SqlHelper
    {
        //获得连接字符串
        public static string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/App_Data/wanchai.mdb");

        /// <summary>
        /// 执行查询操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetDs(string sql)
        {
            OleDbDataAdapter Dar = new OleDbDataAdapter(sql, connectionString);
            DataSet ds = new DataSet();
            ds.Clear();
            Dar.Fill(ds);
            return ds;
        }

        /// <summary>
        /// 执行查询操作
        /// </summary>
        /// <param name="sql"></param>
        public static int DoSql(string sql)
        {            
            OleDbConnection conn = new OleDbConnection();//创建连接对象
            conn.ConnectionString = connectionString;//给连接字符串赋值
            conn.Open();//打开数据库
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            int num=cmd.ExecuteNonQuery();//            
            conn.Close();//关闭数据库
            return num;
        }

        /// <summary>
        /// 方法功能：对命令进行初始化
        /// </summary>
        /// <param name="con">连接对象</param>
        /// <param name="cmd">命令对象</param>
        /// <param name="cmdType">命令类型：存储过程还是SQL语句</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="parms">命令参数</param>
        private static void PrepareCommand(OleDbConnection con,
            OleDbCommand cmd, CommandType cmdType, string cmdText,
            OleDbParameter[] parms)
        {
            //如果没有打开连接，打开连接
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd.Connection = con;                //为命令指定连接
            cmd.CommandType = cmdType;  //为命令指定类型
            cmd.CommandText = cmdText;   //为命令指定文本

            //为命令指定参数
            if (parms != null)
            {
                cmd.Parameters.AddRange(parms);
            }
        }

        /// <summary>
        /// 方法功能：执行查询命令
        /// </summary>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="parms">命令参数</param>
        /// <returns>查询的结果集</returns>
        public static OleDbDataReader ExecuteReader(CommandType cmdType,
            string cmdText, params OleDbParameter[] parms)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = new OleDbConnection(connectionString);

            try
            {
                PrepareCommand(con, cmd, cmdType, cmdText, parms);
                OleDbDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                con.Close();
                throw;
            }
        }
        /// <summary>
        /// 方法功能：执行增加
        /// </summary>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="parms">命令参数</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery( CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {

            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = new OleDbConnection(connectionString);
            try
            {
                PrepareCommand(con, cmd, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
            catch
            {
                
                throw;
            }
            finally {
                con.Close();
            }
            
        }
    }
}
