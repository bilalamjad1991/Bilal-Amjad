Public Class frmSettings
    Const DefATTN As String = "Mr."
    Const DefTO As String = "jamil_akbar@hotmail.com"
    Const DefCC As String = "abbotpar1@hotmail.com"
    Const DefBCC As String = ""
    Private Sub frmSettings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadSettings()
    End Sub
    Sub LoadSettings()
        LoadIndentSettings()
    End Sub
    Sub LoadIndentSettings()
        txtAttention.Text = GetSetting(Company.AppName, "Indent Email", "ATTN", DefATTN)
        txtTo.Text = GetSetting(Company.AppName, "Indent Email", "TO", DefTO)
        txtCC.Text = GetSetting(Company.AppName, "Indent Email", "CC", DefCC)
        txtBCC.Text = GetSetting(Company.AppName, "Indent Email", "BCC", DefBCC)
    End Sub
    Sub SaveIndentSettings()
        SaveSetting(Company.AppName, "Indent Email", "ATTN", txtAttention.Text)
        SaveSetting(Company.AppName, "Indent Email", "TO", txtTo.Text)
        SaveSetting(Company.AppName, "Indent Email", "CC", txtCC.Text)
        SaveSetting(Company.AppName, "Indent Email", "BCC", txtBCC.Text)
    End Sub

    Private Sub cmdIndentSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdIndentSave.Click
        SaveIndentSettings()
        MsgBox("Indent settings are saved", MsgBoxStyle.Information, CName)
    End Sub

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdIndentDefaults_Click(sender As System.Object, e As System.EventArgs) Handles cmdIndentDefaults.Click
        txtAttention.Text = DefATTN
        txtTo.Text = DefTO
        txtCC.Text = DefCC
        txtBCC.Text = DefBCC
    End Sub
End Class