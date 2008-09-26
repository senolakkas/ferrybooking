<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true"
    CodeBehind="frmBookingDetails.aspx.cs" Inherits="ByteCore.FerryBooking.Web.frmBookingDetails"
    Title="Booking Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="4">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            Booking ID:
                        </td>
                        <td>
                            <asp:Label ID="lblBookingId" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Booking Date:
                        </td>
                        <td>
                            <asp:Label ID="lblBookingDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Total Amount:</td>
                        <td>
                            <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Comments:
                        </td>
                        <td>
                            <asp:TextBox ID="txtComments" runat="server" Height="57px" TextMode="MultiLine" Width="448px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Status:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStatus" runat="server" Width="169px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" CausesValidation="False" 
                                onclick="btnSave_Click" />
                        </td>
                        <td>
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                    <asp:Repeater ID="Rpt_PassengerList" runat="server" 
                        onitemdatabound="Rpt_PassengerList_ItemDataBound">
                        <ItemTemplate>
                            <table class="FormCellLabel" style="width: 100%;">
                                <tr class="FormTableHeader">
                                    <td colspan="8">
                                        <asp:Label ID="lblPassengerTitle" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr class="FormTable">
                                <td>
                                        Title: 
                                    </td>
                                    <td>
                                        &nbsp;<asp:Label ID="Label2" runat="server" Text='<%#Eval("Title2")%>'></asp:Label>
                                    </td>
                                    <td>
                                        First Name: 
                                    </td>
                                    <td>
                                        &nbsp;<asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FirstName2")%>'></asp:Label>
                                    </td>
                                    <td>
                                        Middle Name: 
                                    </td>
                                    <td>
                                        &nbsp;<asp:Label ID="Label3" runat="server" Text='<%#Eval("MiddleName2")%>'></asp:Label>
                                    </td>
                                    <td>
                                        Last Name: 
                                    </td>
                                     <td>
                                        &nbsp;<asp:Label ID="Label1" runat="server" Text='<%#Eval("LastName2")%>'></asp:Label>
                                    </td>
                                </tr>
                                <tr class="FormTable">
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                     <td>
                                        &nbsp;
                                    </td>
                                     <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                     <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:Repeater>
            </td>
        </tr>
        <tr>
            <td>
                    <asp:Repeater ID="Rpt_RouteList" runat="server" 
                        onitemdatabound="Rpt_RouteList_ItemDataBound">
                        <ItemTemplate>
                            <table class="FormCellLabel" style="width: 100%;">
                                <tr class="FormTableHeader">
                                    <td colspan="6">
                                        <asp:Label ID="lblRouteTitle" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr class="FormTable">
                                <td>
                                        Sailing Time: 
                                    </td>
                                    <td>
                                        &nbsp;<asp:Label ID="lblStartDate" runat="server" Text='<%#Eval("Schedule.SailingTime")%>'></asp:Label>
                                    </td>
                                    <td>
                                        Arrival Time: 
                                    </td>
                                    <td>
                                        &nbsp;<asp:Label ID="lblArrivalTime" runat="server" 
                                            Text='<%#Eval("Schedule.ArrivalTime")%>'></asp:Label>
                                    </td>
                                    <td>
                                        Vessel: 
                                    </td>
                                    <td>
                                        &nbsp;<asp:Label ID="lblVessel" runat="server" Text='<%#Eval("Schedule.Vessel.FullName")%>'></asp:Label>
                                    </td>
                                </tr>
                                <tr class="FormTable">
                                    <td>
                                        Departure Port: 
                                    </td>
                                     <td>
                                        &nbsp;<asp:Label ID="lblDepPort" runat="server" Text='<%#Eval("Schedule.Fare.Routes.DeparturePort.PortName")%>'></asp:Label>
                                    </td>
                                   <td>
                                        Arrival Port: 
                                    </td>
                                     <td>
                                        &nbsp;<asp:Label ID="lblArrPort" runat="server" Text='<%#Eval("Schedule.Fare.Routes.ArriavlPort.PortName")%>'></asp:Label>
                                    </td>
                                     <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:Repeater>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
