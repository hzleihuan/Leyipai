var OxOc24b=["top","dialogArguments","opener","_dialog_arguments","document","editor","window","element","changed","propertyName","value","checked","trim","prototype",""]; function Window_GetDialogTop(Ox1b5){return Ox1b5[OxOc24b[0x0]];}  ; function Window_FindDialogArguments(Ox1b5){var Ox1b6=Ox1b5[OxOc24b[0x0]];if(Ox1b6[OxOc24b[0x1]]){return Ox1b6[OxOc24b[0x1]];} ;var Ox1b7=Ox1b6[OxOc24b[0x2]];if(Ox1b7==null){return Ox1b6[OxOc24b[0x4]][OxOc24b[0x3]];} ;var Ox3f3=Ox1b7[OxOc24b[0x4]][OxOc24b[0x3]];if(Ox3f3==null){return Window_FindDialogArguments(Ox1b7);} ;return Ox3f3;}  ;var arg=Window_FindDialogArguments(window);var editor=arg[OxOc24b[0x5]];var editwin=arg[OxOc24b[0x6]];var editdoc=arg[OxOc24b[0x4]];var element=arg[OxOc24b[0x7]];var syncingtoview=false; Window_GetDialogTop(window)[OxOc24b[0x8]]=Window_GetDialogTop(window)[OxOc24b[0x8]]||arg[OxOc24b[0x8]] ; function OnPropertyChange(){if(syncingtoview){return ;} ;var Ox2b0=Event_GetEvent();if(Ox2b0[OxOc24b[0x9]]!=OxOc24b[0xa]&&Ox2b0[OxOc24b[0x9]]!=OxOc24b[0xb]){return ;} ; FireUIChanged() ;}  ; function FireUIChanged(){ Window_GetDialogTop(window)[OxOc24b[0x8]]=true ; SyncTo(element) ; UpdateState() ;}  ; function SyncToViewInternal(){ syncingtoview=true ;try{ SyncToView() ; UpdateState() ;} finally{ syncingtoview=false ;} ;}  ; String[OxOc24b[0xd]][OxOc24b[0xc]]=function (){return this.replace(/(^\s*)|(\s*$)/g,OxOc24b[0xe]);}  ; function UpdateState(){}  ; function SyncTo(element){}  ; function SyncToView(){}  ;