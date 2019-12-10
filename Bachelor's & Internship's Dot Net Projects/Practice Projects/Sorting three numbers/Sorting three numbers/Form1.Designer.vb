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
        Me.fstNum = New System.Windows.Forms.TextBox()
        Me.secNum = New System.Windows.Forms.TextBox()
        Me.thdNum = New System.Windows.Forms.TextBox()
        Me.odrNum = New System.Windows.Forms.TextBox()
        Me.btnProcess = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fstNum
        '
        Me.fstNum.Location = New System.Drawing.Point(205, 39)
        Me.fstNum.Name = "fstNum"
        Me.fstNum.Size = New System.Drawing.Size(100, 20)
        Me.fstNum.TabIndex = 0
        '
        'secNum
        '
        Me.secNum.Location = New System.Drawing.Point(205, 82)
        Me.secNum.Name = "secNum"
        Me.secNum.Size = New System.Drawing.Size(100, 20)
        Me.secNum.TabIndex = 1
        '
        'thdNum
        '
        Me.thdNum.Location = New System.Drawing.Point(205, 125)
        Me.thdNum.Name = "thdNum"
        Me.thdNum.Size = New System.Drawing.Size(100, 20)
        Me.thdNum.TabIndex = 2
        '
        'odrNum
        '
        Me.odrNum.Location = New System.Drawing.Point(205, 164)
        Me.odrNum.Name = "odrNum"
        Me.odrNum.Size = New System.Drawing.Size(100, 20)
        Me.odrNum.TabIndex = 3
        '
        'btnProcess
        '
        Me.btnProcess.Location = New System.Drawing.Point(53, 243)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(75, 23)
        Me.btnProcess.TabIndex = 4
        Me.btnProcess.Text = "Process"
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(205, 243)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Clear text"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(179, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Enter the three numbers to be sorted"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 171)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "The threesorted numbers are"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(389, 317)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnProcess)
        Me.Controls.Add(Me.odrNum)
        Me.Controls.Add(Me.thdNum)
        Me.Controls.Add(Me.secNum)
        Me.Controls.Add(Me.fstNum)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fstNum As System.Windows.Forms.TextBox
    Friend WithEvents secNum As System.Windows.Forms.TextBox
    Friend WithEvents thdNum As System.Windows.Forms.TextBox
    Friend WithEvents odrNum As System.Windows.Forms.TextBox
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
