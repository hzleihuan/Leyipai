// 导航栏配置文件
var outlookbar=new outlook();
var t;
t=outlookbar.addtitle('基本设置','系统设置',1)
outlookbar.additem('地区信息设置',t,'c/AreaManger.aspx')
outlookbar.additem('用户信息管理', t, 'sys/SysUser.aspx')
outlookbar.additem('系统角色管理', t, 'sys/SysRose.aspx')
outlookbar.additem('系统仓库配置', t, 'c/DepotManger.aspx')
outlookbar.additem('物流公司配置', t, 'c/LogisticsManger.aspx')
outlookbar.additem('数据库备份', t, 'sys/SysBackupDatabase.aspx')
outlookbar.additem('操作日志', t, 'sys/SysLog.aspx')


t=outlookbar.addtitle('商品设置','系统设置',1)
outlookbar.additem('品牌管理', t, 'products/ProductsBrandManger.aspx')
outlookbar.additem('类型管理', t, 'products/ProductsTypeManger.aspx')
outlookbar.additem('商品添加', t, 'products/Products_Add.aspx')
outlookbar.additem('商品管理', t, 'products/ProductsManger.aspx')




t = outlookbar.addtitle('商务管理', '系统设置', 1)
outlookbar.additem('客户管理', t, 'c/CustomerManger.aspx')
outlookbar.additem('客户分析', t, 'c/CustomerManger.aspx')
outlookbar.additem('客户积分', t, 'c/CustomerManger.aspx')




t = outlookbar.addtitle('用户信息', '系统首页', 1)
outlookbar.additem('用户个人信息', t, 'loginout.php')
outlookbar.additem('修改密码', t, 'loginout.php')
outlookbar.additem('操作日志', t, 'loginout.php')
outlookbar.additem('通知公告', t, 'loginout.php')


t = outlookbar.addtitle('订单管理', '销售管理', 1)
outlookbar.additem('销售订单', t, 'Sales/SalesOrderManger.aspx')
outlookbar.additem('添加订单', t, 'Sales/SalesOrderAdd.aspx')
outlookbar.additem('我的订单', t, 'loginout.php')
outlookbar.additem('订单分析', t, 'loginout.php')


t = outlookbar.addtitle('会计期间', '财务管理', 1)
outlookbar.additem('期末结算', t, 'Sales/SalesOrderManger.aspx')
