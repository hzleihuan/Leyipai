<%@ WebHandler Language="C#" Class="GetAllType" %>

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
/// GetAllType 的摘要说明
/// </summary>
public class GetAllType : IHttpHandler
{
    Leyipai.BLL.products.ProductsTypeBLL dll = new Leyipai.BLL.products.ProductsTypeBLL();
    public void ProcessRequest(HttpContext context)
    {

        string id = context.Request["id"];
        if (null == id || "".Equals(id) || "root".Equals(id)) id = "1";
        List<Leyipai.Model.products_type> list = dll.GetModelList(" parent_id=" + id + "");
        string ss = "[" + getAllTypeString(list) + "]";
        context.Response.ContentType = "text/json";
        context.Response.Write(ss);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }


    public static string getAllTypeString(List<Leyipai.Model.products_type> list)
    {
        StringBuilder sb = new StringBuilder();
        string str = "";
        if (list == null || list.Count < 1)
        {
            sb.Append("");
        }
        else
        {
            int count = list.Count;
            for (int i = 0; i < count; i++)
            {
                Leyipai.Model.products_type node = list[i];
                bool haveChildren = true;
                string chs = "false";
                if (node.children == null || node.children.Count < 1)
                {
                    chs = "true";
                    haveChildren = false;
                }

                if (!haveChildren)
                    sb.Append("{\"children\":[],\"id\":" + node.type_id + ",\"leaf\":" + chs + ",\"text\":\"" + node.type_name + "\"},");
                else
                    sb.Append("{\"children\":[" + getAllTypeString(node.children) + "],\"id\":" + node.type_id + ",\"leaf\":" + chs + ",\"text\":\"" + node.type_name + "\"},");//有子节点


            }
            str = sb.ToString();
            if (str.EndsWith(","))
            {
                str = str.Substring(0, str.Length - 1);
            }

        }
        return str;
    }
}