Public Class salary
    Private hours As Double
    Private rate As Double
    Private gross As Double
    Public Sub setter(ByVal input1 As Double, ByVal input2 As Double)
        hours = input1
        rate = input2
    End Sub


    Public Function computegross() As Double

        gross = hours * rate
        Return gross
    End Function

    Public Function computenet() As Double

        Dim net As Double
        Dim tax As Double = 25
        Dim taxbracket As Double = 100


        If (gross > taxbracket) Then
            net = gross - tax
            Return net
        Else : Return gross
        End If
    End Function
End Class
