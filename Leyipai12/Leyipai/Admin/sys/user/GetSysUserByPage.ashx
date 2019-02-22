<%@ WebHandler Language="C#" Class="GetSysUserByPage" %>

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
    /// GetSysUserByPage 的摘要说明
    /// </summary>
    public class GetSysUserByPage : IHttpHandler, IRequiresSessionState
    {
        Leyipai.BLL.SysUserBLL dll = new Leyipai.BLL.SysUserBLL();
        public void ProcessRequest(HttpContext context)
        {
            string limit=context.Request["limit"];
            string start=context.Request["start"];
            string realname = context.Request["realname"];
            if(dll.isHavePurview(context, 1))
            {
                int limitInt = 20;
                int startInt = 0;
                if (null != limit && Leyipai.Common.PageValidate.IsNumber(limit)) limitInt = int.Parse(limit);
                if (null != start && Leyipai.Common.PageValidate.IsNumber(start)) startInt = int.Parse(start);
                if (null == realname) realname = "";

                Leyipai.Common.Page<Leyipai.Model.sys_user> page = dll.GetListByPage(startInt, limitInt, " realname like '%" + realname + "%'");


           
               context.Response.ContentType = "application/x-json"; 
               context.Response.Charset = "utf-8";
               context.Response.Write( JavaScriptConvert.SerializeObject(page));
            }
             //context.Response.Write(");");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
