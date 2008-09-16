<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ByteCore.FerryBooking.Web.Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:RadioButton ID="rbSingle" runat="server" Checked="True" 
            GroupName="Direction" Text="Single" />
        <asp:RadioButton ID="rbReturn" runat="server"
            GroupName="Direction" Text="Return" />
        <asp:RadioButton ID="rbMulti" runat="server"    
            GroupName="Direction" Text="Multi" />
        <br />
        <asp:DropDownList ID="ddlRoute1" runat="server">
        </asp:DropDownList><br />
        <asp:DropDownList ID="ddlRoute2" runat="server" Enabled="False">
        </asp:DropDownList><br />
        
        <asp:DropDownList ID="ddlRoute3" runat="server" Visible="False">
        </asp:DropDownList><br />
        <asp:DropDownList ID="ddlRoute4" runat="server" Visible="False">
        </asp:DropDownList>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="upRouteSelection" runat="server">
        </asp:UpdatePanel>
        <br />
    
    </div>
    </form>
</body>
</html>
