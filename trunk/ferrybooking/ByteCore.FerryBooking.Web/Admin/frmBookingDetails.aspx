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
                    <asp:Repeater ID="Rpt_PassengerList" runat="server" 
                        onitemdatabound="Rpt_PassengerList_ItemDataBound">
                        <ItemTemplate>
                            <table style="width: 100%;">
                                <tr>
                                    <td colspan="4">
                                        Passenger
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        First Name: 
                                    </td>
                                    <td>
                                        &nbsp;<asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FirstName2")%>'></asp:Label>
                                    </td>
                                    <td>
                                        Last Name: 
                                    </td>
                                     <td>
                                        &nbsp;<asp:Label ID="Label1" runat="server" Text='<%#Eval("LastName2")%>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
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
