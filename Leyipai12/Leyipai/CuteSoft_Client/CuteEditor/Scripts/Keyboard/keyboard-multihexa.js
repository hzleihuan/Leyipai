var OxO285b=["0123456789ABCDEF","0000","all","getElementById","","|","fond","\x3Cimg src=\x22Load.ashx?type=image\x26file=multiclavier.gif\x22 width=404 height=152 border=\x220\x22\x3E\x3Cbr /\x3E","sign","car","simpledia","simple","majus","\x26nbsp;","double","minus","doubledia","kb-","kb+","Delete","Clear","Back","CapsLock","Enter","Shift","\x3C|\x3C","Space","\x3E|\x3E","clavscroll(-3)","clavscroll(3)","faire(\x22del\x22)","RAZ()","faire(\x22bck\x22)","bloq()","faire(\x22\x5Cn\x22)","haut()","faire(\x22ar\x22)","faire(\x22 \x22)","faire(\x22av\x22)","act","action","clav","clavier","masque","\x3Cimg src=\x22Load.ashx?type=image\x26file=1x1.gif\x22 width=404 height=152 border=\x220\x22 usemap=\x22#clavier\x22\x3E","\x3Cmap name=\x22clavier\x22\x3E","\x3Carea coords=\x22",",","\x22 href=\x22javascript:void(0)\x22 onClick=\x27javascript:ecrire(",")\x27\x3E","\x22 href=\x22javascript:void(0)\x22 onClick=\x27javascript:","\x27\x3E","\x22 href=\x27javascript:charger(","\x3C/map\x3E","length"," ","%0D%0A","del","bck","ar","av","\x3Cspan class=","\x3E","\x3C/span\x3E","\x3Cdiv id=\x22","\x22 \x3E","\x3C/div\x3E","left","style","px","top","innerHTML","act0","act1","langue=","cookie",";","langue","=","; ","expires="];var caps=0x0,lock=0x0,hexchars=OxO285b[0x0],accent=OxO285b[0x1],clavdeb=0x0;var clav= new Array(); j=0x0 ;for( i  in Maj){ clav[j]=i ; j++ ;} ;var ns6=((!document[OxO285b[0x2]])&&(document[OxO285b[0x3]]));var ie=document[OxO285b[0x2]];var langue=getCk();if(langue==OxO285b[0x4]){ langue=clav[clavdeb] ;} ; CarMaj=Maj[langue].split(OxO285b[0x5]) ; CarMin=Min[langue].split(OxO285b[0x5]) ;var posClavierLeft=0x0,posClavierTop=0x0;if(ns6){ posClavierLeft=0x0 ; posClavierTop=0x50 ;} else {if(ie){ posClavierLeft=0x0 ; posClavierTop=0x50 ;} ;} ; tracer(OxO285b[0x6],posClavierLeft,posClavierTop,OxO285b[0x7],OxO285b[0x8]) ;var posX= new Array(0x0,0x1c,0x38,0x54,0x70,0x8c,0xa8,0xc4,0xe0,0xfc,0x118,0x134,0x150,0x2a,0x46,0x62,0x7e,0x9a,0xb6,0xd2,0xee,0x10a,0x126,0x142,0x15e,0x32,0x4e,0x6a,0x86,0xa2,0xbe,0xda,0xf6,0x112,0x12e,0x14a,0x40,0x5c,0x78,0x94,0xb0,0xcc,0xe8,0x104,0x120,0x13c,0x1c,0x38,0x54,0x126,0x142,0x15e);var posY= new Array(0xe,0xe,0xe,0xe,0xe,0xe,0xe,0xe,0xe,0xe,0xe,0xe,0xe,0x2a,0x2a,0x2a,0x2a,0x2a,0x2a,0x2a,0x2a,0x2a,0x2a,0x2a,0x2a,0x46,0x46,0x46,0x46,0x46,0x46,0x46,0x46,0x46,0x46,0x46,0x62,0x62,0x62,0x62,0x62,0x62,0x62,0x62,0x62,0x62,0x7e,0x7e,0x7e,0x7e,0x7e,0x7e);var nbTouches=0x34;for( i=0x0 ;i<nbTouches;i++){ CarMaj[i]=((CarMaj[i]!=OxO285b[0x1])?(fromhexby4tocar(CarMaj[i])):OxO285b[0x4]) ; CarMin[i]=((CarMin[i]!=OxO285b[0x1])?(fromhexby4tocar(CarMin[i])):OxO285b[0x4]) ;if(CarMaj[i]==CarMin[i].toUpperCase()){ cecar=((lock==0x0)&&(caps==0x0)?CarMin[i]:CarMaj[i]) ; tracer(OxO285b[0x9]+i,posClavierLeft+0x6+posX[i],posClavierTop+0x3+posY[i],cecar,((dia[hexa(cecar)]!=null)?OxO285b[0xa]:OxO285b[0xb])) ; tracer(OxO285b[0xc]+i,posClavierLeft+0xf+posX[i],posClavierTop+0x1+posY[i],OxO285b[0xd],OxO285b[0xe]) ; tracer(OxO285b[0xf]+i,posClavierLeft+0x3+posX[i],posClavierTop+0x9+posY[i],OxO285b[0xd],OxO285b[0xe]) ;} else { tracer(OxO285b[0x9]+i,posClavierLeft+0x6+posX[i],posClavierTop+0x3+posY[i],OxO285b[0xd],OxO285b[0xb]) ; cecar=CarMin[i] ; tracer(OxO285b[0xf]+i,posClavierLeft+0x3+posX[i],posClavierTop+0x9+posY[i],cecar,((dia[hexa(cecar)]!=null)?OxO285b[0x10]:OxO285b[0xe])) ; cecar=CarMaj[i] ; tracer(OxO285b[0xc]+i,posClavierLeft+0xf+posX[i],posClavierTop+0x1+posY[i],cecar,((dia[hexa(cecar)]!=null)?OxO285b[0x10]:OxO285b[0xe])) ;} ;} ;var actC1= new Array(0x0,0x173,0x16c,0x0,0x17a,0x0,0x166,0x0,0x158,0x0,0x70,0x17a);var actC2= new Array(0x0,0x0,0xe,0x2a,0x2a,0x46,0x46,0x62,0x62,0x7e,0x7e,0x7e);var actC3= new Array(0x20,0x193,0x193,0x27,0x193,0x2f,0x193,0x3d,0x193,0x19,0x123,0x193);var actC4= new Array(0xb,0xb,0x27,0x43,0x43,0x5f,0x5f,0x7b,0x7b,0x97,0x97,0x97);var act= new Array(OxO285b[0x11],OxO285b[0x12],OxO285b[0x13],OxO285b[0x14],OxO285b[0x15],OxO285b[0x16],OxO285b[0x17],OxO285b[0x18],OxO285b[0x18],OxO285b[0x19],OxO285b[0x1a],OxO285b[0x1b]);var effet= new Array(OxO285b[0x1c],OxO285b[0x1d],OxO285b[0x1e],OxO285b[0x1f],OxO285b[0x20],OxO285b[0x21],OxO285b[0x22],OxO285b[0x23],OxO285b[0x23],OxO285b[0x24],OxO285b[0x25],OxO285b[0x26]);var nbActions=0xc;for( i=0x0 ;i<nbActions;i++){ tracer(OxO285b[0x27]+i,posClavierLeft+0x1+actC1[i],posClavierTop-0x1+actC2[i],act[i],OxO285b[0x28]) ;} ;var clavC1= new Array(0x23,0x77,0xcb,0x11f);var clavC2= new Array(0x0,0x0,0x0,0x0);var clavC3= new Array(0x74,0xc8,0x11c,0x170);var clavC4= new Array(0xb,0xb,0xb,0xb);for( i=0x0 ;i<0x4;i++){ tracer(OxO285b[0x29]+i,posClavierLeft+0x5+clavC1[i],posClavierTop-0x1+clavC2[i],clav[i],OxO285b[0x2a]) ;} ; tracer(OxO285b[0x2b],posClavierLeft,posClavierTop,OxO285b[0x2c]) ; document.write(OxO285b[0x2d]) ;for( i=0x0 ;i<nbTouches;i++){ document.write(OxO285b[0x2e]+posX[i]+OxO285b[0x2f]+posY[i]+OxO285b[0x2f]+(posX[i]+0x19)+OxO285b[0x2f]+(posY[i]+0x19)+OxO285b[0x30]+i+OxO285b[0x31]) ;} ;for( i=0x0 ;i<nbActions;i++){ document.write(OxO285b[0x2e]+actC1[i]+OxO285b[0x2f]+actC2[i]+OxO285b[0x2f]+actC3[i]+OxO285b[0x2f]+actC4[i]+OxO285b[0x32]+effet[i]+OxO285b[0x33]) ;} ;for( i=0x0 ;i<0x4;i++){ document.write(OxO285b[0x2e]+clavC1[i]+OxO285b[0x2f]+clavC2[i]+OxO285b[0x2f]+clavC3[i]+OxO285b[0x2f]+clavC4[i]+OxO285b[0x34]+i+OxO285b[0x31]) ;} ; document.write(OxO285b[0x35]) ; function ecrire(i){ txt=rechercher()+OxO285b[0x5] ; subtxt=txt.split(OxO285b[0x5]) ; ceci=(lock==0x1)?CarMaj[i]:((caps==0x1)?CarMaj[i]:CarMin[i]) ;if(test(ceci)){ subtxt[0x0]+=cardia(ceci) ; distinguer(false) ;} else {if(dia[accent]!=null&&dia[hexa(ceci)]!=null){ distinguer(false) ; accent=hexa(ceci) ; distinguer(true) ;} else {if(dia[accent]!=null){ subtxt[0x0]+=fromhexby4tocar(accent)+ceci ; distinguer(false) ;} else {if(dia[hexa(ceci)]!=null){ accent=hexa(ceci) ; distinguer(true) ;} else { subtxt[0x0]+=ceci ;} ;} ;} ;} ; txt=subtxt[0x0]+OxO285b[0x5]+subtxt[0x1] ; afficher(txt) ;if(caps==0x1){ caps=0x0 ; MinusMajus() ;} ;}  ; function faire(Oxa06){ txt=rechercher()+OxO285b[0x5] ; subtxt=txt.split(OxO285b[0x5]) ; l0=subtxt[0x0][OxO285b[0x36]] ; l1=subtxt[0x1][OxO285b[0x36]] ; c1=subtxt[0x0].substring(0x0,(l0-0x2)) ; c2=subtxt[0x0].substring(0x0,(l0-0x1)) ; c3=subtxt[0x1].substring(0x0,0x1) ; c4=subtxt[0x1].substring(0x0,0x2) ; c5=subtxt[0x0].substring((l0-0x2),l0) ; c6=subtxt[0x0].substring((l0-0x1),l0) ; c7=subtxt[0x1].substring(0x1,l1) ; c8=subtxt[0x1].substring(0x2,l1) ;if(dia[accent]!=null){if(Oxa06==OxO285b[0x37]){ Oxa06=fromhexby4tocar(accent) ;} ; distinguer(false) ;} ;switch(Oxa06){case (OxO285b[0x3c]):if(escape(c4)!=OxO285b[0x38]){ txt=subtxt[0x0]+c3+OxO285b[0x5]+c7 ;} else { txt=subtxt[0x0]+c4+OxO285b[0x5]+c8 ;} ;break ;case (OxO285b[0x3b]):if(escape(c5)!=OxO285b[0x38]){ txt=c2+OxO285b[0x5]+c6+subtxt[0x1] ;} else { txt=c1+OxO285b[0x5]+c5+subtxt[0x1] ;} ;break ;case (OxO285b[0x3a]):if(escape(c5)!=OxO285b[0x38]){ txt=c2+OxO285b[0x5]+subtxt[0x1] ;} else { txt=c1+OxO285b[0x5]+subtxt[0x1] ;} ;break ;case (OxO285b[0x39]):if(escape(c4)!=OxO285b[0x38]){ txt=subtxt[0x0]+OxO285b[0x5]+c7 ;} else { txt=subtxt[0x0]+OxO285b[0x5]+c8 ;} ;break ;default: txt=subtxt[0x0]+Oxa06+OxO285b[0x5]+subtxt[0x1] ;break ;;;;;;} ; afficher(txt) ;}  ; function RAZ(){ txt=OxO285b[0x4] ;if(dia[accent]!=null){ distinguer(false) ;} ; afficher(txt) ;}  ; function haut(){ caps=0x1 ; MinusMajus() ;}  ; function bloq(){ lock=(lock==0x1)?0x0:0x1 ; MinusMajus() ;}  ; function tracer(Oxa0b,Oxa0c,haut,Oxa06,Oxa0d){ Oxa06=OxO285b[0x3d]+Oxa0d+OxO285b[0x3e]+Oxa06+OxO285b[0x3f] ; document.write(OxO285b[0x40]+Oxa0b+OxO285b[0x41]+Oxa06+OxO285b[0x42]) ;if(ns6){ document.getElementById(Oxa0b)[OxO285b[0x44]][OxO285b[0x43]]=Oxa0c+OxO285b[0x45] ; document.getElementById(Oxa0b)[OxO285b[0x44]][OxO285b[0x46]]=haut+OxO285b[0x45] ;} else {if(ie){ document.all(Oxa0b)[OxO285b[0x44]][OxO285b[0x43]]=Oxa0c ; document.all(Oxa0b)[OxO285b[0x44]][OxO285b[0x46]]=haut ;} ;} ;}  ; function retracer(Oxa0b,Oxa06,Oxa0d){ Oxa06=OxO285b[0x3d]+Oxa0d+OxO285b[0x3e]+Oxa06+OxO285b[0x3f] ;if(ns6){ document.getElementById(Oxa0b)[OxO285b[0x47]]=Oxa06 ;} else {if(ie){ doc=document.all(Oxa0b) ; doc[OxO285b[0x47]]=Oxa06 ;} ;} ;}  ; function clavscroll(n){ clavdeb+=n ;if(clavdeb<0x0){ clavdeb=0x0 ;} ;if(clavdeb>clav[OxO285b[0x36]]-0x4){ clavdeb=clav[OxO285b[0x36]]-0x4 ;} ;for( i=clavdeb ;i<clavdeb+0x4;i++){ retracer(OxO285b[0x29]+(i-clavdeb),clav[i],OxO285b[0x2a]) ;} ;if(clavdeb==0x0){ retracer(OxO285b[0x48],OxO285b[0xd],OxO285b[0x28]) ;} else { retracer(OxO285b[0x48],act[0x0],OxO285b[0x28]) ;} ;if(clavdeb==clav[OxO285b[0x36]]-0x4){ retracer(OxO285b[0x49],OxO285b[0xd],OxO285b[0x28]) ;} else { retracer(OxO285b[0x49],act[0x1],OxO285b[0x28]) ;} ;}  ; function charger(i){ langue=clav[i+clavdeb] ; setCk(langue) ; accent=OxO285b[0x1] ; CarMaj=Maj[langue].split(OxO285b[0x5]) ; CarMin=Min[langue].split(OxO285b[0x5]) ;for( i=0x0 ;i<nbTouches;i++){ CarMaj[i]=((CarMaj[i]!=OxO285b[0x1])?(fromhexby4tocar(CarMaj[i])):OxO285b[0x4]) ; CarMin[i]=((CarMin[i]!=OxO285b[0x1])?(fromhexby4tocar(CarMin[i])):OxO285b[0x4]) ;if(CarMaj[i]==CarMin[i].toUpperCase()){ cecar=((lock==0x0)&&(caps==0x0)?CarMin[i]:CarMaj[i]) ; retracer(OxO285b[0x9]+i,cecar,((dia[hexa(cecar)]!=null)?OxO285b[0xa]:OxO285b[0xb])) ; retracer(OxO285b[0xf]+i,OxO285b[0xd]) ; retracer(OxO285b[0xc]+i,OxO285b[0xd]) ;} else { retracer(OxO285b[0x9]+i,OxO285b[0xd]) ; cecar=CarMin[i] ; retracer(OxO285b[0xf]+i,cecar,((dia[hexa(cecar)]!=null)?OxO285b[0x10]:OxO285b[0xe])) ; cecar=CarMaj[i] ; retracer(OxO285b[0xc]+i,cecar,((dia[hexa(cecar)]!=null)?OxO285b[0x10]:OxO285b[0xe])) ;} ;} ;}  ; function distinguer(Oxa12){for( i=0x0 ;i<nbTouches;i++){if(CarMaj[i]==CarMin[i].toUpperCase()){ cecar=((lock==0x0)&&(caps==0x0)?CarMin[i]:CarMaj[i]) ;if(test(cecar)){ retracer(OxO285b[0x9]+i,Oxa12?(cardia(cecar)):cecar,Oxa12?OxO285b[0xa]:OxO285b[0xb]) ;} ;} else { cecar=CarMin[i] ;if(test(cecar)){ retracer(OxO285b[0xf]+i,Oxa12?(cardia(cecar)):cecar,Oxa12?OxO285b[0x10]:OxO285b[0xe]) ;} ; cecar=CarMaj[i] ;if(test(cecar)){ retracer(OxO285b[0xc]+i,Oxa12?(cardia(cecar)):cecar,Oxa12?OxO285b[0x10]:OxO285b[0xe]) ;} ;} ;} ;if(!Oxa12){ accent=OxO285b[0x1] ;} ;}  ; function MinusMajus(){for( i=0x0 ;i<nbTouches;i++){if(CarMaj[i]==CarMin[i].toUpperCase()){ cecar=((lock==0x0)&&(caps==0x0)?CarMin[i]:CarMaj[i]) ; retracer(OxO285b[0x9]+i,(test(cecar)?cardia(cecar):cecar),((dia[hexa(cecar)]!=null||test(cecar))?OxO285b[0xa]:OxO285b[0xb])) ;} ;} ;}  ; function test(Oxa15){return (dia[accent]!=null&&dia[accent][hexa(Oxa15)]!=null);}  ; function cardia(Oxa15){return (fromhexby4tocar(dia[accent][hexa(Oxa15)]));}  ; function fromhex(Oxa18){ out=0x0 ;for( a=Oxa18[OxO285b[0x36]]-0x1 ;a>=0x0;a--){ out+=Math.pow(0x10,Oxa18[OxO285b[0x36]]-a-0x1)*hexchars.indexOf(Oxa18.charAt(a)) ;} ;return out;}  ; function fromhexby4tocar(Oxa06){ out4= new String() ;for( l=0x0 ;l<Oxa06[OxO285b[0x36]];l+=0x4){ out4+=String.fromCharCode(fromhex(Oxa06.substring(l,l+0x4))) ;} ;return out4;}  ; function tohex(Oxa18){return hexchars.charAt(Oxa18/0x10)+hexchars.charAt(Oxa18%0x10);}  ; function tohex2(Oxa18){return tohex(Oxa18/0x100)+tohex(Oxa18%0x100);}  ; function hexa(Oxa06){ out=OxO285b[0x4] ;for( k=0x0 ;k<Oxa06[OxO285b[0x36]];k++){ out+=(tohex2(Oxa06.charCodeAt(k))) ;} ;return out;}  ; function getCk(){ fromN=document[OxO285b[0x4b]].indexOf(OxO285b[0x4a])+0x0 ;if((fromN)!=-0x1){ fromN+=0x7 ; toN=document[OxO285b[0x4b]].indexOf(OxO285b[0x4c],fromN)+0x0 ;if(toN==-0x1){ toN=document[OxO285b[0x4b]][OxO285b[0x36]] ;} ;return unescape(document[OxO285b[0x4b]].substring(fromN,toN));} ;return OxO285b[0x4];}  ; function setCk(Oxa18){if(Oxa18!=null){ exp= new Date() ; time=0x16d*0x3c*0x3c*0x18*0x3e8 ; exp.setTime(exp.getTime()+time) ; document[OxO285b[0x4b]]=escape(OxO285b[0x4d])+OxO285b[0x4e]+escape(Oxa18)+OxO285b[0x4f]+OxO285b[0x50]+exp.toGMTString() ;} ;}  ;





