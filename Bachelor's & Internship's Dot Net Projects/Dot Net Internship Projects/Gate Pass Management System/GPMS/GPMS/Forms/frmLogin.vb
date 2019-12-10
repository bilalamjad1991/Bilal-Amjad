Public Class frmLogin

    Dim D As New DAL.DAL
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If UsernameTextBox.Text.Length = 0 Then
            MsgBox("Please enter a valid user name", MsgBoxStyle.Critical, CName)
            UsernameTextBox.Focus()
            Exit Sub

        End If
        If PasswordTextBox.Text.Length = 0 Then
            MsgBox("Please enter a valid password", MsgBoxStyle.Critical, CName)
            PasswordTextBox.Focus()
            Exit Sub
        End If
        Dim UID As Long
        Dim UserActive As Boolean = False
        Dim PassOK As Boolean
        Dim S As Boolean = False
        Try
            UID = D.GetScaler("Select UserID from tblUsers where UserName ='" & UsernameTextBox.Text & "'")
            If UID = 0 Then
                MsgBox("Invalid user name, Please try again", MsgBoxStyle.Information, CName)
                UsernameTextBox.SelectAll()
                UsernameTextBox.Focus()
                Exit Sub

            End If

            UserActive = D.GetScaler("Select Active from tblUsers where UserID=" & UID)
            If Not UserActive Then
                MsgBox("You are not allowed to login, Please contact administrator for user activation", MsgBoxStyle.Information, CName)
                UsernameTextBox.SelectAll()
                UsernameTextBox.Focus()
                Exit Sub

            End If
            PassOK = D.GetScaler("Select Count(UserID) from tblusers where UserID=" & UID & " and Password ='" & EncryptStr(PasswordTextBox.Text) & "'")
            If Not PassOK Then
                MsgBox("Invalid password", MsgBoxStyle.Critical, CName)
                PasswordTextBox.Focus()
                PasswordTextBox.SelectAll()
                Exit Sub
            End If
            S = True

        Catch Ex As Exception
            MsgBox(Ex.Message, MsgBoxStyle.Critical, "Login Error, Contact Vendor")
            End
        End Try

        If S = True Then
            CurrentUser.GetUserInfo(UID)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If


    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
