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
                            <asp:Button ID="btnSave" runat="server" Text="Save" CausesValidation="False" />
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
                <div class="GrdOutline">
                    <asp:GridView ID="GV_PassengersList" runat="server" AutoGenerateColumns="False" Width="100%"
                        DataKeyNames="ID">
                        <Columns>
                            <asp:TemplateField></asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="DataTableCell" />
                        <SelectedRowStyle CssClass="DataTableSelCell" />
                        <HeaderStyle CssClass="DataTableHeader" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GV_RoutesList" runat="server" AutoGenerateColumns="False" Width="100%"
                    DataKeyNames="ID">
                    <Columns>
                        <asp:TemplateField></asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="DataTableCell" />
                    <SelectedRowStyle CssClass="DataTableSelCell" />
                    <HeaderStyle CssClass="DataTableHeader" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
