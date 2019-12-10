Public Class Form1

    Private Sub btnCalDiv_Click(sender As System.Object, e As System.EventArgs) Handles btnCalDiv.Click
        Dim input, input1 As Double
        Dim dividend As Double
        Dim objCompDiv As New clsCompDiv
        input = CType(txtPremium.Text.ToString, Double)
        input1 = CType(txtClaim.Text.ToString, Integer)
        objCompDiv.setter(input, input1)
        dividend = objCompDiv.Compute_dividend()
        txtDiv.Text = CType(dividend.ToString, String)
        Label4.Visible = False
        If (input1 = 0) Then
            Label4.Visible = True
            Label4.Text = "This includes a bonus dividend for zero claims"
        End If
       
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        txtClaim.Clear()
        txtDiv.Clear()
        txtPremium.Clear()
        Label4.Text = ""
    End Sub

    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
