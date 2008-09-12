<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true" CodeBehind="frmSchedule.aspx.cs" Inherits="ByteCore.FerryBooking.Web.frmSchedule" Title="Schedule Management" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="4">
        <tr>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Label ID="lblOperator" runat="server" Text="Vessel:"></asp:Label>
                &nbsp;<asp:DropDownList ID="ddlVessel" runat="server" 
                    DataSourceID="ODS_VesselList" DataTextField="VesselCode" 
                    DataValueField="ID" AutoPostBack="True" 
                    onselectedindexchanged="ddlVessel_SelectedIndexChanged1">
                </asp:DropDownList>
&nbsp;
                <br />
                &nbsp;<asp:Label ID="lblOperator0" runat="server" Text="Fare:"></asp:Label>
                <asp:DropDownList ID="ddlFare" runat="server" DataSourceID="ODS_FareList" 
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
                <asp:ObjectDataSource ID="ODS_VesselList" runat="server" 
                    SelectMethod="GetAllList" TypeName="ByteCore.FerryBooking.Core.Vessel">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ODS_FareList" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllList" 
                    TypeName="ByteCore.FerryBooking.Core.Fare">
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <div class="GrdOutline">
                <asp:GridView ID="GV_ScheduleList" runat="server" AutoGenerateColumns="False" 
                        Width="100%" AllowPaging="True" AllowSorting="True" DataKeyNames="ID" 
                        onselectedindexchanged="GV_ScheduleList_SelectedIndexChanged" 
                        DataSourceID="ODS_ScheduleList" onrowdeleted="GV_ScheduleList_RowDeleted">
                    <Columns>
                        <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                OnClientClick="return confirm('Are you sure you want to delete this record?');">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vessel">
                            <ItemTemplate>
                                <asp:Label ID="lblVessel" runat="server" Text='<%# Eval("Vessel.VesselCode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fare">
                            <ItemTemplate>
                                <asp:Label ID="lblFare" runat="server" Text='<%# Eval("Fare.FullName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="SailingTime" HeaderText="Start Date" />
                        <asp:BoundField DataField="ArrivalTime" HeaderText="End Date" />
                    </Columns>
                    <RowStyle CssClass="DataTableCell" />
                    <SelectedRowStyle CssClass="DataTableSelCell" />
                    <HeaderStyle CssClass="DataTableHeader" />
                </asp:GridView>
                    <asp:ObjectDataSource ID="ODS_ScheduleList" runat="server" 
                        DeleteMethod="DoDelete" SelectMethod="GetScheduleList" 
                        TypeName="ByteCore.FerryBooking.Core.Schedule">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" Type="Int32" />
                        </DeleteParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlVessel" Name="vesselId" 
                                PropertyName="SelectedValue" Type="Int32" />
                            <asp:ControlParameter ControlID="ddlFare" Name="fareId" 
                                PropertyName="SelectedValue" Type="Int32" />
                            <asp:ControlParameter ControlID="txtStartDate" Name="sailingTime" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtEndDate" Name="arrivalTime" PropertyName="Text" 
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
