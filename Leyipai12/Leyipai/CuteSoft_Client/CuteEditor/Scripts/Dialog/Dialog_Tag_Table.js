var OxO160d=["","removeNode","parentNode","firstChild","nodeName","TABLE","length","Can\x27t Get The Position ?","Map","RowCount","ColCount","rows","cells","Unknown Error , pos ",":"," already have cell","rowSpan","colSpan","Unknown Error , Unable to find bestpos","inp_cellspacing","inp_cellpadding","inp_id","inp_border","inp_bgcolor","inp_bordercolor","sel_rules","inp_collapse","inp_summary","btn_editcaption","btn_delcaption","btn_insthead","btn_instfoot","inp_class","inp_width","sel_width_unit","inp_height","sel_height_unit","sel_align","sel_textalign","sel_float","inp_tooltip","onclick","tHead","tFoot","caption","innerHTML","[[Caption]]","innerText","Unable to delete the caption. Please remove it in HTML source.","[[Delete]]","[[Insert]]","[[Edit]]","display","style","none","disabled","cellSpacing","value","cellPadding","id","border","borderColor","backgroundColor","bgColor","borderCollapse","checked","collapse","rules","summary","className","width","options","selectedIndex","height","align","styleFloat","cssFloat","textAlign","title","bordercolor","[[ValidID]]","0","%","class","CaptionTable"]; function ParseFloatToString(Ox24){var Ox8=parseFloat(Ox24);if(isNaN(Ox8)){return OxO160d[0x0];} ;return Ox8+OxO160d[0x0];}  ; function Element_RemoveNode(element,Ox494){if(element[OxO160d[0x1]]){ element.removeNode(Ox494) ;return ;} ;var p=element[OxO160d[0x2]];if(!p){return ;} ;if(Ox494){ p.removeChild(element) ;return ;} ;while(true){var Ox1bd=element[OxO160d[0x3]];if(!Ox1bd){break ;} ; p.insertBefore(Ox1bd,element) ;} ; p.removeChild(element) ;}  ; function Table_GetTable(Ox42){for(;Ox42!=null;Ox42=Ox42[OxO160d[0x2]]){if(Ox42[OxO160d[0x4]]==OxO160d[0x5]){return Ox42;} ;} ;return null;}  ; function Table_GetCellPositionFromMap(Ox48e,Ox315){for(var y=0x0;y<Ox48e[OxO160d[0x6]];y++){var Ox491=Ox48e[y];for(var x=0x0;x<Ox491[OxO160d[0x6]];x++){if(Ox491[x]==Ox315){return {rowIndex:y,cellIndex:x};} ;} ;} ;throw ( new Error(-0x1,OxO160d[0x7]));}  ; function Table_GetCellMap(Ox313){return Table_CalculateTableInfo(Ox313)[OxO160d[0x8]];}  ; function Table_GetRowCount(Ox42){return Table_CalculateTableInfo(Ox42)[OxO160d[0x9]];}  ; function Table_GetColCount(Ox42){return Table_CalculateTableInfo(Ox42)[OxO160d[0xa]];}  ; function Table_CalculateTableInfo(Ox42){var Ox313=Table_GetTable(Ox42);var Ox4a1=Ox313[OxO160d[0xb]];for(var Oxa=Ox4a1[OxO160d[0x6]]-0x1;Oxa>=0x0;Oxa--){var Ox305=Ox4a1.item(Oxa);if(Ox305[OxO160d[0xc]][OxO160d[0x6]]==0x0){ Element_RemoveNode(Ox305,true) ;continue ;} ;} ;var Ox4a2=Ox4a1[OxO160d[0x6]];var Ox4a3=0x0;var Ox4a4= new Array(Ox4a1.length);for(var Ox4a5=0x0;Ox4a5<Ox4a2;Ox4a5++){ Ox4a4[Ox4a5]=[] ;} ; function Ox4a6(Oxa,Ox1bd,Ox315){while(Oxa>=Ox4a2){ Ox4a4[Ox4a2]=[] ; Ox4a2++ ;} ;var Ox4a7=Ox4a4[Oxa];if(Ox1bd>=Ox4a3){ Ox4a3=Ox1bd+0x1 ;} ;if(Ox4a7[Ox1bd]!=null){throw ( new Error(-0x1,OxO160d[0xd]+Oxa+OxO160d[0xe]+Ox1bd+OxO160d[0xf]));} ; Ox4a7[Ox1bd]=Ox315 ;}  ; function Ox4a8(Oxa,Ox1bd){var Ox4a7=Ox4a4[Oxa];if(Ox4a7){return Ox4a7[Ox1bd];} ;}  ;for(var Ox4a5=0x0;Ox4a5<Ox4a1[OxO160d[0x6]];Ox4a5++){var Ox305=Ox4a1.item(Ox4a5);var Ox4a9=Ox305[OxO160d[0xc]];for(var Ox319=0x0;Ox319<Ox4a9[OxO160d[0x6]];Ox319++){var Ox315=Ox4a9.item(Ox319);var Ox4aa=Ox315[OxO160d[0x10]];var Ox4ab=Ox315[OxO160d[0x11]];var Ox4a7=Ox4a4[Ox4a5];var Ox4ac=-0x1;for(var Ox4ad=0x0;Ox4ad<Ox4a3+Ox4ab+0x1;Ox4ad++){if(Ox4aa==0x1&&Ox4ab==0x1){if(Ox4a7[Ox4ad]==null){ Ox4ac=Ox4ad ;break ;} ;} else {var Ox4ae=true;for(var Ox4af=0x0;Ox4af<Ox4aa;Ox4af++){for(var Ox4b0=0x0;Ox4b0<Ox4ab;Ox4b0++){if(Ox4a8(Ox4a5+Ox4af,Ox4ad+Ox4b0)!=null){ Ox4ae=false ;break ;} ;} ;} ;if(Ox4ae){ Ox4ac=Ox4ad ;break ;} ;} ;} ;if(Ox4ac==-0x1){throw ( new Error(-0x1,OxO160d[0x12]));} ;if(Ox4aa==0x1&&Ox4ab==0x1){ Ox4a6(Ox4a5,Ox4ac,Ox315) ;} else {for(var Ox4af=0x0;Ox4af<Ox4aa;Ox4af++){for(var Ox4b0=0x0;Ox4b0<Ox4ab;Ox4b0++){ Ox4a6(Ox4a5+Ox4af,Ox4ac+Ox4b0,Ox315) ;} ;} ;} ;} ;} ;var Ox137={}; Ox137[OxO160d[0x9]]=Ox4a2 ; Ox137[OxO160d[0xa]]=Ox4a3 ; Ox137[OxO160d[0x8]]=Ox4a4 ;for(var Oxa=0x0;Oxa<Ox4a2;Oxa++){var Ox4a7=Ox4a4[Oxa];for(var Ox1bd=0x0;Ox1bd<Ox4a3;Ox1bd++){} ;} ;return Ox137;}  ;var inp_cellspacing=Window_GetElement(window,OxO160d[0x13],true);var inp_cellpadding=Window_GetElement(window,OxO160d[0x14],true);var inp_id=Window_GetElement(window,OxO160d[0x15],true);var inp_border=Window_GetElement(window,OxO160d[0x16],true);var inp_bgcolor=Window_GetElement(window,OxO160d[0x17],true);var inp_bordercolor=Window_GetElement(window,OxO160d[0x18],true);var sel_rules=Window_GetElement(window,OxO160d[0x19],true);var inp_collapse=Window_GetElement(window,OxO160d[0x1a],true);var inp_summary=Window_GetElement(window,OxO160d[0x1b],true);var btn_editcaption=Window_GetElement(window,OxO160d[0x1c],true);var btn_delcaption=Window_GetElement(window,OxO160d[0x1d],true);var btn_insthead=Window_GetElement(window,OxO160d[0x1e],true);var btn_instfoot=Window_GetElement(window,OxO160d[0x1f],true);var inp_class=Window_GetElement(window,OxO160d[0x20],true);var inp_width=Window_GetElement(window,OxO160d[0x21],true);var sel_width_unit=Window_GetElement(window,OxO160d[0x22],true);var inp_height=Window_GetElement(window,OxO160d[0x23],true);var sel_height_unit=Window_GetElement(window,OxO160d[0x24],true);var sel_align=Window_GetElement(window,OxO160d[0x25],true);var sel_textalign=Window_GetElement(window,OxO160d[0x26],true);var sel_float=Window_GetElement(window,OxO160d[0x27],true);var inp_tooltip=Window_GetElement(window,OxO160d[0x28],true); function insertOneRow(Ox5a3,Ox38e){var Ox305=Ox5a3.insertRow(-0x1);for(var i=0x0;i<Ox38e;i++){ Ox305.insertCell() ;} ;}  ; btn_insthead[OxO160d[0x29]]=function btn_insthead_onclick(){if(element[OxO160d[0x2a]]){ element.deleteTHead() ;} else {var Ox5a5=Table_GetColCount(element);var Ox5a6=element.createTHead(); insertOneRow(Ox5a6,Ox5a5) ;} ;}  ; btn_instfoot[OxO160d[0x29]]=function btn_instfoot_onclick(){if(element[OxO160d[0x2b]]){ element.deleteTFoot() ;} else {var Ox5a5=Table_GetColCount(element);var Ox5a8=element.createTFoot(); insertOneRow(Ox5a8,Ox5a5) ;} ;}  ; btn_editcaption[OxO160d[0x29]]=function btn_editcaption_onclick(){var Ox5aa=element[OxO160d[0x2c]];if(Ox5aa!=null){var Ox1ff=editor.EditInWindow(Ox5aa.innerHTML,window);if(Ox1ff!=null&&Ox1ff!==false){ Ox5aa[OxO160d[0x2d]]=Ox1ff ;} ;} else {var Ox5aa=element.createCaption();if(Browser_IsGecko()){ Ox5aa[OxO160d[0x2d]]=OxO160d[0x2e] ;} else { Ox5aa[OxO160d[0x2f]]=OxO160d[0x2e] ;} ;} ;}  ; btn_delcaption[OxO160d[0x29]]=function btn_delcaption_onclick(){if(element[OxO160d[0x2c]]!=null){ alert(OxO160d[0x30]) ;} ;}  ; UpdateState=function UpdateState_Table(){if(Browser_IsGecko()){ btn_insthead[OxO160d[0x2d]]=element[OxO160d[0x2a]]?OxO160d[0x31]:OxO160d[0x32] ; btn_instfoot[OxO160d[0x2d]]=element[OxO160d[0x2b]]?OxO160d[0x31]:OxO160d[0x32] ;} else { btn_insthead[OxO160d[0x2f]]=element[OxO160d[0x2a]]?OxO160d[0x31]:OxO160d[0x32] ; btn_instfoot[OxO160d[0x2f]]=element[OxO160d[0x2b]]?OxO160d[0x31]:OxO160d[0x32] ;} ;if(element[OxO160d[0x2c]]!=null){if(Browser_IsGecko()){ btn_editcaption[OxO160d[0x2d]]=OxO160d[0x33] ;} else { btn_editcaption[OxO160d[0x2f]]=OxO160d[0x33] ;} ; btn_editcaption[OxO160d[0x35]][OxO160d[0x34]]=OxO160d[0x36] ; btn_delcaption[OxO160d[0x37]]=false ;} else {if(Browser_IsGecko()){ btn_editcaption[OxO160d[0x2d]]=OxO160d[0x32] ;} else { btn_editcaption[OxO160d[0x2f]]=OxO160d[0x32] ;} ; btn_delcaption[OxO160d[0x37]]=true ;} ;}  ;var t_inp_width=OxO160d[0x0];var t_inp_height=OxO160d[0x0]; SyncToView=function SyncToView_Table(){ inp_cellspacing[OxO160d[0x39]]=element.getAttribute(OxO160d[0x38]) ; inp_cellpadding[OxO160d[0x39]]=element.getAttribute(OxO160d[0x3a]) ; inp_id[OxO160d[0x39]]=element.getAttribute(OxO160d[0x3b]) ; inp_border[OxO160d[0x39]]=element.getAttribute(OxO160d[0x3c]) ; inp_bordercolor[OxO160d[0x39]]=element.getAttribute(OxO160d[0x3d]) ; inp_bordercolor[OxO160d[0x35]][OxO160d[0x3e]]=inp_bordercolor[OxO160d[0x39]] ; inp_bgcolor[OxO160d[0x39]]=element.getAttribute(OxO160d[0x3f])||element[OxO160d[0x35]][OxO160d[0x3e]] ; inp_bgcolor[OxO160d[0x35]][OxO160d[0x3e]]=inp_bgcolor[OxO160d[0x39]] ; inp_collapse[OxO160d[0x41]]=element[OxO160d[0x35]][OxO160d[0x40]]==OxO160d[0x42] ; sel_rules[OxO160d[0x39]]=element.getAttribute(OxO160d[0x43]) ; inp_summary[OxO160d[0x39]]=element.getAttribute(OxO160d[0x44]) ; inp_class[OxO160d[0x39]]=element[OxO160d[0x45]] ;if(element.getAttribute(OxO160d[0x46])){ t_inp_width=element.getAttribute(OxO160d[0x46]) ;} else {if(element[OxO160d[0x35]][OxO160d[0x46]]){ t_inp_width=element[OxO160d[0x35]][OxO160d[0x46]] ;} ;} ;if(t_inp_width){ inp_width[OxO160d[0x39]]=ParseFloatToString(t_inp_width) ;for(var i=0x0;i<sel_width_unit[OxO160d[0x47]][OxO160d[0x6]];i++){var Ox13b=sel_width_unit[OxO160d[0x47]][i][OxO160d[0x39]];if(Ox13b&&t_inp_width.indexOf(Ox13b)!=-0x1){ sel_width_unit[OxO160d[0x48]]=i ;break ;} ;} ;} ;if(element.getAttribute(OxO160d[0x49])){ t_inp_height=element.getAttribute(OxO160d[0x49]) ;} else {if(element[OxO160d[0x35]][OxO160d[0x49]]){ t_inp_height=element[OxO160d[0x35]][OxO160d[0x49]] ;} ;} ;if(t_inp_height){ inp_height[OxO160d[0x39]]=ParseFloatToString(t_inp_height) ;for(var i=0x0;i<sel_height_unit[OxO160d[0x47]][OxO160d[0x6]];i++){var Ox13b=sel_height_unit[OxO160d[0x47]][i][OxO160d[0x39]];if(Ox13b&&t_inp_height.indexOf(Ox13b)!=-0x1){ sel_height_unit[OxO160d[0x48]]=i ;break ;} ;} ;} ; sel_align[OxO160d[0x39]]=element[OxO160d[0x4a]] ;if(Browser_IsWinIE()){ sel_float[OxO160d[0x39]]=element[OxO160d[0x35]][OxO160d[0x4b]] ;} else { sel_float[OxO160d[0x39]]=element[OxO160d[0x35]][OxO160d[0x4c]] ;} ; sel_textalign[OxO160d[0x39]]=element[OxO160d[0x35]][OxO160d[0x4d]] ; inp_tooltip[OxO160d[0x39]]=element[OxO160d[0x4e]] ;}  ; SyncTo=function SyncTo_Table(element){if(Browser_IsWinIE()){ element[OxO160d[0x3d]]=inp_bordercolor[OxO160d[0x39]] ;} else { element.setAttribute(OxO160d[0x4f],inp_bordercolor.value) ;} ;if(inp_bgcolor[OxO160d[0x39]]){if(element[OxO160d[0x35]][OxO160d[0x3e]]){ element[OxO160d[0x35]][OxO160d[0x3e]]=inp_bgcolor[OxO160d[0x39]] ;} else { element[OxO160d[0x3f]]=inp_bgcolor[OxO160d[0x39]] ;} ;} else { element.removeAttribute(OxO160d[0x3f]) ;} ; element[OxO160d[0x35]][OxO160d[0x40]]=inp_collapse[OxO160d[0x41]]?OxO160d[0x42]:OxO160d[0x0] ; element[OxO160d[0x43]]=sel_rules[OxO160d[0x39]]||OxO160d[0x0] ; element[OxO160d[0x44]]=inp_summary[OxO160d[0x39]] ; element[OxO160d[0x45]]=inp_class[OxO160d[0x39]] ; element[OxO160d[0x38]]=inp_cellspacing[OxO160d[0x39]] ; element[OxO160d[0x3a]]=inp_cellpadding[OxO160d[0x39]] ;var Ox2f4=/[^a-z\d]/i;if(Ox2f4.test(inp_id.value)){ alert(OxO160d[0x50]) ;return ;} ; element[OxO160d[0x3b]]=inp_id[OxO160d[0x39]] ;if(inp_border[OxO160d[0x39]]==OxO160d[0x0]){ element[OxO160d[0x3c]]=OxO160d[0x51] ;} else { element[OxO160d[0x3c]]=inp_border[OxO160d[0x39]] ;} ;if(inp_width[OxO160d[0x39]]==OxO160d[0x0]){ element.removeAttribute(OxO160d[0x46]) ; element[OxO160d[0x35]][OxO160d[0x46]]=OxO160d[0x0] ;} else {try{ t_inp_width=inp_width[OxO160d[0x39]] ;if(sel_width_unit[OxO160d[0x39]]==OxO160d[0x52]){ t_inp_width=inp_width[OxO160d[0x39]]+sel_width_unit[OxO160d[0x39]] ;} ;if(element[OxO160d[0x35]][OxO160d[0x46]]&&element[OxO160d[0x46]]){ element[OxO160d[0x35]][OxO160d[0x46]]=t_inp_width ; element[OxO160d[0x46]]=t_inp_width ;} else {if(element[OxO160d[0x35]][OxO160d[0x46]]){ element[OxO160d[0x35]][OxO160d[0x46]]=t_inp_width ;} else { element[OxO160d[0x46]]=t_inp_width ;} ;} ;} catch(x){} ;} ;if(inp_height[OxO160d[0x39]]==OxO160d[0x0]){ element.removeAttribute(OxO160d[0x49]) ; element[OxO160d[0x35]][OxO160d[0x49]]=OxO160d[0x0] ;} else {try{ t_inp_height=inp_height[OxO160d[0x39]] ;if(sel_height_unit[OxO160d[0x39]]==OxO160d[0x52]){ t_inp_height=inp_height[OxO160d[0x39]]+sel_height_unit[OxO160d[0x39]] ;} ; t_inp_height=inp_height[OxO160d[0x39]]+sel_height_unit[OxO160d[0x39]] ;if(element[OxO160d[0x35]][OxO160d[0x49]]&&element[OxO160d[0x49]]){ element[OxO160d[0x35]][OxO160d[0x49]]=t_inp_height ; element[OxO160d[0x49]]=t_inp_height ;} else {if(element[OxO160d[0x35]][OxO160d[0x49]]){ element[OxO160d[0x35]][OxO160d[0x49]]=t_inp_height ;} else { element[OxO160d[0x49]]=t_inp_height ;} ;} ;} catch(x){} ;} ; element[OxO160d[0x4a]]=sel_align[OxO160d[0x39]] ;if(Browser_IsWinIE()){ element[OxO160d[0x35]][OxO160d[0x4b]]=sel_float[OxO160d[0x39]] ;} else { element[OxO160d[0x35]][OxO160d[0x4c]]=sel_float[OxO160d[0x39]] ;} ; element[OxO160d[0x35]][OxO160d[0x4d]]=sel_textalign[OxO160d[0x39]] ; element[OxO160d[0x4e]]=inp_tooltip[OxO160d[0x39]] ;if(element[OxO160d[0x4e]]==OxO160d[0x0]){ element.removeAttribute(OxO160d[0x4e]) ;} ;if(element[OxO160d[0x44]]==OxO160d[0x0]){ element.removeAttribute(OxO160d[0x44]) ;} ;if(element[OxO160d[0x45]]==OxO160d[0x0]){ element.removeAttribute(OxO160d[0x45]) ;} ;if(element[OxO160d[0x45]]==OxO160d[0x0]){ element.removeAttribute(OxO160d[0x53]) ;} ;if(element[OxO160d[0x3b]]==OxO160d[0x0]){ element.removeAttribute(OxO160d[0x3b]) ;} ;if(element[OxO160d[0x4a]]==OxO160d[0x0]){ element.removeAttribute(OxO160d[0x4a]) ;} ;if(element[OxO160d[0x43]]==OxO160d[0x0]){ element.removeAttribute(OxO160d[0x43]) ;} ;}  ; inp_bgcolor[OxO160d[0x29]]=function inp_bgcolor_onclick(){ SelectColor(inp_bgcolor) ;}  ; inp_bordercolor[OxO160d[0x29]]=function inp_bordercolor_onclick(){ SelectColor(inp_bordercolor) ;}  ;if(!Browser_IsWinIE()){ Window_GetElement(window,OxO160d[0x54],true)[OxO160d[0x35]][OxO160d[0x34]]=OxO160d[0x36] ;} ;




