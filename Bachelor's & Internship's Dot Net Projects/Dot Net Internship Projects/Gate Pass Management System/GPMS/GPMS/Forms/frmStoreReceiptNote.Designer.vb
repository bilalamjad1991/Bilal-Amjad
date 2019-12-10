<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStoreReceiptNote
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStoreReceiptNote))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtItemID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.colItemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUOM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRejected = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colApproved = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtRate = New System.Windows.Forms.TextBox()
        Me.fraGatePass = New System.Windows.Forms.GroupBox()
        Me.cmbDepartment = New System.Windows.Forms.ComboBox()
        Me.txtIGPNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSupplierName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSRNNo = New System.Windows.Forms.TextBox()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.fraDetail = New System.Windows.Forms.GroupBox()
        Me.txtApprovedItem = New System.Windows.Forms.TextBox()
        Me.cmdEditItem = New System.Windows.Forms.Button()
        Me.txtRejectedItem = New System.Windows.Forms.TextBox()
        Me.cmdRemoveItem = New System.Windows.Forms.Button()
        Me.cmdAddItem = New System.Windows.Forms.Button()
        Me.txtReceivedItem = New System.Windows.Forms.TextBox()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdFind = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraGatePass.SuspendLayout()
        Me.fraDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(9, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 22)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "IGP #"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Location = New System.Drawing.Point(107, 50)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(161, 20)
        Me.txtDescription.TabIndex = 1
        Me.txtDescription.TabStop = False
        Me.txtDescription.Visible = False
        '
        'txtItemID
        '
        Me.txtItemID.Location = New System.Drawing.Point(205, 263)
        Me.txtItemID.Name = "txtItemID"
        Me.txtItemID.Size = New System.Drawing.Size(100, 20)
        Me.txtItemID.TabIndex = 0
        Me.txtItemID.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Location = New System.Drawing.Point(629, 309)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 22)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Total Quantity"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(738, 309)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(83, 22)
        Me.txtTotal.TabIndex = 10
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItemID, Me.colDescription, Me.colUOM, Me.colReceived, Me.colRejected, Me.colApproved, Me.colCode, Me.colRate, Me.colQty})
        Me.Grid.Location = New System.Drawing.Point(6, 19)
        Me.Grid.Name = "Grid"
        Me.Grid.RowHeadersVisible = False
        Me.Grid.Size = New System.Drawing.Size(814, 287)
        Me.Grid.TabIndex = 8
        '
        'colItemID
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.colItemID.DefaultCellStyle = DataGridViewCellStyle1
        Me.colItemID.HeaderText = "Item Code"
        Me.colItemID.Name = "colItemID"
        '
        'colDescription
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        Me.colDescription.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDescription.HeaderText = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.Width = 150
        '
        'colUOM
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        Me.colUOM.DefaultCellStyle = DataGridViewCellStyle3
        Me.colUOM.HeaderText = "Unit"
        Me.colUOM.Name = "colUOM"
        Me.colUOM.Width = 80
        '
        'colReceived
        '
        Me.colReceived.HeaderText = "Received"
        Me.colReceived.Name = "colReceived"
        Me.colReceived.Width = 80
        '
        'colRejected
        '
        Me.colRejected.HeaderText = "Rejected"
        Me.colRejected.Name = "colRejected"
        Me.colRejected.Width = 80
        '
        'colApproved
        '
        Me.colApproved.HeaderText = "Approved"
        Me.colApproved.Name = "colApproved"
        Me.colApproved.Width = 80
        '
        'colCode
        '
        Me.colCode.HeaderText = "Code"
        Me.colCode.Name = "colCode"
        Me.colCode.Width = 80
        '
        'colRate
        '
        Me.colRate.HeaderText = "Rate"
        Me.colRate.Name = "colRate"
        Me.colRate.Width = 80
        '
        'colQty
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colQty.DefaultCellStyle = DataGridViewCellStyle4
        Me.colQty.HeaderText = "Amount"
        Me.colQty.Name = "colQty"
        Me.colQty.Width = 80
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(252, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 22)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Remarks"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(331, 81)
        Me.txtRemarks.MaxLength = 25
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(362, 20)
        Me.txtRemarks.TabIndex = 20
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(225, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 22)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Department"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRate
        '
        Me.txtRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRate.BackColor = System.Drawing.SystemColors.Window
        Me.txtRate.Location = New System.Drawing.Point(658, 49)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(80, 20)
        Me.txtRate.TabIndex = 8
        Me.txtRate.TabStop = False
        Me.txtRate.Visible = False
        '
        'fraGatePass
        '
        Me.fraGatePass.Controls.Add(Me.cmbDepartment)
        Me.fraGatePass.Controls.Add(Me.Label4)
        Me.fraGatePass.Controls.Add(Me.txtRemarks)
        Me.fraGatePass.Controls.Add(Me.Label13)
        Me.fraGatePass.Controls.Add(Me.Label6)
        Me.fraGatePass.Controls.Add(Me.txtIGPNo)
        Me.fraGatePass.Controls.Add(Me.Label3)
        Me.fraGatePass.Controls.Add(Me.txtSupplierName)
        Me.fraGatePass.Controls.Add(Me.Label2)
        Me.fraGatePass.Controls.Add(Me.dtDate)
        Me.fraGatePass.Controls.Add(Me.Label1)
        Me.fraGatePass.Controls.Add(Me.txtSRNNo)
        Me.fraGatePass.Location = New System.Drawing.Point(12, 13)
        Me.fraGatePass.Name = "fraGatePass"
        Me.fraGatePass.Size = New System.Drawing.Size(913, 119)
        Me.fraGatePass.TabIndex = 10
        Me.fraGatePass.TabStop = False
        Me.fraGatePass.Text = "Store Receipt Note"
        '
        'cmbDepartment
        '
        Me.cmbDepartment.FormattingEnabled = True
        Me.cmbDepartment.Location = New System.Drawing.Point(330, 51)
        Me.cmbDepartment.Name = "cmbDepartment"
        Me.cmbDepartment.Size = New System.Drawing.Size(246, 21)
        Me.cmbDepartment.TabIndex = 21
        '
        'txtIGPNo
        '
        Me.txtIGPNo.Location = New System.Drawing.Point(88, 50)
        Me.txtIGPNo.MaxLength = 15
        Me.txtIGPNo.Name = "txtIGPNo"
        Me.txtIGPNo.ReadOnly = True
        Me.txtIGPNo.Size = New System.Drawing.Size(105, 20)
        Me.txtIGPNo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(248, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 22)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Supplier Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSupplierName
        '
        Me.txtSupplierName.Location = New System.Drawing.Point(330, 20)
        Me.txtSupplierName.MaxLength = 15
        Me.txtSupplierName.Name = "txtSupplierName"
        Me.txtSupplierName.Size = New System.Drawing.Size(246, 20)
        Me.txtSupplierName.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(9, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 22)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtDate
        '
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDate.Location = New System.Drawing.Point(88, 78)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(105, 20)
        Me.dtDate.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SRN #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSRNNo
        '
        Me.txtSRNNo.Location = New System.Drawing.Point(90, 22)
        Me.txtSRNNo.Name = "txtSRNNo"
        Me.txtSRNNo.ReadOnly = True
        Me.txtSRNNo.Size = New System.Drawing.Size(105, 20)
        Me.txtSRNNo.TabIndex = 1
        Me.txtSRNNo.TabStop = False
        '
        'txtQty
        '
        Me.txtQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQty.Location = New System.Drawing.Point(739, 49)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(83, 20)
        Me.txtQty.TabIndex = 9
        Me.txtQty.Visible = False
        '
        'fraDetail
        '
        Me.fraDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraDetail.Controls.Add(Me.txtApprovedItem)
        Me.fraDetail.Controls.Add(Me.cmdEditItem)
        Me.fraDetail.Controls.Add(Me.txtRejectedItem)
        Me.fraDetail.Controls.Add(Me.cmdRemoveItem)
        Me.fraDetail.Controls.Add(Me.cmdAddItem)
        Me.fraDetail.Controls.Add(Me.txtReceivedItem)
        Me.fraDetail.Controls.Add(Me.txtItemID)
        Me.fraDetail.Controls.Add(Me.Label5)
        Me.fraDetail.Controls.Add(Me.txtUnit)
        Me.fraDetail.Controls.Add(Me.txtTotal)
        Me.fraDetail.Controls.Add(Me.Grid)
        Me.fraDetail.Controls.Add(Me.txtCode)
        Me.fraDetail.Controls.Add(Me.txtQty)
        Me.fraDetail.Controls.Add(Me.txtRate)
        Me.fraDetail.Controls.Add(Me.txtDescription)
        Me.fraDetail.Location = New System.Drawing.Point(12, 138)
        Me.fraDetail.Name = "fraDetail"
        Me.fraDetail.Size = New System.Drawing.Size(827, 337)
        Me.fraDetail.TabIndex = 11
        Me.fraDetail.TabStop = False
        Me.fraDetail.Text = "Detail"
        '
        'txtApprovedItem
        '
        Me.txtApprovedItem.Location = New System.Drawing.Point(550, 262)
        Me.txtApprovedItem.Name = "txtApprovedItem"
        Me.txtApprovedItem.Size = New System.Drawing.Size(80, 20)
        Me.txtApprovedItem.TabIndex = 7
        Me.txtApprovedItem.Visible = False
        '
        'cmdEditItem
        '
        Me.cmdEditItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEditItem.Image = CType(resources.GetObject("cmdEditItem.Image"), System.Drawing.Image)
        Me.cmdEditItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEditItem.Location = New System.Drawing.Point(551, 228)
        Me.cmdEditItem.Name = "cmdEditItem"
        Me.cmdEditItem.Size = New System.Drawing.Size(76, 28)
        Me.cmdEditItem.TabIndex = 7
        Me.cmdEditItem.Text = "Edit"
        Me.cmdEditItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdEditItem.UseVisualStyleBackColor = True
        Me.cmdEditItem.Visible = False
        '
        'txtRejectedItem
        '
        Me.txtRejectedItem.Location = New System.Drawing.Point(469, 262)
        Me.txtRejectedItem.Name = "txtRejectedItem"
        Me.txtRejectedItem.Size = New System.Drawing.Size(80, 20)
        Me.txtRejectedItem.TabIndex = 6
        Me.txtRejectedItem.Visible = False
        '
        'cmdRemoveItem
        '
        Me.cmdRemoveItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRemoveItem.Image = CType(resources.GetObject("cmdRemoveItem.Image"), System.Drawing.Image)
        Me.cmdRemoveItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdRemoveItem.Location = New System.Drawing.Point(715, 227)
        Me.cmdRemoveItem.Name = "cmdRemoveItem"
        Me.cmdRemoveItem.Size = New System.Drawing.Size(76, 28)
        Me.cmdRemoveItem.TabIndex = 11
        Me.cmdRemoveItem.Text = "Remove"
        Me.cmdRemoveItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdRemoveItem.UseVisualStyleBackColor = True
        Me.cmdRemoveItem.Visible = False
        '
        'cmdAddItem
        '
        Me.cmdAddItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAddItem.Image = CType(resources.GetObject("cmdAddItem.Image"), System.Drawing.Image)
        Me.cmdAddItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAddItem.Location = New System.Drawing.Point(633, 227)
        Me.cmdAddItem.Name = "cmdAddItem"
        Me.cmdAddItem.Size = New System.Drawing.Size(76, 28)
        Me.cmdAddItem.TabIndex = 10
        Me.cmdAddItem.Text = "Add"
        Me.cmdAddItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAddItem.UseVisualStyleBackColor = True
        Me.cmdAddItem.Visible = False
        '
        'txtReceivedItem
        '
        Me.txtReceivedItem.Location = New System.Drawing.Point(391, 262)
        Me.txtReceivedItem.Name = "txtReceivedItem"
        Me.txtReceivedItem.Size = New System.Drawing.Size(78, 20)
        Me.txtReceivedItem.TabIndex = 5
        Me.txtReceivedItem.Visible = False
        '
        'txtUnit
        '
        Me.txtUnit.Location = New System.Drawing.Point(311, 263)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(80, 20)
        Me.txtUnit.TabIndex = 3
        Me.txtUnit.Visible = False
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(260, 50)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(78, 20)
        Me.txtCode.TabIndex = 2
        Me.txtCode.Visible = False
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Image = CType(resources.GetObject("cmdPrint.Image"), System.Drawing.Image)
        Me.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPrint.Location = New System.Drawing.Point(846, 346)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(108, 39)
        Me.cmdPrint.TabIndex = 15
        Me.cmdPrint.Text = "Print         "
        Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Image = CType(resources.GetObject("cmdClose.Image"), System.Drawing.Image)
        Me.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdClose.Location = New System.Drawing.Point(845, 436)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(108, 39)
        Me.cmdClose.TabIndex = 17
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdFind
        '
        Me.cmdFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFind.Image = CType(resources.GetObject("cmdFind.Image"), System.Drawing.Image)
        Me.cmdFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdFind.Location = New System.Drawing.Point(846, 391)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(108, 39)
        Me.cmdFind.TabIndex = 16
        Me.cmdFind.Text = "Find      "
        Me.cmdFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdFind.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEdit.Image = CType(resources.GetObject("cmdEdit.Image"), System.Drawing.Image)
        Me.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEdit.Location = New System.Drawing.Point(845, 169)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(108, 39)
        Me.cmdEdit.TabIndex = 14
        Me.cmdEdit.Text = "Edit"
        Me.cmdEdit.UseVisualStyleBackColor = True
        Me.cmdEdit.Visible = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(845, 301)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(108, 39)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.Location = New System.Drawing.Point(846, 256)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(108, 39)
        Me.cmdSave.TabIndex = 12
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAdd.Image = CType(resources.GetObject("cmdAdd.Image"), System.Drawing.Image)
        Me.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAdd.Location = New System.Drawing.Point(846, 211)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(108, 39)
        Me.cmdAdd.TabIndex = 9
        Me.cmdAdd.Text = "New"
        Me.cmdAdd.UseVisualStyleBackColor = True
        Me.cmdAdd.Visible = False
        '
        'frmStoreReceiptNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(966, 487)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.fraGatePass)
        Me.Controls.Add(Me.fraDetail)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStoreReceiptNote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Store Receipt Note"
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraGatePass.ResumeLayout(False)
        Me.fraGatePass.PerformLayout()
        Me.fraDetail.ResumeLayout(False)
        Me.fraDetail.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdRemoveItem As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtItemID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents cmdEditItem As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents txtRate As System.Windows.Forms.TextBox
    Friend WithEvents fraGatePass As System.Windows.Forms.GroupBox
    Friend WithEvents txtIGPNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSRNNo As System.Windows.Forms.TextBox
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents fraDetail As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAddItem As System.Windows.Forms.Button
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtApprovedItem As System.Windows.Forms.TextBox
    Friend WithEvents txtRejectedItem As System.Windows.Forms.TextBox
    Friend WithEvents txtReceivedItem As System.Windows.Forms.TextBox
    Friend WithEvents txtUnit As System.Windows.Forms.TextBox
    Friend WithEvents cmbDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents colItemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReceived As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRejected As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colApproved As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQty As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
