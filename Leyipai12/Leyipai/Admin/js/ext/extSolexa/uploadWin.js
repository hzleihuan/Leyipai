function getUploadWin(config) {

	var params = config.params;
	var tip_message = "t" + new Date().getTime();
	var uploadForm = new Ext.FormPanel({
		labelWidth : 75,
		frame : true,
		bodyStyle : 'padding:5px 5px 0',
		width : '100%',
		fileUpload : true,
		height : 180,
		margins : '5 5 0',
		region : 'north',
		split : true,
		layout : 'column',
		collapsible : true,
		items : [{
			columnWidth : .9,
			layout : 'form',
			items : [{
						xtype : 'textfield',
						fieldLabel : '文件',
						inputType : 'file',
						name : 'uploadFile',
						anchor : '90%'
					}, {
						xtype : 'panel',
						html : '<span id=' + tip_message
								+ ' style="color:red;font-size:13"></span>'
					}]
		}],

		buttons : [{
			text : '上传',
			handler : function() {
				if (uploadForm.getForm().isValid()) {

					document.getElementById(tip_message).innerHTML = '正在上传....';
					uploadForm.getForm().submit({
						url : config.saveUrl,
						params : params || {},
						success : function(form, action) {
							document.getElementById(tip_message).innerHTML = '后台处理完毕,'
									+ action.result.msg;
									
						    if(config.callback){
						    
						    	config.callback(form,action);
						    	
						    }
							if (config.setValueId) {
								Ext.getCmp(config.setValueId)
										.setValue(action.result.msgValue);
							}
						}
					});
				}
			}
		}, {
			text : '关闭',
			handler : function() {
				win.hide();
			}
		}],
		listeners : {
			"render" : function() {

			}
		}
	});

	var win = new Ext.Window({
				title : '上传文件并处理数据',
				renderTo : Ext.getBody(),
				layout : 'fit',
				width : 500,
				height : 160,
				closeAction : 'hide',
				plain : true,
				items : uploadForm
			});

	win.reset = function() {
		uploadForm.getForm().reset();
		document.getElementById(tip_message).innerHTML = '请选择文件，注意只支持xls格式文件.'
	};

	win.setParams = function(p) {
		params = p;
	}
	return win;
}