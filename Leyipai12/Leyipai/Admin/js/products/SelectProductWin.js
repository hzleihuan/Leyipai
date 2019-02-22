//引用商品窗口
function getSelectProductsList() {

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
            url: '../products/products/getAllProducts.ashx'
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
        emptyMsg: "查询记录为空!"
    });

    var pgrid = new Ext.grid.EditorGridPanel({
        tbar: [' 商品名称: ', new Ext.form.TextField({
            fieldLabel: '',
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
        border: true,
        height: 300,
        bodyStyle: 'width:100%',
        stripeRows: true
    });

    ds.load({ params: { start: 0, limit: 20} });
    var selectProducts_win = new Ext.Window({
        title: '选择商品',
        width: 700,
        height: 400,
        resizable: false,
        modal: true,
        closeAction: 'hide',
        tbar: [{
            text: '添加',
            iconCls: 'icon-add',
            handler: function () {
                var _record = pgrid.getSelectionModel().getSelections();

                if (sm.getCount() > 0) {
                    var listgrid = Ext.getCmp("products-gridList");
                    var Plant = listgrid.getStore().recordType;
                    var listStore = listgrid.getStore();
                    //获得当前resourGrid所有行
                    //var recordlist = listgrid.getStore().getRange(0, resStore.getCount());
                    // alert(listgrid);
                    for (var i = 0, j = pgrid.store.getCount(); i < j; i++) {

                        if (pgrid.getSelectionModel().isSelected(i)) {

                            var str_id = pgrid.store.getAt(i).get("id");
                            var str_product_name = pgrid.store.getAt(i).get("product_name");
                            var str_cost_price = pgrid.store.getAt(i).get("cost_price");
                            var str_units = pgrid.store.getAt(i).get("units");

                            //检查是否已经添加过
                            var check = false;
                            for (var a = 0; a < listStore.getCount(); a++) {
                                if (listStore.getAt(a).get("products_id") == str_id) {
                                    check = true;
                                }
                                if (check) break;
                            }

                            if (!check) {

                                var p = new Plant({
                                    products_id: str_id,
                                    products_name: str_product_name,
                                    units: str_units,
                                    price: str_cost_price,
                                    discount_rate: 1.00,
                                    quantity: 1
                                });

                                listgrid.stopEditing();
                                listgrid.getStore().insert(0, p);
                                listgrid.startEditing(0, 0);
                            }
                        }

                    }

                    //重新计算合计
                   
                    var total = 0;
                    var totalNum = 0;
                    for (var aa = 0; aa < listStore.getCount(); aa++) {
                        var a1 = listStore.getAt(aa).get("price"); //价钱
                        var a2 = listStore.getAt(aa).get("discount_rate");
                        var a3 = listStore.getAt(aa).get("quantity"); //数量
                        total = total + a1 * a2 * a3;
                        totalNum = totalNum + a3;

                    }
                    Ext.getCmp("total_income").setValue(total);
                    Ext.getCmp("total_num").setValue(totalNum);
                    selectProducts_win.hide();



                } else {
                    selectProducts_win.hide();
                }

            }
        }],
        items: [pgrid]
    });

    selectProducts_win.show();

}