Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO

Public Class frmIndent
    Dim D As New DAL.DAL
    Dim DM As DAL.DAL.DataMode
    Dim ComboLoading As Boolean

    Private Sub frmIndent_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If DM <> DAL.DAL.DataMode.SavedRecord Then
            MsgBox("Please save or cancel your changes", MsgBoxStyle.Information, CName)

            e.Cancel = True

        End If
    End Sub
    Private Sub frmIndent_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LockAll(True)
        FillDepartments()
        FillLastData()
        BindTxt(txtDemandBy, "IndentDemandBy", "tblIndents", True)
        BindTxt(txtStoreInCharge, "IndentStoreInCharge", "tblIndents", True)
        For Each C As DataGridViewColumn In Grid.Columns
            C.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        DM = DAL.DAL.DataMode.SavedRecord
    End Sub
    Sub LockAll(OK As Boolean)
        cmdAdd.Enabled = OK
        cmdSave.Enabled = Not OK
        cmdCancel.Enabled = Not OK
        cmdEdit.Enabled = OK
        cmdFind.Enabled = OK
        cmdPrint.Enabled = OK
        cmdClose.Enabled = OK
        fraIndentDetail.Enabled = Not OK
        fraItemDetail.Enabled = Not OK
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
    Sub FillLastData()
        Dim IndID As String
        IndID = D.GetScaler("Select max(IndentNo) from tblIndents")
        If IndID = "" Then
            ClearAll()
        Else
            FillData(IndID)
        End If


    End Sub
    Public Sub FillData(ByVal ID As String)

        Dim DT As New DataTable
        DT = D.GetDataTable("Select * from tblIndents where IndentNo = '" & ID & "'")
        ClearAll()
        txtIndentNo.Text = ID
        dtIndentDate.Value = DT.Rows(0).Item("IndentDate")
        cmbDepartment.SelectedValue = DT.Rows(0).Item("deptID")
        cmbSection.SelectedValue = DT.Rows(0).Item("secID")
        txtDemandBy.Text = DT.Rows(0).Item("IndentDemandBy")
        txtStoreInCharge.Text = DT.Rows(0).Item("IndentStoreInCharge")

        DT = D.GetDataTable("Select * from tblIndentDetail Where IndentNo = '" & ID & "'")
        Grid.AllowUserToAddRows = True

        For Each R As DataRow In DT.Rows
            Dim GRow As DataGridViewRow = Grid.Rows(Grid.NewRowIndex).Clone
            With GRow
                .Cells(colItemCode.Index).Value = R("ItemID")
                .Cells(colDescription.Index).Value = ItemIDToName(R("ItemID"))
                .Cells(colQty.Index).Value = R("Quantity")
                .Cells(colBalInHand.Index).Value = Format(R("InHand"), "N2")
                .Cells(colAvgCons.Index).Value = Format(R("AvgCons"), "N2")
                .Cells(colLastPur.Index).Value = R("LastPurchase")
            End With
            Grid.Rows.Add(GRow)
        Next
        Grid.AllowUserToAddRows = False
    End Sub




    Sub BindTxt(T As TextBox, fldName As String, tblName As String, Distinct As Boolean)
        Me.Cursor = Cursors.WaitCursor
        Dim D As New DAL.DAL
        Dim A As New AutoCompleteStringCollection
        Dim S As String
        S = "Select " & IIf(Distinct, "Distinct ", "") & fldName & " from " & tblName
        Dim DT As New DataTable
        DT = D.GetDataTable(S)
        If DT.Rows.Count > 0 Then
            For N As Integer = 0 To DT.Rows.Count - 1
                If Not IsDBNull(DT.Rows(N)(0)) Then
                    A.Add(DT.Rows(N)(0))
                End If
            Next
        End If

        T.AutoCompleteCustomSource = A
        T.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        T.AutoCompleteSource = AutoCompleteSource.CustomSource
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdAdd.Click
        ClearAll()
        txtIndentNo.Text = GetNewIndentNo()
        LockAll(False)
        dtIndentDate.Focus()
        DM = DAL.DAL.DataMode.NewRecord
    End Sub

    Sub ClearAll()
        txtIndentNo.Text = ""
        dtIndentDate.Value = Now.Date
        cmbDepartment.SelectedIndex = -1
        cmbSection.SelectedIndex = -1
        txtDemandBy.Text = ""
        txtStoreInCharge.Text = ""
        ClearItem()
        Grid.Rows.Clear()
    End Sub
    Sub ClearItem()
        txtItemCode.Text = ""
        txtItemDescription.Text = ""
        txtQuantity.Text = ""
        txtAvgCons.Text = ""
        txtLastPur.Text = ""
        txtInHand.Text = ""
    End Sub
    Function GetNewIndentNo() As String
        'format = MMYY-000001
        Dim PreFix As String = Format(Now.Date, "yyMM") & "-"
        Dim N As String = D.GetScaler("Select Max(IndentNo) from tblIndents where IndentNo like '" & PreFix & "%'")
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

    Private Sub cmbDepartment_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbDepartment.SelectedIndexChanged
        If Not ComboLoading Then
            Dim DT As DataTable = D.GetDataTable("Select SecID, SecName from tblSections Where deptID = '" & cmbDepartment.SelectedValue & "'")
            'cmbSection.Items.Clear()
            cmbSection.DataSource = DT
            cmbSection.DisplayMember = "secName"
            cmbSection.ValueMember = "secID"
            cmbSection.SelectedIndex = -1
        End If



    End Sub

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

    Private Sub dtIndentDate_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtIndentDate.KeyDown, cmbDepartment.KeyDown, cmbSection.KeyDown, txtDemandBy.KeyDown, txtStoreInCharge.KeyDown

        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")

    End Sub

    Private Sub txtItemCode_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtItemCode.KeyDown
        If e.KeyCode = Keys.Escape Then
            cmdSave.Focus()
            Exit Sub
        End If
        If e.KeyCode = Keys.Enter Then
            If txtItemCode.Text = "" Then
                Me.Cursor = Cursors.WaitCursor
                frmAllItemsShort.MdiParent = Me.MdiParent
                frmAllItemsShort.MyOpt = "INDENT"
                frmAllItemsShort.Show()
                Me.Cursor = Cursors.Default
            Else
                Dim ItemID As String = Trim(txtItemCode.Text)
                If Not D.IsRecordExists("tblItems", "ItemID", ItemID) Then
                    MsgBox("Sorry, this item code not found in record", MsgBoxStyle.Information, CName)
                    ClearItem()
                    txtItemCode.Text = ItemID
                    txtItemCode.Focus()
                    txtItemCode.SelectAll()
                    Exit Sub
                End If
                txtItemDescription.Text = ItemIDToName(ItemID)
                FillItemOtherDetail(ItemID)
                txtQuantity.Focus()
            End If
        End If
    End Sub
    Public Sub FillItemOtherDetail(ItemID As String)
        'Dim InHand As Single = D.GetScaler("Select sum(stDR)-sum(stCR) from tblStock Where stItemID = " & ItemID)
        Dim InHand As String = D.GetScaler("Select sum(stItemQty)-sum(stInQty) from tblStock Where stItemID = '" & ItemID & "'")
        'TEST VALUE
        '  Dim Inhand As Single = "453.25"
        txtInHand.Text = Format(Val(Inhand), "N2")

        Dim StartDate As Date = Now.Date.AddDays(-90)
        'Dim AvgCons As Single = D.GetScaler("Select sum(stCR) from tblStock Where stType = 'CONS' and CONVERT(varchar(10), stDate,105) BETWEEN " & Format(StartDate, "dd-MM-yyyy") & " AND " & Format(Now.Date, "dd-MM-yyyy"))
        'TEST VALUE
        Dim AvgCons As Single = "1865.50"
        AvgCons = AvgCons / 90
        txtAvgCons.Text = Format(AvgCons, "N2")

        Dim LastDateOfPur As Date
        'Dim L As Object = D.GetScaler("Select Max(stDate) where stItemID = " & ItemID & " and stType = 'PUR'")
        'TEST Value
        Dim L As Date = Now.Date.AddDays(-30)
        If IsDBNull(L) Then
            LastDateOfPur = "01-01-1900"
        Else
            LastDateOfPur = CDate(L)
        End If
        txtLastPur.Text = Format(L, "MM/dd/yyyy")

    End Sub


    Private Sub txtItemCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtItemCode.TextChanged

    End Sub

    Private Sub txtQuantity_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantity.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{TAB}")

        Else
            OnlyDecimalNumerics(e, txtQuantity)
        End If
    End Sub

    Private Sub txtQuantity_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtQuantity.TextChanged

    End Sub

    Private Sub cmdAddItem_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddItem.Click
        If Trim(txtItemCode.Text) = "" Then
            MsgBox("Please enter a valid item code", MsgBoxStyle.Critical, CName)
            txtItemCode.Focus()
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        If Not D.IsRecordExists("tblItems", "ItemID", txtItemCode.Text) Then

            MsgBox("The code you have entered is not found in record", MsgBoxStyle.Critical, CName)
            txtItemCode.Focus()
            txtItemCode.SelectAll()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        Me.Cursor = Cursors.Default
        Dim FoundInGrid As Boolean = False
        For Each DR As DataGridViewRow In Grid.Rows
            If DR.Cells("colItemCode").Value = txtItemCode.Text Then
                FoundInGrid = True
                Exit For
            End If
        Next
        If FoundInGrid Then
            MsgBox("This item has already been added to the indent list", MsgBoxStyle.Critical, CName)
            txtItemCode.Focus()
            txtItemCode.SelectAll()
            Exit Sub
        End If

        Grid.AllowUserToAddRows = True
        Dim R As DataGridViewRow = Grid.Rows(Grid.NewRowIndex).Clone
        R.Cells(colItemCode.Index).Value = txtItemCode.Text
        R.Cells(colDescription.Index).Value = txtItemDescription.Text
        R.Cells(colQty.Index).Value = Format(Val1(txtQuantity.Text), "N2")
        R.Cells(colBalInHand.Index).Value = txtInHand.Text
        R.Cells(colAvgCons.Index).Value = txtAvgCons.Text
        R.Cells(colLastPur.Index).Value = txtLastPur.Text
        Grid.Rows.Add(R)
        Grid.AllowUserToAddRows = False
        ClearItem()
        txtItemCode.Focus()
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        If Not DataIsValid() Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim qbIndents As New QueryBuilder("tblIndents")
        Dim qbIndentDetail As New QueryBuilder("tblIndentDetail")
        Dim sqlIndent As String
        Dim sqlIndentDetail As String
        With qbIndents
            .AddField("IndentNo", txtIndentNo.Text, FieldType.Text)
            .AddField("IndentDate", dtIndentDate.Value, FieldType.DateTime)
            .AddField("deptID", cmbDepartment.SelectedValue, FieldType.Text)
            .AddField("secID", cmbSection.SelectedValue, FieldType.Text)
            .AddField("IndentDemandBy", txtDemandBy.Text, FieldType.Text)
            .AddField("IndentStoreInCharge", txtStoreInCharge.Text, FieldType.Text)
            .AddField("IndentSystem", CurrentUser.SystemName, FieldType.Text)
            .AddField("IndentStatus", "OPEN", FieldType.Text)
            .AddField("IndentCreatedBy", CurrentUser.UserID, FieldType.Numeric)
            .AddField("IndentCreatedOn", Now, FieldType.DateTime)

        End With
        If DM = DAL.DAL.DataMode.NewRecord Then
            sqlIndent = qbIndents.GetInsertQuery
        ElseIf DM = DAL.DAL.DataMode.EditRecord Then
            qbIndents.RemoveField("IndentNo")
            qbIndents.InsertDeleteFilterField("IndentNo", txtIndentNo.Text, FieldType.Text)
            qbIndents.RemoveField("IndentCreatedBy")
            qbIndents.RemoveField("IndentCreatedOn")
            qbIndents.AddField("IndentEditedBy", CurrentUser.UserID, FieldType.Text)
            qbIndents.AddField("IndentEditedOn", Now, FieldType.DateTime)
            sqlIndent = qbIndents.GetUpdateQuery
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
            COM.CommandText = sqlIndent
            COM.ExecuteNonQuery()
            If DM = DAL.DAL.DataMode.EditRecord Then
                COM.CommandText = "Delete from tblIndentDetail Where IndentNo = '" & txtIndentNo.Text & "'"
                COM.ExecuteNonQuery()
            End If
            For Each R As DataGridViewRow In Grid.Rows
                With qbIndentDetail
                    .AddField("IndentNo", txtIndentNo.Text, FieldType.Text)
                    .AddField("ItemID", R.Cells("colItemCode").Value, FieldType.Text)
                    .AddField("Quantity", Val1(R.Cells("colQty").Value), FieldType.Numeric)
                    .AddField("InHand", Val1(R.Cells("colBalInHand").Value), FieldType.Numeric)
                    .AddField("AvgCons", Val1(R.Cells("colAvgCons").Value), FieldType.Numeric)
                    .AddField("LastPurchase", CDate(R.Cells("colLastPur").Value), FieldType.DateTime)
                End With
                sqlIndentDetail = qbIndentDetail.GetInsertQuery
                qbIndentDetail.ClearFields()
                COM.CommandText = sqlIndentDetail
                COM.ExecuteNonQuery()
            Next
            T.Commit()
        Catch ee As Exception
            T.Rollback()
            MsgBox("Following error occured while saving data" & vbCr & ee.Message & vbCr & "Contact SciTechIS", vbCritical, "SciTechIS")

            Exit Sub
        Finally
            C = Nothing
            COM = Nothing
            qbIndents = Nothing
            qbIndentDetail = Nothing
        End Try
        Me.Cursor = Cursors.Default
        MsgBox("Indent data is saved", MsgBoxStyle.Information, CName)
        'ClearAll()
        'FillLastData()
        LockAll(True)
        cmdAdd.Focus()
        DM = DAL.DAL.DataMode.SavedRecord
    End Sub
    Function DataIsValid() As Boolean
        If cmbDepartment.SelectedIndex = -1 Then
            MsgBox("Please select department from the list", MsgBoxStyle.Information, CName)
            cmbDepartment.Focus()
            Return False
        End If
        If cmbSection.SelectedIndex = -1 Then
            MsgBox("Please select section from the list", MsgBoxStyle.Information, CName)
            cmbSection.Focus()
            Return False
        End If
        If Trim(txtDemandBy.Text) = "" Then
            MsgBox("Please enter 'Demand By' name", MsgBoxStyle.Information, CName)
            txtDemandBy.Text = Trim(txtDemandBy.Text)
            txtDemandBy.Focus()
            Return False
        End If
        If Trim(txtStoreInCharge.Text) = "" Then
            MsgBox("Please enter 'Store In-Charge' name", MsgBoxStyle.Information, CName)
            txtStoreInCharge.Text = Trim(txtStoreInCharge.Text)
            txtStoreInCharge.Focus()
            Return False
        End If
        If Grid.Rows.Count = 0 Then
            MsgBox("Please add at least one item to the items list", MsgBoxStyle.Critical, CName)
            txtItemCode.Focus()
            Return False
        End If


        Return True

    End Function

    Private Sub fraItemDetail_Enter(sender As System.Object, e As System.EventArgs) Handles fraItemDetail.Enter

    End Sub

    Private Sub cmdEdit_Click(sender As System.Object, e As System.EventArgs) Handles cmdEdit.Click



        If Len(txtIndentNo.Text) = 0 Then
            MsgBox("No record to edit", MsgBoxStyle.Critical, CName)
            Exit Sub
        End If
        Dim Status As String = D.GetScaler("Select IndentStatus from tblIndents Where IndentNo = '" & txtIndentNo.Text & "'")
        If Status <> "OPEN" Then
            MsgBox("Current status of this indent is " & Status & ". You cannot edit it now", MsgBoxStyle.Information, CName)
            Exit Sub
        End If


        LockAll(False)
        DM = DAL.DAL.DataMode.EditRecord
        dtIndentDate.Focus()
    End Sub

    Private Sub cmdFind_Click(sender As System.Object, e As System.EventArgs) Handles cmdFind.Click
        frmIndentFind.MdiParent = frmMain
        frmIndentFind.Show()

    End Sub

    Private Sub cmdPrint_Click(sender As System.Object, e As System.EventArgs) Handles cmdPrint.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ConnInfo As New ConnectionInfo()
        Dim T As Table
        Dim R As New rptIndent
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

        R.RecordSelectionFormula = "{tblIndents.IndentNo} = '" & txtIndentNo.Text & "'"
        If Not R.HasRecords Then
            MsgBox("No records found against your selection", vbInformation, CName)
            R.Dispose()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        Dim F As New frmReport
        F.MdiParent = Me.MdiParent
        F.Text = "Indent"
        F.CRV.ReportSource = R
        F.CRV.ShowGroupTreeButton = False
        F.CRV.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        F.Text = Me.Text
        F.Show()
        F.CRV.Show()
        F.CRV.Zoom(1)
        Me.Cursor = Cursors.Default
    End Sub

    
    Private Sub cmdEmail_Click(sender As System.Object, e As System.EventArgs) Handles cmdEmail.Click
        Dim pdfFileName As String
        pdfFileName = ExportToPDF()
        'pdfFileName = "C:\GPMS Temp Files\Indent 1411-000004 141114231839.pdf"
        Me.Cursor = Cursors.WaitCursor
        Dim SM As New frmSendEmail
        SM.txtAttachment.Tag = pdfFileName
        SM.txtAttachment.Text = Path.GetFileName(pdfFileName)
        SM.txtBody.Tag = "Dear Sir"
        'SM.txtBody.Tag = "Dear " & ShipmentDetailIDtoClientName(txtShipmentDetailID.Text) & "," & vbCrLf & vbCrLf & _
        '                 "Please find attached Dispatch Report of " & ShipmentDetailIDtoProjectTitle(txtShipmentDetailID.Text) & _
        '                 " MV: " & txtVesselName.Text & " B/L No. " & txtBLNo.Text & vbCrLf & vbCrLf & _
        '                 "Feel free to contact for any further detail" & vbCrLf & vbCrLf & _
        '                 "Note: This is system generated report and email"
        SM.txtSubject.Text = "New Indent for Approval (#" & txtIndentNo.Text & ")"
        SM.IndentNo = txtIndentNo.Text
        SM.ShowDialog()

        Me.Cursor = Cursors.Default
    End Sub
    Function ExportToPDF() As String
        Me.Cursor = Cursors.WaitCursor
        Dim pdfFilePath As String = "C:\GPMS Temp Files"
        If Not Directory.Exists(pdfFilePath) Then Directory.CreateDirectory(pdfFilePath)
        'Dim pdfFileName As String = pdfFilePath & "\Indent " & txtIndentNo.Text & Format(Now, "dd-MM-yy HH:mm:ss") & ".pdf"
        Dim pdfFileName As String = pdfFilePath & "\Indent " & txtIndentNo.Text & " " & Format(Now, "ddMMyyHHmmss") & ".pdf"
        Dim R As New rptIndent
        Dim ConnInfo As New ConnectionInfo()
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

        R.RecordSelectionFormula = "{tblIndents.IndentNo} = '" & txtIndentNo.Text & "'"
        


        Try
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
            CrDiskFileDestinationOptions.DiskFileName = pdfFileName
            CrExportOptions = R.ExportOptions
            'Report document  object has to be given here
            CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
            CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat
            CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions
            CrExportOptions.FormatOptions = CrFormatTypeOptions
            R.Export()
            Return pdfFileName

        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""
        End Try
        Me.Cursor = Cursors.Default
    End Function

    Private Sub cmdEditItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditItem.Click


        Dim R As DataGridViewRow
        R = Grid.CurrentRow
        'If e.ColumnIndex = colQty.Index Or e.ColumnIndex = colUnitRate.Index Then
        '    R.Cells("colAmount").Value = Val(R.Cells("colQty").Value) * Val(R.Cells("colUnitRate").Value)
        'End If
        'CalcTotal()

        If Grid.Rows.Count = 0 Then
            MsgBox("No record selected", MsgBoxStyle.Information, CName)
            Exit Sub
        End If


        txtItemCode.Text = R.Cells("colItemCode").Value
        txtItemCode.Enabled = False
        txtItemDescription.Text = R.Cells("colDescription").Value
        txtItemDescription.Enabled = False
        txtQuantity.Text = R.Cells("colQty").Value

    End Sub

    Private Sub cmdRemoveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveItem.Click       
        If Grid.Rows.Count = 0 Then
            MsgBox("No record selected", MsgBoxStyle.Information, CName)
            Exit Sub
        End If
        Dim R As DataGridViewRow
        R = Grid.CurrentRow

        Try
            D.ExecuteNonQuery("Delete from tblIndentDetail where IndentNo = '" & txtIndentNo.Text.Trim() & "' And ItemID = '" & R.Cells("colItemCode").Value.ToString().Trim() & "'")            
            FillLastData()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtIndentNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIndentNo.TextChanged

    End Sub
End Class