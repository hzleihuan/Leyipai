using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Drawing;


public partial class ShoppingCart : System.Web.UI.Page
{
 
     //整型变量，用于存储总金额
        private decimal Total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string pid = Request.QueryString["pid"];
            BindCartList(pid);
        }


        private void BindCartList(string ID)
        {
            DataTable dt = null;

            //如果Session变量存在，则直接获取
            if (Session["Cart"] != null)
            {
                dt = (DataTable)Session["Cart"];
            }
            else//如果Session变量不存在，创建存储数据的表结构
            {
                dt = new DataTable();
                dt.Columns.Add(new DataColumn("id", typeof(Int32)));
                dt.Columns.Add(new DataColumn("products_name", typeof(String)));
                dt.Columns.Add(new DataColumn("price", typeof(decimal)));
                dt.Columns.Add(new DataColumn("quantity", typeof(Int32)));
                dt.Columns.Add(new DataColumn("discount_rate", typeof(decimal)));
                dt.Columns.Add(new DataColumn("totalCost", typeof(decimal)));
            }
            //ID或ProductNo不为null
            //则表示选中一件商品添加到购物车
            if (ID != null)
            {
                //先判断购物车中是否已经存在该商品
                Boolean IsExist = false;
               
                //如果购物车中存在该商品，则提示客户
                //该商品不会被重复添加到购物车
                if (IsExist)
                {

                }
                else//如果购物车中不存在该商品，则添加到购物车
                {

                    dt.Rows.Add(new object[]{100,"苹果MP3",230.5, 4,0.9,24524.9});
                    dt.Rows.Add(new object[] { 101, "苹果MP4", 235.5, 4, 0.9, 22564.9 });
                    dt.Rows.Add(new object[] { 102, "苹果MP5", 236.5, 4, 0.9, 24524.9 });

                }
            }

            gvCart.DataSource = dt;
            gvCart.DataBind();

            Session["Cart"] = dt;
        }



        protected void gvCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //GridView行的加亮显示功能
                e.Row.Attributes.Add("onmouseover", "b=this.style.backgroundColor;this.style.backgroundColor='#E1ECEE'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=b");

                //给+号图片和-号图片添加客户端click事件
                //用JavaScript实现数量的+1和-1
                TextBox tb = (TextBox)e.Row.FindControl("txtAmount");
                ((HtmlImage)e.Row.FindControl("imgReduce")).Attributes.Add("onclick", "Reduce(" + tb.ClientID + ")");
                ((HtmlImage)e.Row.FindControl("imgPlus")).Attributes.Add("onclick", "Plus(" + tb.ClientID + ")");

                //根据商品单价和数量计算购物车中商品的总金额
                DataRowView drv = (DataRowView)e.Row.DataItem;
                Total += Decimal.Parse(drv["price"].ToString()) * Decimal.Parse(tb.Text) * Decimal.Parse(drv["discount_rate"].ToString());
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //将总金额显示在金额一列对应的Footer单元格
                e.Row.Cells[1].Text = "金额总计：";
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].Text = Total.ToString("c2");
                e.Row.Cells[2].ForeColor = Color.Red;
            }
        }
        protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //点击删除时从DataTable中删除对应的数据行
            if (Session["Cart"] != null)
            {
                DataTable dt = (DataTable)Session["Cart"];
                dt.Rows.RemoveAt(e.RowIndex);
                dt.AcceptChanges();
                Session["Cart"] = dt;
                Response.Redirect("ShoppingCart.aspx");
            }
        }
        protected void imgbtnTotal_Click(object sender, ImageClickEventArgs e)
        {
            //遍历GridView，根据每行的文本框中的值
            //修改DataTable中对应行中数量一列的值
            if (Session["Cart"] != null)
            {
                DataTable dt = (DataTable)Session["Cart"];
                for (int i = 0; i < gvCart.Rows.Count; i++)
                {
                    dt.Rows[i]["Amount"] = ((TextBox)gvCart.Rows[i].FindControl("txtAmount")).Text;
                }
                dt.AcceptChanges();
                Session["Cart"] = dt;
                Response.Redirect("ShoppingCart.aspx");
            }
        }




    }
