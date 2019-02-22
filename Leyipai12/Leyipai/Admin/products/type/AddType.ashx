<%@ WebHandler Language="C#" Class="AddType" %>
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
/// AddType 的摘要说明
/// </summary>
public class AddType : IHttpHandler, IRequiresSessionState
{
    Leyipai.BLL.products.ProductsTypeBLL dll = new Leyipai.BLL.products.ProductsTypeBLL();

    public void ProcessRequest(HttpContext context)
    {
        string _parent_id = context.Request["parent_id"];
        string _type_name = context.Request["type.type_name"];
        string _description = context.Request["type.description"];
        Leyipai.Common.PageSuccess page = new PageSuccess();
        if (null != _parent_id && !"".Equals(_parent_id) && null != _type_name && !"".Equals(_type_name) && dll.isHavePurview(context, 9))
        {
            if ("root".Equals(_parent_id)) _parent_id = "1";
            products_type node = new products_type();
            node.description = _description;
            node.type_name = _type_name;
            node.parent_id = int.Parse(_parent_id);
            node.state = 0;
            dll.Add(node);

            page.success = true;
            page.msg = "添加成功！";
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