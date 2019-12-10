Imports System.Data
Imports System.Data.SqlClient
Public Class frmApproveIndent
    Dim D As New DAL.DAL
    Dim DT As New DataTable
    Dim bsIndents As New BindingSource
    Private Sub frmApproveIndent_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FillGridIndents()
        'DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
        '    cmb.HeaderText = "Select Data";
        '    cmb.Name = "cmb";
        '    cmb.MaxDropDownItems = 4;
        '    cmb.Items.Add("True");
        '    cmb.Items.Add("False");
        '    dataGridView1.Columns.Add(cmb);
        'Dim cmb As New DataGridViewComboBoxColumn
        'cmb.HeaderText = "Hello"
        'cmb.MaxDropDownItems = 4
        'cmb.Items.Add("Approve")
        'cmb.Items.Add("Reject")
        'GridDetail.Columns.Add(cmb)
        '        foreach (DataGridViewRow row in dataGridView1.Rows)
        '{
        '    DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)(row.Cells["abc"]);
        '    cell.DataSource = new string[] { "a", "c" };
        '}
        'For Each R As DataGridViewRow In GridDetail.Rows
        '    Dim C As DataGridViewComboBoxCell = R.Cells("colDelete")
        '    C.DataSource = New String() {"a", "b"}

        'Next

    End Sub
    Sub FillGridIndents()
        'DT = D.GetDataTable("SELECT Code, Description, [Short Description], Category, Unit, Vendor FROM vwItems")
        'BS.Filter = ""
        'BS.DataSource = DT
        'Grid.DataSource = BS
        DT = D.GetDataTable("Select * from vwIndents Where Status IN ('OPEN','HOLD')")
        bsIndents.Filter = ""
        bsIndents.DataSource = DT
        GridIndents.DataSource = bsIndents
        GridIndents.Refresh()

    End Sub

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub



    Private Sub GridIndents_SelectionChanged(sender As Object, e As System.EventArgs) Handles GridIndents.SelectionChanged
        If GridIndents.Rows.Count = 0 Then
            FillIndentDetail("0")

        Else
            FillIndentDetail(GridIndents.Rows(GridIndents.CurrentRow.Index).Cells("colIndentNo").Value)
        End If


        '.Rows(.CurrentRow.Index).Cells("colCode").Value()
    End Sub
    Sub FillIndentDetail(IndentNo As String)
        GridDetail.DataSource = D.GetDataTable("Select * from vwIndentDetail where IndentNo = '" & IndentNo & "'")
        GridDetail.Refresh()
        For Each R As DataGridViewRow In GridDetail.Rows
            R.Cells("colApproved").Value = True
        Next
    End Sub

    Private Sub cmdRefresh_Click(sender As System.Object, e As System.EventArgs) Handles cmdRefresh.Click
        RefreshIndents()
    End Sub
    Private Sub RefreshIndents()
        FillGridIndents()
        txtFindIndent.Text = ""
    End Sub
    Private Sub cmdIndent_Click(sender As System.Object, e As System.EventArgs) Handles cmdFindIndent.Click
        bsIndents.Filter = "[Indent No] + Department + Section + [Demand By] + [Store In-Charge] + Status like '%" & txtFindIndent.Text & "%'"
    End Sub

    Private Sub cmdClearSearch_Click(sender As System.Object, e As System.EventArgs) Handles cmdClearSearch.Click
        txtFindIndent.Text = ""
        bsIndents.Filter = ""
    End Sub

    Private Sub txtFindIndent_GotFocus(sender As Object, e As System.EventArgs) Handles txtFindIndent.GotFocus
        Me.AcceptButton = cmdFindIndent
    End Sub

    Private Sub txtFindIndent_LostFocus(sender As Object, e As System.EventArgs) Handles txtFindIndent.LostFocus
        Me.AcceptButton = Nothing

    End Sub

    Private Sub txtFindIndent_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFindIndent.TextChanged

    End Sub


    Private Sub GridDetail_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridDetail.CellContentClick
        If GridDetail.Rows.Count = 0 Then Exit Sub

        If e.ColumnIndex = GridDetail.Columns("colEdit").Index Then
            Dim ActualQty As Single

            Dim R As DataGridViewRow = GridDetail.CurrentRow
            ActualQty = R.Cells("colqty").Value

            Dim Q As Single
            Q = Val(InputBox("Please enter new quantity for " & R.Cells("colDescription").Value, "Edit Item Quantity", R.Cells("colQty").Value))
            If Q <= 0 Then Exit Sub
            If Q > ActualQty Then
                MsgBox("You cannot approve quantity more than required as per indent", MsgBoxStyle.Critical, CName)
            Else
                R.Cells("colQty").Value = Q
            End If

        ElseIf e.ColumnIndex = GridDetail.Columns("colApproved").Index Then
            'do nothing
        End If
    End Sub
    'Private Sub dataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
    '    If dataGridView1.CurrentCell.ColumnIndex = 1 AndAlso TypeOf e.Control Is ComboBox Then
    '        Dim comboBox As ComboBox = TryCast(e.Control, ComboBox)
    '        AddHandler comboBox.SelectedIndexChanged, AddressOf LastColumnComboSelectionChanged
    '    End If
    'End Sub

    'Private Sub LastColumnComboSelectionChanged(sender As Object, e As EventArgs)
    '    Dim currentcell = dataGridView1.CurrentCellAddress
    '    Dim sendingCB = TryCast(sender, DataGridViewComboBoxEditingControl)
    '    Dim cel As DataGridViewTextBoxCell = DirectCast(dataGridView1.Rows(currentcell.Y).Cells(0), DataGridViewTextBoxCell)
    '    cel.Value = sendingCB.EditingControlFormattedValue.ToString()






    Private Sub GridDetail_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles GridDetail.EditingControlShowing
        'If GridDetail.CurrentCell.ColumnIndex = GridDetail.Columns("colAction").Index Then
        '    Dim C As ComboBox = TryCast(e.Control, ComboBox)
        '    AddHandler C.SelectedIndexChanged, AddressOf ApprovalChanged

        'End If
        'If GridDetail.CurrentCell.ColumnIndex = GridDetail.Columns("colTest").Index Then
        '    Dim C As CheckBox = TryCast(e.Control, CheckBox)
        '    AddHandler C.CheckedChanged, AddressOf ApprovalChanged

        'End If

    End Sub
    Private Sub ApprovalChanged(sender As Object, e As EventArgs)
        'Dim currentcell = GridDetail.CurrentCellAddress
        'Dim sendingCB = TryCast(sender, DataGridViewComboBoxEditingControl)
        ''Dim cel As DataGridViewTextBoxCell = DirectCast(GridDetail.Rows(currentcell.Y).Cells(0), DataGridViewTextBoxCell)
        ''cel.Value = sendingCB.EditingControlFormattedValue.ToString()
        'If sendingCB.EditingControlFormattedValue.ToString = "Reject" Then
        '    GridDetail.CurrentRow.DefaultCellStyle.BackColor = Color.Red
        'Else
        '    GridDetail.CurrentRow.DefaultCellStyle.BackColor = Color.White
        'End If


        'Dim R As DataGridViewRow = GridDetail.CurrentRow
        'Dim C As ComboBox = TryCast(sender, ComboBox)
        'If C. = 0 Then

        '    R.DefaultCellStyle.BackColor = Color.Red
        'Else
        '    R.DefaultCellStyle.BackColor = Color.White
        'End If
    End Sub


    Private Sub cmdApprove_Click(sender As System.Object, e As System.EventArgs) Handles cmdApprove.Click
        If GridIndents.Rows.Count = 0 Then
            MsgBox("No indent selected to approve", MsgBoxStyle.Critical, CName)
            Exit Sub
        End If
        'Dim R As DataGridViewRow = GridIndents.CurrentRow 
        If Not D.IsRecordExists("tblIndents", "IndentNo", GridIndents.Rows(GridIndents.CurrentRow.Index).Cells("colIndentNo").Value) Then
            MsgBox("Selected Indent No not found in record", MsgBoxStyle.Information, CName)
            Exit Sub
        End If
        Dim strSQL1, strSQL2 As String
        Dim IndentNo As String = GridIndents.Rows(GridIndents.CurrentRow.Index).Cells("colIndentNo").Value

        strSQL1 = "UPDATE tblIndents " & _
                   "SET IndentStatus ='APPROVED', " & _
                   "IndentActionDate ='" & Now & "', " & _
                   "IndentActionRemarks = ''" & ", " & _
                   "IndentActionByID = " & CurrentUser.UserID & _
                   "WHERE IndentNo = '" & IndentNo & "'"

        Dim C As New SqlConnection
        Dim COM As New SqlCommand
        Dim T As SqlTransaction
        Me.Cursor = Cursors.WaitCursor
        Try
            C.ConnectionString = D.ConStr
            C.Open()
            T = C.BeginTransaction(IsolationLevel.ReadCommitted)
            COM.Connection = C
            COM.Transaction = T
            COM.CommandText = strSQL1
            COM.ExecuteNonQuery()

            Dim ItemID As String
            Dim isApproved As Boolean
            Dim ApprovedQty As Single
            For Each R As DataGridViewRow In GridDetail.Rows
                ItemID = R.Cells("colItemID").Value
                isApproved = CBool(R.Cells("colApproved").Value)
                ApprovedQty = CSng(R.Cells("colQty").Value)
                strSQL2 = "Update tblIndentDetail " & _
                          "SET ApprovedQty =" & ApprovedQty & ", " & _
                          "isApproved ='" & isApproved & "' " & _
                          "WHERE ItemID = '" & ItemID & "' AND IndentNo = '" & IndentNo & "'"
                D.ExecuteNonQuery(strSQL2)

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
        End Try

        Me.Cursor = Cursors.Default
        MsgBox("Approval processed successfully", MsgBoxStyle.Information, CName)
        RefreshIndents()

    End Sub

   
    Private Sub cmdReject_Click(sender As System.Object, e As System.EventArgs) Handles cmdReject.Click
        If GridIndents.Rows.Count = 0 Then
            MsgBox("No indent selected to take action", MsgBoxStyle.Critical, CName)
            Exit Sub
        End If
        'Dim R As DataGridViewRow = GridIndents.CurrentRow 
        If Not D.IsRecordExists("tblIndents", "IndentNo", GridIndents.Rows(GridIndents.CurrentRow.Index).Cells("colIndentNo").Value) Then
            MsgBox("Selected Indent No not found in record", MsgBoxStyle.Information, CName)
            Exit Sub
        End If
        Dim strSQL1 As String
        Dim IndentNo As String = GridIndents.Rows(GridIndents.CurrentRow.Index).Cells("colIndentNo").Value
        strSQL1 = "UPDATE    tblIndents " & _
                  "SET IndentStatus = 'REJECTED' " & _
                  "WHERE IndentNo = '" & IndentNo & "'"
        Me.Cursor = Cursors.WaitCursor

        Try
            D.ExecuteNonQuery(strSQL1)
        Catch ee As Exception
            MsgBox("Following error occured while saving data" & vbCr & ee.Message & vbCr & "Contact SciTechIS", vbCritical, "SciTechIS")
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
        Me.Cursor = Cursors.Default
        MsgBox("Indent No." & IndentNo & " is rejected successfully", MsgBoxStyle.Information, CName)
        RefreshIndents()

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

    End Sub
End Class