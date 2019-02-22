﻿using System;
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
using Leyp.Model;
using Leyp.Components;
using Leyp.Components.Module;
using Leyp.SQLServerDAL;

public partial class SysConfig : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Databang();
        }
    }

    /// <summary>
    /// 菜单绑定 
    /// </summary>
    protected void Databang()
    {
        AuthorityDAL bAuthority = Leyp.SQLServerDAL.Factory.getAuthorityDAL();
        List<GroupAuthority> AL = new List<GroupAuthority>();
        List<Authority> AL0 = new List<Authority>();//0

        AL = Leyp.SQLServerDAL.Factory.getGroupAuthorityDAL().getALLGroupAuthorityByGroupID(getGroupID());

        for (int i = 0; i < AL.Count; i++)
        {
            GroupAuthority g = AL[i];
            Authority a = bAuthority.getByID(g.AuthorityID);
            if (a.TypeID == 0)
            {
                AL0.Add(a);

            }

            Menu.DataSource = AL0;
            Menu.DataBind();

        }
    }
}
