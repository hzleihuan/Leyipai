<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index_Left_Menu.aspx.cs" Inherits="Index_Left_Menu" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>左边菜单</title>
<style type="text/css">
<!--
BODY {
	FONT-SIZE: 12px
}
TD {
	FONT-SIZE: 12px
}
.menu_box_pad {
	PADDING-RIGHT: 2px; PADDING-LEFT: 2px; BACKGROUND: #fdf9d5; PADDING-BOTTOM: 2px; PADDING-TOP: 0px
}
.menu_box {
	BORDER-RIGHT: #d6d6d6 1px solid; BORDER-TOP: #ababab 1px solid; BORDER-LEFT: #ababab 1px solid; BORDER-BOTTOM: #d6d6d6 1px solid
}
.menu_box TH {
	BACKGROUND: url(images/menu_list_icon.gif) no-repeat center 50%; WIDTH: 10px; LINE-HEIGHT: 22px
}
.menu_box TD {
	BACKGROUND: url(images/menu_list_split.gif) no-repeat left bottom; LINE-HEIGHT: 20px
}
.menu_box A {
	COLOR: #000; TEXT-DECORATION: none
}
.menu_box A:hover {
	TEXT-DECORATION: underline
}
.hand {
	CURSOR: pointer
}
.ctrl_menu {
	BORDER-RIGHT: #767676 1px solid; BACKGROUND: #B8D6F3; BORDER-LEFT: #767676 1px solid; BORDER-BOTTOM: #767676 1px solid
}
.ctrl_menu_title {
	PADDING-LEFT: 15px; FONT-WEIGHT: bold; LINE-HEIGHT: 25px
}
.ctrl_menu_title_bg {
	BACKGROUND: url(images/menu_title_bg.gif)
}
.top_bg {
	BACKGROUND: url(images/top_bg.gif)
}
.logo_bg {
	BACKGROUND: url(images/logo_bg.gif)
}
.a01 A:link {
	COLOR: #000; TEXT-DECORATION: underline
}
.a01 A:visited {
	COLOR: #000; TEXT-DECORATION: underline
}
.a01 A:active {
	COLOR: #000; TEXT-DECORATION: none
}
.a01 A:hover {
	COLOR: #000; TEXT-DECORATION: none
}
#top_nav_menu {
	COLOR: #fff
}
#top_nav_menu A {
	COLOR: #fff; TEXT-DECORATION: none
}
#top_nav_menu A:hover {
	COLOR: #ff6; TEXT-DECORATION: underline
}

-->
</style>
 <SCRIPT language="javascript">
      
function $(s){return document.getElementById(s);}
function swap(s,a,b,c){$(s)[a]=$(s)[a]==b?c:b;}
function hide(s){$(s).style.display=$(s).style.display=="none"?"":"none";}

function openjsj()
{
  window.open("Tool/jsj.htm",null,"height=100%,width=540,status=yes,toolbar=yes,menubar=yes,location=yes,resizable=yes,scroll=yes");

}


function loadload()
{
   var guanlis5=document.getElementById("Hidden5").value;
    var guanlis4=document.getElementById("Hidden4").value;
     var guanlis3=document.getElementById("Hidden3").value;
      var guanlis2=document.getElementById("Hidden2").value;
       var guanlis1=document.getElementById("Hidden1").value;
   if(guanlis5=="0")
   {
     this.document.getElementById("guanlimenu").style.display='none';
   }
    if(guanlis4=="0")
   {
     this.document.getElementById("StockMenuTable").style.display='none';
   }
   
    if(guanlis3=="0")
   {
     this.document.getElementById("salesMenu").style.display='none';
   }
   
    if(guanlis2=="0")
   {
     this.document.getElementById("calgouMenu").style.display='none';
   }
   
   
    if(guanlis1=="0")
   {
     this.document.getElementById("systemSetMenu").style.display='none';
   }
}

      </SCRIPT>
</head>
<body onload="loadload()">
    <form id="form1" runat="server">
    <div><TABLE class=ctrl_menu cellSpacing=0 cellPadding=0 width=205 
            border=0>
              <TBODY>
              <tr>
              <td style="height: 10px; width: 203px;">
           
              
              </td>
              
              </tr>
              <TR>
                <TD align=center style="width: 203px" valign="top"><!-- 快速通道 -->
                  <TABLE class=ctrl_menu_title_bg cellSpacing=0 cellPadding=0 
                  width=195 border=0>
                    <TBODY>
                    <TR class=hand onClick="hide('hideMenuFunc0')">
                      <TD class=ctrl_menu_title width=174>
                          公开信息</TD>
                      <TD width=21><IMG id=MenuFunc0 
                        src="Images/menu_title_up.gif"></TD></TR>
                    <TR id=hideMenuFunc0>
                      <TD class=menu_box_pad align=left colSpan=2>
                        <TABLE class=menu_box cellSpacing=5 cellPadding=0 
                        width="100%" border=0>
                          <TBODY>
                          <TR>
                            <TH>&nbsp;</TH>
                            <TD><A  href="Products/NewsProducts.aspx" 
                              target="MainFrame"> 最新商品</A></TD></TR>
                          <TR>
                            <TH>&nbsp;</TH>
                            <TD><A  href="Products/ShowProductsList.aspx" 
                              target="MainFrame">物品搜索</A></TD>
                          </TR>
                          <TR>
                            <TH>&nbsp;</TH>
                            <TD>
                               <A  href="Notice/NoticeList.aspx" 
                              target="MainFrame"> 系统通知 </A></TD></TR>
                              <tr>
                                  <th style="height: 22px">
                                  </th>
                                  <td style="height: 22px">
                                     <A  href="Customer/My_ServiceInfoList.aspx" 
                              target="MainFrame"> 服务中心 </A></td>
                              </tr>
                              <tr>
                                  <th>
                                  </th>
                                  <td>
                                     <A  href="User/SysUser_Reset_PassWord.aspx" 
                              target="MainFrame"> 密码设置
                              </A>
                              
                              </td>
                              </tr>
                              <tr>
                                  <th>
                                  </th>
                                  <td>
                                     <A  href="Sales/FindSalesOrder_DispatchState.aspx" 
                              target="MainFrame">  发货查询 </A></td>
                              </tr>
                          </TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR>
              <TR>
                <TD align=center  valign="top" style="width: 203px; height: 48px" ><table border="0" id="guanlimenu" cellpadding="0" cellspacing="0" class="ctrl_menu_title_bg" width="195">
                              <tr class="hand" onclick="hide('hideMenuFunc9')">
                                  <td class="ctrl_menu_title" width="174">
                                      管理流程</td>
                                  <td width="21">
                                      <img id="Img5" src="Images/menu_title_down.gif" /></td>
                              </tr>
                              <tr id="hideMenuFunc9" style="display:">
                                  <td align="left" class="menu_box_pad" colspan="2" style="height: 17px">
                                      <table border="0" cellpadding="0" cellspacing="5" class="menu_box" width="100%">
                                          <asp:Repeater ID="FlowRepeater" runat="server">
                                              <ItemTemplate>
                                                  <tr>
                                                      <th>
                                                          &nbsp;</th>
                                                      <td>
                                                          <a href=" <%# Eval("WebUrl")%>" target="MainFrame">
                                                              <%# Eval("AuthorityName")%>
                                                          </a>
                                                      </td>
                                                  </tr>
                                              </ItemTemplate>
                                          </asp:Repeater>
                                      </table>
                                  </td>
                              </tr>
                          </table>
                  </TD></TR>
                
              <TR height=5>
                <TD style="height: 4px; width: 203px;" valign="top" align="center">
                    <TABLE class=ctrl_menu_title_bg id="salesMenu" cellSpacing=0 cellPadding=0 
                  width=195 border=0>
                        <TBODY>
                            <TR class=hand onClick="hide('hideMenuFunc4')">
                                <TD class=ctrl_menu_title width=174>
                                    销售开单</td>
                                <TD width=21>
                                    <IMG id=Img1 
                        src="Images/menu_title_down.gif"></td>
                            </tr>
                            <TR id="hideMenuFunc4" style="display:">
                                <TD class=menu_box_pad align=left colSpan=2 style="height: 17px" >
                                    <TABLE class=menu_box cellSpacing=5 cellPadding=0 
                        width="100%" border=0>
                                        <TBODY>
                                            <asp:Repeater ID="SalesMenu" runat="server">
                                                <ItemTemplate>
                                                    <TR>
                                                        <TH>
                                                            &nbsp;</th>
                                                        <TD>
                                                            <a target="MainFrame" href=" <%# Eval("WebUrl")%>" >
                                                                <%# Eval("AuthorityName")%>
                                                            </a>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </TD></TR>
                  <tr height="5">
                      <td style="width: 203px; height: 4px" align="center" valign="top"><TABLE class=ctrl_menu_title_bg id="StockMenuTable" cellSpacing=0 cellPadding=0 
                  width=195 border=0>
                          <TBODY>
                              <TR class=hand onClick="hide('hideMenuFunc5')">
                                  <TD class=ctrl_menu_title width=174>
                                      库存开单</td>
                                  <TD width=21>
                                      <IMG id=Img2 
                        src="Images/menu_title_down.gif"></td>
                              </tr>
                              <TR id="hideMenuFunc5"style="display:">
                                  <TD class=menu_box_pad align=left colSpan=2 style="height: 17px" >
                                      <TABLE class=menu_box cellSpacing=5 cellPadding=0 
                        width="100%" border=0>
                                          <TBODY>
                                              <asp:Repeater ID="StockMenu" runat="server">
                                                  <ItemTemplate>
                                                      <TR>
                                                          <TH>
                                                              &nbsp;</th>
                                                          <TD>
                                                              <a target="MainFrame" href=" <%# Eval("WebUrl")%>" >
                                                                  <%# Eval("AuthorityName")%>
                                                              </a>
                                                          </td>
                                                      </tr>
                                                  </ItemTemplate>
                                              </asp:Repeater>
                                          </tbody>
                                      </table>
                                  </td>
                              </tr>
                          </tbody>
                      </table>
                      </td>
                  </tr>
                  <tr>
                      <td align="center" style="width: 203px; height: 15px" valign="top">
                          
                          <TABLE class=ctrl_menu_title_bg id="calgouMenu" cellSpacing=0 cellPadding=0 
                  width=195 border=0>
                    <TBODY>
                    <TR class=hand onClick="hide('hideMenuFunc3')">
                      <TD class=ctrl_menu_title width=174>
                          采购开单</TD>
                      <TD width=21><IMG id=MenuFunc3 
                        src="Images/menu_title_down.gif"></TD></TR>
                    <TR id="hideMenuFunc3" style="display:">
                      <TD class=menu_box_pad align=left colSpan=2 >
                        <TABLE class=menu_box cellSpacing=5 cellPadding=0 
                        width="100%" border=0>
                          <TBODY>
                      
                          
                          <asp:Repeater ID="purchaseMenu" runat="server">
        <ItemTemplate>
                        <TR>
                            <TH>&nbsp;</TH>
                            <TD>
                              <a target="MainFrame" href=" <%# Eval("WebUrl")%>" > <%# Eval("AuthorityName")%></a>
                               </TD>
                          </TR>
        
        </ItemTemplate>
        </asp:Repeater>
                          
                          </TBODY></TABLE></TD></TR></TBODY></TABLE>

                          
                      </td>
                  </tr>
              <TR>
                <TD align=center style="width: 203px; height: 15px;" valign="top"><!-- 好友信息 -->
                    &nbsp;<TABLE class=ctrl_menu_title_bg id="systemSetMenu" cellSpacing=0 cellPadding=0 
                  width=195 border=0>
                        <TBODY>
                            <TR class=hand onClick="hide('hideMenuFunc6')">
                                <TD class=ctrl_menu_title width=174 align="center">
                                    系统设置</td>
                                <TD width=21>
                                    <IMG id=Img3 
                        src="Images/menu_title_down.gif"></td>
                            </tr>
                            <TR id="hideMenuFunc6" style="display:">
                                <TD class=menu_box_pad align=left colSpan=2 style="height: 17px" >
                                    <TABLE class=menu_box cellSpacing=5 cellPadding=0 
                        width="100%" border=0>
                                        <TBODY>
                                            <asp:Repeater ID="SystemSet" runat="server">
                                                <ItemTemplate>
                                                    <TR>
                                                        <TH>
                                                            &nbsp;</th>
                                                        <TD>
                                                            <a target="MainFrame" href=" <%# Eval("WebUrl")%>" >
                                                                <%# Eval("AuthorityName")%>
                                                            </a>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                  <!-- /好友信息 --></TD>
              </TR>
              <TR height=5>
                <TD style="width: 203px; height: 5px;" align="center">
                    &nbsp;
                </TD></TR>
              <TR>
                <TD align=middle style="width: 203px"><!-- BLOG信息 --></TD>
              </TR>
              </TBODY></TABLE>
    
    </div>
        <input id="Hidden1" type="hidden" value="0" runat="server" />
        <br />
        <input id="Hidden2" type="hidden" value="0" runat="server" />
        <br />
        <input id="Hidden3" type="hidden" value="0" runat="server" /><br />
        <input id="Hidden4" type="hidden" value="0" runat="server" /><br />
        <input id="Hidden5" type="hidden" value="0" runat="server" />
    </form>
</body>
</html>
