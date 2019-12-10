<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIndent
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIndent))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fraIndentDetail = New System.Windows.Forms.GroupBox()
        Me.txtStoreInCharge = New System.Windows.Forms.TextBox()
        Me.txtDemandBy = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbSection = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbDepartment = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtIndentDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIndentNo = New System.Windows.Forms.TextBox()
        Me.fraItemDetail = New System.Windows.Forms.GroupBox()
        Me.cmdEditItem = New System.Windows.Forms.Button()
        Me.cmdRemoveItem = New System.Windows.Forms.Button()
        Me.cmdAddItem = New System.Windows.Forms.Button()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBalInHand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAvgCons = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLastPur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtLastPur = New System.Windows.Forms.TextBox()
        Me.txtAvgCons = New System.Windows.Forms.TextBox()
        Me.txtInHand = New System.Windows.Forms.TextBox()
        Me.txtItemDescription = New System.Windows.Forms.TextBox()
        Me.txtItemCode = New System.Windows.Forms.TextBox()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdFind = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.cmdEmail = New System.Windows.Forms.Button()
        Me.fraIndentDetail.SuspendLayout()
        Me.fraItemDetail.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraIndentDetail
        '
        Me.fraIndentDetail.Controls.Add(Me.txtStoreInCharge)
        Me.fraIndentDetail.Controls.Add(Me.txtDemandBy)
        Me.fraIndentDetail.Controls.Add(Me.Label5)
        Me.fraIndentDetail.Controls.Add(Me.Label6)
        Me.fraIndentDetail.Controls.Add(Me.Label4)
        Me.fraIndentDetail.Controls.Add(Me.cmbSection)
        Me.fraIndentDetail.Controls.Add(Me.Label3)
        Me.fraIndentDetail.Controls.Add(Me.cmbDepartment)
        Me.fraIndentDetail.Controls.Add(Me.Label2)
        Me.fraIndentDetail.Controls.Add(Me.dtIndentDate)
        Me.fraIndentDetail.Controls.Add(Me.Label1)
        Me.fraIndentDetail.Controls.Add(Me.txtIndentNo)
        Me.fraIndentDetail.Location = New System.Drawing.Point(12, 12)
        Me.fraIndentDetail.Name = "fraIndentDetail"
        Me.fraIndentDetail.Size = New System.Drawing.Size(873, 88)
        Me.fraIndentDetail.TabIndex = 1
        Me.fraIndentDetail.TabStop = False
        Me.fraIndentDetail.Text = "Indent Detail"
        '
        'txtStoreInCharge
        '
        Me.txtStoreInCharge.Location = New System.Drawing.Point(674, 52)
        Me.txtStoreInCharge.MaxLength = 25
        Me.txtStoreInCharge.Name = "txtStoreInCharge"
        Me.txtStoreInCharge.Size = New System.Drawing.Size(193, 23)
        Me.txtStoreInCharge.TabIndex = 11
        '
        'txtDemandBy
        '
        Me.txtDemandBy.Location = New System.Drawing.Point(673, 22)
        Me.txtDemandBy.MaxLength = 25
        Me.txtDemandBy.Name = "txtDemandBy"
        Me.txtDemandBy.Size = New System.Drawing.Size(193, 23)
        Me.txtDemandBy.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(577, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 23)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Store In-Charge"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(577, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 23)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Demand By"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(254, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 23)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Section"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbSection
        '
        Me.cmbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSection.FormattingEnabled = True
        Me.cmbSection.Location = New System.Drawing.Point(350, 52)
        Me.cmbSection.Name = "cmbSection"
        Me.cmbSection.Size = New System.Drawing.Size(221, 23)
        Me.cmbSection.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(254, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 23)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Department"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbDepartment
        '
        Me.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartment.FormattingEnabled = True
        Me.cmbDepartment.Location = New System.Drawing.Point(350, 22)
        Me.cmbDepartment.Name = "cmbDepartment"
        Me.cmbDepartment.Size = New System.Drawing.Size(221, 23)
        Me.cmbDepartment.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Indent Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtIndentDate
        '
        Me.dtIndentDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtIndentDate.Location = New System.Drawing.Point(104, 52)
        Me.dtIndentDate.Name = "dtIndentDate"
        Me.dtIndentDate.Size = New System.Drawing.Size(137, 23)
        Me.dtIndentDate.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Indent No."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtIndentNo
        '
        Me.txtIndentNo.Location = New System.Drawing.Point(104, 22)
        Me.txtIndentNo.Name = "txtIndentNo"
        Me.txtIndentNo.ReadOnly = True
        Me.txtIndentNo.Size = New System.Drawing.Size(137, 23)
        Me.txtIndentNo.TabIndex = 1
        Me.txtIndentNo.TabStop = False
        '
        'fraItemDetail
        '
        Me.fraItemDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraItemDetail.Controls.Add(Me.cmdEditItem)
        Me.fraItemDetail.Controls.Add(Me.cmdRemoveItem)
        Me.fraItemDetail.Controls.Add(Me.cmdAddItem)
        Me.fraItemDetail.Controls.Add(Me.txtQuantity)
        Me.fraItemDetail.Controls.Add(Me.Grid)
        Me.fraItemDetail.Controls.Add(Me.txtLastPur)
        Me.fraItemDetail.Controls.Add(Me.txtAvgCons)
        Me.fraItemDetail.Controls.Add(Me.txtInHand)
        Me.fraItemDetail.Controls.Add(Me.txtItemDescription)
        Me.fraItemDetail.Controls.Add(Me.txtItemCode)
        Me.fraItemDetail.Location = New System.Drawing.Point(13, 107)
        Me.fraItemDetail.Name = "fraItemDetail"
        Me.fraItemDetail.Size = New System.Drawing.Size(766, 363)
        Me.fraItemDetail.TabIndex = 2
        Me.fraItemDetail.TabStop = False
        Me.fraItemDetail.Text = "Items Detail"
        '
        'cmdEditItem
        '
        Me.cmdEditItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEditItem.Image = CType(resources.GetObject("cmdEditItem.Image"), System.Drawing.Image)
        Me.cmdEditItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEditItem.Location = New System.Drawing.Point(518, 18)
        Me.cmdEditItem.Name = "cmdEditItem"
        Me.cmdEditItem.Size = New System.Drawing.Size(76, 30)
        Me.cmdEditItem.TabIndex = 8
        Me.cmdEditItem.Text = "Edit"
        Me.cmdEditItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdEditItem.UseVisualStyleBackColor = True
        Me.cmdEditItem.Visible = False
        '
        'cmdRemoveItem
        '
        Me.cmdRemoveItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRemoveItem.Image = CType(resources.GetObject("cmdRemoveItem.Image"), System.Drawing.Image)
        Me.cmdRemoveItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdRemoveItem.Location = New System.Drawing.Point(680, 18)
        Me.cmdRemoveItem.Name = "cmdRemoveItem"
        Me.cmdRemoveItem.Size = New System.Drawing.Size(76, 30)
        Me.cmdRemoveItem.TabIndex = 7
        Me.cmdRemoveItem.Text = "Remove"
        Me.cmdRemoveItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdRemoveItem.UseVisualStyleBackColor = True
        '
        'cmdAddItem
        '
        Me.cmdAddItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAddItem.Image = CType(resources.GetObject("cmdAddItem.Image"), System.Drawing.Image)
        Me.cmdAddItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAddItem.Location = New System.Drawing.Point(598, 18)
        Me.cmdAddItem.Name = "cmdAddItem"
        Me.cmdAddItem.Size = New System.Drawing.Size(76, 30)
        Me.cmdAddItem.TabIndex = 6
        Me.cmdAddItem.Text = "Add"
        Me.cmdAddItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAddItem.UseVisualStyleBackColor = True
        '
        'txtQuantity
        '
        Me.txtQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQuantity.Location = New System.Drawing.Point(416, 54)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(80, 23)
        Me.txtQuantity.TabIndex = 2
        Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItemCode, Me.colDescription, Me.colQty, Me.colBalInHand, Me.colAvgCons, Me.colLastPur})
        Me.Grid.Location = New System.Drawing.Point(10, 81)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(746, 276)
        Me.Grid.TabIndex = 9
        '
        'colItemCode
        '
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        '
        'colDescription
        '
        Me.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDescription.HeaderText = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.ReadOnly = True
        '
        'colQty
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colQty.DefaultCellStyle = DataGridViewCellStyle5
        Me.colQty.HeaderText = "Quantity"
        Me.colQty.Name = "colQty"
        Me.colQty.ReadOnly = True
        Me.colQty.Width = 80
        '
        'colBalInHand
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colBalInHand.DefaultCellStyle = DataGridViewCellStyle6
        Me.colBalInHand.HeaderText = "In Hand"
        Me.colBalInHand.Name = "colBalInHand"
        Me.colBalInHand.ReadOnly = True
        Me.colBalInHand.ToolTipText = "Stock in hand"
        Me.colBalInHand.Width = 80
        '
        'colAvgCons
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colAvgCons.DefaultCellStyle = DataGridViewCellStyle7
        Me.colAvgCons.HeaderText = "Avg. Consuption"
        Me.colAvgCons.Name = "colAvgCons"
        Me.colAvgCons.ReadOnly = True
        Me.colAvgCons.ToolTipText = "Average consumption of last three months"
        Me.colAvgCons.Width = 80
        '
        'colLastPur
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "d"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.colLastPur.DefaultCellStyle = DataGridViewCellStyle8
        Me.colLastPur.HeaderText = "Last Purchase"
        Me.colLastPur.Name = "colLastPur"
        Me.colLastPur.ReadOnly = True
        Me.colLastPur.ToolTipText = "Last purchase date"
        '
        'txtLastPur
        '
        Me.txtLastPur.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLastPur.Location = New System.Drawing.Point(656, 54)
        Me.txtLastPur.Name = "txtLastPur"
        Me.txtLastPur.ReadOnly = True
        Me.txtLastPur.Size = New System.Drawing.Size(100, 23)
        Me.txtLastPur.TabIndex = 5
        Me.txtLastPur.TabStop = False
        Me.txtLastPur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAvgCons
        '
        Me.txtAvgCons.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAvgCons.Location = New System.Drawing.Point(576, 54)
        Me.txtAvgCons.Name = "txtAvgCons"
        Me.txtAvgCons.ReadOnly = True
        Me.txtAvgCons.Size = New System.Drawing.Size(80, 23)
        Me.txtAvgCons.TabIndex = 4
        Me.txtAvgCons.TabStop = False
        Me.txtAvgCons.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInHand
        '
        Me.txtInHand.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInHand.Location = New System.Drawing.Point(496, 54)
        Me.txtInHand.Name = "txtInHand"
        Me.txtInHand.ReadOnly = True
        Me.txtInHand.Size = New System.Drawing.Size(80, 23)
        Me.txtInHand.TabIndex = 3
        Me.txtInHand.TabStop = False
        Me.txtInHand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtItemDescription
        '
        Me.txtItemDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtItemDescription.Location = New System.Drawing.Point(110, 54)
        Me.txtItemDescription.Name = "txtItemDescription"
        Me.txtItemDescription.Size = New System.Drawing.Size(308, 23)
        Me.txtItemDescription.TabIndex = 1
        '
        'txtItemCode
        '
        Me.txtItemCode.Location = New System.Drawing.Point(10, 54)
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(100, 23)
        Me.txtItemCode.TabIndex = 0
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Image = CType(resources.GetObject("cmdPrint.Image"), System.Drawing.Image)
        Me.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPrint.Location = New System.Drawing.Point(785, 341)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(108, 39)
        Me.cmdPrint.TabIndex = 6
        Me.cmdPrint.Text = "Print         "
        Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Image = CType(resources.GetObject("cmdClose.Image"), System.Drawing.Image)
        Me.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdClose.Location = New System.Drawing.Point(784, 431)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(108, 39)
        Me.cmdClose.TabIndex = 8
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdFind
        '
        Me.cmdFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFind.Image = CType(resources.GetObject("cmdFind.Image"), System.Drawing.Image)
        Me.cmdFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdFind.Location = New System.Drawing.Point(785, 386)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(108, 39)
        Me.cmdFind.TabIndex = 7
        Me.cmdFind.Text = "Find      "
        Me.cmdFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdFind.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEdit.Image = CType(resources.GetObject("cmdEdit.Image"), System.Drawing.Image)
        Me.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEdit.Location = New System.Drawing.Point(783, 251)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(108, 39)
        Me.cmdEdit.TabIndex = 5
        Me.cmdEdit.Text = "Edit"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(783, 206)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(108, 39)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.Location = New System.Drawing.Point(784, 161)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(108, 39)
        Me.cmdSave.TabIndex = 3
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAdd.Image = CType(resources.GetObject("cmdAdd.Image"), System.Drawing.Image)
        Me.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAdd.Location = New System.Drawing.Point(784, 116)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(108, 39)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.Text = "New"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cmdEmail
        '
        Me.cmdEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEmail.Image = CType(resources.GetObject("cmdEmail.Image"), System.Drawing.Image)
        Me.cmdEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEmail.Location = New System.Drawing.Point(785, 296)
        Me.cmdEmail.Name = "cmdEmail"
        Me.cmdEmail.Size = New System.Drawing.Size(108, 39)
        Me.cmdEmail.TabIndex = 9
        Me.cmdEmail.Text = "Email        "
        Me.cmdEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdEmail.UseVisualStyleBackColor = True
        Me.cmdEmail.Visible = False
        '
        'frmIndent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(912, 477)
        Me.Controls.Add(Me.cmdEmail)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.fraItemDetail)
        Me.Controls.Add(Me.fraIndentDetail)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(920, 470)
        Me.Name = "frmIndent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Indent"
        Me.fraIndentDetail.ResumeLayout(False)
        Me.fraIndentDetail.PerformLayout()
        Me.fraItemDetail.ResumeLayout(False)
        Me.fraItemDetail.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraIndentDetail As System.Windows.Forms.GroupBox
    Friend WithEvents txtStoreInCharge As System.Windows.Forms.TextBox
    Friend WithEvents txtDemandBy As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbSection As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtIndentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIndentNo As System.Windows.Forms.TextBox
    Friend WithEvents fraItemDetail As System.Windows.Forms.GroupBox
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents txtLastPur As System.Windows.Forms.TextBox
    Friend WithEvents txtAvgCons As System.Windows.Forms.TextBox
    Friend WithEvents txtInHand As System.Windows.Forms.TextBox
    Friend WithEvents txtItemDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtItemCode As System.Windows.Forms.TextBox
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdEditItem As System.Windows.Forms.Button
    Friend WithEvents cmdRemoveItem As System.Windows.Forms.Button
    Friend WithEvents cmdAddItem As System.Windows.Forms.Button
    Friend WithEvents cmdEmail As System.Windows.Forms.Button
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBalInHand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAvgCons As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLastPur As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
