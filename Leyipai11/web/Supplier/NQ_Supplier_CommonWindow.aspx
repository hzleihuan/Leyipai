﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NQ_Supplier_CommonWindow.aspx.cs" Inherits="Supplier_NQ_Supplier_CommonWindow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
   <iframe name="CommonFrm" frameborder="0" style="width:100%; height:600px;" id="CommonFrm" src='<asp:Literal ID="SubFrmSrc" runat="server"></asp:Literal>'></iframe>
    </form>
</body>
</html>
