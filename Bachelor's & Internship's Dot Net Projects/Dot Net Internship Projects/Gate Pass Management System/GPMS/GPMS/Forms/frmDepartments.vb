Imports System.Data
Imports System.Data.SqlClient
Public Class frmDepartments
    Dim DM As DAL.DAL.DataMode
    Dim D As New DAL.DAL
    Private Sub frmItemCategories_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Lockall(True)
        DM = DAL.DAL.DataMode.SavedRecord
        FillGrid()
    End Sub
    Sub Lockall(ByVal OK As Boolean)
        cmdAdd.Enabled = OK
        cmdSave.Enabled = Not OK
        cmdCancel.Enabled = Not OK
        cmdEdit.Enabled = OK
        cmdClose.Enabled = OK
        Grid.Enabled = OK
        GB.Enabled = Not OK
    End Sub
    Sub FillGrid()
        Grid.DataSource = D.GetDataTable("Select * from tblDepartments Order By deptID")
        Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        DM = DAL.DAL.DataMode.NewRecord
        Lockall(False)
        ClearAll()
        txtCode.Text = GetNewID()
        txtName.Focus()
    End Sub
    Function GetNewID() As String
        Me.Cursor = Cursors.WaitCursor
        Dim S As String
        Dim N As Integer
        S = D.GetScaler("Select Max(deptID) from tblDepartments")
        If S = "" Then
            Me.Cursor = Cursors.Default
            Return "001"
        Else
            N = CInt(S)
            N += 1
            S = N
            Select Case Len(S)
                Case 1 : S = "00" & S
                Case 2 : S = "0" & S
            End Select
            Me.Cursor = Cursors.Default
            Return S
        End If
    End Function

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Lockall(True)
        DM = DAL.DAL.DataMode.SavedRecord
        ClearAll()
        cmdAdd.Focus()

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If Not DataIsValid() Then Exit Sub
        SaveRec()
    End Sub
    Function DataIsValid() As Boolean
        If Len(Trim(txtName.Text)) = 0 Then
            MsgBox("Please enter a valid name", MsgBoxStyle.Critical, CName)
            txtName.Focus()
            Return False
        End If



        Return True
    End Function
    Sub SaveRec()
        Dim QB As New QueryBuilder("tblDepartments")
        Dim strSQL As String
        With QB
            .AddField("deptID", txtCode.Text, FieldType.Text)
            .AddField("deptName", txtName.Text, FieldType.Text)
        End With
        If DM = DAL.DAL.DataMode.NewRecord Then
            strSQL = QB.GetInsertQuery
        ElseIf DM = DAL.DAL.DataMode.EditRecord Then
            QB.RemoveField("deptID")
            QB.InsertDeleteFilterField("deptID", txtCode.Text, FieldType.Text)
            strSQL = QB.GetUpdateQuery
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
            COM.CommandText = strSQL
            COM.ExecuteNonQuery()
            T.Commit()
        Catch e As Exception
            T.Rollback()
            MsgBox("Following error occured While saving data" & vbCr & e.Message & vbCr & "Contact SciTechIS", vbCritical, "SciTechIS")
            Me.Cursor = Cursors.Default

            Exit Sub
        Finally
            C = Nothing
            COM = Nothing
            QB = Nothing

        End Try
        Me.Cursor = Cursors.Default
        FillGrid()
        MsgBox("Data of department is saved", MsgBoxStyle.Information, CName)
        ClearAll()
        Lockall(True)
        cmdAdd.Focus()
        DM = DAL.DAL.DataMode.SavedRecord
    End Sub
    Sub ClearAll()
        txtCode.Text = ""
        txtName.Text = ""
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        If Len(txtCode.Text) = 0 Then
            MsgBox("Please select record from table", vbInformation, CName)
            Grid.Focus()
            Exit Sub
        End If
        DM = DAL.DAL.DataMode.EditRecord

        Lockall(False)

        txtName.Focus()
    End Sub

    Private Sub Grid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellContentClick

    End Sub

    Private Sub Grid_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.SelectionChanged
        With Grid
            If .Rows.Count > 0 Then
                FillData(.Rows(.CurrentRow.Index).Cells("colDeptID").Value)
            End If
        End With
    End Sub
    Sub FillData(ByVal ID As String)
        Me.Cursor = Cursors.WaitCursor
        Dim DT As New DataTable
        DT = D.GetDataTable("Select * from tblDepartments Where deptID = " & ID)
        With DT
            If DT.Rows.Count > 0 Then
                txtCode.Text = .Rows(0).Item("deptID")
                txtName.Text = .Rows(0).Item("deptName")
            End If
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtName.KeyDown
        If e.KeyCode = Keys.Enter Then cmdSave.Focus()

    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged

    End Sub
End Class