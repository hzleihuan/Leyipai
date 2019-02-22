<%@ WebHandler Language="C#" Class="DelSysUser" %>

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
    /// DelSysUser 的摘要说明
    /// </summary>
    public class DelSysUser : IHttpHandler, IRequiresSessionState
    {

        Leyipai.BLL.SysUserBLL dll = new SysUserBLL();
        public void ProcessRequest(HttpContext context)
        {

           
            string _username = context.Request["username"];
            Leyipai.Common.PageSuccess page = new PageSuccess();
            if (null != _username && dll.isHavePurview(context, 1))
            {
                dll.Delete(_username);
                page.success = true;
            }
            else
            {
                page.success = false;
                page.msg = "权限有误！";

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
