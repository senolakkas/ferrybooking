<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Step2.aspx.cs" Inherits="ByteCore.FerryBooking.Web.Step2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Step 2</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:UpdatePanel ID="pnlRout1" runat="server" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:Label ID="labRouteName1" runat="server"></asp:Label>
                <asp:DropDownList ID="ddlYear1" runat="server" AutoPostBack="true" 
                    onselectedindexchanged="ddlYear1_SelectedIndexChanged"></asp:DropDownList>
                <asp:DropDownList ID="ddlMonth1" runat="server" AutoPostBack="true" Enabled="false"></asp:DropDownList>
                <asp:DropDownList ID="ddlDay1" runat="server" AutoPostBack="true" Enabled="false"></asp:DropDownList>
                <asp:DropDownList ID="ddlTime1" runat="server" AutoPostBack="true" Enabled="false"></asp:DropDownList>
                <asp:Label ID="labArrivalDate1" runat="server"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        
    </div>
    </form>
</body>
</html>
