
Ext.onReady(function(){
	
	Ext.QuickTips.init();
	
	var viewport=new Ext.Viewport({
    renderTo: Ext.getBody(),
	layout:'border',
	items:[
	{region:'north',html:'north'},
	{region:'south',html:'south'},
	{region:'east',html:'east'},
	{region:'west',html:'west'},
	{region:'center',html:'center'}
	
	
	]
	});
	
	
	
});
