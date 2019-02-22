/**
url
leftItems
rightItems
successFn
[{
    xtype:'textfield',
                    fieldLabel: '任务单名字',
                    name: 'produceName',
                    anchor:'95%'
                },getBetweenDatePanel({
                    fieldLabel:'制表日期',
                    startName:'produceInserDateEnd',
                    endName:'produceInserDateBegin'
                })]
*/



function getSearchFormPanel(config){
 var searchForm = new Ext.FormPanel({
        labelWidth: 75, // label settings here cascade unless overridden
        url:config.url,
        frame:true,
        title: '搜索条件',
        bodyStyle:'padding:5px 5px 0',
        width: '100%',
        height:180,
        margins: '5 5 0',
        region: 'north',
        split: true,
        collapsible: true,
         items: [{
            layout:'column',
            items:[{
                columnWidth:.5,
                layout: 'form',
                items:config.leftItems
            },{
                columnWidth:.5,
                layout: 'form',
                items:config.rightItems
            }]
        }],

        buttons: [{
            text: '搜索',
            handler: function(){
                searchForm.getForm().submit({
                success: function(form, action) {
                   config.successFn(form,action);
                 }
                });
            }
            
            
        },{
            text: '重设',
            handler: function(){
                searchForm.getForm().reset();
            }
        }],
     listeners : {
        "render" : function(){       
           searchForm.getForm().submit({
                success: function(form, action) {
                   config.successFn(form,action);
                 }
                });

            }
         }
    });

 
  return searchForm;
}