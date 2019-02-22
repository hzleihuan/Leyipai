<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesOrderEdit.aspx.cs" Inherits="Admin_Sales_SalesOrderEdit" %>

<%@ Import Namespace="Leyipai.Model" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" media="all" href="../js/ext/resources/css/ext-all.css" />
        <link rel="stylesheet" type="text/css" media="all" href="../css/ext-common.css" />
	<script type="text/javascript" src="../js/ext/adapter/ext/ext-base.js"></script>
	<script type="text/javascript" src="../js/ext/ext-all.js"></script>	
	<script type="text/javascript" src="../js/ext/ext-lang-zh_CN.js"></script>
    <script type="text/javascript" src="../js/ComboTree.js"></script>
    <script type="text/javascript" src="../js/base.js"></script>
    <script src="../js/products/SelectProductWin.js" type="text/javascript"></script>
    <script src="../js/c/SelectCustomerWin.js" type="text/javascript"></script>

    <script type="text/javascript" >
     Ext.onReady(function () {
            // 使用表单提示
            Ext.QuickTips.init();
            // turn on validation errors beside the field globally
            Ext.form.Field.prototype.msgTarget = 'side';
            var fm = Ext.form;

            var sm = new Ext.grid.CheckboxSelectionModel();
            var cm = new Ext.grid.ColumnModel([
	    new Ext.grid.RowNumberer(),
		sm,
		{ header: '商品编号', width: 80, align: 'center', dataIndex: 'products_id' },
        { header: '商品名称', width: 150, align: 'center', dataIndex: 'products_name' },
        { header: '单位', width: 150, align: 'center', dataIndex: 'units' },
        { header: '价格', width: 120, align: 'center', dataIndex: 'price' },
        { header: '折扣', width: 100, align: 'center', dataIndex: 'discount_rate', editor: new fm.NumberField({
            allowBlank: false,
            allowNegative: false,
            maxValue: 1,
            mixValue: 0.1
        })
        },
        { header: '数量', width: 100, align: 'center', dataIndex: 'quantity', editor: new fm.NumberField({
            allowBlank: false,
            allowNegative: false,
            maxValue: 100000,
            mixValue: 1,
            allowDecimals: false
        })
        }

	]);
            cm.defaultSortable = false;


            // create the Data Store

            var arr=[<%=orderDetailString %>];  
           var reader = new Ext.data.ArrayReader(  
                      {id: 0},  
                    [  
                    {name: 'products_id', mapping: 1},          
                    {name: 'products_name', mapping: 2},
                    {name: 'units', mapping: 3} ,
                    {name: 'price', mapping: 4} ,
                    {name: 'discount_rate', mapping: 5} ,
                    {name: 'quantity', mapping: 6}     
                    ]);  


            var store = new Ext.data.Store({
                autoDestroy: true,
                reader:reader,  
                sortInfo: { field: 'products_id', direction: 'ASC' }
            });
            store.loadData(arr);  
            var grid = new Ext.grid.EditorGridPanel({
                cm: cm,
                store: store,
                sm: sm,
                height: 180,
                id: 'products-gridList',
                border: true,
                bodyStyle: 'width:100%',
                stripeRows: true,
                tbar: [{
                    text: '添加商品',
                    iconCls: 'icon-add',
                    handler: function () {
                        getSelectProductsList();

                    }
                }, '  ', {
                    text: ' 删除 ',
                    iconCls: 'icon-del',
                    handler: function () {
                        var mydel = new Array();
                        var num = 0;
                        for (var i = 0; i < grid.store.getCount(); i++) {
                            if (grid.getSelectionModel().isSelected(i)) {
                                mydel[num] = grid.store.getAt(i);
                                num++;
                            }
                        }

                        grid.store.remove(mydel);
                        afterEdit(null);
                    }
                }]

            });


            // 单元格编辑后事件处理  
            grid.on("afteredit", afterEdit, grid);

            ///
            var win;
            win = new Ext.Window({
                applyTo: 'add-win',
                layout: 'fit',
                resizable: false,
                title: '修改销售订单',
                closable: false,
                draggable: false,
                width: 800,
                height: 480,
                closeAction: 'hide',
                items: [{
                    xtype: "form",
                    labelWidth: 70,
                    labelAlign: 'right',
                    id: 'orderFrom',
                    url: 'ajax/UpadteSalesOrder.ashx',
                    border: false,
                    baseCls: 'x-plain',
                    bodyStyle: 'padding:5px 5px 5px;background-color:#fff',
                    anchor: '100%',
                    defaults: {
                        msgTarget: 'side'
                    },
                    items: [{
                        layout: 'column',   //定义该元素为布局为列布局方式
                        border: false,
                        labelSeparator: '：',
                        items: [{
                            columnWidth: .4,  //该列占用的宽度，标识为50％
                            bodyStyle: 'padding-top:5px',
                            layout: 'form',
                            border: false,
                            items: [{
                                xtype: 'hidden',
                                id: 'depot_id',
                                name: 'depot_id',
                                value :'<%=salesOrder.depot_id %>',
                            }, {
                                xtype: 'hidden',
                                id: 'logistics_id',
                                name: 'logistics_id',
                                value :'<%=salesOrder.logistics_id %>',
                            }, {
                                xtype: 'hidden',
                                id: 'customer_id',
                                name: 'customer_id',
                                value :'<%=salesOrder.customer_id %>'
                            },
                       {
                           xtype: 'textfield',
                           fieldLabel: '订单编号',
                           id: 'order_num',
                           readOnly: true,
                           name: 'sales_orderid',
                           value :'<%=salesOrder.sales_orderId %>',
                           anchor: '90%'
                       }, {
                           anchor: "90%",
                           xtype: "combo",
                           fieldLabel: "货出仓库",
                           name: "depot.Text",
                           store: new Ext.data.GroupingStore({
                               proxy: new Ext.data.HttpProxy({
                                   url: '../c/depot/getAllDepot.ashx'
                               }),
                               reader: new Ext.data.JsonReader({
                                   totalProperty: 'totalProperty',
                                   root: 'root'
                               },
		                            [{ name: 'id', mapping: 'depot_id', type: 'string' },
		                             { name: 'depot_name', type: 'string' },
                                     { name: 'state', type: 'string' }

		                            ])
                           }),
                           displayField: 'depot_name',
                           valueField: 'id',
                           mode: 'remote',
                           emptyText: '<%=salesOrder.depot_name %>',
                           msgTarget: 'side',
                           editable: false,
                           triggerAction: 'all',
                           listeners: {
                               select: function (combo, record, index) {

                                   this.ownerCt.ownerCt.ownerCt.form.findField('depot_id').setValue(this.getValue());
                               }
                           }

                       }, {
                           anchor: "90%",
                           xtype: "combo",
                           fieldLabel: "物流公司",
                           name: "logistics.Text",
                           store: new Ext.data.GroupingStore({
                               proxy: new Ext.data.HttpProxy({
                                   url: '../c/logistics/getAlllogistics.ashx'
                               }),
                               reader: new Ext.data.JsonReader({
                                   totalProperty: 'totalProperty',
                                   root: 'root'
                               },
		                            [{ name: 'id', mapping: 'id', type: 'int' },
		                             { name: 'logistics_name', type: 'string' },
                                     { name: 'description', type: 'string' }

		                            ])
                           }),
                           displayField: 'logistics_name',
                           valueField: 'id',
                           mode: 'remote',
                           emptyText: '<%=salesOrder.logistics_name %>',
                           msgTarget: 'side',
                           editable: false,
                           triggerAction: 'all',
                           listeners: {
                               select: function (combo, record, index) {

                                   this.ownerCt.ownerCt.ownerCt.form.findField('logistics_id').setValue(this.getValue());
                               }
                           }

                       }, {
                           xtype: 'textfield',
                           fieldLabel: '货物金额',
                           name: 'sales_income',
                           id: 'total_income',
                           value: '<%=salesOrder.sales_income.ToString("0.00") %>',
                           msgTarget: 'side',
                           readOnly: true,
                           anchor: '90%'
                       }, {
                           xtype: 'textfield',
                           fieldLabel: '折让金额',
                           name: 'discount',
                           regex: /^\d+(\.\d+)?$/,
                           regexText: "大于0的数字",
                           allowBlank: false,
                           allowNegative: false,
                           mixValue: 0,
                           value: '<%=salesOrder.discount.ToString("0.00") %>',
                           anchor: '90%'
                       }, {
                           xtype: 'textfield',
                           fieldLabel: '交货方式',
                           name: 'delivery_type',
                           value: '<%=salesOrder.delivery_type %>',
                           anchor: '90%'
                       }]
                        }, {
                            columnWidth: .6,
                            layout: 'form',
                            bodyStyle: 'padding-top:5px',
                            border: false,
                            items: [{
                                xtype: 'textfield',
                                fieldLabel: '下单时间',
                                name: 'create_date',
                                readOnly: true,
                                anchor: '90%',
                                value: '<%=salesOrder.create_date %>'
                            }, {
                                layout: 'column',
                                xtype: "panel",
                                isFormField: true,
                                fieldLabel: "订货顾客",
                                border: false,
                                anchor: '90%',
                                items: [
                        {
                            xtype: 'textfield',
                            id: 'customer_text',
                            name: 'customer_text',
                            allowBlank: false,
                            msgTarget: 'side',
                            value: '<%=salesOrder.customer_name %>',
                            readOnly: true,
                            columnWidth: .7

                        }, {
                            xtype: "button",
                            text: "选择顾客",
                            columnWidth: .3,
                            handler: function () {
                                getSelectCustomerList();
                            }
                        }]

                            }, {
                                xtype: 'textfield',
                                fieldLabel: '物流单号',
                                 value: '<%=salesOrder.logistics_num %>',
                                name: 'logistics_num',
                                anchor: '90%'
                            }, {
                                xtype: 'textfield',
                                fieldLabel: '附件成本',
                                name: 'attach_pay',
                                id: 'attach_pay',
                                regex: /^\d+(\.\d+)?$/,
                                regexText: "大于0的数字",
                                allowBlank: false,
                                allowNegative: false,
                                mixValue: 0,
                                value: '<%=salesOrder.attach_pay.ToString("0.00") %>',
                                anchor: '90%'
                            }, {
                                xtype: 'textfield',
                                fieldLabel: '制单人',
                                name: 'username',
                                 value: '<%=salesOrder.username %>',
                                anchor: '90%'
                            }, {
                                xtype: 'textfield',
                                fieldLabel: '交货地点',
                                id: 'delivery_place',
                                name: 'delivery_place',
                                value: '<%=salesOrder.delivery_place %>',
                                anchor: '90%'
                            }]
                        }]
                    }, {
                        xtype: 'textarea',
                        fieldLabel: '相关描述',
                        name: 'description',
                        height: 40,
                        value: '<%=salesOrder.description %>',
                        anchor: '95%'
                    }, grid, {
                        xtype: 'textfield',
                        id: 'total_num',
                        bodyStyle: 'padding-bottom:2px',
                        isFormField: true,
                        fieldLabel: "合计：数量",
                         value: '<%=totalNum %>',
                        readOnly: true

                    }

             ]
                }],
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-save',
                    handler: function () {

                        var frm = Ext.getCmp('orderFrom').getForm();
                        if (!frm.isValid()) return;
                        var listStore = grid.getStore();
                        if (listStore.getCount() < 1) {
                            Ext.Msg.alert('提示', '请选择订单物品为空！不能提交'); return;
                        }

                        var myMask = new Ext.LoadMask(Ext.getBody(), {
                            msg: "请稍等正在保存明细部分...."
                        });
                        myMask.show();
                        //先保存明细部分
                        var orderNum = Ext.getCmp("order_num").getValue();
                        var poatStr = '';
                        for (var aa = 0; aa < listStore.getCount(); aa++) {

                            var a1 = listStore.getAt(aa).get("price"); //价钱
                            var a2 = listStore.getAt(aa).get("discount_rate");
                            var a3 = listStore.getAt(aa).get("quantity"); //数量
                            var a4 = listStore.getAt(aa).get("products_id"); //products
                            var ss = orderNum + "$" + a1 + "$" + a2 + "$" + a3+ "$" + a4;
                            poatStr = poatStr + "," + ss
                        }

                        Ext.Ajax.request({
                            url: 'ajax/UpdateOrderDetail.ashx?orderId='+orderNum,
                            params: {
                                liststr: poatStr
                            },
                            success: function (response) {
                                myMask.hide();
                                var success = Ext.util.JSON.decode(response.responseText).success;
                                if (success) {//接着保存主表
                                    var cnfield = frm.findField('sales_orderid');
                                    frm.submit({
                                        waitTitle: '请稍候',
                                        waitMsg: '正在提交主表单数据,请稍候...',
                                        success: function (form, action) {

                                            Ext.Msg.show({
                                                title: '成功提示',
                                                msg: '"' + cnfield.getValue()
													+ '" ' + '修改成功!',
                                                buttons: Ext.Msg.OK,
                                                fn: function () {
                                                    window.location.href = "SalesOrderManger.aspx";
                                                },
                                                icon: Ext.Msg.INFO
                                            });


                                        },
                                        failure: function () {
                                            Ext.Msg.show({
                                                title: '错误提示',
                                                msg: '添加失败，请联系管理员!',
                                                buttons: Ext.Msg.OK,
                                                fn: function () {
                                                    myMask.hide();
                                                },
                                                icon: Ext.Msg.ERROR
                                            });
                                        }
                                    });


                                }
                            },
                            failure: function () {
                                myMask.hide();
                            }
                        });



                    }
                }, {
                    text: '重设',
                    handler: function () {

                    }
                }]
            });

            //
            win.show();

            // 事件处理函数  
            function afterEdit(e) {
                var listStore = grid.getStore();
                var total = 0;
                var totalNum = 0;
                for (var aa = 0; aa < listStore.getCount(); aa++) {
                    var a1 = listStore.getAt(aa).get("price"); //价钱
                    var a2 = listStore.getAt(aa).get("discount_rate");
                    var a3 = listStore.getAt(aa).get("quantity"); //数量
                    total = total + a1 * a2 * a3;
                    totalNum = totalNum + a3;

                }
                Ext.getCmp("total_income").setValue(total);
                Ext.getCmp("total_num").setValue(totalNum);

            }

        });


     

    
    
    </script>
   
   
</head>
<body>
     
   <div id="add-win"></div>
  
</body>
</html>