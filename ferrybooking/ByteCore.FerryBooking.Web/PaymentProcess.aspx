<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentProcess.aspx.cs"
    Inherits="ByteCore.FerryBooking.Web.PaymentProcess" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Process</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td colspan="2">
                    Summary
                </td>
            </tr>
            <tr>
                <td>
                    First Name&nbsp;
                    </td>
                <td>
                    &nbsp;
                    <asp:Label ID="lblFirstName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Surname&nbsp;
                </td>
                <td>
                    &nbsp;<asp:Label ID="lblSurname" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Phone Number&nbsp;
                </td>
                <td>
                    &nbsp;<asp:Label ID="lblPhoneNumber" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Total&nbsp;
                </td>
                <td>
                    &nbsp;<asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td colspan="2">
                    Billing Information
                </td>
            </tr>
            <tr>
                <td>
                    Payment Type&nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="ddlPaymentType" runat="server">
                        <asp:ListItem Value="">-- Choose one --</asp:ListItem>
                        <asp:ListItem Value="Visa">Visa</asp:ListItem>
                        <asp:ListItem Value="MasterCard">MasterCard</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Card Number&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtCardNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Security code&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtSecurityCode" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Expiration Date (mm/yr)&nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="ddlMonth" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlYear" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Name on Card&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtNameOnCard" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Address&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    City&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Province / State&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtProvince" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    ZIP/Postal code&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtPostalcode" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Country&nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="ddlCountry" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    If you have problems with reservation or need assistance please call 1-800-686-0446
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="bynProcess" runat="server" Text="Process" OnClick="btnProcess_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
