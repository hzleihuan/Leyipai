Ext.onReady(function () {
    // 使用表单提示
    Ext.QuickTips.init();
    // turn on validation errors beside the field globally
    Ext.form.Field.prototype.msgTarget = 'side';

    var sm = new Ext.grid.CheckboxSelectionModel();

    var cm = new Ext.grid.ColumnModel([
	    new Ext.grid.RowNumberer(),
		sm,
		{ header: '帐号', width: 120, align: 'center', dataIndex: 'username' },
        { header: '名称', width: 120, align: 'center', dataIndex: 'c_name' },
        { header: '类别', width: 120, align: 'center', dataIndex: 'types' },
        { header: '信誉', width: 120, align: 'center', dataIndex: 'rank' },
        { header: '电话', width: 120, align: 'center', dataIndex: 'tel' },
        { header: '手机', width: 120, align: 'center', dataIndex: 'mobile' },
        { header: 'Email', width: 120, align: 'center', dataIndex: 'email' },
        { header: '联系人', width: 120, align: 'center', dataIndex: 'link_men' },
        { header: '银行开户', width: 120, align: 'center', dataIndex: 'account_info' },
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
            url: 'customer/getAllCustomer.ashx'
        }),
        reader: new Ext.data.JsonReader({
            totalProperty: 'totalProperty',
            root: 'root'
        },
		[{ name: 'id', mapping: 'id', type: 'int' },
		 { name: 'username', type: 'string' },
         { name: 'password', type: 'string' },
         { name: 'types', type: 'string' },
         { name: 'c_name', type: 'string' },
         { name: 'c_code', type: 'string' },
         { name: 'tariffline', type: 'string' },
         { name: 'tel', type: 'string' },
         { name: 'mobile', type: 'string' },
         { name: 'email', type: 'string' },
         { name: 'link_men', type: 'string' },
         { name: 'address', type: 'string' },
         { name: 'account_info', type: 'string' },
         { name: 'prestige_info', type: 'string' },
         { name: 'remark', type: 'string' },
         { name: 'rank', type: 'int' },
         { name: 'state', type: 'int' }

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
		        tooltip: '添加客户',
		        iconCls: 'icon-add',
		        handler: function () {
		            add();
		        }
		    },
		"-", " ",
		    { text: '修改',
		        tooltip: '修改一条系统仓库',
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
		    tooltip: '删除选择的系统仓库',
		    iconCls: 'icon-del',
		    handler: function () {

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
        title: '客户管理'
    });

    ds.load({ params: { start: 0, limit: 20} });

    //添加--------------------------------------------------------------------------add
    function add() {


        var window_add = new Ext.Window({
            title: '添加客户',
            width: 340,
            resizable: false,
            autoHeight: true,
            modal: true,
            closeAction: 'hide',
            listeners: {
                'hide': function () {
                    this.setTitle('添加客户');
                }
            },
            items: [{
                xtype: "form",
                labelWidth: 70,
                labelAlign: 'right',
                url: 'customer/addCustomer.ashx',
                border: false,
                baseCls: 'x-plain',
                bodyStyle: 'padding:5px 5px 0',
                anchor: '100%',
                defaults: {
                    width: 317,
                    msgTarget: 'side'
                },
                items: [{
                    xtype: 'hidden',
                    id: 'c.rank',
                    name: 'c.rank'
                }, {
                    xtype: "textfield",
                    width: 200,
                    fieldLabel: "客户帐号",
                    name: "c.username",
                    regex: /^\S+$/,
                    regexText: "请输入名称！",
                    allowBlank: false,
                    blankText: '该字段不允许为空',
                    msgTarget: 'side',
                    maxLength: 50
                }, {
                    width: 200,
                    xtype: "textfield",
                    fieldLabel: "密  码",
                    inputType: 'password',
                    name: "c.password",
                    regex: /^\S+$/,
                    regexText: "请输入密 码,不可以用空格开始和结尾!",
                    allowBlank: false,
                    blankText: '该字段不允许为空',
                    msgTarget: 'side',
                    maxLength: 50
                }, {
                    width: 200,
                    xtype: "textfield",
                    fieldLabel: "客户姓名",
                    name: "c.c_name",
                    regex: /^\S+$/,
                    regexText: "请输入用户名,不可以用空格开始和结尾!",
                    allowBlank: false,
                    blankText: '该字段不允许为空',
                    msgTarget: 'side',
                    maxLength: 50
                }, {
                    width: 200,
                    xtype: "textfield",
                    fieldLabel: "客户编码",
                    name: "c.c_code",
                    msgTarget: 'side',
                    maxLength: 50
                }, {
                    width: 200,
                    xtype: "textfield",
                    fieldLabel: "税号",
                    name: "c.tariffline"
                }, {
                    width: 200,
                    xtype: "textfield",
                    fieldLabel: "电话",
                    name: "c.tel"
                }, {
                    width: 200,
                    xtype: "textfield",
                    fieldLabel: "手机",
                    name: "c.mobile"
                }, {
                    width: 200,
                    xtype: "textfield",
                    fieldLabel: "Email",
                    name: "c.email"
                }, {
                    width: 200,
                    xtype: "textfield",
                    fieldLabel: "联系人",
                    name: "c.link_men"
                }, {
                    width: 200,
                    xtype: "textfield",
                    fieldLabel: "地址",
                    name: "c.address"
                }, {
                    width: 200,
                    xtype: "textfield",
                    fieldLabel: "开户情况",
                    name: "c.account_info"
                }, {
                    width: 200,
                    xtype: "textfield",
                    fieldLabel: "信誉情况",
                    name: "c.prestige_info"
                }
                    , {
                        width: 200,
                        xtype: "combo",
                        fieldLabel: "等级分类",
                        name: "c.rankText",
                        store: new Ext.data.SimpleStore({
                            fields: ["value", "text"],
                            data: [['0', '普通客户'], ['1', 'VIP客户']]
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
                        listeners: {
                            select: function (combo, record, index) {
                                //alert(this.getValue());
                                this.ownerCt.form.findField('c.rank').setValue(this.getValue());
                            }
                        }

                    }, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "描述",
                        name: "c.remark"
                    }
                        ],
                buttonAlign: 'center',
                minButtonWidth: 60,
                buttons: [{
                    text: '添加',
                    handler: function (btn) {
                        var frm = this.ownerCt.ownerCt.form;
                        if (frm.isValid()) {
                            btn.disable();
                            var cnfield = frm.findField('c.c_name');
                            frm.submit({
                                waitTitle: '请稍候',
                                waitMsg: '正在提交表单数据,请稍候...',
                                success: function (form, action) {
                                    if (action.result.success) {

                                        Ext.Msg.show({
                                            title: '成功提示',
                                            msg: '"' + cnfield.getValue()
													+ '" ' + '添加成功!',
                                            buttons: Ext.Msg.OK,
                                            fn: function () {
                                                btn.enable();
                                            },
                                            icon: Ext.Msg.INFO
                                        });
                                        window_add.hide();
                                        ds.load();
                                    } else {
                                        Ext.Msg.show({
                                            title: '错误提示',
                                            msg: action.result.msg,
                                            buttons: Ext.Msg.OK,
                                            fn: function () {
                                                btn.enable();
                                            },
                                            icon: Ext.Msg.ERROR
                                        });
                                    
                                    }



                                },
                                failure: function () {
                                    Ext.Msg.show({
                                        title: '错误提示',
                                        msg: '添加失败，请联系管理员!用户名和邮箱不能重复',
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
                        this.ownerCt.form.reset();
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

        var rankText = new Ext.form.ComboBox({
            width: 200,
            fieldLabel: "等级分类",
            anchor: "86%",
            name: "c.rankText",
            store: new Ext.data.SimpleStore({
                fields: ["value", "text"],
                data: [['0', '普通客户'], ['1', 'VIP客户']]
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
            listeners: {
                select: function (combo, record, index) {
                    //alert(this.getValue());
                    this.ownerCt.form.findField('c.rank').setValue(this.getValue());
                }
            }
        });

        rankText.setValue(record.data.rank); 


        var window_add_edit = new Ext.Window({
            title: '修改客户',
            width: 340,
            height: 580,
            resizable: false,
            autoHeight: true,
            modal: true,
            closeAction: 'hide',
            listeners: {
                'hide': function () {
                    this.setTitle('修改客户');
                }
            },
            items: [{
                xtype: "form",
                labelWidth: 70,
                labelAlign: 'right',
                url: 'customer/UpdateCustomer.ashx',
                border: false,
                baseCls: 'x-plain',
                bodyStyle: 'padding:5px 5px 0',
                anchor: '100%',
                defaults: {
                    width: 317,
                    msgTarget: 'side'
                },
                    items: [{
                    xtype: 'hidden',
                    id: 'c.rank',
                    name: 'c.rank',
                    value: record.data.rank
                   },{
                        xtype: 'hidden',
                        id: 'c.id',
                        name: 'c.id',
                        value: record.data.id
                    }, {
                        xtype: "textfield",
                        width: 200,
                        fieldLabel: "客户帐号",
                        name: "c.username",
                        regex: /^\S+$/,
                        regexText: "请输入名称！",
                        allowBlank: false,
                        blankText: '该字段不允许为空',
                        msgTarget: 'side',
                        value: record.data.username,
                        maxLength: 50
                    }, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "密  码",
                        inputType: 'password',
                        name: "c.password",
                        regex: /^\S+$/,
                        regexText: "请输入密 码,不可以用空格开始和结尾!",
                        allowBlank: false,
                        blankText: '该字段不允许为空',
                        msgTarget: 'side',
                        value: record.data.password,
                        maxLength: 50
                    }, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "客户姓名",
                        name: "c.c_name",
                        regex: /^\S+$/,
                        regexText: "请输入用户名,不可以用空格开始和结尾!",
                        allowBlank: false,
                        blankText: '该字段不允许为空',
                        msgTarget: 'side',
                        value: record.data.c_name,
                        maxLength: 50
                    }, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "客户编码",
                        name: "c.c_code",
                        msgTarget: 'side',
                        value: record.data.c_code,
                        maxLength: 50
                    }, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "税号",
                        value: record.data.tariffline,
                        name: "c.tariffline"
                    }, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "电话",
                        value: record.data.tel,
                        name: "c.tel"
                    }, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "手机",
                        value: record.data.mobile,
                        name: "c.mobile"
                    }, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "Email",
                        value: record.data.email,
                        name: "c.email"
                    }, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "联系人",
                        value: record.data.link_men,
                        name: "c.link_men"
                    }, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "地址",
                        value: record.data.address,
                        name: "c.address"
                    }, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "开户情况",
                        value: record.data.account_info,
                        name: "c.account_info"
                    }, {
                        width: 200,
                        xtype: "textfield",
                        value: record.data.prestige_info,
                        fieldLabel: "信誉情况",
                        name: "c.prestige_info"
                    }
                    , rankText, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "描述",
                        value: record.data.remark,
                        name: "c.remark"
                    }],
                buttonAlign: 'center',
                minButtonWidth: 60,
                buttons: [{
                    text: '修改',
                    handler: function (btn) {
                        var frm = this.ownerCt.ownerCt.form;
                        if (frm.isValid()) {
                            btn.disable();
                            var cnfield = frm.findField('c.c_name');
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





});