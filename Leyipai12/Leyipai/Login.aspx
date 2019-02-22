<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<%@ Register src="Control/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="Control/footer.ascx" tagname="footer" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户登录</title>
   <link rel="stylesheet" type="text/css" href="Styles/common.css"/>
    <link href="Styles/login.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/topCommon.js"></script>
</head>
<body>
    <form id="form1" runat="server">

    <uc1:top ID="top1" runat="server" />
<div class="one">


   <div id="login_main" style="background-image:url(images/login_mainbg.jpg)">

<div class="login_r">
<div class="login_lgbox">
<div class="login_lgtop"><img alt="" src="images/spacer.gif" width="1" height="1" /></div>
<div class="login_lgmain">
<div class="login_lgtitle">请登录乐意拍</div>
    </div>
<div class="login_lgdiv">
<div class="login_lgt">Email或用户名：</div>
<div class="login_lginp"> 
    <asp:TextBox ID="loginId" runat="server"></asp:TextBox> 
    
    </div></div>
<div class="login_lgdiv">
<div class="login_lgt">请输入登录密码：</div>
<div class="login_lginp">
    <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
</div></div>
<div class="login_lgdiv">
<div class="login_lgt">请输入验证码：</div>
<div class="login_lginp">

    <asp:TextBox ID="validateCode" runat="server" Width="90px"></asp:TextBox>
&nbsp;<img alt="" style="VERTICAL-ALIGN: -9px" id="vCode"
src=""/></div></div>
<div class="login_lgdiv">
<div class="login_lgcode"></div>
<div class="login_lgreset"><a onclick="codeRefresh();return false;" 
href="javascript:;">看不清楚，换一张</a></div></div>
<div class="login_lgdiv">
<div class="login_lgbtn">
    <asp:ImageButton ID="ImageButton1" runat="server" 
        ImageUrl="~/images/login_lgbtn.gif" onclick="ImageButton1_Click" />
&nbsp;</div>
<div class="login_lglose"><a
href="http://www.womai.com/FindPassword.do">忘记密码?</a></div></div>
   
<div class="login_lgnew"><span>还不是青青河用户？&nbsp;&nbsp; </span>快捷方便的免费注册，让您立刻尽享青青河提供的各项优惠及服务。 
<div class="login_lgnewbtn"><A 
href="Register.aspx"><img border=0 alt="" 
src="images/login_lgnewbtn.gif"/></A></div></div></div>
<div class="login_lgbottom"><img alt="" 
src="images/spacer.gif" width=1 
height=1 /></div></div></div>
<div class="clear"></div>
</div>
 

    
    <uc2:footer ID="footer1" runat="server" />
    </form>
</body>
</html>
