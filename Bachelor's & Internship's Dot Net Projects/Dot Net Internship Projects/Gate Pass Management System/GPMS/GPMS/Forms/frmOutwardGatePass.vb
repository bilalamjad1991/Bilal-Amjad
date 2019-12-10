Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmOutwardGatePass
    Dim DM As DAL.DAL.DataMode
    Dim D As New DAL.DAL
    Private Sub frmOutwardGatePass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LockAll(True)
        FillLastData()
        ''''''''''''''''''''''''''''' 

        ''''''''''''''''''''''''''''''
        For Each C As DataGridViewColumn In Grid.Columns
            C.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
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
        dtDate.Enabled = False

    End Sub
    Sub ClearAll()
        txtSRNNo.Text = ""
        dtDate.Value = Now.Date
        optHeadOffice.Checked = True
        txtAllow.Text = ""
        txtDesignation.Text = ""
        txtPurpose.Text = ""
        txtDesignation.Text = ""
        txtDestination.Text = ""
        Grid.Rows.Clear()
        txtTotal.Text = ""
    End Sub
    Sub FillLastData()
        Dim IndID As String
        IndID = D.GetScaler("Select max(SRNNo) from tblSRN")
        If IndID = "" Then
            ClearAll()
        Else
            FillData(IndID)
        End If
    End Sub
    Public Sub FillData(ByVal ID As String)

        Dim DT As New DataTable
        DT = D.GetDataTable("Select * from tblSRN where SRNNo = '" & ID & "'")
        ClearAll()
        txtSRNNo.Text = ID
        dtDate.Value = DT.Rows(0).Item("SRNDate")
        'txtVehicleNo.Text = DT.Rows(0).Item("dcVehicleNo")
        'txtIndentNo.Text = DT.Rows(0).Item("IndentNo")
        'txtTotal.Text = DT.Rows(0)("dcTotalAmount")


        DT = D.GetDataTable("Select * from tblSRNDetail Where SRNNo = '" & ID & "'")
        Grid.AllowUserToAddRows = True

        For Each R As DataRow In DT.Rows
            Dim GRow As DataGridViewRow = Grid.Rows(Grid.NewRowIndex).Clone
            With GRow
                .Cells(colItemID.Index).Value = R("SRNItemID")
                .Cells(colDescription.Index).Value = R("SRNItemDesc")
                .Cells(colUOM.Index).Value = R("SRNItemUnit")
                '.Cells(colBrand.Index).Value = R("Brand")
                '.Cells(colQty.Index).Value = R("Quantity")

            End With
            Grid.Rows.Add(GRow)
        Next
        Grid.AllowUserToAddRows = False
        'CalcTotal()
    End Sub
    Sub CalcTotal()
        Dim N As Long
        For Each R As DataGridViewRow In Grid.Rows
            N += R.Cells("colQty").Value
        Next
        txtTotal.Text = N
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        'ClearAll()
        txtOGPNo.Text = GetNewOGP()
        LockAll(False)
        txtOGPNo.Focus()
        DM = DAL.DAL.DataMode.NewRecord
    End Sub
    Function GetNewOGP() As String

        'format = MMYY-000001
        '  Dim PreFix As String = Format(Now.Date, "yyMM") & "-"
        'Dim N As String = D.GetScaler("Select Max(OGPNo) from tblOutwardGatePass where OGPNo like '" & PreFix & "%'")
        Dim N As String = D.GetScaler("Select Max(OGPNo) from tblOutwardGatePass")
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
            'Return PreFix & N
            Return N
        End If

    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If Not DataIsValid() Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim qbMaster As New QueryBuilder("tblOutwardGatePass")
        Dim qbDetail As New QueryBuilder("tblOutwardGatePassDetail")
        Dim strVal As String


        If rdbtnNR.Checked = True Then
            strVal = "NonReturnable"
        Else
            strVal = "Returnable"
        End If

        Dim sqlMaster, sqlDetail As String
        With qbMaster
            .AddField("OGPNo", txtOGPNo.Text, FieldType.Text)
            .AddField("OGPSRNNo", txtSRNNo.Text, FieldType.Text)
            .AddField("OGPSRNDate", dtDate.Value, FieldType.DateTime)
            .AddField("OGPType", strVal, FieldType.Text)
            .AddField("OGPPersonAllowed", txtAllow.Text, FieldType.Text)
            .AddField("OGPDesignation", txtDesignation.Text, FieldType.Text)
            .AddField("OGPDestination", txtDestination.Text, FieldType.Text)
            .AddField("OGPPurpose", txtPurpose.Text, FieldType.Text)
            .AddField("OGPCreatedBy", CurrentUser.UserID, FieldType.Numeric)
            .AddField("OGPCretaedOn", Now, FieldType.DateTime)
            .AddField("OGPSystem", CurrentUser.SystemName, FieldType.Text)
        End With

        If DM = DAL.DAL.DataMode.NewRecord Then
            sqlMaster = qbMaster.GetInsertQuery
        ElseIf DM = DAL.DAL.DataMode.EditRecord Then
            qbMaster.RemoveField("OGPNo")
            qbMaster.InsertDeleteFilterField("OGPNo", txtOGPNo.Text, FieldType.Text)

            qbMaster.RemoveField("OGPCreatedBy")
            qbMaster.RemoveField("OGPCretaedOn")
            qbMaster.AddField("OGPCreatedBy", CurrentUser.UserID, FieldType.Text)
            qbMaster.AddField("OGPCretaedOn", Now, FieldType.DateTime)
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
                COM.CommandText = "Delete from tblOutwardGatePassDetail Where OGPNo = '" & txtOGPNo.Text & "'"
                COM.ExecuteNonQuery()
            End If
            For Each R As DataGridViewRow In Grid.Rows
                With qbDetail
                    .AddField("OGPNo", txtOGPNo.Text, FieldType.Text)
                    .AddField("OGPItemID", R.Cells("colItemID").Value, FieldType.Text)
                    .AddField("OGPItemDesc", R.Cells("colDescription").Value, FieldType.Text)
                    .AddField("OGPItemNumber", R.Cells("colUOM").Value, FieldType.Text)
                    .AddField("OGPItemUnit", R.Cells("colNumber").Value, FieldType.Numeric)
                    .AddField("OGPEDR", R.Cells("colEDR").Value, FieldType.Text)
                    .AddField("OGPRemarks", R.Cells("colRemarks").Value, FieldType.Text)

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
        MsgBox("Out Gate Pass is saved", MsgBoxStyle.Information, CName)
        'ClearAll()
        FillLastData()
        LockAll(True)
        cmdAdd.Focus()
        DM = DAL.DAL.DataMode.SavedRecord
    End Sub
    Function DataIsValid() As Boolean
        DataIsValid = True
        ' validations for gridview cells        
        If Len(txtAllow.Text) = 0 Then
            MsgBox("Please enter allows items", MsgBoxStyle.Information, CName)
            txtAllow.Focus()
            Return False
        End If
        If Len(txtDesignation.Text) = 0 Then
            MsgBox("Please enter designation", MsgBoxStyle.Information, CName)
            txtDesignation.Focus()
            Return False
        End If
        If Len(txtDestination.Text) = 0 Then
            MsgBox("Please enter destination", MsgBoxStyle.Information, CName)
            txtDestination.Focus()
            Return False
        End If
        If Len(txtPurpose.Text) = 0 Then
            MsgBox("Please enter purpose", MsgBoxStyle.Information, CName)
            txtPurpose.Focus()
            Return False
        End If    
        If Grid.Rows.Count = 0 Then
            MsgBox("Please add atleast one item to the list", MsgBoxStyle.Information, CName)
            txtItemID.Focus()
            Return False
        End If
        For r = 0 To Grid.RowCount - 1
            If (Grid.Rows(r).Cells.Item(3).Value) = "" Then
                MsgBox("Enter the Number ", MsgBoxStyle.Information, CName)
                Return False
            End If
            If (Grid.Rows(r).Cells.Item(4).Value) = "" Then
                MsgBox("Enter the EDR ", MsgBoxStyle.Information, CName)
                Return False
            End If
            If (Grid.Rows(r).Cells.Item(5).Value) = "" Then
                MsgBox("Enter the Remarks ", MsgBoxStyle.Information, CName)
                Return False
            End If
        Next
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

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Me.Cursor = Cursors.WaitCursor
        frmSRNFind.MdiParent = frmMain
        frmSRNFind.Show()
        Me.Cursor = Cursors.Default

        Me.cmdAdd.Visible = True
        Me.cmdAdd.PerformClick()
        Me.cmdAdd.Visible = False


    End Sub


End Class