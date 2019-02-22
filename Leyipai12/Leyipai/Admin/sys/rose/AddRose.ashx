<%@ WebHandler Language="C#" Class="AddRose" %>

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
    /// AddRose 的摘要说明
    /// </summary>
    public class AddRose : IHttpHandler, IRequiresSessionState
    {
        Leyipai.BLL.SysRoseBLL dll = new Leyipai.BLL.SysRoseBLL();
        public void ProcessRequest(HttpContext context)
        {

            string _rose_name = context.Request["rose.rose_name"];
            string _des = context.Request["rose.des"];
            Leyipai.Common.PageSuccess page = new PageSuccess();
            if (null != _rose_name && !"".Equals(_rose_name) && dll.isHavePurview(context, 3))
            {
                sys_rose node = new sys_rose();
                node.rose_name = _rose_name;
                node.des = _des;
                dll.Add(node);

                 page.success = true;
                 page.msg = "添加成功！";
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
