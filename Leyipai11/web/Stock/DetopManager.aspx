﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetopManager.aspx.cs" Inherits="Stock_DetopManager" %>
<%@ Register Assembly="Components" Namespace="Controls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>仓库库位信息维护</title>
 <style type="text/css">
    body,td,th {
	font-size: 12px;
}
    
    </style>
        <style type="text/css">
<!--

.lbg2 {
	BACKGROUND-IMAGE: url(../images/line.gif); BACKGROUND-REPEAT: repeat-x
}
.mc {
	PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 0px; WORD-BREAK: break-all; LINE-HEIGHT: 20px; PADDING-TOP: 0px
}
.t3 {
	FONT-WEIGHT: bolder; FONT-SIZE: 12px; MARGIN-LEFT: 15px; COLOR: #003473; margin-down: -20px
}
.mc1 {	PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 0px; WORD-BREAK: break-all; LINE-HEIGHT: 20px; PADDING-TOP: 0px
}
-->
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
        </asp:SiteMapPath>
        <br />
        <table style="width: 862px; height: 193px">
            <tr>
                <td style="width: 32px; height: 105px">
                </td>
                <td style="width: 498px; height: 105px">
                    &nbsp;<asp:Label ID="Pageaction" runat="server" Text="view" Visible="False"></asp:Label>&nbsp;&nbsp;
                    <asp:Label ID="editID" runat="server" Visible="False"></asp:Label>
                    &nbsp;
                    <asp:Panel ID="Panel1" runat="server" Width="125px">
                        <br />
                    <div style="border-right: #a4d5e3 1px solid; border-top: #a4d5e3 1px solid; background: url(../images/content_bg1.gif) repeat-x 50% bottom;
                        float: left; margin-bottom: 8px; border-left: #a4d5e3 1px solid; width: 777px;
                        border-bottom: #a4d5e3 1px solid;">
                        <h2 style="padding-right: 0px; padding-left: 8px; font-size: 14px; background: #e2f3fa;
                            padding-bottom: 0px; margin: 0px; color: #0066a9; line-height: 24px; padding-top: 0px;
                            border-bottom: #a4d5e3 1px solid">
                            库区添加/修改</h2>
                        <div style="margin: 5px">
                            <table style="width: 705px; height: 46px">
                                <tr>
                                    <td style="width: 13%; height: 45px">
                                        库房</td>
                                    <td style="width: 21%; height: 45px">
                                        <asp:DropDownList ID="StoreHouseDropDownList" runat="server">
                                        </asp:DropDownList></td>
                                    <td style="width: 16%; height: 45px">
                                        库区名称</td>
                                    <td style="width: 41%; height: 45px">
                                        &nbsp;<asp:TextBox ID="SubareaName" runat="server" Width="103px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="SubareaName"
                                            ErrorMessage="<img src=../images/false.gif  />不能为空"></asp:RequiredFieldValidator></td>
                                    <td style="width: 13%; height: 45px">
                                        &nbsp;状态</td>
                                    <td style="height: 45px; width: 45px;">
                                        &nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
                                            <asp:ListItem Value="Y">正常</asp:ListItem>
                                            <asp:ListItem Value="N">停用</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                    </td>
                                    <td style="width: 36%; height: 45px">
                                        &nbsp;<asp:Button ID="updateButton" runat="server" OnClick="updateButton_Click" Text="新  添"
                                            Width="87px" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 13%; height: 45px">
                                    </td>
                                    <td style="width: 21%; height: 45px">
                                        描述：</td>
                                    <td colspan="5" style="height: 45px">
                                        <asp:TextBox ID="Description" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                        <br />
                    <table bgcolor="#9bc8ff" border="0" cellpadding="0" cellspacing="1" style="width: 775px; height: 199px;">
                        <tbody>
                            <tr>
                                <td bgcolor="#f7fdff" style=" height: 244px;">
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td class="lbg2" height="27" width="354">
                                                    <span class="t3">库区列表 注：状态 Y为正在使用 N为停止使用</span></td>
                                                <td class="lbg2" style="width: 23px">
                                                    <img border="0" height="17" src="../images/bot2.gif" width="17" /></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 772px; height: 182px;">
                                        <tr>
                                            <td class="mc" height="202" valign="top" align="center">
                                                &nbsp;
                                                <table border="0" style="width: 631px; height: 18px;">
                                                    <tr>
                                                        <td style="width: 111px; height: 35px">
                                                            库房</td>
                                                        <td style="width: 424px; height: 35px">
                                                            库区</td>
                                                        <td style="width: 167px; height: 35px">
                                                            状态</td>
                                                              <td style="width: 167px; height: 35px">
                                                            编辑</td>
                                                            <td style="width: 167px; height: 35px">
                                                            删除</td>
                                                    </tr>
                                                    <asp:Repeater ID="listType" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                  <%# Eval("HouseName")%></td>
                                                                <td>
                                                                    <%# Eval("SubareaName")%>
                                                                </td>
                                                                <td>
                                                                    <%# Eval("State")%>
                                                                </td>
                                                                  <td>
                                                                <a href="DetopManager.aspx?action=edit&ID=<%# Eval("ID")%>" > <img src=  "../images/Edit.gif"  border="0" alt="点击编辑"/></a>
                                                                </td>
                                                                
                                                                 <td>
                                                                  <a href="DetopManager.aspx?action=del&ID=<%# Eval("ID")%>" >  <img  alt="" border="0"  src="../images/Delete.gif" /> </a>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </table>
                                                <cc1:collectionpager id="CollectionPager1" runat="server" backnextlinkseparator=" "
                                                    backtext="上一页" firsttext="第一页" labeltext="第" lasttext="最后一页" nexttext="下一页" pagenumbersseparator="-"
                                                    pagesize="15" showfirstlast="true" showpagenumbers="true"></cc1:collectionpager>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                        <br />
                        <br />
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="width: 32px">
                </td>
                <td style="width: 498px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 32px; height: 18px;">
                </td>
                <td style="width: 498px; height: 18px;" align="center">
                    <asp:HyperLink ID="HyperLink1" runat="server" Visible="False" NavigateUrl="~/Stock/DetopManager.aspx">操作成功！返回列表</asp:HyperLink></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

