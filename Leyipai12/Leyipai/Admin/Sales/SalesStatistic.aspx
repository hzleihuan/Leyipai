<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesStatistic.aspx.cs" Inherits="Admin_Sales_SalesStatistic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>销售统计</title>
    
    <style type="text/css">
	<!--
	body,td,th {
	font-size: 14px;
}
	STRONG {
	PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; PADDING-TOP: 0px
		}
		H2 {
	FONT-SIZE: 14px
}
		#column {
		WIDTH: 680px;  margin:auto;
		}
		.module_wrap {
	        BORDER-BOTTOM: #bfe6f4 1px solid; BORDER-LEFT: #bfe6f4 1px solid; BORDER-TOP: #bfe6f4 1px solid; BORDER-RIGHT: #bfe6f4 1px solid
		}
		.module_wrap .wrap {
			BACKGROUND: #fff
		}
		.module_wrap H2 {
			POSITION: relative; LINE-HEIGHT: 30px; PADDING-LEFT: 10px; BACKGROUND: url(../images/module_wrap_h2_bg.gif) repeat-x; HEIGHT: 31px; COLOR: #333; margin-top:0px;
		}
		
		.wrap_space {
	PADDING-BOTTOM: 10px; PADDING-LEFT: 10px; PADDING-RIGHT: 10px; PADDING-TOP: 10px
}
-->

	</style>
</head>
<body>
    <form id="form1" runat="server">
  <div id="column" align="center">
<br/>


<DIV class=module_wrap>
<H2><STRONG>销售统计</STRONG> </H2>
<DIV class="wrap wrap_space">
  
  

  <table width="200" border="0">
    <tr>
      <td><a href="SalesReport_Report_Product.aspx" ><img src="../images/sales_ss02.png"  border="0" /></a></td>
      <td><a href="SalesReport_Report_Customer.aspx"><img src="../images/sales_ss01.png" border="0" /></a></td>
    </tr>
  </table>
  
  </DIV></DIV>




	
	
<br/>
</div>
    </form>
</body>
</html>
