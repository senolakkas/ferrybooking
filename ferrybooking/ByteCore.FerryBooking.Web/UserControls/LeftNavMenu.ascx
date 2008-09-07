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
        <tr>
            <td width="3">
                <img src="../Images/LeftMenuItem.jpg" height="20" width="5"></td>
            <td nowrap="nowrap">
                <asp:HyperLink ID="HyperLink1" CssClass="LeftMenuItem" runat="server" 
                    NavigateUrl="~/Admin/frmVessel.aspx">Vessel</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td width="3">
                <img src="../Images/LeftMenuItem.jpg" height="20" width="5"></td>
            <td nowrap="nowrap">
                <asp:HyperLink ID="HyperLink6" CssClass="LeftMenuItem" runat="server" 
                    NavigateUrl="~/Admin/frmRoute.aspx">Route</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td width="3">
                <img src="../Images/LeftMenuItem.jpg" height="20" width="5"></td>
            <td nowrap="nowrap">
                <asp:HyperLink ID="HyperLink2" CssClass="LeftMenuItem" runat="server" 
                    NavigateUrl="~/Admin/frmFare.aspx">Fare</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td width="3">
                <img src="../Images/LeftMenuItem.jpg" height="20" width="5"></td>
            <td nowrap="nowrap">
                <asp:HyperLink ID="HyperLink3" CssClass="LeftMenuItem" runat="server" 
                    NavigateUrl="~/Admin/frmSchedule.aspx">Schedule</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td width="3">
                <img src="../Images/LeftMenuItem.jpg" height="20" width="5"></td>
            <td nowrap="nowrap">
                <asp:HyperLink ID="HyperLink4" CssClass="LeftMenuItem" runat="server" 
                    NavigateUrl="~/Admin/frmBooking.aspx">Booking</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td width="3">
                <img src="../Images/LeftMenuItem.jpg" height="20" width="5"></td>
            <td nowrap="nowrap">
                <asp:HyperLink ID="HyperLink5" CssClass="LeftMenuItem" runat="server" 
                    NavigateUrl="~/Admin/frmImportDumpFile.aspx">Import DumpFile</asp:HyperLink>
            </td>
        </tr>
    </tbody>
</table>
<p>&nbsp;</p>
<p></p>

