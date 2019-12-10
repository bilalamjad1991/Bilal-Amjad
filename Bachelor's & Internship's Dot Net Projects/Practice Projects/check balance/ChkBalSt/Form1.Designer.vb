<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChkBal
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
        Me.txtStartBal = New System.Windows.Forms.TextBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtChecks = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDeposits = New System.Windows.Forms.TextBox()
        Me.txtDepositsEnd = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCheckEnd = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtEndBalance = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtStrBal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Balance at start of period"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(333, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "This is your Checkbook Balancing Program. It will keep a record of all"
        '
        'txtStartBal
        '
        Me.txtStartBal.Location = New System.Drawing.Point(195, 107)
        Me.txtStartBal.Name = "txtStartBal"
        Me.txtStartBal.Size = New System.Drawing.Size(127, 20)
        Me.txtStartBal.TabIndex = 3
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(98, 353)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 4
        Me.btnPrint.Text = "Print Report"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(366, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "checks written and depostis made.Please enter all information as prescribed."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Number of checks"
        '
        'txtChecks
        '
        Me.txtChecks.Location = New System.Drawing.Point(195, 133)
        Me.txtChecks.Name = "txtChecks"
        Me.txtChecks.Size = New System.Drawing.Size(127, 20)
        Me.txtChecks.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Number of deposits"
        '
        'txtDeposits
        '
        Me.txtDeposits.Location = New System.Drawing.Point(195, 159)
        Me.txtDeposits.Name = "txtDeposits"
        Me.txtDeposits.Size = New System.Drawing.Size(127, 20)
        Me.txtDeposits.TabIndex = 9
        '
        'txtDepositsEnd
        '
        Me.txtDepositsEnd.Location = New System.Drawing.Point(194, 292)
        Me.txtDepositsEnd.Name = "txtDepositsEnd"
        Me.txtDepositsEnd.ReadOnly = True
        Me.txtDepositsEnd.Size = New System.Drawing.Size(127, 20)
        Me.txtDepositsEnd.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 292)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(164, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Number of deposits for this period"
        '
        'txtCheckEnd
        '
        Me.txtCheckEnd.Location = New System.Drawing.Point(194, 265)
        Me.txtCheckEnd.Name = "txtCheckEnd"
        Me.txtCheckEnd.ReadOnly = True
        Me.txtCheckEnd.Size = New System.Drawing.Size(127, 20)
        Me.txtCheckEnd.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 265)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(160, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Number of checks for this period"
        '
        'txtEndBalance
        '
        Me.txtEndBalance.Location = New System.Drawing.Point(194, 238)
        Me.txtEndBalance.Name = "txtEndBalance"
        Me.txtEndBalance.ReadOnly = True
        Me.txtEndBalance.Size = New System.Drawing.Size(127, 20)
        Me.txtEndBalance.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 238)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Balance at end of period"
        '
        'txtStrBal
        '
        Me.txtStrBal.Location = New System.Drawing.Point(194, 211)
        Me.txtStrBal.Name = "txtStrBal"
        Me.txtStrBal.ReadOnly = True
        Me.txtStrBal.Size = New System.Drawing.Size(127, 20)
        Me.txtStrBal.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 211)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Balance at start of period"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(177, 353)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 14
        Me.btnClear.Text = "Clear Field"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(258, 353)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 15
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmChkBal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 393)
        Me.Controls.Add(Me.txtDepositsEnd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCheckEnd)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtEndBalance)
        Me.Controls.Add(Me.txtDeposits)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtStrBal)
        Me.Controls.Add(Me.txtStartBal)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtChecks)
        Me.Controls.Add(Me.btnPrint)
        Me.Name = "frmChkBal"
        Me.Text = "Checking account balance"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtStartBal As System.Windows.Forms.TextBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtChecks As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDeposits As System.Windows.Forms.TextBox
    Friend WithEvents txtStrBal As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtEndBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCheckEnd As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDepositsEnd As System.Windows.Forms.TextBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button

End Class
