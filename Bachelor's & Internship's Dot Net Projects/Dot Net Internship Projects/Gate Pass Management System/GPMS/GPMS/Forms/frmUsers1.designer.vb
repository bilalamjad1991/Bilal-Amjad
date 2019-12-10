<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsers1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsers1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbUserName = New System.Windows.Forms.ComboBox()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.txtConfrimPassword = New System.Windows.Forms.TextBox()
        Me.txtNewPassword = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.lblConfirmPassword = New System.Windows.Forms.Label()
        Me.fraResetPassword = New System.Windows.Forms.GroupBox()
        Me.cmdCancelResetPassword = New System.Windows.Forms.Button()
        Me.cmdSaveResetPassword = New System.Windows.Forms.Button()
        Me.lblNewPassword = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.fraRights = New System.Windows.Forms.GroupBox()
        Me.chkUserActive = New System.Windows.Forms.CheckBox()
        Me.cmdExpandAll = New System.Windows.Forms.Button()
        Me.cmdCheckAll = New System.Windows.Forms.Button()
        Me.cmdClearAll = New System.Windows.Forms.Button()
        Me.TV = New System.Windows.Forms.TreeView()
        Me.fraAddUser = New System.Windows.Forms.GroupBox()
        Me.cmbDesig = New System.Windows.Forms.ComboBox()
        Me.cmdCancelNewUser = New System.Windows.Forms.Button()
        Me.cmdSaveNewUser = New System.Windows.Forms.Button()
        Me.txtNewUserPasswordConfirm = New System.Windows.Forms.TextBox()
        Me.txtNewUserPassword = New System.Windows.Forms.TextBox()
        Me.txtNewUserName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdResetPassword = New System.Windows.Forms.Button()
        Me.cmdAddUser = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.fraResetPassword.SuspendLayout()
        Me.fraRights.SuspendLayout()
        Me.fraAddUser.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "User Name"
        '
        'cmbUserName
        '
        Me.cmbUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUserName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUserName.FormattingEnabled = True
        Me.cmbUserName.Location = New System.Drawing.Point(81, 33)
        Me.cmbUserName.Name = "cmbUserName"
        Me.cmbUserName.Size = New System.Drawing.Size(247, 25)
        Me.cmbUserName.TabIndex = 0
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Location = New System.Drawing.Point(148, 151)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(56, 17)
        Me.chkActive.TabIndex = 7
        Me.chkActive.Text = "Active"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'txtConfrimPassword
        '
        Me.txtConfrimPassword.Location = New System.Drawing.Point(148, 99)
        Me.txtConfrimPassword.Name = "txtConfrimPassword"
        Me.txtConfrimPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfrimPassword.Size = New System.Drawing.Size(167, 23)
        Me.txtConfrimPassword.TabIndex = 5
        '
        'txtNewPassword
        '
        Me.txtNewPassword.Location = New System.Drawing.Point(148, 69)
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPassword.Size = New System.Drawing.Size(167, 23)
        Me.txtNewPassword.TabIndex = 3
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(148, 39)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(167, 23)
        Me.txtUserName.TabIndex = 1
        '
        'lblConfirmPassword
        '
        Me.lblConfirmPassword.AutoSize = True
        Me.lblConfirmPassword.Location = New System.Drawing.Point(35, 102)
        Me.lblConfirmPassword.Name = "lblConfirmPassword"
        Me.lblConfirmPassword.Size = New System.Drawing.Size(104, 15)
        Me.lblConfirmPassword.TabIndex = 4
        Me.lblConfirmPassword.Text = "Confirm Password"
        '
        'fraResetPassword
        '
        Me.fraResetPassword.Controls.Add(Me.cmdCancelResetPassword)
        Me.fraResetPassword.Controls.Add(Me.cmdSaveResetPassword)
        Me.fraResetPassword.Controls.Add(Me.txtConfrimPassword)
        Me.fraResetPassword.Controls.Add(Me.txtNewPassword)
        Me.fraResetPassword.Controls.Add(Me.txtUserName)
        Me.fraResetPassword.Controls.Add(Me.lblConfirmPassword)
        Me.fraResetPassword.Controls.Add(Me.lblNewPassword)
        Me.fraResetPassword.Controls.Add(Me.lblUserName)
        Me.fraResetPassword.Location = New System.Drawing.Point(601, 216)
        Me.fraResetPassword.Name = "fraResetPassword"
        Me.fraResetPassword.Size = New System.Drawing.Size(339, 198)
        Me.fraResetPassword.TabIndex = 6
        Me.fraResetPassword.TabStop = False
        Me.fraResetPassword.Text = "Reset Password"
        Me.fraResetPassword.Visible = False
        '
        'cmdCancelResetPassword
        '
        Me.cmdCancelResetPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelResetPassword.Image = CType(resources.GetObject("cmdCancelResetPassword.Image"), System.Drawing.Image)
        Me.cmdCancelResetPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelResetPassword.Location = New System.Drawing.Point(85, 146)
        Me.cmdCancelResetPassword.Name = "cmdCancelResetPassword"
        Me.cmdCancelResetPassword.Size = New System.Drawing.Size(89, 35)
        Me.cmdCancelResetPassword.TabIndex = 6
        Me.cmdCancelResetPassword.Text = "     Cancel"
        Me.cmdCancelResetPassword.UseVisualStyleBackColor = True
        '
        'cmdSaveResetPassword
        '
        Me.cmdSaveResetPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSaveResetPassword.Image = CType(resources.GetObject("cmdSaveResetPassword.Image"), System.Drawing.Image)
        Me.cmdSaveResetPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSaveResetPassword.Location = New System.Drawing.Point(177, 146)
        Me.cmdSaveResetPassword.Name = "cmdSaveResetPassword"
        Me.cmdSaveResetPassword.Size = New System.Drawing.Size(89, 35)
        Me.cmdSaveResetPassword.TabIndex = 7
        Me.cmdSaveResetPassword.Text = "   Save"
        Me.cmdSaveResetPassword.UseVisualStyleBackColor = True
        '
        'lblNewPassword
        '
        Me.lblNewPassword.AutoSize = True
        Me.lblNewPassword.Location = New System.Drawing.Point(50, 72)
        Me.lblNewPassword.Name = "lblNewPassword"
        Me.lblNewPassword.Size = New System.Drawing.Size(84, 15)
        Me.lblNewPassword.TabIndex = 2
        Me.lblNewPassword.Text = "New Password"
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Location = New System.Drawing.Point(69, 42)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(65, 15)
        Me.lblUserName.TabIndex = 0
        Me.lblUserName.Text = "User Name"
        '
        'fraRights
        '
        Me.fraRights.Controls.Add(Me.chkUserActive)
        Me.fraRights.Controls.Add(Me.Label1)
        Me.fraRights.Controls.Add(Me.cmdExpandAll)
        Me.fraRights.Controls.Add(Me.cmbUserName)
        Me.fraRights.Controls.Add(Me.cmdCheckAll)
        Me.fraRights.Controls.Add(Me.cmdClearAll)
        Me.fraRights.Controls.Add(Me.TV)
        Me.fraRights.Location = New System.Drawing.Point(17, 12)
        Me.fraRights.Name = "fraRights"
        Me.fraRights.Size = New System.Drawing.Size(578, 493)
        Me.fraRights.TabIndex = 0
        Me.fraRights.TabStop = False
        Me.fraRights.Text = "Access && Rights"
        '
        'chkUserActive
        '
        Me.chkUserActive.AutoSize = True
        Me.chkUserActive.Location = New System.Drawing.Point(334, 36)
        Me.chkUserActive.Name = "chkUserActive"
        Me.chkUserActive.Size = New System.Drawing.Size(56, 17)
        Me.chkUserActive.TabIndex = 6
        Me.chkUserActive.Text = "Active"
        Me.chkUserActive.UseVisualStyleBackColor = True
        '
        'cmdExpandAll
        '
        Me.cmdExpandAll.Location = New System.Drawing.Point(462, 391)
        Me.cmdExpandAll.Name = "cmdExpandAll"
        Me.cmdExpandAll.Size = New System.Drawing.Size(105, 27)
        Me.cmdExpandAll.TabIndex = 3
        Me.cmdExpandAll.Text = "&Expand All"
        Me.cmdExpandAll.UseVisualStyleBackColor = True
        '
        'cmdCheckAll
        '
        Me.cmdCheckAll.Enabled = False
        Me.cmdCheckAll.Location = New System.Drawing.Point(462, 424)
        Me.cmdCheckAll.Name = "cmdCheckAll"
        Me.cmdCheckAll.Size = New System.Drawing.Size(105, 27)
        Me.cmdCheckAll.TabIndex = 4
        Me.cmdCheckAll.Text = "Check &All"
        Me.cmdCheckAll.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Location = New System.Drawing.Point(462, 458)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(105, 27)
        Me.cmdClearAll.TabIndex = 5
        Me.cmdClearAll.Text = "Cle&ar All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'TV
        '
        Me.TV.CheckBoxes = True
        Me.TV.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TV.Location = New System.Drawing.Point(13, 64)
        Me.TV.Name = "TV"
        Me.TV.Size = New System.Drawing.Size(443, 421)
        Me.TV.TabIndex = 2
        '
        'fraAddUser
        '
        Me.fraAddUser.Controls.Add(Me.cmbDesig)
        Me.fraAddUser.Controls.Add(Me.cmdCancelNewUser)
        Me.fraAddUser.Controls.Add(Me.cmdSaveNewUser)
        Me.fraAddUser.Controls.Add(Me.txtNewUserPasswordConfirm)
        Me.fraAddUser.Controls.Add(Me.txtNewUserPassword)
        Me.fraAddUser.Controls.Add(Me.txtNewUserName)
        Me.fraAddUser.Controls.Add(Me.Label2)
        Me.fraAddUser.Controls.Add(Me.Label3)
        Me.fraAddUser.Controls.Add(Me.chkActive)
        Me.fraAddUser.Controls.Add(Me.Label4)
        Me.fraAddUser.Location = New System.Drawing.Point(601, 12)
        Me.fraAddUser.Name = "fraAddUser"
        Me.fraAddUser.Size = New System.Drawing.Size(339, 224)
        Me.fraAddUser.TabIndex = 3
        Me.fraAddUser.TabStop = False
        Me.fraAddUser.Text = "Add New User"
        Me.fraAddUser.Visible = False
        '
        'cmbDesig
        '
        Me.cmbDesig.FormattingEnabled = True
        Me.cmbDesig.Items.AddRange(New Object() {"Store Officer", "GM"})
        Me.cmbDesig.Location = New System.Drawing.Point(148, 118)
        Me.cmbDesig.Name = "cmbDesig"
        Me.cmbDesig.Size = New System.Drawing.Size(167, 23)
        Me.cmbDesig.TabIndex = 6
        '
        'cmdCancelNewUser
        '
        Me.cmdCancelNewUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelNewUser.Image = CType(resources.GetObject("cmdCancelNewUser.Image"), System.Drawing.Image)
        Me.cmdCancelNewUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelNewUser.Location = New System.Drawing.Point(85, 176)
        Me.cmdCancelNewUser.Name = "cmdCancelNewUser"
        Me.cmdCancelNewUser.Size = New System.Drawing.Size(89, 35)
        Me.cmdCancelNewUser.TabIndex = 8
        Me.cmdCancelNewUser.Text = "     Cancel"
        Me.cmdCancelNewUser.UseVisualStyleBackColor = True
        '
        'cmdSaveNewUser
        '
        Me.cmdSaveNewUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSaveNewUser.Image = CType(resources.GetObject("cmdSaveNewUser.Image"), System.Drawing.Image)
        Me.cmdSaveNewUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSaveNewUser.Location = New System.Drawing.Point(177, 176)
        Me.cmdSaveNewUser.Name = "cmdSaveNewUser"
        Me.cmdSaveNewUser.Size = New System.Drawing.Size(89, 35)
        Me.cmdSaveNewUser.TabIndex = 9
        Me.cmdSaveNewUser.Text = "   Save"
        Me.cmdSaveNewUser.UseVisualStyleBackColor = True
        '
        'txtNewUserPasswordConfirm
        '
        Me.txtNewUserPasswordConfirm.Location = New System.Drawing.Point(148, 88)
        Me.txtNewUserPasswordConfirm.MaxLength = 20
        Me.txtNewUserPasswordConfirm.Name = "txtNewUserPasswordConfirm"
        Me.txtNewUserPasswordConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewUserPasswordConfirm.Size = New System.Drawing.Size(167, 23)
        Me.txtNewUserPasswordConfirm.TabIndex = 5
        '
        'txtNewUserPassword
        '
        Me.txtNewUserPassword.Location = New System.Drawing.Point(148, 58)
        Me.txtNewUserPassword.MaxLength = 20
        Me.txtNewUserPassword.Name = "txtNewUserPassword"
        Me.txtNewUserPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewUserPassword.Size = New System.Drawing.Size(167, 23)
        Me.txtNewUserPassword.TabIndex = 3
        '
        'txtNewUserName
        '
        Me.txtNewUserName.Location = New System.Drawing.Point(148, 28)
        Me.txtNewUserName.MaxLength = 20
        Me.txtNewUserName.Name = "txtNewUserName"
        Me.txtNewUserName.Size = New System.Drawing.Size(167, 23)
        Me.txtNewUserName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Confirm Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(82, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = " Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(77, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "User Name"
        '
        'cmdResetPassword
        '
        Me.cmdResetPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdResetPassword.Image = CType(resources.GetObject("cmdResetPassword.Image"), System.Drawing.Image)
        Me.cmdResetPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdResetPassword.Location = New System.Drawing.Point(603, 317)
        Me.cmdResetPassword.Name = "cmdResetPassword"
        Me.cmdResetPassword.Size = New System.Drawing.Size(109, 42)
        Me.cmdResetPassword.TabIndex = 5
        Me.cmdResetPassword.Text = "&Reset" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Password"
        Me.cmdResetPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdResetPassword.UseVisualStyleBackColor = True
        '
        'cmdAddUser
        '
        Me.cmdAddUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAddUser.Image = CType(resources.GetObject("cmdAddUser.Image"), System.Drawing.Image)
        Me.cmdAddUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAddUser.Location = New System.Drawing.Point(603, 269)
        Me.cmdAddUser.Name = "cmdAddUser"
        Me.cmdAddUser.Size = New System.Drawing.Size(109, 42)
        Me.cmdAddUser.TabIndex = 4
        Me.cmdAddUser.Text = "      Add User"
        Me.cmdAddUser.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.Location = New System.Drawing.Point(603, 413)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(109, 42)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "     &Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(603, 365)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(109, 42)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "      Ca&ncel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Image = CType(resources.GetObject("cmdClose.Image"), System.Drawing.Image)
        Me.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdClose.Location = New System.Drawing.Point(603, 462)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(109, 42)
        Me.cmdClose.TabIndex = 6
        Me.cmdClose.Text = "     Cl&ose"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'frmUsers1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(724, 516)
        Me.Controls.Add(Me.fraAddUser)
        Me.Controls.Add(Me.fraResetPassword)
        Me.Controls.Add(Me.cmdResetPassword)
        Me.Controls.Add(Me.cmdAddUser)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.fraRights)
        Me.Controls.Add(Me.cmdClose)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmUsers1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Management"
        Me.fraResetPassword.ResumeLayout(False)
        Me.fraResetPassword.PerformLayout()
        Me.fraRights.ResumeLayout(False)
        Me.fraRights.PerformLayout()
        Me.fraAddUser.ResumeLayout(False)
        Me.fraAddUser.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdResetPassword As System.Windows.Forms.Button
    Friend WithEvents cmdAddUser As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbUserName As System.Windows.Forms.ComboBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents txtConfrimPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtNewPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents lblConfirmPassword As System.Windows.Forms.Label
    Friend WithEvents fraResetPassword As System.Windows.Forms.GroupBox
    Friend WithEvents lblNewPassword As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents fraRights As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents TV As System.Windows.Forms.TreeView
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdCheckAll As System.Windows.Forms.Button
    Friend WithEvents cmdExpandAll As System.Windows.Forms.Button
    Friend WithEvents fraAddUser As System.Windows.Forms.GroupBox
    Friend WithEvents txtNewUserPasswordConfirm As System.Windows.Forms.TextBox
    Friend WithEvents txtNewUserPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtNewUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdCancelResetPassword As System.Windows.Forms.Button
    Friend WithEvents cmdSaveResetPassword As System.Windows.Forms.Button
    Friend WithEvents cmdCancelNewUser As System.Windows.Forms.Button
    Friend WithEvents cmdSaveNewUser As System.Windows.Forms.Button
    Friend WithEvents chkUserActive As System.Windows.Forms.CheckBox
    Friend WithEvents cmbDesig As System.Windows.Forms.ComboBox
End Class
