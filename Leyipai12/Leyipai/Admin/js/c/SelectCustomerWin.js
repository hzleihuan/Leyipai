//引用顾客窗口
function getSelectCustomerList() {

    var  sm = new Ext.grid.CheckboxSelectionModel({singleSelect:true}); 

    var cm = new Ext.grid.ColumnModel([
	    new Ext.grid.RowNumberer(),
		sm,
		{ header: '帐号', width: 120, align: 'center', dataIndex: 'username' },
        { header: '名称', width: 120, align: 'center', dataIndex: 'c_name' },
        { header: '类别', width: 120, align: 'center', dataIndex: 'types' },
        { header: '信誉', width: 120, align: 'center', dataIndex: 'rank' },
        { header: '电话', width: 120, align: 'center', dataIndex: 'tel' },
        { header: '手机', width: 120, align: 'center', dataIndex: 'mobile' },
        { header: 'Email', width: 120, align: 'center', dataIndex: 'email' },
        { header: '联系人', width: 120, align: 'center', dataIndex: 'link_men' },
        { header: '银行开户', width: 120, align: 'center', dataIndex: 'account_info' },
		{ header: '状态', width: 100, align: 'center', dataIndex: 'state', renderer: function (v) {
		    if (v == 0) {
		        return "正常使用";
		    } else if (v == 1) {
		        return "禁用中";
		    }
		}
		}
	]);


    cm.defaultSortable = true;
    var ds = new Ext.data.GroupingStore({
        proxy: new Ext.data.HttpProxy({
            url: '../c/customer/getAllCustomer.ashx?state=0'
        }),
        reader: new Ext.data.JsonReader({
            totalProperty: 'totalProperty',
            root: 'root'
        },
		[{ name: 'id', mapping: 'id', type: 'int' },
		 { name: 'username', type: 'string' },
         { name: 'password', type: 'string' },
         { name: 'types', type: 'string' },
         { name: 'c_name', type: 'string' },
         { name: 'c_code', type: 'string' },
         { name: 'tariffline', type: 'string' },
         { name: 'tel', type: 'string' },
         { name: 'mobile', type: 'string' },
         { name: 'email', type: 'string' },
         { name: 'link_men', type: 'string' },
         { name: 'address', type: 'string' },
         { name: 'account_info', type: 'string' },
         { name: 'prestige_info', type: 'string' },
         { name: 'remark', type: 'string' },
         { name: 'rank', type: 'int' },
         { name: 'state', type: 'int' }

		])
    });




    var paging = new Ext.PagingToolbar({
        pageSize: 20,
        store: ds,
        displayInfo: true,
        displayMsg: '显示第{0}条到{1}条记录，一共{2}条',
        emptyMsg: "查询记录为空!"
    });

    var cgrid = new Ext.grid.EditorGridPanel({
        tbar: [' 客户名称: ', new Ext.form.TextField({
            fieldLabel: '',
            emptyText: '',
            name: 'coutomer_name',
            id: 'coutomer_name',
            width: 130
        }), '', new Ext.Button({
            text: '搜索',
            iconCls: 'icon_reset',
            handler: function () {
                var sname = Ext.get("coutomer_name").getValue();
                ds.load({ params: { start: 0, limit: 20, coutomer_name: sname} });
            }
        }

			)],
        cm: cm,
        ds: ds,
        sm: sm,
        bbar: paging,
        border: true,
        height: 300,
        bodyStyle: 'width:100%',
        stripeRows: true
    });

    ds.load({ params: { start: 0, limit: 20} });
    var selectCustomer_win = new Ext.Window({
        title: '选择顾客',
        width: 700,
        height: 400,
        resizable: false,
        modal: true,
        closeAction: 'hide',
        tbar: [{
            text: '添加',
            iconCls: 'icon-add',
            handler: function () {
                var _record = cgrid.getSelectionModel().getSelected();
                if (sm.getCount() == 1) {
                    var c_id = _record.data.id;
                    var c_nametext = _record.data.c_name;
                    Ext.getCmp("customer_id").setValue(c_id);
                    Ext.getCmp("customer_text").setValue(c_nametext);
                    var other_place = Ext.getCmp("delivery_place");
                    if (null != other_place && typeof(other_place)!="undefined") {
                        other_place.setValue(_record.data.address);

                    }
                    selectCustomer_win.hide();
                }
                else {
                    selectCustomer_win.hide();
                }

            }
        }],
        items: [cgrid]
    });

    selectCustomer_win.show();

}