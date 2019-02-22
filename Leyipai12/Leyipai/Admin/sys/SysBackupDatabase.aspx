<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SysBackupDatabase.aspx.cs" Inherits="Admin_sys_SysBackupDatabase" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link rel="stylesheet" href="../css/common.css" type="text/css" />
<title>管理区域</title>
</head>

<body>
<form id="form2" runat="server">
<div id="man_zone">

 <div id="ctn" style="position:relative; margin-top:50px; margin-left:100px; width:50%; height:40px;" >
    <asp:Button ID="inalSettlement" runat="server" Text="备份数据库" Height="31px" 
         Width="144px" onclick="inalSettlement_Click" 
         />
     <br />
    
    </div>


    <div id="d1" style="position:relative; margin-top:50px; margin-left:100px; width:50%; height:40px;" >
    <p>已经备份的数据还原点列表：<asp:DropDownList ID="DropDownList1" runat="server">
         </asp:DropDownList></p>
    
    </div>
     <div id="Div1" style="position:relative; margin-top:50px; margin-left:100px; width:50%; height:100px;" >
    &nbsp;<asp:Button ID="Button1" runat="server" Text="数据库还原" Height="31px" 
         Width="144px" onclick="Button1_Click" 
         />
     <br />
    
    </div>


</div>
 </form>
</body>
</html>
