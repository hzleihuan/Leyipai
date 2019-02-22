<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MySet.aspx.cs" Inherits="Admin_sys_MySet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
      <link rel="stylesheet" type="text/css" media="all" href="../js/ext/resources/css/ext-all.css" />
	<script type="text/javascript" src="../js/ext/adapter/ext/ext-base.js"></script>
	<script type="text/javascript" src="../js/ext/ext-all.js"></script>	
	<script type="text/javascript" src="../js/ext/ext-lang-zh_CN.js"></script>
    <script type="text/javascript" src="../js/base.js"></script>
    <script type="text/javascript" src="../js/sys/MySet.js"></script>
    <link rel="stylesheet" type="text/css" media="all" href="../css/ext-common.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="tabs1"  style="margin-left:50px; margin-top:20px; width:80%;">
        <div id="resetPw" style="margin-left:10px; margin-top:10px;height:200px" >
           
            <label  style="width:100px;" >&nbsp;&nbsp;&nbsp;原密码：</label> <input  type="password" name="oldPw" id="oldPw" /> <br />
             <br />
            <label   style="width:100px;" >&nbsp;&nbsp;&nbsp;新密码：</label> <input type="password" name="newPw" id="newPw" /><br />
             <br />
            <label   style="width:100px;" >确认密码：</label> <input type="password" name="newPw_c" id="newPw_c" /><br />
            <br />
            <input type="button"  value=" 提 交 " id="resetPwBt" />
              </div>
        <div id="test1" class="x-hide-display">
           test        </div>
    </div>
    </form>
</body>
</html>