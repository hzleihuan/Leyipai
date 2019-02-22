<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<%@ Register src="Control/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="Control/footer.ascx" tagname="footer" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>乐意拍商城用户注册</title>
   <link rel="stylesheet" type="text/css" href="Styles/common.css"/>
    <link href="Styles/regInfo.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/topCommon.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/reg.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/init.js"></script>

<style type="text/css">

#regTop {
	 position:relative; height:100px; width:100%
}
</style>
</head>
<body>
    <form id="form1" method="post" action="RegCheckEmail.aspx" >

    <uc1:top ID="top1" runat="server" />
<div class="one">

<div id="regTop" >
 <img alt="用户注册第一步" src="images/regTag1.png" />
</div>


<div id="regform">
 <div class="reginfo_txtdiv">
<div class="reginfo_tl"><span>*</span>Email地址：</div>
<div class="reginfo_tr2"><input id="email" class="reginfo_input2" onblur="checkEmail(this)" onkeypress="clearMsg(this)" name="email" /></div>
<div id="emailMsg"></div></div>
<div class="reginfo_txtdiv">
<div class="reginfo_tl"><span>*</span>用户名：</div>
<div class="reginfo_tr2"><input onblur="checkUserName(this)" id="username" class="reginfo_input2" onkeypress="clearMsg(this);" name="username"/></div>
<div id="usernameMsg"></div></div>
<div class="reginfo_txtdiv">
<div class="reginfo_tl"><span>*</span>登录密码：</div>
<div class="reginfo_tr2"><input onblur="checkPwd(this)" id="password"class="reginfo_input2" onkeypress="clearMsg(this)" type="password" name="password"/></div>
<div id="passwordMsg"></div></div>
<div class="reginfo_txtdiv">
<div class="reginfo_tl"><span>*</span>确认密码：</div>
<div class="reginfo_tr2"><input onblur="checkPwd2(this)" class="reginfo_input2" onkeypress="clearMsg(this)" type="password" name="password2"/></div>
<div id="password2Msg"></div></div>

<div class="reginfo_txtdiv">
<div class="reginfo_tl"><span>*</span>验证码：</div>
<div class="reginfo_tr2"><input onblur="checkCode(this)" style="WIDTH: 60px" class="reginfo_input2" onkeypress="" name="validateCode"/></div>
<div class="reginfo_trcode"><img id="vCode" src="include/GetValidate.aspx" alt=""/></div>
<div class="reginfo_tr3">&nbsp;&nbsp;<a onclick="codeRefresh();return false;" 
href="javascript:;">看不清楚，换一张</a></div>
<div style="BACKGROUND-IMAGE: none" id="validateCodeMsg"></div></div>
    

    <div class="reginfo_read"><input checked="checked" id="checkBox" type="checkbox"/><a href="#">我已阅读并同意《我买网网上商城服务条款》</a></div>
            

    <div class="reginfo_subbtn">
    
    
     <input id="submitBtn" src="images/reginfo_subbtn.gif" type="image" /></div>
    </div>
   
 
</div>
    
    <uc2:footer ID="footer1" runat="server" />
    </form>
</body>
</html>

