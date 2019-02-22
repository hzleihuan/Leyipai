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

public partial class Admin_Sales_SalesReport_Report_ByProduct : System.Web.UI.Page
{
    public string dataXml = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string bdate = Request.QueryString["bdate"];
        string edate = Request.QueryString["edate"];
        string pids = Request.QueryString["pids"];
        if (null == pids || "".Equals(pids))
        {
            Response.Write("参数有误！");
            Response.End();
            return;
        }

        if (pids.EndsWith(",")) pids = pids.Substring(0, pids.Length - 2);

        if (pids.StartsWith(",")) pids = pids.Substring(1, pids.Length - 1);

        string[] pidsz = pids.Split(new char[] { ',' });

        Leyipai.BLL.OrderDetailBLL bll = new Leyipai.BLL.OrderDetailBLL();
        dataXml = bll.getChartDataXml(bdate, edate, pidsz);


    }
}
