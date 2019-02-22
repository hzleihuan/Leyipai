

/*
包括一个搜索条件和一个表格的panel
*/
Ext.user.ModulePanel = Ext.extend(Ext.Panel, {

 initComponent : function(){
        this.frame = false;
        Ext.user.ModulePanle.superclass.initComponent.call(this);
        
        //注册时间
        this.addEvents('beforetabchange','tabchange','contextmenu');
        
        this.setLayout(new Ext.layout.CardLayout(Ext.apply({
            layoutOnCardChange: this.layoutOnTabChange,
            deferredRender: this.deferredRender
        }, this.layoutConfig)));
    }
});

Ext.reg('modulepanel', Ext.TabPanel);