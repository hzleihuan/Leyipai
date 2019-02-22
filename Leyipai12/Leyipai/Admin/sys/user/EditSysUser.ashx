<%@ WebHandler Language="C#" Class="EditSysUser" %>

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
    /// EditSysUser 的摘要说明
    /// </summary>
    public class EditSysUser : IHttpHandler, IRequiresSessionState
    {

        Leyipai.BLL.SysUserBLL dll = new Leyipai.BLL.SysUserBLL();
        public void ProcessRequest(HttpContext context)
        {
            string _uid = context.Request["user.uid"];
            string _rid = context.Request["user.rid"];
            string _username = context.Request["user.username"];
            string _password = context.Request["user.password"];
            string _realname = context.Request["user.realname"];
            string _department = context.Request["user.department"];
            string _qq = context.Request["user.qq"];
            string _email = context.Request["user.email"];
            string _tel = context.Request["user.tel"];
            string _state = context.Request["user.state"];

            Leyipai.Common.PageSuccess page = new PageSuccess();
            if (null != _rid && null != _username && null != _password && null != _realname && null != _state && dll.isHavePurview(context, 1))
            {
                sys_user node = dll.GetModel(_username);
                if (null != node)
                {
                    node.uid = int.Parse(_uid);
                    node.department = _department;
                    node.email = _email;
                    node.password = _password;
                    node.qq = _qq;
                    node.realname = _realname;
                    node.rid = int.Parse(_rid);
                    node.state = int.Parse(_state);
                    node.tel = _tel;
                    node.username = _username;
                    dll.Update(node);

                    page.success = true;
                    page.msg = "修改成功！";

                }
                else
                {
                    page.success = false;
                    page.msg = "用户不存在！";
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
