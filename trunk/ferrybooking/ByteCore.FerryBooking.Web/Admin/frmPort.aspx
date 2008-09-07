<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true" CodeBehind="frmPort.aspx.cs" Inherits="ByteCore.FerryBooking.Web.Admin.frmPort" Title="Port Management" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="4">
        <tr>
            <td>
                <asp:Label ID="lblOperatorName" runat="server" Text="Port Name:"></asp:Label>
                <asp:TextBox ID="txtPortName" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" 
                    Text="Search" CausesValidation="False" />
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <div class="GrdOutline">
                <asp:GridView ID="GV_PortList" runat="server" AutoGenerateColumns="False" 
                        Width="100%" AllowPaging="True" AllowSorting="True" DataKeyNames="ID" 
                        onselectedindexchanged="GV_PortList_SelectedIndexChanged"
                        DataSourceID="ODS_PortList" onrowdeleted="GV_PortList_RowDeleted">
                    <Columns>
                        <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                OnClientClick="return confirm('Are you sure you want to delete this record?');">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID" HeaderText="Port Code" ReadOnly="True" />
                        <asp:BoundField DataField="PortName" HeaderText="Port Name" />
                    </Columns>
                    <RowStyle CssClass="DataTableCell" />
                    <SelectedRowStyle CssClass="DataTableSelCell" />
                    <HeaderStyle CssClass="DataTableHeader" />
                </asp:GridView>
                    <asp:ObjectDataSource ID="ODS_PortList" runat="server" 
                        SelectMethod="GetPortList" TypeName="ByteCore.FerryBooking.Core.Port" 
                        DeleteMethod="DoDelete">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" Type="String" />
                        </DeleteParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtPortName" Name="portName" 
                                PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="btnAdd_Click" CausesValidation="False" />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:FormView ID="FV_Port" runat="server" Width="400px" 
                    onitemcommand="FV_Port_ItemCommand" DataSourceID="ODS_PortEdit" 
                    DataKeyNames="ID">
                    <InsertItemTemplate>
                        <table class="FormCellLabel" width="400px" border="0" cellpadding="2" cellspacing="0">
                            <tr>
                                <td colspan="2" class="FormTableHeader">
                                    <asp:Label ID="lblHeader" runat="server">Add Port</asp:Label></td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Port Code:</td>
                                <td>
                                    <asp:TextBox ID="txtPortCode" runat="server" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPortCode"
                                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Port Name:</td>
                                <td>
                                    <asp:TextBox ID="txtPortName" runat="server" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPortName"
                                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
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
                        <table class="FormCellLabel" width="400px" border="0" cellpadding="2" cellspacing="0">
                            <tr>
                                <td colspan="2" class="FormTableHeader">
                                    <asp:Label ID="lblHeader0" runat="server">Edit Port</asp:Label></td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Port Code:</td>
                                <td>
                                    <asp:Label ID="lblPortCode" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Port Name:</td>
                                <td>
                                    <asp:TextBox ID="txtPortName" runat="server" 
                                        Text='<%# Eval("PortName") %>' Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                        ControlToValidate="txtPortName" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
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
                <asp:ObjectDataSource ID="ODS_PortEdit" runat="server" 
                    SelectMethod="GetById" TypeName="ByteCore.FerryBooking.Core.Port">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="GV_PortList" Name="id" 
                            PropertyName="SelectedValue" Type="String" DefaultValue="" />
                        <asp:Parameter DefaultValue="false" Name="shouldLock" Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
