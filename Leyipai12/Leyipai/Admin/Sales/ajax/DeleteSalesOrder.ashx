<%@ WebHandler Language="C#" Class="DeleteSalesOrder" %>

using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Leyipai.Common;
using Leyipai.BLL;
using Leyipai.Model;
using Newtonsoft.Json;

/// <summary>
/// DeleteSalesOrder 的摘要说明
/// </summary>
public class DeleteSalesOrder : IHttpHandler, IRequiresSessionState
{

    Leyipai.BLL.SalesOrderBLL bll = new Leyipai.BLL.SalesOrderBLL();
    public void ProcessRequest(HttpContext context)
    {
        if (bll.isHavePurview(context, 12))
        {
            string username = Leyipai.BLL.BaseLogin.getUserName(context);
            string _sales_orderids = context.Request["orderIds"];
            string[] ids = _sales_orderids.Split(new char[] { ',' });
            string ss = bll.DeleteOrders(username, ids);
            context.Response.ContentType = "application/x-json";
            context.Response.Charset = "utf-8";
            context.Response.Write(ss);
        }
        else
        {


            context.Response.ContentType = "application/x-json";
            context.Response.Charset = "utf-8";
            context.Response.Write("没有权限");

        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}