Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmStoreReceiptNote
    Dim DM As DAL.DAL.DataMode
    Dim D As New DAL.DAL
    Dim ComboLoading As Boolean
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If Not DataIsValid() Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim qbMaster As New QueryBuilder("tblSRN")
        Dim qbDetail As New QueryBuilder("tblSRNDetail")
        Dim qbGPDetail As New QueryBuilder("tblGatePass")
        Dim sqlMaster, sqlDetail, sqlGpUpdate As String
        With qbMaster
            .AddField("SRNNo", txtSRNNo.Text, FieldType.Text)
            ' .AddField("gpType", "IN", FieldType.Text)
            .AddField("SRNIGPNo", txtIGPNo.Text, FieldType.Text)
            .AddField("SRNDate", dtDate.Value, FieldType.DateTime)
            '  .AddField("gpTime", dtTime.Value, FieldType.DateTime)

            .AddField("SRNSupplierName", txtSupplierName.Text, FieldType.Text)
            '.AddField("gpBiltyNo", txtBiltyNo.Text, FieldType.Text)
            '.AddField("gpBiltyDate", dtBiltyDate.Value, FieldType.DateTime)
            '.AddField("gpPersonDelivered", txtPersonDelivered.Text, FieldType.Text)
            .AddField("SRNDepartment", cmbDepartment.Text, FieldType.Text)
            .AddField("SRNRemarks", txtRemarks.Text, FieldType.Text)
            .AddField("SRNCreatedBy", CurrentUser.UserID, FieldType.Numeric)
            .AddField("SRNCretaedOn", Now, FieldType.DateTime)
            .AddField("SRNSystem", CurrentUser.SystemName, FieldType.Text)

        End With
        If DM = DAL.DAL.DataMode.NewRecord Then
            sqlMaster = qbMaster.GetInsertQuery
        ElseIf DM = DAL.DAL.DataMode.EditRecord Then
            qbMaster.RemoveField("SRNNo")
            qbMaster.InsertDeleteFilterField("SRNNo", txtSRNNo.Text, FieldType.Text)
            qbMaster.RemoveField("SRNCreatedBy")
            qbMaster.RemoveField("SRNCreatedOn")
            qbMaster.AddField("SRNEditedBy", CurrentUser.UserID, FieldType.Text)
            qbMaster.AddField("SRNEditedOn", Now, FieldType.DateTime)
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
                COM.CommandText = "Delete from tblSRNDetail Where SRNNo = '" & txtSRNNo.Text & "'"
                COM.ExecuteNonQuery()
            End If
            For Each R As DataGridViewRow In Grid.Rows
                With qbDetail
                    .AddField("SRNNo", txtSRNNo.Text, FieldType.Text)
                    ' .AddField("gpType", "IN", FieldType.Text)
                    .AddField("SRNItemID", R.Cells("colItemID").Value, FieldType.Text)
                    .AddField("SRNItemDesc", R.Cells("colDescription").Value, FieldType.Text)
                    .AddField("SRNItemCode", R.Cells("colCode").Value, FieldType.Text)
                    .AddField("SRNItemUnit", R.Cells("colUOM").Value, FieldType.Text)
                    '  .AddField("Brand", R.Cells("colBrand").Value, FieldType.Text)
                    .AddField("SRNItemReceived", R.Cells("colReceived").Value, FieldType.Numeric)
                    .AddField("SRNItemRejected", R.Cells("colRejected").Value, FieldType.Numeric)
                    .AddField("SRNItemApproved", R.Cells("colApproved").Value, FieldType.Text)
                    .AddField("SRNItemRate", R.Cells("colRate").Value, FieldType.Text)
                    .AddField("SRNItemAmount", Val1(R.Cells("colQty").Value), FieldType.Numeric)
                    '  .AddField("Brand", R.Cells("colBrand").Value, FieldType.Text)
                    '  .AddField("Remarks", "", FieldType.Text)

                End With
                sqlDetail = qbDetail.GetInsertQuery
                qbDetail.ClearFields()
                COM.CommandText = sqlDetail
                COM.ExecuteNonQuery()
            Next
            qbGPDetail.AddField("gpSRN", 1, FieldType.Numeric)
            qbGPDetail.pFilter.fldName = "gpSerialNo"
            qbGPDetail.pFilter.fldType = FieldType.Text
            qbGPDetail.pFilter.fldValue = txtIGPNo.Text

            sqlGpUpdate = qbGPDetail.GetUpdateQuery()
            COM.CommandText = sqlGpUpdate
            COM.ExecuteNonQuery()

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
            qbGPDetail = Nothing
        End Try
        Me.Cursor = Cursors.Default
        MsgBox("Store Receipt Note is saved", MsgBoxStyle.Information, CName)
        'ClearAll()
        FillLastData()
        LockAll(True)
        cmdAdd.Focus()
        DM = DAL.DAL.DataMode.SavedRecord

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        LockAll(True)
        DM = DAL.DAL.DataMode.SavedRecord
        cmdAdd.Focus()
        ClearAll()
        FillLastData()
    End Sub
    Sub LockAll(ByVal OK As Boolean)
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
        'txtSRNNo.Text = ""
        txtIGPNo.Text = ""
        dtDate.Value = Now.Date
        ' dtTime.Value = Now
        'optHeadOffice.Checked = True
        'fraReturn.Enabled = False
        'txtOutGatePassNo.Text = ""
        'dtOutDate.Value = Now.Date
        cmbDepartment.SelectedIndex = -1
        txtSupplierName.Text = ""
        txtRemarks.Text = ""
        'txtBiltyNo.Text = ""
        'dtBiltyDate.Value = Now.Date
        'txtPersonDelivered.Text = ""
        'txtDeparetment.Text = ""

        Grid.Rows.Clear()
        txtTotal.Text = ""
    End Sub


    Sub FillLastData()
        Dim IndID As String
        IndID = D.GetScaler("Select max(gpSerialNo) from tblGatePass")
        If IndID = "" Then
            ClearAll()
        Else
            FillData(IndID)
        End If
    End Sub
    Public Sub FillData(ByVal ID As String)

        Dim DT As New DataTable
        DT = D.GetDataTable("Select * from tblGatePass where gpSerialNo = '" & ID & "'")
        'DT = D.GetDataTable("Select * from tblSRN where SRNNo = '" & ID & "'")
        ClearAll()
        txtIGPNo.Text = ID
        dtDate.Value = DT.Rows(0).Item("gpDate")
        'txtVehicleNo.Text = DT.Rows(0).Item("dcVehicleNo")
        'txtIndentNo.Text = DT.Rows(0).Item("IndentNo")       
        'txtTotal.Text = DT.Rows(0)("dcTotalAmount")


        DT = D.GetDataTable("Select * from tblGatePassDetail Where gpSerialNo = '" & ID & "'")
        Grid.AllowUserToAddRows = True

        For Each R As DataRow In DT.Rows
            Dim GRow As DataGridViewRow = Grid.Rows(Grid.NewRowIndex).Clone
            With GRow
                .Cells(colItemID.Index).Value = R("ItemID")
                .Cells(colDescription.Index).Value = ItemIDToName(R("ItemId"))
                .Cells(colUOM.Index).Value = ItemIDtoUnit(R("ItemId"))
                '  .Cells(colBrand.Index).Value = R("Brand")
                .Cells(colReceived.Index).Value = R("Quantity")

            End With
            Grid.Rows.Add(GRow)
        Next
        Grid.AllowUserToAddRows = False
        '  CalcSubTotal()
        CalcTotal()
    End Sub
    Sub CalcTotal()
        Dim N As Long
        For Each R As DataGridViewRow In Grid.Rows
            N += R.Cells("colQty").Value
        Next
        txtTotal.Text = N
    End Sub
    'Sub CalcSubTotal()
    '    Try
    '        Dim T As Long
    '        Dim r As DataGridViewRow
    '        T = r.Cells("colUOM").Value * r.Cells("colRate").Value
    '        r.Cells("colQty").Value = T
    '    Catch ex As Exception
    '        ' MsgBox("Multiplication Error : ", MsgBoxStyle.Critical, CName)

    '    End Try

    'End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddItem.Click
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
        R.Cells(colCode.Index).Value = txtCode.Text
        R.Cells(colUOM.Index).Value = txtUnit.Text
        ' R.Cells(colBrand.Index).Value = txtAmount.Text   
        '  R.Cells(colBrand.Index).Value = txtBrandName.Text
        R.Cells(colReceived.Index).Value = txtReceivedItem.Text
        R.Cells(colRejected.Index).Value = txtRejectedItem.Text
        R.Cells(colApproved.Index).Value = txtApprovedItem.Text
        R.Cells(colRate.Index).Value = txtRate.Text
        '''''''''''''''''''''''''''''''''''''''
        R.Cells(colQty.Index).Value = Val1(txtQty.Text)
        Grid.Rows.Add(R)
        Grid.AllowUserToAddRows = False
        ClearItem()
        ' CalcSubTotal() ''''''''''''''''''''''''''''
        CalcTotal()
        txtItemID.Focus()
    End Sub
    Sub ClearItem()
        txtItemID.Text = ""
        txtDescription.Text = ""
        txtCode.Text = ""
        txtUnit.Text = ""
        ' txtBrandName.Text = ""        
        txtReceivedItem.Text = ""
        txtRejectedItem.Text = ""
        txtApprovedItem.Text = ""
        txtRate.Text = ""
        txtQty.Text = ""
        txtRate.Text = ""
        '  txtAmount.Text = ""        

    End Sub

    Private Sub txtItemID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemID.KeyDown
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
                    txtRate.Text = ItemIDtoUnit(ID)
                    '   txtAmount.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub cmdRemoveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveItem.Click
        If Grid.Rows.Count = 0 Then
            MsgBox("No record selected", MsgBoxStyle.Information, CName)
            Exit Sub
        End If
        Dim R As DataGridViewRow
        R = Grid.CurrentRow

        Try
            D.ExecuteNonQuery("Delete from tblGatePassDetail where gpSerialNo = '" & txtSRNNo.Text.Trim() & "' And ItemID = '" & R.Cells("colItemID").Value.ToString().Trim() & "'")
            FillLastData()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        'ClearAll()
        txtSRNNo.Text = GetNewSRNNo("IN")
        LockAll(False)
        txtIGPNo.Focus()
        DM = DAL.DAL.DataMode.NewRecord
    End Sub
    Function GetNewSRNNo(ByVal gpType As String) As String

        'format = MMYY-000001
        Dim PreFix As String = Format(Now.Date, "yyMM") & "-"
        'Dim N As String = D.GetScaler("Select Max(SRNNo) from tblSRN where SRNNo like '" & PreFix & "%' and gpType='" & gpType & "'")
        Dim N As String = D.GetScaler("Select Max(SRNNo) from tblSRN where SRNNo like '" & PreFix & "%'")
        If N = "" Then
            Return PreFix & "000001"
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
            Return PreFix & N
        End If

    End Function

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        If Len(txtSRNNo.Text) = 0 Then
            MsgBox("No record to edit", MsgBoxStyle.Critical, CName)
            Exit Sub
        End If
        LockAll(False)

        DM = DAL.DAL.DataMode.EditRecord
        dtDate.Focus()
    End Sub

    Private Sub frmStoreReceiptNote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LockAll(True)
        FillLastData()
        FillDepartments()
        ' fillStoreKeeper()
        '  fillGM()
        '''''''''''''''''''''''''''''

        ''''''''''''''''''''''''''''''
        For Each C As DataGridViewColumn In Grid.Columns
            C.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        DM = DAL.DAL.DataMode.SavedRecord
    End Sub

    Private Sub frmStoreReceiptNote_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If DM <> DAL.DAL.DataMode.SavedRecord Then
            MsgBox("Please save or cancel your changes", MsgBoxStyle.Information, CName)

            e.Cancel = True

        End If
    End Sub
    Function DataIsValid() As Boolean
        DataIsValid = True
        If Len(txtSupplierName.Text) = 0 Then
            MsgBox("Please enter the supplier name", MsgBoxStyle.Information, CName)
            txtSupplierName.Focus()
            Return False
        End If
        If cmbDepartment.SelectedIndex = -1 Then
            MsgBox("Please select department from the list", MsgBoxStyle.Information, CName)
            cmbDepartment.Focus()
            Return False
        End If
        For r = 0 To Grid.RowCount - 1
            If (Grid.Rows(r).Cells.Item(4).Value) = "" Then
                MsgBox("Enter the No Rejected Items ", MsgBoxStyle.Information, CName)
                Return False
            End If
            If (Grid.Rows(r).Cells.Item(5).Value) = "" Then
                MsgBox("Enter the No Approved Items ", MsgBoxStyle.Information, CName)
                Return False
            End If
            If (Grid.Rows(r).Cells.Item(6).Value) = "" Then
                MsgBox("Enter the Item Code ", MsgBoxStyle.Information, CName)
                Return False
            End If
            If (Grid.Rows(r).Cells.Item(7).Value) = "" Then
                MsgBox("Enter the Item Rate  ", MsgBoxStyle.Information, CName)
                Return False
            End If
        Next

        If Grid.Rows.Count = 0 Then
            MsgBox("Please add atleast one item to the list", MsgBoxStyle.Information, CName)
            txtItemID.Focus()
            Return False
        End If       
    End Function

    Private Sub txtQty_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown
        cmdAddItem.Focus()
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Me.Cursor = Cursors.WaitCursor
        frmInwardFind.MdiParent = frmMain
        frmInwardFind.Show()
        Me.Cursor = Cursors.Default
        Me.cmdAdd.Visible = True
        Me.cmdAdd.PerformClick()
        Me.cmdAdd.Visible = False

    End Sub
    Sub FillDepartments()
        ComboLoading = True
        Dim DT As New DataTable
        DT = D.GetDataTable("Select deptID, deptName from tblDepartments")
        cmbDepartment.DataSource = DT
        cmbDepartment.DisplayMember = "deptName"
        cmbDepartment.ValueMember = "deptID"
        cmbDepartment.SelectedIndex = -1
        ComboLoading = False

    End Sub    
    Private Sub Grid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellEndEdit
        Try
            Dim R As DataGridViewRow
            R = Grid.CurrentRow
            If e.ColumnIndex = colReceived.Index Or e.ColumnIndex = colRate.Index Then
                R.Cells("colQty").Value = Val(R.Cells("colReceived").Value) * Val(R.Cells("colRate").Value)
            End If
            CalcTotal()
        Catch ex As Exception

        End Try       
    End Sub
End Class