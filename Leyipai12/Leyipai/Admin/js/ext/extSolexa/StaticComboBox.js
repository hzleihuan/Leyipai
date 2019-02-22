function getStaticComboBox(config) {

	return new Ext.form.ComboBox({
				store :config.store|| new Ext.data.ArrayStore({
							fields : [config.cmName, 'fValue'],
							data : config.data
						}),
				valueField : config.cmName,
				displayField : 'fValue',
				typeAhead : true,
				mode : 'local',
				notClear : config.notClear, // 为true，调用BasicForm.clear()不清空默认值
				width : (config.anchor) ?undefined:(config.width||130),
				fieldLabel : config.fieldLabel,
				name : config.cmName,
				forceSelection : true,
				id : config.id,
				triggerAction : 'all',
				anchor : config.anchor,
				hiddenName : config.cmName,
				value : config.value,
				disabled : config.disabled || false,
				listeners : {
					afterrender : function(combo) {
						if (config.selectItem != undefined) {
							combo.setValue(config.data[config.selectItem][0]);
						}
					}
				}
			});

}