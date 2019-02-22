<%@ WebHandler Language="C#" Class="GetAllSysResource" %>

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
    /// GetAllSysResource 的摘要说明
    /// </summary>
    public class GetAllSysResource : IHttpHandler
    {

        Leyipai.BLL.SysRoseBLL dll = new Leyipai.BLL.SysRoseBLL();
        public void ProcessRequest(HttpContext context)
        {
            Leyipai.Common.Page<Leyipai.Model.sys_resource> page = new Page<Leyipai.Model.sys_resource>();
            List<sys_resource> list = dll.GetAllSysResource();
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
