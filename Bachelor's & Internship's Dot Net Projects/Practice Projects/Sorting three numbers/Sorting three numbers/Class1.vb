Public Class number
    
    Public Sub order(ByRef x As Double, ByRef y As Double)
        Dim temp As Double

        If (x > y) Then
            temp = x
            x = y
            y = temp

        End If


    End Sub
End Class
