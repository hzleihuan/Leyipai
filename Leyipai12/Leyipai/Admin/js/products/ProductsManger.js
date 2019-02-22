Ext.onReady(function () {
    // 使用表单提示
    Ext.QuickTips.init();
    // turn on validation errors beside the field globally
    Ext.form.Field.prototype.msgTarget = 'side';

    var sm = new Ext.grid.CheckboxSelectionModel();

    var cm = new Ext.grid.ColumnModel([
	    new Ext.grid.RowNumberer(),
		sm,
		{ header: '商品名称', width: 120, align: 'center', dataIndex: 'product_name' },
        { header: '商品类型', width: 100, align: 'center', dataIndex: 'type_name' },
        { header: '商品品牌', width: 100, align: 'center', dataIndex: 'brand_name' },
        { header: '单位计量', width: 90, align: 'center', dataIndex: 'units' },
        { header: '成本', width: 100, align: 'center', dataIndex: 'cost_price' },
        { header: '批发价', width: 100, align: 'center', dataIndex: 'wholesale_price' },
        { header: '零售价', width: 100, align: 'center', dataIndex: 'retail_price' },
        { header: '库存上限', width: 100, align: 'center', dataIndex: 'upperlimit' },
        { header: '库存下限', width: 100, align: 'center', dataIndex: 'lowerlimit' },
        { header: '规格', width: 120, align: 'center', dataIndex: 'spec' },
        { header: '过期日期', width: 100, align: 'center', dataIndex: 'expiry_date' },
		{ header: '自定义编码', width: 100, align: 'center', dataIndex: 'code' }




	]);

    cm.defaultSortable = true;

    var ds = new Ext.data.GroupingStore({
        proxy: new Ext.data.HttpProxy({
            url: 'products/getAllProducts.ashx'
        }),
        reader: new Ext.data.JsonReader({
            totalProperty: 'totalProperty',
            root: 'root'
        },
		[{ name: 'id', mapping: 'product_id', type: 'int' },
        { name: 'product_name', type: 'string' },
        { name: 'type_id', type: 'string' },
        { name: 'brand_id', type: 'string' },
        { name: 'cost_price', type: 'string' },
        { name: 'wholesale_price', type: 'string' },
        { name: 'retail_price', type: 'string' },
        { name: 'units', type: 'string' },
        { name: 'weight', type: 'string' },
        { name: 'material', type: 'string' },
        { name: 'spec', type: 'string' },
        { name: 'upperlimit', type: 'int' },
		{ name: 'lowerlimit', type: 'int' },
        { name: 'expiry_date', type: 'string' },
        { name: 'code', type: 'string' },
         { name: 'brand_name', type: 'string' },
         { name: 'type_name', type: 'string' }

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
		        tooltip: '添加一条商品品牌',
		        iconCls: 'icon-add',
		        handler: function () {
		            window.location.href = "Products_Add.aspx";
		        }
		    },
		"-", " ",
		    { text: '修改',
		        tooltip: '修改一条商品品牌',
		        iconCls: 'icon-edit',
		        handler: function () {
		            var _record = grid.getSelectionModel().getSelected();
		            if (sm.getCount() == 1) {
		                window.location.href = "Products_Add.aspx?pid=" + _record.data.id;
		            } else
		                Ext.Msg.alert('提示', '请选择一条记录！');

		        }
		    },
		"-", " ", { text: '删除',
		    tooltip: '删除选择的商品品牌',
		    iconCls: 'icon-del',
		    handler: function () {

		        var _record = grid.getSelectionModel().getSelected();
		        if (sm.getCount() == 1) {
		            delproducts(_record);
		        } else
		            Ext.Msg.alert('提示', '请选择一条记录！');

		    }
		}
		],
        emptyMsg: "查询记录为空!"
    });

    var grid = new Ext.grid.EditorGridPanel({
        renderTo: 'grid-div',
        tbar: [' 商品名称: ', new Ext.form.TextField({
            fieldLabel: '真实姓名',
            emptyText: '',
            name: 'search_name',
            id: 'search_name',
            width: 130
        }), '', new Ext.Button({
            text: '搜索',
            iconCls: 'icon_reset',
            handler: function () {
                var sname = Ext.get("search_name").getValue();

                ds.load({ params: { start: 0, limit: 20, pname: sname} });
            }
        }

			)],
        cm: cm,
        ds: ds,
        sm: sm,
        bbar: paging,
        height: 400,
        border: true,
        bodyStyle: 'width:960px',
        stripeRows: true

    });

    ds.load({ params: { start: 0, limit: 20} });


    function delproducts(_record) {
        var myMask = new Ext.LoadMask(Ext.getBody(), {
            msg: "Please wait..."
        });
        myMask.show();
        Ext.Ajax.request({
            url: 'products/DelProducts.ashx',
            params: {
                id: _record.data.id
            },
            success: function (response) {
                var success = Ext.util.JSON.decode(response.responseText).success;
                if (success) {
                    myMask.hide();
                    Ext.MessageBox.show({
                        title: '成功提示',
                        msg: '删除成功',
                        buttons: Ext.MessageBox.OK,
                        icon: Ext.MessageBox.INFO,
                        fn: function () {
                            ds.load();

                        }
                    });
                } else {
                    myMask.hide();
                    Ext.MessageBox.show({
                        title: '失败提示',
                        msg: '删除失败,请检查是否关联了角色信息',
                        buttons: Ext.MessageBox.OK,
                        icon: Ext.MessageBox.ERROR
                    });

                }
            },
            failure: function () {
                myMask.hide();
                Ext.MessageBox.show({
                    title: '失败提示',
                    msg: '系统错误，请联系管理员',
                    buttons: Ext.MessageBox.OK,
                    icon: Ext.MessageBox.ERROR
                });

            }
        });
    
    }

});