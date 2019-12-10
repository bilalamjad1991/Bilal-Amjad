Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSum.Click
        Dim input1, input2, input3, input4, value1 As Double
        Dim objclass As New sum
        input1 = CType(txtBx1.Text.ToString, Double)
        input2 = CType(txtBx2.Text.ToString, Double)
        input3 = CType(txtBx3.Text.ToString, Double)
        input4 = CType(txtBx4.Text.ToString, Double)
        value1 = objclass.add(input1, input2, input3, input4)
        txtBx5.Text = value1



    End Sub

    Private Sub btnAvg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAvg.Click
        Dim value2 As Double
        Dim input1, input2, input3, input4 As Double
        Dim objclass As New sum
        input1 = CType(txtBx1.Text.ToString, Double)
        input2 = CType(txtBx2.Text.ToString, Double)
        input3 = CType(txtBx3.Text.ToString, Double)
        input4 = CType(txtBx4.Text.ToString, Double)
        value2 = objclass.avg(input1, input2, input3, input4)
        txtBx6.Text = value2
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtBx1.Clear()
        txtBx2.Clear()
        txtBx3.Clear()
        txtBx4.Clear()
        txtBx5.Clear()
        txtBx6.Clear()
    End Sub
End Class
