<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true" CodeBehind="frmRoute.aspx.cs" Inherits="ByteCore.FerryBooking.Web.frmRoute" Title="Route Management" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="4">
        <tr>
            <td>
                &nbsp;<asp:Label ID="lblOperator" runat="server" Text="Operator:"></asp:Label>
                &nbsp;<asp:DropDownList ID="ddlOperator" runat="server" 
                    DataSourceID="ODS_OperatorList" DataTextField="CompanyShortName" 
                    DataValueField="ID">
                </asp:DropDownList>
&nbsp;
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" 
                    Text="Search" CausesValidation="False" />
                <asp:ObjectDataSource ID="ODS_OperatorList" runat="server" 
                    SelectMethod="GetAllList" TypeName="ByteCore.FerryBooking.Core.Company">
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <div class="GrdOutline">
                <asp:GridView ID="GV_RouteList" runat="server" AutoGenerateColumns="False" 
                        Width="100%" AllowPaging="True" AllowSorting="True" DataKeyNames="ID" 
                        onselectedindexchanged="GV_RouteList_SelectedIndexChanged" 
                        DataSourceID="ODS_RouteList" onrowdeleted="GV_RouteList_RowDeleted">
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
                                <asp:Label ID="lblOperator" runat="server" Text='<%# Eval("Operator.CompanyShortName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Departure Port">
                            <ItemTemplate>
                                <asp:Label ID="lblDeparturePort" runat="server" Text='<%# Eval("DeparturePort.PortName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="Arrival Port">
                            <ItemTemplate>
                                <asp:Label ID="lblArrivalPort" runat="server" Text='<%# Eval("ArriavlPort.PortName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="DataTableCell" />
                    <EmptyDataTemplate>
                        No result
                    </EmptyDataTemplate>
                    <SelectedRowStyle CssClass="DataTableSelCell" />
                    <HeaderStyle CssClass="DataTableHeader" />
                </asp:GridView>
                    <asp:ObjectDataSource ID="ODS_RouteList" runat="server" 
                        DeleteMethod="DoDelete" SelectMethod="GetRouteList" 
                        TypeName="ByteCore.FerryBooking.Core.Route">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" Type="Int32" />
                        </DeleteParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlOperator" Name="operatorId" 
                                PropertyName="SelectedValue" Type="Int32" />
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
                <br />
                <asp:FormView ID="FV_Route" runat="server" Width="500px" 
                    onitemcommand="FV_Route_ItemCommand" DataSourceID="ODS_RouteEdit" 
                    DataKeyNames="ID">
                    <InsertItemTemplate>
                        <table class="FormCellLabel" width="500px" border="0" cellpadding="2" cellspacing="0">
                            <tr>
                                <td colspan="2" class="FormTableHeader">
                                    <asp:Label ID="lblHeader" runat="server">Add Route</asp:Label></td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Operator:</td>
                                <td>
                                    <asp:DropDownList ID="ddlOperator" runat="server" DataSourceID="ODS_Operator" 
                                        DataTextField="CompanyShortName" DataValueField="ID"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="ODS_Operator" runat="server" 
                                        SelectMethod="GetAllList" TypeName="ByteCore.FerryBooking.Core.Company">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>  
                            <tr class="FormTable">
                                <td>
                                    Departure Port:</td>
                                <td>
                                    <asp:DropDownList ID="ddlDeparturePort" runat="server" DataSourceID="ODS_DeparturePort" 
                                        DataTextField="PortName" DataValueField="ID"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="ODS_DeparturePort" runat="server" 
                                        SelectMethod="GetAllList" TypeName="ByteCore.FerryBooking.Core.Port">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>   
                            <tr class="FormTable">
                                <td>
                                    Arrival Port:</td>
                                <td>
                                    <asp:DropDownList ID="ddlArrivalPort" runat="server" DataSourceID="ODS_ArrivalPort" 
                                        DataTextField="PortName" DataValueField="ID"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="ODS_ArrivalPort" runat="server" 
                                        SelectMethod="GetAllList" TypeName="ByteCore.FerryBooking.Core.Port">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr> 
                            <tr class="FormTable">
                                <td>
                                    IsActive:</td>
                                <td>
                                    <asp:CheckBox ID="chkIsActive" runat="server" Checked="True" />
                                    (Check for "Yes")</td>
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
                                    <asp:Label ID="lblHeader" runat="server">Edit Vessel</asp:Label></td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Operator:</td>
                                <td>
                                    <asp:DropDownList ID="ddlOperator" runat="server" 
                                        SelectedValue='<%# Eval("OperatorId") %>' DataSourceID="ODS_Operator" 
                                        DataTextField="CompanyShortName" DataValueField="ID">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ODS_Operator" runat="server" 
                                        SelectMethod="GetAllList" TypeName="ByteCore.FerryBooking.Core.Company">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Departure Port:</td>
                                <td>
                                    <asp:DropDownList ID="ddlDeparturePort" runat="server" DataSourceID="ODS_DeparturePort" 
                                        SelectedValue='<%# Eval("DeparturePortId") %>' DataTextField="PortName" DataValueField="ID">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ODS_DeparturePort" runat="server" 
                                        SelectMethod="GetAllList" TypeName="ByteCore.FerryBooking.Core.Port">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Arrival Port:</td>
                                <td>                                    
                                    <asp:DropDownList ID="ddlArrivalPort" runat="server" DataSourceID="ODS_ArrivalPort" 
                                        SelectedValue='<%# Eval("ArriavlPortId") %>' DataTextField="PortName" DataValueField="ID">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ODS_ArrivalPort" runat="server" 
                                        SelectMethod="GetAllList" TypeName="ByteCore.FerryBooking.Core.Port">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    IsActive:</td>
                                <td>
                                    <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%# Eval("IsActive")==null ? false : Eval("IsActive") %>' />
                                    (Check for "Yes")</td>
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
                <asp:ObjectDataSource ID="ODS_RouteEdit" runat="server" 
                    SelectMethod="GetById" TypeName="ByteCore.FerryBooking.Core.Route">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="GV_RouteList" Name="id" 
                            PropertyName="SelectedValue" Type="Int32" />
                        <asp:Parameter DefaultValue="false" Name="shouldLock" Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
