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
using Leyp.Model.Sales;
using Leyp.Components.Module.Sales;
using Leyp.Components;

public partial class Sales_SalesOrder_Adda :  SalesOrderModule
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            init();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
        }
    }

    public void init()
    {
        SalesOrderID.Text = "BY" + StrHelper.GetRamCode();
        CreateDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        if (getTypeID() != 0)
        {
           CheckUserType.Value = "1";


        }


    }
}
