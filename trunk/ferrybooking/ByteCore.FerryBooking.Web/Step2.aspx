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
        <asp:ListView ID="lvSchedule" runat="server" 
            onitemdatabound="lvSchedule_ItemDataBound" >
            <LayoutTemplate>
                <table>
                    <tr><td><b>Schedule:</b></td></tr>
                    <tr runat="server" id="itemPlaceholder" />
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="pnlRout" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:Label ID="labRouteName" runat="server"></asp:Label> 
                                <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" 
                                    onselectedindexchanged="ddlYear_SelectedIndexChanged"></asp:DropDownList>
                                <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="true" 
                                    Enabled="false" onselectedindexchanged="ddlMonth_SelectedIndexChanged"></asp:DropDownList>
                                <asp:DropDownList ID="ddlDay" runat="server" AutoPostBack="true" 
                                    Enabled="false" onselectedindexchanged="ddlDay_SelectedIndexChanged"></asp:DropDownList>
                                <asp:DropDownList ID="ddlTime" runat="server" AutoPostBack="true" onselectedindexchanged="ddlTime_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                                <asp:Label ID="labArrivalDate" runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    
        <asp:ListView ID="lvPassenger" runat="server" onitemdatabound="lvPassenger_ItemDataBound" >
            <LayoutTemplate>
                <table>
                    <tr><td><b>Passenger Ages:</b></td></tr>
                    <tr runat="server" id="itemPlaceholder" />
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        Passenger
                        <asp:Label ID="labPassengerNo" runat="server"></asp:Label> 
                        &nbsp;&nbsp;Age:
                        <asp:TextBox ID="txtPassengerAge" runat="server"></asp:TextBox>
                        Please enter age <font color="red">at time of travel.</font>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        
        <asp:Button ID="btnContinue" runat="server" Text="Continue" 
                onclick="btnContinue_Click" />
        
    </div>
    </form>
</body>
</html>
