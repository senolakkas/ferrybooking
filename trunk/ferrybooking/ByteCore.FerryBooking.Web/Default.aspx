<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ByteCore.FerryBooking.Web.Default"  validateRequest="false" enableEventValidation="false" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Default</title>
    <script language="javascript" type="text/javascript">
    
    function on_rbSingle()
    {
        route2.disabled="disable";
        route2.options[0].selected = true;
        route3.style.display="none";
        route4.style.display="none"; 
    }
    
    function on_rbReturn()
    {
        route2.disabled = "";
        autoSelectReturnRoute();
        route3.style.display="none";
        route4.style.display="none";
    }
    
    function on_rbMulti()
    {
        route2.disabled="";
        autoSelectReturnRoute();
        route3.style.display="block";
        route4.style.display="block";
    }
    
    function autoSelectReturnRoute()
    {
        var str = "";
        for (var i = 0; i < route1.options.length; i++)
        {
            if (route1.options[i].selected) 
            {
                var ports1 = route1.options[i].text.split(" - ");
                str = ports1[1] + " - " + ports1[0];
            }
        }

        for (var i = 0; i < route2.options.length; i++) 
        {
            if (!route2.disabled && route2.options[i].text == str) 
            {
                route2.options[i].selected = true;
                break;
            }
        }
    }
    
    function on_route1_change()
    {
        initRouteDataSource();
        if(!singleRb.checked)
        {
            autoSelectReturnRoute();
        }
    }
    
    function initRouteDataSource()
    {
        route2.options.length = 1;
        route3.options.length = 1;
        route4.options.length = 1;
        if(route1.selectedIndex==0)
            return;
        var currSelectValue = route1.value.split("_");
        var companyId = currSelectValue[1];
        for (var i = 1; i < route1.options.length; i++)
        {
            if (route1.options[i].value.endsWith("_"+companyId)) 
            {
                route2.options.add(new Option(route1.options[i].text, route1.options[i].value));  
                route3.options.add(new Option(route1.options[i].text, route1.options[i].value));
                route4.options.add(new Option(route1.options[i].text, route1.options[i].value));
            }
        }
    }
    
    function validateRoute1(sender, args)
    {
        args.IsValid = (route1.selectedIndex!=0);
        return;
    }
    
    function validatePassengers(sender, args)
    {
        args.IsValid = (passengers.selectedIndex!=0);
        return;
    }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
        <table border="0" cellpadding="0" cellspacing="0" >
            <tr>
                <td>
                    <asp:RadioButton ID="rbSingle" runat="server" Checked="True"
                        GroupName="Direction" Text="Single" />
                    <asp:RadioButton ID="rbReturn" runat="server"
                        GroupName="Direction" Text="Return" />
                    <asp:RadioButton ID="rbMulti" runat="server" 
                        GroupName="Direction" Text="Multi" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlRoute1" runat="server" Width="180px" ></asp:DropDownList>
                    <asp:CustomValidator ID="validRout1" runat="server" ErrorMessage="CustomValidator" ControlToValidate="ddlRoute1" 
                        ValidationGroup="vgBookingStep1" ClientValidationFunction="validateRoute1" 
                        SetFocusOnError="True" Text="*" Display="Dynamic"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlRoute2" runat="server" Width="180px" Enabled="False"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlRoute3" runat="server" Width="180px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlRoute4" runat="server" Width="180px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlPassengers" runat="server" Width="180px"></asp:DropDownList>
                    <asp:CustomValidator ID="validPassenger" runat="server" ErrorMessage="CustomValidator" ControlToValidate="ddlPassengers" 
                        ValidationGroup="vgBookingStep1" ClientValidationFunction="validatePassengers" 
                        SetFocusOnError="True" Text="*" Display="Dynamic"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlVehicles" runat="server" Width="180px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnGetPrice" runat="server" Text="Get Price" 
                        ValidationGroup="vgBookingStep1" onclick="btnGetPrice_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
