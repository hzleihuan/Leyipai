using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.Security;
using System.Data;

public partial class Admin_sys_SysBackupDatabase : System.Web.UI.Page
{
    Leyipai.BLL.SysBackupDatabaseBLL bll = new Leyipai.BLL.SysBackupDatabaseBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            loadBackNode();
        }

        protected void inalSettlement_Click(object sender, EventArgs e)
        {
           

            bll.BackupDatabase();
            loadBackNode();
        }



        protected void loadBackNode()
        {

            List<Leyipai.Model.backup_database> list = bll.GetModelList("");
            DropDownList1.DataSource = list;
            DropDownList1.DataTextField = "file_name";
            DropDownList1.DataValueField = "id";
            DropDownList1.DataBind();
        
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ids = DropDownList1.SelectedValue;
            if (ids == null || "".Equals(ids))
            {
                Leyipai.Common.Jscript.AlertAndRedirect("请选择还原点！", "SysBackupDatabase.aspx");
                return;
            }
            bool result = bll.restoreDatabase(ids);
            if (result)
            {
                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();
                FormsAuthentication.SignOut();
                Leyipai.Common.Jscript.AlertAndRedirect("还原成功！", "../Login.aspx");
                return;
            }
            else {

                Leyipai.Common.Jscript.AlertAndRedirect("还原失败！", "SysBackupDatabase.aspx");
                return;
            }
           
    //try
    //{
    // 连接 master 数据库 ;
    // 执行 sql  语句;
    // Response.Write("<script language=javascript>alert('数据恢复成功！');</script>");
    //}
    //catch(Exception ex)

        }
    }
