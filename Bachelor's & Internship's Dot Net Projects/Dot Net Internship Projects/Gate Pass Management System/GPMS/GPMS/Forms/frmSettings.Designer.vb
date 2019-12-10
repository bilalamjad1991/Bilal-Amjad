<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbIndent = New System.Windows.Forms.TabPage()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdIndentDefaults = New System.Windows.Forms.Button()
        Me.cmdIndentSave = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtAttention = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCC = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtBCC = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.tbIndent.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbIndent)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(506, 377)
        Me.TabControl1.TabIndex = 0
        '
        'tbIndent
        '
        Me.tbIndent.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tbIndent.Controls.Add(Me.GroupBox1)
        Me.tbIndent.Controls.Add(Me.cmdIndentSave)
        Me.tbIndent.Controls.Add(Me.cmdIndentDefaults)
        Me.tbIndent.Location = New System.Drawing.Point(4, 24)
        Me.tbIndent.Name = "tbIndent"
        Me.tbIndent.Padding = New System.Windows.Forms.Padding(3)
        Me.tbIndent.Size = New System.Drawing.Size(498, 349)
        Me.tbIndent.TabIndex = 0
        Me.tbIndent.Text = "Indent"
        '
        'cmdClose
        '
        Me.cmdClose.Image = CType(resources.GetObject("cmdClose.Image"), System.Drawing.Image)
        Me.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdClose.Location = New System.Drawing.Point(418, 395)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(100, 37)
        Me.cmdClose.TabIndex = 1
        Me.cmdClose.Text = "       Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdIndentDefaults
        '
        Me.cmdIndentDefaults.Image = CType(resources.GetObject("cmdIndentDefaults.Image"), System.Drawing.Image)
        Me.cmdIndentDefaults.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdIndentDefaults.Location = New System.Drawing.Point(289, 194)
        Me.cmdIndentDefaults.Name = "cmdIndentDefaults"
        Me.cmdIndentDefaults.Size = New System.Drawing.Size(100, 37)
        Me.cmdIndentDefaults.TabIndex = 2
        Me.cmdIndentDefaults.Text = "       Defaults"
        Me.cmdIndentDefaults.UseVisualStyleBackColor = True
        '
        'cmdIndentSave
        '
        Me.cmdIndentSave.Image = CType(resources.GetObject("cmdIndentSave.Image"), System.Drawing.Image)
        Me.cmdIndentSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdIndentSave.Location = New System.Drawing.Point(395, 194)
        Me.cmdIndentSave.Name = "cmdIndentSave"
        Me.cmdIndentSave.Size = New System.Drawing.Size(100, 37)
        Me.cmdIndentSave.TabIndex = 3
        Me.cmdIndentSave.Text = "       Save"
        Me.cmdIndentSave.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtBCC)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtCC)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtTo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtAttention)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(491, 181)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Email Settings"
        '
        'txtAttention
        '
        Me.txtAttention.Location = New System.Drawing.Point(100, 33)
        Me.txtAttention.Name = "txtAttention"
        Me.txtAttention.Size = New System.Drawing.Size(233, 23)
        Me.txtAttention.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(11, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Attention"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(11, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "To"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTo
        '
        Me.txtTo.Location = New System.Drawing.Point(100, 62)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(385, 23)
        Me.txtTo.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(11, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "CC"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCC
        '
        Me.txtCC.Location = New System.Drawing.Point(100, 91)
        Me.txtCC.Name = "txtCC"
        Me.txtCC.Size = New System.Drawing.Size(385, 23)
        Me.txtCC.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(11, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 23)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "BCC"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBCC
        '
        Me.txtBCC.Location = New System.Drawing.Point(100, 120)
        Me.txtBCC.Name = "txtBCC"
        Me.txtBCC.Size = New System.Drawing.Size(385, 23)
        Me.txtBCC.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(100, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(306, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Note: separate multiple email addresses with semicolon ;"
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(530, 437)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.TabControl1.ResumeLayout(False)
        Me.tbIndent.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tbIndent As System.Windows.Forms.TabPage
    Friend WithEvents cmdIndentDefaults As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdIndentSave As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtBCC As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCC As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAttention As System.Windows.Forms.TextBox
End Class
