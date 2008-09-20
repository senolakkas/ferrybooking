﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true" CodeBehind="frmFare.aspx.cs" Inherits="ByteCore.FerryBooking.Web.frmFare" Title="Fare Management" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="4">
        <tr>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Label ID="lblOperator" runat="server" Text="Operator:"></asp:Label>
                &nbsp;<asp:DropDownList ID="ddlOperator" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlOperator_SelectedIndexChanged" Width="200px">
                </asp:DropDownList>
&nbsp;
                <br />
                Route:
                <asp:DropDownList ID="ddlRoute" runat="server" Width="300px">
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
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <div class="GrdOutline">
                <asp:GridView ID="GV_FareList" runat="server" AutoGenerateColumns="False" 
                        Width="100%" AllowPaging="True" DataKeyNames="ID" 
                        onselectedindexchanged="GV_FareList_SelectedIndexChanged" 
                        onrowdeleted="GV_FareList_RowDeleted" 
                        onpageindexchanging="GV_FareList_PageIndexChanging">
                    <Columns>
                        <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnEditItems" runat="server" CausesValidation="False" 
                                    CommandName="EditItems" CommandArgument='<%#Eval("ID")%>' 
                                    oncommand="lbtnEditItems_Command">Edit Items</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
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
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <asp:Button ID="btnAdd" runat="server" Text="Add New Fare" 
                    OnClick="btnAdd_Click" CausesValidation="False" />&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:FormView ID="FV_Fare" runat="server" Width="500px" 
                    onitemcommand="FV_Fare_ItemCommand" DataSourceID="ODS_FareEdit" 
                    DataKeyNames="ID">
                    <InsertItemTemplate>
                        <table class="FormCellLabel" width="500px" border="0" cellpadding="2" cellspacing="0">
                            <tr>
                                <td colspan="2" class="FormTableHeader">
                                    <asp:Label ID="lblHeader" runat="server">Add Fare</asp:Label></td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Route:</td>
                                <td>
                                    <asp:DropDownList ID="ddlRoute" runat="server" Width="300px" DataSourceID="ODS_RouteInsert" 
                                        DataTextField="FullName" DataValueField="ID"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="ODS_RouteInsert" runat="server" 
                                        SelectMethod="GetAllList" TypeName="ByteCore.FerryBooking.Core.Route">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>                              
                            <tr class="FormTable">
                                <td>
                                    Start Date:</td>
                                <td>
                                    <asp:TextBox ID="txtStartDate" runat="server" Width="150px"></asp:TextBox>
                                    &nbsp;(i.e. 2008/05/01)</td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    End Date:</td>
                                <td>
                                    <asp:TextBox ID="txtEndDate" runat="server" Width="150px"></asp:TextBox>
                                    &nbsp;(i.e. 2008/09/30)</td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                </td>
                                <td>
                                    <asp:LinkButton ID="btnInsert" runat="server" CausesValidation="True" CommandName="DoInsert"
                                        Text="Insert"></asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton ID="btnCancelInsert" runat="server" CausesValidation="False" CommandName="DoCancel"
                                        Text="Cancel"></asp:LinkButton></td>
                            </tr>
                        </table>
                    </InsertItemTemplate>
                    <EditItemTemplate>
                        <table class="FormCellLabel" width="500px" border="0" cellpadding="2" cellspacing="0">
                            <tr>
                                <td colspan="2" class="FormTableHeader">
                                    <asp:Label ID="lblHeader0" runat="server">Edit Fare</asp:Label></td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Route:</td>
                                <td>
                                    <asp:DropDownList ID="ddlRoute" runat="server" Width="300px" 
                                    SelectedValue='<%# Eval("RoutesId") %>' DataSourceID="ODS_RouteEdit" 
                                        DataTextField="FullName" DataValueField="ID" >
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ODS_RouteEdit" runat="server" 
                                        SelectMethod="GetAllList" TypeName="ByteCore.FerryBooking.Core.Route">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Start Date:</td>
                                <td>
                                    <asp:TextBox ID="txtStartDate" 
                                        Text='<%# Eval("StartDate","{0:yyyy/MM/dd}") %>' runat="server" 
                                        Width="150px" ></asp:TextBox>
                                    &nbsp;(i.e. 2008/05/01)</td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    End Date:</td>
                                <td>
                                    <asp:TextBox ID="txtEndDate" 
                                        Text='<%# Eval("EndDate","{0:yyyy/MM/dd}") %>' runat="server" 
                                        Width="150px"></asp:TextBox>
                                    &nbsp;(i.e. 2008/09/30)</td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                </td>
                                <td>
                                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="DoUpdate" CommandArgument='<%# Eval("ID") %>' 
                                        Text="Update"></asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="DoCancel"
                                        Text="Cancel"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="ODS_FareEdit" runat="server" 
                    SelectMethod="GetById" TypeName="ByteCore.FerryBooking.Core.Fare">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="GV_FareList" Name="id" 
                            PropertyName="SelectedValue" Type="Int32" />
                        <asp:Parameter DefaultValue="false" Name="shouldLock" Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlFareItems" runat="server" Width="100%">
                    <table width="100%" border="0" cellpadding="0" cellspacing="4">
        <tr>
            <td>
                Fare Category:&nbsp;<asp:DropDownList ID="ddlFareCategory" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlOperator_SelectedIndexChanged" Width="200px">
                </asp:DropDownList>
                <br />
                <asp:Button ID="btnSubSearch" runat="server" OnClick="btnSubSearch_Click" 
                    Text="Search" CausesValidation="False" />
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <div class="GrdOutline">
                <asp:GridView ID="GV_FareItem" runat="server" AutoGenerateColumns="False" 
                        Width="100%" AllowPaging="True" DataKeyNames="ID" 
                        onselectedindexchanged="GV_FareItemList_SelectedIndexChanged" 
                        onrowdeleted="GV_FareItemList_RowDeleted" 
                        onpageindexchanging="GV_FareItemList_PageIndexChanging">
                    <Columns>
                        <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                OnClientClick="return confirm('Are you sure you want to delete this record?');">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Operator">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("FareType.OperatorId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                        <asp:BoundField DataField="RangeStart" HeaderText="Range Start" />
                    </Columns>
                    <RowStyle CssClass="DataTableCell" />
                    <SelectedRowStyle CssClass="DataTableSelCell" />
                    <HeaderStyle CssClass="DataTableHeader" />
                </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <asp:Button ID="btnAddFareItem" runat="server" Text="Add New Fare Item" 
                    OnClick="btnAddItem_Click" CausesValidation="False" />&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblSubMessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:FormView ID="FV_FareItem" runat="server" Width="500px" 
                    onitemcommand="FV_FareItem_ItemCommand" DataSourceID="ODS_FareItemEdit" 
                    DataKeyNames="ID">
                    <InsertItemTemplate>
                        <table class="FormCellLabel" width="500px" border="0" cellpadding="2" cellspacing="0">
                            <tr>
                                <td colspan="2" class="FormTableHeader">
                                    <asp:Label ID="lblHeader" runat="server">Add Fare</asp:Label></td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Route:</td>
                                <td>
                                    <asp:DropDownList ID="ddlRoute" runat="server" Width="300px" DataSourceID="ODS_RouteInsert" 
                                        DataTextField="FullName" DataValueField="ID"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="ODS_RouteInsert" runat="server" 
                                        SelectMethod="GetAllList" TypeName="ByteCore.FerryBooking.Core.Route">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>                              
                            <tr class="FormTable">
                                <td>
                                    Start Date:</td>
                                <td>
                                    <asp:TextBox ID="txtStartDate" runat="server" Width="150px"></asp:TextBox>
                                    &nbsp;(i.e. 2008/05/01)</td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    End Date:</td>
                                <td>
                                    <asp:TextBox ID="txtEndDate" runat="server" Width="150px"></asp:TextBox>
                                    &nbsp;(i.e. 2008/09/30)</td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                </td>
                                <td>
                                    <asp:LinkButton ID="btnInsert" runat="server" CausesValidation="True" CommandName="DoInsert"
                                        Text="Insert"></asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton ID="btnCancelInsert" runat="server" CausesValidation="False" CommandName="DoCancel"
                                        Text="Cancel"></asp:LinkButton></td>
                            </tr>
                        </table>
                    </InsertItemTemplate>
                    <EditItemTemplate>
                        <table class="FormCellLabel" width="500px" border="0" cellpadding="2" cellspacing="0">
                            <tr>
                                <td colspan="2" class="FormTableHeader">
                                    <asp:Label ID="lblHeader0" runat="server">Edit Fare</asp:Label></td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Route:</td>
                                <td>
                                    <asp:DropDownList ID="ddlRoute" runat="server" Width="300px" 
                                    DataSourceID="ODS_RouteEdit" 
                                        DataTextField="FullName" DataValueField="ID" >
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ODS_RouteEdit" runat="server" 
                                        SelectMethod="GetAllList" TypeName="ByteCore.FerryBooking.Core.Route">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Start Date:</td>
                                <td>
                                    <asp:TextBox ID="txtStartDate" 
                                        runat="server" 
                                        Width="150px" ></asp:TextBox>
                                    &nbsp;(i.e. 2008/05/01)</td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    End Date:</td>
                                <td>
                                    <asp:TextBox ID="txtEndDate" 
                                        runat="server" 
                                        Width="150px"></asp:TextBox>
                                    &nbsp;(i.e. 2008/09/30)</td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                </td>
                                <td>
                                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="DoUpdate" CommandArgument='<%# Eval("ID") %>' 
                                        Text="Update"></asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="DoCancel"
                                        Text="Cancel"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="ODS_FareItemEdit" runat="server" 
                    SelectMethod="GetById" TypeName="ByteCore.FerryBooking.Core.FareItem">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="GV_FareList" Name="id" 
                            PropertyName="SelectedValue" Type="Int32" />
                        <asp:Parameter DefaultValue="false" Name="shouldLock" Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
