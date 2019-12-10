Public Class gorss_pay
    Public Function compute_gross(ByVal hours, ByVal rate)
        Dim max_hours As Integer
        max_hours = 40.0
        Dim overtime_rate As Integer
        overtime_rate = 2.0
        If (hours <= max_hours) Then
            Return hours * rate
        Else
            Dim gross As Integer
            gross = max_hours * rate
            Return gross + (hours - max_hours) * overtime_rate * rate
        End If
    End Function

End Class
