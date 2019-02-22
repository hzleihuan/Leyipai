<%@ WebHandler Language="C#" Class="AddOrder" %>

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
    /// AddOrder 的摘要说明
    /// </summary>
    public class AddOrder : IHttpHandler, IRequiresSessionState
    {
        Leyipai.BLL.SalesOrderBLL bll = new Leyipai.BLL.SalesOrderBLL();
        Leyipai.Common.PageSuccess page = new PageSuccess();
        public void ProcessRequest(HttpContext context)
        {
         string _sales_orderid=context.Request["sales_orderid"];
         string _create_date = context.Request["create_date"];
         int _sales_type = 0;
         string _customer_id = context.Request["customer_id"];
         string _depot_id = context.Request["depot_id"];
         string _delivery_type = context.Request["delivery_type"];
         string _delivery_place = context.Request["delivery_place"];
         string _logistics_id = context.Request["logistics_id"];
         string _logistics_num = context.Request["logistics_num"];
         string _sales_income = context.Request["sales_income"];
         string _attach_pay = context.Request["attach_pay"];
         string _discount = context.Request["discount"];
        // string _username = context.Request["username"];
         string _description = context.Request["description"];

         string username = Leyipai.BLL.BaseLogin.getUserName(context);
         if (null != _sales_orderid && !"".Equals(_sales_orderid) &&
             null != _customer_id && !"".Equals(_customer_id) &&
             null != _depot_id && !"".Equals(_depot_id) &&
             null != _logistics_id && !"".Equals(_logistics_id) &&
             null != _sales_income && !"".Equals(_sales_income) &&
             null != _attach_pay && !"".Equals(_attach_pay) &&
             null != _discount && !"".Equals(_discount) && bll.isHavePurview(context, 12))
         {
             try
             {
                 sales_order o = new sales_order();
                 o.attach_pay = Decimal.Parse(_attach_pay);
                 o.auditing_user = "";
                 o.create_date = _create_date;
                 o.customer_id = int.Parse(_customer_id);
                 o.delivery_place = _delivery_place;
                 o.delivery_type = _delivery_type;
                 o.depot_id = int.Parse(_depot_id);
                 o.description = _description;
                 o.discount = Decimal.Parse(_discount);
                 o.logistics_id = int.Parse(_logistics_id);
                 o.logistics_num = _logistics_num;
                 o.sales_income = Decimal.Parse(_sales_income);
                 o.sales_orderId = _sales_orderid;
                 o.sales_type = _sales_type;
                 o.state = 0;
                 o.username = username;

                 bll.Add(o);
                 page.success = true;
                 page.msg = "添加成功！";

             }
             catch {

                 page.success = false;
                 page.msg = "参数有误！";
             }

         }
         else
         {
             page.success = false;
             page.msg = "参数有误！";

         }


            context.Response.ContentType = "application/x-json";
            context.Response.Charset = "utf-8";
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
