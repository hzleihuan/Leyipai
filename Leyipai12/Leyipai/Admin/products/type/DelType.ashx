<%@ WebHandler Language="C#" Class="DelType" %>

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
/// DelType 的摘要说明
/// </summary>
public class DelType : IHttpHandler, IRequiresSessionState
{

    Leyipai.BLL.products.ProductsTypeBLL dll = new Leyipai.BLL.products.ProductsTypeBLL();

    public void ProcessRequest(HttpContext context)
    {
        string id = context.Request["id"];
        Leyipai.Common.PageSuccess page = new PageSuccess();
        if (null != id && !"".Equals(id) && dll.isHavePurview(context, 9))
        {
            page.success = dll.Delete(Int32.Parse(id));
            page.msg = "删除成功！";
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