<%@ WebHandler Language="C#" Class="DelProducts" %>

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
/// DelProducts 的摘要说明
/// </summary>
public class DelProducts : IHttpHandler, IRequiresSessionState
{

    Leyipai.BLL.products.ProductsBLL bll = new Leyipai.BLL.products.ProductsBLL();
    public void ProcessRequest(HttpContext context)
    {
        string id = context.Request["id"];
        Leyipai.Common.PageSuccess page = new PageSuccess();
        if (null != id && !"".Equals(id) && bll.isHavePurview(context, 10))
        {
            page.success = bll.Delete(Int32.Parse(id));
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