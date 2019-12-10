Public Class clsCompDiv
    Private dividends As Double
    Private Const basic_rate As Double = 0.045
    Private Const bonus_rate As Double = 0.005
    Private claim As Integer
    Private premium As Double
    Public Sub setter(ByVal input As Double, ByVal input1 As Integer)
        premium = input
        claim = input1
    End Sub
    Public Function Compute_dividend() As Double
        dividends = premium * basic_rate
        If (claim = 0) Then
            dividends = dividends + premium * bonus_rate
        End If
        Return dividends
    End Function
End Class
