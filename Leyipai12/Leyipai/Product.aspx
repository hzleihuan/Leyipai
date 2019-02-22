<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>


<%@ Register src="Control/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="Control/footer.ascx" tagname="footer" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>商品详细信息</title>
   <link rel="stylesheet" type="text/css" href="Styles/common.css"/>
    <link href="Styles/login.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/topCommon.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/init.js"></script>
<link href="Styles/Product.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">

    <uc1:top ID="top1" runat="server" />
<div class="one">

<div id="p-left">
<div class="detail_ltitle">购买过此商品的人还购买</div>
<div class="detail_l1_box">

<DIV class="detail_l1div">
<DIV class="detail_l1img">
<DIV><A href="#" target=_blank><IMG 
alt="福临门醇香黄豆酱(瓶装 100g)" 
src="images/74724_210448_pic60_5157.jpg"></A></DIV></DIV>
<DIV class="detail_l1info">
<DIV class="detail_l1t"><A href="#" 
target=_blank>福临门醇香黄豆酱(瓶装 100g)</A></DIV>
<DIV style="MARGIN-TOP: 6px" id="buy_a_74724" 
class="market_member_price"></DIV></DIV></DIV>



<DIV class="detail_l1div">
<DIV class="detail_l1img">
<DIV><A href="#" target=_blank><IMG 
alt="福临门醇香黄豆酱(瓶装 200g)" 
src="images/74724_210448_pic60_5157.jpg"></A></DIV></DIV>
<DIV class="detail_l1info">
<DIV class="detail_l1t"><A href="#" 
target=_blank>福临门醇香黄豆酱(瓶装 200g)</A></DIV>
<DIV style="MARGIN-TOP: 6px" id="DIV1" 
class="market_member_price"></DIV></DIV></DIV>


<DIV class="detail_l1div">
<DIV class="detail_l1img">
<DIV><A href="#" target=_blank><IMG 
alt="福临门醇香黄豆酱(瓶装 500g)" 
src="images/74724_210448_pic60_5157.jpg"></A></DIV></DIV>
<DIV class="detail_l1info">
<DIV class="detail_l1t"><A href="#" 
target=_blank>福临门醇香黄豆酱(瓶装 500g)</A></DIV>
<DIV style="MARGIN-TOP: 6px" id="DIV2" 
class="market_member_price"></DIV></DIV></DIV>




</div>
<br />
<br />
<br />
</div>

<div id="p-rigth">
<div class=detail_r1_title>
<H1>立丰沙嗲牛肉干(袋装 120g)【第二件五折】</H1></div>
<br />
<br />
<br />
<br />
   <span style="margin-left:100px;"><asp:Button ID="Button1" runat="server" Text="添加到购物车" onclick="Button1_Click" /></span> 
<br />
<br />
<br />

<div class="detail_r4_title">
<div class="detail_r4_tcur">商品详情</div>
<div class="detail_r4_tdiv"><A 
href="#">客户点评<SPAN 
style="COLOR: #ff0000">(1)</SPAN></A></div>
<div class="detail_r4_tdiv"><A 
href="#">包装配送</A></div></div>

<div class="detail_r4_tittle3">商品描述</div>
<div class="detail_r4_box2">这里填写商品描述：商品描述商品描述商品描述</div>



</div>
 
</div>
 

    
    <uc2:footer ID="footer1" runat="server" />
    </form>
</body>
</html>
