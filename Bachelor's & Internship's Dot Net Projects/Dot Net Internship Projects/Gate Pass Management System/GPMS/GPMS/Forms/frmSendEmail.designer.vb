<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSendEmail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSendEmail))
        Me.txtTo = New System.Windows.Forms.TextBox()
        Me.txtCC = New System.Windows.Forms.TextBox()
        Me.txtBCC = New System.Windows.Forms.TextBox()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.cmdSend = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAttachment = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbFrom = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtBody = New System.Windows.Forms.RichTextBox()
        Me.cmbSignature = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.optDirectSend = New System.Windows.Forms.RadioButton()
        Me.optShowInOutLook = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'txtTo
        '
        Me.txtTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTo.Location = New System.Drawing.Point(131, 37)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(591, 23)
        Me.txtTo.TabIndex = 3
        '
        'txtCC
        '
        Me.txtCC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCC.Location = New System.Drawing.Point(131, 67)
        Me.txtCC.Name = "txtCC"
        Me.txtCC.Size = New System.Drawing.Size(591, 23)
        Me.txtCC.TabIndex = 5
        '
        'txtBCC
        '
        Me.txtBCC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBCC.Location = New System.Drawing.Point(131, 97)
        Me.txtBCC.Name = "txtBCC"
        Me.txtBCC.Size = New System.Drawing.Size(591, 23)
        Me.txtBCC.TabIndex = 7
        '
        'txtSubject
        '
        Me.txtSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubject.Location = New System.Drawing.Point(131, 127)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(591, 23)
        Me.txtSubject.TabIndex = 9
        '
        'cmdSend
        '
        Me.cmdSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSend.Image = CType(resources.GetObject("cmdSend.Image"), System.Drawing.Image)
        Me.cmdSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSend.Location = New System.Drawing.Point(520, 452)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(99, 40)
        Me.cmdSend.TabIndex = 14
        Me.cmdSend.Text = "Send   "
        Me.cmdSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSend.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(625, 452)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(99, 40)
        Me.cmdCancel.TabIndex = 15
        Me.cmdCancel.Text = "Cancel   "
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(14, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "To"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 23)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "CC"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 23)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "BCC"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 23)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Subject"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(14, 185)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 23)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Message"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAttachment
        '
        Me.txtAttachment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAttachment.Location = New System.Drawing.Point(133, 156)
        Me.txtAttachment.Name = "txtAttachment"
        Me.txtAttachment.ReadOnly = True
        Me.txtAttachment.Size = New System.Drawing.Size(591, 23)
        Me.txtAttachment.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(14, 156)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 23)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Attachment"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbFrom
        '
        Me.cmbFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFrom.FormattingEnabled = True
        Me.cmbFrom.Location = New System.Drawing.Point(131, 8)
        Me.cmbFrom.Name = "cmbFrom"
        Me.cmbFrom.Size = New System.Drawing.Size(233, 23)
        Me.cmbFrom.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(14, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 23)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "From"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBody
        '
        Me.txtBody.Location = New System.Drawing.Point(133, 186)
        Me.txtBody.Name = "txtBody"
        Me.txtBody.Size = New System.Drawing.Size(589, 260)
        Me.txtBody.TabIndex = 13
        Me.txtBody.Text = ""
        '
        'cmbSignature
        '
        Me.cmbSignature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSignature.FormattingEnabled = True
        Me.cmbSignature.Location = New System.Drawing.Point(131, 452)
        Me.cmbSignature.Name = "cmbSignature"
        Me.cmbSignature.Size = New System.Drawing.Size(217, 23)
        Me.cmbSignature.TabIndex = 16
        Me.cmbSignature.Visible = False
        '
        'Label8
        '
        Me.Label8.Enabled = False
        Me.Label8.Location = New System.Drawing.Point(14, 451)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 23)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Signature"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label8.Visible = False
        '
        'optDirectSend
        '
        Me.optDirectSend.AutoSize = True
        Me.optDirectSend.Checked = True
        Me.optDirectSend.Location = New System.Drawing.Point(374, 452)
        Me.optDirectSend.Name = "optDirectSend"
        Me.optDirectSend.Size = New System.Drawing.Size(85, 19)
        Me.optDirectSend.TabIndex = 18
        Me.optDirectSend.TabStop = True
        Me.optDirectSend.Text = "Direct Send"
        Me.optDirectSend.UseVisualStyleBackColor = True
        '
        'optShowInOutLook
        '
        Me.optShowInOutLook.AutoSize = True
        Me.optShowInOutLook.Location = New System.Drawing.Point(374, 475)
        Me.optShowInOutLook.Name = "optShowInOutLook"
        Me.optShowInOutLook.Size = New System.Drawing.Size(113, 19)
        Me.optShowInOutLook.TabIndex = 19
        Me.optShowInOutLook.Text = "Open in Outlook"
        Me.optShowInOutLook.UseVisualStyleBackColor = True
        '
        'frmSendEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(734, 504)
        Me.Controls.Add(Me.optShowInOutLook)
        Me.Controls.Add(Me.optDirectSend)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbSignature)
        Me.Controls.Add(Me.txtBody)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmbFrom)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtAttachment)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSend)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.txtBCC)
        Me.Controls.Add(Me.txtCC)
        Me.Controls.Add(Me.txtTo)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSendEmail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Send Email"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents txtCC As System.Windows.Forms.TextBox
    Friend WithEvents txtBCC As System.Windows.Forms.TextBox
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents cmdSend As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAttachment As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbFrom As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtBody As System.Windows.Forms.RichTextBox
    Friend WithEvents cmbSignature As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents optDirectSend As System.Windows.Forms.RadioButton
    Friend WithEvents optShowInOutLook As System.Windows.Forms.RadioButton
End Class
