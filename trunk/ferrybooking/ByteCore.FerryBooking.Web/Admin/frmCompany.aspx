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
                <asp:GridView ID="GV_OperatorList" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True" AllowSorting="True" DataKeyNames="ID">
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
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="btnAdd_Click" CausesValidation="False" /></td>
        </tr>
        <tr>
            <td>
                <br />
                <asp:FormView ID="FV_Operator" runat="server" Width="100%" DefaultMode="Insert">
                    <InsertItemTemplate>
                        <table class="FormCellLabel" border="0" cellpadding="2" cellspacing="0">
                            <tr>
                                <td colspan="2" class="FormTableHeader">
                                    <asp:Label ID="lblHeader" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="FormCellLabel">
                                    Name:</td>
                                <td class="FormCellValue">
                                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("OperatorName") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtName"
                                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="FormCellLabel">
                                    Short Name:</td>
                                <td class="FormCellValue">
                                    <asp:TextBox ID="txtShortName" runat="server" Text='<%# Bind("OperatorShortName") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtShortName"
                                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td class="FormCellLabel">
                                    Currency:</td>
                                <td class="FormCellValue">
                                    <asp:DropDownList ID="ddlCurrency" runat="server" 
                                        SelectedValue='<%# Bind("CurrencyID") %>'>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td class="FormCellLabel">
                                    IsActive:</td>
                                <td class="FormCellValue">
                                    <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%# Bind("IsActive") %>' />
                                    (Check for "Yes")</td>
                            </tr>
                            <tr>
                                <td class="FormCellLabel">
                                    Logo:</td>
                                <td class="FormCellValue">
                                    <asp:FileUpload ID="FU_Logo" runat="server" /></td>
                            </tr>
                            <tr>
                                <td class="FormCellLabel">
                                    Terms:</td>
                                <td class="FormCellValue">
                                    <asp:TextBox ID="txtTerms" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="FormCellLabel">
                                </td>
                                <td class="FormCellValue">
                                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                        Text="Insert">
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Text="Cancel">
                                    </asp:LinkButton></td>
                            </tr>
                        </table>
                    </InsertItemTemplate>
                    <EditItemTemplate>
                        <table class="FormCellLabel" border="0" cellpadding="2" cellspacing="0">
                            <tr>
                                <td colspan="2" class="FormTableHeader">
                                    <asp:Label ID="lblHeader" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="FormCellLabel">
                                    Name:</td>
                                <td class="FormCellValue">
                                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("OperatorName") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtName"
                                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td class="FormCellLabel">
                                    Short Name:</td>
                                <td class="FormCellValue">
                                    <asp:DropDownList ID="ddlCurrency" runat="server" 
                                        SelectedValue='<%# Bind("CurrencyID") %>'>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td class="FormCellLabel">
                                    IsActive:</td>
                                <td class="FormCellValue">
                                    <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%# Bind("IsActive") %>' />
                                    (Check for "Yes")</td>
                            </tr>
                            <tr>
                                <td class="FormCellLabel">
                                    Logo:</td>
                                <td class="FormCellValue">
                                <asp:FileUpload ID="FU_Logo" runat="server" /></td>
                            </tr>
                            <tr>
                                <td class="FormCellLabel">
                                    Terms:</td>
                                <td class="FormCellValue">
                                    <asp:TextBox ID="txtTerms" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="FormCellLabel">
                                </td>
                                <td class="FormCellValue">
                                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                                        Text="Update"></asp:LinkButton>
                                    <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Text="Cancel"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                </asp:FormView>
            </td>
        </tr>
    </table>
</asp:Content>
