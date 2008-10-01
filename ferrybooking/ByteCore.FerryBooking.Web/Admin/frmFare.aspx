<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true"
    CodeBehind="frmFare.aspx.cs" Inherits="ByteCore.FerryBooking.Web.frmFare" Title="Fare Management" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="4">
        <tr>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <table cellpadding="2" style="width: 100%">
                    <tr>
                        <td style="width: 58px">
                <asp:Label ID="lblOperator" runat="server" Text="Operator:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlOperator" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOperator_SelectedIndexChanged"
                    Width="200px">
                </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 58px">
                Route:
                        </td>
                        <td>
                <asp:DropDownList ID="ddlRoute" runat="server" Width="300px">
                </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 58px">
                Date:
                        </td>
                        <td>
                <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
                <asp:Image ID="imgStartDate" runat="server" ImageUrl="~/Images/calendar.gif" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate"
                    PopupButtonID="imgStartDate">
                </cc1:CalendarExtender>
                &nbsp;to
                <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                <asp:Image ID="imgEndDate" runat="server" ImageUrl="~/Images/calendar.gif" />
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEndDate"
                    PopupButtonID="imgEndDate">
                </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 58px">
                            &nbsp;</td>
                        <td>
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search"
                    CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <div class="GrdOutline">
                    <asp:GridView ID="GV_FareList" runat="server" AutoGenerateColumns="False" Width="100%"
                        AllowPaging="True" DataKeyNames="ID" OnSelectedIndexChanged="GV_FareList_SelectedIndexChanged"
                        OnRowDeleted="GV_FareList_RowDeleted" OnPageIndexChanging="GV_FareList_PageIndexChanging">
                        <Columns>                            
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEditFare" runat="server" CausesValidation="False" CommandName="EditFare"
                                        CommandArgument='<%#Eval("ID")%>' OnCommand="lbtnEditFare_Command">Edit</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField SelectText="Edit Items" ShowSelectButton="True" />
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
                            <asp:BoundField DataField="StartDate" HeaderText="Start Date" DataFormatString="{0:MMM dd, yyyy}" HtmlEncode="false" />
                            <asp:BoundField DataField="EndDate" HeaderText="End Date" DataFormatString="{0:MMM dd, yyyy}" HtmlEncode="false" />
                            <asp:BoundField DataField="ID" HeaderText="ID" />
                        </Columns>
                        <RowStyle CssClass="DataTableCell" />
                        <EmptyDataTemplate>
                            No result.
                        </EmptyDataTemplate>
                        <SelectedRowStyle CssClass="DataTableSelCell" />
                        <HeaderStyle CssClass="DataTableHeader" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <asp:Button ID="btnAdd" runat="server" Text="Add New Fare" OnClick="btnAdd_Click"
                    CausesValidation="False" />&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:FormView ID="FV_Fare" runat="server" Width="500px" OnItemCommand="FV_Fare_ItemCommand"
                    DataSourceID="ODS_FareEdit" DataKeyNames="ID">
                    <InsertItemTemplate>
                        <table class="FormCellLabel" width="500px" border="0" cellpadding="2" cellspacing="0">
                            <tr>
                                <td colspan="2" class="FormTableHeader">
                                    <asp:Label ID="lblHeader" runat="server">Add Fare</asp:Label>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Route:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlRoute" runat="server" Width="300px" DataSourceID="ODS_RouteInsert"
                                        DataTextField="FullName" DataValueField="ID">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ODS_RouteInsert" runat="server" SelectMethod="GetAllList"
                                        TypeName="ByteCore.FerryBooking.Core.Route"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Start Date:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtStartDate" runat="server" Width="150px"></asp:TextBox>
                                    &nbsp;(i.e. 2008/05/01)
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txtStartDate" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    End Date:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEndDate" runat="server" Width="150px"></asp:TextBox>
                                    &nbsp;(i.e. 2008/09/30)
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="txtEndDate" ErrorMessage="*"></asp:RequiredFieldValidator>
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
                                        Text="Cancel"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </InsertItemTemplate>
                    <EditItemTemplate>
                        <table class="FormCellLabel" width="500px" border="0" cellpadding="2" cellspacing="0">
                            <tr>
                                <td colspan="2" class="FormTableHeader">
                                    <asp:Label ID="lblHeader0" runat="server">Edit Fare</asp:Label>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Route:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlRoute" runat="server" Width="300px" SelectedValue='<%# Eval("RoutesId") %>'
                                        DataSourceID="ODS_RouteEdit" DataTextField="FullName" DataValueField="ID">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ODS_RouteEdit" runat="server" SelectMethod="GetAllList"
                                        TypeName="ByteCore.FerryBooking.Core.Route"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    Start Date:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtStartDate" Text='<%# Eval("StartDate","{0:yyyy/MM/dd}") %>' runat="server"
                                        Width="150px"></asp:TextBox>
                                    &nbsp;(i.e. 2008/05/01)
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txtStartDate" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                    End Date:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEndDate" Text='<%# Eval("EndDate","{0:yyyy/MM/dd}") %>' runat="server"
                                        Width="150px"></asp:TextBox>
                                    &nbsp;(i.e. 2008/09/30)
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="txtEndDate" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="FormTable">
                                <td>
                                </td>
                                <td>
                                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="DoUpdate"
                                        CommandArgument='<%# Eval("ID") %>' Text="Update"></asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="DoCancel"
                                        Text="Cancel"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="ODS_FareEdit" runat="server" SelectMethod="GetById" TypeName="ByteCore.FerryBooking.Core.Fare">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="GV_FareList" Name="id" PropertyName="SelectedValue"
                            Type="Int32" />
                        <asp:Parameter DefaultValue="false" Name="shouldLock" Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlFareItems" runat="server" Width="100%">
                    <table width="100%" border="0" cellpadding="0" cellspacing="4">
                        <tr>
                            <td>
                                Fare Category:&nbsp;<asp:DropDownList ID="ddlFareCategory" runat="server" 
                                    Width="200px">
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnSubSearch" runat="server" OnClick="btnSubSearch_Click" Text="Search"
                                    CausesValidation="False" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="GrdOutline">
                                    <asp:GridView ID="GV_FareItemList" runat="server" AutoGenerateColumns="False" Width="100%"
                                        AllowPaging="True" DataKeyNames="ID" OnSelectedIndexChanged="GV_FareItemList_SelectedIndexChanged"
                                        OnRowDeleted="GV_FareItemList_RowDeleted" OnPageIndexChanging="GV_FareItemList_PageIndexChanging">
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
                                                    <asp:Label ID="lblOperator" runat="server" Text='<%# Eval("FareType.Operator.CompanyShortName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Category">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("FareType.Category.CategoryName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:C}" HtmlEncode="false" />
                                            <asp:BoundField DataField="RangeStart" HeaderText="Range Start" />
                                            <asp:BoundField DataField="RangeEnd" HeaderText="Range End" />
                                            <asp:BoundField DataField="ByFootAmount" HeaderText="By Foot Amount" DataFormatString="{0:C}" HtmlEncode="false" />
                                            <asp:BoundField DataField="ID" HeaderText="ID" />
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
                                <asp:Button ID="btnAddFareItem" runat="server" Text="Add New Fare Item" OnClick="btnAddItem_Click"
                                    CausesValidation="False" />&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblSubMessage" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:FormView ID="FV_FareItem" runat="server" Width="500px" OnItemCommand="FV_FareItem_ItemCommand"
                                    DataSourceID="ODS_FareItemEdit" DataKeyNames="ID" 
                                    onprerender="FV_FareItem_PreRender" ondatabound="FV_FareItem_DataBound">
                                    <InsertItemTemplate>
                                        <table class="FormCellLabel" width="500px" border="0" cellpadding="2" cellspacing="0">
                                            <tr>
                                                <td colspan="2" class="FormTableHeader">
                                                    <asp:Label ID="lblHeader" runat="server">Add Fare Item</asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="FormTable">
                                                <td>
                                                    Fare:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="lblFare" runat="server" Width="150px" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr class="FormTable">
                                                <td>
                                                    Fare Type:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlFareType" runat="server" Width="300px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr class="FormTable">
                                                <td>
                                                    Range Start:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRangeStart" runat="server" Width="150px"></asp:TextBox>                                                    
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                        ControlToValidate="txtRangeStart" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr class="FormTable">
                                                <td>
                                                    Range End:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRangeEnd" runat="server" Width="150px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                        ControlToValidate="txtRangeEnd" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr class="FormTable">
                                                <td>
                                                    Amount:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAmount" runat="server" Width="150px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                        ControlToValidate="txtAmount" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr class="FormTable">
                                                <td>
                                                    By Foot Amount:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtByFootAmount" runat="server" Width="150px"></asp:TextBox>
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
                                                        Text="Cancel"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </InsertItemTemplate>
                                    <EditItemTemplate>
                                        <table class="FormCellLabel" width="500px" border="0" cellpadding="2" cellspacing="0">
                                            <tr>
                                                <td colspan="2" class="FormTableHeader">
                                                    <asp:Label ID="lblHeader0" runat="server">Edit Fare Item</asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="FormTable">
                                                <td>
                                                    Fare:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="lblFare" runat="server" Width="150px" Enabled="false" Text='<%# Eval("FareId") %>'>&lt;%# 
                                                    Eval(&quot;FareId&quot;) %&gt;</asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr class="FormTable">
                                                <td>
                                                    Fare Type:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlFareType" runat="server" Width="300px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr class="FormTable">
                                                <td>
                                                    Range Start:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRangeStart" runat="server" Width="150px" Text='<%# Eval("RangeStart") %>'>&lt;%# 
                                                    Eval(&quot;RangeStart&quot;) %&gt;</asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                        ControlToValidate="txtRangeStart" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr class="FormTable">
                                                <td>
                                                    Range End:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRangeEnd" runat="server" Width="150px" Text='<%# Eval("RangeEnd") %>'>&lt;%# 
                                                    Eval(&quot;RangeEnd&quot;) %&gt;</asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                        ControlToValidate="txtRangeEnd" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr class="FormTable">
                                                <td>
                                                    Amount:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAmount" runat="server" Width="150px" Text='<%# Eval("Amount") %>'>&lt;%# 
                                                    Eval(&quot;Amount&quot;) %&gt;</asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                        ControlToValidate="txtAmount" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr class="FormTable">
                                                <td>
                                                    By Foot Amount:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtByFootAmount" runat="server" Width="150px" Text='<%# Eval("ByFootAmount") %>'>&lt;%# 
                                                    Eval(&quot;ByFootAmount&quot;) %&gt;</asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr class="FormTable">
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="DoUpdate"
                                                        CommandArgument='<%# Eval("ID") %>' Text="Update"></asp:LinkButton>
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="DoCancel"
                                                        Text="Cancel"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </EditItemTemplate>
                                </asp:FormView>
                                <asp:ObjectDataSource ID="ODS_FareItemEdit" runat="server" SelectMethod="GetById"
                                    TypeName="ByteCore.FerryBooking.Core.FareItem">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="GV_FareItemList" Name="id" PropertyName="SelectedValue"
                                            Type="Int32" />
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
