<%@ WebHandler Language="C#" Class="getAllProducts" %>

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
    /// getAllProducts 的摘要说明
    /// </summary>
    public class getAllProducts : IHttpHandler
    {
        Leyipai.BLL.products.ProductsBLL bll = new Leyipai.BLL.products.ProductsBLL();
        public void ProcessRequest(HttpContext context)
        {
            string p_name = context.Request["pname"];
            string p_typeid = context.Request["typeId"];
            string p_brandid = context.Request["brandId"];
            string limit = context.Request["limit"];
            string start = context.Request["start"];
           

            int limitInt = 20;
            int startInt = 0;
            if (null != limit && Leyipai.Common.PageValidate.IsNumber(limit)) limitInt = int.Parse(limit);
            if (null != start && Leyipai.Common.PageValidate.IsNumber(start)) startInt = int.Parse(start);
            if (null == p_name) p_name = "";

            string sqlstr = " product_name like '%" + p_name + "%'";
            if (null != p_typeid && Leyipai.Common.PageValidate.IsNumber(p_typeid))
            {
                sqlstr = sqlstr + " and type_id=" + p_typeid;
            }

            if (null != p_brandid && Leyipai.Common.PageValidate.IsNumber(p_brandid))
            {
                sqlstr = sqlstr + " and brand_id=" + p_brandid;
            }

            Leyipai.Common.Page<Leyipai.Model.products> page = bll.GetListByPage(startInt, limitInt, sqlstr);

            List<Leyipai.Model.products> list = page.root;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].description = "";
            }
            page.root = list;
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
