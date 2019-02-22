<%@ WebHandler Language="C#" Class="Dellogistics" %>

using System;
using System.Collections.Generic;
using System;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Leyipai.Common;
using Leyipai.BLL;
using Leyipai.Model;
using Newtonsoft.Json;
/// <summary>
/// Dellogistics 的摘要说明
/// </summary>
public class Dellogistics : IHttpHandler, IRequiresSessionState
{

    Leyipai.BLL.c.LogisticsBLL dll = new Leyipai.BLL.c.LogisticsBLL();
    public void ProcessRequest(HttpContext context)
    {
        string id = context.Request["id"];
        Leyipai.Common.PageSuccess page = new PageSuccess();
        if (null != id && !"".Equals(id) && dll.isHavePurview(context, 5))
        {
            page.success = dll.Delete(Int32.Parse(id));
        }
        else
        {

            page.success = false;
        }


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