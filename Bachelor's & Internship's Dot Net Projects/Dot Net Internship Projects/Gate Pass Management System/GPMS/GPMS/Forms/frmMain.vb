Imports System.Windows.Forms
'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.Shared
Public Class frmMain

   
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ctl As Control
        For Each ctl In Me.Controls
            If TypeOf ctl Is MdiClient Then
                ctl.BackColor = Me.BackColor
            End If

        Next

        
        DisableMenus()
        DisableTools()
        'SetMenus()
        CurrentUser.GetSysInfo()
        Company.GetInfo()
        Me.Text = "GPMS " & " V" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & " - " & CName
        stbUser.Text = "User: NONE" & CurrentUser.UserName
        stbSystem.Text = "System: " & CurrentUser.SystemName
        stbApp.Text = My.Application.Info.Title '& " " & My.Application.Info.Copyright
        'stbLocation.Text = "Location: " & LocationIDtoName(CurrentLocationID)
        stbVersion.Text = "Version: " & My.Application.Info.Version.ToString
        Dim D As New DAL.DAL
        stbDatabase.Text = "Database: " & D.DBName
        D = Nothing


    End Sub
    Public Sub SetMenus()
        Dim D As New DAL.DAL
        Dim DT As New DataTable
        DT = D.GetDataTable("Select * from vwUserRights where UserID = " & CurrentUser.UserID & " and (rightControlType='Form' or rightControlType='Menu')")
        For N As Long = 0 To DT.Rows.Count - 1
            EnableMenuItem(DT.Rows(N)("rightName"))
        Next
        SetTools()
        
    End Sub
    Sub EnableMenuItem(ByVal mName As String)
        Dim X As ToolStripMenuItem
        Dim Y As ToolStripMenuItem
        For Each X In Me.MenuStrip.Items
            'MsgBox(X.Name)
            For N As Integer = 0 To X.DropDownItems.Count - 1
                If TypeOf X.DropDownItems(N) Is ToolStripMenuItem Then
                    'MsgBox(X.DropDownItems(N).Name)
                    If X.DropDownItems(N).Name = mName Then
                        X.DropDownItems(N).Enabled = True
                    End If
                    Y = X.DropDownItems(N)
                    For M As Integer = 0 To Y.DropDownItems.Count - 1
                        If TypeOf Y.DropDownItems(M) Is ToolStripMenuItem Then
                            If Y.DropDownItems(M).Name = mName Then
                                Y.DropDownItems(M).Enabled = True
                            End If

                            'MsgBox(Y.DropDownItems(M).Name)
                        End If
                    Next
                End If
            Next
        Next
    End Sub
    Sub SetTools()
        
        VendorToolStripButton.Enabled = AddEditVendorToolStripMenuItem.Enabled
        ItemsToolStripButton.Enabled = AddEditItemToolStripMenuItem.Enabled
        DepartmentsToolStripButton.Enabled = DepartmentsToolStripMenuItem.Enabled
        SectionsToolStripButton.Enabled = SectionsToolStripMenuItem.Enabled

        IndentToolStripButton.Enabled = AddIndentToolStripMenuItem.Enabled
        ApproveIndentToolStripButton.Enabled = IndentApprovalToolStripMenuItem.Enabled
        DeliveryChallanToolStripButton.Enabled = DeliveryChallanToolStripMenuItem.Enabled
        InwardGatePassToolStripButton.Enabled = InwardGatePassToolStripMenuItem.Enabled
        OutwardGatePassToolStripButton.Enabled = OutwardGatePassToolStripMenuItem.Enabled

        SettingsToolStripButton.Enabled = SettingsToolStripMenuItem.Enabled
        UserManagementToolStripButton.Enabled = UserManagementToolStripMenuItem.Enabled
        BackupDatabaseToolStripButton.Enabled = BackupDatabaseToolStripMenuItem.Enabled
        RestoreDatabaseToolStripButton.Enabled = RestoreDatabaseToolStripMenuItem.Enabled

    End Sub
    Sub DisableMenus()
        DisableMenu(FileMenu)
        DisableMenu(TransactionToolStripMenuItem)
        DisableMenu(ReportsToolStripMenuItem)
        DisableMenu(ToolsMenu)



        LoginToolStripMenuItem.Enabled = True
        ExitToolStripMenuItem.Enabled = True

        'UnitOfMeasurementToolStripMenuItem.Enabled = True
        'DepartmentsToolStripMenuItem.Enabled = True
        'SectionsToolStripMenuItem.Enabled = True
        'TestToolStripMenuItem.Enabled = True

    End Sub
    Sub DisableMenu(ByVal MN As ToolStripMenuItem)
        For Each MI As ToolStripMenuItem In MN.DropDownItems.OfType(Of ToolStripMenuItem)()
            MI.Enabled = False
            DisableMenu(MI)
        Next
    End Sub





    Sub DisableTools()
        For Each T As ToolStripButton In ToolStrip1.Items.OfType(Of ToolStripButton)()
            T.Enabled = False
        Next
        LoginToolStripButton.Enabled = True
        ExitToolStripButton.Enabled = True
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Are you sure you want to close this application?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Exit " & My.Application.Info.Title) = MsgBoxResult.No Then
            e.Cancel = True
        Else
            MsgBox("Thank you for using " & My.Application.Info.Title, MsgBoxStyle.Information, "SciTechIS Team")
            End
        End If
    End Sub
    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip1.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginToolStripMenuItem.Click, LoginToolStripButton.Click
        If LoginToolStripMenuItem.Text = "&Login" Then
            Dim L As New frmLogin
            'L.MdiParent = Me
            L.ShowDialog()
            If L.DialogResult = Windows.Forms.DialogResult.OK Then
                LoginToolStripMenuItem.Text = "&Logout"
                LoginToolStripButton.ToolTipText = "Logout"
                LoginToolStripButton.Image = Global.GPMS.My.Resources.Lock_Unlock_icon48
                LoginToolStripMenuItem.Image = Global.GPMS.My.Resources.Lock_Unlock_icon24
                stbUser.Text = "User : " & CurrentUser.UserName
                Me.Text = "GPMS " & " V" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & " - " & CName & " - [" & CurrentUser.UserName & "]"
                SetMenus()
            End If

        ElseIf LoginToolStripMenuItem.Text = "&Logout" Then
            If MsgBox("Are you sure you want to log out?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, CName) = MsgBoxResult.Yes Then
                LoginToolStripMenuItem.Text = "&Login"
                LoginToolStripButton.ToolTipText = "Login"
                LoginToolStripButton.Image = Global.GPMS.My.Resources.Lock_Lock_icon_48
                LoginToolStripMenuItem.Image = Global.GPMS.My.Resources.Lock_Lock_icon_24
                Me.Text = "POS Net " & " V" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & " - " & CName
                DisableMenus()
                DisableTools()
                'EnableMenus(False)
            End If
        End If
    End Sub

    'Private Sub HeadAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HeadAccountsToolStripMenuItem.Click
    '    frmAccountHead.MdiParent = Me
    '    frmAccountHead.Show()
    'End Sub

    'Private Sub ControlAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlAccountsToolStripMenuItem.Click
    '    frmAccountControl.MdiParent = Me
    '    frmAccountControl.Show()
    'End Sub

    'Private Sub AddEditAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEditAccountToolStripMenuItem.Click, AccountsToolStripButton.Click
    '    frmAccounts.MdiParent = Me
    '    frmAccounts.Show()
    'End Sub

    'Private Sub ViewAllAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewAllAccountsToolStripMenuItem.Click
    '    frmAccountsAll.MdiParent = Me
    '    frmAccountsAll.Show()
    'End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click, ExitToolStripButton.Click
        Me.Close()
    End Sub

    Private Sub AddEditVendorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEditVendorToolStripMenuItem.Click, VendorToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        frmVendors.MdiParent = Me
        frmVendors.Show()
        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub ViewAllVendorsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewAllVendorsToolStripMenuItem.Click
    '    frmVendorsAll.MdiParent = Me
    '    frmVendorsAll.Show()
    'End Sub

    'Private Sub AddEditCustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEditCustomerToolStripMenuItem.Click, CustomerToolStripButton.Click
    '    frmCustomers.MdiParent = Me
    '    frmCustomers.Show()
    'End Sub

    'Private Sub ViewAllCustomersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewAllCustomersToolStripMenuItem.Click
    '    frmCustomersAll.MdiParent = Me
    '    frmCustomersAll.Show()

    'End Sub

    'Private Sub AddEditEmployeeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEditEmployeeToolStripMenuItem.Click, EmployeeToolStripButton.Click
    '    frmEmployees.MdiParent = Me
    '    frmEmployees.Show()

    'End Sub

    'Private Sub stbSystem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbSystem.Click

    'End Sub

    'Private Sub ViewAllEmployeesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewAllEmployeesToolStripMenuItem.Click
    '    frmEmployeesAll.MdiParent = Me
    '    frmEmployeesAll.Show()
    'End Sub

    Private Sub ItemCategoriesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemCategoriesToolStripMenuItem.Click
        frmItemCategories.MdiParent = Me
        frmItemCategories.Show()
    End Sub

    'Private Sub ItemCompaniesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemCompaniesToolStripMenuItem.Click
    '    frmItemCompanies.MdiParent = Me
    '    frmItemCompanies.Show()
    'End Sub

    Private Sub AddEditItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEditItemToolStripMenuItem.Click, ItemsToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        frmItems.MdiParent = Me
        'frmItems.WindowState = FormWindowState.Maximized
        frmItems.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub UserManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserManagementToolStripMenuItem.Click, UserManagementToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        frmUsers1.MdiParent = Me
        frmUsers1.Show()
        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub CashPaymentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashPaymentsToolStripMenuItem.Click, CashPaymentToolStripButton.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmCashPayment.MdiParent = Me
    '    frmCashPayment.Show()
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub TestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestToolStripMenuItem.Click
    '    frmPasswordRecover.MdiParent = Me
    '    frmPasswordRecover.Show()
    'End Sub

    'Private Sub CashReceiveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashReceiveToolStripMenuItem.Click, CashReceiveToolStripButton.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmCashReceive.MdiParent = Me
    '    frmCashReceive.Show()
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub GeneralVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneralVoucherToolStripMenuItem.Click, GenralVoucerToolStripButton.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmGeneralJournal.MdiParent = Me
    '    frmGeneralJournal.Show()
    '    Me.Cursor = Cursors.Default

    'End Sub

    'Private Sub PurchaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseToolStripMenuItem.Click, PurchaseToolStripButton.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmPurchase.MdiParent = Me
    '    frmPurchase.WindowState = FormWindowState.Maximized
    '    frmPurchase.Show()
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub PurchaseReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseReturnToolStripMenuItem.Click, PurchaseReturnToolStripButton.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmPurchaseReturns.MdiParent = Me
    '    frmPurchaseReturns.Show()
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub IssueStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IssueStockToolStripMenuItem.Click, StockTransferToolStripButton.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmStockTransfer.MdiParent = Me
    '    frmStockTransfer.Show()
    '    Me.Cursor = Cursors.Default


    'End Sub

    'Private Sub RegistrationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrationToolStripMenuItem.Click
    '    frmRegistration.ShowDialog()

    'End Sub

    'Private Sub ItemsListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemsListToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmItemList.MdiParent = Me
    '    frmItemList.Show()
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub AccountTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountTransactionsToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmAccountTransactions.MdiParent = Me
    '    frmAccountTransactions.Show()
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub AccountBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountBalanceToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmAccountsBalances.MdiParent = Me
    '    frmAccountsBalances.Show()
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub ChartOfAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChartOfAccountToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim D As New DAL.DAL
    '    Dim ConnInfo As New ConnectionInfo()
    '    Dim T As Table
    '    Dim R As New rptChartOfAccounts

    '    With ConnInfo
    '        .ServerName = D.ServerName
    '        .DatabaseName = D.DBName
    '        .UserID = D.UserName
    '        .Password = D.Password
    '    End With
    '    For Each T In R.Database.Tables
    '        T.LogOnInfo.ConnectionInfo = ConnInfo
    '        T.ApplyLogOnInfo(T.LogOnInfo)
    '    Next
    '    R.DataDefinition.FormulaFields("CName").Text = "'" & CName & "'"
    '    R.DataDefinition.FormulaFields("CAddress").Text = "'" & CAddress & "'"
    '    R.DataDefinition.FormulaFields("CPhone").Text = "'" & CPhone & "'"
    '    R.DataDefinition.FormulaFields("Period").Text = "'For the period ended on " & Format(Now.Date, "dd-MMM-yy") & "'"
    '    If Not R.HasRecords Then
    '        MsgBox("No records found against your selection", vbInformation, CName)
    '        R.Dispose()
    '        Me.Cursor = Cursors.Default
    '        Exit Sub
    '    End If
    '    Dim F As New frmReport
    '    F.CRV.ReportSource = R
    '    F.MdiParent = Me.MdiParent
    '    F.Text = "Chart of Accounts"
    '    F.CRV.ShowGroupTreeButton = True
    '    F.WindowState = FormWindowState.Maximized
    '    F.Show()
    '    F.CRV.Refresh()
    '    F.CRV.Zoom(1)
    '    F.CRV.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub GrossMarginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrossMarginToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmGrossMargin.MdiParent = Me
    '    frmGrossMargin.Show()
    '    Me.Cursor = Cursors.Default

    'End Sub

    'Private Sub TrialBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrialBalanceToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim D As New DAL.DAL
    '    Dim ConnInfo As New ConnectionInfo()
    '    Dim T As Table
    '    Dim R As New rptTrialBalance
    '    With ConnInfo
    '        .ServerName = D.ServerName
    '        .DatabaseName = D.DBName
    '        .UserID = D.UserName
    '        .Password = D.Password
    '    End With
    '    For Each T In R.Database.Tables
    '        T.LogOnInfo.ConnectionInfo = ConnInfo
    '        T.ApplyLogOnInfo(T.LogOnInfo)
    '    Next
    '    Dim F As New frmReport

    '    R.DataDefinition.FormulaFields("CName").Text = "'" & CName & "'"
    '    R.DataDefinition.FormulaFields("CAddress").Text = "'" & CAddress & "'"
    '    R.DataDefinition.FormulaFields("CPhone").Text = "'" & CPhone & "'"
    '    R.DataDefinition.FormulaFields("Period").Text = "'For the period ended on " & Format(Now.Date, "dd-MMM-yy") & "'"

    '    F.MdiParent = Me
    '    F.Text = "Trial Balance"
    '    F.CRV.ReportSource = R
    '    'F.CRV.DisplayGroupTree = False
    '    F.CRV.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
    '    F.CRV.ShowGroupTreeButton = False
    '    F.Text = Me.Text
    '    F.WindowState = FormWindowState.Maximized
    '    F.Show()
    '    F.CRV.Show()
    '    F.CRV.Zoom(1)
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub LedgerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmLedgerReport.MdiParent = Me
    '    frmLedgerReport.Show()
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub VendorsListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VendorsListToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim D As New DAL.DAL
    '    Dim ConnInfo As New ConnectionInfo()
    '    Dim T As Table
    '    Dim R As New rptVendors
    '    With ConnInfo
    '        .ServerName = D.ServerName
    '        .DatabaseName = D.DBName
    '        '.UserID = D.UserName
    '        '.Password = D.Password
    '        .IntegratedSecurity = True
    '    End With
    '    For Each T In R.Database.Tables
    '        T.LogOnInfo.ConnectionInfo = ConnInfo
    '        T.ApplyLogOnInfo(T.LogOnInfo)
    '    Next
    '    Dim F As New frmReport

    '    R.DataDefinition.FormulaFields("CName").Text = "'" & CName & "'"
    '    R.DataDefinition.FormulaFields("CAddress").Text = "'" & CAddress & "'"
    '    R.DataDefinition.FormulaFields("CPhone").Text = "'" & CPhone & "'"
    '    F.MdiParent = Me
    '    F.Text = "Vendor List"
    '    F.CRV.ReportSource = R
    '    'F.CRV.DisplayGroupTree = False
    '    F.CRV.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
    '    F.CRV.ShowGroupTreeButton = False
    '    F.Text = Me.Text
    '    F.WindowState = FormWindowState.Maximized
    '    F.Show()
    '    F.CRV.Show()
    '    F.CRV.Zoom(1)
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub CustomersListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersListToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim D As New DAL.DAL
    '    Dim ConnInfo As New ConnectionInfo()
    '    Dim T As Table
    '    Dim R As New rptCustomers
    '    With ConnInfo
    '        .ServerName = D.ServerName
    '        .DatabaseName = D.DBName
    '        .UserID = D.UserName
    '        .Password = D.Password
    '    End With
    '    For Each T In R.Database.Tables
    '        T.LogOnInfo.ConnectionInfo = ConnInfo
    '        T.ApplyLogOnInfo(T.LogOnInfo)
    '    Next
    '    Dim F As New frmReport

    '    R.DataDefinition.FormulaFields("CName").Text = "'" & CName & "'"
    '    R.DataDefinition.FormulaFields("CAddress").Text = "'" & CAddress & "'"
    '    R.DataDefinition.FormulaFields("CPhone").Text = "'" & CPhone & "'"
    '    F.MdiParent = Me
    '    F.Text = "Vendor List"
    '    F.CRV.ReportSource = R
    '    'F.CRV.DisplayGroupTree = False
    '    F.CRV.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
    '    F.CRV.ShowGroupTreeButton = False
    '    F.Text = Me.Text
    '    F.WindowState = FormWindowState.Maximized
    '    F.Show()
    '    F.CRV.Show()
    '    F.CRV.Zoom(1)
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub EmployeesListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeesListToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim D As New DAL.DAL
    '    Dim ConnInfo As New ConnectionInfo()
    '    Dim T As Table
    '    Dim R As New rptEmployees
    '    With ConnInfo
    '        .ServerName = D.ServerName
    '        .DatabaseName = D.DBName
    '        .UserID = D.UserName
    '        .Password = D.Password
    '    End With
    '    For Each T In R.Database.Tables
    '        T.LogOnInfo.ConnectionInfo = ConnInfo
    '        T.ApplyLogOnInfo(T.LogOnInfo)
    '    Next
    '    Dim F As New frmReport

    '    R.DataDefinition.FormulaFields("CName").Text = "'" & CName & "'"
    '    R.DataDefinition.FormulaFields("CAddress").Text = "'" & CAddress & "'"
    '    R.DataDefinition.FormulaFields("CPhone").Text = "'" & CPhone & "'"
    '    F.MdiParent = Me
    '    F.Text = "Vendor List"
    '    F.CRV.ReportSource = R
    '    'F.CRV.DisplayGroupTree = False
    '    F.CRV.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
    '    F.CRV.ShowGroupTreeButton = False
    '    F.Text = Me.Text
    '    F.WindowState = FormWindowState.Maximized
    '    F.Show()
    '    F.CRV.Show()
    '    F.CRV.Zoom(1)
    '    Me.Cursor = Cursors.Default
    'End Sub


    'Private Sub BasicPurchaseReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BasicPurchaseReportToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmPurchaseReport.MdiParent = Me
    '    frmPurchaseReport.Show()
    '    Me.Cursor = Cursors.Default

    'End Sub

    'Private Sub AdvancePurchaseReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvancePurchaseReportToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmPurchaseReportAdvance.MdiParent = Me
    '    frmPurchaseReportAdvance.Show()
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub BasicSaleReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BasicSaleReportToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmSaleReport.MdiParent = Me
    '    frmSaleReport.Show()
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub CashBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashBookToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmCashBook.MdiParent = Me
    '    frmCashBook.Show()
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub ExpenseReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpenseReportToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmExpenseReport.MdiParent = Me
    '    frmExpenseReport.Show()
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub IncomeStatementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncomeStatementToolStripMenuItem.Click

    'End Sub

    'Private Sub AdvanceSaleReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvanceSaleReportToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmSaleReportAdvance.MdiParent = Me
    '    frmSaleReportAdvance.Show()
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub ItemLedgerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemLedgerToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmItemLedger.MdiParent = Me
    '    frmItemLedger.Show()
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub StockValueReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockValueReportToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmStockAndValueReport.MdiParent = Me
    '    frmStockAndValueReport.Show()
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub EmployeeSaleReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeSaleReportToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmSaleReportEmployee.MdiParent = Me
    '    frmSaleReportEmployee.Show()
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub ManageShiftsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageShiftsToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmShifts.MdiParent = Me
    '    frmShifts.Show()
    '    Me.Cursor = Cursors.Default
    'End Sub


    'Private Sub StockTransferReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockTransferReportToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmStockTransferReport.MdiParent = Me
    '    frmStockTransferReport.Show()
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub TopSellingItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TopSellingItemsToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmTopSellingItems.MdiParent = Me
    '    frmTopSellingItems.Show()
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub PrintBarcodesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBarcodesToolStripMenuItem.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    frmPrintBarcode.MdiParent = Me
    '    frmPrintBarcode.Show()
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub AdvanceStockReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvanceStockReportToolStripMenuItem.Click
    '    MsgBox("This feature is not available in demo version", MsgBoxStyle.Information, CName)


    'End Sub





    'Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseAllToolStripMenuItem.Click
    '    For Each ChildForm As Form In Me.MdiChildren
    '        ChildForm.Close()
    '    Next
    'End Sub

    'Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
    '    frmAbout.ShowDialog()

    'End Sub

    Private Sub UnitOfMeasurementToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UnitOfMeasurementToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        frmItemUnits.MdiParent = Me
        frmItemUnits.Show()
        Me.Cursor = Cursors.Default
    End Sub

   
    Private Sub DepartmentsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DepartmentsToolStripMenuItem.Click, DepartmentsToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        frmDepartments.MdiParent = Me
        frmDepartments.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SectionsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SectionsToolStripMenuItem.Click, SectionsToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        frmSections.MdiParent = Me
        frmSections.Show()
        Me.Cursor = Cursors.Default
    End Sub

    
    Private Sub AddIndentToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddIndentToolStripMenuItem.Click, IndentToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        frmIndent.MdiParent = Me
        frmIndent.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TestToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TestToolStripMenuItem.Click
        frmItemsAdd.MdiParent = Me
        frmItemsAdd.Show()
    End Sub

    
    Private Sub IndentApprovalToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles IndentApprovalToolStripMenuItem.Click, IndentApprovalToolStripMenuItem.Click, ApproveIndentToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        frmApproveIndent.MdiParent = Me
        frmApproveIndent.Show()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        frmChangePassword.MdiParent = Me
        frmChangePassword.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ViewAllItemsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ViewAllItemsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        frmAllItemsShort.MdiParent = Me
        frmAllItemsShort.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SettingsToolStripMenuItem.Click, SettingsToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        frmSettings.MdiParent = Me
        frmSettings.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DeliveryChallanToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeliveryChallanToolStripMenuItem.Click, DeliveryChallanToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        frmDeliveryChallan.MdiParent = Me
        frmDeliveryChallan.Show()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub InwardGatePassToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles InwardGatePassToolStripMenuItem.Click, InwardGatePassToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        frmInwardGatePass.MdiParent = Me
        frmInwardGatePass.Show()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub StoreReceiptNoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StoreReceiptNoteToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        frmStoreReceiptNote.MdiParent = Me
        frmStoreReceiptNote.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub OutwardGatePassToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutwardGatePassToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        frmOutwardGatePass.MdiParent = Me
        frmOutwardGatePass.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub OutwardGatePassToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutwardGatePassToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        frmOutwardGatePass.MdiParent = Me
        frmOutwardGatePass.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub AccountBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountBalanceToolStripMenuItem.Click

    End Sub
End Class
