Ext.onReady(function () {
    // 使用表单提示
    Ext.QuickTips.init();
    // turn on validation errors beside the field globally
    Ext.form.Field.prototype.msgTarget = 'side';

    var sm = new Ext.grid.CheckboxSelectionModel();

    var cm = new Ext.grid.ColumnModel([
	    new Ext.grid.RowNumberer(),
		sm,
		{ header: '用户名', width: 120, align: 'center', dataIndex: 'username' },
		{ header: '姓名', width: 120, align: 'center', dataIndex: 'realname' },
		{ header: '角色', width: 100, align: 'center', dataIndex: 'rosename' },
        { header: '部门', width: 100, align: 'center', dataIndex: 'department' },
        { header: 'QQ', width: 100, align: 'center', dataIndex: 'qq' },
        { header: 'Email', width: 150, align: 'center', dataIndex: 'email' },
        { header: '手机', width: 100, align: 'center', dataIndex: 'tel' },
        { header: '状态', width: 70, align: 'center', dataIndex: 'state', renderer: function (v) {
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
            url: 'user/GetSysUserByPage.ashx'
        }),
        reader: new Ext.data.JsonReader({
            totalProperty: 'totalProperty',
            root: 'root'
        },
		[{ name: 'id', mapping: 'uid', type: 'string' },
         { name: 'rid', mapping: 'rid', type: 'string' },
		 { name: 'username', type: 'string' },
         { name: 'password', type: 'string' },
		 { name: 'realname', type: 'string' },
		 { name: 'rosename', type: 'string' },
         { name: 'department', type: 'string' },
         { name: 'qq', type: 'string' },
         { name: 'email', type: 'string' },
         { name: 'tel', type: 'string' },
		 { name: 'state', type: 'string' }
		])
    });

    var searchbar = new Ext.Toolbar({
        id: 'searchbar',
        items: ['姓名  ： ',
		    new Ext.form.TextField({
		        id: 's_realname',
		        width: 100
		    }), ' ',
			new Ext.Toolbar.Button({
			    id: 'searchbutton',
			    iconCls: 'icon_search',
			    text: '查询',
			    handler: doSearch
			})
		]
    });

    function doSearch() {
        ds.load(
	        { params: {
	            start: 0,
	            limit: 20,
	            realname: Ext.get('s_realname').dom.value
	        }
	        });
    }

    var paging = new Ext.PagingToolbar({
        pageSize: 10,
        store: ds,
        displayInfo: true,
        displayMsg: '显示第{0}条到{1}条记录，一共{2}条',
        items:
		["-", " ",
		    { text: '添加',
		        tooltip: '添加一条系统用户信息',
		        iconCls: 'icon-add',
		        handler: function () {
		            addNewUser();
		        }
		    },
		"-", " ",
		    { text: '修改',
		        tooltip: '修改一条系统用户信息',
		        iconCls: 'icon-edit',
		        handler: function () {
		            var _record = grid.getSelectionModel().getSelected();
		            if (sm.getCount() == 1) {
		                edit_sysUser(_record);
		            } else
		                Ext.Msg.alert('提示', '请选择一条记录！');
		        }
		    },
		 "-", " ", { text: '删除',
		     tooltip: '删除选择的系统用户信息',
		     iconCls: 'icon-del',
		     handler: function () {

		         var _record = grid.getSelectionModel().getSelected();
		         if (sm.getCount() == 1) {
		             del_user(_record);
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
        tbar: searchbar,
        bbar: paging,
        height: 400,
        border: true,
        bodyStyle: 'width:960px',
        stripeRows: true,
        title: '用户管理'
    });

    ds.load({ params: { start: 0, limit: 20} });




    //角色数据
    var ds_rose = new Ext.data.Store({
        autoLoad: true,
        proxy: new Ext.data.HttpProxy({
            url: 'rose/GetAllRose.ashx',
            method: 'POST'
        }),
        reader: new Ext.data.JsonReader({
            totalProperty: 'totalProperty',
            root: 'root',
            fields: [{
                name: 'rid',
                type: 'string'
            }, {
                name: 'rose_name',
                type: 'string'
            }]
        })
    });

    var text_rose = new Ext.form.ComboBox({
        fieldLabel: '角色',
        width: 200,
        store: ds_rose,
        displayField: 'rose_name',
        valueField: 'rid',
        typeAhead: true,
        loadingText: '载入中...',
        mode: 'local',
        emptyText: '请选择角色',
        triggerAction: 'all'
    });

    text_rose.on('change', function (box, record, index) {
        this.ownerCt.ownerCt.form.findField('user.rid').setValue(this.getValue());
    });


    //add-win
    function addNewUser() {
        var window_add_user = new Ext.Window({
            title: '添加用户',
            width: 340,
            height: 580,
            resizable: false,
            autoHeight: true,
            modal: true,
            closeAction: 'hide',
            listeners: {
                'hide': function () {
                    this.setTitle('添加用户');
                }
            },
            items: [{
                xtype: "form",
                labelWidth: 70,
                labelAlign: 'right',
                url: 'user/AddSysUser.ashx',
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
                        id: 'user_state',
                        name: 'user.state'
                    }, {
                        xtype: 'hidden',
                        id: 'user_rid',
                        name: 'user.rid'
                    }, {
                        xtype: "textfield",
                        width: 200,
                        fieldLabel: "用户名",
                        name: "user.username",
                        regex: /^\S+$/,
                        regexText: "请输入用户名,不可以用空格开始和结尾!",
                        allowBlank: false,
                        blankText: '该字段不允许为空',
                        msgTarget: 'side',
                        maxLength: 50
                    }, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "密  码",
                        inputType: 'password',
                        name: "user.password",
                        regex: /^\S+$/,
                        regexText: "请输入密 码,不可以用空格开始和结尾!",
                        allowBlank: false,
                        blankText: '该字段不允许为空',
                        msgTarget: 'side',
                        maxLength: 50
                    }, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "真实姓名",
                        name: "user.realname",
                        regex: /^\S+$/,
                        regexText: "请输入用户名,不可以用空格开始和结尾!",
                        allowBlank: false,
                        blankText: '该字段不允许为空',
                        msgTarget: 'side',
                        maxLength: 50
                    }, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "所属部门",
                        name: "user.department"
                    }, text_rose, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "电话/手机",
                        regex: /^(\d{3}-\d{8}|\d{4}-\d{7})|(^((\(\d{3}\))|(\d{3}\-))?13\d{9}|15[01389]\d{8}$)/,
                        regexText: "请输入正确的手机号码或固定电话号码,固话区号与号码用-分割!",
                        maxLength: 20,
                        name: "user.tel"
                    }, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "Email",
                        vtype: "email", //email格式验证
                        vtypeText: "不是有效的邮箱地址",
                        name: "user.email"
                    }, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "QQ号",
                        regex: /^[0-9]\d*$/,
                        regexText: "QQ号只能为数字!",
                        name: "user.qq"
                    }, {
                        width: 200,
                        anchor: "94%",
                        xtype: "combo",
                        fieldLabel: "状  态",
                        name: "user.statesText",
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
                                this.ownerCt.ownerCt.form.findField('user.state').setValue(this.getValue());
                            }
                        }

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
                            var cnfield = frm.findField('user.realname');
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
                                    window_add_user.hide();
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
                        window_add_user.hide();
                    }
                }]
            }]
        });

        window_add_user.show();
    }


    function del_user(record) {

        var myMask = new Ext.LoadMask(Ext.getBody(), {
            msg: "Please wait..."
        });
        Ext.Ajax.request({
            url: 'user/DelSysUser.ashx?username=' + record.data.username,
            success: function (response) {
                ds.load();
                myMask.hide();
            },
            failure: function () {

                Ext.Msg.alert('提示', '操作失败！');
                myMask.hide();
            }
        });
    }


    //edit function
    function edit_sysUser(record) {
        var window_edit_user = new Ext.Window({
            title: '修改用户',
            width: 340,
            height: 580,
            resizable: false,
            autoHeight: true,
            modal: true,
            closeAction: 'hide',
            listeners: {
                'hide': function () {
                    this.setTitle('修改用户');
                }
            },
            items: [{
                xtype: "form",
                labelWidth: 70,
                labelAlign: 'right',
                url: 'user/EditSysUser.ashx',
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
                        id: 'user_uid',
                        name: 'user.uid',
                        value: record.data.id
                    }, {
                        xtype: 'hidden',
                        id: 'user_state',
                        name: 'user.state',
                        value: record.data.state
                    }, {
                        xtype: 'hidden',
                        id: 'user_rid',
                        name: 'user.rid',
                        value: record.data.rid
                    }, {
                        xtype: "textfield",
                        width: 200,
                        fieldLabel: "用户名",
                        name: "user.username",
                        value: record.data.username,
                        regex: /^\S+$/,
                        regexText: "请输入用户名,不可以用空格开始和结尾!",
                        allowBlank: false,
                        blankText: '该字段不允许为空',
                        msgTarget: 'side',
                        maxLength: 50
                    }, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "密  码",
                        inputType: 'password',
                        value: record.data.password,
                        name: "user.password",
                        regex: /^\S+$/,
                        regexText: "请输入密 码,不可以用空格开始和结尾!",
                        allowBlank: false,
                        blankText: '该字段不允许为空',
                        msgTarget: 'side',
                        maxLength: 50
                    }, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "真实姓名",
                        value: record.data.realname,
                        name: "user.realname",
                        regex: /^\S+$/,
                        regexText: "请输入用户名,不可以用空格开始和结尾!",
                        allowBlank: false,
                        blankText: '该字段不允许为空',
                        msgTarget: 'side',
                        maxLength: 50
                    }, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "所属部门",
                        value: record.data.realname,
                        name: "user.department"
                    }, text_rose, {
                        width: 200,
                        xtype: "textfield",
                        value: record.data.tel,
                        fieldLabel: "电话/手机",
                        regex: /^(\d{3}-\d{8}|\d{4}-\d{7})|(^((\(\d{3}\))|(\d{3}\-))?13\d{9}|15[01389]\d{8}$)/,
                        regexText: "请输入正确的手机号码或固定电话号码,固话区号与号码用-分割!",
                        maxLength: 20,
                        name: "user.tel"
                    }, {
                        width: 200,
                        xtype: "textfield",
                        value: record.data.email,
                        fieldLabel: "Email",
                        vtype: "email", //email格式验证
                        vtypeText: "不是有效的邮箱地址",
                        name: "user.email"
                    }, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "QQ号",
                        value: record.data.qq,
                        regex: /^[0-9]\d*$/,
                        regexText: "QQ号只能为数字!",
                        name: "user.qq"
                    }, {
                        width: 200,
                        anchor: "94%",
                        xtype: "combo",
                        fieldLabel: "状  态",
                        name: "user.statesText",
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
                                this.ownerCt.ownerCt.form.findField('user.state').setValue(this.getValue());
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
                            var cnfield = frm.findField('user.realname');
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
                                    window_edit_user.hide();
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
                        window_edit_user.hide();
                    }
                }]
            }]
        });

        window_edit_user.show();

    }


});