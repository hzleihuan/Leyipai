<%@ WebHandler Language="C#" Class="AddDepot" %>

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
    /// AddDepot 的摘要说明
    /// </summary>
    public class AddDepot : IHttpHandler, IRequiresSessionState
    {
        Leyipai.BLL.c.DepotBLL dll = new Leyipai.BLL.c.DepotBLL();
        public void ProcessRequest(HttpContext context)
        {
            string ss = context.Request["depot.depot_name"];
            Leyipai.Common.PageSuccess page = new PageSuccess();
            if (null != ss && !"".Equals(ss) && dll.isHavePurview(context, 4))
            {
                c_depot node = new c_depot();       
                node.depot_name = ss;
                node.state = 0;
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
