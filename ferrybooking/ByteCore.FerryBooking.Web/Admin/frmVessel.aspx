<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true" CodeBehind="frmVessel.aspx.cs" Inherits="ByteCore.FerryBooking.Web.frmVessel" Title="Vessel Management" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="4">
        <tr>
            <td>
                <asp:Label ID="lblVesselName" runat="server" Text="Vessel Code:"></asp:Label>
                &nbsp;&nbsp;<asp:TextBox ID="txtVesselCode" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblOperator" runat="server" Text="Operator:"></asp:Label>
                &nbsp;&nbsp;<asp:DropDownList ID="ddlOperator" runat="server" 
                    DataSourceID="ODS_OperatorList" DataTextField="FullName" 
                    DataValueField="ID" Width="200px">
                </asp:DropDownList>
&nbsp;
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
                <asp:GridView ID="GV_VesselList" runat="server" AutoGenerateColumns="False" 
                        Width="100%" AllowPaging="True" AllowSorting="True" DataKeyNames="ID" 
                        onselectedindexchanged="GV_VesselList_SelectedIndexChanged" 
                        DataSourceID="ODS_VesselList" onrowdeleted="GV_VesselList_RowDeleted">
                    <Columns>
                        <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                OnClientClick="return confirm('Are you sure you want to delete this record?');">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="VesselCode" HeaderText="Vessel Code" />
                        <asp:BoundField DataField="VesselName" HeaderText="Vessel Name" />
                        <asp:TemplateField HeaderText="Operator">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Operator.CompanyShortName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="DataTableCell" />
                    <SelectedRowStyle CssClass="DataTableSelCell" />
                    <HeaderStyle CssClass="DataTableHeader" />
                </asp:GridView>
                    <asp:ObjectDataSource ID="ODS_VesselList" runat="server" 
                        DeleteMethod="DoDelete" SelectMethod="GetVesselList" 
                        TypeName="ByteCore.FerryBooking.Core.Vessel">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" Type="Int32" />
                        </DeleteParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlOperator" Name="operatorId" 
                                PropertyName="SelectedValue" Type="Int32" />
                            <asp:ControlParameter ControlID="txtVesselCode" Name="vesselCode" 
                                PropertyName="Text" Type="String" />
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
                <asp:FormView ID="FV_Vessel" runat="server" Width="500px" 
                    onitemcommand="FV_Vessel_ItemCommand" DataSourceID="ODS_VesselEdit" 
                    DataKeyNames="ID">
                    <InsertItemTemplate>
                        <table class="FormCellLabel" width="500px" border="0" cellpadding="2" cellspacing="0">
                            <tr>
                                <td colspan="2" class="FormTableHeader">
                                    <asp:Label ID="lblHeader" runat="server">Add Vessel</asp:Label></td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Vessel Code:</td>
                                <td>
                                    <asp:TextBox ID="txtVesselCode" runat="server" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtVesselCode"
                                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Vessel Name:</td>
                                <td>
                                    <asp:TextBox ID="txtVesselName" runat="server" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVesselName"
                                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Operator:</td>
                                <td>
                                    <asp:DropDownList ID="ddlOperator" runat="server" DataSourceID="ODS_Operator" 
                                        DataTextField="CompanyShortName" DataValueField="ID" AutoPostBack="True" 
                                        onselectedindexchanged="ddlOperator_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="ODS_Operator" runat="server" 
                                        SelectMethod="GetAllList" TypeName="ByteCore.FerryBooking.Core.Company">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>                            
                            <tr class="FormTable">
                                <td>
                                    Cabinet:</td>
                                <td>
                                    <asp:Panel ID="pnlCabinet"  runat="server">
                                    </asp:Panel>
                                </td>
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
                                    Vessel Code:</td>
                                <td>
                                    <asp:TextBox ID="txtVesselCode" runat="server" Text='<%# Eval("VesselCode") %>' Width="300px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtVesselCode"
                                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Vessel Name:</td>
                                <td>
                                    <asp:TextBox ID="txtVesselName" runat="server" Text='<%# Eval("VesselName") %>'></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Operator:</td>
                                <td>
                                    <asp:DropDownList ID="ddlOperator" runat="server" 
                                        SelectedValue='<%# Eval("OperatorId") %>' DataSourceID="ODS_Operator" 
                                        DataTextField="CompanyShortName" DataValueField="ID" AutoPostBack="True" 
                                        onselectedindexchanged="ddlOperator_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ODS_Operator" runat="server" 
                                        SelectMethod="GetAllList" TypeName="ByteCore.FerryBooking.Core.Company">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Cabinet:</td>
                                <td>
                                    <asp:Panel ID="pnlCabinet" runat="server">
                                    </asp:Panel>
                                </td>
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
                <asp:ObjectDataSource ID="ODS_VesselEdit" runat="server" 
                    SelectMethod="GetById" TypeName="ByteCore.FerryBooking.Core.Vessel">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="GV_VesselList" Name="id" 
                            PropertyName="SelectedValue" Type="Int32" />
                        <asp:Parameter DefaultValue="false" Name="shouldLock" Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
