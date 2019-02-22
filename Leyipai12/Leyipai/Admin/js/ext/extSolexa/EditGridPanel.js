/**
[{
        name: 'budgetInserDate',
        type: 'date',
        dateFormat:'Y-m-d H:i:s'
    }, {
        name: 'produceName',
        type: 'string'
    }, {
        name: 'produceCode',
        type: 'string'
    },{
        name: 'produceType',
        type: 'string'
    },{
        name: 'produceExcuteFlag',
        type: 'string'
    },{
        name: 'budgetInserMan',
        type: 'string'
    },{
        name: 'islock',
        type: 'string'
    },{
        name: 'produceId',
        type: 'string'
    },{
        name: 'itemId',
        type: 'string'
    }]
    
    [
        {
            ref: '../submitBtn',
            iconCls: 'icon-user-save',
            text: '下达执行单',
            disabled:true,
            handler: function(){
            
              Ext.MessageBox.confirm('确认', '你确认下达你选择的任务单吗?', function(btn, text){
     
                     if(btn=='yes'){
                     
                               proudceSubmit();
                     
                     }

                 });
                
            }
        },{
            ref: '../cancelBtn',
            iconCls: 'icon-user-save',
            text: '任务单退回',
            disabled:true,
            handler: function(){
            
            
             Ext.MessageBox.confirm('确认', '你确认撤销你选择的任务单吗?', function(btn, text){
     
                     if(btn=='yes'){
                        produceCancle();
                     }
                 });
            
                
            }
        }

        ]
        
        
         {
            id: 'budgetInserDate',
            header: '任务单下达日期',
            dataIndex: 'budgetInserDate',
            width: 120,
            sortable: true,
            renderer: Ext.util.Format.dateRenderer('Y-m-d H:i:s')
            
        },
        {
            id: 'produceName',
            header: '任务单名字',
            dataIndex: 'produceName',
            width: 220,
            sortable: true,
            renderer:function(value,metadata,record,rowIndex,colIndex,store){
               
              var productId=record.get("produceId");
              
              return "<a href='/newbms/workflow/bms/produce/produce_views.jsp?produce_id="+productId+"' target='_blank' style='text-decoration:none;'>"+value+"</a>";
               
            }
            
          
        },{
            id: 'produceCode',
            header: '任务单编号',
            dataIndex: 'produceCode',
            width: 80,
            sortable: true         
            

        },{
            id: 'produceType',
            header: '任务单类型',
            dataIndex: 'produceType',
            width: 80,
            sortable: true
        },{
            id: 'budgetInserMan',
            header: '制表人',
            dataIndex: 'budgetInserMan',
            width: 150,
            sortable: true
        },{
            id: 'produceId',
            dataIndex: 'produceId',
            hidden:true
            
        },{
            id: 'itemId',
            dataIndex: 'itemId',
            hidden:true
        }  
    recordDef
    url
    urlParams
    gridId
    tbar
    bbar
    columns
*/
//
function getEditGridPanel(config){
    
    var Employee = Ext.data.Record.create(config.recordDef);

   //定义表格的数据源 totalProperty数据的总记录数,root数据体
    var store = new Ext.data.Store({
        url:config.url,
        baseParams:config.urlParams||{},
        reader: new Ext.data.JsonReader({
        fields: Employee,
        totalProperty:"count",
        root:"data"
        }),
       remoteSort:config.remote||false
    });
   //定义列选择器
    var sm = new Ext.grid.CheckboxSelectionModel();
    
    var rn= new Ext.grid.RowNumberer();
    //定义表格
    var columns1=[sm,rn];
    
    columns1=columns1.concat(config.columns);
    
    var grid = new Ext.grid.EditorGridPanel({
        store: store,
        width: config.width||800,
        height:config.height||500,
        id:config.gridId,
        title:config.title||"",
        split:config.split||false,
        sm: sm,
        region:config.region||'center',
        margins: '0 5 5 5',
        tbar:config.tbar||[],
        bbar:config.notbbar?null:new Ext.PagingToolbar({
            pageSize: 20,
            store: store,
            displayInfo: true,
            displayMsg: '显示记录从 {0} 到 {1} ,共记录数 {2}',
            emptyMsg: "没有记录显示"
        }),

        columns:columns1,  
        listeners : {
            render: function(){
                 //this.store.load({params: {start: 0, limit: 20}});
            }
         }
    });   
    
    return grid;
}
