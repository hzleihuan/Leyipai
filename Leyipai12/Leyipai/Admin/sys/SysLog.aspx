<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SysLog.aspx.cs" Inherits="Admin_sys_SysLog" %>

<%@ Register assembly="Leyipai.Common" namespace="Leyipai.Common" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/sorter.css" rel="stylesheet" type="text/css" />
    <script src="../js/sorter.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <div id="wrapper">
    <table cellpadding="0" cellspacing="0" border="0" class="sortable" id="sorter">
		<tr>
			<th class="nosort">ID</th>
			<th>操作用户</th>
			<th>操作时间</th>
			<th>相关信息</th>
		</tr>
         <asp:Repeater ID="OrderList" runat="server">
        <ItemTemplate>
         <tr>
			<td><%#Eval("id")%></td>
			<td><%#Eval("log_username")%></td>
			<td><%#Eval("log_time")%></td>
			<td><%#Eval("log_info")%></td>
		</tr>
        
        </ItemTemplate>
        </asp:Repeater>
      
		
        	</table>
    </div>
<br />
<div style="margin:auto;" align="center">
<cc1:collectionpager id="CollectionPager1" runat="server" backnextlinkseparator=" "
            backtext="上一页" firsttext="第一页" labeltext="第" lasttext="最后一页" nexttext="下一页" pagenumbersseparator="-"
            pagesize="15" showfirstlast="true" showpagenumbers="true">
        </cc1:collectionpager>

</div>

<script type="text/javascript">
    var sorter = new table.sorter("sorter");
    sorter.init("sorter", 1);
</script>
         
    </div>
    </form>
</body>
</html>