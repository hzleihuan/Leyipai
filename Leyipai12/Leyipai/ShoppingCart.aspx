<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" %>

<%@ Register src="Control/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="Control/footer.ascx" tagname="footer" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>我的购物车</title>
   <link rel="stylesheet" type="text/css" href="Styles/common.css"/>
    <link href="Styles/regInfo.css" rel="stylesheet" type="text/css" />
    <link href="Styles/shoppingCart.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/topCommon.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/init.js"></script>

 <script type="text/javascript">
     //点击+号图，数量+1
     function Plus(obj) {
         obj.value = parseInt(obj.value) + 1;
     }
     //数量-1
     function Reduce(obj) {
         if (obj.value > 1) {
             obj.value = obj.value - 1;
         }
     }
     //替换txtAmount文本框非整数的输入
     //数据整个不合法时置1
     function CheckValue(obj) {
         var v = obj.value.replace(/[^\d]/g, '');
         if (v == '' || v == 'NaN') {
             obj.value = "1";
         }
         else {
             obj.value = v;
         }
     }
    </script>

</head>
<body>
    <form id="form1" runat="server">

    <uc1:top ID="top1" runat="server" />
<div class="one">


             <table class="shopping_bag" border="0" cellspacing="0" cellpadding="0"
      width="100%"><!--DWLayouttable-->
        <tbody>
        <tr>
          <td height="10px" width="950px"></td></tr>
        <tr>
          <td height=26 valign="top">
            <table class=arrow border=0 cellSpacing=0 cellPadding=0 
width="100%"><!--DWLayouttable-->
              <tbody>
              <tr>
                <td style="COLOR: #ffffff" bgcolor="#95cf4c" height="26px"
                valign=center width=302 
                align=middle><StrONG>1.查看购物车</StrONG></td>
                <td valign=top width=22><img src="images/Arrow1.gif" 
                  width=22 height=26></td>
                <td style="COLOR: #000000" valign=center width=302 
                  align=middle><StrONG>2.请确认订单信息</StrONG></td>
                <td valign=top width=22><img src="images/Arrow2.gif" 
                  width=22 height=26></td>
                <td style="COLOR: #000000" valign=center width=302 
                  align=middle><StrONG>3.完成订单</StrONG></td></tr></tbody></table></td></tr>
        <tr>
          <td height=34 valign=top>
            <table border=0 cellSpacing=0 cellPadding=0 width="100%"><!--DWLayouttable-->
              <tbody>
              <tr>
                <td height=34 valign=center width=34 align=middle><img 
                  src="images/ico_stars.gif" width=23 height=23></td>
                <td style="COLOR: #666666; FONT-SIZE: 12px" valign=center 
                width=916>
                  <DIV id=zengpinprice></DIV></td></tr></tbody></table></td></tr>
        <tr>
          <td valign=top>
            <table class=shoppinglist border=0 cellSpacing=0 cellPadding=0 
            width="100%"><!--DWLayouttable-->
              <tbody>
              <tr>
                <td height=29 valign=top width=948>
                  <table class=list_title border=0 cellSpacing=0 cellPadding=0 
                  width="100%"><!--DWLayouttable-->
                    <tbody>
                    <tr>
                      <td height=29 width="250px" align=middle>商品名</td>
                      <td width="150px" align="center">会员价</td>
                      <td width="180px" align="center">数量</td>
                      <td width="120px" align="center">折扣率</td>
                
                      <td align="center"><!--DWLayoutEmptyCell-->&nbsp;</td></tr></tbody></table></td></tr>
              <tr>
                <td height=57 valign=top>
                  
                  
                   <asp:GridView ID="gvCart" runat="server" DataKeyNames="id" AutoGenerateColumns="False"
                ShowFooter="True" Width="100%" ShowHeader="false" OnRowDataBound="gvCart_RowDataBound" OnRowDeleting="gvCart_RowDeleting">

                <Columns>
                    <asp:BoundField DataField="products_name" HeaderText="名称">
                        <ItemStyle Width="260px" />
                    </asp:BoundField>
              
              <asp:BoundField DataField="price" HeaderText="价钱">
                        <ItemStyle Width="180px" />
                    </asp:BoundField>
                   

                    <asp:TemplateField HeaderText="数量">
                        <ItemStyle Width="150px" />
                        <ItemTemplate>
                            <img alt="" src="images/cut.gif" id="imgReduce" runat="server" />
                            <asp:TextBox ID="txtAmount" Width="20px" Height="16px" runat="server" Text='<%# Eval("quantity") %>'
                                onkeyup="CheckValue(this)"></asp:TextBox>
                            <img alt="" src="images/add.gif" id="imgPlus" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:BoundField DataField="discount_rate" ItemStyle-Width="150px" HeaderText="折扣" />

                    <asp:CommandField HeaderText="删除" DeleteText="删除" ShowDeleteButton="true">
                        <ItemStyle />
                    </asp:CommandField>
                </Columns>
                <EmptyDataTemplate>
                    您的购物车中没有任何商品。
                </EmptyDataTemplate>
                <AlternatingRowStyle BackColor="WhiteSmoke" />
            </asp:GridView>

                  
                  </td></tr>
              <tr>
                <td>
                  <DIV id=zengpin></DIV></td></tr></tbody></table></td></tr>
        <tr>
          <td height=103 valign=top>
            <table border=0 cellSpacing=0 cellPadding=0 width="100%"><!--DWLayouttable-->
              <tbody>
              <tr>
                <td height=42 valign=center colSpan=2 align=right>
                  <DIV id=allinfo>总获得积分：<SPAN 
                  style="COLOR: #f00000; FONT-SIZE: 14px"><StrONG>19 
                  </StrONG></SPAN>积分 总价（不含运费）：<SPAN 
                  style="COLOR: #f00000; FONT-SIZE: 14px"><StrONG>199.0 
                  </StrONG></SPAN>元 </DIV></td></tr>
              <tr>
                <td height=61 valign=top width=836 align=right><A 
                  href="#"><img border=0 
                  src="images/go_back.gif" width=103 height=34></A> </td>
        <td valign=top width=114 align=right><A 
                 
                  href="#"><img 
                  border=0 src="images/order.gif" width=103 
              height=34></A></td></tr></tbody></table></td></tr></tbody></table>

</div>
    
    <uc2:footer ID="footer1" runat="server" />
    </form>
</body>
</html>

