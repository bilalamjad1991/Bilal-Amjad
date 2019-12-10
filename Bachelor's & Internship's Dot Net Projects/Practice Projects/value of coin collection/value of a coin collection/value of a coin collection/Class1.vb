Public Class coincollect
    Private nickles As Double
    Private pennies As Double
    Public Function coinvalue() As Double
        Dim totalcents As Double
        Dim dollars As Double

        totalcents = 5 * (nickles + pennies)
        dollars = totalcents / 100

        Return dollars
    End Function

    Public Function coinvalue2() As Double
        Dim totalcents As Double
        Dim change As Double
        totalcents = 5 * (nickles + pennies)
        change = totalcents Mod 100
        Return change
    End Function

    Public Sub setter(ByVal input1 As Double, ByVal input2 As Double)
        nickles = input1
        pennies = input2
    End Sub
End Class
