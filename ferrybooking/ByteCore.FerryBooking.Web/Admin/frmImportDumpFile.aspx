<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true" CodeBehind="frmImportDumpFile.aspx.cs" Inherits="ByteCore.FerryBooking.Web.frmImportDumpFile" Title="Import DumpFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="4">
        <tr>
            <td>
                <asp:RadioButtonList ID="rdoImportType" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                    OnSelectedIndexChanged="rdoImportType_SelectedIndexChanged">
                    <asp:ListItem Value="Fare">Import Fare Dump File</asp:ListItem>
                    <asp:ListItem Value="Schedule">Import Schedule Dump File</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Instruction:<br />
                1. Convert Excel file to CSV format;<br />
                2. Import process may take very long time (3-4 hours), please do not close browser and just let it running;<br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlFareDump" runat="server" Visible="False">
                    <asp:Label ID="lblFare" runat="server" Text="Please select an Excel file to import:"></asp:Label>
                    &nbsp;
                    <asp:FileUpload ID="FU_Fare" runat="server" />
                    <br />
                    <asp:Button ID="btnImportFare" runat="server" Text="Import Fare" OnClick="btnImportFare_Click" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlScheduleDump" runat="server" Visible="False">
                    <asp:Label ID="Label2" runat="server" Text="Please select an Excel file to import:"></asp:Label>
                    &nbsp;
                    <asp:FileUpload ID="FU_Schedule" runat="server" />
                    <br />
                    <asp:Button ID="btnImportSchedule" runat="server" Text="Import Schedule" 
                        onclick="btnImportSchedule_Click" />
                </asp:Panel>
            </td>
        </tr>
        <tr><td>
            <asp:Label ID="Label5" runat="server" Text="Import Result"></asp:Label>
            </td></tr>
        <tr>
            <td>
                <div class="GrdOutline">
                    <asp:GridView ID="GV_Result" runat="server" AutoGenerateColumns="False" 
                        Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Row #">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("RowNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Error Column Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("ErrColumnName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Error Column Data">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("ErrColumnData") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Error Description">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("ErrDescription") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="DataTableCell" />
                        <EmptyDataTemplate>
                            Import Success.
                        </EmptyDataTemplate>
                        <SelectedRowStyle CssClass="DataTableSelCell" />
                        <HeaderStyle CssClass="DataTableHeader" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
