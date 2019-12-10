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
        Me.txtNickles = New System.Windows.Forms.TextBox()
        Me.txtPennies = New System.Windows.Forms.TextBox()
        Me.txtDollars = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCents = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnResult = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtNickles
        '
        Me.txtNickles.Location = New System.Drawing.Point(141, 49)
        Me.txtNickles.Name = "txtNickles"
        Me.txtNickles.Size = New System.Drawing.Size(100, 20)
        Me.txtNickles.TabIndex = 0
        '
        'txtPennies
        '
        Me.txtPennies.Location = New System.Drawing.Point(141, 105)
        Me.txtPennies.Name = "txtPennies"
        Me.txtPennies.Size = New System.Drawing.Size(100, 20)
        Me.txtPennies.TabIndex = 1
        '
        'txtDollars
        '
        Me.txtDollars.Location = New System.Drawing.Point(141, 211)
        Me.txtDollars.Name = "txtDollars"
        Me.txtDollars.Size = New System.Drawing.Size(100, 20)
        Me.txtDollars.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Enter no. of nickels"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Enter no. of pennies"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(42, 167)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Your collection is worth"
        '
        'txtCents
        '
        Me.txtCents.Location = New System.Drawing.Point(141, 262)
        Me.txtCents.Name = "txtCents"
        Me.txtCents.Size = New System.Drawing.Size(100, 20)
        Me.txtCents.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(55, 218)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "No. of dollars"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(65, 269)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "No. of cents"
        '
        'btnResult
        '
        Me.btnResult.Location = New System.Drawing.Point(76, 308)
        Me.btnResult.Name = "btnResult"
        Me.btnResult.Size = New System.Drawing.Size(75, 23)
        Me.btnResult.TabIndex = 9
        Me.btnResult.Text = "Show Result"
        Me.btnResult.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(202, 308)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 10
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 376)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnResult)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCents)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDollars)
        Me.Controls.Add(Me.txtPennies)
        Me.Controls.Add(Me.txtNickles)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNickles As System.Windows.Forms.TextBox
    Friend WithEvents txtPennies As System.Windows.Forms.TextBox
    Friend WithEvents txtDollars As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCents As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnResult As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button

End Class
