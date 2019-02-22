<%@ WebHandler Language="C#" Class="updateArea" %>

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
public class updateArea : IHttpHandler, IRequiresSessionState
{

    Leyipai.BLL.c.areaBLL dal = new Leyipai.BLL.c.areaBLL();
        public void ProcessRequest(HttpContext context)
        {
            Leyipai.Common.PageSuccess page = new PageSuccess();
            string ss = context.Request["area.text"];
            string id = context.Request["area.id"];
            if (null != ss && !"".Equals(ss) && null != id && !"".Equals(id) && dal.isHavePurview(context, 2))
            {
                Leyipai.Model.c_area node =dal.GetModel(int.Parse(id));
                if (null != node)
                {
                    node.area_name = ss;
                    dal.Update(node);
                    page.success = true;
                
                }
                
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
