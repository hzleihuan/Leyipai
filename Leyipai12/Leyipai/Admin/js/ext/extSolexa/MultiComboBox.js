/*
* Ext2.2扩展组件
* Author:microboat@gmail.com
* Update:2009-05-21
*/
Ext.namespace('Boat.UI');

//单选下拉框
Boat.UI.SingleSelect = Ext.extend(Ext.form.ComboBox, {
    triggerAction: 'all',
    mode: 'local',
    editable: false,
    emptyText: '请选择...',
    displayField: 'text',
    valueField: 'value',
    /*
    @store 数组数据源 例如:[[1,'a'],[2,'b'],[3,'c']]或['a','b','c']
    */
    initComponent: function() {
        this.hiddenName = this.name;
        Boat.UI.SingleSelect.superclass.initComponent.call(this);
    },

    setValue: function(v) {
        if (Ext.type(v) == 'object') {
            v = v[this.valueField];
        }
        Boat.UI.SingleSelect.superclass.setValue.call(this, v);
    }
});
Ext.reg('select', Boat.UI.SingleSelect);

//多选下拉框
Boat.UI.MultiSelect = Ext.extend(Boat.UI.SingleSelect, {
    tpl: '<div class="multiselect"></div>',

    // private
    initList: function() {
        Boat.UI.MultiSelect.superclass.initList.call(this);
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
Ext.reg('multiselect', Boat.UI.MultiSelect);