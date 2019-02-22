<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegCheckEmail.aspx.cs" Inherits="RegCheckEmail" %>

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

.arrow {
	BACKGROUND-COLOR: #e4e4e4; FONT-SIZE: 14px;  margin-left:50px;
}
.c666 {
	COLOR: #666 !important
}.p1 {
	LINE-HEIGHT: 20px
}
.regbotton {
	HEIGHT: 28px
}
.regbotton A {
	BORDER-BOTTOM: #000000 1px solid; BORDER-LEFT: #000000 1px solid; PADDING-BOTTOM: 5px; LINE-HEIGHT: 28px; PADDING-LEFT: 15px; PADDING-RIGHT: 15px; BACKGROUND: url(images/reg_botton02.jpg) 50% top; COLOR: #fff; FONT-SIZE: 14px; BORDER-TOP: #000000 1px solid; FONT-WEIGHT: bold; BORDER-RIGHT: #000000 1px solid; PADDING-TOP: 5px
}
.regbotton A:link {
	COLOR: #fff; TEXT-DECORATION: none
}
.regbotton A:visited {
	COLOR: #fff; TEXT-DECORATION: none
}
.regbotton A:hover {
	BACKGROUND: url(images/reg_botton01.jpg); COLOR: #fff; FONT-SIZE: 14px; TEXT-DECORATION: none
}
.regbotton A:active {
	COLOR: #fff; TEXT-DECORATION: none
}
</style>
</head>
<body>
    <form id="form1" runat="server">

    <uc1:top ID="top1" runat="server" />
      
      <div class="one">
      <div id="top">
      <img src="images/regTag2.png" alt="" />
      </div>
      
      <div class="line" style="font-size:14px; font-weight:bold; text-align:left" >离成功只差一步了，请立即激活账户</div>

         <div>
            <div style="position:relative; top:0px; left:0px; width:20%; height:250px; float:left; padding-top:20px;">
            <img alt="信封" src="images/reg_next2_leftbg.jpg" />
            </div>

            <div  class="p1" style="position:relative; top:0px; left:210px; width:78%; height:250px; float:right;padding-top:10px;">
            <P class=c666>我们已向你填写的Email地址 <SPAN class="nub c000">ei-7758258@163.com</SPAN> 
<BR>发送了一封激活邮件，请注意查收。 <BR>点击邮件中的确认链接即可激活你的账户。<BR></P>
                <div style="MARGIN: 10pt 0px" class="regbotton"><A 
onclick="window.open('http://mail.163.com')" 
href="javascript:void(0);">现在就去收信</A> <A 
href="#">完善资料</A>
</div>
           <P class="px14 bb h30">没收到邮件？</P>
<P class=c666>可能目前网络不太顺畅，需要等待几分钟才能收到该邮件。 <BR>可以去你的垃圾邮件箱中找找。<BR>可以点击<A 
href="#">重新进行验证</A>。再次查看确认信是否到达。<BR>可以重新发送<A 
href="#">更换一个Email地址</A>，重新进行验证。</P> 
            </div>
         
         
         </div>




      </div>
    
       

    <uc2:footer ID="footer1" runat="server" />
    </form>
</body>
</html>