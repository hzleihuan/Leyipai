Ext.onReady(function () {
    // 使用表单提示
    Ext.QuickTips.init();
    // turn on validation errors beside the field globally
    Ext.form.Field.prototype.msgTarget = 'side';

    var sm = new Ext.grid.CheckboxSelectionModel();
    var cm = new Ext.grid.ColumnModel([
	    new Ext.grid.RowNumberer(),
		sm,
		{ header: '订单编号', width: 120, align: 'center', dataIndex: 'sales_orderId', renderer: function (v) {
		        return "<a href=\"SalesOrderDetail.aspx?orderId="+v+"\"target=\"_blank\">"+v+"</a>";
		} 
		},
        { header: '下单日期', width: 100, align: 'center', dataIndex: 'create_date' },
        { header: '订单类型', width: 100, align: 'center', dataIndex: 'sales_type', renderer: function (v) {
            if (v == 0) {
                return "内部下单";
            } else if (v == 1) {
                return "网站下单";
            }
        }
        },
        { header: '货物仓库', width: 90, align: 'center', dataIndex: 'depot_name' },
        { header: '物流公司', width: 100, align: 'center', dataIndex: 'logistics_name' },
        { header: '货运单号', width: 100, align: 'center', dataIndex: 'logistics_num' },
        { header: '货物金额', width: 100, align: 'center', dataIndex: 'sales_income' },
        { header: '附件成本', width: 100, align: 'center', dataIndex: 'attach_pay' },
        { header: '折让金额', width: 100, align: 'center', dataIndex: 'discount' },
        { header: '订单状态', width: 120, align: 'center', dataIndex: 'state', renderer: function (v) {
            if (v == 0) {
                return "<font color=\"#FF0000\">未审</font>";
            } else if (v == 1) {
                return "<font color=\"#006600\">已审</font>";
            } else if (v == 2) {
                return "<font color=\"#999999\">底单</font>";
            }
        }
        },
        { header: '审核人员', width: 100, align: 'center', dataIndex: 'auditing_user' }

	]);
    // 0 为未审 1 一已审 默认0  2形成底单 不再显示
    cm.defaultSortable = true;

    var ds = new Ext.data.GroupingStore({
        proxy: new Ext.data.HttpProxy({
            url: 'ajax/getSalesOrderList.ashx'
        }),
        reader: new Ext.data.JsonReader({
            totalProperty: 'totalProperty',
            root: 'root'
        },
		[{ name: 'id', mapping: 'id', type: 'int' },
        { name: 'sales_orderId', type: 'string' },
        { name: 'create_date', type: 'string' },
        { name: 'sales_type', type: 'string' },
        { name: 'customer_id', type: 'int' },
        { name: 'depot_id', type: 'int' },
        { name: 'delivery_type', type: 'string' },
        { name: 'delivery_place', type: 'string' },
        { name: 'logistics_id', type: 'int' },
        { name: 'logistics_num', type: 'string' },
        { name: 'sales_income', type: 'string' },
        { name: 'attach_pay', type: 'string' },
		{ name: 'discount', type: 'string' },
        { name: 'username', type: 'string' },
        { name: 'auditing_user', type: 'string' },
        { name: 'state', type: 'int' },
        { name: 'depot_name', type: 'string' },
        { name: 'logistics_name', type: 'string' },
        { name: 'customer_name', type: 'string' }

		])
    });



    var paging = new Ext.PagingToolbar({
        pageSize: 20,
        store: ds,
        displayInfo: true,
        displayMsg: '显示第{0}条到{1}条记录，一共{2}条',
        items:
		["-", " ",
		    { text: '添加',
		        tooltip: '添加一条信息',
		        iconCls: 'icon-add',
		        handler: function () {
		            window.location.href = "SalesOrderAdd.aspx";

		        }
		    },
		"-", " ",
		    { text: '修改',
		        tooltip: '修改一条信息',
		        iconCls: 'icon-edit',
		        handler: function () {
		            var _record = grid.getSelectionModel().getSelected();
		            if (sm.getCount() == 1) {
		                window.location.href = "SalesOrderEdit.aspx?orderId=" + _record.data.sales_orderId;
		            } else
		                Ext.Msg.alert('提示', '请选择一条记录！');

		        }
		    },
		"-", " ", { text: '删除',
		    tooltip: '删除选择的信息',
		    iconCls: 'icon-del',
		    handler: function () {
		        if (sm.getCount() > 0) {
		            var listStore = grid.getStore();
		            var idStr = "";

		            for (var i = 0, j = grid.store.getCount(); i < j; i++) {
		                if (grid.getSelectionModel().isSelected(i)) {
		                    var str_id = grid.store.getAt(i).get("id");
		                    idStr = idStr + "," + str_id;
		                }
		            }
		            var myMask = new Ext.LoadMask(Ext.getBody(), {
		                msg: "Please wait..."
		            });
		            myMask.show();
		            Ext.Ajax.request({
		                url: 'ajax/DeleteSalesOrder.ashx?orderIds=' + idStr,

		                success: function (response) {
		                    Ext.Msg.alert('提示', response.responseText);
		                    myMask.hide();
		                    ds.load();
		                },
		                failure: function () {
		                    Ext.Msg.alert('提示', '操作失败！');
		                    myMask.hide();
		                }
		            });

		        } else {
		            Ext.Msg.alert('提示', '请选择要删除的记录！');
		            

		        }
		    }
		}
		],
        emptyMsg: "查询记录为空!"
    });

    var grid = new Ext.grid.EditorGridPanel({
        renderTo: 'grid-div',
        tbar: ['订单编号: ', new Ext.form.TextField({
            fieldLabel: '',
            emptyText: '',
            name: 'orderNumId',
            id: 'orderNumId',
            width: 130
        }), '  ', '起始日期: ', new Ext.form.DateField({
            id: 'bdate',
            format: 'Y-m-d',
            value: new Date(),
            menu: new Ext.menu.DateMenu({
                hideOnClick: false,
                allowOtherMenus: true
            })
        }), '  ', '结束日期: ', new Ext.form.DateField({
            id: 'edate',
            format: 'Y-m-d',
            value: new Date(),
            menu: new Ext.menu.DateMenu({
                hideOnClick: false,
                allowOtherMenus: true
            })
        }), '  ', new Ext.Button({
            text: '搜索',
            iconCls: 'icon_reset',
            handler: function () {
                var oNum = Ext.get("orderNumId").getValue();
                var bdates = Ext.get("bdate").getValue();
                var edates = Ext.get("edate").getValue();
                ds.load({ params: { start: 0, limit: 20, orderNum: oNum, bdate: bdates, edate: edates} });
            }
        }

			), '  ', new Ext.Button({
			    text: '审核',
			    width: 80,
			    iconCls: 'icon-tools',
			    handler: function () {
			        if (sm.getCount() > 0) {
			            var listStore = grid.getStore();
			            var idStr = "";

			            for (var i = 0, j = grid.store.getCount(); i < j; i++) {
			                if (grid.getSelectionModel().isSelected(i)) {
			                    var str_id = grid.store.getAt(i).get("id");
			                    idStr = idStr + "," + str_id;
			                }
			            }
			            var myMask = new Ext.LoadMask(Ext.getBody(), {
			                msg: "Please wait..."
			            });
			            myMask.show();
			            Ext.Ajax.request({
			                url: 'ajax/AuditingSalesOrder.ashx?orderIds=' + idStr,

			                success: function (response) {
			                    Ext.Msg.alert('提示', response.responseText);
			                    myMask.hide();
			                    ds.load();
			                },
			                failure: function () {
			                    Ext.Msg.alert('提示', '操作失败！');
			                    myMask.hide();
			                }
			            });

			        } else
			            Ext.Msg.alert('提示', '请选择要审核的记录！');
			            ds.load();

			    }
			})
        , '  ', new Ext.Button({
            text: '反审核',
            width: 80,
            iconCls: 'icon_reset',
            handler: function () {
                   if (sm.getCount() > 0) {
			            var listStore = grid.getStore();
			            var idStr = "";

			            for (var i = 0, j = grid.store.getCount(); i < j; i++) {
			                if (grid.getSelectionModel().isSelected(i)) {
			                    var str_id = grid.store.getAt(i).get("id");
			                    idStr = idStr + "," + str_id;
			                }
			            }
			            var myMask = new Ext.LoadMask(Ext.getBody(), {
			                msg: "Please wait..."
			            });
			            myMask.show();
			            Ext.Ajax.request({
			                url: 'ajax/UnAuditingOrders.ashx?orderIds=' + idStr,

			                success: function (response) {
			                    Ext.Msg.alert('提示', response.responseText);
			                    myMask.hide();
			                    ds.load();
			                },
			                failure: function () {
			                    Ext.Msg.alert('提示', '操作失败！');
			                    myMask.hide();
			                }
			            });

			        } else{
			            Ext.Msg.alert('提示', '请选择要反审核的记录！');
			            ds.load();

			    }
            }
        })],
        cm: cm,
        ds: ds,
        sm: sm,
        bbar: paging,
        height: 400,
        bodyStyle: 'width:960px',
        border: true,
        stripeRows: true

    });

    ds.load({ params: { start: 0, limit: 20} });

});