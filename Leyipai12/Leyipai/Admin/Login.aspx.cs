using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Admin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LoginButton_Click(object sender, ImageClickEventArgs e)
    {
        string sname = username.Text;
        string spwd = password.Text;
        string scode = code.Text;
        if (scode == null || "".Equals(scode))
        {
            Leyipai.Common.Jscript.AlertAndRedirect("验证码不能空！", "Login.aspx");
            return;
        }
        if (sname == null || "".Equals(sname))
        {
            Leyipai.Common.Jscript.AlertAndRedirect("用户名不能空！", "Login.aspx");
            return;
        }
        if (spwd == null || "".Equals(spwd))
        {
            Leyipai.Common.Jscript.AlertAndRedirect("密码不能空！", "Login.aspx");
            return;
        }

        string checkCode = Request.Cookies.Get("CheckCode").Value;
        if (checkCode == null || "".Equals(checkCode) || !checkCode.Equals(scode))
        {
            Leyipai.Common.Jscript.AlertAndRedirect("验证码错误！", "Login.aspx");
            return;
        }
        sname = sname.ToString().Trim().Replace("'", "").Replace("=", "");
        spwd = spwd.ToString().Trim().Replace("'", "").Replace("=", "");

        Leyipai.BLL.SysUserBLL ubll = new Leyipai.BLL.SysUserBLL();
        Leyipai.Model.sys_user user = ubll.GetModel(sname);
        if (null == user)
        {
            Leyipai.Common.Jscript.AlertAndRedirect("用户名或密码有误！", "Login.aspx");
            return;
        }
        if (!user.password.Equals(spwd))
        {
            Leyipai.Common.Jscript.AlertAndRedirect("用户名或密码有误！", "Login.aspx");
            return;
        }

        Leyipai.Model.SessionUser suser = new Leyipai.Model.SessionUser();
        List<Leyipai.Model.sys_resource> list = new Leyipai.BLL.SysRoseBLL().GetAllSysResourceByRoseID(user.rid);
        suser.username = user.username;
        suser.password = user.password;
        suser.realname = user.realname;//5+1+a+s+p+x
        suser.uid = user.uid;
        suser.rid = user.rid;
        suser.rosename = user.rosename;
        List<Int32> numlist = new List<int>();
        for (int i = 0; i < list.Count; i++)
        {
            Leyipai.Model.sys_resource node = list[i];
            numlist.Add(node.rs_id);
        }
        suser.myresource = numlist;
        Leyipai.BLL.BaseLogin.SetSession(HttpContext.Current, suser);

        //日志

        Response.Redirect("Index.aspx");


    }
}
