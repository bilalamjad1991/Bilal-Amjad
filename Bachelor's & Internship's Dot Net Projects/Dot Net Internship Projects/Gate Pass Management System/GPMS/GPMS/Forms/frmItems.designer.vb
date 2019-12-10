<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItems
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmItems))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grpItemDetail = New System.Windows.Forms.GroupBox()
        Me.txtItemCode = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbVendors = New System.Windows.Forms.ComboBox()
        Me.cmbFillUnits = New System.Windows.Forms.Button()
        Me.cmbUnits = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmdFillCatagories = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtShortDescription = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtItemCodeOld = New System.Windows.Forms.TextBox()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.grpList = New System.Windows.Forms.GroupBox()
        Me.lblTotalItems = New System.Windows.Forms.Label()
        Me.txtFindItem = New System.Windows.Forms.TextBox()
        Me.cmdClearSearch = New System.Windows.Forms.Button()
        Me.cmdFindItem = New System.Windows.Forms.Button()
        Me.GridItems = New System.Windows.Forms.DataGridView()
        Me.colCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TT = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.grpItemDetail.SuspendLayout()
        Me.grpList.SuspendLayout()
        CType(Me.GridItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpItemDetail
        '
        Me.grpItemDetail.Controls.Add(Me.txtItemCode)
        Me.grpItemDetail.Controls.Add(Me.Label4)
        Me.grpItemDetail.Controls.Add(Me.Button1)
        Me.grpItemDetail.Controls.Add(Me.cmbVendors)
        Me.grpItemDetail.Controls.Add(Me.cmbFillUnits)
        Me.grpItemDetail.Controls.Add(Me.cmbUnits)
        Me.grpItemDetail.Controls.Add(Me.Label18)
        Me.grpItemDetail.Controls.Add(Me.cmdFillCatagories)
        Me.grpItemDetail.Controls.Add(Me.Label5)
        Me.grpItemDetail.Controls.Add(Me.Label3)
        Me.grpItemDetail.Controls.Add(Me.Label2)
        Me.grpItemDetail.Controls.Add(Me.Label1)
        Me.grpItemDetail.Controls.Add(Me.txtShortDescription)
        Me.grpItemDetail.Controls.Add(Me.txtDescription)
        Me.grpItemDetail.Controls.Add(Me.txtItemCodeOld)
        Me.grpItemDetail.Controls.Add(Me.cmbCategory)
        Me.grpItemDetail.Location = New System.Drawing.Point(10, 2)
        Me.grpItemDetail.Name = "grpItemDetail"
        Me.grpItemDetail.Size = New System.Drawing.Size(559, 205)
        Me.grpItemDetail.TabIndex = 1
        Me.grpItemDetail.TabStop = False
        Me.grpItemDetail.Text = "Item Detail"
        '
        'txtItemCode
        '
        Me.txtItemCode.Location = New System.Drawing.Point(138, 23)
        Me.txtItemCode.Mask = "000-000-00000"
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.PromptChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.txtItemCode.Size = New System.Drawing.Size(111, 23)
        Me.txtItemCode.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 179)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 15)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Preffered Vendor*"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(367, 175)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 24)
        Me.Button1.TabIndex = 14
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbVendors
        '
        Me.cmbVendors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendors.FormattingEnabled = True
        Me.cmbVendors.Location = New System.Drawing.Point(138, 176)
        Me.cmbVendors.Name = "cmbVendors"
        Me.cmbVendors.Size = New System.Drawing.Size(223, 23)
        Me.cmbVendors.TabIndex = 13
        '
        'cmbFillUnits
        '
        Me.cmbFillUnits.Image = CType(resources.GetObject("cmbFillUnits.Image"), System.Drawing.Image)
        Me.cmbFillUnits.Location = New System.Drawing.Point(367, 142)
        Me.cmbFillUnits.Name = "cmbFillUnits"
        Me.cmbFillUnits.Size = New System.Drawing.Size(24, 24)
        Me.cmbFillUnits.TabIndex = 11
        Me.cmbFillUnits.UseVisualStyleBackColor = True
        '
        'cmbUnits
        '
        Me.cmbUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnits.FormattingEnabled = True
        Me.cmbUnits.Location = New System.Drawing.Point(138, 143)
        Me.cmbUnits.Name = "cmbUnits"
        Me.cmbUnits.Size = New System.Drawing.Size(223, 23)
        Me.cmbUnits.TabIndex = 10
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 145)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(124, 15)
        Me.Label18.TabIndex = 9
        Me.Label18.Text = "Unit of Measurement*"
        '
        'cmdFillCatagories
        '
        Me.cmdFillCatagories.Image = CType(resources.GetObject("cmdFillCatagories.Image"), System.Drawing.Image)
        Me.cmdFillCatagories.Location = New System.Drawing.Point(367, 50)
        Me.cmdFillCatagories.Name = "cmdFillCatagories"
        Me.cmdFillCatagories.Size = New System.Drawing.Size(24, 24)
        Me.cmdFillCatagories.TabIndex = 4
        Me.cmdFillCatagories.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 15)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Short Description*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(60, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Description*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(72, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Category*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(70, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Item Code"
        '
        'txtShortDescription
        '
        Me.txtShortDescription.Location = New System.Drawing.Point(138, 112)
        Me.txtShortDescription.MaxLength = 255
        Me.txtShortDescription.Name = "txtShortDescription"
        Me.txtShortDescription.Size = New System.Drawing.Size(392, 23)
        Me.txtShortDescription.TabIndex = 8
        Me.TT.SetToolTip(Me.txtShortDescription, "Will be printed on Invoice")
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(138, 80)
        Me.txtDescription.MaxLength = 40
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(392, 23)
        Me.txtDescription.TabIndex = 6
        Me.TT.SetToolTip(Me.txtDescription, "Will be printed on barcode label")
        '
        'txtItemCodeOld
        '
        Me.txtItemCodeOld.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtItemCodeOld.Location = New System.Drawing.Point(409, 14)
        Me.txtItemCodeOld.Name = "txtItemCodeOld"
        Me.txtItemCodeOld.ReadOnly = True
        Me.txtItemCodeOld.Size = New System.Drawing.Size(144, 23)
        Me.txtItemCodeOld.TabIndex = 15
        Me.txtItemCodeOld.Visible = False
        '
        'cmbCategory
        '
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(138, 51)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(223, 23)
        Me.cmbCategory.TabIndex = 3
        '
        'grpList
        '
        Me.grpList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpList.Controls.Add(Me.lblTotalItems)
        Me.grpList.Controls.Add(Me.txtFindItem)
        Me.grpList.Controls.Add(Me.cmdClearSearch)
        Me.grpList.Controls.Add(Me.cmdFindItem)
        Me.grpList.Controls.Add(Me.GridItems)
        Me.grpList.Location = New System.Drawing.Point(10, 209)
        Me.grpList.Name = "grpList"
        Me.grpList.Size = New System.Drawing.Size(559, 261)
        Me.grpList.TabIndex = 5
        Me.grpList.TabStop = False
        Me.grpList.Text = "List"
        '
        'lblTotalItems
        '
        Me.lblTotalItems.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalItems.AutoSize = True
        Me.lblTotalItems.Location = New System.Drawing.Point(6, 243)
        Me.lblTotalItems.Name = "lblTotalItems"
        Me.lblTotalItems.Size = New System.Drawing.Size(78, 15)
        Me.lblTotalItems.TabIndex = 4
        Me.lblTotalItems.Text = "Total Items: 0"
        '
        'txtFindItem
        '
        Me.txtFindItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFindItem.Location = New System.Drawing.Point(5, 18)
        Me.txtFindItem.Name = "txtFindItem"
        Me.txtFindItem.Size = New System.Drawing.Size(489, 23)
        Me.txtFindItem.TabIndex = 0
        '
        'cmdClearSearch
        '
        Me.cmdClearSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearSearch.Image = CType(resources.GetObject("cmdClearSearch.Image"), System.Drawing.Image)
        Me.cmdClearSearch.Location = New System.Drawing.Point(529, 16)
        Me.cmdClearSearch.Name = "cmdClearSearch"
        Me.cmdClearSearch.Size = New System.Drawing.Size(24, 26)
        Me.cmdClearSearch.TabIndex = 2
        Me.cmdClearSearch.UseVisualStyleBackColor = True
        '
        'cmdFindItem
        '
        Me.cmdFindItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFindItem.Image = CType(resources.GetObject("cmdFindItem.Image"), System.Drawing.Image)
        Me.cmdFindItem.Location = New System.Drawing.Point(499, 16)
        Me.cmdFindItem.Name = "cmdFindItem"
        Me.cmdFindItem.Size = New System.Drawing.Size(24, 26)
        Me.cmdFindItem.TabIndex = 1
        Me.cmdFindItem.UseVisualStyleBackColor = True
        '
        'GridItems
        '
        Me.GridItems.AllowUserToAddRows = False
        Me.GridItems.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue
        Me.GridItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.GridItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCode, Me.colName, Me.colUnit, Me.colCategory})
        Me.GridItems.Location = New System.Drawing.Point(9, 48)
        Me.GridItems.Name = "GridItems"
        Me.GridItems.ReadOnly = True
        Me.GridItems.RowHeadersVisible = False
        Me.GridItems.Size = New System.Drawing.Size(544, 192)
        Me.GridItems.TabIndex = 3
        '
        'colCode
        '
        Me.colCode.DataPropertyName = "Code"
        Me.colCode.HeaderText = "Code"
        Me.colCode.Name = "colCode"
        Me.colCode.ReadOnly = True
        '
        'colName
        '
        Me.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colName.DataPropertyName = "Description"
        Me.colName.HeaderText = "Description"
        Me.colName.MinimumWidth = 180
        Me.colName.Name = "colName"
        Me.colName.ReadOnly = True
        '
        'colUnit
        '
        Me.colUnit.DataPropertyName = "Unit"
        Me.colUnit.HeaderText = "Unit"
        Me.colUnit.Name = "colUnit"
        Me.colUnit.ReadOnly = True
        '
        'colCategory
        '
        Me.colCategory.DataPropertyName = "Category"
        Me.colCategory.HeaderText = "Category"
        Me.colCategory.Name = "colCategory"
        Me.colCategory.ReadOnly = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Image = CType(resources.GetObject("cmdClose.Image"), System.Drawing.Image)
        Me.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdClose.Location = New System.Drawing.Point(575, 428)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(108, 39)
        Me.cmdClose.TabIndex = 6
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEdit.Image = CType(resources.GetObject("cmdEdit.Image"), System.Drawing.Image)
        Me.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEdit.Location = New System.Drawing.Point(575, 383)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(108, 39)
        Me.cmdEdit.TabIndex = 4
        Me.cmdEdit.Text = "Edit"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(575, 338)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(108, 39)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.Location = New System.Drawing.Point(575, 293)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(108, 39)
        Me.cmdSave.TabIndex = 2
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAdd.Image = CType(resources.GetObject("cmdAdd.Image"), System.Drawing.Image)
        Me.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAdd.Location = New System.Drawing.Point(575, 248)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(108, 39)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.Text = "New"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'frmItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(692, 482)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.grpList)
        Me.Controls.Add(Me.grpItemDetail)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(708, 520)
        Me.Name = "frmItems"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Items"
        Me.grpItemDetail.ResumeLayout(False)
        Me.grpItemDetail.PerformLayout()
        Me.grpList.ResumeLayout(False)
        Me.grpList.PerformLayout()
        CType(Me.GridItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpItemDetail As System.Windows.Forms.GroupBox
    Friend WithEvents grpList As System.Windows.Forms.GroupBox
    Friend WithEvents GridItems As System.Windows.Forms.DataGridView
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents txtFindItem As System.Windows.Forms.TextBox
    Friend WithEvents cmdClearSearch As System.Windows.Forms.Button
    Friend WithEvents cmdFindItem As System.Windows.Forms.Button
    Friend WithEvents TT As System.Windows.Forms.ToolTip
    Friend WithEvents lblTotalItems As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmbVendors As System.Windows.Forms.ComboBox
    Friend WithEvents cmbFillUnits As System.Windows.Forms.Button
    Friend WithEvents cmbUnits As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmdFillCatagories As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtShortDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtItemCodeOld As System.Windows.Forms.TextBox
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents colCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtItemCode As System.Windows.Forms.MaskedTextBox
End Class
