/**
 * 配置项 data:下拉选中框所有选择的数据,格式[fid,fValue]的二维数组 cmName:下拉选择框的name和id tfName:文本填写框
 */

function getSelectAndTextField(config) {

	var cm = new Ext.form.ComboBox({
				store : new Ext.data.ArrayStore({
							fields : [config.cmName, 'fValue'],
							data : config.data
						}),
				valueField : config.cmName,
				displayField : 'fValue',
				typeAhead : true,
				mode : 'local',
				hiddenName : config.cmName,
				triggerAction : 'all',
				selectOnFocus : true,
				width : 130,
				hideLabel : true,
				name : config.cmName,
				emptyText : config.emptyText || '请选择',
				listeners : {
					afterrender : function(combo) {
						if (config.selectItem!=undefined){
							cm.setValue(config.data[config.selectItem][0]);
						}
					}
				}
			});

	return {
		layout : 'column',
		xtype : 'panel',
		width : 300,
		items : [{
					columnWidth : .45,
					layout : 'form',
					width : 150,
					items : [cm]
				}, {
					columnWidth : .1,
					layout : 'form',
					width : 20,
					items : [{
								xtype : 'label',
								width : 10,
								text : ':',
								hideLabel : true
							}]
				}, {
					columnWidth : .45,
					layout : 'form',
					width : 140,
					items : [{
								xtype : 'textfield',
								name : config.tfName,
								hideLabel : true
							}]
				}]
	};

}