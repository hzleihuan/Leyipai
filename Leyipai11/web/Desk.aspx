<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Desk.aspx.cs" Inherits="Desk" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd">
<!--  -->
<HTML lang=zh-cn xmlns="http://www.w3.org/1999/xhtml" 
xml:lang="zh-cn"><HEAD><TITLE>我的办公桌</TITLE>
<META http-equiv=Content-Type content="text/html; charset=gb2312">
<LINK 
href="css/mytable.css" type=text/css rel=stylesheet>
<link href="css/base.css" rel="stylesheet" type="text/css" />
<SCRIPT src="js/mytable.js" type=text/javascript></SCRIPT>

<SCRIPT type=text/javascript>
window.setTimeout('this.location.reload();',1200000);

var my_pos=true;
var my_width=65;
var my_expand=true;
function _edit(module_id)
{
	 show_msg("optionBlock");	 
    $("optionBlockTitle").innerText=$("module_"+module_id+"_text").innerText+" 模块选项";
    $('display_lines').focus();
	 $('display_lines').value=lines_per_page(module_id);
	 $('scroll').checked=getCookie("my_scroll_3_"+module_id)=="true";
	 $('col_width').value=my_width;
	 $('module_id').value=module_id;
}
function _resize(module_id)
{
	 var module_i=$("module_"+module_id);
	 var head_i=$("module_"+module_id+"_head");
	 var body_i=$("module_"+module_id+"_body");
	 var img_i=$("img_resize_"+module_id);
	 var my_cookie=getCookie("my_expand_3");
	 my_cookie = (my_cookie==null || my_cookie=="undefined") ? "" : my_cookie;//alert(my_cookie)
	 if(body_i.style.display=="none")
	 {
	    module_i.className=module_i.className.substr(0,module_i.className.lastIndexOf(" "));
	    head_i.className=head_i.className.substr(0,head_i.className.lastIndexOf(" "));
	    body_i.style.display="block";
	    img_i.src=img_i.src.substr(0,img_i.src.lastIndexOf("/")+1)+"expand_arrow.png";
	    img_i.title="折叠";
	    
	    if(my_cookie.indexOf(module_id+",") == 0)
	       my_cookie = my_cookie.replace(module_id+",", "");
	    else if(my_cookie.indexOf(","+module_id+",") > 0)
	       my_cookie = my_cookie.replace(","+module_id+",", ",");
	    
	    //my_expand=true;
       setCookie("my_expand_all_3", "");
	 }
	 else
	 {
	    module_i.className=module_i.className+" listColorCollapsed";
	    head_i.className=head_i.className+" moduleHeaderCollapsed";
	    body_i.style.display="none";
	    img_i.src=img_i.src.substr(0,img_i.src.lastIndexOf("/")+1)+"collapse_arrow.png";
	    img_i.title="展开";
	    
	    if(my_cookie.indexOf(module_id+",") != 0 && my_cookie.indexOf(","+module_id+",") <= 0)
	       my_cookie += module_id+",";
	 }
	 setCookie("my_expand_3", my_cookie);
}
function resize_all()
{
   var img_all_resize=$("img_all_resize");
   var imgs=document.getElementsByTagName("IMG");
   var module_id_str="";
   for(var i=0;i<imgs.length;i++)
   {
      if(imgs[i].id.substr(0,11)!="img_resize_")
         continue;
      
      var module_id=imgs[i].id.substr(11,imgs[i].id.length);
      module_id_str+=module_id+",";
      if(my_expand && $("module_"+module_id+"_body").style.display!="none" || !my_expand && $("module_"+module_id+"_body").style.display=="none")
         _resize(module_id);
   }
   
   if(my_expand)
   {
      img_all_resize.src=img_all_resize.src.substr(0,img_all_resize.src.lastIndexOf("/")+1)+"collapse_arrow.png";
      setCookie("my_expand_3",module_id_str);
   }
   else
   {
      img_all_resize.src=img_all_resize.src.substr(0,img_all_resize.src.lastIndexOf("/")+1)+"expand_arrow.png";
      setCookie("my_expand_3","");
   }

   my_expand=!my_expand;
   setCookie("my_expand_all_3", my_expand ? "" : "0");
}
function SetNums()
{
	 var today_lines=$('display_lines').value;
	 var col_width=$('col_width').value;
   if(today_lines=="" || checkNum(today_lines) || col_width=="" || checkNum(col_width))
   {
      alert("显示条数和栏目宽度必须是数字");
      return;
   }

   if(parseInt(today_lines)<=0 || parseInt(today_lines)>=1000)
   {
      alert("显示条数必须在1-1000之间");
      return;
   }
   if(parseInt(col_width)<=0 || parseInt(col_width)>100)
   {
      alert("栏目宽度必须在1-100之间");
      return;
   }
   setCookie("my_nums_3_"+$('module_id').value, today_lines);
   setCookie("my_scroll_3_"+$('module_id').value, $('scroll').checked);
   setCookie("my_width_3", col_width);

   my_width=col_width;

   $("msgBody").style.display = "none";
   $("msgCommand").style.display = "none";
   $("msgSuccess").style.display = "block";
   
   //window.location.reload();
}
</SCRIPT>

<META content="MSHTML 6.00.2900.3395" name=GENERATOR></HEAD>
<BODY>
<DIV id=desktop_config>
    <br />
    <IMG id=img_all_resize title="全部 展开/折叠" 
onclick=resize_all() src="images/expand_arrow.png"> </DIV>
<TABLE cellSpacing=0 cellPadding=0 width="100%" border=0>
  <TBODY>
  <TR>
    <TD id=col_l vAlign=top width="65%">
	
	
      <DIV class="module listColor" id=module_16>
      <DIV class=head>
      <H4 class=moduleHeader id=module_16_head><A class=expand 
      href="javascript:_resize(16);"><IMG class=icon id=img_resize_16 title=折叠 
      src="images/expand_arrow.png"></A> <SPAN class=text id=module_16_text 
      onclick=_resize(16);>最近热销</SPAN> <SPAN class=title id=module_16_title 
      style="CURSOR: move"></SPAN><SPAN class=close id=module_16_op><A 
      class=PageLinkDisable id=module_16_link_pre title=上一页 
      href="javascript:NextPage('16',-1);"><B>▲</B></A> <A 
      id=module_16_link_next title=下一页 
      href="javascript:NextPage('16',1);"><B>▼</B></A> <A 
      href="#">全部</A>&nbsp;<A 
      title=设置 href="javascript:_edit(16);"><IMG 
      src="images/pencil.png"></A>&nbsp;<A title=关闭模块 
      href="javascript:_del(16);"><IMG src="images/close_x.png"></A> 
      </SPAN></H4>
	 
	  
	  </DIV> <!-- 头部 -->
	  
	  
      <DIV class=module_body id=module_16_body>
      <DIV class=module_div id=module_16_ul style="HEIGHT: 100px">
      <UL>
        <A href="javascript:plan_detail(136);"></A> 
       
          <UL><asp:Repeater ID="NewsSales" runat="server">
              <ItemTemplate>
                  <LI><A target="_blank" href="Notice/Notice_Detail.aspx?NoticeID=<%#Eval("NoticeID")%>"><FONT 
        color=red>
                      <B>
                          <%#Eval("Title")%>
                      </b></font></a>&nbsp;(<%#Eval("CreateDate")%>
                  )
              </ItemTemplate>
          </asp:Repeater>
          </UL>
        </UL>
      </DIV></DIV></DIV>
		
<!--          /////////////////////////////////                 -->
      
      <DIV class="module listColor" id=module_27>
      <DIV class=head>
      <H4 class=moduleHeader id=module_27_head><A class=expand 
      href="javascript:_resize(27);"><IMG class=icon id=img_resize_27 title=折叠 
      src="images/expand_arrow.png"></A> <SPAN class=text id=module_27_text 
      onclick=_resize(27);>本周会议</SPAN> <SPAN class=title id=module_27_title 
      style="CURSOR: move"></SPAN><SPAN class=close id=module_27_op><A 
      class=PageLinkDisable id=module_27_link_pre title=上一页 
      href="javascript:NextPage('27',-1);"><B>▲</B></A> <A 
      id=module_27_link_next title=下一页 
      href="javascript:NextPage('27',1);"><B>▼</B></A> <A 
      href="#">全部</A>&nbsp;<A 
      title=设置 href="javascript:_edit(27);"><IMG 
      src="images/pencil.png"></A>&nbsp;<A title=关闭模块 
      href="javascript:_del(27);"><IMG src="images/close_x.png"></A> 
      </SPAN></H4></DIV>
      <DIV class=module_body id=module_27_body>
      <DIV class=module_div id=module_27_ul style="HEIGHT: 100px">
        <p><asp:Repeater ID="MeetingRepeater" runat="server">
            <ItemTemplate>
                <LI><A target="_blank" href="Notice/Notice_Detail.aspx?NoticeID=<%#Eval("NoticeID")%>">
                    <FONT 
        color=red><B>
                        <%#Eval("Title")%>
                    </b></font></a>&nbsp;(<%#Eval("CreateDate")%>
                )
            </ItemTemplate>
        </asp:Repeater>
            &nbsp;</p>
      <SCRIPT>
function open_meeting(M_ID)
{
   URL="/general/meeting/query/meeting_detail.php?M_ID="+M_ID;
   myleft=(screen.availWidth-600)/2;
   mytop=100
   mywidth=600;
   myheight=500;
   window.open(URL,"read_meeting","height="+myheight+",width="+mywidth+",status=1,toolbar=no,menubar=no,location=no,scrollbars=yes,top="+mytop+",left="+myleft+",resizable=yes");
}
</SCRIPT>
      </DIV></DIV></DIV>
      
      <DIV class=shadow></DIV></TD>
    <TD id=col_r style="PADDING-RIGHT: 10px" vAlign=top width="35%">
      <DIV class="module listColor" id=module_1>
      <DIV class=head>
      <H4 class=moduleHeader id=module_1_head><A class=expand 
      href="javascript:_resize(1);"><IMG class=icon id=img_resize_1 title=折叠 
      src="images/expand_arrow.png"></A> <SPAN class=text id=module_1_text 
      onclick=_resize(1);>公告通知</SPAN> <SPAN class=title id=module_1_title 
      style="CURSOR: move"></SPAN><SPAN class=close id=module_1_op><A 
      class=PageLinkDisable id=module_1_link_pre title=上一页 
      href="javascript:NextPage('1',-1);"><B>▲</B></A> <A id=module_1_link_next 
      title=下一页 href="javascript:NextPage('1',1);"><B>▼</B></A> <A 
      href="#">全部</A>&nbsp;<A 
      title=设置 href="javascript:_edit(1);"><IMG 
      src="images/pencil.png"></A>&nbsp; </SPAN></H4></DIV>
      <DIV class=module_body id=module_1_body>
      <DIV class=module_div id=module_1_ul style="HEIGHT: 100px">
      <FONT 
        color=red><B></B></FONT><p>
            <asp:Repeater ID="Noticelist" runat="server">
             <ItemTemplate>
                        <LI><A target="_blank" href="Notice/Notice_Detail.aspx?NoticeID=<%#Eval("NoticeID")%>"><FONT 
        color=red><B><%#Eval("Title")%></B></FONT></A>&nbsp;(<%#Eval("CreateDate")%>)
             
             </ItemTemplate>
            </asp:Repeater>
        </p>
          <p>
        </p>
        <UL>
          <SCRIPT>
function open_notify(NOTIFY_ID,FORMAT)
{
 URL="/general/notify/show/read_notify.php?NOTIFY_ID="+NOTIFY_ID;
 myleft=(screen.availWidth-780)/2;
 mytop=100
 mywidth=780;
 myheight=500;
 if(FORMAT=="1")
 {
    myleft=0;
    mytop=0
    mywidth=screen.availWidth-10;
    myheight=screen.availHeight-40;
 }
 window.open(URL,"read_news","height="+myheight+",width="+mywidth+",status=1,toolbar=no,menubar=no,location=no,scrollbars=yes,top="+mytop+",left="+myleft+",resizable=yes");
}
</SCRIPT>
        </UL></DIV></DIV></DIV>
      
      
      
      
      
      
      <DIV class=shadow><DIV class="module listColor" id=module_28>
          <DIV class=head>
              <H4 class=moduleHeader id=module_28_head>
                  <A class=expand 
      href="javascript:_resize(28);">
                      <IMG class=icon id=Img1 title=折叠 
      src="images/expand_arrow.png"></a> <SPAN class=text id=module_28_text 
      onclick=_resize(28);>我的问题</span> <SPAN class=title id=module_28_title 
      style="CURSOR: move">
                          </span><SPAN class=close id=module_28_op><A 
      class=PageLinkDisable id=A1 title=上一页 
      href="javascript:NextPage('27',-1);"><B>▲</b></a> <A 
      id=A2 title=下一页 
      href="javascript:NextPage('27',1);">
                                  <B>▼</b></a> <A 
      href="#">全部</a> <A 
      title=设置 href="javascript:_edit(28);">
                                      <IMG 
      src="images/pencil.png"></a> <A title=关闭模块 
      href="javascript:_del(28);">
                                          <IMG src="images/close_x.png"></a> </span>
              </h4>
          </div>
          <DIV class=module_body id="module_28_body">
              <DIV class=module_div id="module_28_ul" style="HEIGHT: 100px">
                  <p>
                      <asp:Repeater ID="VServiceInfoList" runat="server">
                          <ItemTemplate>
                              <LI><A target="_blank" href="Customer/ServiceInfo_Detail.aspx?ServiceID=<%#Eval("ID")%>">
                                  <FONT 
        color=red><B>
                                      <%#Eval("ServiceTitle")%>
                                  </b></font></a>&nbsp;(<%# setToString(Eval("State").ToString())%>
                              )
                          </ItemTemplate>
                      </asp:Repeater>
                      &nbsp;</p>

             
、

              </div>
          </div>
      </div>
      </DIV></TD></TR></TBODY></TABLE>
<SCRIPT type=text/javascript>
<!--
_upc(2);
//-->
</SCRIPT>

<DIV id=overlay></DIV>


</BODY></HTML>
