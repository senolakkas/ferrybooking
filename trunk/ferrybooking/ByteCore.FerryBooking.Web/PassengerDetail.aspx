<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassengerDetail.aspx.cs"
    Inherits="ByteCore.FerryBooking.Web.PassengerDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Passenger Details</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ListView ID="LV_RouteVehicle" runat="server" OnItemDataBound="LV_RouteVehicle_ItemDataBound">
            <LayoutTemplate>
                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                    <tr>
                        <td>
                            Route
                        </td>
                        <td>
                            License plate
                        </td>
                        <td>
                            Vehicle Make/Model
                        </td>
                    </tr>
                    <tr id="itemPlaceholder" runat="server">
                    </tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="lblRouteNo" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="hidRouteNo" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:ListView ID="LV_VehicleDetail" runat="server" OnItemDataBound="LV_VehicleDetail_ItemDataBound">
                            <LayoutTemplate>
                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblVehicleNo" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPlate" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtModel" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <br />
        <br />
        <asp:ListView ID="LV_PassengerDetail" runat="server" OnItemDataBound="LV_PassengerDetail_ItemDataBound">
            <LayoutTemplate>
                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                    <tr>
                        <td colspan="2">
                            Enter Passenger Details
                        </td>
                    </tr>
                    <tr id="itemPlaceholder" runat="server">
                    </tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        Title *
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTitle" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        First Name *
                    </td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        SurName *
                    </td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Citizenship *
                    </td>
                    <td>
                        <asp:TextBox ID="txtCitizenship" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Gender *
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGender" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Date Of Birth (<asp:Label ID="lblAge" runat="server" Text=""></asp:Label>) *
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDate" runat="server">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlMonth" runat="server">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlYear" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <asp:Panel ID="pnlAdditionalDetail" runat="server">
                    <tr>
                        <td>
                            Passport *
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassport" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email *
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Address *
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Address 2 *
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            City *
                        </td>
                        <td>
                            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Province / State *
                        </td>
                        <td>
                            <asp:TextBox ID="txtProvince" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Postcode *
                        </td>
                        <td>
                            <asp:TextBox ID="txtPostcode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Country *
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCountry" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Cell / Mobile *
                        </td>
                        <td>
                            <asp:TextBox ID="txtCellphone" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Telephone *
                        </td>
                        <td>
                            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Fax *
                        </td>
                        <td>
                            <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            Special requirement *
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSpecialRequirement" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </asp:Panel>
            </ItemTemplate>
            <ItemSeparatorTemplate><hr /></ItemSeparatorTemplate>
        </asp:ListView>
        <br />
        <br />
        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
        <asp:Button ID="btnContinue" runat="server" Text="Continue" OnClick="btnContinue_Click" />
    </div>
    </form>
</body>
</html>
