<%@ Control Language="C#" AutoEventWireup="true" CodeFile="top.ascx.cs" Inherits="Control_top" %>
<div class=top>
<div class=topsl id="tops_1"><SPAN><a 
href="ShoppingCart.aspx?pid=0">购物车<STRONG>0</STRONG>种商品</a>　|　<a 
href="#">我的收藏</a></SPAN><a 
href="vascript:void(0)" class="signin"><label>[ 登录 ]</label></a>　|　<a 
href="Register.aspx">[ 免费注册 ]</a> </div>
<div class=topsr>
<div class=user>
<DL>
  <DT><a href="#">我的乐易拍</a></DT>
  <DD><a href="#">我购买的商品</a><a 
  href="#">我的收藏</a><a 
  href="#">最新降价提醒</a><a 
  href="#">短消息(<STRONG>22</STRONG>)条</a></DD></DL></div>
<div class=text>|<a href="#">供应商加盟</a>|<a 
href="#">反馈</a>|<a 
href="#">装修社区</a>|</div>
<div class=help>
<DL>
  <DT><a href="#">帮助</a></DT>
  <DD><a href="#">支付方式</a><a 
  href="#">配送范围</a><a 
  href="#">客户服务</a></DD></DL></div></div>
<div class=topClose><a title=点击关闭 href="javascript:void(0)">关闭</a></div></div>


<div class=topOpen><a title=点击打开 href="javascript:void(0)">打开</a></div><!-- head -->
<div class=head>
<H1><a title="" href="index.aspx">乐意拍商城</a></H1>
<div class=search><INPUT id=searchInput maxLength=20 type=text 
name=searchInput><BUTTON type=submit>商品搜索</BUTTON> </div>
<div class=tags><a href="#">MP4</a><a 
href="#">数码</a><a href="#">手机</a> 
</div></div><!-- nav -->

<div class=nav><SPAN class=icon></SPAN><SPAN class=navl></SPAN><SPAN 
class=navr></SPAN>
<UL>
  <LI><a href="#">首 页</a></LI>
  <LI><a href="#">乐易商城</a></LI>
  <LI><a href="#">特价商品</a></LI>
  <LI><a href="#">促销热卖</a></LI>
  <LI><a href="#">新品上市</a></LI>
  <LI><a href="#">行业资讯</a></LI>
  <LI><a href="#">乐易社区</a></LI></UL></div>

<fieldset id="signin_menu">
<form id="signin" method="post" action="">
<P></P>
<label for="username">邮箱</label> 
<input id="username" title="username" tabIndex=4 type=text 
name="username"> 
<P></P>
<P><label for="password">密码</label> <input id="password" title="password"
tabIndex=5 type="password" name="password"> </P>
<P class=remember><input id=signin_submit tabIndex=6 value="Sign in" type=submit> 
<input id=remember tabIndex=7 value=1 type=checkbox name=remember_me> <label 
for=remember>记住我</label> </P>
<P class=forgot><A id=resend_password_link 
href="#">忘记密码?</A> </P>
</form></fieldset>