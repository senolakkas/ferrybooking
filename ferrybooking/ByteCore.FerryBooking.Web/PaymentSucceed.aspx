﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentSucceed.aspx.cs"
    Inherits="ByteCore.FerryBooking.Web.PaymentSucceed" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Succeed</title>
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
        Your booking has been processd. Our representitive will contact you shortly. Thank you for your booking.
        </asp:Literal>
    </div>
    </form>
</body>
</html>