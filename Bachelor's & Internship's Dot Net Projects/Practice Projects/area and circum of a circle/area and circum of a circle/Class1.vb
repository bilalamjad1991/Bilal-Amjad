Public Class classcircle
    Private radius As Double

    Public Function value1() As Double
        Dim area As Double
        Dim pi As Double = 3.14159
        area = pi * radius * radius


        Return area
    End Function

    Public Function value2() As Double
        Dim circumference As Double
        Dim pi As Double = 3.14159
        circumference = 2 * pi * radius

        Return circumference
    End Function

    Public Sub setter(ByVal input As Double)
        radius = input

    End Sub
End Class
