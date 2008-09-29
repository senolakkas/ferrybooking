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
                            Total Amount:
                        </td>
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
                            <asp:Button ID="btnSave" runat="server" Text="Save" CausesValidation="False" OnClick="btnSave_Click" />
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
            </td>
        </tr>
        <tr>
            <td>
                <asp:Repeater ID="Rpt_RouteList" runat="server" OnItemDataBound="Rpt_RouteList_ItemDataBound">
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
                                    &nbsp;<asp:Label ID="lblArrivalTime" runat="server" Text='<%#Eval("Schedule.ArrivalTime")%>'></asp:Label>
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
                            <tr class="FormTable">
                                <td>
                                    Passengers:
                                </td>
                                <td colspan="5">
                                    <asp:Repeater ID="Rpt_PassengerList" runat="server" OnItemDataBound="Rpt_PassengerList_ItemDataBound">
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
                                                        Gender:
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("Gender2")%>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        Nationalship:
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label7" runat="server" Text='<%#Eval("Citizenship2")%>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        Date of Birth:
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("Brithday2")%>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr class="FormTable">
                                                    <td colspan="6">
                                                        <asp:Panel ID="pnlPassengerAdditionalInfo" runat="server">
                                                        <table class="FormCellLabel" style="width: 100%;">
                                                        <tr class="FormTable">
                                                    <td>
                                                        Address:
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label9" runat="server" Text='<%#Eval("Address3")%>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        City:
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("City2")%>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        State:
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label11" runat="server" Text='<%#Eval("Province2")%>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        Country
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label15" runat="server" Text='<%#Eval("Province2")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="FormTable">
                                                    <td>
                                                        PostalCode:
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label12" runat="server" Text='<%#Eval("Postcode2")%>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        Telephone:
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label13" runat="server" Text='<%#Eval("Telephone2")%>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        Email:
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label14" runat="server" Text='<%#Eval("Email2")%>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        Fax:
                                                    </td>
                                                    <td>
                                                         <asp:Label ID="Label16" runat="server" Text='<%#Eval("Fax2")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="FormTable">
                                                <td>
                                                        Additional requirement:
                                                    </td>
                                                    <td colspan="5">
                                                        <asp:Label ID="Label17" runat="server" Text='<%#Eval("Fax2")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                        </table>
                                                        </asp:Panel> 
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Vehicles:
                                </td>
                                <td colspan="5">
                                    <asp:Repeater ID="Rpt_VehicleList" runat="server" OnItemDataBound="Rpt_VehicleList_ItemDataBound">
                                        <ItemTemplate>
                                            <table class="FormCellLabel" style="width: 100%;">
                                                <tr class="FormTableHeader">
                                                    <td colspan="8">
                                                        <asp:Label ID="lblVehicleTitle" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="FormTable">
                                                    <td>
                                                        Name:
                                                    </td>
                                                    <td>
                                                        &nbsp;<asp:Label ID="lblName" runat="server" Text='<%#Eval("RouteOrderDetail.FareType.FareTypeName")%>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        Length:
                                                    </td>
                                                    <td>
                                                        &nbsp;<asp:Label ID="lblLength" runat="server" Text='<%#Eval("Length")%>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        Height:
                                                    </td>
                                                    <td>
                                                        &nbsp;<asp:Label ID="lblHeight" runat="server" Text='<%#Eval("VAPSetting.VAPSettingName")%>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        Width:
                                                    </td>
                                                    <td>
                                                        &nbsp;<asp:Label ID="Label1" runat="server" Text='<%#Eval("VehVAPSetting.VAPSettingName")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="FormTable">
                                                    <td>
                                                        License Plate:
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("LicensePlate")%>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        Make Model:
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("MakeModel")%>'></asp:Label>
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
                            <tr class="FormTable">
                                <td>
                                    Cabin:
                                </td>
                                <td colspan="5">
                                    <asp:Label ID="lblCabinInfo" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Add-On:
                                </td>
                                <td colspan="5">
                                    <asp:Label ID="lblAddonInfo" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Total:
                                </td>
                                <td colspan="5">
                                    <asp:Label ID="lblRouteTotalAmount" runat="server" Text=""></asp:Label>
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
