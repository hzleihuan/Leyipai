<%@ WebHandler Language="C#" Class="UpdateType" %>

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
    /// UpdateType 的摘要说明
    /// </summary>
    public class UpdateType : IHttpHandler, IRequiresSessionState
    {
        Leyipai.BLL.products.ProductsTypeBLL dll = new Leyipai.BLL.products.ProductsTypeBLL();
        public void ProcessRequest(HttpContext context)
        {

            string _parent_id = context.Request["type.parent_id"];
            string _type_id = context.Request["type.type_id"];
            string _type_name = context.Request["type.type_name"];
            string _description = context.Request["type.description"];
            Leyipai.Common.PageSuccess page = new PageSuccess();
            if (null != _type_id && !"".Equals(_type_id) && null != _parent_id && !"".Equals(_parent_id) && null != _type_name && !"".Equals(_type_name) && dll.isHavePurview(context, 9))
            {
                products_type node = dll.GetModel(int.Parse(_type_id));
                node.description = _description;
                node.type_name = _type_name;
                node.parent_id = int.Parse(_parent_id);
                node.state = 0;
                dll.Update(node);

                page.success = true;
               
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