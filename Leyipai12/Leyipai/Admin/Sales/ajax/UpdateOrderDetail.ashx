<%@ WebHandler Language="C#" Class="UpdateOrderDetail" %>

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
    /// UpdateOrderDetail 的摘要说明
    /// </summary>
    public class UpdateOrderDetail : IHttpHandler, IRequiresSessionState
    {
             Leyipai.BLL.OrderDetailBLL bll = new OrderDetailBLL();
             public void ProcessRequest(HttpContext context)
             {
                 string orderstr = context.Request["liststr"];
                 string orderId = context.Request["orderId"];
                 Leyipai.Common.PageSuccess page = new PageSuccess();
                 if (null != orderstr && !"".Equals(orderstr) && bll.isHavePurview(context, 12))
                 {
                     string[] nodes = orderstr.Split(new char[] { ',' });// 订单号$价钱$折扣$数量$商品ID
                     bool delOld = bll.DeleteByOrderId(orderId);
                     if (delOld)
                     {
                         for (int i = 0; i < nodes.Length; i++)
                         {
                             string str = nodes[i];
                             if (!"".Equals(str))
                             {
                                 string[] nums = str.Split(new char[] { '$' });
                                 order_detail n = new order_detail();
                                 n.order_id = nums[0];
                                 n.price = Decimal.Parse(nums[1]);
                                 n.discount_rate = Decimal.Parse(nums[2]);
                                 n.quantity = Int32.Parse(nums[3]);
                                 n.products_id = Int32.Parse(nums[4]);
                                 bll.Add(n);

                             }

                         }

                         page.success = true;
                         page.msg = "添加成功！";
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
