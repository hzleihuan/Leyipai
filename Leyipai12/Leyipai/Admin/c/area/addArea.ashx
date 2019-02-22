<%@ WebHandler Language="C#" Class="addArea" %>

using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Leyipai.Common;
using Leyipai.BLL;
using Leyipai.Model;
using Newtonsoft.Json;

public class addArea : IHttpHandler, IRequiresSessionState
{
    Leyipai.BLL.c.areaBLL dal = new Leyipai.BLL.c.areaBLL();
        public void ProcessRequest(HttpContext context)
        {
            Leyipai.Common.PageSuccess page = new PageSuccess();
            string ss = context.Request["area.text"];
            string parentId = context.Request["parentId"];
            if (null != ss && !"".Equals(ss) && null != parentId && !"".Equals(parentId) && dal.isHavePurview(context,2))
            {
                Leyipai.Model.c_area node = new c_area();
                node.area_name = ss;
                if ("root".Equals(parentId)) parentId = "1";
                node.parent_id = int.Parse(parentId);
                dal.Add(node);
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

