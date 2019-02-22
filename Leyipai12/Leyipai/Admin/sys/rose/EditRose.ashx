<%@ WebHandler Language="C#" Class="EditRose" %>
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
    /// EditRose 的摘要说明
    /// </summary>
    public class EditRose : IHttpHandler, IRequiresSessionState
    {

        Leyipai.BLL.SysRoseBLL dll = new Leyipai.BLL.SysRoseBLL();
        public void ProcessRequest(HttpContext context)
        {
            string _rid = context.Request["rose.rid"];
            string _rose_name = context.Request["rose.rose_name"];
            string _des = context.Request["rose.des"];
            Leyipai.Common.PageSuccess page = new PageSuccess();
            if (null != _rid && Leyipai.Common.PageValidate.IsNumber(_rid) && null != _rose_name && !"".Equals(_rose_name) && dll.isHavePurview(context, 3))
            {
                sys_rose node = dll.GetModel(int.Parse(_rid));
                if (null != node)
                {
                    node.rose_name = _rose_name;
                    node.des = _des;
                    dll.Update(node);

                    page.success = true;
                    page.msg = "修改成功！";
                }
                else {

                    page.success = false;
                    page.msg = "修改失败！";
                
                }
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
