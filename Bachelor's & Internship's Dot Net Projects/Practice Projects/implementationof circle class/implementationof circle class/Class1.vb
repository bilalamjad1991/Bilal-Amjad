Public Class Circle
    Private radius, area, perimeter As Double
    Private pi As Double = 3.14159
    Public Sub getknownattributes(ByVal input1 As Double)
        radius = input1
    End Sub

    Public Function computearea() As Double
        area = pi * radius * radius
        Return area
    End Function
    Public Function computeperimeter() As Double
        perimeter = 2.0 * pi * radius
        Return perimeter
    End Function

End Class
