Public Class frmChangePassword
    Dim D As New DAL.DAL
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub frmChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUserName.Text = CurrentUser.UserName

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If Trim(txtOldPassword.Text) = "" Then
            MsgBox("Please enter old password", MsgBoxStyle.Critical, CName)
            txtOldPassword.Text = Trim(txtOldPassword.Text)
            txtOldPassword.Focus()
            Exit Sub
        End If
        If Trim(txtNewPassword.Text) = "" Then
            MsgBox("Please enter the new password", MsgBoxStyle.Critical, CName)
            txtNewPassword.Text = Trim(txtNewPassword.Text)
            txtNewPassword.Focus()
            Exit Sub
        End If
        If Trim(txtConfirmPassword.Text) = "" Then
            MsgBox("Please enter confirmation password", MsgBoxStyle.Critical, CName)
            txtConfirmPassword.Text = Trim(txtConfirmPassword.Text)
            txtConfirmPassword.Focus()
            Exit Sub
        End If
        If txtNewPassword.Text <> txtConfirmPassword.Text Then
            MsgBox("New password and confirm password does not match", MsgBoxStyle.Critical, CName)
            txtConfirmPassword.Focus()
            txtConfirmPassword.SelectAll()
            Exit Sub

        End If
        If Not (txtOldPassword.Text = Encrypt.EncryptStr(D.GetScaler("Select Password from tblUsers Where UserName = '" & txtUserName.Text & "'"))) Then
            MsgBox("Invalid password of '" & txtUserName.Text & "'", MsgBoxStyle.Critical)
            txtOldPassword.Focus()
            txtOldPassword.SelectAll()
            Exit Sub
        End If

        'MsgBox("All OK")
        D.ExecuteNonQuery("Update tblUsers Set Password = '" & Encrypt.EncryptStr(txtNewPassword.Text) & "' Where UserName = '" & txtUserName.Text & "'")
        MsgBox("Password changed successfully", MsgBoxStyle.Information, CName)
        txtNewPassword.Text = ""
        txtOldPassword.Text = ""
        txtConfirmPassword.Text = ""
        Me.Close()

    End Sub
End Class