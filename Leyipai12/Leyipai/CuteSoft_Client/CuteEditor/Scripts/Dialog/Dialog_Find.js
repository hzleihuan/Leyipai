var OxOb80c=["stringSearch","stringReplace","MatchWholeWord","MatchCase","document","checked","length","value","Nothing to search.","selection","body","type","Control","text","Finished Searching the document. Would you like to start again from the top?","","textedit","[[WordNotFound]]","[[WordReplaced]] : ","Please use replace funtion."];var editwin=Window_GetDialogArguments(window);var stringSearch=Window_GetElement(window,OxOb80c[0x0],true);var stringReplace=Window_GetElement(window,OxOb80c[0x1],true);var MatchWholeWord=Window_GetElement(window,OxOb80c[0x2],true);var MatchCase=Window_GetElement(window,OxOb80c[0x3],true);var editdoc=editwin[OxOb80c[0x4]]; function get_ie_matchtype(){var Ox28f=0x0;var Ox290=0x0;var Ox291=0x0;if(MatchCase[OxOb80c[0x5]]){ Ox290=0x4 ;} ;if(MatchWholeWord[OxOb80c[0x5]]){ Ox291=0x2 ;} ; Ox28f=Ox290+Ox291 ;return (Ox28f);}  ; function checkInputString(){if(stringSearch[OxOb80c[0x7]][OxOb80c[0x6]]<0x1){ alert(OxOb80c[0x8]) ;return false;} else {return true;} ;}  ; function IsMatchSearchValue(Ox24){if(!Ox24){return false;} ;if(stringSearch[OxOb80c[0x7]]==Ox24){return true;} ;if(MatchCase[OxOb80c[0x5]]){return false;} ;return stringSearch[OxOb80c[0x7]].toLowerCase()==Ox24.toLowerCase();}  ;var _ie_range=null; function IE_Restore(){ editwin.focus() ;if(_ie_range!=null){ _ie_range.select() ;} ;}  ; function IE_Save(){ editwin.focus() ; _ie_range=editdoc[OxOb80c[0x9]].createRange() ;}  ; function MoveToBodyStart(){if(Browser_UseIESelection()){ range=document[OxOb80c[0xa]].createTextRange() ; range.collapse(true) ; range.select() ; IE_Save() ;} else { editwin.getSelection().collapse(editdoc.body,0x0) ;} ;}  ; function DoFind(){if(Browser_UseIESelection()){ IE_Restore() ;var Ox12f=editdoc[OxOb80c[0x9]];if(Ox12f[OxOb80c[0xb]]==OxOb80c[0xc]){ MoveToBodyStart() ;} ;var Ox1a2=Ox12f.createRange(); Ox1a2.collapse(false) ;if(Ox1a2.findText(stringSearch[OxOb80c[0x7]],0x3b9aca00,get_ie_matchtype())){ Ox1a2.select() ; IE_Save() ;return true;} ;} else {var Ox1a2=editwin.getSelection().getRangeAt(0x0);if(editwin.find(stringSearch[OxOb80c[0x7]],MatchCase[OxOb80c[0x5]],false,false,MatchWholeWord.checked,false,false)){return true;} ;} ;}  ; function DoReplace(){if(Browser_UseIESelection()){ IE_Restore() ;var Ox12f=editdoc[OxOb80c[0x9]];if(Ox12f[OxOb80c[0xb]]!=OxOb80c[0xc]){var Ox1a2=Ox12f.createRange();if(IsMatchSearchValue(Ox1a2.text)){ Ox1a2[OxOb80c[0xd]]=stringReplace[OxOb80c[0x7]] ; Ox1a2.collapse(false) ; IE_Save() ;return true;} ;} ;} else {var Ox12f=editwin.getSelection();if(IsMatchSearchValue(Ox12f.toString())){ Ox12f.deleteFromDocument() ; Ox12f.getRangeAt(0x0).insertNode(editdoc.createTextNode(stringReplace.value)) ; Ox12f.getRangeAt(0x0).collapse(false) ;return true;} ;} ;return false;}  ; function FindTxt(){if(!checkInputString()){return false;} ;while(true){if(DoFind()){return ;} ;if(!confirm(OxOb80c[0xe])){return ;} ; MoveToBodyStart() ;} ;}  ; function ReplaceTxt(){if(!checkInputString()){return ;} ; DoReplace() ; FindTxt() ;}  ; function ReplaceAllTxt(){if(!checkInputString()){return ;} ;var Ox29d=0x0;var msg=OxOb80c[0xf]; MoveToBodyStart() ;if(Browser_UseIESelection()){var Ox12f=editdoc[OxOb80c[0x9]];if(Ox12f[OxOb80c[0xb]]==OxOb80c[0xc]){ MoveToBodyStart() ;} ;var Ox29e=Ox12f.createRange();var Ox29d=0x0;var msg=OxOb80c[0xf]; Ox29e.expand(OxOb80c[0x10]) ; Ox29e.collapse() ; Ox29e.select() ;while(Ox29e.findText(stringSearch[OxOb80c[0x7]],0x3b9aca00,get_ie_matchtype())){ Ox29e.select() ; Ox29e[OxOb80c[0xd]]=stringReplace[OxOb80c[0x7]] ; Ox29d++ ;} ;if(Ox29d==0x0){ msg=OxOb80c[0x11] ;} else { msg=OxOb80c[0x12]+Ox29d ;} ; alert(msg) ;} else {if((stringReplace[OxOb80c[0x7]]).indexOf(stringSearch.value)==-0x1){ DoFind() ;while(DoReplace()){ Ox29d++ ; DoFind() ; FindTxt() ;} ;if(Ox29d==0x0){ msg=OxOb80c[0x11] ;} else { msg=OxOb80c[0x12]+Ox29d ;} ; alert(msg) ;} else { FindTxt() ; alert(OxOb80c[0x13]) ;} ;} ;}  ;




