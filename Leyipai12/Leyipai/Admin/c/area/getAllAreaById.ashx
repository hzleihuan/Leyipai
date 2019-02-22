<%@ WebHandler Language="C#" Class="getAllAreaById" %>

using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Leyipai.Common;
using Leyipai.BLL;
using Leyipai.Model;

public class getAllAreaById : IHttpHandler, IRequiresSessionState
{

    Leyipai.BLL.c.areaBLL dal = new Leyipai.BLL.c.areaBLL();
        public void ProcessRequest(HttpContext context)
        {
            string id = context.Request["id"];
            if (null == id || "".Equals(id) || "root".Equals(id)) id = "1";
            List<Leyipai.Model.c_area> list = dal.GetModelList(" parent_id=" + id + "");
            string ss ="["+ getAllAreaString(list)+"]";
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


        public static string getAllAreaString(List<Leyipai.Model.c_area> list)
        {
            StringBuilder sb = new StringBuilder();
            string str = "";
            if (list == null || list.Count < 1)
            {
                sb.Append("");
            }
            else { 
                  int count=list.Count;
                  for (int i = 0; i < count; i++)
                  {
                      Leyipai.Model.c_area node = list[i];
                      bool haveChildren = true;
                      string chs = "false";
                      if (node.children == null || node.children.Count < 1)
                      {
                          chs = "true";
                          haveChildren = false;
                      }
                     
                      if (!haveChildren)
                           sb.Append("{\"children\":[],\"id\":" + node.id + ",\"leaf\":" + chs + ",\"text\":\""+node.area_name+"\"},");
                      else
                          sb.Append("{\"children\":[" + getAllAreaString(node.children) + "],\"id\":" + node.id + ",\"leaf\":" + chs + ",\"text\":\"" + node.area_name + "\"},");//有子节点

                    
                  }
                  str = sb.ToString();
                  if (str.EndsWith(","))
                  {
                      str = str.Substring(0, str.Length - 1);
                  }
            
            }
            return str;
        }
   
    
    //
    }
