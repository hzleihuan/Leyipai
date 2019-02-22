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

public partial class Admin_Sales_SalesReport_Report_ByCustomer : System.Web.UI.Page
{

    public string dataXml = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string bdate = Request.QueryString["bdate"];
        string edate = Request.QueryString["edate"];
        string cids = Request.QueryString["cids"];
        if (null == cids || "".Equals(cids))
        {
            Response.Write("参数有误！");
            Response.End();
            return;
        }

        if (cids.EndsWith(",")) cids = cids.Substring(0, cids.Length - 2);

        if (cids.StartsWith(",")) cids = cids.Substring(1, cids.Length - 1);

        string[] cidsz = cids.Split(new char[] { ',' });
        Leyipai.BLL.SalesOrderBLL sdll = new Leyipai.BLL.SalesOrderBLL();
        dataXml = sdll.CustomerAnalyseChart(bdate, edate, cidsz);

    }


    

}
