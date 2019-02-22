<%@ WebHandler Language="C#" Class="DelRose" %>

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
    /// DelRose 的摘要说明
    /// </summary>
    public class DelRose : IHttpHandler, IRequiresSessionState
    {

        Leyipai.BLL.SysRoseBLL dll = new Leyipai.BLL.SysRoseBLL();
        public void ProcessRequest(HttpContext context)
        {
            string _rid = context.Request["rose_rid"];
            Leyipai.Common.PageSuccess page = new PageSuccess();
            if (null != _rid && Leyipai.Common.PageValidate.IsNumber(_rid) && dll.isHavePurview(context, 3))
            {
                bool result = dll.Delete(int.Parse(_rid));
                if (result)
                {
                    page.success = true;
                    page.msg = "修改成功！";
                }
                else
                {
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
