<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true" CodeBehind="frmSchedule.aspx.cs" Inherits="ByteCore.FerryBooking.Web.frmSchedule" Title="Schedule Management" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="4">
        <tr>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Label ID="lblOperator" runat="server" Text="Vessel:"></asp:Label>
                &nbsp;<asp:DropDownList ID="ddlVessel" runat="server" Width="300px">
                </asp:DropDownList>
&nbsp;
                <br />
                <asp:Label ID="lblOperator0" runat="server" Text="Fare:"></asp:Label>
                <asp:DropDownList ID="ddlFare" runat="server" Width="300px">
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
                <asp:GridView ID="GV_ScheduleList" runat="server" AutoGenerateColumns="False" 
                        Width="100%" AllowPaging="True" DataKeyNames="ID" 
                        onselectedindexchanged="GV_ScheduleList_SelectedIndexChanged" 
                        onrowdeleted="GV_ScheduleList_RowDeleted" 
                        onpageindexchanging="GV_ScheduleList_PageIndexChanging">
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
                <asp:FormView ID="FV_Schedule" runat="server" Width="500px" 
                    onitemcommand="FV_Schedule_ItemCommand" DataSourceID="ODS_ScheduleEdit" 
                    DataKeyNames="ID">
                    <InsertItemTemplate>
                        <table class="FormCellLabel" width="500px" border="0" cellpadding="2" cellspacing="0">
                            <tr>
                                <td colspan="2" class="FormTableHeader">
                                    <asp:Label ID="lblHeader" runat="server">Add Schedule</asp:Label></td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Vessel:</td>
                                <td>
                                    <asp:DropDownList ID="ddlVessel" runat="server" Width="300px" DataSourceID="ODS_Vessel" 
                                        DataTextField="FullName" DataValueField="ID"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="ODS_Vessel" runat="server" 
                                        SelectMethod="GetAllList" TypeName="ByteCore.FerryBooking.Core.Vessel">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>  
                            <tr class="FormTable">
                                <td>
                                    Fare:</td>
                                <td>
                                    <asp:DropDownList ID="ddlFare" runat="server" Width="300px" DataSourceID="ODS_Fare" 
                                        DataTextField="FullName" DataValueField="ID"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="ODS_Fare" runat="server" 
                                        SelectMethod="GetAllList" TypeName="ByteCore.FerryBooking.Core.Fare">
                                    </asp:ObjectDataSource>
                                    </td>
                            </tr>                              
                            <tr class="FormTable">
                                <td>
                                    Sailing Time:</td>
                                <td>
                                    <asp:TextBox ID="txtSailingTime" runat="server" Width="150px"></asp:TextBox>
                                    &nbsp;(i.e. 2008/09/18 14:30:00)</td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Arrival Time:</td>
                                <td>
                                    <asp:TextBox ID="txtArrivalTime" runat="server" Width="150px"></asp:TextBox>
                                    &nbsp;(i.e. 2008/09/19 18:30:00)</td>
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
                                    <asp:Label ID="lblHeader0" runat="server">Edit Schedule</asp:Label></td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Vessel:</td>
                                <td>
                                    <asp:DropDownList ID="ddlVessel" runat="server" Width="300px" 
                                    SelectedValue='<%# Eval("VesselId") %>' DataSourceID="ODS_Vessel" 
                                        DataTextField="FullName" DataValueField="ID" >
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ODS_Vessel" runat="server" 
                                        SelectMethod="GetAllList" TypeName="ByteCore.FerryBooking.Core.Vessel">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Fare:</td>
                                <td>
                                    <asp:DropDownList ID="ddlFare" runat="server" Width="300px" 
                                    SelectedValue='<%# Eval("FareId") %>' DataSourceID="ODS_Fare" 
                                        DataTextField="FullName" DataValueField="ID">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ODS_Fare" runat="server" 
                                        SelectMethod="GetAllList" TypeName="ByteCore.FerryBooking.Core.Fare">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Sailing Time:</td>
                                <td>
                                    <asp:TextBox ID="txtSailingTime" Text='<%# Eval("SailingTime","{0:yyyy/MM/dd HH:mm:ss}") %>' runat="server" Width="150px" ></asp:TextBox>
                                    &nbsp;(i.e. 2008/09/18 14:30:00)</td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Arrival Time:</td>
                                <td>
                                    <asp:TextBox ID="txtArrivalTime" Text='<%# Eval("ArrivalTime","{0:yyyy/MM/dd HH:mm:ss}") %>' runat="server" Width="150px"></asp:TextBox>
                                    &nbsp;(i.e. 2008/09/19 18:30:00)</td>
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
                <asp:ObjectDataSource ID="ODS_ScheduleEdit" runat="server" 
                    SelectMethod="GetById" TypeName="ByteCore.FerryBooking.Core.Schedule">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="GV_ScheduleList" Name="id" 
                            PropertyName="SelectedValue" Type="Int32" />
                        <asp:Parameter DefaultValue="false" Name="shouldLock" Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
