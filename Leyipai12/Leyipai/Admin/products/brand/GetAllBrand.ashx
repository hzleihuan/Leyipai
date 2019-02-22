<%@ WebHandler Language="C#" Class="GetAllBrand" %>

using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Leyipai.Common;
using Leyipai.BLL;
using Leyipai.Model;
using Newtonsoft.Json;
/// <summary>
/// GetAllBrand 的摘要说明
/// </summary>
public class GetAllBrand : IHttpHandler
{
    Leyipai.BLL.products.ProductsBrandBLL dll = new Leyipai.BLL.products.ProductsBrandBLL();
    public void ProcessRequest(HttpContext context)
    {
        Leyipai.Common.Page<Leyipai.Model.products_brand> page = new Page<Leyipai.Model.products_brand>();
        List<products_brand> list = dll.GetModelList("");
        page.root = list;
        page.success = true;
        context.Response.ContentType = "text/json";
        context.Response.Write(JavaScriptConvert.SerializeObject(page));
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}