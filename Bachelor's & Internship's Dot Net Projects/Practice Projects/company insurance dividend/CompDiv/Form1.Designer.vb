<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPremium = New System.Windows.Forms.TextBox()
        Me.txtClaim = New System.Windows.Forms.TextBox()
        Me.txtDiv = New System.Windows.Forms.TextBox()
        Me.btnCalDiv = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 154)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Premium amount : $"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 187)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Number of claims : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 247)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Total dividend is $ "
        '
        'txtPremium
        '
        Me.txtPremium.Location = New System.Drawing.Point(133, 151)
        Me.txtPremium.Name = "txtPremium"
        Me.txtPremium.Size = New System.Drawing.Size(118, 20)
        Me.txtPremium.TabIndex = 3
        '
        'txtClaim
        '
        Me.txtClaim.Location = New System.Drawing.Point(133, 184)
        Me.txtClaim.Name = "txtClaim"
        Me.txtClaim.Size = New System.Drawing.Size(118, 20)
        Me.txtClaim.TabIndex = 4
        '
        'txtDiv
        '
        Me.txtDiv.Location = New System.Drawing.Point(133, 244)
        Me.txtDiv.Name = "txtDiv"
        Me.txtDiv.ReadOnly = True
        Me.txtDiv.Size = New System.Drawing.Size(118, 20)
        Me.txtDiv.TabIndex = 5
        '
        'btnCalDiv
        '
        Me.btnCalDiv.Location = New System.Drawing.Point(15, 300)
        Me.btnCalDiv.Name = "btnCalDiv"
        Me.btnCalDiv.Size = New System.Drawing.Size(122, 23)
        Me.btnCalDiv.TabIndex = 6
        Me.btnCalDiv.Text = "Calculate Dividend"
        Me.btnCalDiv.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(248, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "This program displays an insurance policy dividend."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(227, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "The basic dividend is 0.045 times the premium."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 79)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(251, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "A bonus dividend of 0.005 times the premium is paid"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 107)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(187, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "for policies with no claim against them."
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(143, 300)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(92, 23)
        Me.btnClear.TabIndex = 14
        Me.btnClear.Text = "Clear Field"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(242, 299)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(92, 23)
        Me.btnExit.TabIndex = 18
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 281)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Label4"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(383, 350)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDiv)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPremium)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.txtClaim)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnCalDiv)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Company Dividend"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPremium As System.Windows.Forms.TextBox
    Friend WithEvents txtClaim As System.Windows.Forms.TextBox
    Friend WithEvents txtDiv As System.Windows.Forms.TextBox
    Friend WithEvents btnCalDiv As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
