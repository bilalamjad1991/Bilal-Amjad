<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmApproveIndent
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmApproveIndent))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFindIndent = New System.Windows.Forms.TextBox()
        Me.cmdClearSearch = New System.Windows.Forms.Button()
        Me.cmdFindIndent = New System.Windows.Forms.Button()
        Me.GridIndents = New System.Windows.Forms.DataGridView()
        Me.colIndentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDepartment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSection = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDemandBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStoreInCharge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GridDetail = New System.Windows.Forms.DataGridView()
        Me.colDetIndentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInHand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAvgCons = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLastPur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colApproved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cmdApprove = New System.Windows.Forms.Button()
        Me.cmdReject = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridIndents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdRefresh)
        Me.GroupBox1.Controls.Add(Me.cmdSave)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtFindIndent)
        Me.GroupBox1.Controls.Add(Me.cmdClearSearch)
        Me.GroupBox1.Controls.Add(Me.cmdFindIndent)
        Me.GroupBox1.Controls.Add(Me.GridIndents)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(994, 196)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Open Indents"
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRefresh.Image = CType(resources.GetObject("cmdRefresh.Image"), System.Drawing.Image)
        Me.cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdRefresh.Location = New System.Drawing.Point(897, 148)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(91, 41)
        Me.cmdRefresh.TabIndex = 8
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.Location = New System.Drawing.Point(897, 101)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(91, 41)
        Me.cmdSave.TabIndex = 7
        Me.cmdSave.Text = "Select"
        Me.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSave.UseVisualStyleBackColor = True
        Me.cmdSave.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Filter"
        '
        'txtFindIndent
        '
        Me.txtFindIndent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFindIndent.Location = New System.Drawing.Point(53, 15)
        Me.txtFindIndent.Name = "txtFindIndent"
        Me.txtFindIndent.Size = New System.Drawing.Size(788, 22)
        Me.txtFindIndent.TabIndex = 3
        '
        'cmdClearSearch
        '
        Me.cmdClearSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearSearch.Image = CType(resources.GetObject("cmdClearSearch.Image"), System.Drawing.Image)
        Me.cmdClearSearch.Location = New System.Drawing.Point(867, 13)
        Me.cmdClearSearch.Name = "cmdClearSearch"
        Me.cmdClearSearch.Size = New System.Drawing.Size(24, 26)
        Me.cmdClearSearch.TabIndex = 5
        Me.cmdClearSearch.UseVisualStyleBackColor = True
        '
        'cmdFindIndent
        '
        Me.cmdFindIndent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFindIndent.Image = CType(resources.GetObject("cmdFindIndent.Image"), System.Drawing.Image)
        Me.cmdFindIndent.Location = New System.Drawing.Point(842, 13)
        Me.cmdFindIndent.Name = "cmdFindIndent"
        Me.cmdFindIndent.Size = New System.Drawing.Size(24, 26)
        Me.cmdFindIndent.TabIndex = 4
        Me.cmdFindIndent.UseVisualStyleBackColor = True
        '
        'GridIndents
        '
        Me.GridIndents.AllowUserToAddRows = False
        Me.GridIndents.AllowUserToDeleteRows = False
        Me.GridIndents.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridIndents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridIndents.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIndentNo, Me.colDate, Me.colDepartment, Me.colSection, Me.colDemandBy, Me.colStoreInCharge, Me.colStatus})
        Me.GridIndents.Location = New System.Drawing.Point(7, 43)
        Me.GridIndents.Name = "GridIndents"
        Me.GridIndents.ReadOnly = True
        Me.GridIndents.RowHeadersVisible = False
        Me.GridIndents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridIndents.Size = New System.Drawing.Size(884, 146)
        Me.GridIndents.TabIndex = 0
        '
        'colIndentNo
        '
        Me.colIndentNo.DataPropertyName = "Indent No"
        Me.colIndentNo.HeaderText = "IndentNo"
        Me.colIndentNo.Name = "colIndentNo"
        Me.colIndentNo.ReadOnly = True
        '
        'colDate
        '
        Me.colDate.DataPropertyName = "Date"
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.colDate.DefaultCellStyle = DataGridViewCellStyle5
        Me.colDate.HeaderText = "Date"
        Me.colDate.Name = "colDate"
        Me.colDate.ReadOnly = True
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
        Me.colDemandBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDemandBy.DataPropertyName = "Demand By"
        Me.colDemandBy.HeaderText = "Demand By"
        Me.colDemandBy.Name = "colDemandBy"
        Me.colDemandBy.ReadOnly = True
        '
        'colStoreInCharge
        '
        Me.colStoreInCharge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colStoreInCharge.DataPropertyName = "Store In-Charge"
        Me.colStoreInCharge.HeaderText = "Store In-Charge"
        Me.colStoreInCharge.Name = "colStoreInCharge"
        Me.colStoreInCharge.ReadOnly = True
        '
        'colStatus
        '
        Me.colStatus.DataPropertyName = "Status"
        Me.colStatus.HeaderText = "Status"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.ReadOnly = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.GridDetail)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 215)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(891, 249)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Indent Detail"
        '
        'GridDetail
        '
        Me.GridDetail.AllowUserToAddRows = False
        Me.GridDetail.AllowUserToDeleteRows = False
        Me.GridDetail.AllowUserToOrderColumns = True
        Me.GridDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDetIndentNo, Me.colItemID, Me.colDescription, Me.colQty, Me.colInHand, Me.colAvgCons, Me.colLastPur, Me.colEdit, Me.colApproved})
        Me.GridDetail.Location = New System.Drawing.Point(7, 21)
        Me.GridDetail.Name = "GridDetail"
        Me.GridDetail.RowHeadersVisible = False
        Me.GridDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridDetail.Size = New System.Drawing.Size(878, 222)
        Me.GridDetail.TabIndex = 0
        '
        'colDetIndentNo
        '
        Me.colDetIndentNo.DataPropertyName = "IndentNo"
        Me.colDetIndentNo.HeaderText = "IndentNo"
        Me.colDetIndentNo.Name = "colDetIndentNo"
        Me.colDetIndentNo.Visible = False
        '
        'colItemID
        '
        Me.colItemID.DataPropertyName = "ItemID"
        Me.colItemID.HeaderText = "Item Code"
        Me.colItemID.Name = "colItemID"
        Me.colItemID.ReadOnly = True
        '
        'colDescription
        '
        Me.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDescription.DataPropertyName = "ItemDescription"
        Me.colDescription.HeaderText = "Descriprion"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.ReadOnly = True
        '
        'colQty
        '
        Me.colQty.DataPropertyName = "Quantity"
        Me.colQty.HeaderText = "Quantity"
        Me.colQty.Name = "colQty"
        Me.colQty.ReadOnly = True
        '
        'colInHand
        '
        Me.colInHand.DataPropertyName = "InHand"
        Me.colInHand.HeaderText = "In Hand"
        Me.colInHand.Name = "colInHand"
        Me.colInHand.ReadOnly = True
        '
        'colAvgCons
        '
        Me.colAvgCons.DataPropertyName = "AvgCons"
        Me.colAvgCons.HeaderText = "Avg. Consuption"
        Me.colAvgCons.Name = "colAvgCons"
        '
        'colLastPur
        '
        Me.colLastPur.DataPropertyName = "LastPurchase"
        DataGridViewCellStyle6.Format = "d"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colLastPur.DefaultCellStyle = DataGridViewCellStyle6
        Me.colLastPur.HeaderText = "Last Purchase"
        Me.colLastPur.Name = "colLastPur"
        '
        'colEdit
        '
        Me.colEdit.HeaderText = "Edit"
        Me.colEdit.Name = "colEdit"
        Me.colEdit.Text = "Edit"
        Me.colEdit.UseColumnTextForButtonValue = True
        Me.colEdit.Width = 60
        '
        'colApproved
        '
        Me.colApproved.HeaderText = "Approved"
        Me.colApproved.Name = "colApproved"
        Me.colApproved.Width = 60
        '
        'cmdApprove
        '
        Me.cmdApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdApprove.Image = CType(resources.GetObject("cmdApprove.Image"), System.Drawing.Image)
        Me.cmdApprove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdApprove.Location = New System.Drawing.Point(910, 329)
        Me.cmdApprove.Name = "cmdApprove"
        Me.cmdApprove.Size = New System.Drawing.Size(97, 41)
        Me.cmdApprove.TabIndex = 10
        Me.cmdApprove.Text = "Approve"
        Me.cmdApprove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdApprove.UseVisualStyleBackColor = True
        '
        'cmdReject
        '
        Me.cmdReject.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReject.Image = CType(resources.GetObject("cmdReject.Image"), System.Drawing.Image)
        Me.cmdReject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdReject.Location = New System.Drawing.Point(910, 376)
        Me.cmdReject.Name = "cmdReject"
        Me.cmdReject.Size = New System.Drawing.Size(97, 41)
        Me.cmdReject.TabIndex = 9
        Me.cmdReject.Text = "Reject"
        Me.cmdReject.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdReject.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(910, 282)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(97, 41)
        Me.Button4.TabIndex = 11
        Me.Button4.Text = "Hold"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Image = CType(resources.GetObject("cmdClose.Image"), System.Drawing.Image)
        Me.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdClose.Location = New System.Drawing.Point(910, 423)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(97, 41)
        Me.cmdClose.TabIndex = 12
        Me.cmdClose.Text = "Close"
        Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'frmApproveIndent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1019, 476)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.cmdApprove)
        Me.Controls.Add(Me.cmdReject)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmApproveIndent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Approve Indent"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GridIndents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GridDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GridIndents As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFindIndent As System.Windows.Forms.TextBox
    Friend WithEvents cmdClearSearch As System.Windows.Forms.Button
    Friend WithEvents cmdFindIndent As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents GridDetail As System.Windows.Forms.DataGridView
    Friend WithEvents cmdApprove As System.Windows.Forms.Button
    Friend WithEvents cmdReject As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents colIndentNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDepartment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSection As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDemandBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStoreInCharge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDetIndentNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInHand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAvgCons As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLastPur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEdit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colApproved As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
