<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAllItemsShort
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAllItemsShort))
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.colItemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colShortDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVendor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtFind = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmdSelect = New System.Windows.Forms.Button()
        Me.cmdPreviousPurchase = New System.Windows.Forms.Button()
        Me.cmdShowDetail = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.cmdAddNew = New System.Windows.Forms.Button()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
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
        Me.Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItemID, Me.colDescription, Me.colShortDescription, Me.colCat, Me.colUnit, Me.colVendor})
        Me.Grid.Location = New System.Drawing.Point(11, 51)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(891, 373)
        Me.Grid.TabIndex = 3
        '
        'colItemID
        '
        Me.colItemID.DataPropertyName = "Code"
        Me.colItemID.HeaderText = "Code"
        Me.colItemID.Name = "colItemID"
        Me.colItemID.ReadOnly = True
        '
        'colDescription
        '
        Me.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDescription.DataPropertyName = "Description"
        Me.colDescription.HeaderText = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.ReadOnly = True
        '
        'colShortDescription
        '
        Me.colShortDescription.DataPropertyName = "Short Description"
        Me.colShortDescription.HeaderText = "Short Description"
        Me.colShortDescription.Name = "colShortDescription"
        Me.colShortDescription.ReadOnly = True
        Me.colShortDescription.Width = 160
        '
        'colCat
        '
        Me.colCat.DataPropertyName = "Category"
        Me.colCat.HeaderText = "Category"
        Me.colCat.Name = "colCat"
        Me.colCat.ReadOnly = True
        '
        'colUnit
        '
        Me.colUnit.DataPropertyName = "Unit"
        Me.colUnit.HeaderText = "Unit"
        Me.colUnit.Name = "colUnit"
        Me.colUnit.ReadOnly = True
        '
        'colVendor
        '
        Me.colVendor.DataPropertyName = "Vendor"
        Me.colVendor.HeaderText = "Pref. Vendor"
        Me.colVendor.Name = "colVendor"
        Me.colVendor.ReadOnly = True
        Me.colVendor.Width = 150
        '
        'txtFind
        '
        Me.txtFind.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFind.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFind.Location = New System.Drawing.Point(12, 12)
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(851, 33)
        Me.txtFind.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 473)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(912, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(448, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "Total: "
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(448, 17)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "Found:"
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdSelect
        '
        Me.cmdSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSelect.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSelect.Image = CType(resources.GetObject("cmdSelect.Image"), System.Drawing.Image)
        Me.cmdSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSelect.Location = New System.Drawing.Point(714, 430)
        Me.cmdSelect.Name = "cmdSelect"
        Me.cmdSelect.Size = New System.Drawing.Size(91, 39)
        Me.cmdSelect.TabIndex = 4
        Me.cmdSelect.Text = "Select"
        Me.cmdSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSelect.UseVisualStyleBackColor = True
        '
        'cmdPreviousPurchase
        '
        Me.cmdPreviousPurchase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPreviousPurchase.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdPreviousPurchase.Image = CType(resources.GetObject("cmdPreviousPurchase.Image"), System.Drawing.Image)
        Me.cmdPreviousPurchase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPreviousPurchase.Location = New System.Drawing.Point(12, 431)
        Me.cmdPreviousPurchase.Name = "cmdPreviousPurchase"
        Me.cmdPreviousPurchase.Size = New System.Drawing.Size(140, 39)
        Me.cmdPreviousPurchase.TabIndex = 8
        Me.cmdPreviousPurchase.Text = "Purchase History"
        Me.cmdPreviousPurchase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdPreviousPurchase.UseVisualStyleBackColor = True
        Me.cmdPreviousPurchase.Visible = False
        '
        'cmdShowDetail
        '
        Me.cmdShowDetail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdShowDetail.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdShowDetail.Image = CType(resources.GetObject("cmdShowDetail.Image"), System.Drawing.Image)
        Me.cmdShowDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdShowDetail.Location = New System.Drawing.Point(454, 431)
        Me.cmdShowDetail.Name = "cmdShowDetail"
        Me.cmdShowDetail.Size = New System.Drawing.Size(124, 39)
        Me.cmdShowDetail.TabIndex = 7
        Me.cmdShowDetail.Text = "Show Detail"
        Me.cmdShowDetail.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Image = CType(resources.GetObject("cmdClose.Image"), System.Drawing.Image)
        Me.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdClose.Location = New System.Drawing.Point(811, 430)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(91, 39)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "Close"
        Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRefresh.Image = CType(resources.GetObject("cmdRefresh.Image"), System.Drawing.Image)
        Me.cmdRefresh.Location = New System.Drawing.Point(869, 12)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(33, 33)
        Me.cmdRefresh.TabIndex = 2
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdAddNew
        '
        Me.cmdAddNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAddNew.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdAddNew.Image = CType(resources.GetObject("cmdAddNew.Image"), System.Drawing.Image)
        Me.cmdAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAddNew.Location = New System.Drawing.Point(584, 430)
        Me.cmdAddNew.Name = "cmdAddNew"
        Me.cmdAddNew.Size = New System.Drawing.Size(124, 39)
        Me.cmdAddNew.TabIndex = 9
        Me.cmdAddNew.Text = "Add New"
        Me.cmdAddNew.UseVisualStyleBackColor = True
        '
        'frmAllItemsShort
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.CancelButton = Me.cmdSelect
        Me.ClientSize = New System.Drawing.Size(912, 495)
        Me.Controls.Add(Me.cmdAddNew)
        Me.Controls.Add(Me.cmdPreviousPurchase)
        Me.Controls.Add(Me.cmdShowDetail)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdSelect)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.txtFind)
        Me.Controls.Add(Me.Grid)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "frmAllItemsShort"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "All Items"
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents txtFind As System.Windows.Forms.TextBox
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmdSelect As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdShowDetail As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousPurchase As System.Windows.Forms.Button
    Friend WithEvents colItemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colShortDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVendor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdAddNew As System.Windows.Forms.Button
End Class
