<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftNavMenu.ascx.cs" Inherits="controls_LeftNavMenu" %>
<table align="right" border="0" cellpadding="0" cellspacing="8" width="180">
    <tbody>
        <tr>
            <td colspan="2" height="6">
                <img src="../Images/spacer.gif" height="6" width="12"></td>
        </tr>
        <tr>
            <td width="3">
                <img src="../Images/LeftMenuItem.jpg" height="20" width="5"></td>
            <td nowrap="nowrap">
                <asp:HyperLink ID="hlOperator" CssClass="LeftMenuItem" runat="server" 
                    NavigateUrl="~/Admin/frmCompany.aspx">Operator</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td width="3">
                <img src="../Images/LeftMenuItem.jpg" height="20" width="5"></td>
            <td nowrap="nowrap">
                <asp:HyperLink ID="hlPort" CssClass="LeftMenuItem" runat="server" 
                    NavigateUrl="~/Admin/frmPort.aspx">Port</asp:HyperLink>
            </td>
        </tr>
    </tbody>
</table>
<p>&nbsp;</p>
<p></p>

