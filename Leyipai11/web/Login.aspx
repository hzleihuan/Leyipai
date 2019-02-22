<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 4.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>系统登陆</title>
    
    	<link rel="stylesheet" type="text/css" href="css/Login.css"/>

	<SCRIPT src="js/jquery.js" type=text/javascript></SCRIPT>
    <SCRIPT src="js/jquery-cookieplug.js" type=text/javascript></SCRIPT>
  <STYLE type=text/css>TABLE {
	FONT-SIZE: 12px; COLOR: #333333; LINE-HEIGHT: 150%; FONT-FAMILY: "宋体"
}
BODY {
	MARGIN: 0px
}
</STYLE>
</head>
<body leftMargin=0 background=images/bg.gif topMargin=0>
    <form id="form1" runat="server">

<DIV align=center>

<TABLE cellSpacing=0 cellPadding=0 width=913 border=0>
  <TBODY>
  <TR>
    <TD width=461 style="height: 465px" valign="top">
      <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0>
        <TBODY>
        <TR>
          <TD>
            <DIV align=left><IMG height=80 src="images/log_mykd_n.gif" 
            width=212></DIV></TD></TR>
        <TR>
          <TD><IMG height=110 src="images/ren1_n.gif" 
        width=461></TD></TR>
        <TR>
          <TD><IMG height=230 src="images/ren2.jpg" 
        width=461></TD></TR></TBODY></TABLE></TD>
    <TD vAlign=top style="height: 465px">
      <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0>
        <TBODY>
        <TR>
          <TD vAlign=bottom height=190><IMG height=32 
            src="images/pic_text.gif" width=381></TD></TR></TBODY></TABLE>
      <TABLE  cellSpacing=0 cellPadding=0 width="100%"  border=0>
        <TBODY>
        <TR>
          <TD vAlign=top background=images/con1.gif>
            <TABLE style="MARGIN-TOP: 37px; MARGIN-LEFT: 8px" cellSpacing=0 
            cellPadding=0 width="100%" border=0>
              <TBODY>
              <TR>
                <TD><IMG height=34 src="images/pic_text_login.gif" 
                  width=253></TD></TR>
              <TR>
                <TD>
                  <TABLE style="MARGIN-TOP: 10px; width: 379px;" cellSpacing=0 cellPadding=0 border=0>
                    <TBODY>
                    <TR>
                      <TD noWrap style="width: 38px">
                          用户：</TD>
                      <TD style="width: 155px"><LABEL>
                          <asp:TextBox ID="UserName" runat="server"  Width="101px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                              ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName" ErrorMessage='<img src="images/false.gif">'></asp:RequiredFieldValidator></LABEL></TD></TR>
                    <TR style="PADDING-TOP: 5px">
                      <TD style="width: 38px">
                          密码：</TD>
                      <TD style="width: 155px"><LABEL>
                          <asp:TextBox ID="PassWord" runat="server" Text="123" TextMode="Password" Width="101px"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PassWord"
                              ErrorMessage='<img src="images/false.gif">'></asp:RequiredFieldValidator></LABEL></TD></TR>
                    <TR style="PADDING-TOP: 5px">
                      <TD style="width: 38px">&nbsp;</TD>
                      <TD style="width: 155px">
                        <TABLE cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TBODY>
                          <TR>
                            <TD>
                              <DIV align=left>
                                  &nbsp;<asp:ImageButton ID="LoginButton" runat="server" ImageUrl="images/but1.gif"
                                      OnClick="LoginButton_Click" /></DIV></TD></TR>
                          <TR>
                            <TD>
                              <DIV align=left><IMG height=18 
                              src="images/but1_y.gif" 
                            width=83></DIV></TD></TR>
                          <TR>
                            <TD>
                              </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD>
          <TD width=22><IMG height=229 src="images/con2.gif" 
            width=22></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
<TABLE cellSpacing=0 cellPadding=0 width=913 align=center border=0>
  <TBODY>
  <TR>
    <TD style="PADDING-BOTTOM: 10px" vAlign=bottom height=180>
      <DIV align=center><FONT color=#999999>深圳乐易拍版权所有 2008-2009<BR>请使用IE6.0 
SP1以上浏览器，最佳显示分辨率1024×768</FONT></DIV></TD></TR></TBODY></TABLE>




</DIV>
  
    </form>



</body>
</html>

