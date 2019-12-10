<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DefaultCS.aspx.cs" Inherits="Telerik.GridExamplesCSharp.DataEditing.AllEditableColumns.DefaultCS"
    MasterPageFile="~/MasterPage.master" %>
 
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="styles.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:ConfiguratorPanel runat="server" ID="ConfigurationPanel1" Title="Configurator"
        Expanded="true">
        Switch the edit modes:
        <br />
        <div style="float: left; margin-left: 30px;">
            <asp:RadioButton ID="RadioButton1" AutoPostBack="True" Text="In-forms editing mode"
                runat="server" Checked="True" OnCheckedChanged="RadioCheckedChanged"></asp:RadioButton>
        </div>
        <div style="float: left;">
            <asp:RadioButton ID="RadioButton2" AutoPostBack="True" Text="In-line editing mode"
                runat="server" OnCheckedChanged="RadioCheckedChanged"></asp:RadioButton>
        </div>
        <div style="float: left; margin-left: 20px;">
            <asp:CheckBox ID="CheckBox1" Text="Allow multi-row edit" AutoPostBack="True" runat="server"
                OnCheckedChanged="CheckboxCheckedChanged"></asp:CheckBox>
        </div>
    </telerik:ConfiguratorPanel>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            //<![CDATA[
            function RowDblClick(sender, eventArgs) {
                sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
            }

            function gridCreated(sender, args) {
                if (sender.get_editIndexes && sender.get_editIndexes().length > 0) {
                    document.getElementById("OutPut").innerHTML = sender.get_editIndexes().join();
                }
                else {
                    document.getElementById("OutPut").innerHTML = "";
                }
            }
            //]]>
        </script>
    </telerik:RadCodeBlock>
    <div class="module" style="height: 20px; width: 350px;">
        <span style="font-weight: bold;">Edit indexes: </span><span id="OutPut" style="font-weight: bold;
            color: navy;"></span>
    </div>
    <telerik:RadAjaxManager ID="RadAjaxManager1" EnableAJAX="true" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadioButton1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="RadioButton2"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadioButton2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="RadioButton1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="CheckBox1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    
    <telerik:RadGrid ID="RadGrid1" GridLines="None" runat="server" AllowAutomaticDeletes="True"
        AllowAutomaticInserts="True" PageSize="10" AllowAutomaticUpdates="True" AllowPaging="True"
        AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnItemUpdated="RadGrid1_ItemUpdated"
        OnItemDeleted="RadGrid1_ItemDeleted" OnItemInserted="RadGrid1_ItemInserted" OnPreRender="RadGrid1_PreRender">
        <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
        <MasterTableView Width="100%" CommandItemDisplay="TopAndBottom" DataKeyNames="ProductID"
            DataSourceID="SqlDataSource1" HorizontalAlign="NotSet" AutoGenerateColumns="False">
            <Columns>
                <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn">
                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                </telerik:GridEditCommandColumn>
                <telerik:GridBoundColumn DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName"
                    UniqueName="ProductName" ColumnEditorID="GridTextBoxColumnEditor1">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                        <RequiredFieldValidator ForeColor="Red" Text="*This field is required">
                        </RequiredFieldValidator>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridDropDownColumn DataField="CategoryID" DataSourceID="SqlDataSource2"
                    HeaderText="Category" ListTextField="CategoryName" ListValueField="CategoryID"
                    UniqueName="CategoryID" ColumnEditorID="GridDropDownColumnEditor1">
                </telerik:GridDropDownColumn>
                <telerik:GridNumericColumn DataField="UnitsInStock" HeaderText="Units In Stock" SortExpression="UnitsInStock"
                    UniqueName="UnitsInStock" ColumnEditorID="GridNumericColumnEditor1">
                </telerik:GridNumericColumn>
                <telerik:GridBoundColumn DataField="QuantityPerUnit" HeaderText="Quantity Per Unit"
                    SortExpression="QuantityPerUnit" UniqueName="QuantityPerUnit" Visible="false"
                    EditFormColumnIndex="1" ColumnEditorID="GridTextBoxColumnEditor2">
                </telerik:GridBoundColumn>
                <telerik:GridCheckBoxColumn DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued"
                    UniqueName="Discontinued" EditFormColumnIndex="1">
                </telerik:GridCheckBoxColumn>
                <telerik:GridTemplateColumn HeaderText="UnitPrice" SortExpression="UnitPrice" UniqueName="TemplateColumn"
                    EditFormColumnIndex="1">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblUnitPrice" Text='<%# Eval("UnitPrice", "{0:C}") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <span>
                            <telerik:RadNumericTextBox runat="server" ID="tbUnitPrice" Width="40px" DbValue='<%# Bind("UnitPrice") %>'>
                            </telerik:RadNumericTextBox><span style="color: Red"><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                ControlToValidate="tbUnitPrice" ErrorMessage="*" runat="server">
                            </asp:RequiredFieldValidator></span> </span>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridButtonColumn ConfirmText="Delete this product?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Delete" ButtonType="ImageButton" CommandName="Delete" Text="Delete"
                    UniqueName="DeleteColumn">
                    <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                </telerik:GridButtonColumn>
            </Columns>
            <EditFormSettings ColumnNumber="2" CaptionDataField="ProductName" CaptionFormatString="Edit properties of Product {0}"
                InsertCaption="New Product">
                <FormTableItemStyle Wrap="False"></FormTableItemStyle>
                <FormCaptionStyle CssClass="EditFormHeader"></FormCaptionStyle>
                <FormMainTableStyle GridLines="None" CellSpacing="0" CellPadding="3"
                    Width="100%"></FormMainTableStyle>
                <FormTableStyle CellSpacing="0" CellPadding="2" Height="110px">
                </FormTableStyle>
                <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                <EditColumn ButtonType="ImageButton" InsertText="Insert Order" UpdateText="Update record"
                    UniqueName="EditCommandColumn1" CancelText="Cancel edit">
                </EditColumn>
                <FormTableButtonRowStyle HorizontalAlign="Right" CssClass="EditFormButtonRow"></FormTableButtonRowStyle>
            </EditFormSettings>
        </MasterTableView>
        <ClientSettings>
            <ClientEvents OnRowDblClick="RowDblClick" OnGridCreated="gridCreated"></ClientEvents>
        </ClientSettings>
    </telerik:RadGrid>
    <telerik:GridTextBoxColumnEditor ID="GridTextBoxColumnEditor1" runat="server" TextBoxStyle-Width="200px">
    </telerik:GridTextBoxColumnEditor>
    <telerik:GridTextBoxColumnEditor ID="GridTextBoxColumnEditor2" runat="server" TextBoxStyle-Width="150px">
    </telerik:GridTextBoxColumnEditor>
    <telerik:GridDropDownListColumnEditor ID="GridDropDownColumnEditor1" runat="server"
        DropDownStyle-Width="110px">
    </telerik:GridDropDownListColumnEditor>
    <telerik:GridNumericColumnEditor ID="GridNumericColumnEditor1" runat="server" NumericTextBox-Width="40px">
    </telerik:GridNumericColumnEditor>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString35 %>"
        DeleteCommand="DELETE FROM [Products] WHERE [ProductID] = @ProductID" InsertCommand="INSERT INTO [Products] ([ProductName], [CategoryID], [UnitPrice], [Discontinued], [QuantityPerUnit], [UnitsInStock]) VALUES (@ProductName, @CategoryID, @UnitPrice, @Discontinued, @QuantityPerUnit, @UnitsInStock)"
        SelectCommand="SELECT [ProductID], [ProductName], [CategoryID], [UnitPrice], [Discontinued], [QuantityPerUnit], [UnitsInStock] FROM [Products] WITH(NOLOCK)"
        UpdateCommand="UPDATE [Products] SET [ProductName] = @ProductName, [CategoryID] = @CategoryID, [UnitPrice] = @UnitPrice, [Discontinued] = @Discontinued, [QuantityPerUnit] = @QuantityPerUnit, [UnitsInStock] = @UnitsInStock WHERE [ProductID] = @ProductID">
        <DeleteParameters>
            <asp:Parameter Name="ProductID" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ProductName" Type="String"></asp:Parameter>
            <asp:Parameter Name="CategoryID" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="UnitPrice" Type="Decimal"></asp:Parameter>
            <asp:Parameter Name="Discontinued" Type="Boolean"></asp:Parameter>
            <asp:Parameter Name="QuantityPerUnit" Type="String"></asp:Parameter>
            <asp:Parameter Name="UnitsInStock" Type="Int16"></asp:Parameter>
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="ProductName" Type="String"></asp:Parameter>
            <asp:Parameter Name="CategoryID" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="UnitPrice" Type="Decimal"></asp:Parameter>
            <asp:Parameter Name="Discontinued" Type="Boolean"></asp:Parameter>
            <asp:Parameter Name="QuantityPerUnit" Type="String"></asp:Parameter>
            <asp:Parameter Name="UnitsInStock" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="ProductID" Type="Int32"></asp:Parameter>
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString35 %>"
        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [CategoryID], [CategoryName] FROM [Categories]">
    </asp:SqlDataSource>
</asp:Content>