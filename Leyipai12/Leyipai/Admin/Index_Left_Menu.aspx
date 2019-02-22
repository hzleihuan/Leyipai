<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index_Left_Menu.aspx.cs" Inherits="Admin_Index_Left_Menu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
 <SCRIPT language=javascript>

     function $(s) { return document.getElementById(s); }
     function swap(s, a, b, c) { $(s)[a] = $(s)[a] == b ? c : b; }
     function hide(s) { $(s).style.display = $(s).style.display == "none" ? "" : "none"; }

     function openjsj() {
         window.open("Tool/jsj.htm", null, "height=100%,width=540,status=yes,toolbar=yes,menubar=yes,location=yes,resizable=yes,scroll=yes");

     }


     function loadload() {
         var guanlis5 = document.getElementById("Hidden5").value;
         var guanlis4 = document.getElementById("Hidden4").value;
         var guanlis3 = document.getElementById("Hidden3").value;
         var guanlis2 = document.getElementById("Hidden2").value;
         var guanlis1 = document.getElementById("Hidden1").value;
         if (guanlis5 == "0") {
             this.document.getElementById("guanlimenu").style.display = 'none';
         }
         if (guanlis4 == "0") {
             this.document.getElementById("StockMenutable").style.display = 'none';
         }

         if (guanlis3 == "0") {
             this.document.getElementById("salesMenu").style.display = 'none';
         }

         if (guanlis2 == "0") {
             this.document.getElementById("calgouMenu").style.display = 'none';
         }


         if (guanlis1 == "0") {
             this.document.getElementById("systemSetMenu").style.display = 'none';
         }
     }

      </SCRIPT>
</head>
<body>
    <form id="form1" runat="server">
    <div><table class=ctrl_menu cellSpacing=0 cellPadding=0 width=205 
            border=0>
              <tbody>
              <tr>
              <td style="height: 10px; width: 203px;">
           
              
              </td>
              
              </tr>
              <tr>
                <td align=center style="width: 203px" valign="top"><!-- 快速通道 -->
                  <table class=ctrl_menu_title_bg cellSpacing=0 cellPadding=0 
                  width=195 border=0>
                    <tbody>
                    <tr class=hand onClick="hide('hideMenuFunc0')">
                      <td class=ctrl_menu_title width=174>
                          快捷导航</td>
                      <td width=21><IMG id=MenuFunc0 
                        src="images/menu_title_up.gif"></td></tr>
                    <tr id=hideMenuFunc0>
                      <td class=menu_box_pad align=left colSpan=2>
                        <table class=menu_box cellSpacing=5 cellPadding=0 
                        width="100%" border=0>
                          <tbody>
                          
                          
                          
                              <tr><th></th><td><A  href="../index.aspx" target=_blank> 前台首页</A>
                              </td>
                              </tr>
                              <tr><th></th><td><A  href="sys/MySet.aspx" target="MainFrame"> 用户设置</A>
                              </td>
                              </tr>
                              
                          </tbody></table></td></tr></tbody></table></td></tr>
              <tr>
                <td align=center  valign="top" style="width: 203px;" ><table border="0" id="guanlimenu" cellpadding="0" cellspacing="0" class="ctrl_menu_title_bg" width="195">
                              <tr class="hand" onclick="hide('hideMenuFunc9')">
                                  <td class="ctrl_menu_title" width="174">
                                      销售管理</td>
                                  <td width="21">
                                      <img id="Img5" src="images/menu_title_down.gif" /></td>
                              </tr>
                              <tr id="hideMenuFunc9" style="display:">
                                  <td align="left" class="menu_box_pad" colspan="2" style="height: 17px">
                                      <table border="0" cellpadding="0" cellspacing="5" class="menu_box" width="100%">
                                          <asp:Repeater ID="SalesRepeater" runat="server">
                                              <ItemTemplate>
                                                  <tr>
                                                      <th>
                                                          &nbsp;</th>
                                                      <td>
                                                          <a href=" <%# Eval("url")%>" target="MainFrame">
                                                              <%# Eval("menuname")%>
                                                          </a>
                                                      </td>
                                                  </tr>
                                              </ItemTemplate>
                                          </asp:Repeater>
                                      </table>
                                  </td>
                              </tr>
                          </table>
                  </td></tr>
              <tr height="5">
                <td style=" width: 203px;" valign="top" align="center">
                    <table class=ctrl_menu_title_bg id="salesMenu" cellSpacing=0 cellPadding=0 
                  width=195 border=0>
                        <tbody>
                            <tr class=hand onClick="hide('hideMenuFunc4')">
                                <td class=ctrl_menu_title width=174>
                                    采购管理</td>
                                <td width=21>
                                    <IMG id=Img1 
                        src="images/menu_title_down.gif"></td>
                            </tr>
                            <tr id="hideMenuFunc4" style="display:">
                                <td class=menu_box_pad align=left colSpan=2 style="height: 17px" >
                                    <table class=menu_box cellSpacing=5 cellPadding=0 
                        width="100%" border=0>
                                        <tbody>
                                            <asp:Repeater ID="Repeater1" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <TH>
                                                            &nbsp;</th>
                                                        <td>
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
                </td></tr>
                  <tr height="5">
                      <td style="width: 203px; height: 4px" align="center" valign="top"><table class=ctrl_menu_title_bg id="StockMenutable" cellSpacing=0 cellPadding=0 
                  width=195 border=0>
                          <tbody>
                              <tr class=hand onClick="hide('hideMenuFunc5')">
                                  <td class=ctrl_menu_title width=174>
                                      库存管理</td>
                                  <td width=21>
                                      <IMG id=Img2 
                        src="images/menu_title_down.gif"></td>
                              </tr>
                              <tr id="hideMenuFunc5"style="display:">
                                  <td class=menu_box_pad align=left colSpan=2 style="height: 17px" >
                                      <table class=menu_box cellSpacing=5 cellPadding=0 
                        width="100%" border=0>
                                          <tbody>
                                              <asp:Repeater ID="StockMenu" runat="server">
                                                  <ItemTemplate>
                                                      <tr>
                                                          <TH>
                                                              &nbsp;</th>
                                                          <td>
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
                      <td align="center" style="width: 203px;" valign="top">
                          
                          <table class=ctrl_menu_title_bg id="calgouMenu" cellSpacing=0 cellPadding=0 
                  width=195 border=0>
                    <tbody>
                    <tr class=hand onClick="hide('hideMenuFunc3')">
                      <td class=ctrl_menu_title width=174>
                          财务管理</td>
                      <td width=21><IMG id=MenuFunc3 
                        src="images/menu_title_down.gif"></td></tr>
                    <tr id="hideMenuFunc3" style="display:">
                      <td class=menu_box_pad align=left colSpan=2 >
                        <table class=menu_box cellSpacing=5 cellPadding=0 
                        width="100%" border=0>
                          <tbody>
                      
                          
                          <asp:Repeater ID="purchaseMenu" runat="server">
        <ItemTemplate>
                        <tr>
                            <TH>&nbsp;</TH>
                            <td>
                              <a target="MainFrame" href=" <%# Eval("WebUrl")%>" > <%# Eval("AuthorityName")%></a>
                               </td>
                          </tr>
        
        </ItemTemplate>
        </asp:Repeater>
                          
                          </tbody></table></td></tr></tbody></table>

                          
                      </td>
                  </tr>
              <tr>
                <td align=center style="width: 203px;" valign="top">
                    &nbsp;<table class=ctrl_menu_title_bg id="systemSetMenu" cellSpacing=0 cellPadding=0 
                  width=195 border=0>
                        <tbody>
                            <tr class=hand onClick="hide('hideMenuFunc6')">
                                <td class=ctrl_menu_title width=174 align="center">
                                    系统设置</td>
                                <td width=21>
                                    <IMG id=Img3 
                        src="images/menu_title_down.gif"></td>
                            </tr>
                            <tr id="hideMenuFunc6" style="display:">
                                <td class=menu_box_pad align=left colSpan=2 style="height: 17px" >
                                    <table class=menu_box cellSpacing=5 cellPadding=0 
                        width="100%" border=0>
                                        <tbody>
                                            <asp:Repeater ID="SystemSet" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <TH>
                                                            &nbsp;</th>
                                                        <td>
                                                            <a target="MainFrame" href=" <%# Eval("url")%>" >
                                                                <%# Eval("menuname")%>
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
                  <!-- /好友信息 --></td>
              </tr>
              <tr height=5>
                <td style="width: 203px; height: 5px;" align="center">
                    &nbsp;
                </td></tr>
              <tr>
                <td align=middle style="width: 203px"><!-- BLOG信息 --></td>
              </tr>
              </tbody></table>
    
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
