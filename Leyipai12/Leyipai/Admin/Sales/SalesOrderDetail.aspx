<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesOrderDetail.aspx.cs" Inherits="Admin_Sales_SalesOrderDetail" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>销售订单详细信息</title>
    <STYLE>BODY {
	SCROLLBAR-ARROW-COLOR: #797979; MARGIN: 0px; SCROLLBAR-DARKSHADOW-COLOR: #ffffff; FONT-FAMILY: "Arial" , "宋体" , "Helvetica" , "sans-serif"; SCROLLBAR-HIGHLIGHT-COLOR: #f5f9ff; SCROLLBAR-SHADOW-COLOR: #828282; FONT-SIZE: 12px; SCROLLBAR-TRACK-COLOR: #ececec; SCROLLBAR-3DLIGHT-COLOR: #828282
}
TD {
	SCROLLBAR-ARROW-COLOR: #797979; MARGIN: 0px; SCROLLBAR-DARKSHADOW-COLOR: #ffffff; FONT-FAMILY: "Arial" , "宋体" , "Helvetica" , "sans-serif"; SCROLLBAR-HIGHLIGHT-COLOR: #f5f9ff; SCROLLBAR-SHADOW-COLOR: #828282; FONT-SIZE: 12px; SCROLLBAR-TRACK-COLOR: #ececec; SCROLLBAR-3DLIGHT-COLOR: #828282
}
TH {
	SCROLLBAR-ARROW-COLOR: #797979; MARGIN: 0px; SCROLLBAR-DARKSHADOW-COLOR: #ffffff; FONT-FAMILY: "Arial" , "宋体" , "Helvetica" , "sans-serif"; SCROLLBAR-HIGHLIGHT-COLOR: #f5f9ff; SCROLLBAR-SHADOW-COLOR: #828282; FONT-SIZE: 12px; SCROLLBAR-TRACK-COLOR: #ececec; SCROLLBAR-3DLIGHT-COLOR: #828282
}
.printTitle {
	FONT-SIZE: 24px; FONT-WEIGHT: bold
}
.printTitle2 {
	FONT-SIZE: 18px; FONT-WEIGHT: normal
}
.printTitle3 {
	FONT-SIZE: 18px; FONT-WEIGHT: bold
}
.printTitle4 {
	FONT-STYLE: italic; FONT-SIZE: 18px; FONT-WEIGHT: bold
}
.printEntryTable {
	BORDER-BOTTOM: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-COLLAPSE: collapse; BORDER-TOP: #000000 1px solid; BORDER-RIGHT: #000000 1px solid
}
.printEntryTable TR {
	HEIGHT: 20px
}
.printEntryTable TH {
	BORDER-BOTTOM: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-TOP: #000000 1px solid; FONT-WEIGHT: normal; BORDER-RIGHT: #000000 1px solid
}
.printEntryTable TD {
	BORDER-BOTTOM: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-RIGHT: #000000 1px solid
}
.PageNext {
	PAGE-BREAK-AFTER: always
}
        .style1
        {
            width: 90px;
        }
        .style2
        {
            width: 105px;
        }
        .style3
        {
            width: 72px;
        }
    </STYLE>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <TABLE style="POSITION: relative"  border=0 cellSpacing=0 cellPadding=0 
width="100%">
  <TBODY>
  <TR style="BACKGROUND-COLOR: #dcdcdc">
    <TD style="FONT-SIZE: 14px"><B></B><input id="hidExportTag" type=hidden></TD>
    <TD id="tdUCToolBar" align=right>
<input id=printButton onclick="javascipt:window.print()" value=打印 type=button> 
<input id=closButton onclick="javascript:window.close();" value=关闭 type=button> 
    </TD></TR></TBODY></TABLE>


    


    <TABLE style="WIDTH: 730px" border=0 cellSpacing=0 align=center>
  <TBODY>
  <TR>
    <TD colSpan=2>
      <TABLE style="WIDTH: 100%; TABLE-LAYOUT: fixed" border=0>
        <TBODY>
        <TR>
          <TD style="WIDTH: 120px" rowSpan=4></TD>
          <TD class=printTitle3 colSpan=3>深圳乐易拍电子商务公司</TD>
        </TR>
        <TR>
          <TD colSpan=3></TD></TR>
        <TR>
          <TD class=printTitle3 colSpan=3>&nbsp;</TD></TR>
        <TR>
          <TD colSpan=3></TD></TR>
        <TR>
          <TD>地址：</TD>
          <TD colSpan=3>深圳市罗湖东门</TD></TR>
        <TR>
          <TD>地址（英文）：</TD>
          <TD style="WORD-WRAP: break-word" colSpan=3>shenzhen city Chian </TD>
        </TR>
        <TR>
          <TD>电话：</TD>
          <TD>0755-26888888</TD>
          <TD style="PADDING-LEFT: 30px">传真：</TD>
          <TD>07552600000</TD></TR>
        <TR>
          <TD>网站：</TD>
          <TD>http://www.leyipai.com.cn</TD>
          <TD style="PADDING-LEFT: 30px">E-Mail：</TD>
          <TD>ei-7758258@163.com</TD></TR></TBODY></TABLE></TD></TR>
  <TR>
    <TD style="TEXT-ALIGN: center" colSpan=2>
      <TABLE style="WIDTH: 100%" class=Title border=0>
        <TBODY>
        <TR>
          <TD style="TEXT-ALIGN: center" 
      class=printTitle>销售订单</TD></TR></TBODY></TABLE></TD></TR>
  <TR>
    <TD vAlign=top>
      <TABLE width="510" border=0 style="WIDTH: 500px">
        <TBODY>
        <TR>
          <TD class="style3">客户：</TD>
          <TD width="440" style="WIDTH: 440px">
              <asp:Label ID="customer_name" runat="server" Text=""></asp:Label>
            </TD>
        </TR>
        <TR>
          <TD class="style3">地址：</TD>
          <TD style="WORD-WRAP: break-word; WORD-BREAK: normal">
              <asp:Label ID="customer_address" runat="server" Text=""></asp:Label>
            </TD></TR>
        <TR>
          <TD class="style3">联系人：</TD>
          <TD>
              <asp:Label ID="customer_linker" runat="server" Text=""></asp:Label>
            </TD></TR>
        <TR>
          <TD class="style3">Email：</TD>
          <TD>
              <asp:Label ID="customet_email" runat="server" Text=""></asp:Label>
            </TD></TR>
        <TR>
          <TD class="style3">手机：</TD>
          <TD>
              <asp:Label ID="customer_tel" runat="server" Text=""></asp:Label>
            </TD></TR>
        <TR>
          <TD class="style3">交货方式：</TD>
          <TD>
              <asp:Label ID="delivery_type" runat="server" Text=""></asp:Label>
            </TD></TR>
        <TR>
          <TD class="style3"></TD>
          <TD></TD></TR></TBODY></TABLE></TD>
    <TD vAlign=top>
      <TABLE style="WIDTH: 230px" border=0>
        <TBODY>
        <TR>
          <TD class="style1">订单编号：</TD>
          <TD>
              <asp:Label ID="sales_orderid" runat="server" Text=""></asp:Label>
            </TD></TR>
        <TR>
          <TD class="style1">订单日期：</TD>
          <TD>
              <asp:Label ID="create_date" runat="server" Text=""></asp:Label>
            </TD></TR>
        <TR>
          <TD class="style1">销售员：</TD>
          <TD>
              <asp:Label ID="username" runat="server" Text=""></asp:Label>
            </TD></TR>
        <TR>
          <TD class="style1">已收款：</TD>
          <TD>
              <asp:Label ID="hadPay" runat="server" Text=""></asp:Label>
            </TD></TR>
        <TR>
          <TD class="style1">订单状态：</TD>
          <TD>
              <asp:Label ID="state" runat="server" Text=""></asp:Label>
            </TD></TR>
        <TR>
          <TD class="style1">货运公司：</TD>
          <TD>
              <asp:Label ID="logistics" runat="server" Text=""></asp:Label>
            </TD></TR>
        <TR>
          <TD class="style1">货运单号：</TD>
          <TD>
              <asp:Label ID="logistics_num" runat="server" Text=""></asp:Label>
            </TD>
        </TR></TBODY></TABLE></TD></TR>
  <TR>
    <TD colSpan=2>
      <TABLE border=0>
        <TBODY>
        <TR>
          <TD>送货地址：</TD>
          <TD class="style2">
              <asp:Label ID="delivery_place" runat="server" Text=""></asp:Label>
            </TD></TR></TBODY></TABLE></TD></TR>
  <TR>
    <TD colSpan=2></TD></TR>
  <TR>
    <TD colSpan=2>
      <TABLE class=printEntryTable width="100%">
        <TBODY>
        <TR align="center">
          <TD>序号</TD>
          <TD>编号</TD>
          <TD>名称</TD>
          <TD>地点</TD>
          <TD>单位</TD>
          <TD>数量</TD>
          <TD>折率</TD>
          <TD>单价</TD>
          <TD>金额</TD></TR>
          <%=orderList%>
        <TR>
          <TD>&nbsp;</TD>
          <TD>&nbsp;</TD>
          <TD>&nbsp;</TD>
          <TD>&nbsp;</TD>
          <TD>&nbsp;</TD>
          <TD>&nbsp;</TD>
           <TD>&nbsp;</TD>
          <TD>&nbsp;</TD>
          <TD>&nbsp;</TD></TR>
        <TR>
          <TD colSpan=5 align=right>合计：</TD>
          <TD align=right>
              <asp:Label ID="totalNumLabel" runat="server" Text=""></asp:Label>
            </TD>
          <TD align=right>&nbsp;</TD>
           <TD>&nbsp;</TD>
          <TD align=right>
              <asp:Label ID="totalMoneyLabel" runat="server" Text=""></asp:Label>
            </TD></TR></TBODY></TABLE></TD></TR>
  <TR>
    <TD colSpan=2 align=right>
      <TABLE border=0>
        <TBODY>
        <TR>
          <TD>优惠金额：</TD>
          <TD>
              <asp:Label ID="discount" runat="server" Text=""></asp:Label>
            </TD>
            <TD style="PADDING-LEFT: 30px">附加金额：</TD>
          <TD >
              <asp:Label ID="attach_pay" runat="server" Text=""></asp:Label>
            </TD>
          <TD style="PADDING-LEFT: 30px">优惠后金额：</TD>
          <TD>
              <asp:Label ID="sales_income" runat="server" Text=""></asp:Label>
            </TD></TR></TBODY></TABLE></TD></TR>
  <TR>
    <TD colSpan=2>
      <TABLE border=0>
        <TBODY>
        <TR>
          <TD>大写金额：</TD>
          <TD>  
              <asp:Label ID="MoneyChinaString" runat="server" Text=""></asp:Label> </TD></TR></TBODY></TABLE></TD></TR>
  <TR>
    <TD colSpan=2>
      <TABLE border=0>
        <TBODY>
        <TR>
          <TD style="WHITE-SPACE: nowrap; VERTICAL-ALIGN: top">相关描述：</TD>
          <TD 
            style="LINE-HEIGHT: 20px">
              <asp:Label ID="description" runat="server" Text=""></asp:Label>
            </TD></TR></TBODY></TABLE></TD></TR>
  <TR>
    <TD colSpan=2>
      <TABLE border=0>
        <TBODY>
        <TR>
          <TD style="VERTICAL-ALIGN: bottom">制单人：</TD>
          <TD 
          style="BORDER-BOTTOM: #000000 2px solid; WIDTH: 90px; HEIGHT: 30px; VERTICAL-ALIGN: bottom">
              <asp:Label ID="order_user" runat="server" Text=""></asp:Label>
            </TD>
          <TD style="PADDING-LEFT: 10px; VERTICAL-ALIGN: bottom">审核人：</TD>
          <TD 
          style="BORDER-BOTTOM: #000000 2px solid; WIDTH: 90px; HEIGHT: 30px; VERTICAL-ALIGN: bottom">
              <asp:Label ID="auditing_user" runat="server" Text=""></asp:Label>
            </TD>
          <TD style="PADDING-LEFT: 10px; VERTICAL-ALIGN: bottom">供应商签字（盖章）：</TD>
          <TD 
          style="BORDER-BOTTOM: #000000 2px solid; WIDTH: 110px; HEIGHT: 30px; VERTICAL-ALIGN: bottom">&nbsp;</TD>
          <TD></TD>
          <TD></TD></TR></TBODY></TABLE></TD></TR></TBODY></T
    </div>
    </form>
</body>
</html>