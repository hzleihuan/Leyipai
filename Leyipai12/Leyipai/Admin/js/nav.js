// �����������ļ�
var outlookbar=new outlook();
var t;
t=outlookbar.addtitle('��������','ϵͳ����',1)
outlookbar.additem('������Ϣ����',t,'c/AreaManger.aspx')
outlookbar.additem('�û���Ϣ����', t, 'sys/SysUser.aspx')
outlookbar.additem('ϵͳ��ɫ����', t, 'sys/SysRose.aspx')
outlookbar.additem('ϵͳ�ֿ�����', t, 'c/DepotManger.aspx')
outlookbar.additem('������˾����', t, 'c/LogisticsManger.aspx')
outlookbar.additem('���ݿⱸ��', t, 'sys/SysBackupDatabase.aspx')
outlookbar.additem('������־', t, 'sys/SysLog.aspx')


t=outlookbar.addtitle('��Ʒ����','ϵͳ����',1)
outlookbar.additem('Ʒ�ƹ���', t, 'products/ProductsBrandManger.aspx')
outlookbar.additem('���͹���', t, 'products/ProductsTypeManger.aspx')
outlookbar.additem('��Ʒ���', t, 'products/Products_Add.aspx')
outlookbar.additem('��Ʒ����', t, 'products/ProductsManger.aspx')




t = outlookbar.addtitle('�������', 'ϵͳ����', 1)
outlookbar.additem('�ͻ�����', t, 'c/CustomerManger.aspx')
outlookbar.additem('�ͻ�����', t, 'c/CustomerManger.aspx')
outlookbar.additem('�ͻ�����', t, 'c/CustomerManger.aspx')




t = outlookbar.addtitle('�û���Ϣ', 'ϵͳ��ҳ', 1)
outlookbar.additem('�û�������Ϣ', t, 'loginout.php')
outlookbar.additem('�޸�����', t, 'loginout.php')
outlookbar.additem('������־', t, 'loginout.php')
outlookbar.additem('֪ͨ����', t, 'loginout.php')


t = outlookbar.addtitle('��������', '���۹���', 1)
outlookbar.additem('���۶���', t, 'Sales/SalesOrderManger.aspx')
outlookbar.additem('��Ӷ���', t, 'Sales/SalesOrderAdd.aspx')
outlookbar.additem('�ҵĶ���', t, 'loginout.php')
outlookbar.additem('��������', t, 'loginout.php')


t = outlookbar.addtitle('����ڼ�', '�������', 1)
outlookbar.additem('��ĩ����', t, 'Sales/SalesOrderManger.aspx')
