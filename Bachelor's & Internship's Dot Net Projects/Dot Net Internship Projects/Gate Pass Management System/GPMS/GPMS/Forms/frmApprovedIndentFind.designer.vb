<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmApprovedIndentFind
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmApprovedIndentFind))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.txtFind = New System.Windows.Forms.TextBox()
        Me.dtDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdSelect = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.cmdFind = New System.Windows.Forms.Button()
        Me.colIndentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDepartment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSection = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDemandBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStoreIncharge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIndentNo, Me.colDate, Me.colDepartment, Me.colSection, Me.colDemandBy, Me.colStoreIncharge})
        Me.Grid.Location = New System.Drawing.Point(15, 58)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(764, 421)
        Me.Grid.TabIndex = 7
        '
        'txtFind
        '
        Me.txtFind.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFind.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFind.Location = New System.Drawing.Point(15, 29)
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(557, 23)
        Me.txtFind.TabIndex = 1
        '
        'dtDate
        '
        Me.dtDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDate.Location = New System.Drawing.Point(593, 29)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.ShowCheckBox = True
        Me.dtDate.Size = New System.Drawing.Size(113, 23)
        Me.dtDate.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(300, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Find Indent (Enter Indent No, Department, Section etc. )"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(578, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Indent Date"
        '
        'cmdSelect
        '
        Me.cmdSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSelect.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSelect.Image = CType(resources.GetObject("cmdSelect.Image"), System.Drawing.Image)
        Me.cmdSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSelect.Location = New System.Drawing.Point(591, 490)
        Me.cmdSelect.Name = "cmdSelect"
        Me.cmdSelect.Size = New System.Drawing.Size(91, 39)
        Me.cmdSelect.TabIndex = 8
        Me.cmdSelect.Text = "&Select"
        Me.cmdSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSelect.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Image = CType(resources.GetObject("cmdClose.Image"), System.Drawing.Image)
        Me.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdClose.Location = New System.Drawing.Point(688, 490)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(91, 39)
        Me.cmdClose.TabIndex = 9
        Me.cmdClose.Text = "&Close"
        Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRefresh.Image = CType(resources.GetObject("cmdRefresh.Image"), System.Drawing.Image)
        Me.cmdRefresh.Location = New System.Drawing.Point(746, 19)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(33, 33)
        Me.cmdRefresh.TabIndex = 6
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdFind
        '
        Me.cmdFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFind.Image = CType(resources.GetObject("cmdFind.Image"), System.Drawing.Image)
        Me.cmdFind.Location = New System.Drawing.Point(710, 19)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(33, 33)
        Me.cmdFind.TabIndex = 5
        Me.cmdFind.UseVisualStyleBackColor = True
        '
        'colIndentNo
        '
        Me.colIndentNo.DataPropertyName = "Indent No"
        Me.colIndentNo.HeaderText = "Indent No"
        Me.colIndentNo.Name = "colIndentNo"
        Me.colIndentNo.ReadOnly = True
        '
        'colDate
        '
        Me.colDate.DataPropertyName = "Date"
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.colDate.DefaultCellStyle = DataGridViewCellStyle1
        Me.colDate.HeaderText = "Date"
        Me.colDate.Name = "colDate"
        Me.colDate.ReadOnly = True
        Me.colDate.Width = 80
        '
        'colDepartment
        '
        Me.colDepartment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDepartment.DataPropertyName = "Department"
        Me.colDepartment.HeaderText = "Department"
        Me.colDepartment.Name = "colDepartment"
        Me.colDepartment.ReadOnly = True
        '
        'colSection
        '
        Me.colSection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colSection.DataPropertyName = "Section"
        Me.colSection.HeaderText = "Section"
        Me.colSection.Name = "colSection"
        Me.colSection.ReadOnly = True
        '
        'colDemandBy
        '
        Me.colDemandBy.DataPropertyName = "Demand By"
        Me.colDemandBy.HeaderText = "Demand By"
        Me.colDemandBy.Name = "colDemandBy"
        Me.colDemandBy.ReadOnly = True
        Me.colDemandBy.Width = 120
        '
        'colStoreIncharge
        '
        Me.colStoreIncharge.DataPropertyName = "Store In-Charge"
        Me.colStoreIncharge.HeaderText = "Store In-Charge"
        Me.colStoreIncharge.Name = "colStoreIncharge"
        Me.colStoreIncharge.ReadOnly = True
        Me.colStoreIncharge.Width = 120
        '
        'frmApprovedIndentFind
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.CancelButton = Me.cmdSelect
        Me.ClientSize = New System.Drawing.Size(787, 541)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtDate)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdSelect)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.txtFind)
        Me.Controls.Add(Me.Grid)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(698, 579)
        Me.Name = "frmApprovedIndentFind"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Find Purchase"
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdSelect As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents txtFind As System.Windows.Forms.TextBox
    Friend WithEvents dtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents colIndentNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDepartment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSection As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDemandBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStoreIncharge As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
