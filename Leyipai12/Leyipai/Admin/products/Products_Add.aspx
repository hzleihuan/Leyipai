<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Products_Add.aspx.cs" Inherits="Admin_products_Products_Add" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <link rel="stylesheet" type="text/css" media="all" href="../js/ext/resources/css/ext-all.css" />
	<script type="text/javascript" src="../js/ext/adapter/ext/ext-base.js"></script>
	<script type="text/javascript" src="../js/ext/ext-all.js"></script>	
	<script type="text/javascript" src="../js/ext/ext-lang-zh_CN.js"></script>
    <script type="text/javascript" src="../js/base.js"></script>

    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../js/jquery.tools.min.js" type="text/javascript"></script>
    <script src="../js/products/Products_Add.js" type="text/javascript"></script>
    <title></title>
   
    <style type="text/css">
        .style1
        {
            width: 37%;
        }
        .style2
        {
            background-color: #F3F8F7;
            color: #73938E;
            font-weight: bold;
            line-height: 30px;
            text-align: right;
            width: 12%;
        }
        .style3
        {
            background-color: #fff;
            color: #73938E;
            font-weight: bold;
            line-height: 30px;
            text-align: right;
            width: 12%;
        }
        .style4
        {
            background-color: #F3F8F7;
            color: #73938E;
            font-weight: bold;
            line-height: 30px;
            text-align: right;
            width: 13%;
        }
        .style5
        {
            background-color: #fff;
            color: #73938E;
            font-weight: bold;
            line-height: 30px;
            text-align: right;
            width: 13%;
        }
        .style6
        {
            width: 16px;
            height: 15px;
        }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">

    <asp:Panel ID="Panel1" runat="server">
    
    <div>

        &nbsp;
        <div style=" margin-top:5px; margin-left:50px">
        <asp:Button ID="Button2" runat="server" Text="保存" Width="107px" 
            onclick="Button2_Click" Height="29px" />
            </div>

        <br />
<ul class="tabs">
	<li><a href="#">基本信息 </a></li>
	<li><a href="#">图片信息</a></li>
	<li><a href="#">商品描述</a></li>
</ul>

<!-- tab "panes" -->
<div class="panes">
	<div style="height:320px">
    
                         <div id="man_zone">
  <table width="99%" border="0" align="center"  cellpadding="3" cellspacing="1" class="table_style">
    <tr>
      <td class="style4">
          商品名称</td>
      <td class="style1">
           <input id="Product_ID"  runat="server" type="hidden" /> 
          <asp:TextBox ID="Product_Name" runat="server" CssClass="textinp"></asp:TextBox>
          <asp:RequiredFieldValidator ID="Product_NameRequired" runat="server" ControlToValidate="Product_Name" 
                              ErrorMessage="必须填写“商品名称”。" 
              ToolTip="必须填写“商品名称”。" ForeColor="#FF3300" 
                             >必须填写</asp:RequiredFieldValidator>
        </td>
      <td class="style2">成本价</td>
      <td width="82%">
          <asp:TextBox ID="Cost_price" runat="server"  CssClass="textinp"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Cost_price" 
                             CssClass="failureNotification" ErrorMessage="必须填写“成本价”。" 
              ToolTip="必须填写“成本价”。" ForeColor="Red" 
                             >必须填写</asp:RequiredFieldValidator>
          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
              ErrorMessage="应该输入数字" 
              ValidationExpression="^[0-9]+(.[0-9]{0,3})?$"  
              ControlToValidate="Cost_price" ForeColor="#FF3300"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
      <td class="style5">
          商品类型</td>
      <td class="style1">
          <input id="Type_ID"  runat="server" type="hidden" /> 
          <asp:TextBox ID="Type_text"   runat="server" CssClass="textinp" ></asp:TextBox>
         <a href="#"  onclick="selectTypeAction()" ><img alt="选择类型" id="selectProductType" class="style6" src="../images/tbtn_f7.gif" /></a>
         </td>
      <td class="style3">
          批发价</td>
      <td>
          <asp:TextBox ID="Wholesale_price" CssClass="textinp" runat="server"></asp:TextBox>
        &nbsp;不填默认是成本的110%<asp:RegularExpressionValidator 
              ID="RegularExpressionValidator2" runat="server" 
              ErrorMessage="应该输入数字" 
              ValidationExpression="^[0-9]+(.[0-9]{0,3})?$"  
              ControlToValidate="Wholesale_price" ForeColor="#FF3300"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
      <td class="style4">商品品牌</td>
      <td class="style1">
         
          <asp:DropDownList ID="Brand_ID" CssClass="textinp" runat="server" 
              DataTextField="brand_name" 
              DataValueField="brand_id"  >
          </asp:DropDownList>
     
        </td>
      <td class="style2">零售价</td>
      <td>
          <asp:TextBox ID="Retail_Price" CssClass="textinp" runat="server"></asp:TextBox>
          不填默认是成本的120%<br />
          <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
              ErrorMessage="应该输入数字" 
              ValidationExpression="^[0-9]+(.[0-9]{0,3})?$"  
              ControlToValidate="Retail_Price" ForeColor="#FF3300"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
      <td class="style5">
         计量单位</td>
      <td class="style1">
          <asp:TextBox ID="units" CssClass="textinp" runat="server"></asp:TextBox>
        </td>
      <td class="style3">库存上限</td>
      <td>
          <asp:TextBox ID="UpperLimit" CssClass="textinp" runat="server">10000</asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="UpperLimit" 
                              ErrorMessage="必须填写“库存上限”。" 
              ToolTip="必须填写“库存上限”。" ForeColor="#FF3300" 
                             >必须填写</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
      <td class="style4">
          重量（kg）</td>
      <td class="style1">
          <asp:TextBox ID="Weight" CssClass="textinp" runat="server"></asp:TextBox>
        </td>
      <td class="style2">库存下限</td>
      <td>
          <asp:TextBox ID="LowerLimit" CssClass="textinp" runat="server">0</asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="LowerLimit" 
                              ErrorMessage="必须填写“库存下限”。" 
              ToolTip="必须填写“库存下限”。" ForeColor="#FF3300" 
                             >必须填写</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
      <td class="style5">
         材质</td>
      <td class="style1">
          <asp:TextBox ID="Material" CssClass="textinp" runat="server"></asp:TextBox>
        </td>
      <td class="style3">商品条码</td>
      <td>
          <asp:TextBox ID="code" CssClass="textinp" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
      <td class="style4">
          规格</td>
      <td class="style1">
          <asp:TextBox ID="Spec" CssClass="textinp" runat="server"></asp:TextBox>
        </td>
      <td class="style2">有效日期</td>
      <td>
          <asp:TextBox ID="Expiry_date" CssClass="textinp"  runat="server"></asp:TextBox>
          
          <img alt="选择类型" id="selectProductType0" class="style6" 
              src="../images/tbtn_f7.gif" />
         
        </td>
    </tr>
    </table>
</div>
    </div>
	<div style="height:320px">
    <br />
    <br />

        <div style=" margin-left:90px; margin-top:25px;">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:FileUpload ID="prc_FileUpload" runat="server" />
&nbsp;
        <asp:Button ID="Button1" runat="server" Text="上传文件" onclick="Button1_Click" />
        </div>

        <input id="product_pic" type="hidden" runat="server" />

         <br />
        <div style=" margin-left:90px;"> 本次上传生成缩略图一张和原图一张</div>
    </div>
	<div style="height:320px">
       
       &nbsp; &nbsp; &nbsp; 
       
       <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="950px" ></CE:Editor>
      
    </div>
</div>
    </div>

    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server">

        <asp:Label ID="msg" runat="server" ForeColor="Red"></asp:Label>  
    </asp:Panel>

    </form>
</body>
</html>
