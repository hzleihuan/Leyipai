var OxO5474=["hiddenDirectory","hiddenFile","hiddenAlert","hiddenAction","hiddenActionData","hiddenHTML","This function is disabled in the demo mode.","disabled","[[Disabled]]","[[SpecifyNewFolderName]]","","value","createdir","[[CopyMoveto]]","/","move","copy","[[AreyouSureDelete]]","parentNode","path","[[TemplateModified]]","OuterEditorFull.aspx?","\x26f=","dialogWidth:760px;dialogHeight:385px;help:no;scroll:no;status:no;resizable:0;","UseStandardDialog","1","\x26Dialog=Standard","DNNArg","Theme","EditorSetting","setting=","\x26Theme=","\x26","[[TemplateCreated]]","refresh","[[SpecifyNewFileName]]","innerHTML","isdir","true","text",".","rename","True","False",":","FoldersAndFiles","TR","length","this.bgColor=\x27#eeeeee\x27;","onmouseover","this.bgColor=\x27\x27;","onmouseout","nodeName","INPUT","changedir","url","TargetUrl","htmlcode","onload","getElementsByTagName","table","sortable","className"," ","id","rows","cells","\x3Ca href=\x22#\x22 onclick=\x22ts_resortTable(this);return false;\x22\x3E","\x3Cspan class=\x22sortarrow\x22\x3E\x26nbsp;\x3C/span\x3E\x3C/a\x3E","string","undefined","innerText","childNodes","nodeValue","nodeType","span","cellIndex","TABLE","sortdir","down","\x26uarr;","up","\x26darr;","sortbottom","tBodies","sortarrow","\x26nbsp;","20","19","Form1","Image1","FolderDescription","CreateDir","Copy","Move","NewTemplate","Delete","DoRefresh","contentWindow","framepreview","Button1","Button2","btn_zoom_in","btn_zoom_out","btn_Actualsize","?","src","body","document","\x26#",";","zoom","style","wrapupPrompt","iepromptfield","display","none","div","IEPromptBox","promptBlackout","border","1px solid #b0bec7","backgroundColor","#f0f0f0","position","absolute","width","330px","zIndex","100","\x3Cdiv style=\x22width: 100%; padding-top:3px;background-color: #DCE7EB; font-family: verdana; font-size: 10pt; font-weight: bold; height: 22px; text-align:center; background:url(Load.ashx?type=image\x26file=formbg2.gif) repeat-x left top;\x22\x3E[[InputRequired]]\x3C/div\x3E","\x3Cdiv style=\x22padding: 10px\x22\x3E","\x3CBR\x3E\x3CBR\x3E","\x3Cform action=\x22\x22 onsubmit=\x22return wrapupPrompt()\x22\x3E","\x3Cinput id=\x22iepromptfield\x22 name=\x22iepromptdata\x22 type=text size=46 value=\x22","\x22\x3E","\x3Cbr\x3E\x3Cbr\x3E\x3Ccenter\x3E","\x3Cinput type=\x22submit\x22 value=\x22\x26nbsp;\x26nbsp;\x26nbsp;[[OK]]\x26nbsp;\x26nbsp;\x26nbsp;\x22\x3E","\x26nbsp;\x26nbsp;\x26nbsp;\x26nbsp;\x26nbsp;\x26nbsp;","\x3Cinput type=\x22button\x22 onclick=\x22wrapupPrompt(true)\x22 value=\x22\x26nbsp;[[Cancel]]\x26nbsp;\x22\x3E","\x3C/form\x3E\x3C/div\x3E","top","100px","offsetWidth","left","px","block","CuteEditor_ColorPicker_ButtonOver(this)"];var hiddenDirectory=Window_GetElement(window,OxO5474[0x0],true);var hiddenFile=Window_GetElement(window,OxO5474[0x1],true);var hiddenAlert=Window_GetElement(window,OxO5474[0x2],true);var hiddenAction=Window_GetElement(window,OxO5474[0x3],true);var hiddenActionData=Window_GetElement(window,OxO5474[0x4],true);var hiddenHTML=Window_GetElement(window,OxO5474[0x5],true); function CreateDir_click(){if(isDemoMode){ alert(OxO5474[0x6]) ;return false;} ;if(Event_GetSrcElement()[OxO5474[0x7]]){ alert(OxO5474[0x8]) ;return false;} ;if(Browser_IsIE7()){ IEprompt(Ox19b,OxO5474[0x9],OxO5474[0xa]) ; function Ox19b(Ox300){if(Ox300){ hiddenActionData[OxO5474[0xb]]=Ox300 ; hiddenAction[OxO5474[0xb]]=OxO5474[0xc] ; window.PostBackAction() ;return true;} else {return false;} ;}  ;return Event_CancelEvent();} else {var Ox300=prompt(OxO5474[0x9],OxO5474[0xa]);if(Ox300){ hiddenActionData[OxO5474[0xb]]=Ox300 ;return true;} else {return false;} ;return false;} ;}  ; function Move_click(){if(isDemoMode){ alert(OxO5474[0x6]) ;return false;} ;if(Event_GetSrcElement()[OxO5474[0x7]]){ alert(OxO5474[0x8]) ;return false;} ;if(Browser_IsIE7()){ IEprompt(Ox19b,OxO5474[0xd],OxO5474[0xe]) ; function Ox19b(Ox300){if(Ox300){ hiddenActionData[OxO5474[0xb]]=Ox300 ; hiddenAction[OxO5474[0xb]]=OxO5474[0xf] ; window.PostBackAction() ;return true;} else {return false;} ;}  ;return Event_CancelEvent();} else {var Ox300=prompt(OxO5474[0xd],OxO5474[0xe]);if(Ox300){ hiddenActionData[OxO5474[0xb]]=Ox300 ;return true;} else {return false;} ;return false;} ;}  ; function Copy_click(){if(isDemoMode){ alert(OxO5474[0x6]) ;return false;} ;if(Event_GetSrcElement()[OxO5474[0x7]]){ alert(OxO5474[0x8]) ;return false;} ;if(Browser_IsIE7()){ IEprompt(Ox19b,OxO5474[0xd],OxO5474[0xe]) ; function Ox19b(Ox300){if(Ox300){ hiddenActionData[OxO5474[0xb]]=Ox300 ; hiddenAction[OxO5474[0xb]]=OxO5474[0x10] ; window.PostBackAction() ;return true;} else {return false;} ;}  ;return Event_CancelEvent();} else {var Ox300=prompt(OxO5474[0xd],OxO5474[0xe]);if(Ox300){ hiddenActionData[OxO5474[0xb]]=Ox300 ;return true;} else {return false;} ;return false;} ;}  ; function Delete_click(){if(isDemoMode){ alert(OxO5474[0x6]) ;return false;} ;if(Event_GetSrcElement()[OxO5474[0x7]]){ alert(OxO5474[0x8]) ;return false;} ;return confirm(OxO5474[0x11]);}  ; function EditImg_click(img){if(isDemoMode){ alert(OxO5474[0x6]) ;return false;} ;var Ox305=img[OxO5474[0x12]][OxO5474[0x12]];var p=Ox305.getAttribute(OxO5474[0x13]);if(p!=OxO5474[0xa]&&p!=null){ function Ox2db(Ox186){if(Ox186){ alert(OxO5474[0x14]) ; window.PostBackAction() ;} ;}  ; editor.SetNextDialogWindow(window) ; editor.ShowDialog(Ox2db,OxO5474[0x15]+GetDialogQueryString()+OxO5474[0x16]+p+OxO5474[0xa],window,OxO5474[0x17]) ;return true;} else {return false;} ;}  ; function GetDialogQueryString(){var Ox119=OxO5474[0xa];if(editor.GetScriptProperty(OxO5474[0x18])==OxO5474[0x19]){ Ox119=OxO5474[0x1a] ;} ;return OxO5474[0x1e]+editor.GetScriptProperty(OxO5474[0x1d])+OxO5474[0x1f]+editor.GetScriptProperty(OxO5474[0x1c])+Ox119+OxO5474[0x20]+editor.GetScriptProperty(OxO5474[0x1b]);}  ; function NewTemplate_Click(){if(isDemoMode){ alert(OxO5474[0x6]) ;return false;} ; function Ox2db(Ox186){if(Ox186){ alert(OxO5474[0x21]) ; hiddenActionData[OxO5474[0xb]]=OxO5474[0xa] ; hiddenAction[OxO5474[0xb]]=OxO5474[0x22] ; window.PostBackAction() ;} ;}  ;if(Browser_IsIE7()){ IEprompt(Ox19b,OxO5474[0x23],OxO5474[0xa]) ; function Ox19b(Ox300){if(Ox300){ Ox300=FolderDescription[OxO5474[0x24]]+Ox300 ; editor.SetNextDialogWindow(window) ; editor.ShowDialog(Ox2db,OxO5474[0x15]+GetDialogQueryString()+OxO5474[0x16]+Ox300+OxO5474[0xa],window,OxO5474[0x17]) ;return true;} else {return false;} ;}  ;return Event_CancelEvent();} else {var Ox300=prompt(OxO5474[0x23],OxO5474[0xa]);if(Ox300){ Ox300=FolderDescription[OxO5474[0x24]]+Ox300 ; editor.SetNextDialogWindow(window) ; editor.ShowDialog(Ox2db,OxO5474[0x15]+GetDialogQueryString()+OxO5474[0x16]+Ox300+OxO5474[0xa],window,OxO5474[0x17]) ;return true;} else {return false;} ;} ;}  ; function GetDialogQueryString(){var Ox119=OxO5474[0xa];if(editor.GetScriptProperty(OxO5474[0x18])==OxO5474[0x19]){ Ox119=OxO5474[0x1a] ;} ;return OxO5474[0x1e]+editor.GetScriptProperty(OxO5474[0x1d])+OxO5474[0x1f]+editor.GetScriptProperty(OxO5474[0x1c])+Ox119+OxO5474[0x20]+editor.GetScriptProperty(OxO5474[0x1b]);}  ; function RenImg_click(img){if(isDemoMode){ alert(OxO5474[0x6]) ;return false;} ;if(img[OxO5474[0x7]]){ alert(OxO5474[0x8]) ;return false;} ;var Ox305=img[OxO5474[0x12]][OxO5474[0x12]];var Ox307;if(Browser_IsOpera()){ Ox307=Ox305.getAttribute(OxO5474[0x25])==OxO5474[0x26] ;} else { Ox307=Ox305[OxO5474[0x25]] ;} ;var Ox306=Ox305[OxO5474[0x27]];var name;if(Browser_IsIE7()){var Oxc3;if(Ox307){ IEprompt(Ox19b,OxO5474[0x9],Ox306) ;} else {var i=Ox306.lastIndexOf(OxO5474[0x28]); Oxc3=Ox306.substr(i) ;var Ox12=Ox306.substr(0x0,Ox306.lastIndexOf(OxO5474[0x28])); IEprompt(Ox19b,OxO5474[0x23],Ox12) ;} ; function Ox19b(Ox300){if(Ox300&&Ox300!=Ox305[OxO5474[0x27]]){if(!Ox307){ Ox300=Ox300+Oxc3 ;} ; hiddenAction[OxO5474[0xb]]=OxO5474[0x29] ; hiddenActionData[OxO5474[0xb]]=(Ox307?OxO5474[0x2a]:OxO5474[0x2b])+OxO5474[0x2c]+Ox305[OxO5474[0x13]]+OxO5474[0x2c]+Ox300 ; window.PostBackAction() ;} ;}  ;} else {if(Ox307){ name=prompt(OxO5474[0x9],Ox306) ;} else {var i=Ox306.lastIndexOf(OxO5474[0x28]);var Oxc3=Ox306.substr(i);var Ox12=Ox306.substr(0x0,Ox306.lastIndexOf(OxO5474[0x28])); name=prompt(OxO5474[0x23],Ox12) ;if(name){ name=name+Oxc3 ;} ;} ;if(name&&name!=Ox305[OxO5474[0x27]]){ hiddenAction[OxO5474[0xb]]=OxO5474[0x29] ; hiddenActionData[OxO5474[0xb]]=(Ox307?OxO5474[0x2a]:OxO5474[0x2b])+OxO5474[0x2c]+Ox305[OxO5474[0x13]]+OxO5474[0x2c]+name ; window.PostBackAction() ;} ;} ;return Event_CancelEvent();}  ; setMouseOver() ; function setMouseOver(){var FoldersAndFiles=Window_GetElement(window,OxO5474[0x2d],true);var Ox30a=FoldersAndFiles.getElementsByTagName(OxO5474[0x2e]);for(var i=0x0;i<Ox30a[OxO5474[0x2f]];i++){var Ox305=Ox30a[i]; Ox305[OxO5474[0x31]]= new Function(OxO5474[0xa],OxO5474[0x30]) ; Ox305[OxO5474[0x33]]= new Function(OxO5474[0xa],OxO5474[0x32]) ;} ;}  ; function row_click(Ox305){var Ox307;if(Browser_IsOpera()){ Ox307=Ox305.getAttribute(OxO5474[0x25])==OxO5474[0x26] ;} else { Ox307=Ox305[OxO5474[0x25]] ;} ;if(Ox307){if(Event_GetSrcElement()[OxO5474[0x34]]==OxO5474[0x35]){return ;} ; hiddenAction[OxO5474[0xb]]=OxO5474[0x36] ; hiddenActionData[OxO5474[0xb]]=Ox305.getAttribute(OxO5474[0x13]) ; window.PostBackAction() ;} else {var Ox102=Ox305.getAttribute(OxO5474[0x13]); hiddenFile[OxO5474[0xb]]=Ox102 ;var Ox205=Ox305.getAttribute(OxO5474[0x37]); Window_GetElement(window,OxO5474[0x38],true)[OxO5474[0xb]]=Ox205 ;var htmlcode=Ox305.getAttribute(OxO5474[0x39]);if(htmlcode!=OxO5474[0xa]&&htmlcode!=null){ do_preview(htmlcode) ;} else {try{ Actualsize() ;} catch(x){ do_preview() ;} ;} ;} ;}  ; function do_preview(){}  ; function reset_hiddens(){if(hiddenAlert[OxO5474[0xb]]){ alert(hiddenAlert.value) ;} ;if(hiddenHTML[OxO5474[0xb]]){ do_preview(hiddenHTML.value) ;} ; hiddenAlert[OxO5474[0xb]]=OxO5474[0xa] ; hiddenHTML[OxO5474[0xb]]=OxO5474[0xa] ; hiddenAction[OxO5474[0xb]]=OxO5474[0xa] ; hiddenActionData[OxO5474[0xb]]=OxO5474[0xa] ;}  ; Event_Attach(window,OxO5474[0x3a],reset_hiddens) ; function RequireFileBrowseScript(){}  ; Event_Attach(window,OxO5474[0x3a],sortables_init) ;var SORT_COLUMN_INDEX; function sortables_init(){if(!document[OxO5474[0x3b]]){return ;} ;var Ox30f=document.getElementsByTagName(OxO5474[0x3c]);for(var Ox310=0x0;Ox310<Ox30f[OxO5474[0x2f]];Ox310++){var Ox311=Ox30f[Ox310];if(((OxO5474[0x3f]+Ox311[OxO5474[0x3e]]+OxO5474[0x3f]).indexOf(OxO5474[0x3d])!=-0x1)&&(Ox311[OxO5474[0x40]])){ ts_makeSortable(Ox311) ;} ;} ;}  ; function ts_makeSortable(Ox313){if(Ox313[OxO5474[0x41]]&&Ox313[OxO5474[0x41]][OxO5474[0x2f]]>0x0){var Ox314=Ox313[OxO5474[0x41]][0x0];} ;if(!Ox314){return ;} ;for(var i=0x2;i<0x4;i++){var Ox315=Ox314[OxO5474[0x42]][i];var Ox200=ts_getInnerText(Ox315); Ox315[OxO5474[0x24]]=OxO5474[0x43]+Ox200+OxO5474[0x44] ;} ;}  ; function ts_getInnerText(Ox27){if( typeof Ox27==OxO5474[0x45]){return Ox27;} ;if( typeof Ox27==OxO5474[0x46]){return Ox27;} ;if(Ox27[OxO5474[0x47]]){return Ox27[OxO5474[0x47]];} ;var Ox24=OxO5474[0xa];var Ox2c1=Ox27[OxO5474[0x48]];var Ox11=Ox2c1[OxO5474[0x2f]];for(var i=0x0;i<Ox11;i++){switch(Ox2c1[i][OxO5474[0x4a]]){case 0x1: Ox24+=ts_getInnerText(Ox2c1[i]) ;break ;case 0x3: Ox24+=Ox2c1[i][OxO5474[0x49]] ;break ;;;} ;} ;return Ox24;}  ; function ts_resortTable(Ox318){var Ox224;for(var Ox319=0x0;Ox319<Ox318[OxO5474[0x48]][OxO5474[0x2f]];Ox319++){if(Ox318[OxO5474[0x48]][Ox319][OxO5474[0x34]]&&Ox318[OxO5474[0x48]][Ox319][OxO5474[0x34]].toLowerCase()==OxO5474[0x4b]){ Ox224=Ox318[OxO5474[0x48]][Ox319] ;} ;} ;var Ox31a=ts_getInnerText(Ox224);var Ox31b=Ox318[OxO5474[0x12]];var Ox31c=Ox31b[OxO5474[0x4c]];var Ox313=getParent(Ox31b,OxO5474[0x4d]);if(Ox313[OxO5474[0x41]][OxO5474[0x2f]]<=0x1){return ;} ;var Ox31d=ts_getInnerText(Ox313[OxO5474[0x41]][0x1][OxO5474[0x42]][Ox31c]);var Ox31e=ts_sort_caseinsensitive;if(Ox31d.match(/^\d\d[\/-]\d\d[\/-]\d\d\d\d$/)){ Ox31e=ts_sort_date ;} ;if(Ox31d.match(/^\d\d[\/-]\d\d[\/-]\d\d$/)){ Ox31e=ts_sort_date ;} ;if(Ox31d.match(/^[?]/)){ Ox31e=ts_sort_currency ;} ;if(Ox31d.match(/^[\d\.]+$/)){ Ox31e=ts_sort_numeric ;} ; SORT_COLUMN_INDEX=Ox31c ;var Ox314= new Array();var Ox31f= new Array();for(var i=0x0;i<Ox313[OxO5474[0x41]][0x0][OxO5474[0x2f]];i++){ Ox314[i]=Ox313[OxO5474[0x41]][0x0][i] ;} ;for(var j=0x1;j<Ox313[OxO5474[0x41]][OxO5474[0x2f]];j++){ Ox31f[j-0x1]=Ox313[OxO5474[0x41]][j] ;} ; Ox31f.sort(Ox31e) ;if(Ox224.getAttribute(OxO5474[0x4e])==OxO5474[0x4f]){var Ox320=OxO5474[0x50]; Ox31f.reverse() ; Ox224.setAttribute(OxO5474[0x4e],OxO5474[0x51]) ;} else { Ox320=OxO5474[0x52] ; Ox224.setAttribute(OxO5474[0x4e],OxO5474[0x4f]) ;} ;for( i=0x0 ;i<Ox31f[OxO5474[0x2f]];i++){if(!Ox31f[i][OxO5474[0x3e]]||(Ox31f[i][OxO5474[0x3e]]&&(Ox31f[i][OxO5474[0x3e]].indexOf(OxO5474[0x53])==-0x1))){ Ox313[OxO5474[0x54]][0x0].appendChild(Ox31f[i]) ;} ;} ;for( i=0x0 ;i<Ox31f[OxO5474[0x2f]];i++){if(Ox31f[i][OxO5474[0x3e]]&&(Ox31f[i][OxO5474[0x3e]].indexOf(OxO5474[0x53])!=-0x1)){ Ox313[OxO5474[0x54]][0x0].appendChild(Ox31f[i]) ;} ;} ;var Ox321=document.getElementsByTagName(OxO5474[0x4b]);for(var Ox319=0x0;Ox319<Ox321[OxO5474[0x2f]];Ox319++){if(Ox321[Ox319][OxO5474[0x3e]]==OxO5474[0x55]){if(getParent(Ox321[Ox319],OxO5474[0x3c])==getParent(Ox318,OxO5474[0x3c])){ Ox321[Ox319][OxO5474[0x24]]=OxO5474[0x56] ;} ;} ;} ; Ox224[OxO5474[0x24]]=Ox320 ;}  ; function getParent(Ox27,Ox323){if(Ox27==null){return null;} else {if(Ox27[OxO5474[0x4a]]==0x1&&Ox27[OxO5474[0x34]].toLowerCase()==Ox323.toLowerCase()){return Ox27;} else {return getParent(Ox27.parentNode,Ox323);} ;} ;}  ; function ts_sort_date(Oxe7,b){var Ox325=ts_getInnerText(Oxe7[OxO5474[0x42]][SORT_COLUMN_INDEX]);var Ox326=ts_getInnerText(b[OxO5474[0x42]][SORT_COLUMN_INDEX]);if(Ox325[OxO5474[0x2f]]==0xa){var Ox327=Ox325.substr(0x6,0x4)+Ox325.substr(0x3,0x2)+Ox325.substr(0x0,0x2);} else {var Ox328=Ox325.substr(0x6,0x2);if(parseInt(Ox328)<0x32){ Ox328=OxO5474[0x57]+Ox328 ;} else { Ox328=OxO5474[0x58]+Ox328 ;} ;var Ox327=Ox328+Ox325.substr(0x3,0x2)+Ox325.substr(0x0,0x2);} ;if(Ox326[OxO5474[0x2f]]==0xa){var Ox329=Ox326.substr(0x6,0x4)+Ox326.substr(0x3,0x2)+Ox326.substr(0x0,0x2);} else { Ox328=Ox326.substr(0x6,0x2) ;if(parseInt(Ox328)<0x32){ Ox328=OxO5474[0x57]+Ox328 ;} else { Ox328=OxO5474[0x58]+Ox328 ;} ;var Ox329=Ox328+Ox326.substr(0x3,0x2)+Ox326.substr(0x0,0x2);} ;if(Ox327==Ox329){return 0x0;} ;if(Ox327<Ox329){return -0x1;} ;return 0x1;}  ; function ts_sort_currency(Oxe7,b){var Ox325=ts_getInnerText(Oxe7[OxO5474[0x42]][SORT_COLUMN_INDEX]).replace(/[^0-9.]/g,OxO5474[0xa]);var Ox326=ts_getInnerText(b[OxO5474[0x42]][SORT_COLUMN_INDEX]).replace(/[^0-9.]/g,OxO5474[0xa]);return parseFloat(Ox325)-parseFloat(Ox326);}  ; function ts_sort_numeric(Oxe7,b){var Ox325=parseFloat(ts_getInnerText(Oxe7[OxO5474[0x42]][SORT_COLUMN_INDEX]));if(isNaN(Ox325)){ Ox325=0x0 ;} ;var Ox326=parseFloat(ts_getInnerText(b[OxO5474[0x42]][SORT_COLUMN_INDEX]));if(isNaN(Ox326)){ Ox326=0x0 ;} ;return Ox325-Ox326;}  ; function ts_sort_caseinsensitive(Oxe7,b){var Ox325=ts_getInnerText(Oxe7[OxO5474[0x42]][SORT_COLUMN_INDEX]).toLowerCase();var Ox326=ts_getInnerText(b[OxO5474[0x42]][SORT_COLUMN_INDEX]).toLowerCase();if(Ox325==Ox326){return 0x0;} ;if(Ox325<Ox326){return -0x1;} ;return 0x1;}  ; function ts_sort_default(Oxe7,b){var Ox325=ts_getInnerText(Oxe7[OxO5474[0x42]][SORT_COLUMN_INDEX]);var Ox326=ts_getInnerText(b[OxO5474[0x42]][SORT_COLUMN_INDEX]);if(Ox325==Ox326){return 0x0;} ;if(Ox325<Ox326){return -0x1;} ;return 0x1;} [sortables_init] ; RequireFileBrowseScript() ;var Form1=Window_GetElement(window,OxO5474[0x59],true);var hiddenDirectory=Window_GetElement(window,OxO5474[0x0],true);var hiddenFile=Window_GetElement(window,OxO5474[0x1],true);var hiddenAlert=Window_GetElement(window,OxO5474[0x2],true);var hiddenAction=Window_GetElement(window,OxO5474[0x3],true);var hiddenActionData=Window_GetElement(window,OxO5474[0x4],true);var Image1=Window_GetElement(window,OxO5474[0x5a],true);var FolderDescription=Window_GetElement(window,OxO5474[0x5b],true);var CreateDir=Window_GetElement(window,OxO5474[0x5c],true);var Copy=Window_GetElement(window,OxO5474[0x5d],true);var Move=Window_GetElement(window,OxO5474[0x5e],true);var NewTemplate=Window_GetElement(window,OxO5474[0x5f],true);var FoldersAndFiles=Window_GetElement(window,OxO5474[0x2d],true);var Delete=Window_GetElement(window,OxO5474[0x60],true);var DoRefresh=Window_GetElement(window,OxO5474[0x61],true);var framepreview=document.getElementById(OxO5474[0x63])[OxO5474[0x62]];var TargetUrl=Window_GetElement(window,OxO5474[0x38],true);var Button1=Window_GetElement(window,OxO5474[0x64],true);var Button2=Window_GetElement(window,OxO5474[0x65],true);var btn_zoom_in=Window_GetElement(window,OxO5474[0x66],true);var btn_zoom_out=Window_GetElement(window,OxO5474[0x67],true);var btn_Actualsize=Window_GetElement(window,OxO5474[0x68],true);var editor=Window_GetDialogArguments(window);var htmlcode=OxO5474[0xa]; function do_preview(Ox1ff){ htmlcode=Ox1ff ;if(Ox1ff==OxO5474[0xa]||Ox1ff==null){var Ox1ab=TargetUrl[OxO5474[0xb]];if(Ox1ab.indexOf(OxO5474[0x69])!=-0x1){ document.getElementById(OxO5474[0x63])[OxO5474[0x6a]]=Ox1ab ;} else { framepreview[OxO5474[0x6c]][OxO5474[0x6b]][OxO5474[0x24]]=OxO5474[0xa] ;} ;} else { framepreview[OxO5474[0x6c]][OxO5474[0x6b]][OxO5474[0x24]]=Ox1ff ;} ;}  ; function do_insert(){var Ox1ab=TargetUrl[OxO5474[0xb]];if(Ox1ab.indexOf(OxO5474[0x69])!=-0x1){ htmlcode=framepreview[OxO5474[0x6c]][OxO5474[0x6b]][OxO5474[0x24]] ;} ; htmlcode=htmlcode.replace(/[\u00A0-\u00FF|\u00FF-\uFFFF]/g,function (Oxe7,b,Ox1bd){return OxO5474[0x6d]+Oxe7.charCodeAt(0x0)+OxO5474[0x6e];} ) ; editor.PasteHTML(htmlcode) ; Window_CloseDialog(window) ;}  ; function do_Close(){ Window_CloseDialog(window) ;}  ; function Zoom_In(){if(framepreview[OxO5474[0x6c]][OxO5474[0x6b]][OxO5474[0x70]][OxO5474[0x6f]]!=0x0){ framepreview[OxO5474[0x6c]][OxO5474[0x6b]][OxO5474[0x70]][OxO5474[0x6f]]*=1.1 ;} else { framepreview[OxO5474[0x6c]][OxO5474[0x6b]][OxO5474[0x70]][OxO5474[0x6f]]=1.1 ;} ;}  ; function Zoom_Out(){if(framepreview[OxO5474[0x6c]][OxO5474[0x6b]][OxO5474[0x70]][OxO5474[0x6f]]!=0x0){ framepreview[OxO5474[0x6c]][OxO5474[0x6b]][OxO5474[0x70]][OxO5474[0x6f]]*=0.8 ;} else { framepreview[OxO5474[0x6c]][OxO5474[0x6b]][OxO5474[0x70]][OxO5474[0x6f]]=0.8 ;} ;}  ; function Actualsize(){ framepreview[OxO5474[0x6c]][OxO5474[0x6b]][OxO5474[0x70]][OxO5474[0x6f]]=0x1 ; do_preview(htmlcode) ;}  ;if(Browser_IsIE7()){var _dialogPromptID=null; function IEprompt(Ox19b,Ox19c,Ox19d){ that=this ; this[OxO5474[0x71]]=function (Ox19e){ val=document.getElementById(OxO5474[0x72])[OxO5474[0xb]] ; _dialogPromptID[OxO5474[0x70]][OxO5474[0x73]]=OxO5474[0x74] ; document.getElementById(OxO5474[0x72])[OxO5474[0xb]]=OxO5474[0xa] ;if(Ox19e){ val=OxO5474[0xa] ;} ; Ox19b(val) ;return false;}  ;if(Ox19d==undefined){ Ox19d=OxO5474[0xa] ;} ;if(_dialogPromptID==null){var Ox19f=document.getElementsByTagName(OxO5474[0x6b])[0x0]; tnode=document.createElement(OxO5474[0x75]) ; tnode[OxO5474[0x40]]=OxO5474[0x76] ; Ox19f.appendChild(tnode) ; _dialogPromptID=document.getElementById(OxO5474[0x76]) ; tnode=document.createElement(OxO5474[0x75]) ; tnode[OxO5474[0x40]]=OxO5474[0x77] ; Ox19f.appendChild(tnode) ; _dialogPromptID[OxO5474[0x70]][OxO5474[0x78]]=OxO5474[0x79] ; _dialogPromptID[OxO5474[0x70]][OxO5474[0x7a]]=OxO5474[0x7b] ; _dialogPromptID[OxO5474[0x70]][OxO5474[0x7c]]=OxO5474[0x7d] ; _dialogPromptID[OxO5474[0x70]][OxO5474[0x7e]]=OxO5474[0x7f] ; _dialogPromptID[OxO5474[0x70]][OxO5474[0x80]]=OxO5474[0x81] ;} ;var Ox1a0=OxO5474[0x82]; Ox1a0+=OxO5474[0x83]+Ox19c+OxO5474[0x84] ; Ox1a0+=OxO5474[0x85] ; Ox1a0+=OxO5474[0x86]+Ox19d+OxO5474[0x87] ; Ox1a0+=OxO5474[0x88] ; Ox1a0+=OxO5474[0x89] ; Ox1a0+=OxO5474[0x8a] ; Ox1a0+=OxO5474[0x8b] ; Ox1a0+=OxO5474[0x8c] ; _dialogPromptID[OxO5474[0x24]]=Ox1a0 ; _dialogPromptID[OxO5474[0x70]][OxO5474[0x8d]]=OxO5474[0x8e] ; _dialogPromptID[OxO5474[0x70]][OxO5474[0x90]]=parseInt((document[OxO5474[0x6b]][OxO5474[0x8f]]-0x13b)/0x2)+OxO5474[0x91] ; _dialogPromptID[OxO5474[0x70]][OxO5474[0x73]]=OxO5474[0x92] ;var Ox1a1=document.getElementById(OxO5474[0x72]);try{var Ox1a2=Ox1a1.createTextRange(); Ox1a2.collapse(false) ; Ox1a2.select() ;} catch(x){ Ox1a1.focus() ;} ;}  ;} ;if(!Browser_IsWinIE()){ btn_zoom_in[OxO5474[0x70]][OxO5474[0x73]]=btn_zoom_out[OxO5474[0x70]][OxO5474[0x73]]=btn_Actualsize[OxO5474[0x70]][OxO5474[0x73]]=OxO5474[0x74] ;} ;if(CreateDir){ CreateDir[OxO5474[0x31]]= new Function(OxO5474[0x93]) ;} ;if(Copy){ Copy[OxO5474[0x31]]= new Function(OxO5474[0x93]) ;} ;if(Move){ Move[OxO5474[0x31]]= new Function(OxO5474[0x93]) ;} ;if(Delete){ Delete[OxO5474[0x31]]= new Function(OxO5474[0x93]) ;} ;if(DoRefresh){ DoRefresh[OxO5474[0x31]]= new Function(OxO5474[0x93]) ;} ;if(btn_zoom_in){ btn_zoom_in[OxO5474[0x31]]= new Function(OxO5474[0x93]) ;} ;if(btn_zoom_out){ btn_zoom_out[OxO5474[0x31]]= new Function(OxO5474[0x93]) ;} ;if(btn_Actualsize){ btn_Actualsize[OxO5474[0x31]]= new Function(OxO5474[0x93]) ;} ;if(NewTemplate){ NewTemplate[OxO5474[0x31]]= new Function(OxO5474[0x93]) ;} ;





