<%@ WebHandler Language="C#" Class="Updatelogistics" %>

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
/// Updatelogistics 的摘要说明
/// </summary>
public class Updatelogistics : IHttpHandler, IRequiresSessionState
{

    Leyipai.BLL.c.LogisticsBLL dll = new Leyipai.BLL.c.LogisticsBLL();
    public void ProcessRequest(HttpContext context)
    {
        string sid = context.Request["l.id"];
        string sname = context.Request["l.logistics_name"];
        string des = context.Request["l.description"];
        Leyipai.Common.PageSuccess page = new PageSuccess();
        if (null != sid && !"".Equals(sid) && null != sname && !"".Equals(sname) && dll.isHavePurview(context, 5))
        {
            c_logistics node = dll.GetModel(int.Parse(sid));
            if (node != null)
            {
                node.logistics_name = sname;
                node.description = des;
                dll.Update(node);
            }
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