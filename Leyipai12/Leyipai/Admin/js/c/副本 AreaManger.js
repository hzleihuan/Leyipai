Ext.onReady(function () {

  Ext.QuickTips.init(); //初始化接点提示
    //数据
    var loader = new Ext.tree.TreeLoader({
        url:  'area/getAllAreaById.ashx'
    });

    loader.on('beforeload', function (treeloader, node) {
        treeloader.baseParams = {
            id: node.id
        };
    }, loader);


    // 树形面板
    var tree = new Ext.tree.TreePanel({
        id: 'tree-mianban',
        title: '地区列表',
        autoScroll: true,
        split: true,
        animate: true,
        enableDD: false,
        rootVisible: true,
        root: new Ext.tree.AsyncTreeNode({
            draggable: true,
            id: '1',
            expanded: true,
            symbol: 'all',
            text: '中国'
        }),
        loader: loader
     
       
    });
    
   
   
    // 给tree添加事件
    tree.on('rightClickCont', tree.rightClick, tree);


    // 模块销毁函数
    function destroy() {
       
    }

    // 本例的主角，加载 tree TreePanel
    //tree.setRootNode(root);
    tree.render("treeList");
   // root.expand(true, true);
   //  tree.expandAll();
    // 定义右键菜单
    var rightClick = new Ext.menu.Menu({
        id: 'rightClickCont',
        items: [{
            id: 'addNode',
            iconCls: 'icon-add',
            text: '添加地区',
            // 增加菜单点击事件
            menu: [{
                id: 'insertNode',
                text: '添加同级地区',
                iconCls: 'icon-add',
                handler: function (tree) {

                    insertNode();
                }

            }, {
                id: 'appendNode',
                iconCls: 'icon-add',
                text: '添加儿子地区',
                handler: function (tree) {

                    appendNodeAction();
                }
            }]
        }, '-', {
            id: 'delNode',
            iconCls: 'icon-del',
            text: '删除',
            handler: function (tree) {

                delNodeAction();
            }
        }, {
            id: 'modifNode',
            text: '修改',
            iconCls: 'icon-edit',
            handler: function () {
                modifNodeAction()
            }
        }]
    });
    // 添加点击事件
    tree.on('click', function (node) {
        if (!node.isLeaf()) {
           
        }
    });

    // 增加右键弹出事件
    tree.on('contextmenu', function (node, event) {// 声明菜单类型
        event.preventDefault(); // 这行是必须的，使用preventDefault方法可防止浏览器的默认事件操作发生。

        node.select();
        rightClick.showAt(event.getXY()); // 取得鼠标点击坐标，展示菜单
    });

    // 添加兄弟节点事件实现
    function insertNode() {

        var selectedNode = tree.getSelectionModel().getSelectedNode();

        var selectedParentNode = selectedNode.parentNode;

        var newNode = new Ext.tree.TreeNode({
            text: '新建节点' + selectedNode.id
        });
        if (selectedParentNode == null) {
            selectedNode.appendChild(newNode);
        } else {
            selectedParentNode.insertBefore(newNode, selectedNode);
        }

        setTimeout(function () {
            treeEditor.editNode = newNode;
            treeEditor.startEdit(newNode.ui.textNode);
        }, 10);
    };

    // 添加子节点事件实现
    function appendNodeAction() {

        var selectedNode = tree.getSelectionModel().getSelectedNode();
        if (selectedNode.isLeaf()) {
            selectedNode.leaf = false;
        }
        var newNode = selectedNode.appendChild(new Ext.tree.TreeNode({
            text: '新建节点' + selectedNode.id
        }));
        newNode.parentNode.expand(true, true, function () {
            tree.getSelectionModel().select(newNode);
            setTimeout(function () {
                treeEditor.editNode = newNode;
                treeEditor.startEdit(newNode.ui.textNode);
            }, 10);
        }); // 将上级树形展开
    }
    // 删除节点事件实现
    function delNodeAction() {

        var selectedNode = tree.getSelectionModel().getSelectedNode();
        // 得到选中的节点
        selectedNode.remove();
    };
    // 修改节点事件实现
    function modifNodeAction() {

        var selectedNode = tree.getSelectionModel().getSelectedNode(); // 得到选中的节点
        treeEditor.editNode = selectedNode;
        treeEditor.startEdit(selectedNode.ui.textNode);
    };
    // 查看事件实现
    function veiwNodeAction() {

        var viewPanel = Ext.getCmp('tree-window-view');
        var selectedNode = tree.getSelectionModel().getSelectedNode();
        // 得到选中的节点
        var tmpid = selectedNode.attributes.id;
        var tmpname = selectedNode.attributes.text;
        var tmpdes = selectedNode.attributes.des;

        win.setTitle(tmpname + '的介绍');
        win.show();

        var dataObj = {
            id: tmpid,
            name: tmpname,
            des: tmpdes
        }
        var tmpTpl = new Ext.Template([
    '<div style="margin:10px"><div style="margin:10px">编号:{id}</div>',
    '<div style="margin:10px">名称:{name}</div>',
    '<div style="margin:10px">描述:{des}</div></div>']);

        tmpTpl.overwrite(viewPanel.body, dataObj);

    };

});
