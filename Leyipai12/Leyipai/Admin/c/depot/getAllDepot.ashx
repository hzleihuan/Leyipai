<%@ WebHandler Language="C#" Class="getAllDepot" %>

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
    /// getAllDepot 的摘要说明
    /// </summary>
    public class getAllDepot : IHttpHandler
    {
        Leyipai.BLL.c.DepotBLL dll = new Leyipai.BLL.c.DepotBLL();
        public void ProcessRequest(HttpContext context)
        {
            Leyipai.Common.Page<Leyipai.Model.c_depot> page = new Page<Leyipai.Model.c_depot>();
            List<c_depot> list = dll.GetModelList("");
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
