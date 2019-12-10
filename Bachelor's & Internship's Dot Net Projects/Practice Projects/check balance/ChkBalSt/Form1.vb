Public Class frmChkBal

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Dim input As Double
        Dim input1, input2 As Integer
        Dim objChk As New clsChkBal
        input = CType(txtStartBal.Text.ToString, Double)
        input1 = CType(txtChecks.Text.ToString, Integer)
        input2 = CType(txtDeposits.Text.ToString, Integer)
        objChk.setter(input, input, input1, input2)
        txtStrBal.Text = objChk.getter_start_balance()

        If (input1 > input) Then
            txtEndBalance.Text = "Check not valid"
        Else
            txtEndBalance.Text = objChk.getter_end_balance()

        End If

        txtCheckEnd.Text = objChk.getter_checks()
        txtDepositsEnd.Text = objChk.getter_deposit()
       
    End Sub
    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        txtCheckEnd.Clear()
        txtChecks.Clear()
        txtDeposits.Clear()
        txtDepositsEnd.Clear()
        txtEndBalance.Clear()
        txtStartBal.Clear()
        txtStrBal.Clear()
    End Sub

    Private Sub frmChkBal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
