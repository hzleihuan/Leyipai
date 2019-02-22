$(function () {
    // setup ul.tabs to work as tabs for each div directly under div.panes
    $("ul.tabs").tabs("div.panes > div");
});

// 添加节点事件实现
function selectTypeAction() {

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
    
    tree.expand();
    root.expand(false, false);
    
    // 添加点击事件
    tree.on('click', function (node) {
        if (node.id != 'root') {
            $("#Type_text").val(node.text);
            $("#Type_ID").val(node.id);
            selectTypeWin.hide();
        }
    });


    var selectTypeWin = new Ext.Window({
        width: 340,
        height: 450,
        title: "选择类型",
        maximizable: true,
        items: [tree]

    });
    selectTypeWin.show();
};




function isNumber(oNum) 
   { 
  if(!oNum) return false; 
  var strP=/^\d+(\.\d+)?$/; 
  if(!strP.test(oNum)) return false; 
  try{ 
  if(parseFloat(oNum)!=oNum) return false; 
  } 
  catch(ex) 
  { 
   return false; 
  } 
  return true; 
   }