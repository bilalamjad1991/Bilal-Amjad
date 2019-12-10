Imports Outlook = Microsoft.Office.Interop.Outlook
Imports System.IO
Public Class frmSendEmail
    Dim ComboLoading As Boolean
    Private Account As Outlook.Account
    Private olApp As Outlook.Application
    Private olSession As Outlook.NameSpace
    'Dim SigDir As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signatures"
    'Dim SignatureText As String
    Public IndentNo As String

    Private Sub cmbfrom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFrom.SelectedIndexChanged
        Account = olSession.Accounts(cmbFrom.SelectedItem)
    End Sub

    Private Sub cmbSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click
        Dim MyMail As Outlook.MailItem
        Dim MyAttachments As Outlook.Attachments
        MyMail = olApp.CreateItem(Outlook.OlItemType.olMailItem)
        Dim ToList As New List(Of String)
        Dim CCList As New List(Of String)
        Dim BCCList As New List(Of String)

        Dim MyRecipients As Outlook.Recipients = MyMail.Recipients
        PickEmailAddressesFromTextbox(ToList, txtTo)
        PickEmailAddressesFromTextbox(CCList, txtCC)
        PickEmailAddressesFromTextbox(BCCList, txtBCC)
        If ToList.Count > 0 Then
            For Each EA As String In ToList
                Dim R As Outlook.Recipient = MyRecipients.Add(EA)
                R.Type = Outlook.OlMailRecipientType.olTo
                R.Resolve()
            Next
        End If
        If CCList.Count > 0 Then
            For Each EA As String In CCList
                Dim R As Outlook.Recipient = MyRecipients.Add(EA)
                R.Type = Outlook.OlMailRecipientType.olCC
                R.Resolve()
            Next
        End If
        If BCCList.Count > 0 Then
            For Each EA As String In BCCList
                Dim R As Outlook.Recipient = MyRecipients.Add(EA)
                R.Type = Outlook.OlMailRecipientType.olBCC
                R.Resolve()
            Next
        End If

        With MyMail
            .SendUsingAccount = Account
            .Subject = txtSubject.Text
            .HTMLBody = GetHTMLBodyText() '& getSignatureText()

            'ATTACHEMENT
            MyAttachments = .Attachments
            MyAttachments.Add(txtAttachment.Tag, , 1, txtAttachment.Text)
            If optDirectSend.Checked Then
                .Send()
                MsgBox("Email sent", MsgBoxStyle.Information, CName)
                Me.Close()
            Else
                .Display()
                Me.Close()
            End If
        End With
        'MsgBox("Mail sent")
    End Sub
    Function GetHTMLBodyText() As String
        Dim S As String
        Dim ATTN As String = GetSetting(Company.AppName, "Indent Email", "ATTN", "")
        S = "<html>" & _
            "<font face = 'Verdana' size =2 color = 'SteelBlue'>" & _
            "Dear " & ATTN & "," & _
            "<br><br>" & _
            "Please find attached Indent  <b> (#" & IndentNo & ") </b> " & _
            "<br><br>" & _
            "It is requested to please take necessary action." & _
            "<br><br></font>" & _
            "<font Face = 'Verdana' size=1 color='Gray'> Note: Attached reports and this email is system generated E&OE <br><br></font>" & _
            "</html>"
        
        Return S

    End Function
    Function GetPlainBodyText() As String
        Dim S As String
        Dim ATTN As String = GetSetting(Company.AppName, "Indent Email", "ATTN", "")
        S = "Dear " & ATTN & "," & vbCrLf & vbCrLf & _
            "Please find attached Indent (#" & IndentNo & ")" & vbCrLf & _
            "It is requested to please take necessary action." & vbCrLf & vbCrLf & _
            "Note: Attached reports and this email is system generated E&OE" & vbCrLf & vbCrLf & _
            "Kind Regards,"
        
        Return S
    End Function
    Private Sub frmSendEmail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim olAccounts As Outlook.Accounts
        olApp = New Outlook.Application()
        olSession = olApp.Session
        olAccounts = olSession.Accounts
        cmbFrom.Items.Clear()
        For Each olAccount As Outlook.Account In olAccounts
            cmbFrom.Items.Add(olAccount.DisplayName)
        Next
        cmbFrom.SelectedIndex = 0
        Account = olSession.Accounts(cmbFrom.SelectedItem)
        txtBody.Text = GetPlainBodyText()
        txtTo.Text = GetSetting(Company.AppName, "Indent Email", "TO", "")
        txtCC.Text = GetSetting(Company.AppName, "Indent Email", "CC", "")
        txtBCC.Text = GetSetting(Company.AppName, "Indent Email", "BCC", "")




    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
    Sub PickEmailAddressesFromTextbox(ByRef L As List(Of String), ByVal T As TextBox)
        Dim N As Integer
        Dim S As String = T.Text
        Dim AR() As String
        AR = S.Split(";")
        For N = AR.GetLowerBound(0) To AR.GetUpperBound(0)
            If Len(AR(N)) > 0 Then
                L.Add(Trim(AR(N).ToString))
            End If
        Next

    End Sub
    
End Class



