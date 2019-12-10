Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculate.Click
        Dim input1 As Double
        Dim input2 As Double
        input1 = CType(txtHours.Text.ToString, Double)
        input2 = CType(txtRate.Text.ToString, Double)
        Dim objclass As New salary
        objclass.setter(input1, input2)
        txtGross.Text = objclass.computegross
        txtNet.Text = objclass.computenet
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtGross.Clear()
        txtHours.Clear()
        txtNet.Clear()
        txtRate.Clear()
    End Sub
End Class
