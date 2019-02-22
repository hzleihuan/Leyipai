<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 4.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>系统登陆</title>
	<style type="text/css">
	body { margin:0px;  top:0; left:o; FONT-SIZE: 12px; COLOR: #333333; LINE-HEIGHT: 150%; FONT-FAMILY: "宋体"}
	#main{ margin:auto; width:913px; height:100%}
	#tip1 { position:relative; margin-top:0px; height:110px; width:461px;}
	#tip2 { position:relative; height:32px; margin-left:461px; width:400px; margin-top:-32px;}
	
	#login_bg{ margin:auto; width:913px;margin-top:-5px; height:230px; background-image:url(images/login_bg.gif)}
	#login_bg_from{margin-left:461px; padding-top:50px; padding-left:60px }
	
		#login_name input{ width:160px; height:16px;  }
		#login_pwd{ margin-top:10px;}
		#login_pwd input{ width:160px; height:16px; }
		#login_code{margin-top:2px; }
		#login_code input{ width:60px; height:16px; }
	    #submitBut{ margin-top:10px; padding-left:20px;}
	
	
	#footer{ margin-top:20px;}
	
</style>


</head>
<body  background="images/bg.gif">
 <form id="form1" runat="server">
<div id="main">
  <div align="left"><img height="80px" alt=""  src="images/log_mykd_n.gif"  width="212px" /></div>
  <div id="tip1"></div>
  <div id="tip2" align="right"><img height="32px" alt=""  src="images/pic_text.gif" width="381px" /></div>
  
   <div id="login_bg">
   
   <div id="login_bg_from">
       <div id="login_name">用户名&nbsp; 
           <asp:TextBox ID="username" runat="server" >51aspx</asp:TextBox> </div>
	   <div id="login_pwd">密&nbsp;&nbsp;&nbsp;码
           <asp:TextBox ID="password" TextMode="Password" runat="server">111111</asp:TextBox>
       </div>
	   <div id="login_code">
	    <table style="width:98%"  border="0">
  <tr>
    <td width="50px">验证码&nbsp;</td>
    <td width="52px"> 
        <asp:TextBox ID="code" runat="server"></asp:TextBox>   </td>
    <td><img src="../include/GetValidate.aspx"  alt="" /></td>
  </tr>
</table>
</div>


<div id="submitBut">
 <asp:ImageButton ID="LoginButton" runat="server" ImageUrl="images/but1.gif"
                                      OnClick="LoginButton_Click" />
</div>
   </div>
   
   </div>
   
   
   
   
   <div id="footer" align="center"><font color="#999999">深圳乐易拍版权所有 2008-2009<BR>请使用IE6.0 
SP1以上浏览器，最佳显示分辨率1024×768</font></div >

</div>
</form>
</body>
</html>