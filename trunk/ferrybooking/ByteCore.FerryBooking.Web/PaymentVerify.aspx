<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentVerify.aspx.cs"
    Inherits="ByteCore.FerryBooking.Web.PaymentVerify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Verify</title>
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
        <asp:Literal ID="Literal1" runat="server">
        Sorry, but your credit card transaction can not be completed as entered
Please check your credit card to verify the information entered is correct and try again or , choose another card.
        </asp:Literal>
    </div>
    </form>
</body>
</html>
