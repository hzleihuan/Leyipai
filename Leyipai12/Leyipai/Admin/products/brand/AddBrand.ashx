<%@ WebHandler Language="C#" Class="AddBrand" %>

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
/// AddBrand 的摘要说明
/// </summary>
public class AddBrand : IHttpHandler, IRequiresSessionState
{

    Leyipai.BLL.products.ProductsBrandBLL dll = new Leyipai.BLL.products.ProductsBrandBLL();
    public void ProcessRequest(HttpContext context)
    {

        string _brand_name = context.Request["brand.brand_name"];
        string _description = context.Request["brand.description"];
        Leyipai.Common.PageSuccess page = new PageSuccess();
        if (null != _brand_name && !"".Equals(_brand_name) && dll.isHavePurview(context, 8))
        {
            products_brand node = new products_brand();
            node.brand_name = _brand_name;
            node.description = _description;
            node.state = 0;
            dll.Add(node);

            page.success = true;
            page.msg = "添加成功！";
        }
        else
        {
            page.success = false;
            page.msg = "参数有误！";

        }


        context.Response.ContentType = "application/x-json";
        context.Response.Charset = "utf-8";
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