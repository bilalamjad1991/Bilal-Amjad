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
        Me.txtHours = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblGross = New System.Windows.Forms.Label()
        Me.lblOvrTime = New System.Windows.Forms.Label()
        Me.txtHrlyRate = New System.Windows.Forms.TextBox()
        Me.txtComputeGross = New System.Windows.Forms.TextBox()
        Me.txtOvrTimePay = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnCmputeGross = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(67, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Hours Worked :"
        '
        'txtHours
        '
        Me.txtHours.Location = New System.Drawing.Point(208, 112)
        Me.txtHours.Name = "txtHours"
        Me.txtHours.Size = New System.Drawing.Size(100, 20)
        Me.txtHours.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(67, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Hourlly rate :"
        '
        'lblGross
        '
        Me.lblGross.AutoSize = True
        Me.lblGross.Location = New System.Drawing.Point(63, 223)
        Me.lblGross.Name = "lblGross"
        Me.lblGross.Size = New System.Drawing.Size(83, 13)
        Me.lblGross.TabIndex = 3
        Me.lblGross.Text = "Gross salary is $"
        '
        'lblOvrTime
        '
        Me.lblOvrTime.AutoSize = True
        Me.lblOvrTime.Location = New System.Drawing.Point(63, 223)
        Me.lblOvrTime.Name = "lblOvrTime"
        Me.lblOvrTime.Size = New System.Drawing.Size(70, 13)
        Me.lblOvrTime.TabIndex = 4
        Me.lblOvrTime.Text = "Overtime Pay"
        '
        'txtHrlyRate
        '
        Me.txtHrlyRate.Location = New System.Drawing.Point(208, 144)
        Me.txtHrlyRate.Name = "txtHrlyRate"
        Me.txtHrlyRate.Size = New System.Drawing.Size(100, 20)
        Me.txtHrlyRate.TabIndex = 5
        '
        'txtComputeGross
        '
        Me.txtComputeGross.Location = New System.Drawing.Point(204, 220)
        Me.txtComputeGross.Name = "txtComputeGross"
        Me.txtComputeGross.Size = New System.Drawing.Size(100, 20)
        Me.txtComputeGross.TabIndex = 6
        '
        'txtOvrTimePay
        '
        Me.txtOvrTimePay.Location = New System.Drawing.Point(204, 220)
        Me.txtOvrTimePay.Name = "txtOvrTimePay"
        Me.txtOvrTimePay.Size = New System.Drawing.Size(100, 20)
        Me.txtOvrTimePay.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(43, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(241, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "This program computes gross salary and Overtime"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(43, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(175, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "A tax amount of $25 is deducted for"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(43, 69)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(196, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "an employee who earns more than $100"
        '
        'btnCmputeGross
        '
        Me.btnCmputeGross.Location = New System.Drawing.Point(348, 265)
        Me.btnCmputeGross.Name = "btnCmputeGross"
        Me.btnCmputeGross.Size = New System.Drawing.Size(109, 23)
        Me.btnCmputeGross.TabIndex = 11
        Me.btnCmputeGross.Text = "Compute Gross Pay"
        Me.btnCmputeGross.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(463, 265)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 12
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 300)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnCmputeGross)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtOvrTimePay)
        Me.Controls.Add(Me.txtComputeGross)
        Me.Controls.Add(Me.txtHrlyRate)
        Me.Controls.Add(Me.lblOvrTime)
        Me.Controls.Add(Me.lblGross)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtHours)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtHours As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblGross As System.Windows.Forms.Label
    Friend WithEvents lblOvrTime As System.Windows.Forms.Label
    Friend WithEvents txtHrlyRate As System.Windows.Forms.TextBox
    Friend WithEvents txtComputeGross As System.Windows.Forms.TextBox
    Friend WithEvents txtOvrTimePay As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnCmputeGross As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button

End Class
