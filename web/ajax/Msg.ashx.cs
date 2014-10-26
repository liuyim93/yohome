using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using BLL;
using Model;

namespace web.ajax
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Msg msg = new Msg();
            string name=context.Request.Params["name"];
            string phone = context.Request.Params["phone"];
            string email = context.Request.Params["email"];
            string adr = context.Request.Params["adr"];
            string con = context.Request.Params["con"];
            msg.Author = name;
            msg.Phone = phone;
            msg.Email = email;
            msg.Adress = adr;
            msg.Details = con;
            msg.CreateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            msg.IsRead = 0;
            try
            {
                MsgBll.AddMsg(msg);
                context.Response.Write("1");
            }
            catch (Exception)
            {
                context.Response.Write("0"); 
                throw;
            }
            context.Response.Flush();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}