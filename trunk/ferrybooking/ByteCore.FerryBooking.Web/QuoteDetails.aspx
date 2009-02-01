<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuoteDetails.aspx.cs" Inherits="ByteCore.FerryBooking.Web.QuoteDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quote Details</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:ListView ID="lvSchedule" runat="server" OnItemDataBound="lvSchedule_ItemDataBound">
            <LayoutTemplate>
                <table>
                    <tr>
                        <td>
                            <b>Schedule:</b>
                        </td>
                    </tr>
                    <tr runat="server" id="itemPlaceholder" />
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="pnlRout" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Label ID="labRouteNo" runat="server"></asp:Label>
                                <asp:Label ID="labRouteName" runat="server"></asp:Label>
                                <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="true" Enabled="false"
                                    OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlDay" runat="server" AutoPostBack="true" Enabled="false"
                                    OnSelectedIndexChanged="ddlDay_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlTime" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTime_SelectedIndexChanged"
                                    Enabled="false">
                                </asp:DropDownList>
                                <asp:Label ID="labArrivalDate" runat="server"></asp:Label>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlYear" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlMonth" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlDay" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlTime" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <asp:ListView ID="lvPassenger" runat="server" OnItemDataBound="lvPassenger_ItemDataBound">
            <LayoutTemplate>
                <table>
                    <tr>
                        <td>
                            <b>Passenger Ages:</b>
                        </td>
                    </tr>
                    <tr runat="server" id="itemPlaceholder" />
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        Passenger
                        <asp:Label ID="labPassengerNo" runat="server"></asp:Label>
                        &nbsp;&nbsp;Age:
                        <asp:TextBox ID="txtPassengerAge" runat="server" Width="50"></asp:TextBox>
                        Please enter age <font color="red">at time of travel.</font>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <asp:ListView ID="lvTravelMethod" runat="server" OnItemDataBound="lvTravelMethod_ItemDataBound">
            <LayoutTemplate>
                <table>
                    <tr>
                        <td colspan="2">
                            <b>Select your method of travel:</b>
                        </td>
                    </tr>
                    <tr runat="server" id="itemPlaceholder" />
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="labRouteNo" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="upnlVehicle" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:ListView ID="lvVehicle" runat="server" OnItemDataBound="lvVehicle_ItemDataBound"
                                    Enabled="false">
                                    <LayoutTemplate>
                                        <table>
                                            <tr runat="server" id="itemPlaceholder" />
                                        </table>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="labVehicleNo" runat="server" Text="Label"></asp:Label>
                                                <asp:DropDownList ID="ddlType" runat="server">
                                                    <asp:ListItem Text="--select--" Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                                Length:<asp:TextBox ID="txtLength" runat="server" Width="50"></asp:TextBox>
                                                Height:
                                                <asp:DropDownList ID="ddlHeight" runat="server">
                                                    <asp:ListItem Text="--select--" Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                                Width:
                                                <asp:DropDownList ID="ddlWidth" runat="server">
                                                    <asp:ListItem Text="--select--" Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <asp:Button ID="btnContinue" runat="server" Text="Continue" OnClick="btnContinue_Click" />
    </div>
    </form>
</body>
</html>
