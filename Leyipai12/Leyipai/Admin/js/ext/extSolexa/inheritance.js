	MyColumn = function(config){
		 var config = config || {};    
		 var defaultConfig = {
		 	regex : /^\S+$/,
			regexText : "请输入名称,不可以用空格开始和结尾!",
			allowBlank : false,
			blankText : '该字段不允许为空',
			msgTarget : 'side',
			maxLength : 50
		  };
		 Ext.applyIf(config,defaultConfig);
		 MyColumn.superclass.constructor.call(this,config); 
	 }
	Ext.extend(MyColumn,Ext.form.TextField);
 	Ext.reg('myColumn', MyColumn);  
 	
 	MyDateField = function(config){
		 var config = config || {};    
		 var defaultConfig = {
		 	allowBlank : false,
			emptyText : '请选择日期！',
			format:'Y-m-d H:i:s',
			msgTarget : 'side',
			maxLength : 50
		  };
		 Ext.applyIf(config,defaultConfig);
		 MyDateField.superclass.constructor.call(this,config); 
	 }
	Ext.extend(MyDateField,Ext.form.DateField);
 	Ext.reg('myDateField', MyDateField);  
 	
 	MyNumberField = function(config){
		 var config = config || {};    
		 var defaultConfig = {
			allowBlank : false,
			blankText : '该字段为数字，并不允许为空',
			nanText:'请输入数字',
			msgTarget : 'side',
			maxLength : 50
		  };
		 Ext.applyIf(config,defaultConfig);
		 MyNumberField.superclass.constructor.call(this,config); 
	 }
	Ext.extend(MyNumberField,Ext.form.NumberField);
 	Ext.reg('myNumberField', MyNumberField);  
 	
 	/*
 	 * 获取登录人员名称 
 	 */
 	justLogin = function(config){
 		Ext.Ajax.request({
			url:BasicUrl+"/itemInfo.htm?cmd=getUser",  
			method: 'POST',  
			params: {},
			success:function(result,action){
				var returnData = Ext.util.JSON.decode(result.responseText);
				if(""!=returnData.user&&null!=returnData.user){
					config.objectForm.getForm().findField(config.member).setValue(returnData.user) ;
					return true;
				}else
				{
					Ext.MessageBox.alert("超时","登录超时，请重新登录",function(btn){
					window.location.top.href=BasicUrl;
					return false;
					});
					
				 }
			},
			failure:function(){
				Ext.MessageBox.alert("超时","登录超时，请重新登录",function(btn){
					window.location.top.href=BasicUrl;
					return false;
					});
			}
	    	});	
 	}
 	/*
 	 * dateId为时间ID值，ls==end时，通过dateId（开始时间ID），
 	 * 检查开始时间的是否超过截止时间，是的话则设置开始时间为空值
	 *								
 	 */
 	 LsDateField = function(config){
		 var config = config || {};    
		 var defaultConfig = {
		 	width:126
		  };
		 Ext.applyIf(config,defaultConfig);
		 LsDateField.superclass.constructor.call(this,{
		 	name : config.name,
		 	id:config.id,
		 	allowBlank :false||config.allowBlank,
			fieldLabel : config.fieldLabel,
			width:config.width,
			 listeners:{
				"change":function(e,newValue,oldValue){
					var tempDate=Ext.getCmp(config.dateId);
				 		if(config.ls=="end"){
				 			if(tempDate.value>e.value){
								tempDate.setValue('');
								}
							tempDate.setMaxValue(e.value) ;
				 		}else if(config.ls=="start"){
				 			if(tempDate.value<e.value){
								tempDate.setValue('');
								}
							tempDate.setMinValue(e.value) ;
				 		}
					}
				}
		 }); 
	 }
	Ext.extend(LsDateField,MyDateField);
 	Ext.reg('lsDateField', LsDateField);  
 	
 	var recordIds=new Array();// 选中的Record主键列id列表  
	var recordsChecked=new Array();// 选中的Record列表  
 	function RemoveArray(array,attachId){  
        for(var i=0,n=0;i<array.length;i++){  
            if(array[i]!=attachId){  
                array[n++]=array[i]  
            }  
        }
        if(array.length>0)
        	array.length -= 1;  
    }  
    function containsArray(array,attachId){  
       for(var i=0;i<array.length;i++){  
           if(array[i]==attachId){  
               return true;  
               break;  
           }  
       }  
      return false;  
   }   
   
 

   Array.prototype.remove = function (obj) {  
       return RemoveArray(this,obj);  
   };   
   Array.prototype.contains = function (obj) {  
       return containsArray(this,obj);  
   };   
// 	var selMod = new Ext.grid.CheckboxSelectionModel({
//                 listeners : {
//                     "rowdeselect" : function(e, rowIndex, record) {
//                             if (recordIds.contains(record.data.id)) {
//                                 recordIds.remove(record.data.id);  
//                                 recordsChecked.remove(record.get('id'));  
//                             }  
//                           
//                     },  
//                     "rowselect" : function(e, rowIndex, record) {
//                             if (!recordIds.contains(record.data.id)) {
//                                 recordIds.push(record.data.id);  
//                             	 recordsChecked.push(record.get('id'));  
//                             }
//                         }  
//                       
//                 }  
//    });  
   //单选下拉框
SingleSelect = Ext.extend(Ext.form.ComboBox, {
    triggerAction: 'all',
    mode: 'local',
    editable: false,
//    emptyText: '请选择...',
    displayField: 'text',
    valueField: 'value',
    reader:this.reader,
    /*
    @store 数组数据源 例如:[[1,'a'],[2,'b'],[3,'c']]或['a','b','c']
    */
    initComponent: function() {
        this.hiddenName = this.name;
        SingleSelect.superclass.initComponent.call(this);
    },

    setValue: function(v) {
        if (Ext.type(v) == 'object') {
            v = v[this.valueField];
        }
        SingleSelect.superclass.setValue.call(this, v);
    }
});
Ext.reg('select', SingleSelect);

//多选下拉框
MultiSelect = Ext.extend(SingleSelect, {
    tpl: '<div class="multiselect"></div>',

    // private
    initList: function() {
        MultiSelect.superclass.initList.call(this);
        this.initCheckBox();
    },

    // private
    initCheckBox: function() {
        var ct = this.innerList.first('.multiselect');
        this.items = new Ext.util.MixedCollection();
        var fn = function(r) {
            var c = new Ext.form.Checkbox({
                boxLabel: r.data[this.displayField],
                inputValue: r.data[this.valueField],
                renderTo: ct
            });
            this.items.add(c);
        };
        this.store.each(fn, this);
        this.on('collapse', this.onCollapse, this);
        this.on('expand', this.onExpand, this);
    },

    onCollapse: function() {
        var value = [];
        var fn = function(c) {
            if (c.getValue()) {
                value.push(c.el.dom.value);
            }
        };
        this.items.each(fn);
        this.setValue(value);
    },

    setValue: function(v) {
        if (!Ext.isArray(v)) { v = [v]; }
        this.hiddenField.value = v;
        Ext.form.ComboBox.superclass.setValue.call(this, this.getTexts(v));
//         Ext.form.ComboBox.superclass.setRawValue.call(this, this.getTexts(v));
        this.value = v;
    },

    getTexts: function(v) {
        var texts = [];
        var fn = function(r) {
            var rv = r.data[this.valueField];

            for (var i = 0; i < v.length; i++) {
                if (rv == v[i]) {
                    texts.push(r.data[this.displayField]);
                    break;
                }
            }
        };
        this.store.each(fn, this);
        return texts.join();
    },

    onExpand: function() {
        if (!Ext.isArray(this.value) || this.value.length == 0) { return; }

        var v = this.value;

        var fn = function(item) {
            var rv = item.el.dom.value;
            item.setValue(false);
            
            for (var i = 0; i < v.length; i++) {
                if (rv == v[i]) {
                    item.setValue(true);
                    break;
                }
            }
        };

        this.items.each(fn);
    }
});
Ext.reg('multiselect', MultiSelect);
   
   