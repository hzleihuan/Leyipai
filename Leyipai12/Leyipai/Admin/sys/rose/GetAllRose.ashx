<%@ WebHandler Language="C#" Class="GetAllRose" %>

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
    /// GetAllRose 的摘要说明
    /// </summary>
    public class GetAllRose : IHttpHandler
    {
        Leyipai.BLL.SysRoseBLL dll = new Leyipai.BLL.SysRoseBLL();
        public void ProcessRequest(HttpContext context)
        {
            Leyipai.Common.Page<Leyipai.Model.sys_rose> page = new Page<Leyipai.Model.sys_rose>();
            List<sys_rose> list = dll.GetModelList("");
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
