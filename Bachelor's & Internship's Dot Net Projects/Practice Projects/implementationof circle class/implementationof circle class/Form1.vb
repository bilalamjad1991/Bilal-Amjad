Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCompute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompute.Click
        Dim objclass As New Circle
        Dim input1 As Double
        input1 = CType(txtRds.Text.ToString, Double)
        objclass.getknownattributes(input1)
        txtArea.Text = objclass.computearea()
        txtPrmtr.Text = objclass.computeperimeter()

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtArea.Clear()
        txtPrmtr.Clear()
        txtRds.Clear()

    End Sub
End Class
