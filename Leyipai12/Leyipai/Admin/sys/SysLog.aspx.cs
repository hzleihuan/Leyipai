using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Admin_sys_SysLog : System.Web.UI.Page
{
     Leyipai.BLL.SysLogBLL logbll = new Leyipai.BLL.SysLogBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }


        protected void BindData()
        {
           
                List<Leyipai.Model.sys_log> list = logbll.GetModelList("");

                CollectionPager1.DataSource = list;

                CollectionPager1.BindToControl = OrderList;
                OrderList.DataSource = CollectionPager1.DataSourcePaged;
        }

       



       
    }
