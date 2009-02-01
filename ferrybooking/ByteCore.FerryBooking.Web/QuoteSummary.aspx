<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuoteSummary.aspx.cs" Inherits="ByteCore.FerryBooking.Web.QuoteSummary" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quote Summary</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table>
        <tr>
            <td>
                Total price of passenger shown below&nbsp;
                <asp:Label ID="lblTotalPrice" runat="server" Text=""></asp:Label>
                &nbsp;(incls any applicable taxes etc)
            </td>
        </tr>
        <tr>
            <td>
                <asp:ListView ID="lvSummary" runat="server" OnItemDataBound="lvSummary_ItemDataBound">
                    <LayoutTemplate>
                        <table>
                            <tr runat="server" id="itemPlaceholder" />
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <table cellpadding="0" cellspacing="0" class="style1">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblRouteTitle" runat="server" Text="Route 1 - Route Details"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Route Total :
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRouteTotal" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Route :
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRouteName" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Vessel :
                                        </td>
                                        <td>
                                            <asp:Label ID="lblVesselName" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Operator :
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCompanyName" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Image ID="imgCompany" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Departure Date/Time :
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDepartureDatetime" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Arrival Date/Time :
                                        </td>
                                        <td>
                                            <asp:Label ID="lblArrivalDatetime" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Passengers :
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPassenger" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Transport :
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTransport" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Accommodation :
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAccommodation" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                <asp:Button ID="btnContinue" runat="server" Text="Continue Booking" OnClick="btnContinue_Click" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
