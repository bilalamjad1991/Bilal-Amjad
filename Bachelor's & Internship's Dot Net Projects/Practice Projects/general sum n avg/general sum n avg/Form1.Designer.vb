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
        Me.txtBx1 = New System.Windows.Forms.TextBox()
        Me.txtBx3 = New System.Windows.Forms.TextBox()
        Me.txtBx4 = New System.Windows.Forms.TextBox()
        Me.txtBx2 = New System.Windows.Forms.TextBox()
        Me.txtBx5 = New System.Windows.Forms.TextBox()
        Me.btnSum = New System.Windows.Forms.Button()
        Me.btnAvg = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.txtBx6 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtBx1
        '
        Me.txtBx1.Location = New System.Drawing.Point(204, 41)
        Me.txtBx1.Name = "txtBx1"
        Me.txtBx1.Size = New System.Drawing.Size(100, 20)
        Me.txtBx1.TabIndex = 0
        '
        'txtBx3
        '
        Me.txtBx3.Location = New System.Drawing.Point(204, 112)
        Me.txtBx3.Name = "txtBx3"
        Me.txtBx3.Size = New System.Drawing.Size(100, 20)
        Me.txtBx3.TabIndex = 1
        '
        'txtBx4
        '
        Me.txtBx4.Location = New System.Drawing.Point(204, 152)
        Me.txtBx4.Name = "txtBx4"
        Me.txtBx4.Size = New System.Drawing.Size(100, 20)
        Me.txtBx4.TabIndex = 2
        '
        'txtBx2
        '
        Me.txtBx2.Location = New System.Drawing.Point(204, 76)
        Me.txtBx2.Name = "txtBx2"
        Me.txtBx2.Size = New System.Drawing.Size(100, 20)
        Me.txtBx2.TabIndex = 3
        '
        'txtBx5
        '
        Me.txtBx5.Location = New System.Drawing.Point(84, 204)
        Me.txtBx5.Name = "txtBx5"
        Me.txtBx5.Size = New System.Drawing.Size(100, 20)
        Me.txtBx5.TabIndex = 4
        '
        'btnSum
        '
        Me.btnSum.Location = New System.Drawing.Point(54, 286)
        Me.btnSum.Name = "btnSum"
        Me.btnSum.Size = New System.Drawing.Size(75, 23)
        Me.btnSum.TabIndex = 5
        Me.btnSum.Text = "Sum"
        Me.btnSum.UseVisualStyleBackColor = True
        '
        'btnAvg
        '
        Me.btnAvg.Location = New System.Drawing.Point(204, 286)
        Me.btnAvg.Name = "btnAvg"
        Me.btnAvg.Size = New System.Drawing.Size(75, 23)
        Me.btnAvg.TabIndex = 6
        Me.btnAvg.Text = "Average"
        Me.btnAvg.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Enter values in each field"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(328, 286)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 8
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'txtBx6
        '
        Me.txtBx6.Location = New System.Drawing.Point(303, 201)
        Me.txtBx6.Name = "txtBx6"
        Me.txtBx6.Size = New System.Drawing.Size(100, 20)
        Me.txtBx6.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 204)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Sum is"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(211, 204)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Average is"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 371)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBx6)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAvg)
        Me.Controls.Add(Me.btnSum)
        Me.Controls.Add(Me.txtBx5)
        Me.Controls.Add(Me.txtBx2)
        Me.Controls.Add(Me.txtBx4)
        Me.Controls.Add(Me.txtBx3)
        Me.Controls.Add(Me.txtBx1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBx1 As System.Windows.Forms.TextBox
    Friend WithEvents txtBx3 As System.Windows.Forms.TextBox
    Friend WithEvents txtBx4 As System.Windows.Forms.TextBox
    Friend WithEvents txtBx2 As System.Windows.Forms.TextBox
    Friend WithEvents txtBx5 As System.Windows.Forms.TextBox
    Friend WithEvents btnSum As System.Windows.Forms.Button
    Friend WithEvents btnAvg As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents txtBx6 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
