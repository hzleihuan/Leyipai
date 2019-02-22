<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesReport_Report_ByProduct.aspx.cs" Inherits="Admin_Sales_SalesReport_Report_ByProduct" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>商品销售柱图统计</title>
</head>
<body  style="text-align:center">
    <form id="form1" runat="server">
    <div style="margin-left:50px">
    
    
    
    	  	<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0" 
			width="780" height="500" id="myNext">
			<param name="allowScriptAccess" value="always" />
			<param name="movie" value="../flash/Charts/ScrollColumn2D.swf"/>
			<param name="FlashVars" value="<%=dataXml %>" />
			<param name="quality" value="high" />
			<embed src="../flash/Charts/ScrollColumn2D.swf" FlashVars="<%=dataXml %>" 
			quality="high" width="780" 
			height="500" name="myNext"
			allowScriptAccess="always" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />
			</object>
    </div>
    </form>
</body>
</html>
