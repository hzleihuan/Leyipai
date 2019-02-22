<%@ WebHandler Language="C#" Class="getMySalesOrderList" %>

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
    /// getMySalesOrderList 的摘要说明
    /// </summary>
    public class getMySalesOrderList : IHttpHandler, IRequiresSessionState
    {

        Leyipai.BLL.SalesOrderBLL bll = new SalesOrderBLL();
        public void ProcessRequest(HttpContext context)
        {
            string orderNum = context.Request["orderNum"];
            string bdate = context.Request["bdate"];
            string edate = context.Request["edate"];
            string limit = context.Request["limit"];
            string start = context.Request["start"];

            int limitInt = 20;
            int startInt = 0;
            if (null != limit && Leyipai.Common.PageValidate.IsNumber(limit)) limitInt = int.Parse(limit);
            if (null != start && Leyipai.Common.PageValidate.IsNumber(start)) startInt = int.Parse(start);

            string loginUsername = Leyipai.BLL.BaseLogin.getUserName(context);
            if (null == loginUsername) loginUsername = "false";

            Leyipai.Common.Page<Leyipai.Model.sales_order> page = bll.GetListByPage(startInt, limitInt, orderNum, bdate, edate, loginUsername);
            page.success = true;
            context.Response.ContentType = "text/json";
            context.Response.Write(JavaScriptConvert.SerializeObject(page));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
