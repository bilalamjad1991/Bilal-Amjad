Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmDeliveryChallan
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
        For Each C As DataGridViewColumn In Grid.Columns
            C.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        DM = DAL.DAL.DataMode.SavedRecord
    End Sub

    Sub CalcTotal()
        Dim N As Long
        For Each R As DataGridViewRow In Grid.Rows
            N += R.Cells("colAmount").Value
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
        fraDeliveryChallan.Enabled = Not OK
        fraDetail.Enabled = Not OK
    End Sub
    Sub ClearAll()
        txtDCNo.Text = ""
        dtDeliveryDate.Value = Now.Date
        txtVehicleNo.Text = ""
        txtIndentNo.Text = ""
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
        txtDCNo.Text = GetNewDCNo()
        LockAll(False)
        dtDeliveryDate.Focus()
        DM = DAL.DAL.DataMode.NewRecord
    End Sub
    Function GetNewDCNo() As String

        'format = MMYY-000001
        Dim PreFix As String = Format(Now.Date, "yyMM") & "-"
        Dim N As String = D.GetScaler("Select Max(dcNo) from tblDeliveryChallans where dcNo like '" & PreFix & "%'")
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

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        LockAll(True)
        DM = DAL.DAL.DataMode.SavedRecord
        cmdAdd.Focus()
        ClearAll()
        FillLastData()
        cmdLoadIndent.Enabled = True
    End Sub

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdLoadIndent_Click(sender As System.Object, e As System.EventArgs) Handles cmdLoadIndent.Click
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
        Dim R As DataGridViewRow
        R = Grid.CurrentRow
        If e.ColumnIndex = colQty.Index Or e.ColumnIndex = colUnitRate.Index Then
            R.Cells("colAmount").Value = Val(R.Cells("colQty").Value) * Val(R.Cells("colUnitRate").Value)
        End If
        CalcTotal()
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
        Dim qbMaster As New QueryBuilder("tblDeliveryChallans")
        Dim qbDetail As New QueryBuilder("tblDeliveryChallanDetail")
        Dim sqlMaster, sqlDetail As String
        With qbMaster
            .AddField("dcNo", txtDCNo.Text, FieldType.Text)
            .AddField("dcDate", dtDeliveryDate.Value, FieldType.DateTime)
            .AddField("dcVehicleNo", txtVehicleNo.Text, FieldType.Text)
            .AddField("IndentNo", txtIndentNo.Text, FieldType.Text)
            .AddField("dcTotalAmount", txtTotal.Text, FieldType.Numeric)
            .AddField("dcCreatedBy", CurrentUser.UserID, FieldType.Numeric)
            .AddField("dcCreatedOn", Now, FieldType.DateTime)
            .AddField("dcSystem", CurrentUser.SystemName, FieldType.Text)

        End With
        If DM = DAL.DAL.DataMode.NewRecord Then
            sqlMaster = qbMaster.GetInsertQuery
        ElseIf DM = DAL.DAL.DataMode.EditRecord Then
            qbMaster.RemoveField("dcNo")
            qbMaster.InsertDeleteFilterField("dcNO", txtDCNo.Text, FieldType.Text)
            qbMaster.RemoveField("dcCreatedBy")
            qbMaster.RemoveField("dcCreatedOn")
            qbMaster.AddField("dcEditedBy", CurrentUser.UserID, FieldType.Text)
            qbMaster.AddField("dcEditedOn", Now, FieldType.DateTime)
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
                COM.CommandText = "Delete from tblDeliveryChallanDetail Where dcNo = '" & txtDCNo.Text & "'"
                COM.ExecuteNonQuery()
            End If
            For Each R As DataGridViewRow In Grid.Rows
                With qbDetail
                    .AddField("dcNo", txtDCNo.Text, FieldType.Text)
                    .AddField("ItemID", R.Cells("colItemID").Value, FieldType.Text)
                    .AddField("Brand", R.Cells("colBrand").Value, FieldType.Text)
                    .AddField("Quantity", Val1(R.Cells("colQty").Value), FieldType.Numeric)
                    .AddField("UnitRate", Val1(R.Cells("colUnitRate").Value), FieldType.Numeric)

                End With
                sqlDetail = qbDetail.GetInsertQuery
                qbDetail.ClearFields()
                COM.CommandText = sqlDetail
                COM.ExecuteNonQuery()
            Next
            COM.CommandText = "Update tblIndents SET IndentStatus = 'CLOSED' Where IndentNo='" & txtIndentNo.Text & "'"
            COM.ExecuteNonQuery()
            T.Commit()
        Catch ee As Exception
            T.Rollback()
            MsgBox("Following error occured while saving data" & vbCr & ee.Message & vbCr & "Contact SciTechIS", vbCritical, "SciTechIS")

            Exit Sub
        Finally
            C = Nothing
            COM = Nothing
            qbMaster = Nothing
            qbDetail = Nothing
        End Try
        Me.Cursor = Cursors.Default
        MsgBox("Delivery Challan is saved", MsgBoxStyle.Information, CName)
        'ClearAll()
        FillLastData()
        LockAll(True)
        cmdAdd.Focus()
        DM = DAL.DAL.DataMode.SavedRecord
        cmdLoadIndent.Enabled = True
    End Sub
    Function DataIsValid() As Boolean
        DataIsValid = True
        If txtVehicleNo.Text = "" Then
            MsgBox("Please enter a valid vehicle no", MsgBoxStyle.Information, CName)
            txtVehicleNo.Focus()
            Return False
        End If
        If txtIndentNo.Text = "" Then
            MsgBox("Please select an indent first", MsgBoxStyle.Information, CName)
            cmdLoadIndent.Focus()
            Return False
        End If

    End Function
    Public Sub FillData(ByVal ID As String)

        Dim DT As New DataTable
        DT = D.GetDataTable("Select * from tblDeliveryChallans where dcNo = '" & ID & "'")
        ClearAll()
        txtDCNo.Text = ID
        dtDeliveryDate.Value = DT.Rows(0).Item("dcDate")
        txtVehicleNo.Text = DT.Rows(0).Item("dcVehicleNo")
        txtIndentNo.Text = DT.Rows(0).Item("IndentNo")
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
                .Cells(colUnitRate.Index).Value = R("UnitRate")
                .Cells(colAmount.Index).Value = Val(R("Quantity")) * Val(R("UnitRate"))
            End With
            Grid.Rows.Add(GRow)
        Next
        Grid.AllowUserToAddRows = False
        CalcTotal()
    End Sub

    Private Sub cmdEdit_Click(sender As System.Object, e As System.EventArgs) Handles cmdEdit.Click
        If Len(txtDCNo.Text) = 0 Then
            MsgBox("No record to edit", MsgBoxStyle.Critical, CName)
            Exit Sub
        End If
        LockAll(False)
        cmdLoadIndent.Enabled = False
        DM = DAL.DAL.DataMode.EditRecord
        dtDeliveryDate.Focus()
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

        R.RecordSelectionFormula = "{tblDeliveryChallans.dcNo} = '" & txtDCNo.Text & "'"
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
End Class
