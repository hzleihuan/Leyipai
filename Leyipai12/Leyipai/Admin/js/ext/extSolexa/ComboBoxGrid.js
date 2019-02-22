/**
 * 下拉表格ComboBoxGrid
 * 
 * @extend Ext.form.ComboBox
 * 
 * 用法： new ComboBoxGrid({ 
			  valueField:"id",
			  displayField:"customerShortName", 
			  hiddenName:'custId',								//设置隐藏域,不然取值都是文本值
			  gridId:"custtable",
			  cascadeToFormFields : {
									panel : 'objectForm', 
									formFieldsMapping : [
										['itemId', 'itemMxId'], //级联record到panel中 [formfield,recordField]
										['sampleConnMan', 'itemMxName']
									]							
								},
			  fieldLabel : "客户名称",
			  grid:grid,											//grid是一个已定义好的表格组件
			  listWidth : 250 ,
			  gridWidth:400,
			  gridHeight:400,
			 }
 * 
 */
ComboBoxGrid = function(cfg) {
	// 前台传入grid组件
	this.grid = cfg.grid;
	Ext.apply(this, cfg);
	ComboBoxGrid.superclass.constructor.call(this, {
				editable : true, // 禁止手写及联想功能
				mode : 'local',
				triggerAction : 'all',
				store : new Ext.data.SimpleStore({
							fields : [],
							data : [[]]
						}),
				maxHeight : 500,
				selectedClass : '',
				onSelect : Ext.emptyFn,
				emptyText : '请选择...',
				gridWidth : cfg.gridWidth || 400,
				gridHeight : cfg.gridHeight || 450,
				listAlign : 'tr-br',
				listWidth : 300,
				resizable : false
			});
};
Ext.extend(ComboBoxGrid, Ext.form.ComboBox, {
			gridClk : function(grid, rowIndex, e) {
				var record = grid.getStore().getAt(rowIndex);
				var idValue = record.get(this.valueField);
				var displayValue = record.get(this.displayField);

				try {
					var cascadeToFormFields = this.cascadeToFormFields;
					var panel = cascadeToFormFields.panel;
					var form = Ext.getCmp(panel).getForm();
					for (var i in cascadeToFormFields.formFieldsMapping) {
						t1 = cascadeToFormFields.formFieldsMapping[i][0];
						t2 = cascadeToFormFields.formFieldsMapping[i][1];
						form.findField(t1).setValue(record.get(t2))
					}

				} catch (e) {

				}
				this.setRawValue(displayValue);
				this.setValue(idValue);
				this.collapse();
				// this.fireEvent('gridselected', grid.getRecord(rowIndex));
			},
			initLayout : function() {
				this.grid.autoScroll = true;
				this.grid.height = this.gridHeight;
				this.grid.width = this.gridWidth;
				this.grid.containerScroll = false;
				this.grid.border = false;
				this.listWidth = this.grid.width + 3;
			},
			initComponent : function() {
				ComboBoxGrid.superclass.initComponent.call(this);
				this.initLayout();
				this.tplId = Ext.id();
				this.tpl = '<div id="' + this.tplId + '" style="height:'
						+ (this.gridHeight || 180)
						+ '";overflow:hidden;"></div>';
				// Add Event
				// this.addEvents('gridselected');
			},
			listeners : {
				'expand' : {
					fn : function() {
						// var pageSize = this.grid.getBottomToolbar().pageSize;
						if (this.tplId) {
							this.initLayout();
							this.grid.render(this.tplId);

							// this.grid.getStore().load({
							// params:{
							// start:0,
							// limit:pageSize
							// }
							// })
							// 设置ComboBox的store使得设置的时候能够取到真实的Value
							this.store = this.grid.store;
							// this.store.reload();
							// this.store.reload();
							if (this.store.getCount() == 0) {
								this.store.add(new Ext.data.Record([{}]));
							}
							this.grid.on('rowclick', this.gridClk, this);
						}
						this.grid.show();
					}
				},
				'render' : {
					fn : function() {
					}
				},
				'beforedestroy' : {
					fn : function(cmp) {
						this.purgeListeners();
						this.grid.purgeListeners();
					}
				},
				'collapse' : {
					fn : function(cmp) {
						/**
						 * 防止当store的记录为0时不出现下拉的状况
						 */
						if (this.grid.store.getCount() == 0) {
							this.store.add(new Ext.data.Record([{}]));
						}
					}
				}
			}
		});