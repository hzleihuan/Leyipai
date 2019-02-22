using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Admin_Sales_SalesOrderEdit: Leyipai.BLL.AdminBasePage
    {
        public Leyipai.Model.sales_order salesOrder;
        public string orderDetailString = "";
        public string totalPrice = "";
        public string totalNum = "";
    Leyipai.BLL.SalesOrderBLL sbll = new Leyipai.BLL.SalesOrderBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            this.TestPurview(HttpContext.Current, 12);
            string orderId = Request.QueryString["orderId"];
            salesOrder = sbll.getByOrderNum(orderId);
            if (null == salesOrder)
            {
                Response.Write("订单不存在");
                Response.End();
                return;
            }
            else {
                loadDetail(orderId);
            
            }

        }

        public void loadDetail(string orderId)
        {
            Leyipai.BLL.OrderDetailBLL obll = new Leyipai.BLL.OrderDetailBLL();
            List<Leyipai.Model.order_detail> list = obll.GetByOrderId(orderId);
            StringBuilder sr = new StringBuilder();
            // var arr=[ [1, '本', '拉登'], [2, '笨', '拉登'],[3, '笨', '拉灯'] ];
            decimal totalMoney = 0;
            int Num = 0;

            sr.Append("");
            for (int i = 0; i < list.Count; i++)
            {
                Leyipai.Model.order_detail detail = list[i];
                sr.Append("[");
                sr.Append("" + i + "");
                sr.Append("," + detail.products_id + "");
                sr.Append(",'" + detail.products_name + "'");
                sr.Append(",'" + detail.units + "'");
                sr.Append(",'" + detail.price.ToString("#.##") + "'");
                sr.Append(",'" + detail.discount_rate.ToString("#.##") + "'");
                sr.Append("," + detail.quantity + "");
               
                sr.Append("]");
                if (i !=( list.Count - 1))
                {
                    sr.Append(",");
                }
                totalMoney = totalMoney + (detail.price * detail.quantity*detail.discount_rate);
                Num = Num + detail.quantity;
            }

            orderDetailString = sr.ToString();
            totalPrice = totalMoney.ToString("#.##");
            totalNum = Num + "";
        
        }


    }
