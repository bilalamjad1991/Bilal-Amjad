Public Class clsConversion
    Private fabricSize As Double
    Public Function ConvertUnits() As Double
        Dim ans As Double
        ans = fabricSize * 1.196
        Return ans
    End Function
    Public Sub Setter(ByVal input As Double)
        fabricSize = input
    End Sub

End Class
