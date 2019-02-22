<%@ WebHandler Language="C#" Class="UpdateDepot" %>

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
    /// UpdateDepot 的摘要说明
    /// </summary>
    public class UpdateDepot : IHttpHandler, IRequiresSessionState
    {

        Leyipai.BLL.c.DepotBLL dll = new Leyipai.BLL.c.DepotBLL();
        public void ProcessRequest(HttpContext context)
        {
            string sid = context.Request["depot.depot_id"];
            string sname = context.Request["depot.depot_name"];
            string sstate = context.Request["depot.state"];
            Leyipai.Common.PageSuccess page = new PageSuccess();
            if (null != sid && !"".Equals(sid) && null != sname && !"".Equals(sname) && null != sstate && !"".Equals(sstate) && dll.isHavePurview(context, 4))
            {
                c_depot node = dll.GetModel(int.Parse(sid));
                if (node != null)
                {
                    node.depot_name = sname;
                    node.state = int.Parse(sstate);
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
