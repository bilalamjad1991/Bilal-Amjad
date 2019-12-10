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
        Me.txtbxSqrMtr = New System.Windows.Forms.TextBox()
        Me.txtbxSqrYrd = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnConvertingUnits = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(82, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter the fabric size in square meter:"
        '
        'txtbxSqrMtr
        '
        Me.txtbxSqrMtr.Location = New System.Drawing.Point(278, 44)
        Me.txtbxSqrMtr.Name = "txtbxSqrMtr"
        Me.txtbxSqrMtr.Size = New System.Drawing.Size(100, 20)
        Me.txtbxSqrMtr.TabIndex = 1
        '
        'txtbxSqrYrd
        '
        Me.txtbxSqrYrd.Location = New System.Drawing.Point(278, 79)
        Me.txtbxSqrYrd.Name = "txtbxSqrYrd"
        Me.txtbxSqrYrd.Size = New System.Drawing.Size(100, 20)
        Me.txtbxSqrYrd.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(95, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "The fabric size in square yards is:"
        '
        'btnConvertingUnits
        '
        Me.btnConvertingUnits.Location = New System.Drawing.Point(150, 133)
        Me.btnConvertingUnits.Name = "btnConvertingUnits"
        Me.btnConvertingUnits.Size = New System.Drawing.Size(108, 23)
        Me.btnConvertingUnits.TabIndex = 4
        Me.btnConvertingUnits.Text = "Converting Units"
        Me.btnConvertingUnits.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(278, 133)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(64, 23)
        Me.btnClear.TabIndex = 5
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 302)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnConvertingUnits)
        Me.Controls.Add(Me.txtbxSqrYrd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtbxSqrMtr)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Welcome To The Units Conversion Soft Plateform"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtbxSqrMtr As System.Windows.Forms.TextBox
    Friend WithEvents txtbxSqrYrd As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnConvertingUnits As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button

End Class
