﻿using System;
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
using Leyp.Model.Sales;
using Leyp.Components.Module.Sales;

public partial class Sales_MySalesDispatch : SalesDispatchSent
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            init();
        }

    }

    protected void init()
    {
        object action = Request.QueryString["action"];
        if (action != null)
        {
            if (action.ToString().Equals("view"))
            {
                string str0 = Request.QueryString["baginData"].ToString();
                string str1 = Request.QueryString["endData"].ToString();
                string str2 = Request.QueryString["side"].ToString();

                if (str0.Equals(""))
                {
                    str0 = "1000";
                }
                if (str1.Equals(""))
                {
                    str1 = "3000";
                }

                List<VSalesDispatch> list = new List<VSalesDispatch>();
                list = Leyp.SQLServerDAL.Sales.Factory.getSalesDispatchDAL().getByConsignorByDeliveryDate(str0, str1, int.Parse(str2),getUserName());

                CollectionPager1.DataSource = list;
                CollectionPager1.BindToControl = OrderList;
                OrderList.DataSource = CollectionPager1.DataSourcePaged;
            }
            



        }
        else  //初始化页面
        {
            List<VSalesDispatch> list = new List<VSalesDispatch>();
            list = Leyp.SQLServerDAL.Sales.Factory.getSalesDispatchDAL().getByConsignorByDeliveryDate("1000", "3000", 0, getUserName());

            CollectionPager1.DataSource = list;
            CollectionPager1.BindToControl = OrderList;
            OrderList.DataSource = CollectionPager1.DataSourcePaged;

        }
    }
    protected void Select_Click(object sender, EventArgs e)
    {
       
        string str1 = baginData.Text.ToString();
        string str2 = endData.Text.ToString();
        string str3 = side.SelectedValue.ToString();
        Response.Redirect(string.Format("MySalesDispatch.aspx?action=view&baginData={0}&endData={1}&side={2}", str1, str2, str3), true);

       
    }

    public string changString(string str)
    {

        if (str.Equals("1"))
        {
            return "<font color=\"#009933\">正常发货</font>";
        }
        else if (str.Equals("0"))
        {
            return "<font color=\"#FF0000\">未发货</font>";
        }
        else if (str.Equals("2"))
        {
            return "问题返回件";
        }
        else
        {
            return str;
        }

    }
}
