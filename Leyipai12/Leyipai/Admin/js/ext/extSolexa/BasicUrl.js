
var BasicUrl="/bms2010";
//重写window，可以让window最大化
	Ext.override(Ext.Window, {
	           maximizable:true,
               maxWidth:Ext.getBody().getWidth()*0.93,
               maxHeight:Ext.getBody().getHeight()*0.93
		});
		
	/*	
	* 改变语言加载相应的js文件
	* 
    * @param pathName 保存路径
    * @param language 保存的语言
    */
	function changeLanguage(pathName,language){
		language=language.toString().toLowerCase();
		if (null==language&&navigator.browserLanguage){   //对于IE
        	 language = navigator.browserLanguage;
         }
   	   	else  if(null==language&&navigator.language){ //对于mozilla, Firefor
         	 language = navigator.language;
   	     }

	   if(language.lastIndexOf("cn")>-1){
	   	  lagMain = "Lcn.js";
	 	  lagFile = pathName+'_Lcn.js'; 
	   }else  if(language.lastIndexOf("hk")>-1||language.lastIndexOf("tw")>-1){
	   	  lagMain = "Lhk.js";
	 	  lagFile = pathName+'_Lhk.js'; 
	   }else  if(language.lastIndexOf("en")>-1){
	   	  lagMain = "Len.js";
	 	  lagFile = pathName+'_Len.js'; 
	   }else{
	   	  lagMain = "Lcn.js";	
	 	  lagFile = pathName+'_Lcn.js'; 
	   };
	   
	    include_abc(BasicUrl+"/ext/"+lagMain);
	    include_abc(BasicUrl+"/"+lagFile);

	}
	
	/*	
	* 加载相应的js文件
	* 
    * @param path 保存路径
    */
	function include_abc(path)
	{     
	      var sobj = document.createElement('script');
	      sobj.type = "text/javascript";
	      sobj.src = path;
	      var headobj = document.getElementsByTagName('head')[0];
	      headobj.appendChild(sobj);
	}
	
	