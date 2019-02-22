/*!
 * Ext JS Library 3.2.0
 * Copyright(c) 2006-2010 Ext JS, Inc.
 * licensing@extjs.com
 * http://www.extjs.com/license
 */

//
// This is the main layout definition.
//
Ext.onReady(function(){
	
	Ext.QuickTips.init();
	
	var initheight=window.screen.height - 320;
	
	if(initheight==null || initheight<200) initheight=400;
	var sm = new Ext.grid.CheckboxSelectionModel();
    var cm = new Ext.grid.ColumnModel([
	    new Ext.grid.RowNumberer(),
	    sm,
		{ header: '仓库名称', width: 100, align: 'center', dataIndex: 'depot_name' },
		{ header: '状态', width: 80, align: 'center', dataIndex: 'state', renderer: function (v) {
		    if (v == 0) {
		        return "正常";
		    } else if (v == 1) {
		        return "禁用中";
		    }
		}
		}

	]);

    cm.defaultSortable = true;

    var ds = new Ext.data.GroupingStore({
        proxy: new Ext.data.HttpProxy({
            url: '../c/depot/getAllDepot.ashx'
        }),
        reader: new Ext.data.JsonReader({
            totalProperty: 'totalProperty',
            root: 'root'
        },
		[{ name: 'id', mapping: 'depot_id', type: 'string' },
		 { name: 'depot_name', type: 'string' },
         { name: 'state', type: 'string' }

		])
    });

    var depotgrid = new Ext.grid.EditorGridPanel({
        cm: cm,
        sm: sm,
        ds: ds,
        applyTo: 'left-div',
        autoScroll : true,
         height: initheight

  
  
    });
    
   depotgrid.addListener('rowclick', rowclickFn);      
     
function rowclickFn(grid, rowindex, e){  
     var _record = depotgrid.getSelectionModel().getSelected();    
    dss.load({ params: { depot_id: _record.data.id} });    
     //alert(rowindex);  
}   

    ds.load({ params: { start: 0, limit: 100} });

	
	
	
	//-------------------------------------------------------详细商品列表
	
	var sms = new Ext.grid.CheckboxSelectionModel();
	var cms = new Ext.grid.ColumnModel([
	    new Ext.grid.RowNumberer(),
	    sms,
		{ header: '仓库名称', width: 100, align: 'center', dataIndex: 'depot_name' },
		{ header: '商品名称', width: 100, align: 'center', dataIndex: 'product_name' },
		{ header: '商品数量', width: 100, align: 'center', dataIndex: 'quantity' }
	

	]);
	cms.defaultSortable = true;
	
   var dss = new Ext.data.GroupingStore({
        proxy: new Ext.data.HttpProxy({
            url: 'ajax/findProductsByDepot.ashx'
        }),
        reader: new Ext.data.JsonReader({
            totalProperty: 'totalProperty',
            root: 'root'
        },
		[{ name: 'id', mapping: 'depot_id', type: 'string' },
		 { name: 'depot_name', type: 'string' },
         { name: 'product_name', type: 'string' },
         { name: 'quantity', type: 'string' }

		])
    });
    
    var productsgrid = new Ext.grid.EditorGridPanel({
        cm: cms,
        sm: sms,
        ds: dss,
        autoScroll : true,
        height: initheight

  
  
    });
//------------------------------------------------------------------------------
	
	
	
	
	
	var contentPanel = {
		id: 'content-panel',
		region: 'center', // this is what makes this panel into a region within the containing layout
		layout: 'card',
		margins: '2 5 5 0',
		activeItem: 0,
		border: false,
		items: [{
		id: 'mian-panel',
        title: '商品列表',
        bodyStyle: 'padding-bottom:15px;background:#eee;',
		autoScroll: true,
		items:[productsgrid]
       }]
	};
   
	// This is the Details panel that contains the description for each example layout.depotListPanel
	
	var depotListPanel = {
		id: 'details-panel',
        title: '仓库列表',
        region: 'center',
        bodyStyle: 'padding-bottom:15px;',
		autoScroll: true,
		items:[depotgrid]
    };
	
	// Finally, build the main layout once all the pieces are ready.  This is also a good
	// example of putting together a full-screen BorderLayout within a Viewport.
    new Ext.Viewport({
		layout: 'border',
		title: 'Ext Layout Browser',
		 height: 500,
		items: [{
			layout: 'border',
	    	id: 'layout-browser',
	        region:'west',
	        border: false,
	        split:true,
			margins: '2 0 5 5',
	        width: 275,
	        minSize: 100,
	        maxSize: 500,
			items: [depotListPanel]
		},
			contentPanel
		],
        renderTo: Ext.getBody()
    });
});
