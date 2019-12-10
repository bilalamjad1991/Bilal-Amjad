Public Class Form1

    Private Sub btnresult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnresult.Click
        Dim input As Double

        Dim objclass As New classcircle
        input = CType(txtRadius.Text.ToString, Double)

        objclass.setter(input)
        txtArea.Text = objclass.value1()
        txtCircum.Text = objclass.value2()

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtArea.Clear()
        txtRadius.Clear()
        txtCircum.Clear()
    End Sub
End Class
