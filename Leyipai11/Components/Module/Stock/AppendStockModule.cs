﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Leyp.Components.Module.Stock
{
    /// <summary>
    /// 入库添加、浏览
    /// </summary>
    public class AppendStockModule: BasePage
    {
        protected override void OnInit(EventArgs e)
        {

            base.OnInit(e);
            validataAuthority("AppendStockModule");

        }
    }
}
