Ext.onReady(function () {

    Ext.QuickTips.init(); //初始化接点提示


    var loader = new Ext.tree.TreeLoader({
        url: 'type/GetAllType.ashx'
    });

    loader.on('beforeload', function (treeloader, node) {
        treeloader.baseParams = {
            id: node.id
        };
    }, loader);


    var root = new Ext.tree.AsyncTreeNode({
        text: '商品类型',
        draggable: false,
        id: 'root'
    });



    var tree = new Ext.tree.TreePanel({
        width: 300,
        id: 'tree-mianban',
        title: '商品类型列表',
        animate: true,
        enableDD: true,
        containerScroll: false,
        root: root,
        loader: loader,
        containerScroll: false,
        border: true


    });

    var treeEditer = new Ext.tree.TreeEditor(Ext.getCmp('tree-mianban'), {
        id: 'tree-Manage',
        allowBlank: false
        // 输入值不可以为空
    });
    tree.render("treeList");
    tree.expand();
    root.expand(false, false);
    // 定义右键菜单
    var rightClick = new Ext.menu.Menu({
        id: 'rightClickCont',
        items: [{
            id: 'addNode',
            text: '添加',
            // 增加菜单点击事件
            menu: [{
                id: 'insertNode',
                text: '添加兄弟节点',
                handler: function (tree) {
                    addAction(1);
                }

            }, {
                id: 'appendNode',
                text: '添加儿子节点',
                handler: function (tree) {
                    addAction(0);
                }
            }]
        }, '-', {
            id: 'delNode',
            text: '删除',
            handler: function (tree) {

                deltype();
            }
        }, {
            id: 'modifNode',
            text: '修改',
            handler: function () {

                upadteAction();
            }
        }, {
            id: 'viewNode',
            text: '查看',
            handler: function (tree) {

                //veiwNodeAction();
            }
        }]
    });
   

    // 增加右键弹出事件
    tree.on('contextmenu', function (node, event) {// 声明菜单类型
        event.preventDefault(); // 这行是必须的，使用preventDefault方法可防止浏览器的默认事件操作发生。

        node.select();
        rightClick.showAt(event.getXY()); // 取得鼠标点击坐标，展示菜单
    });







    // 添加节点事件实现
    function addAction(num) {
        var selectedNode = tree.getSelectionModel().getSelectedNode();
        var selectedParentNode = selectedNode.parentNode;
        var submitUrl = "";
        if (num == 0) {//添加子节点
            submitUrl = 'type/AddType.ashx?parent_id=' + selectedNode.id;
        } else { //添加兄弟节点
            submitUrl = 'type/AddType.ashx?parent_id=' + selectedParentNode.id;
        }
        var addWin = new Ext.Window({
            width: 340,
            autoHeight: true,
            title: "添加商品类型",
            maximizable: true,
            items: [{
                xtype: "form",
                labelWidth: 80,
                labelAlign: 'right',
                url: submitUrl,
                border: false,
                baseCls: 'x-plain',
                bodyStyle: 'padding:5px 5px 0',
                anchor: '100%',
                defaults: {
                    width: 300,
                    msgTarget: 'side'
                },
                items: [{
                    xtype: "fieldset",
                    title: "类型名称",
                    autoHeight: true,
                    items: [{
                        xtype: "textfield",
                        fieldLabel: "类型名称",
                        name: "type.type_name"
                    }]
                }],
                buttonAlign: 'right',
                minButtonWidth: 60,
                buttons: [{
                    text: '添加',
                    handler: function (btn) {
                        var frm = this.ownerCt.ownerCt.form;
                        if (frm.isValid()) {
                            btn.disable();
                            var cnfield = frm.findField('type.type_name');
                            frm.submit({
                                waitTitle: '请稍候',
                                waitMsg: '正在提交表单数据,请稍候...',
                                success: function (form, action) {

                                    Ext.Msg.show({
                                        title: '信息提示',
                                        width: 200,
                                        msg: (action.result.msg == null) ? ('"' + cnfield.getValue() + '" ' + '添加成功!') : action.result.msg,
                                        buttons: Ext.Msg.OK,
                                        fn: function () {

                                            btn.enable();
                                        },
                                        icon: (action.result.msg == null) ? Ext.Msg.INFO : Ext.Msg.WARNING
                                    });
                                    addWin.close();
                                    tree.getRootNode().reload();
                                },
                                failure: function () {
                                    Ext.Msg.show({
                                        title: '错误提示',
                                        width: 200,
                                        msg: '添加失败!',
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
                        this.ownerCt.ownerCt.ownerCt.hide();
                    }
                }]
            }]
        });
        addWin.show();
    };


    // 修改节点
    function upadteAction() {

        var selectedNode = tree.getSelectionModel().getSelectedNode();
        var selectedParentNode = selectedNode.parentNode;
        var submitUrl = 'type/UpdateType.ashx';
        var upadteWin = new Ext.Window({
            width: 340,
            autoHeight: true,
            title: "修改类型",
            maximizable: true,
            items: [{
                xtype: "form",
                labelWidth: 80,
                labelAlign: 'right',
                url: submitUrl,
                border: false,
                baseCls: 'x-plain',
                bodyStyle: 'padding:5px 5px 0',
                anchor: '100%',
                defaults: {
                    width: 300,
                    msgTarget: 'side'
                },
                items: [{
                    xtype: "fieldset",
                    title: "",
                    autoHeight: true,
                    items: [{
                        xtype: "hidden",
                        name: "type.parent_id",
                        id: 'type.parent_id',
                        value: selectedParentNode.id
                    }, {
                        xtype: "textfield",
                        fieldLabel: "名称",
                        name: "type.type_name",
                        value: selectedNode.text
                    }, {
                        xtype: 'combotree',
                        fieldLabel: '上级节点',
                        name: 'type.parent_text',
                        tree: new Ext.tree.TreePanel({
                            root: new Ext.tree.AsyncTreeNode(
														{
														    text: '--选择--',
														    id: 'root'
														}),
                            rootVisible: true,
                            border: false,
                            loader: loader
                        }),
                        value: selectedParentNode.text,
                        listeners: {
                            select: function (combo, record, index) {
                                alert(this.getValue());
                                combo.setRawValue(record.text);
                                this.ownerCt.ownerCt.form.findField('type.parent_id').setValue(this.getValue());
                            }
                        }

                    }, {
                        xtype: "hidden",
                        name: "type.type_id",
                        value: selectedNode.id
                    }]
                }],
                buttonAlign: 'right',
                minButtonWidth: 60,
                buttons: [{
                    text: '修改',
                    handler: function (btn) {
                        var frm = this.ownerCt.ownerCt.form;
                        if (frm.isValid()) {
                            btn.disable();
                            var cnfield = frm.findField('type.type_name');
                            frm.submit({
                                waitTitle: '请稍候',
                                waitMsg: '正在提交表单数据,请稍候...',
                                success: function (form, action) {

                                    Ext.Msg.show({
                                        title: '信息提示',
                                        width: 200,
                                        msg: (action.result.msg == null) ? ('"' + cnfield.getValue() + '" ' + '修改成功!') : action.result.msg,
                                        buttons: Ext.Msg.OK,
                                        fn: function () {

                                            btn.enable();
                                        },
                                        icon: (action.result.msg == null) ? Ext.Msg.INFO : Ext.Msg.WARNING
                                    });
                                    upadteWin.close();
                                    tree.getRootNode().reload();
                                },
                                failure: function () {
                                    Ext.Msg.show({
                                        title: '错误提示',
                                        width: 200,
                                        msg: '修改失败!',
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
                        this.ownerCt.ownerCt.ownerCt.hide();
                    }
                }]
            }]
        });
        upadteWin.show();

    }



    function deltype() {


        var selectedNode = tree.getSelectionModel().getSelectedNode();

        var myMask = new Ext.LoadMask(Ext.getBody(), {
            msg: "Please wait..."
        });
        myMask.show();
        Ext.Ajax.request({
            url: 'type/DelType.ashx',
            params: {
                id: selectedNode.id
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
                            tree.getRootNode().reload();

                        }
                    });
                } else {
                    myMask.hide();
                    Ext.MessageBox.show({
                        title: '失败提示',
                        msg: '资源删除失败,请检查是否关联了',
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
 