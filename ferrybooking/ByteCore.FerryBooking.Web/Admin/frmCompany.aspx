<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true" CodeBehind="frmCompany.aspx.cs" Inherits="ByteCore.FerryBooking.Web.Admin.frmCompany" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="4">
        <tr>
            <td>
                <asp:Label ID="lblOperatorName" runat="server" Text="Operator Name:"></asp:Label>
                <asp:TextBox ID="txtOperatorName" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" 
                    Text="Search" CausesValidation="False" />
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <div class="GrdOutline">
                <asp:GridView ID="GV_OperatorList" runat="server" AutoGenerateColumns="False" 
                        Width="100%" AllowPaging="True" AllowSorting="True" DataKeyNames="ID" 
                        onselectedindexchanged="GV_OperatorList_SelectedIndexChanged" 
                        DataSourceID="ODS_CompanyList" onrowdeleted="GV_OperatorList_RowDeleted">
                    <Columns>
                        <asp:BoundField DataField="CompanyName" HeaderText="Name" />
                        <asp:BoundField DataField="CompanyShortName" HeaderText="Short Name" />
                        <asp:TemplateField HeaderText="Currency">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Currency.CurrencySymbol") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                OnClientClick="return confirm('Are you sure you want to delete this record?');">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="DataTableCell" />
                    <SelectedRowStyle CssClass="DataTableSelCell" />
                    <HeaderStyle CssClass="DataTableHeader" />
                </asp:GridView>
                    <asp:ObjectDataSource ID="ODS_CompanyList" runat="server" 
                        DeleteMethod="DoDelete" SelectMethod="GetCompanyList" 
                        TypeName="ByteCore.FerryBooking.Core.Company">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" Type="Int32" />
                        </DeleteParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="GV_OperatorList" Name="companyName" 
                                PropertyName="SelectedValue" Type="String" />
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
                <asp:FormView ID="FV_Operator" runat="server" Width="400px" 
                    onitemcommand="FV_Operator_ItemCommand" DataSourceID="ODS_CompanyEdit" 
                    DataKeyNames="ID">
                    <InsertItemTemplate>
                        <table class="FormCellLabel" width="400px" border="0" cellpadding="2" cellspacing="0">
                            <tr>
                                <td colspan="2" class="FormTableHeader">
                                    <asp:Label ID="lblHeader" runat="server">Add Operator</asp:Label></td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Name:</td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtName"
                                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Short Name:</td>
                                <td>
                                    <asp:TextBox ID="txtShortName" runat="server" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtShortName"
                                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Currency:</td>
                                <td>
                                    <asp:DropDownList ID="ddlCurrency" runat="server" DataSourceID="ODS_Currency" 
                                        DataTextField="CurrencySymbol" DataValueField="ID"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="ODS_Currency" runat="server" 
                                        SelectMethod="GetCurrencyList" TypeName="ByteCore.FerryBooking.Core.Currency">
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
                                    Logo:</td>
                                <td>
                                    <asp:FileUpload ID="FU_Logo" runat="server" />
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Terms:</td>
                                <td>
                                    <asp:TextBox ID="txtTerms" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox></td>
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
                                    <asp:Label ID="lblHeader" runat="server">Edit Operator</asp:Label></td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Name:</td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("CompanyName") %>' Width="300px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtName"
                                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Short Name:</td>
                                <td>
                                    <asp:TextBox ID="txtShortName" runat="server" Text='<%# Eval("CompanyShortName") %>'></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Currency:</td>
                                <td>
                                    <asp:DropDownList ID="ddlCurrency" runat="server" 
                                        SelectedValue='<%# Eval("CurrencyID") %>' DataSourceID="ODS_Currency" 
                                        DataTextField="CurrencySymbol" DataValueField="ID">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ODS_Currency" runat="server" 
                                        SelectMethod="GetCurrencyList" TypeName="ByteCore.FerryBooking.Core.Currency">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    IsActive:</td>
                                <td>
                                    <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%# Eval("IsActive")==null ?false:Eval("IsActive") %>' />
                                    (Check for "Yes")</td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Logo:</td>
                                <td>
                                <asp:FileUpload ID="FU_Logo" runat="server" /></td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Terms:</td>
                                <td>
                                    <asp:TextBox ID="txtTerms" runat="server" TextMode="MultiLine" Width="300px" Text='<%# Eval("Terms") %>'></asp:TextBox></td>
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
                <asp:ObjectDataSource ID="ODS_CompanyEdit" runat="server" 
                    SelectMethod="GetById" TypeName="ByteCore.FerryBooking.Core.Company">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="GV_OperatorList" Name="id" 
                            PropertyName="SelectedValue" Type="Int32" />
                        <asp:Parameter DefaultValue="false" Name="shouldLock" Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
