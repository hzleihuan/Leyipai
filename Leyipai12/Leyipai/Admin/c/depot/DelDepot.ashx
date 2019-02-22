<%@ WebHandler Language="C#" Class="DelDepot" %>

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
    /// DelDepot 的摘要说明
    /// </summary>
    public class DelDepot : IHttpHandler, IRequiresSessionState
    {

        Leyipai.BLL.c.DepotBLL dll = new Leyipai.BLL.c.DepotBLL();
        public void ProcessRequest(HttpContext context)
        {
            string id = context.Request["depotId"];
            Leyipai.Common.PageSuccess page = new PageSuccess();
            if (null != id && !"".Equals(id) && dll.isHavePurview(context, 4))
            {
                page.success = dll.Delete(Int32.Parse(id));
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
