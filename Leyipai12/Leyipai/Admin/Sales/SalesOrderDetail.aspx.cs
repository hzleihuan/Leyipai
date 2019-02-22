using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using Leyipai.Model;

public partial class Admin_Sales_SalesOrderDetail : System.Web.UI.Page
    {
    Leyipai.BLL.SalesOrderBLL salesBll = new Leyipai.BLL.SalesOrderBLL();
        public string orderList = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string orderId = Request.QueryString["orderId"];
            if (null != orderId && !"".Equals(orderId))
            {
                sales_order o = salesBll.getByOrderNum(orderId);
                if (null != o)//加权限控制
                {
                    loadOrderDate(o);
                }
                else {

                    Response.Write("订单不存在");
                    Response.End();
                
                }
            }
            else { 
            
              
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        private void loadOrderDate(sales_order o) {


            Leyipai.BLL.c.CustomerBLL cbll = new Leyipai.BLL.c.CustomerBLL();
            Leyipai.BLL.OrderDetailBLL obll = new Leyipai.BLL.OrderDetailBLL();
         c_customer c = cbll.GetModel(o.customer_id);
         customer_name.Text = c.c_name;
         customer_address.Text = c.address;
         customer_linker.Text = c.link_men;
         customer_tel.Text = c.mobile;
         customet_email.Text = c.email;
           


         sales_orderid.Text=o.sales_orderId;
         create_date.Text = o.create_date;

         delivery_type.Text = o.delivery_type;
         delivery_place.Text = o.delivery_place;
         logistics.Text = o.logistics_name;
         logistics_num.Text = o.logistics_num;
         sales_income.Text = o.sales_income.ToString("0.00");
         attach_pay.Text = o.attach_pay.ToString("0.00");
         discount.Text = o.discount.ToString("0.00");;
         username.Text = o.username;
         auditing_user.Text = o.auditing_user;
         description.Text = o.description;
         order_user.Text = o.username;
         if (o.state == 0)
         {
             state.Text = "<font color=\"#FF0000\">未审核</font>";
         }
         else {
             state.Text = "<font color=\"#009933\">已审核</font>";
         }

         List<Leyipai.Model.order_detail> list = obll.GetByOrderId(o.sales_orderId);
         StringBuilder sr = new StringBuilder();
            
         decimal totalMoney = 0;
         int totalNum = 0;
         for (int i = 0; i < list.Count; i++)
         {
             Leyipai.Model.order_detail detail=list[i];
             sr.Append("<TR align=\"center\"><TD>" + (i + 1) + "</TD>");
             sr.Append("<TD>"+detail.products_id+"</TD>");
             sr.Append("<TD>"+detail.products_name+"</TD>");
             sr.Append("<TD>"+o.depot_name+"</TD>");
             sr.Append("<TD>"+detail.units+"</TD>");
             sr.Append("<TD>"+detail.quantity+"</TD>");
             sr.Append("<TD>" + detail.discount_rate.ToString("0.00") + "</TD>");
             sr.Append("<TD>"+detail.price.ToString("0.00")+"</TD>");
             sr.Append("<TD>" + (detail.price * detail.quantity * detail.discount_rate).ToString("0.00") + "</TD>");

             totalMoney = totalMoney + (detail.price * detail.quantity * detail.discount_rate);
             totalNum = totalNum + detail.quantity;
         }
         totalMoneyLabel.Text = totalMoney.ToString("0.00");
         totalNumLabel.Text = totalNum + "";
         MoneyChinaString.Text = Leyipai.Common.MoneyToChinaString.ConvertSum(o.sales_income.ToString("#.00"));
         orderList = sr.ToString();
        }

    }
