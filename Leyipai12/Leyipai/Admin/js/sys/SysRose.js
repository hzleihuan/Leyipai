Ext.onReady(function () {
    // 使用表单提示
    Ext.QuickTips.init();
    // turn on validation errors beside the field globally
    Ext.form.Field.prototype.msgTarget = 'side';

    var sm = new Ext.grid.CheckboxSelectionModel();

    var cm = new Ext.grid.ColumnModel([
	    new Ext.grid.RowNumberer(),
		sm,
		{ header: '角色名', width: 120, align: 'center', dataIndex: 'rose_name' },
		{ header: '相关描述', width: 220, align: 'center', dataIndex: 'des' }



	]);

    cm.defaultSortable = true;

    var ds = new Ext.data.GroupingStore({
        proxy: new Ext.data.HttpProxy({
            url: 'rose/GetAllRose.ashx'
        }),
        reader: new Ext.data.JsonReader({
            totalProperty: 'totalProperty',
            root: 'root'
        },
		[{ name: 'id', mapping: 'rid', type: 'string' },
		 { name: 'rose_name', type: 'string' },
         { name: 'des', type: 'string' }

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
		        tooltip: '添加一条系统角色',
		        iconCls: 'icon-add',
		        handler: function () {
		            addRose();
		        }
		    },
		"-", " ",
		    { text: '修改',
		        tooltip: '修改一条系统角色',
		        iconCls: 'icon-edit',
		        handler: function () {
		            var _record = grid.getSelectionModel().getSelected();
		            if (sm.getCount() == 1) {
		                editRose(_record);
		            } else
		                Ext.Msg.alert('提示', '请选择一条记录！');
		        }
		    },
		"-", " ",
		    { text: '配置资源',
		        tooltip: '配置一条系统角色资源',
		        iconCls: 'icon-edit',
		        handler: function () {
		            var _record = grid.getSelectionModel().getSelected();
		            if (sm.getCount() == 1) {
		                configRose(_record);
		            } else
		                Ext.Msg.alert('提示', '请选择一条记录！');
		        }
		    },
		 "-", " ", { text: '删除',
		     tooltip: '删除选择的系统角色',
		     iconCls: 'icon-del',
		     handler: function () {

		         var _record = grid.getSelectionModel().getSelected();
		         if (sm.getCount() == 1) {
		             delRose(_record);
		         } else {
		             Ext.Msg.alert('提示', '请选择一条记录！');
		         }

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
        title: '角色管理'
    });

    ds.load({ params: { start: 0, limit: 100} });

    //添加角色--------------------------------------------------------------------------add
    function addRose() {


        var window_add_rose = new Ext.Window({
            title: '添加角色',
            width: 340,
            height: 580,
            resizable: false,
            autoHeight: true,
            modal: true,
            closeAction: 'hide',
            listeners: {
                'hide': function () {
                    this.setTitle('添加角色');
                }
            },
            items: [{
                xtype: "form",
                labelWidth: 70,
                labelAlign: 'right',
                url: 'rose/AddRose.ashx',
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
                        fieldLabel: "用户名",
                        name: "rose.rose_name",
                        regex: /^\S+$/,
                        regexText: "请输入名称！",
                        allowBlank: false,
                        blankText: '该字段不允许为空',
                        msgTarget: 'side',
                        maxLength: 50
                    }, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "相关描述",
                        name: "rose.des"
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
                            var cnfield = frm.findField('rose.rose_name');
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
                                    window_add_rose.hide();
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
                        window_add_rose.hide();
                    }
                }]
            }]
        });

        window_add_rose.show();

    }
    //修改角色-------------------------------------------------------------------------edit
    function editRose(record) {


        var window_add_edit = new Ext.Window({
            title: '修改角色',
            width: 340,
            height: 580,
            resizable: false,
            autoHeight: true,
            modal: true,
            closeAction: 'hide',
            listeners: {
                'hide': function () {
                    this.setTitle('修改角色');
                }
            },
            items: [{
                xtype: "form",
                labelWidth: 70,
                labelAlign: 'right',
                url: 'rose/EditRose.ashx',
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
                        id: 'rose.rid',
                        name: 'rose.rid',
                        value: record.data.id
                    }, {
                        xtype: "textfield",
                        width: 200,
                        fieldLabel: "用户名",
                        name: "rose.rose_name",
                        regex: /^\S+$/,
                        regexText: "请输入名称！",
                        allowBlank: false,
                        blankText: '该字段不允许为空',
                        msgTarget: 'side',
                        maxLength: 50,
                        value: record.data.rose_name
                    }, {
                        width: 200,
                        xtype: "textfield",
                        fieldLabel: "相关描述",
                        name: "rose.des",
                        value: record.data.des
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
                            var cnfield = frm.findField('rose.rose_name');
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


    function delRose(record) {

        var myMask = new Ext.LoadMask(Ext.getBody(), {
            msg: "Please wait..."
        });
        myMask.show();
        Ext.Ajax.request({
            url: 'rose/DelRose.ashx',
            params: {
                rose_rid: record.data.id
            },
            success: function (response) {
                var success = Ext.util.JSON.decode(response.responseText).success;
                if (success) {
                    myMask.hide();
                    Ext.MessageBox.show({
                        title: '成功提示',
                        msg: '角色删除成功',
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
                        msg: '资源删除失败,请检查是否关联了角色信息',
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

    //资源配置-------------------------------------------------------------------------------config resource
    var xg = Ext.grid;
    function configRose(record) {
        var myMask = new Ext.LoadMask(Ext.getBody(), {
            msg: "Please wait..."
        });
        myMask.show();
        resStoreloadCallBack = function () {
            //勾选已经有的资源
            var model = grid4.getSelectionModel();
            Ext.Ajax.request({
                url: 'rose/GetSysRescourceByRoseId.ashx',
                params: {
                    rid: record.data.id
                },
                success: function (response) {
                    var success = Ext.util.JSON.decode(response.responseText).success;
                    var arrayId = Ext.util.JSON.decode(response.responseText).msg;
                    if (success) {
                        if (arrayId != '') {//js 字符串转数组
                            var strAry = arrayId.split(",");
                            // var selModel = resourGrid.getSelectionModel(); 

                            //获得当前resourGrid所有行
                            var recordlist = resStore.getRange(0, resStore.getCount());
                            var i = 0;
                            var myArray = new Array();
                            var myArray_length = 0;
                            for (i = 0; i < recordlist.length; i++) {
                                var sid = recordlist[i].get('id');
                                var j = 0;
                                for (j = 0; j < strAry.length; j++) {
                                    if (sid == strAry[j]) {
                                        myArray[myArray_length] = i;
                                        myArray_length++;
                                    }

                                    //smm.selectRow(i);
                                }
                            }
                            model.selectRows(myArray);
                            // alert(selModel.getSelections().length);
                        }

                    }
                    myMask.hide();
                },
                failure: function () {
                    myMask.hide();
                }
            });
        }

        var resStore = new Ext.data.GroupingStore({
            proxy: new Ext.data.HttpProxy({
                url: 'rose/GetAllSysResource.ashx'
            }),
            sortInfo: {
                field: 'rs_type',
                direction: 'asc'
            },
            listeners: {
                load: resStoreloadCallBack
            },
            reader: new Ext.data.JsonReader({
                totalProperty: 'totalProperty',
                root: 'root'
            },

		[{ name: 'id', mapping: 'rs_id', type: 'string' },
		 { name: 'rs_name', type: 'string' },
         { name: 'rs_url', type: 'string' },
         { name: 'rs_type', type: 'string' }

		])
        });

        var sm2 = new xg.CheckboxSelectionModel();
        var grid4 = new xg.GridPanel({
            id: 'button-grid',
            store: resStore,
            cm: new xg.ColumnModel([
            sm2,
            { id: 'rs_name', header: "rs_name", width: 40, sortable: true, dataIndex: 'rs_name' },
            { header: "rs_url", width: 20, sortable: true, dataIndex: 'rs_url' },
            { header: "rs_type", width: 20, sortable: true, dataIndex: 'rs_type' }

        ]),
            sm: sm2,

            viewConfig: {
                forceFit: true
            },
            columnLines: true,

            // inline buttons
            buttons: [{
                text: '提交',
                handler: function () {
                    var str = "";
                    var check = false;
                    if (grid4.getSelectionModel().getCount() > 0) {

                        for (var i = 0, j = grid4.store.getCount(); i < j; i++) {

                            if (grid4.getSelectionModel().isSelected(i)) {
                                if (!check)
                                    str = grid4.store.getAt(i).get("id");
                                else
                                    str = str + "," + grid4.store.getAt(i).get("id");
                                check = true;
                            }

                        }

                    }

                    Ext.Ajax.request({
                        url: 'rose/updateRoseResource.ashx',
                        params: {
                            rid: record.data.id,
                            rsids: str
                        },
                        success: function (response) {
                            Ext.MessageBox.show({
                                title: '成功提示',
                                msg: '角色配置成功',
                                buttons: Ext.MessageBox.OK,
                                icon: Ext.MessageBox.INFO,
                                fn: function () {
                                    window_config.hide();

                                }
                            });
                        },
                        failure: function () {

                        }
                    });

                }
            }, { text: '取消', handler: function () { window_config.hide(); } }

             ],
            buttonAlign: 'center',

            width: 600,
            height: 350,
            frame: true,
            iconCls: 'icon-grid'
        });

        //加载所有资源
        resStore.load();



        var window_config = new Ext.Window({
            title: '配置角色',
            width: 600,
            resizable: false,
            autoHeight: true,
            modal: true,
            closeAction: 'hide',
            listeners: {
                'hide': function () {
                    this.setTitle('修改角色');
                }
            },
            items: [grid4]
        });

        window_config.show();

    }




});