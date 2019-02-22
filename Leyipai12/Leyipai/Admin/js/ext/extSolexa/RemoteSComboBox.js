/**
 * 配置项 url:远程读取的数据 cmName:下拉选择框的name和id fieldLabel:显现在这个下拉选择框的文本
 * 
 */
function getRemoteSComboBox(config) {
	return new Ext.form.ComboBox({
				store :config.store|| new Ext.data.Store({
							proxy : new Ext.data.HttpProxy({
										url : config.url,
										method : 'POST'
									}),
							baseParams : config.urlParams || {},
							reader : config.reader || new Ext.data.ArrayReader({
										fields : [config.cmName, 'fValue'],
										root : "data"
									})
						}),

				valueField : config.valueField||config.cmName,
				displayField : config.displayField||'fValue',
				typeAhead : true,
				mode : 'local',
				width : (config.anchor) ?undefined:(config.width||130),
				fieldLabel : config.fieldLabel,
				disabled:config.disabled||false,
				id : config.id,
				name : config.cmName,
				forceSelection : true,
				triggerAction : 'all',
				hiddenName : config.cmName,
				value : config.value,
				anchor:config.anchor,
				listeners : {
					render : function() {
						if (config.notAutoLoad) {
						} else {
							this.store.load();
						}
					},
					select : function(combo, record, index) {
						if (config.select) {
							config.select(combo, record, index);
						}
					}
				}
			});
}

function getRemotePageComboBox(config) {
	var store = new Ext.data.Store({
				proxy : new Ext.data.HttpProxy({
							url : config.url,
							method : 'POST'
						}),
				reader : new Ext.data.ArrayReader({
							fields : [config.cmName, 'fValue'],
							root : "data"
						})
			});
	store.load({
				params : {
					start : 0,
					limit : 6
				}
			});
	return new Ext.form.ComboBox({
				store : store,
				valueField : config.cmName,
				displayField : 'fValue',
				typeAhead : true,
				mode : 'local',
				width : config.width || 130,
				fieldLabel : config.fieldLabel,
				id : config.id,
				name : config.cmName,
				forceSelection : true,
				triggerAction : 'all',
				pageSize : 8,// 每页显示8条记录
				hiddenName : config.cmName,
				value : config.value,
				listeners : {
					render : function() {
						if (config.notAutoLoad) {
						} else {
							this.store.load({
										params : {
											start : 0,
											limit : 6
										}
									});
						}
					},
					select : function(combo, record, index) {
						if (config.select) {
							config.select(combo, record, index);
						}
					}
				}

			});
}

var TYPEURL = "ibUI/sample/sampleManager/assitprocess/getTypeContrl.jsp?type=receive_man"; // 获得所有下拉列表数据
// URL
function getDynaComboBox(config) {
	return new Ext.form.ComboBox({
		store : new Ext.data.Store({
			proxy : new Ext.data.HttpProxy({
				url : 'ibUI/sample/sampleManager/assitprocess/getTypeContrl.jsp?paramType='
						+ config.paramType
			}),
			reader : new Ext.data.JsonReader({
						root : 'results'
					}, [{
								name : 'CODE'
							}, {
								name : 'NAME'
							}]),
			remoteStore : true
		}),
		width : config.width || 200,
		valueField : "NAME",
		selectOnFocus : true,
		mode : 'remote',// 远程，还有local
		displayField : 'NAME',
		typeAhead : true,
		width : 130,
		fieldLabel : config.fieldLabel,
		name : config.cmName,
		forceSelection : true,
		triggerAction : 'all',
		hiddenName : config.cmName,
		value : config.value
	});
}