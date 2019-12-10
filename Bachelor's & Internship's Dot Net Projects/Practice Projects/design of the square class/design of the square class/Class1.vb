Public Class square

    Private length, area, perimeter As Double

    Public Sub getknownattributes(ByVal input1 As Double)
        length = input1

    End Sub

    Public Function computearea() As Double
        area = length * length
        Return area
    End Function
    Public Function computeperimeter() As Double
        perimeter = 4.0 * (length)
        Return perimeter
    End Function

End Class
