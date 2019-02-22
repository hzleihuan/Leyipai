<%@ WebHandler Language="C#" Class="updateRoseResource" %>

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
/// updateRoseResource 的摘要说明
/// </summary>
public class updateRoseResource : IHttpHandler, IRequiresSessionState
{

    Leyipai.BLL.SysRoseBLL dll = new Leyipai.BLL.SysRoseBLL();
    public void ProcessRequest(HttpContext context)
    {
        string _rid = context.Request["rid"];
        string _rsids = context.Request["rsids"];
        Leyipai.Common.Page<Leyipai.Model.sys_resource> page = new Page<Leyipai.Model.sys_resource>();
        if (null != _rid && null != _rsids && dll.isHavePurview(context, 3))
        {
            //if (_rsids.StartsWith(",")) _rsids = _rsids.Substring(1, _rsids.Length);
            dll.UpdateRoseResouce(int.Parse(_rid), _rsids);
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