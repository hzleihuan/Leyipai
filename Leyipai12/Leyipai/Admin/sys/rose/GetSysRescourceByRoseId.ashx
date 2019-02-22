<%@ WebHandler Language="C#" Class="GetSysRescourceByRoseId" %>

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
    /// GetSysRescourceByRoseId 的摘要说明
    /// </summary>
    public class GetSysRescourceByRoseId : IHttpHandler
    {

        Leyipai.BLL.SysRoseBLL dll = new Leyipai.BLL.SysRoseBLL();
        public void ProcessRequest(HttpContext context)
        {
            string _rid = context.Request["rid"];
            string result = "";
            Leyipai.Common.Page<Leyipai.Model.sys_resource> page = new Page<Leyipai.Model.sys_resource>();
            if (null != _rid)
            {

                List<sys_resource> list = dll.GetAllSysResourceByRoseID(int.Parse(_rid));
                for (int i = 0; i < list.Count; i++)
                {
                    sys_resource node = list[i];
                    if(i==0)
                        result =node.rs_id+ "";
                    else
                    result = result + "," + node.rs_id;
                }
                page.msg = result;
                page.success = true;
            }
            else {
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
