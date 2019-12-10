
Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtbxSqrYrd.Clear()
        txtbxSqrMtr.Clear()
    End Sub

    Private Sub btnConvertingUnits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvertingUnits.Click
        Dim input As Double
        Dim objConvert As New clsConversion

        input = CType(txtbxSqrMtr.Text.ToString, Double)
        objConvert.Setter(input)
        txtbxSqrYrd.Text = objConvert.ConvertUnits()
    End Sub

    Private Sub txtbxSqrMtr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbxSqrMtr.TextChanged

    End Sub
End Class
