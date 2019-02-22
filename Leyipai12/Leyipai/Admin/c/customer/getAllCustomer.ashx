<%@ WebHandler Language="C#" Class="getAllCustomer" %>

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
    /// getAllCustomer 的摘要说明
    /// </summary>
    public class getAllCustomer : IHttpHandler
    {
        Leyipai.BLL.c.CustomerBLL bll = new Leyipai.BLL.c.CustomerBLL();
        public void ProcessRequest(HttpContext context)
        {
            Leyipai.Common.Page<Leyipai.Model.c_customer> page = new Page<Leyipai.Model.c_customer>();
            string state = context.Request["state"];
            string coutomer_name = context.Request["coutomer_name"];
            string strWhere = "";
            if (null == coutomer_name) coutomer_name = "";
            strWhere = "c_name like '%" + coutomer_name + "%'";

            if (null != state && !"".Equals(state))
            {
                strWhere = strWhere + " and state=" + state;
            }
            List<c_customer> list = bll.GetModelList(strWhere);
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
