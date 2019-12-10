<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItemsAdd
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmItemsAdd))
        Me.grpItemDetail = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbVendors = New System.Windows.Forms.ComboBox()
        Me.cmbFillUnits = New System.Windows.Forms.Button()
        Me.cmbUnits = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmdFillCatagories = New System.Windows.Forms.Button()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtShortDescription = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.TT = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.txtItemCode = New System.Windows.Forms.MaskedTextBox()
        Me.grpItemDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpItemDetail
        '
        Me.grpItemDetail.Controls.Add(Me.txtItemCode)
        Me.grpItemDetail.Controls.Add(Me.Label4)
        Me.grpItemDetail.Controls.Add(Me.Button1)
        Me.grpItemDetail.Controls.Add(Me.cmbVendors)
        Me.grpItemDetail.Controls.Add(Me.cmbFillUnits)
        Me.grpItemDetail.Controls.Add(Me.cmbUnits)
        Me.grpItemDetail.Controls.Add(Me.Label18)
        Me.grpItemDetail.Controls.Add(Me.cmdFillCatagories)
        Me.grpItemDetail.Controls.Add(Me.chkActive)
        Me.grpItemDetail.Controls.Add(Me.Label5)
        Me.grpItemDetail.Controls.Add(Me.Label3)
        Me.grpItemDetail.Controls.Add(Me.Label2)
        Me.grpItemDetail.Controls.Add(Me.Label1)
        Me.grpItemDetail.Controls.Add(Me.txtShortDescription)
        Me.grpItemDetail.Controls.Add(Me.txtDescription)
        Me.grpItemDetail.Controls.Add(Me.cmbCategory)
        Me.grpItemDetail.Location = New System.Drawing.Point(10, 2)
        Me.grpItemDetail.Name = "grpItemDetail"
        Me.grpItemDetail.Size = New System.Drawing.Size(559, 205)
        Me.grpItemDetail.TabIndex = 0
        Me.grpItemDetail.TabStop = False
        Me.grpItemDetail.Text = "Item Detail"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 179)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 15)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Preffered Vendor*"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(367, 175)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 24)
        Me.Button1.TabIndex = 15
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbVendors
        '
        Me.cmbVendors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendors.FormattingEnabled = True
        Me.cmbVendors.Location = New System.Drawing.Point(138, 176)
        Me.cmbVendors.Name = "cmbVendors"
        Me.cmbVendors.Size = New System.Drawing.Size(223, 23)
        Me.cmbVendors.TabIndex = 14
        '
        'cmbFillUnits
        '
        Me.cmbFillUnits.Image = CType(resources.GetObject("cmbFillUnits.Image"), System.Drawing.Image)
        Me.cmbFillUnits.Location = New System.Drawing.Point(367, 142)
        Me.cmbFillUnits.Name = "cmbFillUnits"
        Me.cmbFillUnits.Size = New System.Drawing.Size(24, 24)
        Me.cmbFillUnits.TabIndex = 12
        Me.cmbFillUnits.UseVisualStyleBackColor = True
        '
        'cmbUnits
        '
        Me.cmbUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnits.FormattingEnabled = True
        Me.cmbUnits.Location = New System.Drawing.Point(138, 143)
        Me.cmbUnits.Name = "cmbUnits"
        Me.cmbUnits.Size = New System.Drawing.Size(223, 23)
        Me.cmbUnits.TabIndex = 11
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 145)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(124, 15)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Unit of Measurement*"
        '
        'cmdFillCatagories
        '
        Me.cmdFillCatagories.Image = CType(resources.GetObject("cmdFillCatagories.Image"), System.Drawing.Image)
        Me.cmdFillCatagories.Location = New System.Drawing.Point(367, 50)
        Me.cmdFillCatagories.Name = "cmdFillCatagories"
        Me.cmdFillCatagories.Size = New System.Drawing.Size(24, 24)
        Me.cmdFillCatagories.TabIndex = 5
        Me.cmdFillCatagories.UseVisualStyleBackColor = True
        '
        'chkActive
        '
        Me.chkActive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkActive.AutoSize = True
        Me.chkActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkActive.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActive.Location = New System.Drawing.Point(468, 19)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(61, 17)
        Me.chkActive.TabIndex = 2
        Me.chkActive.Text = "Active"
        Me.chkActive.UseVisualStyleBackColor = True
        Me.chkActive.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Short Description*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(60, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Description*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(72, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Category*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(70, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Item Code"
        '
        'txtShortDescription
        '
        Me.txtShortDescription.Location = New System.Drawing.Point(138, 112)
        Me.txtShortDescription.MaxLength = 255
        Me.txtShortDescription.Name = "txtShortDescription"
        Me.txtShortDescription.Size = New System.Drawing.Size(392, 23)
        Me.txtShortDescription.TabIndex = 9
        Me.TT.SetToolTip(Me.txtShortDescription, "Will be printed on Invoice")
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(138, 80)
        Me.txtDescription.MaxLength = 40
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(392, 23)
        Me.txtDescription.TabIndex = 7
        Me.TT.SetToolTip(Me.txtDescription, "Will be printed on barcode label")
        '
        'cmbCategory
        '
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(138, 51)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(223, 23)
        Me.cmbCategory.TabIndex = 4
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(572, 168)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(108, 39)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.Location = New System.Drawing.Point(572, 123)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(108, 39)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "Save && Close"
        Me.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'txtItemCode
        '
        Me.txtItemCode.Location = New System.Drawing.Point(138, 19)
        Me.txtItemCode.Mask = "000-000-00000"
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.PromptChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.txtItemCode.Size = New System.Drawing.Size(111, 23)
        Me.txtItemCode.TabIndex = 1
        '
        'frmItemsAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(692, 219)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.grpItemDetail)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmItemsAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Item"
        Me.grpItemDetail.ResumeLayout(False)
        Me.grpItemDetail.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpItemDetail As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents TT As System.Windows.Forms.ToolTip
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmbVendors As System.Windows.Forms.ComboBox
    Friend WithEvents cmbFillUnits As System.Windows.Forms.Button
    Friend WithEvents cmbUnits As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmdFillCatagories As System.Windows.Forms.Button
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtShortDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents txtItemCode As System.Windows.Forms.MaskedTextBox
End Class
