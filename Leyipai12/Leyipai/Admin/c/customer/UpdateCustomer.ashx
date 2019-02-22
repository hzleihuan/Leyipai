<%@ WebHandler Language="C#" Class="UpdateCustomer" %>
using System;
using System.Collections.Generic;
using System;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Leyipai.Common;
using Leyipai.BLL;
using Leyipai.Model;
using Newtonsoft.Json;


 /// <summary>
    /// UpdateCustomer 的摘要说明
    /// </summary>
    public class UpdateCustomer : IHttpHandler, IRequiresSessionState
    {
        Leyipai.BLL.c.CustomerBLL bll = new Leyipai.BLL.c.CustomerBLL();
        public void ProcessRequest(HttpContext context)
        {
            string _id = context.Request["c.id"];
            string _username = context.Request["c.username"];
            string _password = context.Request["c.password"];
            int _types = 1;
            string _c_name = context.Request["c.c_name"];
            string _c_code = context.Request["c.c_code"];
            string _tariffline = context.Request["c.tariffline"];
            string _tel = context.Request["c.tel"];
            string _mobile = context.Request["c.mobile"];
            string _email = context.Request["c.email"];
            string _link_men = context.Request["c.link_men"];
            string _address = context.Request["c.address"];
            string _account_info = context.Request["c.account_info"];
            string _prestige_info = context.Request["c.prestige_info"];
            string _remark = context.Request["c.remark"];
            string _rank = context.Request["c.rank"];
            Leyipai.Common.PageSuccess page = new PageSuccess();
            if (Leyipai.Common.StringPlus.checkValue(_id) && Leyipai.Common.StringPlus.checkValue(_username) && Leyipai.Common.StringPlus.checkValue(_password) && Leyipai.Common.StringPlus.checkValue(_c_name) && bll.isHavePurview(context, 11))
            {

                c_customer node = bll.GetModel(int.Parse(_id));
                if (null == node)
                {
                    page.success = false;
                    page.msg = "用户不存在";
                }
                else
                {
                    if (!"".Equals(_email) && !node.email.Equals(_email) && bll.IsExistsByEmail(_email))
                    {
                        page.success = false;
                        page.msg = "邮箱已经存在";
                    }
                    else
                    {
                       
                        node.account_info = _account_info;
                        node.address = _address;
                        node.c_code = _c_code;
                        node.c_name = _c_name;
                        node.email = _email;
                        node.link_men = _link_men;
                        node.mobile = _mobile;
                        node.password = _password;
                        node.prestige_info = _prestige_info;
                        node.rank = int.Parse(_rank);
                        node.remark = _remark;
                        node.state = 0;
                        node.tariffline = _tariffline;
                        node.tel = _tel;
                       // node.username = _username;
                        node.types = _types;
                        bll.Update(node);
                        page.success = true;
                        page.msg = "修改成功";

                    }

                }
            }
            else
            {

                page.success = false;
                page.msg = "数据填写不完整";

            }



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
