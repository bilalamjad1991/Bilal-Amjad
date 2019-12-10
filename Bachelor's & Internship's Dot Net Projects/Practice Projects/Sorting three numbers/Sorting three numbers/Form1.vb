Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "sort 3 numbers"
    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        Dim objclass As New number
        
        Dim input1, input2, input3 As Double
        input1 = CType(fstNum.Text.ToString, Double)
        input2 = CType(secNum.Text.ToString, Double)
        input3 = CType(thdNum.Text.ToString, Double)

        objclass.order(input1, input2)
        objclass.order(input1, input3)
        objclass.order(input2, input3)
        odrNum.Text = input1 & ", " & input2 & " ," & input3

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        fstNum.Clear()
        secNum.Clear()
        thdNum.Clear()
        odrNum.Clear()
    End Sub
End Class
