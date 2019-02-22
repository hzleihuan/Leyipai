<%@ WebHandler Language="C#" Class="resetMyPassWord" %>

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
    /// resetMyPassWord 的摘要说明
    /// </summary>
    public class resetMyPassWord : IHttpHandler, IRequiresSessionState
    {
        Leyipai.BLL.SysUserBLL bll = new SysUserBLL();
        public void ProcessRequest(HttpContext context)
        {

            string username = Leyipai.BLL.BaseLogin.getUserName(context);
            string oldpw = context.Request["oldpw"];
            string newpw = context.Request["newpw"];
            Leyipai.Common.PageSuccess page = new PageSuccess();
            if (null != username && !"".Equals(username) && null != oldpw && !"".Equals(oldpw) && null != newpw && !"".Equals(newpw))
            {
                Leyipai.Model.sys_user user = bll.GetModel(username);
                if (null != user)
                {
                    if(user.password.Equals(oldpw.Trim()))
                    {

                        user.password = newpw;
                        bll.Update(user);
                        page.success = true;
                        page.msg = "修改成功！";
                    
                    }else{
                    
                       page.success = false;
                       page.msg = "原密码不正确！";
                    }
                }
                else {
                    page.success = false;
                    page.msg = "用户不存在！";
                }

            }
            else {

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
