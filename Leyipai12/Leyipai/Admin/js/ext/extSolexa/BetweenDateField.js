Ext.apply(Ext.form.VTypes, {
    daterange : function(val, field) {
        var date = field.parseDate(val);

        if(!date){
            return;
        }
        if (field.startDateField && (!this.dateRangeMax || (date.getTime() != this.dateRangeMax.getTime()))) {
            var start = Ext.getCmp(field.startDateField);
            start.setMaxValue(date);
            start.validate();
            this.dateRangeMax = date;
        } 
        else if (field.endDateField && (!this.dateRangeMin || (date.getTime() != this.dateRangeMin.getTime()))) {
            var end = Ext.getCmp(field.endDateField);
            end.setMinValue(date);
            end.validate();
            this.dateRangeMin = date;
        }
        return true;
    }
});
/**
name 和id 一样
config={
   fieldLabel:"日期",
   startName:"date1",
   endName:"date2"
}

*/
function getBetweenDatePanel(config){

 return {
       layout:'column',
       xtype:'panel',
       anchor:'95%',
       items:[{
                columnWidth:.60,
                layout: 'form',
                items: [{
                    xtype:'datefield',
                    fieldLabel:config.fieldLabel,
                    name: config.startName,
                    anchor:'95%',
                  //  id:config.startName,
                  //  vtype: 'daterange',
                  //  startDateField:config.endName,
                  //hideLabel: true ,
                    editable:false,
                    format:"Y-m-d"
              
                }]},{
                columnWidth:.4,
                layout: 'form',
                labelWidth:20,
                items: [{
                    xtype:'datefield',
                    name: config.endName,
                    fieldLabel:'到',
                    labelSeparator:"",
                   // labelStyle:"50px;",
                    // id:config.endName,
                  //  hideLabel: true,
//                    fieldTpl:new Ext.Template(
//							    '<div class="x-form-item {itemCls}" tabIndex="-1">',
//							        '<label for="{id}" style="{labelStyle}" class="x-form-item-label">{label}{labelSeparator}</label>',
//							        '<div class="x-form-element" id="x-form-el-{id}" style="{elementStyle}">',
//							        '</div><div class="{clearCls}"></div>',
//							    '</div>'
//							),
                    anchor:'95%',
                  //  vtype:'daterange',
                  //  startDateField: config.startName,
                    editable:false,
                    format:"Y-m-d"
                }]
          }]};
 
 }			
               