var GridHeadPlugin = {

	/**
	*  初始化用户定义的表头
	*
	**/
   initHeads:function(grid,module){
   
       var colModel=grid.getColumnModel();
            
      var count=colModel.getColumnCount();
     
      Ext.Ajax.request({
                           url :BasicUrl+"/gridConfig.htm?cmd=getConfig" ,    
                                params:{categoryName:module},
                                method: 'POST',   
                                success: function ( result, request ) {    
                                
                                  var  returnData= Ext.util.JSON.decode(result.responseText);
                                  
                                  var ininData=returnData.object;
                                  
                                  for(var i=0;i<count;i++){
                       
				                          var flag=false;
				                          
				                          for(var key in ininData){
				                              
				                            if(colModel.getColumnId(i)==ininData[key]){
							                  
							                  flag=true;
							                  
							                  colModel.setHidden(i,false);
							                  
							                  break;
							                  
							                 }
				                          
				                          }
				                          
				                          if(!flag){
				                          
				                            if(colModel.getColumnId(i)!='checker' &&colModel.getColumnId(i)!='numberer'){
				                            
				                                colModel.setHidden(i,true);
				                            }
				                          
				                          }
							            }
  
                                 },   
                                failure: function ( result, request) {   
                                
                       
                         }    
                  }); 
     
     
   
   },
   
   
	/**
	*  保存用户定义的表头
	*
	**/
   settingHeads:function(grid,module){
   
   
            
            var colModel=grid.getColumnModel();
            
            var count=colModel.getColumnCount();
            
            var data =new Array();
            
            for(var i=0;i<count;i++){
            
              if(colModel.getColumnHeader(i)&&colModel.getColumnId(i)!='checker' &&colModel.getColumnId(i)!='numberer'){
                var o={};
                o.i=i;
                o.header=colModel.getColumnHeader(i);
                o.id=colModel.getColumnId(i);
                o.hidden=colModel.isHidden(i);
                data.push(o);
              }
            }
            
            var checkBoxs =new Array();
            
            for(var i=0;i<data.length;i++){
              
              var o={};
              
              o.boxLabel=data[i].header;
              
              o.name=data[i].id;
              
              o.checked=!data[i].hidden;
              
              checkBoxs.push(o);
            
            }
            
            
            var configGridHead = new Ext.FormPanel({
		        labelWidth: 75, // label settings here cascade unless overridden
		        frame:true,
		        bodyStyle:'padding:5px 5px 0',
		        width: '100%',
		        margins: '5 5 0',
		        region: 'north',
		        split: true,
		        collapsible: true,
		         items: [{
		            layout:'column',
		            items:[{
			                columnWidth:1,
			                layout: 'form',
			                items:[ new Ext.form.CheckboxGroup({
								    xtype: 'checkboxgroup',
								    fieldLabel: '显示列',
								    columns: 3,
								    items:checkBoxs
								})]
			            }]
		        }],
		
		        buttons: [{
		           text: '保存',
		           handler: function(){

                      var temp= configGridHead.getForm().getValues();
                      
                      var hideArray=new Array();
                      
                      var showArray=new Array();
                      
             
                       for(var i=0;i<count;i++){
                       
                          var flag=false;
                          
                          for(var key in temp){
                              
                            if(colModel.getColumnId(i)==key){
			                  
			                  flag=true;
			                  
			                //  showArray.push(i);
			                  colModel.setHidden(i,false);
			                  
			                  break;
			                  
			                 }
                          
                          }
                          
                          if(!flag){
                          
                            if(colModel.getColumnId(i)!='checker' &&colModel.getColumnId(i)!='numberer'){
                            
                            	//hideArray.push(i);
                                colModel.setHidden(i,true);
                            }
                          
                          }
			            }
			       
                        for(var key in showArray){
		                
		                // colModel.setHidden(key,false);	
		              
		               }
		               
			            for(var key in hideArray){ 
			            
			           //  colModel.setHidden(key,true); 
			           
			            }
			            
		             
		            
			           win.hide();
			           //发ajax到后台，修改个性化数据
			           Ext.Ajax.request({
                                url :BasicUrl+"/gridConfig.htm?cmd=save" ,    
                                params:{headers:Ext.util.JSON.encode(temp),categoryName:module},
                                method: 'POST',   
                                success: function ( result, request ) {    
                                
                                 win.close();
                       
                                 },   
                                failure: function ( result, request) {   
                                
                                 win.show();
                                 
                                 Ext.MessageBox.alert("提示","设置失败");
                       
                         }    
                  }); 
			           
			           
			            
                      
		            }  
		        }]
		    });
		    
		     var win=  new Ext.Window({
                title:'设置自定义表头',
                renderTo:Ext.getBody(),
                layout:'fit',
                width:500,
                height:300,
                closeAction:'close',
                plain: true,
                items:configGridHead
	            }); 
	            
	         win.show();   
   
   }
   
}


