<%@ WebHandler Language="C#" Class="findProductsByDepot" %>
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Leyipai.Common;
using Leyipai.BLL;
using Leyipai.Model;
using Newtonsoft.Json;

public class findProductsByDepot : IHttpHandler, IRequiresSessionState
{
    Leyipai.BLL.DepotProductsBLL bll = new Leyipai.BLL.DepotProductsBLL();
    public void ProcessRequest (HttpContext context) {
         string depot_id = context.Request["depot_id"];

        Leyipai.Common.Page<Leyipai.Model.depot_products> page = new Page<depot_products>();
        page.root = bll.getByDepotId(Int32.Parse(depot_id));
        page.success = true;

        context.Response.ContentType = "text/json";
        context.Response.Write(JavaScriptConvert.SerializeObject(page));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}