/*!
 * Ext JS Library 3.3.1
 * Copyright(c) 2006-2010 Sencha Inc.
 * licensing@sencha.com
 * http://www.sencha.com/license
 */
Ext.onReady(function(){

    var myData = {
		records : [
			{ name : "Rec 0", column1 : "0", column2 : "0" },
			{ name : "Rec 1", column1 : "1", column2 : "1" },
			{ name : "Rec 2", column1 : "2", column2 : "2" },
			{ name : "Rec 3", column1 : "3", column2 : "3" },
			{ name : "Rec 4", column1 : "4", column2 : "4" },
			{ name : "Rec 5", column1 : "5", column2 : "5" },
			{ name : "Rec 6", column1 : "6", column2 : "6" },
			{ name : "Rec 7", column1 : "7", column2 : "7" },
			{ name : "Rec 8", column1 : "8", column2 : "8" },
			{ name : "Rec 9", column1 : "9", column2 : "9" }
		]
	};


	// Generic fields array to use in both store defs.
	var fields = [
		{ header: '商品名称', width: 120, align: 'center', dataIndex: 'product_name' },
        { header: '商品类型', width: 100, align: 'center', dataIndex: 'type_name' },
        { header: '商品品牌', width: 100, align: 'center', dataIndex: 'brand_name' },
        { header: '单位计量', width: 90, align: 'center', dataIndex: 'units' },
        { header: '规格', width: 120, align: 'center', dataIndex: 'spec' },
        { header: '过期日期', width: 100, align: 'center', dataIndex: 'expiry_date' },
		{ header: '自定义编码', width: 100, align: 'center', dataIndex: 'code' }
	];

    // create the data store
    var firstGridStore = new Ext.data.GroupingStore({
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


	// Column Model shortcut array
	var cols = [
		{ id : 'name', header: "编号", width: 160, sortable: true, dataIndex: 'id'},
		{ header: '商品名称', width: 120, align: 'center', dataIndex: 'product_name' },
        { header: '商品类型', width: 100, align: 'center', dataIndex: 'type_name' },
        { header: '商品品牌', width: 100, align: 'center', dataIndex: 'brand_name' },
        { header: '单位计量', width: 90, align: 'center', dataIndex: 'units' },
        { header: '规格', width: 120, align: 'center', dataIndex: 'spec' },
        { header: '过期日期', width: 100, align: 'center', dataIndex: 'expiry_date' },
		{ header: '自定义编码', width: 100, align: 'center', dataIndex: 'code' }
	];

	// declare the source Grid
    var firstGrid = new Ext.grid.GridPanel({
	    ddGroup : 'secondGridDDGroup',
	     tbar: [' 商品名称: ', new Ext.form.TextField({
            fieldLabel: '真实姓名',
            emptyText: '',
            name: 'search_name',
            id: 'search_name',
            width: 130
        }), '', new Ext.Button({
            text: '搜索',
            iconCls: 'icon_search',
            handler: function () {
                var sname = Ext.get("search_name").getValue();
                firstGridStore.load({ params: { start: 0, limit: 2000, pname: sname} });
            }
        }

			)],
        store  : firstGridStore,
        columns  : cols,
	    enableDragDrop : true,
        stripeRows : true,
        autoExpandColumn : 'name',
        title : '物品/商品列表(选择拖动到右边)'
    });

    var secondGridStore = new Ext.data.JsonStore({
        fields : fields,
		root   : 'records'
    });

    // create the destination Grid
    var secondGrid = new Ext.grid.GridPanel({
	    ddGroup : 'firstGridDDGroup',
	    tbar: [ '起始日期: ', new Ext.form.DateField({
            id: 'bdate',
            format: 'Y-m-d',
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
            text: '统计',
            iconCls: 'icon_chart',
            handler: function () {
                
                var bdates = Ext.get("bdate").getValue();
                var edates = Ext.get("edate").getValue();
                var pids="";
                  for (var aa = 0; aa < secondGridStore.getCount(); aa++) {
                        if(aa>11) break;
                        var a1 = secondGridStore.getAt(aa).get("id"); //if
                        pids=pids+","+a1;
                       }
                  
               window.location.href = "SalesReport_Report_ByProduct.aspx?bdate="+bdates+"&edate="+edates+"&pids="+pids;
                
                //ds.load({ params: { start: 0, limit: 20,bdate: bdates, edate: edates} });
            }
        })
        , '  ', new Ext.Button({
            text: '重选',
            iconCls: 'icon_reset',
            handler: function () {
               	 var sname = Ext.get("search_name").getValue();
                 firstGridStore.load({ params: { start: 0, limit: 2000, pname: sname} });
			     secondGridStore.removeAll();
            }
        })
        
         ],
        store  : secondGridStore,
        columns : cols,
	    enableDragDrop : true,
        stripeRows : true,
        autoExpandColumn : 'name',
        title : '已选择（最多选择12种）'
    });


	//Simple 'border layout' panel to house both grids
	var displayPanel = new Ext.Panel({
		width  : 950,
		height  : 550,
		layout : 'hbox',
		renderTo: 'panel',
		defaults: { flex : 1 }, //auto stretch
		layoutConfig:{ align : 'stretch' },
		items: [
			firstGrid,
			secondGrid
		]
		
	});

	// used to add records to the destination stores
	var blankRecord =  Ext.data.Record.create(fields);

        /****
        * Setup Drop Targets
        ***/
        // This will make sure we only drop to the  view scroller element
        var firstGridDropTargetEl =  firstGrid.getView().scroller.dom;
        var firstGridDropTarget = new Ext.dd.DropTarget(firstGridDropTargetEl, {
                ddGroup : 'firstGridDDGroup',
                notifyDrop : function(ddSource, e, data){
                        var records =  ddSource.dragData.selections;
                        Ext.each(records, ddSource.grid.store.remove, ddSource.grid.store);
                        firstGrid.store.add(records);
                        firstGrid.store.sort('name', 'ASC');
                        return true
                }
        });


        // This will make sure we only drop to the view scroller element
        var secondGridDropTargetEl = secondGrid.getView().scroller.dom;
        var secondGridDropTarget = new Ext.dd.DropTarget(secondGridDropTargetEl, {
                ddGroup    : 'secondGridDDGroup',
                notifyDrop : function(ddSource, e, data){
                        var records =  ddSource.dragData.selections;
                        Ext.each(records, ddSource.grid.store.remove, ddSource.grid.store);
                        secondGrid.store.add(records);
                        secondGrid.store.sort('name', 'ASC');
                        return true
                }
        });
        
        
        
        //加载数据
     firstGridStore.load({ params: { start: 0, limit: 2000} });

});
