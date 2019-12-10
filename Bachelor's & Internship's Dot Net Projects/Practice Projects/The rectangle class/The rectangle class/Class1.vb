Public Class Rectangle
    Private base, height, area, perimeter As Double

    Public Sub getknownattributes(ByVal input1 As Double, ByVal input2 As Double)
        base = input1
        height = input2
    End Sub

    Public Function computearea() As Double
        area = base * height
        Return area
    End Function
    Public Function computeperimeter() As Double
        perimeter = 2.0 * (base + height)
        Return perimeter
    End Function

End Class
