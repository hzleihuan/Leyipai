Ext.onReady(function () {
    // 使用表单提示
    Ext.QuickTips.init();
    // turn on validation errors beside the field globally
    Ext.form.Field.prototype.msgTarget = 'side';

    var sm = new Ext.grid.CheckboxSelectionModel();

    var cm = new Ext.grid.ColumnModel([
	    new Ext.grid.RowNumberer(),
		sm,
		{ header: '品牌名称', width: 120, align: 'center', dataIndex: 'brand_name' },
        { header: '相关说明', width: 120, align: 'center', dataIndex: 'description' },
		{ header: '状态', width: 100, align: 'center', dataIndex: 'state', renderer: function (v) {
		    if (v == 0) {
		        return "正常使用";
		    } else if (v == 1) {
		        return "禁用中";
		    }
		}
		}



	]);

    cm.defaultSortable = true;

    var ds = new Ext.data.GroupingStore({
        proxy: new Ext.data.HttpProxy({
            url: 'brand/GetAllBrand.ashx'
        }),
        reader: new Ext.data.JsonReader({
            totalProperty: 'totalProperty',
            root: 'root'
        },
		[{ name: 'id', mapping: 'brand_id', type: 'string' },
		 { name: 'brand_name', type: 'string' },
         { name: 'description', type: 'string' },
         { name: 'state', type: 'string' }

		])
    });



    var paging = new Ext.PagingToolbar({
        pageSize: 100,
        store: ds,
        displayInfo: true,
        displayMsg: '显示第{0}条到{1}条记录，一共{2}条',
        items:
		["-", " ",
		    { text: '添加',
		        tooltip: '添加一条商品品牌',
		        iconCls: 'icon-add',
		        handler: function () {
		            add();
		        }
		    },
		"-", " ",
		    { text: '修改',
		        tooltip: '修改一条商品品牌',
		        iconCls: 'icon-edit',
		        handler: function () {
		            var _record = grid.getSelectionModel().getSelected();
		            if (sm.getCount() == 1) {
		                edit(_record);
		            } else
		                Ext.Msg.alert('提示', '请选择一条记录！');
		        }
		    },
		"-", " ", { text: '删除',
		    tooltip: '删除选择的商品品牌',
		    iconCls: 'icon-del',
		    handler: function () {

		        var _record = grid.getSelectionModel().getSelected();
		        if (sm.getCount() == 1) {
		            del(_record);
		        } else
		            Ext.Msg.alert('提示', '请选择一条记录！');
		       
		    }
		}
		],
        emptyMsg: "查询记录为空!"
    });

    var grid = new Ext.grid.EditorGridPanel({
        renderTo: 'grid-div',
        cm: cm,
        ds: ds,
        sm: sm,
        bbar: paging,
        height: 400,
        border: true,
        bodyStyle: 'width:960px',
        stripeRows: true,
        title: '商品品牌'
    });

    ds.load({ params: { start: 0, limit: 100} });

    //添加--------------------------------------------------------------------------add
    function add() {


        var window_add = new Ext.Window({
            title: '添加商品品牌',
            width: 340,
            height: 580,
            resizable: false,
            autoHeight: true,
            modal: true,
            closeAction: 'hide',
            listeners: {
                'hide': function () {
                    this.setTitle('添加商品品牌');
                }
            },
            items: [{
                xtype: "form",
                labelWidth: 70,
                labelAlign: 'right',
                url: 'brand/AddBrand.ashx',
                border: false,
                baseCls: 'x-plain',
                bodyStyle: 'padding:5px 5px 0',
                anchor: '100%',
                defaults: {
                    width: 317,
                    msgTarget: 'side'
                },
                items: [{
                    xtype: "fieldset",
                    title: '',
                    autoHeight: true,
                    items: [{
                        xtype: "textfield",
                        width: 200,
                        fieldLabel: "品牌名称",
                        name: "brand.brand_name",
                        regex: /^\S+$/,
                        regexText: "请输入名称！",
                        allowBlank: false,
                        blankText: '该字段不允许为空',
                        msgTarget: 'side',
                        maxLength: 50
                    }, {
                        xtype: "textfield",
                        width: 200,
                        fieldLabel: "描述",
                        name: "brand.description",
                        msgTarget: 'side',
                        maxLength: 50
                    }]
                }],
                buttonAlign: 'center',
                minButtonWidth: 60,
                buttons: [{
                    text: '添加',
                    handler: function (btn) {
                        var frm = this.ownerCt.ownerCt.form;
                        if (frm.isValid()) {
                            btn.disable();
                            var cnfield = frm.findField('brand.brand_name');
                            frm.submit({
                                waitTitle: '请稍候',
                                waitMsg: '正在提交表单数据,请稍候...',
                                success: function (form, action) {

                                    Ext.Msg.show({
                                        title: '成功提示',
                                        msg: '"' + cnfield.getValue()
													+ '" ' + '添加成功!',
                                        buttons: Ext.Msg.OK,
                                        fn: function () {
                                            cnfield.focus(true);
                                            btn.enable();
                                        },
                                        icon: Ext.Msg.INFO
                                    });
                                    cnfield.reset();
                                    window_add.hide();
                                    ds.load();
                                },
                                failure: function () {
                                    Ext.Msg.show({
                                        title: '错误提示',
                                        msg: '添加失败，请联系管理员!',
                                        buttons: Ext.Msg.OK,
                                        fn: function () {
                                            btn.enable();
                                        },
                                        icon: Ext.Msg.ERROR
                                    });
                                }
                            });
                        }
                    }
                }, {
                    text: '重置',
                    handler: function () {
                        this.ownerCt.ownerCt.form.reset();
                    }
                }, {
                    text: '取消',
                    handler: function () {
                        window_add.hide();
                    }
                }]
            }]
        });

        window_add.show();

    }
    //修改-------------------------------------------------------------------------edit
    function edit(record) {


        var window_add_edit = new Ext.Window({
            title: '修改品牌',
            width: 340,
            height: 580,
            resizable: false,
            autoHeight: true,
            modal: true,
            closeAction: 'hide',
            listeners: {
                'hide': function () {
                    this.setTitle('修改品牌');
                }
            },
            items: [{
                xtype: "form",
                labelWidth: 70,
                labelAlign: 'right',
                url: 'brand/UpdateBrand.ashx',
                border: false,
                baseCls: 'x-plain',
                bodyStyle: 'padding:5px 5px 0',
                anchor: '100%',
                defaults: {
                    width: 317,
                    msgTarget: 'side'
                },
                items: [{
                    xtype: "fieldset",
                    title: '',
                    autoHeight: true,
                    items: [{
                        xtype: 'hidden',
                        id: 'brand.brand_id',
                        name: 'brand.brand_id',
                        value: record.data.id
                    }, {
                        xtype: 'hidden',
                        id: 'brand.state',
                        name: 'brand.state',
                        value: record.data.state
                    }, {
                        xtype: "textfield",
                        width: 200,
                        fieldLabel: "品牌名称",
                        name: "brand.brand_name",
                        regex: /^\S+$/,
                        regexText: "请输入名称！",
                        allowBlank: false,
                        blankText: '该字段不允许为空',
                        msgTarget: 'side',
                        maxLength: 50,
                        value: record.data.brand_name
                    }, {
                        xtype: "textfield",
                        width: 200,
                        fieldLabel: "描述",
                        name: "brand.description",
                        msgTarget: 'side',
                        maxLength: 250,
                        value: record.data.description
                    }, {
                        width: 200,
                        anchor: "94%",
                        xtype: "combo",
                        fieldLabel: "状  态",
                        name: "brand.statesText",
                        store: new Ext.data.SimpleStore({
                            fields: ["value", "text"],
                            data: [['0', '正常使用'], ['1', '禁止使用']]
                        }),
                        displayField: 'text',
                        valueField: 'value',
                        mode: 'local',
                        emptyText: '请选择状态',
                        allowBlank: false,
                        blankText: '该字段不允许为空',
                        msgTarget: 'side',
                        editable: false,
                        triggerAction: 'all',
                        listWidth: 200,
                        listeners: {
                            select: function (combo, record, index) {
                                //alert(this.getValue());
                                this.ownerCt.ownerCt.form.findField('brand.state').setValue(this.getValue());
                            }
                        }

                    }]
                }],
                buttonAlign: 'center',
                minButtonWidth: 60,
                buttons: [{
                    text: '修改',
                    handler: function (btn) {
                        var frm = this.ownerCt.ownerCt.form;
                        if (frm.isValid()) {
                            btn.disable();
                            var cnfield = frm.findField('brand.brand_name');
                            frm.submit({
                                waitTitle: '请稍候',
                                waitMsg: '正在提交表单数据,请稍候...',
                                success: function (form, action) {

                                    Ext.Msg.show({
                                        title: '成功提示',
                                        msg: '"' + cnfield.getValue()
													+ '" ' + '修改成功!',
                                        buttons: Ext.Msg.OK,
                                        fn: function () {
                                            cnfield.focus(true);
                                            btn.enable();
                                        },
                                        icon: Ext.Msg.INFO
                                    });
                                    cnfield.reset();
                                    window_add_edit.hide();
                                    ds.load();
                                },
                                failure: function () {
                                    Ext.Msg.show({
                                        title: '错误提示',
                                        msg: '添加失败，请联系管理员!',
                                        buttons: Ext.Msg.OK,
                                        fn: function () {
                                            btn.enable();
                                        },
                                        icon: Ext.Msg.ERROR
                                    });
                                }
                            });
                        }
                    }
                }, {
                    text: '取消',
                    handler: function () {
                        window_add_edit.hide();
                    }
                }]
            }]
        });

        window_add_edit.show();

    }


    function del(record) {

        var myMask = new Ext.LoadMask(Ext.getBody(), {
            msg: "Please wait..."
        });
        myMask.show();
        Ext.Ajax.request({
            url: 'brand/Delbrand.ashx',
            params: {
                id: record.data.id
            },
            success: function (response) {
                var success = Ext.util.JSON.decode(response.responseText).success;
                if (success) {
                    myMask.hide();
                    Ext.MessageBox.show({
                        title: '成功提示',
                        msg: '删除成功',
                        buttons: Ext.MessageBox.OK,
                        icon: Ext.MessageBox.INFO,
                        fn: function () {
                            ds.load();

                        }
                    });
                } else {
                    myMask.hide();
                    Ext.MessageBox.show({
                        title: '失败提示',
                        msg: '删除失败,请检查是否关联了角色信息',
                        buttons: Ext.MessageBox.OK,
                        icon: Ext.MessageBox.ERROR
                    });

                }
            },
            failure: function () {
                myMask.hide();
                Ext.MessageBox.show({
                    title: '失败提示',
                    msg: '系统错误，请联系管理员',
                    buttons: Ext.MessageBox.OK,
                    icon: Ext.MessageBox.ERROR
                });

            }
        });

    }




});