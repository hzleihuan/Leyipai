﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manager_OutStockOrder.aspx.cs" Inherits="Stock_Manager_OutStockOrder" %>
<%@ Register Assembly="Components" Namespace="Controls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>管理库存出库单</title>
        <link href="../css/base.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../css/flexigrid.css"/>
   	<script type="text/javascript" src="../js/jq.js"></script>
	<script type="text/javascript" src="../js/AjaxJS.js"></script>
	<script type="text/javascript" src="../js/flexigrid.js"></script>
	


	
	
      <style type="text/css">
    #addMian_b {width:980px;height:450px;background:#000;-moz-opacity:0.2; filter:alpha(opacity=25);margin:-30px 10 0 10px; position:absolute;}
#addMian_t { z-index:20;border:1px solid #a4d5e3;width:960px;height:450px;background:#FFF;margin:-15px 0 0 5px; position:absolute;}
body {
	margin-left: 10px;
	margin-top: 0px;
}
    
    </style>
    
  <script type="text/javascript">
    
    function shenheSubmit(action)
    {
     var str="";
     var j=0;
      var obj=document.getElementsByName("selOrder");
     var k=obj.length;
     if(k == 1)
     {
      
       if(obj[0].checked==true)
         str=obj[0].value;
     }else
     {
      for( i=0;i<document.all.selOrder.length;i++)
         {
            if(document.all.selOrder[i].checked)
            {
              if( 0==j)
             {
              str=document.all.selOrder[i].value
             }else
             {
              str=str+"#"+document.all.selOrder[i].value;
             }
             j++;
           } 
            document.all.selOrder[i].checked = false;      
         }
     }
        if(str=="")
        {
          
          alert("请选择要操作的选项");
          return false;
        }
        else
        {
          // window.location.replace("Manager_AuditingBuyOrder.aspx?AuditingId="+encodeURIComponent(str)) ;
           window.location.href("Manager_AuditingOutStockOrder.aspx?action="+action+"&AuditingId="+encodeURIComponent(str)) ;
        }
     
    }
    
    function newAdd()
    {
       window.location.href("OutStock_Add.aspx");
    }
    </script>
</head>
<body>
    <table style="width: 97%">
        <tr>
            <td align="left" style="width: 810px; height: 20px">
                <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
            </td>
        </tr>
    </table>
    <br />

  <table width="100%" border="0">
    <tr>
      <td style="width: 334px"></td>
      <td style="height: 21px">
          &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;<input type="button"  name="shenhe" value="审核出库" id="Submit1" onclick="javascript:if(!confirm('您确定要操作吗'))return  false;shenheSubmit('shenhe')" style="width: 81px" /> &nbsp; &nbsp; &nbsp; &nbsp;
          <input type="button"  name="shenhe" value="删除单据" id="Button1" onclick="javascript:if(!confirm('您确定要删除吗'))return  false;shenheSubmit('delete')" style="width: 89px" />
          &nbsp;&nbsp;
          <input type="button"  name="shenhe" value="新添出库单" id="Button2" onclick="newAdd()" style="width: 103px" />
      </td>
    </tr>
  </table>

    <form id="form2" runat="server" >
    <div align="center" >
    <DIV class=bar>
  <table width="900" border="0">
    <tr>
     <td style="width: 175px">出库编号：<asp:TextBox ID="OutID" runat="server" Width="105px"></asp:TextBox></td>
     <td style="width: 129px">
     从:
         <asp:TextBox ID="baginData" runat="server" Width="83px"></asp:TextBox>
          <img src="../images/calendar.gif" onclick="fPopUpCalendarDlg(baginData);return false;" /> </td>
      <td style="width: 138px"> 
      至:
          <asp:TextBox ID="endData" runat="server" Width="92px"></asp:TextBox>
          <img src="../images/calendar.gif" onClick="fPopUpCalendarDlg(endData);return false;" />
      </td>
      <td style="width: 133px">
          状态：
          &nbsp;&nbsp;
          <asp:DropDownList ID="side" runat="server" Width="58px">
              <asp:ListItem Value="0">全部</asp:ListItem>
              <asp:ListItem Value="1">未审</asp:ListItem>
              <asp:ListItem Value="2">已审</asp:ListItem>
          </asp:DropDownList></td>
      <td style="width: 228px" align="left">
          &nbsp; &nbsp; &nbsp;<asp:Button ID="Select" runat="server"
              Text="查询" OnClick="Select_Click" />
          &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
          &nbsp;&nbsp;</td>
    </tr>
  </table>
</DIV>
<table style="width:97%;" >

<tr>
<td align="center" class="title" style="width: 810px; height: 38px;">
    库存出库单
</td>
</tr>
</table><table style="width:97%;" >
    <tr>
        <td align="center" style="width: 950px; height: 38px;">

    <table width="800"  class="flexme2">
	<thead>
    		<tr>
            	<th width="35">选择</th>
            
            	<th width="150">订单号</th>
            	<th width="100">
                    入库类型</th>
            	<th width="200">
                    库区</th>
            	
            	<th width="100">制单人</th>
   
                <th width="100">日期</th>
                <th width="100">合计金额
                    </th>
    		    <th width="50">状态</th>
    		    <th width="30"></th>
    		</tr>
    </thead>
    <tbody>
        <asp:Repeater ID="OrderList" runat="server">
        <ItemTemplate>
           <tr>
            	<td><input type="checkbox" name="selOrder" value="<%#Eval("OutID")%>" />
            	
            	</td>
            	<td>
            	<a target="_blank" href="OutStock_Detail.aspx?OutID=<%#Eval("OutID")%>"><%#Eval("OutID")%></a>
            	
            	</td>
            
            	<td><%#changString0(Eval("OutType").ToString())%></td>
            	<td><%#Eval("HouseName")%>--><%#Eval("SubareaName")%></td>
                <td><%#Eval("RealName")%></td>
                	<td><%#Eval("CreateDate")%> </td>
                	<td><%#Eval("TotalPrice").ToString()%></td>
    		    <td><%# changString(Eval("State").ToString())%></td>
    		     <td></td>
    		</tr>
        
        </ItemTemplate>
        </asp:Repeater>
      
    		
    </tbody>
</table>
        </td>
    </tr>
</table>
    
    <br />
           <div class="pageLink" id="pageLink">
        <cc1:collectionpager id="CollectionPager1" runat="server" backnextlinkseparator=" "
            backtext="上一页" firsttext="第一页" labeltext="第" lasttext="最后一页" nexttext="下一页" pagenumbersseparator="-"
            pagesize="10" showfirstlast="true" showpagenumbers="true"></cc1:collectionpager>
            </div>
          
 <script type="text/javascript">



			$('.flexme2').flexigrid();
			///$('.flexme2').flexigrid({height:'auto',striped:false});


</script>
    
  
    </div>
    </form>
</body>
</html>

