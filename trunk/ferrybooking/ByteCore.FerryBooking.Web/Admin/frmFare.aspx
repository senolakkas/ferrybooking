<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true" CodeBehind="frmFare.aspx.cs" Inherits="ByteCore.FerryBooking.Web.frmFare" Title="Fare Management" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="4">
        <tr>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Label ID="lblOperator" runat="server" Text="Operator:"></asp:Label>
                &nbsp;<asp:DropDownList ID="ddlOperator" runat="server" 
                    DataSourceID="ODS_OperatorList" DataTextField="CompanyShortName" 
                    DataValueField="ID" AutoPostBack="True" 
                    onselectedindexchanged="ddlOperator_SelectedIndexChanged1">
                </asp:DropDownList>
&nbsp;
                <br />
&nbsp;Route:
                <asp:DropDownList ID="ddlRoute" runat="server" DataSourceID="ODS_RouteList" 
                    DataTextField="FullName" DataValueField="ID">
                </asp:DropDownList>
                <br />
                Date:
                <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
                <asp:Image ID="imgStartDate" runat="server" ImageUrl="~/Images/calendar.gif" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate" PopupButtonID="imgStartDate">
                </cc1:CalendarExtender>
                
                &nbsp;to
                <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                <asp:Image ID="imgEndDate" runat="server" ImageUrl="~/Images/calendar.gif" />
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEndDate" PopupButtonID="imgEndDate">
                </cc1:CalendarExtender>
                <br />
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" 
                    Text="Search" CausesValidation="False" />
                <asp:ObjectDataSource ID="ODS_OperatorList" runat="server" 
                    SelectMethod="GetAllList" TypeName="ByteCore.FerryBooking.Core.Company">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ODS_RouteList" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetRouteList" 
                    TypeName="ByteCore.FerryBooking.Core.Route">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlOperator" Name="operatorId" 
                            PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <div class="GrdOutline">
                <asp:GridView ID="GV_FareList" runat="server" AutoGenerateColumns="False" 
                        Width="100%" AllowPaging="True" AllowSorting="True" DataKeyNames="ID" 
                        onselectedindexchanged="GV_FareList_SelectedIndexChanged" 
                        DataSourceID="ODS_FareList" onrowdeleted="GV_FareList_RowDeleted">
                    <Columns>
                        <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                OnClientClick="return confirm('Are you sure you want to delete this record?');">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Route">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Routes.FullName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="StartDate" HeaderText="Start Date" />
                        <asp:BoundField DataField="EndDate" HeaderText="End Date" />
                    </Columns>
                    <RowStyle CssClass="DataTableCell" />
                    <SelectedRowStyle CssClass="DataTableSelCell" />
                    <HeaderStyle CssClass="DataTableHeader" />
                </asp:GridView>
                    <asp:ObjectDataSource ID="ODS_FareList" runat="server" 
                        DeleteMethod="DoDelete" SelectMethod="GetFareList" 
                        TypeName="ByteCore.FerryBooking.Core.Fare" 
                        OldValuesParameterFormatString="original_{0}">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" Type="Int32" />
                        </DeleteParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlOperator" Name="operatorId" 
                                PropertyName="SelectedValue" Type="Int32" />
                            <asp:ControlParameter ControlID="ddlRoute" Name="routeId" 
                                PropertyName="SelectedValue" Type="Int32" />
                            <asp:ControlParameter ControlID="txtStartDate" Name="startDate" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtEndDate" Name="endDate" PropertyName="Text" 
                                Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="btnAdd_Click" CausesValidation="False" />&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
