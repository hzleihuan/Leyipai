<%@ WebHandler Language="C#" Class="Addlogistics" %>

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
/// Addlogistics 的摘要说明
/// </summary>
public class Addlogistics : IHttpHandler, IRequiresSessionState
{

    Leyipai.BLL.c.LogisticsBLL dll = new Leyipai.BLL.c.LogisticsBLL();
    public void ProcessRequest(HttpContext context)
    {
        string ss = context.Request["l.logistics_name"];
        string des = context.Request["l.description"];
        Leyipai.Common.PageSuccess page = new PageSuccess();
        if (null != ss && !"".Equals(ss) && dll.isHavePurview(context, 5))
        {
            c_logistics node = new c_logistics();
            node.logistics_name = ss;
            node.description = des;
            dll.Add(node);

            page.success = true;
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