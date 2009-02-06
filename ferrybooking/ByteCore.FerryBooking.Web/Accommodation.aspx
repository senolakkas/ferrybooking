<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Accommodation.aspx.cs"
    Inherits="ByteCore.FerryBooking.Web.Accommodation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ferry Travel - Booking - Accommodation</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:ListView ID="lvAccommodation" runat="server" OnItemDataBound="lvAccommodation_ItemDataBound">
            <LayoutTemplate>
                <table>
                    <tr runat="server" id="itemPlaceholder" />
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="lblRoute" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:GridView ID="gvAccommodation" DataKeyNames="FareTypeId" runat="server" AutoGenerateColumns="false" AllowPaging="false" AllowSorting="false" OnRowDataBound="gvAccommodation_ItemDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Accommodation Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAccommodationType" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Number">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlNumber" runat="server">
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                No accommodation available in this route</EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
        <asp:Button ID="btnContinue" runat="server" Text="Continue" OnClick="btnContinue_Click" />
    </div>
    </form>
</body>
</html>
