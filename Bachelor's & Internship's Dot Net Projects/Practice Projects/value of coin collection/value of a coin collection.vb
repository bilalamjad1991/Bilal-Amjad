Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResult.Click
        Dim input1 As Double
        Dim input2 As Double
        Dim objclass As New coincollect
        input1 = CType(txtNickles.Text.ToString, Double)
        input2 = CType(txtPennies.Text.ToString, Double)
        objclass.setter(input1, input2)
        txtDollars.Text = objclass.coinvalue()
        txtCents.Text = objclass.coinvalue2()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtCents.Clear()
        txtDollars.Clear()
        txtNickles.Clear()
        txtPennies.Clear()
    End Sub
End Class
