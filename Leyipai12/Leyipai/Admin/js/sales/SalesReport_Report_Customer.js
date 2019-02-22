/*!
 */
Ext.onReady(function(){



	// Generic fields array to use in both store defs.
	var fields = [
		{ header: '客户帐号', width: 120, align: 'center', dataIndex: 'username' },
        { header: '客户名称', width: 100, align: 'center', dataIndex: 'c_name' },
        { header: '客户信誉', width: 100, align: 'center', dataIndex: 'rank' },
        { header: '联系人', width: 90, align: 'center', dataIndex: 'link_men' },
        { header: '银行账户', width: 120, align: 'center', dataIndex: 'account_info' },
        { header: 'Email', width: 100, align: 'center', dataIndex: 'email' },
		{ header: '状态', width: 100, align: 'center', dataIndex: 'state', renderer: function (v) {
		    if (v == 0) {
		        return "正常使用";
		    } else if (v == 1) {
		        return "禁用中";
		    }
		}
		}
	];

    // create the data store
    var firstGridStore = new Ext.data.GroupingStore({
        proxy: new Ext.data.HttpProxy({
            url: '../c/customer/getAllCustomer.ashx'
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

	// Column Model shortcut array
	var cols = [
		{ id : 'name', header: "编号", width: 50, sortable: true, dataIndex: 'id'},
		{ header: '客户帐号', width: 120, align: 'center', dataIndex: 'username' },
        { header: '客户名称', width: 100, align: 'center', dataIndex: 'c_name' },
        { header: '客户信誉', width: 100, align: 'center', dataIndex: 'rank' },
        { header: '联系人', width: 90, align: 'center', dataIndex: 'link_men' },
        { header: '银行账户', width: 120, align: 'center', dataIndex: 'account_info' },
        { header: 'Email', width: 100, align: 'center', dataIndex: 'email' },
		{ header: '状态', width: 100, align: 'center', dataIndex: 'state', renderer: function (v) {
		    if (v == 0) {
		        return "正常使用";
		    } else if (v == 1) {
		        return "禁用中";
		    }
		}
		}
	];

	// declare the source Grid
    var firstGrid = new Ext.grid.GridPanel({
	    ddGroup : 'secondGridDDGroup',
        store  : firstGridStore,
        columns  : cols,
	    enableDragDrop : true,
        stripeRows : true,
        autoExpandColumn : 'name',
        title : '客户列表(选择拖动到右边)'
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
                  
              window.location.href = "SalesReport_Report_ByCustomer.aspx?bdate="+bdates+"&edate="+edates+"&cids="+pids;
                
                //ds.load({ params: { start: 0, limit: 20,bdate: bdates, edate: edates} });
            }
        })
        , '  ', new Ext.Button({
            text: '重选',
            iconCls: 'icon_reset',
            handler: function () {
                 firstGridStore.load({ params: { start: 0, limit: 2000} });
			     secondGridStore.removeAll();
            }
        })
        
         ],
        store  : secondGridStore,
        columns : cols,
	    enableDragDrop : true,
        stripeRows : true,
        autoExpandColumn : 'name',
        title : '已选择(最多12项)'
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
