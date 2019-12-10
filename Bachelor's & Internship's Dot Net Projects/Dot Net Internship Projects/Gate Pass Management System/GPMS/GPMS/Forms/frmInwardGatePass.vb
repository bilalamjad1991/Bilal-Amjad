Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmInwardGatePass
    Dim D As New DAL.DAL
    Dim DM As DAL.DAL.DataMode
    Dim ComboLoading As Boolean

    Private Sub frmDeliveryChallan_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If DM <> DAL.DAL.DataMode.SavedRecord Then
            MsgBox("Please save or cancel your changes", MsgBoxStyle.Information, CName)

            e.Cancel = True

        End If
    End Sub
    Private Sub frmDeliveryChallan_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LockAll(True)
        FillLastData()
        
        '''''''''''''''''''''''''''''
        fillStoreKeeper()
        fillGM()
        ''''''''''''''''''''''''''''''
        For Each C As DataGridViewColumn In Grid.Columns
            C.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        DM = DAL.DAL.DataMode.SavedRecord
    End Sub

    Sub CalcTotal()
        Dim N As Long
        For Each R As DataGridViewRow In Grid.Rows
            N += R.Cells("colQty").Value
        Next
        txtTotal.Text = N
    End Sub
    Sub LockAll(OK As Boolean)
        cmdAdd.Enabled = OK
        cmdSave.Enabled = Not OK
        cmdCancel.Enabled = Not OK
        cmdEdit.Enabled = OK
        cmdFind.Enabled = OK
        cmdPrint.Enabled = OK
        cmdClose.Enabled = OK
        fraGatePass.Enabled = Not OK
        fraDetail.Enabled = Not OK
    End Sub
    Sub ClearAll()
        txtGatePassNo.Text = ""
        txtRefNo.Text = ""
        dtDate.Value = Now.Date
        dtTime.Value = Now

        optHeadOffice.Checked = True
        fraReturn.Enabled = False
        txtOutGatePassNo.Text = ""
        dtOutDate.Value = Now.Date

        txtVehicleNo.Text = ""
        txtBiltyNo.Text = ""
        dtBiltyDate.Value = Now.Date

        txtPersonDelivered.Text = ""
        txtGateIncharge.Text = ""

        Grid.Rows.Clear()
        txtTotal.Text = ""
    End Sub


    Sub FillLastData()
        Dim IndID As String
        IndID = D.GetScaler("Select max(dcNo) from tblDeliveryChallans")
        If IndID = "" Then
            ClearAll()
        Else
            FillData(IndID)
        End If


    End Sub


    Private Sub cmdAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdAdd.Click
        ClearAll()
        txtGatePassNo.Text = GetNewGatePassNo("IN")
        LockAll(False)
        txtRefNo.Focus()
        DM = DAL.DAL.DataMode.NewRecord
    End Sub
    Function GetNewGatePassNo(gpType As String) As String

        'format = MMYY-000001
        '   Dim PreFix As String = Format(Now.Date, "yyMM") & "-"
        'Dim N As String = D.GetScaler("Select Max(gpSerialNo) from tblGatePass where gpSerialNo like '" & PreFix & "%' and gpType='" & gpType & "'")
        Dim N As String = D.GetScaler("Select Max(gpSerialNo) from tblGatePass where gpType='" & gpType & "'")
        If N = "" Then
            'Return PreFix & "000001"
            Return "000001"
        Else
            N = Mid(N, 6, 6)
            Dim X As Double = CDbl(N) + 1
            Select Case Len(CStr(X))
                Case 1 : N = "00000" & CStr(X)
                Case 2 : N = "0000" & CStr(X)
                Case 3 : N = "000" & CStr(X)
                Case 4 : N = "00" & CStr(X)
                Case 5 : N = "0" & CStr(X)
                Case 6 : N = CStr(X)

            End Select
            ' Return PreFix & N
            Return N
        End If

    End Function

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        LockAll(True)
        DM = DAL.DAL.DataMode.SavedRecord
        cmdAdd.Focus()
        ClearAll()
        FillLastData()

    End Sub

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdLoadIndent_Click(sender As System.Object, e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        frmApprovedIndentFind.MdiParent = frmMain
        frmApprovedIndentFind.Show()
        Me.Cursor = Cursors.Default
    End Sub


    Public Sub FillIndentData(IndentNo As String)
        Dim DT As DataTable
        DT = D.GetDataTable("Select * from vwApprovedIndentDetail where IndentNo = '" & IndentNo & "'")
        Grid.AllowUserToAddRows = True
        For Each R As DataRow In DT.Rows
            Dim GRow As DataGridViewRow = Grid.Rows(Grid.NewRowIndex).Clone
            With GRow
                .Cells(colItemID.Index).Value = R.Item("ItemID")
                .Cells(colDescription.Index).Value = R.Item("ItemDescription")
                .Cells(colUOM.Index).Value = R.Item("unitShortName")
                .Cells(colQty.Index).Value = R.Item("Qty")
            End With
            Grid.Rows.Add(GRow)

        Next
        Grid.AllowUserToAddRows = False
        CalcTotal()
    End Sub

    Private Sub Grid_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellContentClick

    End Sub

    Private Sub Grid_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellEndEdit
        'Dim R As DataGridViewRow
        'R = Grid.CurrentRow
        'If e.ColumnIndex = colQty.Index Or e.ColumnIndex = colUnitRate.Index Then
        '    R.Cells("colAmount").Value = Val(R.Cells("colQty").Value) * Val(R.Cells("colUnitRate").Value)
        'End If
        'CalcTotal()
    End Sub

    Private Sub Grid_CellValidating(sender As Object, e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles Grid.CellValidating
        'If e.ColumnIndex = colQty.Index Then
        '    If Val(Grid.CurrentRow.Cells("colQty").Value) = 0 Then
        '        MsgBox("Invalid quantity", MsgBoxStyle.Critical, CName)
        '        e.Cancel = True

        '    End If
        'End If
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        If Not DataIsValid() Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim qbMaster As New QueryBuilder("tblGatePass")
        Dim qbDetail As New QueryBuilder("tblGatePassDetail")
        Dim qStock As New QueryBuilder("tblStock") ' insert data into stock table
        Dim sqlMaster, sqlDetail, sqlStock As String
        With qbMaster
            .AddField("gpSerialNo", txtGatePassNo.Text, FieldType.Text)
            .AddField("gpType", "IN", FieldType.Text)
            .AddField("gpRefNo", txtRefNo.Text, FieldType.Text)
            .AddField("gpDate", dtDate.Value, FieldType.DateTime)
            .AddField("gpTime", dtTime.Value, FieldType.DateTime)
            If optHeadOffice.Checked Then
                .AddField("gpInwardType", "HO", FieldType.Text)
                .AddField("gpOutNo", "0", FieldType.Text)
                .AddField("gpOutDate", "01-01-1900", FieldType.DateTime)
            ElseIf optReturn.Checked Then
                .AddField("gpInwardType", "RET", FieldType.Text)
                .AddField("gpOutNo", txtOutGatePassNo.Text, FieldType.Text)
                .AddField("gpOutDate", dtOutDate.Value, FieldType.DateTime)
            End If
            .AddField("gpVehicleNo", txtVehicleNo.Text, FieldType.Text)
            .AddField("gpBiltyNo", txtBiltyNo.Text, FieldType.Text)
            .AddField("gpBiltyDate", dtBiltyDate.Value, FieldType.DateTime)
            .AddField("gpPersonDelivered", txtPersonDelivered.Text, FieldType.Text)
            .AddField("gpGateIncharge", txtGateIncharge.Text, FieldType.Text)

            .AddField("gpGM", cmbGM.Text, FieldType.Text)
            .AddField("gpStoreKeeper", cmbStorekeeper.Text, FieldType.Text)
            .AddField("gpSRN", 0, FieldType.Numeric)

            .AddField("gpRemarks", txtRemarks.Text, FieldType.Text)
            .AddField("gpCreatedBy", CurrentUser.UserID, FieldType.Numeric)
            .AddField("gpCretaedOn", Now, FieldType.DateTime)
            .AddField("gpSystem", CurrentUser.SystemName, FieldType.Text)

        End With
        If DM = DAL.DAL.DataMode.NewRecord Then
            sqlMaster = qbMaster.GetInsertQuery
        ElseIf DM = DAL.DAL.DataMode.EditRecord Then
            qbMaster.RemoveField("gpSerialNo")
            qbMaster.InsertDeleteFilterField("gpSerialNo", txtGatePassNo.Text, FieldType.Text)
            qbMaster.RemoveField("gpCreatedBy")
            qbMaster.RemoveField("gpCreatedOn")
            qbMaster.AddField("gpEditedBy", CurrentUser.UserID, FieldType.Text)
            qbMaster.AddField("gpEditedOn", Now, FieldType.DateTime)
            sqlMaster = qbMaster.GetUpdateQuery
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim C As New SqlConnection
        Dim COM As New SqlCommand
        Dim T As SqlTransaction
        Try
            C.ConnectionString = D.ConStr
            C.Open()
            T = C.BeginTransaction(IsolationLevel.ReadCommitted)
            COM.Connection = C
            COM.Transaction = T
            COM.CommandText = sqlMaster
            COM.ExecuteNonQuery()
            If DM = DAL.DAL.DataMode.EditRecord Then
                COM.CommandText = "Delete from tblGatePassDetail Where gpSerialNo = '" & txtGatePassNo.Text & "'"
                COM.ExecuteNonQuery()
            End If
            For Each R As DataGridViewRow In Grid.Rows
                With qbDetail
                    .AddField("gpSerialNo", txtGatePassNo.Text, FieldType.Text)
                    .AddField("gpType", "IN", FieldType.Text)
                    .AddField("ItemID", R.Cells("colItemID").Value, FieldType.Text)
                    .AddField("Quantity", Val1(R.Cells("colQty").Value), FieldType.Numeric)
                    .AddField("Brand", R.Cells("colBrand").Value, FieldType.Text)
                    .AddField("Remarks", "", FieldType.Text)

                End With
                sqlDetail = qbDetail.GetInsertQuery
                qbDetail.ClearFields()
                COM.CommandText = sqlDetail
                COM.ExecuteNonQuery()
            Next
            T.Commit()
        Catch ee As Exception
            T.Rollback()
            MsgBox("Following error occured while saving data" & vbCr & ee.Message & vbCr & "Contact SciTechIS", vbCritical, "SciTechIS")
            Me.Cursor = Cursors.Default
            Exit Sub
        Finally
            C = Nothing
            COM = Nothing
            qbMaster = Nothing
            qbDetail = Nothing
        End Try
        Me.Cursor = Cursors.Default
        MsgBox("Inward Gate Pass is saved", MsgBoxStyle.Information, CName)
        'ClearAll()
        FillLastData()
        LockAll(True)
        cmdAdd.Focus()
        DM = DAL.DAL.DataMode.SavedRecord
        ' SaveRec() ' function calling to insert data into tblStock

    End Sub
    ' function is used to insert record into tblStock ''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Sub SaveRec()
        '    Dim qStock As New QueryBuilder("tblStock") ' insert data into stock table
        Dim sqlStock As String
        Me.Cursor = Cursors.WaitCursor
        Dim C As New SqlConnection
        Dim COM As New SqlCommand
        Dim T As SqlTransaction
        Try
            C.ConnectionString = D.ConStr
            C.Open()
            T = C.BeginTransaction(IsolationLevel.ReadCommitted)
            COM.Connection = C
            COM.Transaction = T
            COM.CommandText = sqlStock
            COM.ExecuteNonQuery()
            Dim qStock As New QueryBuilder("tblStock")
            'If DM = DAL.DAL.DataMode.EditRecord Then
            '    COM.CommandText = "Delete from tblGatePassDetail Where gpSerialNo = '" & txtGatePassNo.Text & "'"
            '    COM.ExecuteNonQuery()
            'End If
            If DM = DAL.DAL.DataMode.NewRecord Then
                sqlStock = qStock.GetInsertQuery
            End If

            ' Dim sqlstock As String
            For Each R As DataGridViewRow In Grid.Rows
                With qStock
                    ' .AddField("gpSerialNo", txtGatePassNo.Text, FieldType.Text)
                    .AddField("ItemID", R.Cells("colItemID").Value, FieldType.Text)
                    .AddField("stType", "IN", FieldType.Text)
                    .AddField("stItemQty", Val1(R.Cells("colQty").Value), FieldType.Numeric)
                    .AddField("stInDate", Now, FieldType.DateTime)

                End With
                sqlStock = qStock.GetInsertQuery
                qStock.ClearFields()
                COM.CommandText = sqlStock
                COM.ExecuteNonQuery()
            Next
            T.Commit()
        Catch ex As Exception
            MsgBox("Error while inserting in tblStock" + ex.ToString(), MsgBoxStyle.Critical, CName)
        End Try
    End Sub
    '''''''''''''''''''''''''''''''''''''''''''''''''''
    Function DataIsValid() As Boolean
        DataIsValid = True
        If optReturn.Checked And Len(txtOutGatePassNo.Text) = 0 Then
            MsgBox("Please select outward gate pass number", MsgBoxStyle.Critical, CName)
            cmdPickOutGatePass.Focus()
            Return False
        End If
        If Grid.Rows.Count = 0 Then
            MsgBox("Please add atleast one item to the list", MsgBoxStyle.Information, CName)
            txtItemID.Focus()
            Return False
        End If
        If Len(txtVehicleNo.Text) = 0 Then
            MsgBox("Please enter vehicle no", MsgBoxStyle.Information, CName)
            txtVehicleNo.Focus()
            Return False
        End If
        If Len(txtGateIncharge.Text) = 0 Then
            MsgBox("Please enter gate incharge name", MsgBoxStyle.Information, CName)
            txtGateIncharge.Focus()
            Return False
        End If
        If Len(txtPersonDelivered.Text) = 0 Then
            MsgBox("Please enter delivered person name", MsgBoxStyle.Information, CName)
            txtPersonDelivered.Focus()
            Return False
        End If
        If Len(txtBiltyNo.Text) = 0 Then
            MsgBox("Please enter bilty no", MsgBoxStyle.Information, CName)
            txtBiltyNo.Focus()
            Return False
        End If        
        If cmbGM.SelectedIndex = -1 Then
            MsgBox("Please select atleast one name from the list", MsgBoxStyle.Information, CName)
            cmbGM.Focus()
            Return False
        End If
        If cmbStorekeeper.SelectedIndex = -1 Then
            MsgBox("Please select atleast one name from the list", MsgBoxStyle.Information, CName)
            cmbStorekeeper.Focus()
            Return False
        End If
        If Len(txtRefNo.Text) = 0 Then
            MsgBox("Please enter reference no", MsgBoxStyle.Information, CName)
            txtRefNo.Focus()
            Return False
        End If


    End Function
    Public Sub FillData(ByVal ID As String)

        Dim DT As New DataTable
        DT = D.GetDataTable("Select * from tblDeliveryChallans where dcNo = '" & ID & "'")
        ClearAll()
        txtGatePassNo.Text = ID
        dtDate.Value = DT.Rows(0).Item("dcDate")
        txtVehicleNo.Text = DT.Rows(0).Item("dcVehicleNo")
        'txtIndentNo.Text = DT.Rows(0).Item("IndentNo")
        txtTotal.Text = DT.Rows(0)("dcTotalAmount")


        DT = D.GetDataTable("Select * from tblDeliveryChallanDetail Where dcNo = '" & ID & "'")
        Grid.AllowUserToAddRows = True

        For Each R As DataRow In DT.Rows
            Dim GRow As DataGridViewRow = Grid.Rows(Grid.NewRowIndex).Clone
            With GRow
                .Cells(colItemID.Index).Value = R("ItemID")
                .Cells(colDescription.Index).Value = ItemIDToName(R("ItemId"))
                .Cells(colUOM.Index).Value = ItemIDtoUnit(R("ItemId"))
                .Cells(colBrand.Index).Value = R("Brand")
                .Cells(colQty.Index).Value = R("Quantity")

            End With
            Grid.Rows.Add(GRow)
        Next
        Grid.AllowUserToAddRows = False
        CalcTotal()
    End Sub

    Private Sub cmdEdit_Click(sender As System.Object, e As System.EventArgs) Handles cmdEdit.Click
        If Len(txtGatePassNo.Text) = 0 Then
            MsgBox("No record to edit", MsgBoxStyle.Critical, CName)
            Exit Sub
        End If
        LockAll(False)

        DM = DAL.DAL.DataMode.EditRecord
        dtDate.Focus()
    End Sub

    Private Sub cmdFind_Click(sender As System.Object, e As System.EventArgs) Handles cmdFind.Click
        Me.Cursor = Cursors.WaitCursor
        frmDeliveryChallanFind.MdiParent = frmMain
        frmDeliveryChallanFind.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdPrint_Click(sender As System.Object, e As System.EventArgs) Handles cmdPrint.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ConnInfo As New ConnectionInfo()
        Dim T As Table
        Dim R As New rptDeliveryChallan
        With ConnInfo
            .ServerName = D.ServerName
            .DatabaseName = D.DBName
            .UserID = D.UserName
            .Password = D.Password
        End With
        For Each T In R.Database.Tables
            T.LogOnInfo.ConnectionInfo = ConnInfo
            T.ApplyLogOnInfo(T.LogOnInfo)
        Next

        R.RecordSelectionFormula = "{tblDeliveryChallans.dcNo} = '" & txtGatePassNo.Text & "'"
        If Not R.HasRecords Then
            MsgBox("No records found against your selection", vbInformation, CName)
            R.Dispose()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        Dim F As New frmReport
        F.MdiParent = Me.MdiParent
        F.Text = "Delivery Challan"
        F.CRV.ReportSource = R
        F.CRV.ShowGroupTreeButton = False
        F.CRV.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        F.Text = Me.Text
        F.Show()
        F.CRV.Show()
        F.CRV.Zoom(1)
        Me.Cursor = Cursors.Default
    End Sub

   
    Private Sub optHeadOffice_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optHeadOffice.CheckedChanged, optReturn.CheckedChanged
        If optHeadOffice.Checked Then
            fraReturn.Enabled = False
        ElseIf optReturn.Checked Then
            fraReturn.Enabled = True
        End If

    End Sub
    Sub ClearItem()
        txtItemID.Text = ""
        txtDescription.Text = ""
        txtUnit.Text = ""
        txtBrand.Text = ""
        txtQty.Text = ""

    End Sub
    Private Sub txtItemID_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtItemID.KeyDown
        Dim ID As String = txtItemID.Text
        If e.KeyCode = Keys.Enter Then
            If Len(ID) = 0 Then
                frmAllItemsShort.MyOpt = "INWARD"
                frmAllItemsShort.MdiParent = frmMain
                'frmAllItemsShort.cmdPreviousPurchase.Visible = True
                frmAllItemsShort.Show()
                Exit Sub
            Else
                Dim iName As String = ItemIDToName(ID)
                If Len(iName) = 0 Then

                    ClearItem()
                    txtItemID.Text = ID
                    MsgBox("Sorry, this item code not found in record", MsgBoxStyle.Information, CName)
                    txtItemID.Focus()
                    txtItemID.SelectAll()
                Else
                    txtDescription.Text = iName
                    txtUnit.Text = ItemIDtoUnit(ID)
                    txtBrand.Focus()
                End If
            End If
        End If
    End Sub

    
   
    Private Sub cmdAddItem_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddItem.Click
        If Trim(txtItemID.Text) = "" Then
            MsgBox("Please enter a valid item code", MsgBoxStyle.Critical, CName)
            txtItemID.Focus()
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        If Not D.IsRecordExists("tblItems", "ItemID", txtItemID.Text) Then

            MsgBox("The code you have entered is not found in record", MsgBoxStyle.Critical, CName)
            txtItemID.Focus()
            txtItemID.SelectAll()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        Me.Cursor = Cursors.Default
        Dim FoundInGrid As Boolean = False
        For Each DR As DataGridViewRow In Grid.Rows
            If DR.Cells("colItemID").Value = txtItemID.Text Then
                FoundInGrid = True
                Exit For
            End If
        Next
        If FoundInGrid Then
            MsgBox("This item has already been added to the list", MsgBoxStyle.Critical, CName)
            txtItemID.Focus()
            txtItemID.SelectAll()
            Exit Sub
        End If

        Grid.AllowUserToAddRows = True
        Dim R As DataGridViewRow = Grid.Rows(Grid.NewRowIndex).Clone
        R.Cells(colItemID.Index).Value = txtItemID.Text
        R.Cells(colDescription.Index).Value = txtDescription.Text
        R.Cells(colUOM.Index).Value = txtUnit.Text
        R.Cells(colBrand.Index).Value = txtBrand.Text
        R.Cells(colQty.Index).Value = Val1(txtQty.Text)
        Grid.Rows.Add(R)
        Grid.AllowUserToAddRows = False
        ClearItem()
        CalcTotal()
        txtItemID.Focus()

    End Sub
    Function fillStoreKeeper() As String
        Dim DT As New DataTable
        DT = D.GetDataTable("Select * from tblUsers where FK_DesigID = 1")
        cmbStorekeeper.DataSource = DT
        cmbStorekeeper.DisplayMember = "UserName"
        cmbStorekeeper.ValueMember = "UserID"
        cmbStorekeeper.SelectedIndex = -1
    End Function

    Function fillGM() As String
        Dim DT As New DataTable
        DT = D.GetDataTable("Select * from tblUsers where FK_DesigID = 2")
        cmbGM.DataSource = DT
        cmbGM.DisplayMember = "UserName"
        cmbGM.ValueMember = "UserID"
        cmbGM.SelectedIndex = -1
    End Function

    Sub TransferFocus(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRefNo.KeyDown, dtDate.KeyDown, dtTime.KeyDown, optHeadOffice.KeyDown, optReturn.KeyDown, txtVehicleNo.KeyDown, txtBiltyNo.KeyDown, dtBiltyDate.KeyDown, txtPersonDelivered.KeyDown, txtGateIncharge.KeyDown, txtBrand.KeyDown, txtQty.KeyDown, txtRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtRefNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRefNo.TextChanged

    End Sub

    Private Sub txtGatePassNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGatePassNo.TextChanged

    End Sub

    Private Sub cmdRemoveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveItem.Click
        If Grid.Rows.Count = 0 Then
            MsgBox("No record selected", MsgBoxStyle.Information, CName)
            Exit Sub
        End If
        Dim R As DataGridViewRow
        R = Grid.CurrentRow

        Try
            D.ExecuteNonQuery("Delete from tblGatePassDetail where gpSerialNo = '" & txtGatePassNo.Text.Trim() & "' And ItemID = '" & R.Cells("colItemID").Value.ToString().Trim() & "'")
            FillLastData()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdEditItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditItem.Click

    End Sub

    Private Sub cmdPickOutGatePass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPickOutGatePass.Click
        Me.Cursor = Cursors.WaitCursor
        frmOutwardGatePassFind.MdiParent = frmMain
        frmOutwardGatePassFind.Show()
        Me.Cursor = Cursors.Default
    End Sub

    ' '''''''''''''''''''''''''''''''''''''''''
    'Public Sub saveStock(ByVal IndentNo As String)
    '    Dim DT As DataTable
    '    DT = D.GetDataTable("Select * from  where IndentNo = '" & IndentNo & "'")
    '    Grid.AllowUserToAddRows = True
    '    For Each R As DataRow In DT.Rows
    '        Dim GRow As DataGridViewRow = Grid.Rows(Grid.NewRowIndex).Clone
    '        With GRow
    '            .Cells(colItemID.Index).Value = R.Item("ItemID")
    '            .Cells(colDescription.Index).Value = R.Item("ItemDescription")
    '            .Cells(colUOM.Index).Value = R.Item("unitShortName")
    '            .Cells(colQty.Index).Value = R.Item("Qty")
    '        End With
    '        Grid.Rows.Add(GRow)

    '    Next
    '    Grid.AllowUserToAddRows = False
    '    CalcTotal()
    'End Sub


End Class

