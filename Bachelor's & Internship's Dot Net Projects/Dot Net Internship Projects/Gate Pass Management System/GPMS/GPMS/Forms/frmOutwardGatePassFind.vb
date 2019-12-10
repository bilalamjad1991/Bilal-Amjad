Public Class frmOutwardGatePassFind
    Dim D As New DAL.DAL

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Dim S As String
        Me.Cursor = Cursors.WaitCursor
        S = "SELECT OGPNo as IGP_No,OGPDate as Date FROM tblSRN " & _
            "WHERE OGPNo like '%" & txtFind.Text & "%'" & IIf(dtDate.Checked, " AND convert(varchar(10),OGPDate,105) ='" & Format(dtDate.Value, "dd-MM-yyyy") & "'", "")

        Grid.DataSource = D.GetDataTable(S)
        Grid.Refresh()
        If Grid.Rows.Count = 0 Then
            cmdSelect.Enabled = False
        Else
            cmdSelect.Enabled = True
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub frmOutwardGatePassFind_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillGrid()
        dtDate.Value = Now.Date
    End Sub

    Sub FillGrid()
        Me.Cursor = Cursors.WaitCursor
        Grid.DataSource = D.GetDataTable("SELECT OGPNo as OGP_No,OGPCretaedOn as Date FROM tblOutwardGatePass")
        Grid.Refresh()
        If Grid.Rows.Count = 0 Then
            cmdSelect.Enabled = False
        Else
            cmdSelect.Enabled = True
        End If
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub txtFind_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFind.GotFocus, dtDate.GotFocus
        Me.AcceptButton = cmdFind
    End Sub

    Private Sub cmdSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelect.Click
        If Grid.Rows.Count = 0 Then
            MsgBox("No record selected", MsgBoxStyle.Information, CName)
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        'frmOutwardGatePass.FillData(Grid.CurrentRow.Cells(0).Value)
        frmInwardGatePass.txtOutGatePassNo.Text = Grid.CurrentRow.Cells(0).Value
        frmInwardGatePass.dtOutDate.Text = Grid.CurrentRow.Cells(1).Value

        Me.Close()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
End Class