 /*
 会mask住屏幕的ajax, 一般处理批数据会调用.

 配置项:
 url:ajax请求的路径
 params:{itemMxIds:Ext.util.JSON.encode(itemMxIds),selected:true};
 success:function(returnData){}                                
 */
 function MashAjax(config){
 
 var myMask = new Ext.LoadMask(Ext.getBody(), {msg:"正在处理 请稍后........."});
                
               myMask.show();
               
               Ext.Ajax.request({url :config.url ,    
                                params:config.params,
                                method: 'POST',   
                                success: function ( result, request ) {    
                                
                                var  returnData= Ext.util.JSON.decode(result.responseText);
                                 
                                 
                                var t = new Ext.QuickTip({
                                      maxWidth:550,
                                      html:'<div style="background-color:#66CCFF">'+returnData.result+'</div>',
                                      targetXY:[300,300],
                                      autoHide:false});
                                      t.show();
                                 
                                   config.success(returnData);
                                 
                                   myMask.hide();
                                 },   
                                failure: function ( result, request) {    
                                 myMask.hide();
                                 var t = new Ext.QuickTip({
                                 maxWidth:550,
                                 html:'<div style="background-color:#66CCFF">操作失败</div>',
                                 targetXY:[300,300],
                                 autoHide:false});
                                 t.show();
  
                                  }    
                               }); 
 
 
 }
 