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
using Leyipai.Model;
using System.Collections.Generic;

public partial class Admin_Index_Left_Menu : Leyipai.BLL.AdminBasePage
{
     protected void Page_Load(object sender, EventArgs e)
        {
            loadMenu();
        }


        public void loadMenu()
        {
            List<MenuNode> list = new List<MenuNode>();
            list.Add(new MenuNode("地区信息设置", "c/AreaManger.aspx",0, 2));
            list.Add(new MenuNode("用户信息管理", "sys/SysUser.aspx", 0, 1));
            list.Add(new MenuNode("系统角色管理", "sys/SysRose.aspx", 0, 3));
            list.Add(new MenuNode("系统仓库配置", "c/DepotManger.aspx", 0, 4));
            list.Add(new MenuNode("物流公司配置", "c/LogisticsManger.aspx", 0, 5));
            list.Add(new MenuNode("数据库备份", "sys/SysBackupDatabase.aspx", 0,6));
            list.Add(new MenuNode("系统操作日志", "sys/SysLog.aspx", 0, 7));
            list.Add(new MenuNode("品牌管理", "products/ProductsBrandManger.aspx", 0, 8));
            list.Add(new MenuNode("类型管理", "products/ProductsTypeManger.aspx", 0, 9));
            list.Add(new MenuNode("商品添加", "products/Products_Add.aspx", 0, 10));
            list.Add(new MenuNode("商品管理", "products/ProductsManger.aspx", 0, 10));
            //item2
            list.Add(new MenuNode("销售客户管理", "c/CustomerManger.aspx", 1, 11));
            list.Add(new MenuNode("销售订单管理", "Sales/SalesOrderManger.aspx", 1, 13));
            list.Add(new MenuNode("销售报表统计", "Sales/SalesStatistic.aspx", 1, 14));
            list.Add(new MenuNode("添加销售订单", "Sales/SalesOrderAdd.aspx", 1, 12));
            list.Add(new MenuNode("我的销售订单", "Sales/MySalesOrderList.aspx", 1, 12));
            //
            list.Add(new MenuNode("库存状况", "Stock/ShowProductsInDepot.aspx", 1, 12));




            //
             //5|1|a|s|p|x

              SessionUser user = this.getSessionUser(HttpContext.Current);
              List<MenuNode> listTemp0 = new List<MenuNode>();
              List<MenuNode> listTemp1 = new List<MenuNode>();
              if (null != user)
              {
                  List<Int32> userReslist = user.myresource;
                  for (int i = 0; i < list.Count; i++)
                  {
                      MenuNode node = list[i];
                      if (userReslist.Contains(node.pruviewnum))
                      {
                          if (node.type == 0)
                          {
                              listTemp0.Add(node);
                          }
                          else if (node.type == 1)
                          {
                              listTemp1.Add(node);
                          }
                      }
                  }
              }





              SystemSet.DataSource = listTemp0;
              SystemSet.DataBind();


              SalesRepeater.DataSource = listTemp1;
              SalesRepeater.DataBind();
        
        }


    }
