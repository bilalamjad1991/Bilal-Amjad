Public Class Form1

    Private Sub btnCmputeGross_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCmputeGross.Click
        Dim objclass As New gorss_pay
        Dim max_hour As Integer
        max_hour = 40.0
        Dim pay As Integer
        pay = objclass.compute_gross(CType(txtHours.Text.ToString(), Integer), CType(txtHrlyRate.Text.ToString(), Integer))
        If (txtHours.Text <= max_hour) Then
            lblOvrTime.Hide()
            txtOvrTimePay.Hide()
            lblGross.Show()
            txtComputeGross.Show()
            txtComputeGross.Text = pay
        Else
            lblGross.Hide()
            txtComputeGross.Hide()
            lblOvrTime.Show()
            txtOvrTimePay.Show()
            txtOvrTimePay.Text = pay
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtComputeGross.Clear()
        txtHours.Clear()
        txtHrlyRate.Clear()
        txtOvrTimePay.Clear()

    End Sub

    Private Sub txtOvrTimePay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOvrTimePay.TextChanged

    End Sub

    Private Sub txtComputeGross_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComputeGross.TextChanged

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
