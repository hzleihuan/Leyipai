<%@ WebHandler Language="C#" Class="getSalesOrderNum" %>

using System;
using System.Collections.Generic;
using System.Web;
using Leyipai.Common;

 /// <summary>
    /// getSalesOrderNum 的摘要说明
    /// </summary>
    public class getSalesOrderNum : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string num = MyRandom.GetSalesOrderID();
            context.Response.ContentType = "text/plain";
            context.Response.Write(num);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
