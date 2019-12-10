Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculate.Click
        Dim objclass As New square
        Dim input1 As Double
        input1 = CType(txtLength.Text.ToString, Double)

        objclass.getknownattributes(input1)
        txtArea.Text = objclass.computearea()
        txtPrmtr.Text = objclass.computeperimeter()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtLength.Clear()
        txtArea.Clear()
        txtPrmtr.Clear()
        
    End Sub
End Class
