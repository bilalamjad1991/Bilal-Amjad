Public Class clsChkBal
    Private startbal, currentbal As Double
    Private checks, deposit As Integer
    Public Sub setter(ByVal start_bal As Double, ByVal current_bal As Double, ByVal num_check As Integer, ByVal num_deposits As Integer)
        startbal = start_bal
        currentbal = current_bal
        checks = num_check
        deposit = num_deposits
    End Sub
    Public Function getter_start_balance() As Double
        Return startbal
    End Function
    Public Function getter_end_balance() As Double
        If (checks <= startbal And deposit > 0) Then
            currentbal = currentbal - checks
            currentbal = currentbal + deposit
            Return currentbal
        Else
            Return startbal
        End If
    End Function
    Public Function getter_checks() As Integer
        Return checks
    End Function
    Public Function getter_deposit() As Integer
        Return deposit
    End Function
End Class
