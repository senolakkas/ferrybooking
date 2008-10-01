<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true"
    CodeBehind="frmBooking.aspx.cs" Inherits="ByteCore.FerryBooking.Web.frmBooking"
    Title="Booking Management" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="4">
        <tr>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <table cellpadding="2" style="width: 100%">
                    <tr>
                        <td style="width: 40px">
                            <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStatus" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 40px">
                            Date:
                        </td>
                        <td>
                            From
                            <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
                            <asp:Image ID="imgStartDate" runat="server" ImageUrl="~/Images/calendar.gif" />
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate"
                                PopupButtonID="imgStartDate">
                            </cc1:CalendarExtender>
                            &nbsp;to
                            <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                            <asp:Image ID="imgEndDate" runat="server" ImageUrl="~/Images/calendar.gif" />
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEndDate"
                                PopupButtonID="imgEndDate">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 40px">
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search"
                                CausesValidation="False" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <div class="GrdOutline">
                    <asp:GridView ID="GV_BookingList" runat="server" AutoGenerateColumns="False" Width="100%"
                        AllowPaging="True" DataKeyNames="ID" OnSelectedIndexChanged="GV_BookingList_SelectedIndexChanged"
                        OnPageIndexChanging="GV_BookingList_PageIndexChanging" 
                        onrowdatabound="GV_BookingList_RowDataBound">
                        <Columns>
                            <asp:CommandField SelectText="View Details" ShowSelectButton="True" />
                            <asp:BoundField DataField="BookingDate" HeaderText="Booking Date" DataFormatString="{0:MMM d, yyyy}"
                                HtmlEncode="false" />
                            <asp:TemplateField HeaderText="Phone">
                                <ItemTemplate>
                                    <asp:Label ID="lblPhoneNumber" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Primary Passenger">
                                <ItemTemplate>
                                    <asp:Label ID="lblPrimaryPassenger" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TotalAmount" DataFormatString="{0:C}" 
                                HeaderText="Total Amount" HtmlEncode="False" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:BoundField DataField="Comment" HeaderText="Comment" />
                            <asp:BoundField DataField="ID" HeaderText="ID" />
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
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
