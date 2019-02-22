<%@ WebHandler Language="C#" Class="getAlllogistics" %>

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
/// getAlllogistics 的摘要说明
/// </summary>
public class getAlllogistics : IHttpHandler
{

    Leyipai.BLL.c.LogisticsBLL dll = new Leyipai.BLL.c.LogisticsBLL();
    public void ProcessRequest(HttpContext context)
    {
        Leyipai.Common.Page<Leyipai.Model.c_logistics> page = new Page<Leyipai.Model.c_logistics>();
        List<c_logistics> list = dll.GetModelList("");
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