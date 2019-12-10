Public Class frmDeliveryChallanFind
    Dim D As New DAL.DAL
    Private Sub frmPurchaseFind_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillGrid()
        dtDate.Value = Now.Date
    End Sub
    Sub FillGrid()
        Me.Cursor = Cursors.WaitCursor
        Grid.DataSource = D.GetDataTable("SELECT dcNo,dcDate,dcVehicleNo, IndentNo, dcTotalAmount  FROM tblDeliveryChallans")
        Grid.Refresh()
        If Grid.Rows.Count = 0 Then
            cmdSelect.Enabled = False
        Else
            cmdSelect.Enabled = True
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        FillGrid()
        dtDate.Checked = True
        txtFind.Text = ""
        txtFind.Focus()

    End Sub

    Private Sub txtFind_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFind.GotFocus, dtDate.GotFocus
        Me.AcceptButton = cmdFind

    End Sub

    Private Sub txtFind_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFind.LostFocus, dtDate.LostFocus
        Me.AcceptButton = Nothing
    End Sub
    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Dim S As String
        Me.Cursor = Cursors.WaitCursor
        S = "SELECT dcNo,dcDate,dcVehicleNo, IndentNo, dcTotalAmount  FROM tblDeliveryChallans " & _
            "WHERE dcNo + IndentNo like '%" & txtFind.Text & "%'" & IIf(dtDate.Checked, " AND convert(varchar(10),dcDate,105) ='" & Format(dtDate.Value, "dd-MM-yyyy") & "'", "")

        Grid.DataSource = D.GetDataTable(S)
        Grid.Refresh()
        If Grid.Rows.Count = 0 Then
            cmdSelect.Enabled = False
        Else
            cmdSelect.Enabled = True
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub



    Private Sub cmdSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelect.Click
        If Grid.Rows.Count = 0 Then
            MsgBox("No record selected", MsgBoxStyle.Information, CName)
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        frmDeliveryChallan.FillData(Grid.CurrentRow.Cells("coldcNo").Value)
        Me.Close()
        Me.Cursor = Cursors.Default


    End Sub


    Private Sub dtDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtDate.ValueChanged

    End Sub
End Class