Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        Dim alphafirst As Char
        Dim objclass As New alphabet
        Dim input1, input2, input3 As Char
        input1 = CType(txtFirst.Text.ToString, Char)
        input2 = CType(txtSec.Text.ToString, Char)
        input3 = CType(txtThird.Text.ToString, Char)
        objclass.setter(input1, input2, input3)
        alphafirst = objclass.getfirst(input1, input2)
        alphafirst = objclass.getfirst(input3, alphafirst)
        txtFourth.Text = alphafirst
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtFirst.Clear()
        txtSec.Clear()
        txtThird.Clear()
        txtFourth.Clear()
    End Sub
End Class
