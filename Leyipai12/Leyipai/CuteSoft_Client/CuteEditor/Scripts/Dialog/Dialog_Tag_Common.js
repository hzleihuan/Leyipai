var OxO22e6=["inp_class","inp_width","inp_height","sel_align","sel_textalign","sel_float","inp_forecolor","img_forecolor","inp_backcolor","img_backcolor","inp_tooltip","className","value","width","style","height","align","styleFloat","cssFloat","textAlign","title","backgroundColor","color","","class","onclick"];var inp_class=Window_GetElement(window,OxO22e6[0x0],true);var inp_width=Window_GetElement(window,OxO22e6[0x1],true);var inp_height=Window_GetElement(window,OxO22e6[0x2],true);var sel_align=Window_GetElement(window,OxO22e6[0x3],true);var sel_textalign=Window_GetElement(window,OxO22e6[0x4],true);var sel_float=Window_GetElement(window,OxO22e6[0x5],true);var inp_forecolor=Window_GetElement(window,OxO22e6[0x6],true);var img_forecolor=Window_GetElement(window,OxO22e6[0x7],true);var inp_backcolor=Window_GetElement(window,OxO22e6[0x8],true);var img_backcolor=Window_GetElement(window,OxO22e6[0x9],true);var inp_tooltip=Window_GetElement(window,OxO22e6[0xa],true); UpdateState=function UpdateState_Common(){}  ; SyncToView=function SyncToView_Common(){ inp_class[OxO22e6[0xc]]=element[OxO22e6[0xb]] ; inp_width[OxO22e6[0xc]]=element[OxO22e6[0xe]][OxO22e6[0xd]] ; inp_height[OxO22e6[0xc]]=element[OxO22e6[0xe]][OxO22e6[0xf]] ; sel_align[OxO22e6[0xc]]=element[OxO22e6[0x10]] ;if(Browser_IsWinIE()){ sel_float[OxO22e6[0xc]]=element[OxO22e6[0xe]][OxO22e6[0x11]] ;} else { sel_float[OxO22e6[0xc]]=element[OxO22e6[0xe]][OxO22e6[0x12]] ;} ; sel_textalign[OxO22e6[0xc]]=element[OxO22e6[0xe]][OxO22e6[0x13]] ; inp_tooltip[OxO22e6[0xc]]=element[OxO22e6[0x14]] ; inp_forecolor[OxO22e6[0xc]]=revertColor(element[OxO22e6[0xe]].color) ; inp_forecolor[OxO22e6[0xe]][OxO22e6[0x15]]=inp_forecolor[OxO22e6[0xc]] ; img_forecolor[OxO22e6[0xe]][OxO22e6[0x15]]=inp_forecolor[OxO22e6[0xc]] ; inp_backcolor[OxO22e6[0xc]]=revertColor(element[OxO22e6[0xe]].backgroundColor) ; inp_backcolor[OxO22e6[0xe]][OxO22e6[0x15]]=inp_backcolor[OxO22e6[0xc]] ; img_backcolor[OxO22e6[0xe]][OxO22e6[0x15]]=inp_backcolor[OxO22e6[0xc]] ;}  ; SyncTo=function SyncTo_Common(element){ element[OxO22e6[0xb]]=inp_class[OxO22e6[0xc]] ;try{ element[OxO22e6[0xe]][OxO22e6[0xd]]=inp_width[OxO22e6[0xc]] ; element[OxO22e6[0xe]][OxO22e6[0xf]]=inp_height[OxO22e6[0xc]] ;} catch(x){} ; element[OxO22e6[0x10]]=sel_align[OxO22e6[0xc]] ;if(Browser_IsWinIE()){ element[OxO22e6[0xe]][OxO22e6[0x11]]=sel_float[OxO22e6[0xc]] ;} else { element[OxO22e6[0xe]][OxO22e6[0x12]]=sel_float[OxO22e6[0xc]] ;} ; element[OxO22e6[0xe]][OxO22e6[0x13]]=sel_textalign[OxO22e6[0xc]] ; element[OxO22e6[0x14]]=inp_tooltip[OxO22e6[0xc]] ; element[OxO22e6[0xe]][OxO22e6[0x16]]=inp_forecolor[OxO22e6[0xc]] ; element[OxO22e6[0xe]][OxO22e6[0x15]]=inp_backcolor[OxO22e6[0xc]] ;if(element[OxO22e6[0xb]]==OxO22e6[0x17]){ element.removeAttribute(OxO22e6[0xb]) ;} ;if(element[OxO22e6[0xb]]==OxO22e6[0x17]){ element.removeAttribute(OxO22e6[0x18]) ;} ;if(element[OxO22e6[0x14]]==OxO22e6[0x17]){ element.removeAttribute(OxO22e6[0x14]) ;} ;if(element[OxO22e6[0x10]]==OxO22e6[0x17]){ element.removeAttribute(OxO22e6[0x10]) ;} ;}  ; img_forecolor[OxO22e6[0x19]]=inp_forecolor[OxO22e6[0x19]]=function inp_forecolor_onclick(){ SelectColor(inp_forecolor,img_forecolor) ;}  ; img_backcolor[OxO22e6[0x19]]=inp_backcolor[OxO22e6[0x19]]=function inp_backcolor_onclick(){ SelectColor(inp_backcolor,img_backcolor) ;}  ;




