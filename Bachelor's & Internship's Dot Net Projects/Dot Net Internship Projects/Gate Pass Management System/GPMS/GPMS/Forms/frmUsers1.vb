Public Class frmUsers1
    Dim D As New DAL.DAL
    Dim UserComboIsBusy As Boolean

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub FillRights()
        Dim DT As New DataTable
        DT = D.GetDataTable("Select * from tblrights where rightParentID=0")
        Dim RootNode As New TreeNode
        RootNode.Text = Company.AppName
        RootNode.Tag = "0"
        TV.Nodes.Add(RootNode)
        For I As Long = 0 To DT.Rows.Count - 1
            Dim ParentNode As New TreeNode
            ParentNode.Text = DT.Rows(I)("rightCaption")
            ParentNode.Tag = DT.Rows(I)("rightID")
            TV.Nodes(0).Nodes.Add(ParentNode)
            FillChild(ParentNode)
        Next
        RootNode.Expand()
        RootNode.EnsureVisible()
    End Sub

    Sub FillChild(ByVal pNode As TreeNode)
        Dim DT As DataTable
        DT = D.GetDataTable("Select * from tblRights where rightParent = '" & pNode.Text & "'")
        If DT.Rows.Count > 0 Then
            For I As Long = 0 To DT.Rows.Count - 1
                Dim Child As New TreeNode
                Child.Text = DT.Rows(I)("rightCaption")
                Child.Tag = DT.Rows(I)("rightID")
                pNode.Nodes.Add(Child)
                Child.Collapse()
                FillChild(Child)
            Next
        Else
            Exit Sub
        End If
    End Sub

    Private Sub TV_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TV.AfterCheck
        If cmbUserName.SelectedIndex = -1 Then Exit Sub
        CheckChildern(e.Node, e.Node.Checked)
        CheckParent(e.Node, e.Node.Checked)
    End Sub

    Sub CheckChildern(ByVal PNode As TreeNode, ByVal OK As Boolean)
        For Each N As TreeNode In PNode.Nodes
            If OK = False Then
                N.Checked = False
            End If

            CheckChildern(N, OK)
        Next
    End Sub

    Sub CheckParent(ByVal CNode As TreeNode, ByVal OK As Boolean)
        If CNode.Parent Is Nothing Then
            Exit Sub
        Else
            If OK = True And CNode.Parent.Checked = False Then
                CNode.Parent.Checked = True
                CheckParent(CNode, OK)
            End If
        End If

    End Sub

    Private Function GetCheck(ByVal node As TreeNodeCollection) As List(Of TreeNode)
        Dim lN As New List(Of TreeNode)
        For Each n As TreeNode In node
            If n.Checked Then lN.Add(n)
            lN.AddRange(GetCheck(n.Nodes))
        Next

        Return lN
    End Function

    Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddUser.Click
        txtNewUserName.Text = ""
        txtNewUserPassword.Text = ""
        txtNewUserPasswordConfirm.Text = ""
        chkActive.Checked = True

        fraAddUser.Left = (Me.Width - fraAddUser.Width) / 2
        fraAddUser.Top = (Me.Height - fraAddUser.Height) / 2
        fraAddUser.Visible = True
        ShowBackControls(False)
        txtNewUserName.Focus()
    End Sub

    Sub ShowBackControls(OK As Boolean)
        fraRights.Enabled = OK
        cmdAddUser.Enabled = OK
        cmdResetPassword.Enabled = OK
        cmdCancel.Enabled = OK
        cmdSave.Enabled = OK
        cmdClose.Enabled = OK
    End Sub

    Private Sub cmdResetPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdResetPassword.Click
        txtUserName.Text = ""
        txtNewPassword.Text = ""
        txtConfrimPassword.Text = ""

        fraResetPassword.Left = (Me.Width - fraResetPassword.Width) / 2
        fraResetPassword.Top = (Me.Height - fraResetPassword.Height) / 2
        fraResetPassword.Visible = True
        ShowBackControls(False)
        txtUserName.Focus()

    End Sub

    Private Sub frmUsers1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillUsers()
        FillRights()
    End Sub

    Sub FillUsers()
        UserComboIsBusy = True
        Dim DT As New DataTable
        DT = D.GetDataTable("Select * from tblUsers")
        cmbUserName.DataSource = DT
        cmbUserName.DisplayMember = "UserName"
        cmbUserName.ValueMember = "UserID"
        cmbUserName.SelectedIndex = -1
        UserComboIsBusy = False
    End Sub

    Private Sub cmbUserName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUserName.SelectedIndexChanged
        If Not UserComboIsBusy Then
            FillUserRights(cmbUserName.SelectedValue)

        End If
        If cmbUserName.SelectedIndex = -1 Then
            cmdCheckAll.Enabled = False
        Else
            cmdCheckAll.Enabled = True
        End If
    End Sub

    Sub FillUserRights(ByVal UserID As Long)
        Dim DT As New DataTable
        DT = D.GetDataTable("Select rightID from tblUserRights where userID=" & UserID)
        ClearTreeView()
        If DT.Rows.Count > 0 Then
            For N As Integer = 0 To DT.Rows.Count - 1
                SetCheckedNodes(TV.Nodes(0), DT.Rows(N)("rightID"))
            Next
        End If
        chkUserActive.Checked = CBool(D.GetScaler("Select Active from tblUsers where UserID = " & UserID))

    End Sub

    Sub SetCheckedNodes(ByVal N As TreeNode, ByVal RID As Long)
        For Each NN As TreeNode In N.Nodes
            If NN.Tag = RID Then
                NN.Checked = True
            End If
            SetCheckedNodes(NN, RID)
        Next
    End Sub

    Sub ClearTreeView()
        ClearNodes(TV.Nodes(0))
    End Sub

    Sub ClearNodes(ByVal N As TreeNode)
        For Each NN As TreeNode In N.Nodes
            NN.Checked = False
            ClearNodes(NN)
        Next
    End Sub

    Private Sub cmdSaveRights_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cmbUserName.SelectedIndex = -1 Then
            MsgBox("Please select a user from the list", MsgBoxStyle.Information, CName)
            cmbUserName.Focus()
            Exit Sub
        End If
        Try
            D.ExecuteNonQuery("Delete from tblUserRights where userID = " & cmbUserName.SelectedValue)
            D.ExecuteNonQuery("Update tblusers set Active = " & IIf(chkUserActive.Checked, 1, 0) & " where userid = " & cmbUserName.SelectedValue)
            SaveCheckedNode(TV.Nodes(0))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, CName)
        End Try
        MsgBox("Data is saved, Changes will take effect on next login", MsgBoxStyle.Information, CName)
        Me.Close()
    End Sub

    Sub SaveCheckedNode(ByVal N As TreeNode)
        For Each NN As TreeNode In N.Nodes
            If NN.Checked Then
                AddRight(NN.Tag)

            End If
            SaveCheckedNode(NN)
        Next
    End Sub

    Sub AddRight(ByVal RightID As Long)
        Dim S As String = "Insert into tblUserRights (UserID,RightID) Values (" & cmbUserName.SelectedValue & ", " & RightID & ")"
        D.ExecuteNonQuery(S)
    End Sub

    Private Sub cmdCancelRights_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        If Not UserComboIsBusy Then
            FillUserRights(cmbUserName.SelectedValue)
        End If
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        ClearTreeView()
    End Sub

    Private Sub cmdCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckAll.Click
        CheckAll(TV.Nodes(0))
    End Sub

    Sub CheckAll(ByVal N As TreeNode)
        For Each NN As TreeNode In N.Nodes
            NN.Checked = True
            CheckAll(NN)
        Next
    End Sub

    Private Sub cmdExpandAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExpandAll.Click
        TV.Nodes(0).ExpandAll()
        TV.Nodes(0).EnsureVisible()
    End Sub

    Private Sub TV_BeforeCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TV.BeforeCheck
        If cmbUserName.SelectedIndex = -1 Then
            MsgBox("Please select a user", MsgBoxStyle.Information, CName)
            e.Cancel = True
            cmbUserName.Focus()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox(CurrentUser.HasRight("Sale"))
    End Sub

    Private Sub cmdCancelNewUser_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancelNewUser.Click
        fraAddUser.Visible = False
        ShowBackControls(True)
    End Sub

    Private Sub cmdSaveNewUser_Click(sender As System.Object, e As System.EventArgs) Handles cmdSaveNewUser.Click
        If Trim(txtNewUserName.Text) = "" Then
            txtNewUserName.Text = Trim(txtNewUserName.Text)
            MsgBox("User Name is empty, Please enter valid user name", MsgBoxStyle.Critical, CName)
            txtNewUserName.Focus()
            Exit Sub
        End If
        If D.IsRecordExists("tblUsers", "UserName", txtNewUserName.Text) Then
            MsgBox("This user name already exist in record", MsgBoxStyle.Critical, CName)
            txtNewUserName.Focus()
            txtNewUserName.SelectAll()
            Exit Sub
        End If
        If Trim(txtNewUserPassword.Text) = "" Then
            txtNewUserPassword.Text = Trim(txtNewUserPassword.Text)
            MsgBox("Invalid password", MsgBoxStyle.Critical, CName)
            txtNewUserPassword.Focus()
            Exit Sub
        End If
        If Trim(txtNewUserPasswordConfirm.Text) = "" Then
            txtNewUserPasswordConfirm.Text = Trim(txtNewUserPasswordConfirm.Text)
            MsgBox("Invalid confirm password", MsgBoxStyle.Critical, CName)
            txtNewUserPasswordConfirm.Focus()
            Exit Sub
        End If

        If txtNewUserPassword.Text <> txtNewUserPasswordConfirm.Text Then
            MsgBox("Password does not match with confirm password", MsgBoxStyle.Critical, CName)
            txtNewUserPasswordConfirm.Focus()
            txtNewUserPasswordConfirm.SelectAll()
            Exit Sub
        End If

        Dim strQry As String
        Dim UID As String = CInt(D.GetScaler("Select Max(UserID) from tblUsers")) + 1

        '' Add Designation
        'strQry = "INSERT INTO tblDesignation " & _
        '         "(Desig_Name) " & _
        '         "VALUES('" & cmbDesig.Text & "')"
        '  D.ExecuteNonQuery(strQry)        ''''''''''''''''''''''''''''''''

        ' Select Designation ID
        Dim DT As New DataTable
        DT = D.GetDataTable("Select * from tblDesignation where Desig_Name = '" & cmbDesig.Text & "'")
        Dim desigID As Integer
        desigID = DT.Rows(0).Item("PK_DesigID")

        ''''''''''''''''''''''''   "Select rightID from tblUserRights where userID=" & UserID
        strQry = "INSERT INTO tblUsers " & _
                 "(UserID, UserName, DateCreated, Active, Password,FK_DesigID) " & _
                 "VALUES(" & UID & ",'" & txtNewUserName.Text & "','" & Now & "','" & If(chkActive.Checked, "TRUE", "FLASE") & "','" & Encrypt.EncryptStr(txtNewUserPassword.Text) & "'," & desigID & ")"
        D.ExecuteNonQuery(strQry)
        MsgBox("New user added successfully", MsgBoxStyle.Information, CName)
        
        fraAddUser.Visible = False
        ShowBackControls(True)
        FillUsers()
    End Sub

    Private Sub cmdCancelResetPassword_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancelResetPassword.Click
        fraResetPassword.Visible = False
        ShowBackControls(True)
    End Sub

    Private Sub cmdSaveResetPassword_Click(sender As System.Object, e As System.EventArgs) Handles cmdSaveResetPassword.Click
        If Trim(txtUserName.Text) = "" Then
            txtNewUserName.Text = Trim(txtNewUserName.Text)
            MsgBox("Invalid user name", MsgBoxStyle.Critical, CName)
            txtUserName.Focus()
            Exit Sub
        End If
        If Not D.IsRecordExists("tblUsers", "UserName", txtUserName.Text) Then
            MsgBox("This user name does not exist in record", MsgBoxStyle.Information, CName)
            txtUserName.Focus()
            txtUserName.SelectAll()
            Exit Sub
        End If
        If Trim(txtNewPassword.Text) = "" Then
            txtNewPassword.Text = Trim(txtNewPassword.Text)
            MsgBox("Invalid password", MsgBoxStyle.Critical, CName)
            txtNewPassword.Focus()
            Exit Sub
        End If
        If Trim(txtConfrimPassword.Text) = "" Then
            txtConfrimPassword.Text = Trim(txtConfrimPassword.Text)
            MsgBox("Invalid confirm password", MsgBoxStyle.Critical, CName)
            txtConfrimPassword.Focus()
            Exit Sub
        End If
        If txtNewPassword.Text <> txtConfrimPassword.Text Then
            MsgBox("Password does not match with confirm password", MsgBoxStyle.Critical, CName)
            txtConfrimPassword.Focus()
            txtConfrimPassword.SelectAll()
            Exit Sub
        End If

        Dim strQry As String
        strQry = "UPDATE tblUsers " & _
                 "Set Password = '" & Encrypt.EncryptStr(txtNewPassword.Text) & "' " &
                 "WHERE UserName = '" & txtUserName.Text & "'"
        D.ExecuteNonQuery(strQry)
        MsgBox("Password changed successfully", MsgBoxStyle.Information, CName)
        fraResetPassword.Visible = False
        ShowBackControls(True)
    End Sub
End Class