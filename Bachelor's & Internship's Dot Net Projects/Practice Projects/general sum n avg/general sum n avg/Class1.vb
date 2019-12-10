Public Class sum
    Private plus As Double
    Private average As Double
    Public Function add(ByVal input1 As Double, ByVal input2 As Double, ByVal input3 As Double, ByVal input4 As Double) As Double
        plus = (input1 + input2 + input3 + input4)
        Return plus
    End Function


    Public Function avg(ByVal input1 As Double, ByVal input2 As Double, ByVal input3 As Double, ByVal input4 As Double) As Double

        plus = (input1 + input2 + input3 + input4)
        average = plus / 4
        Return average
    End Function
End Class
