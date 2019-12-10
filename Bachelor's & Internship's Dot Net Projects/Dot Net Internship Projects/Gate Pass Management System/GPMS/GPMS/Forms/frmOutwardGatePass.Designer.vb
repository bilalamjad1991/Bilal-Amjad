<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOutwardGatePass
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOutwardGatePass))
        Me.fraGatePass = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPurpose = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtOGPNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAllow = New System.Windows.Forms.TextBox()
        Me.txtDestination = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDesignation = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSRNNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.fraGoodsRecFrom = New System.Windows.Forms.GroupBox()
        Me.rdbtnNR = New System.Windows.Forms.RadioButton()
        Me.optHeadOffice = New System.Windows.Forms.RadioButton()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtItemID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.colItemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUOM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEDR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtBrand = New System.Windows.Forms.TextBox()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.fraDetail = New System.Windows.Forms.GroupBox()
        Me.cmdEditItem = New System.Windows.Forms.Button()
        Me.cmdRemoveItem = New System.Windows.Forms.Button()
        Me.cmdAddItem = New System.Windows.Forms.Button()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdFind = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.fraGatePass.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.fraGoodsRecFrom.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraGatePass
        '
        Me.fraGatePass.Controls.Add(Me.GroupBox2)
        Me.fraGatePass.Controls.Add(Me.GroupBox1)
        Me.fraGatePass.Controls.Add(Me.fraGoodsRecFrom)
        Me.fraGatePass.Location = New System.Drawing.Point(12, 12)
        Me.fraGatePass.Name = "fraGatePass"
        Me.fraGatePass.Size = New System.Drawing.Size(913, 149)
        Me.fraGatePass.TabIndex = 10
        Me.fraGatePass.TabStop = False
        Me.fraGatePass.Text = "Outward Gatepass"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPurpose)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtOGPNo)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtAllow)
        Me.GroupBox2.Controls.Add(Me.txtDestination)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtDesignation)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Location = New System.Drawing.Point(216, 22)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(691, 116)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        '
        'txtPurpose
        '
        Me.txtPurpose.Location = New System.Drawing.Point(412, 72)
        Me.txtPurpose.Name = "txtPurpose"
        Me.txtPurpose.Size = New System.Drawing.Size(269, 20)
        Me.txtPurpose.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(6, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 22)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "OGP No."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOGPNo
        '
        Me.txtOGPNo.Location = New System.Drawing.Point(87, 18)
        Me.txtOGPNo.MaxLength = 15
        Me.txtOGPNo.Name = "txtOGPNo"
        Me.txtOGPNo.ReadOnly = True
        Me.txtOGPNo.Size = New System.Drawing.Size(105, 20)
        Me.txtOGPNo.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(9, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 22)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Destination:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAllow
        '
        Me.txtAllow.Location = New System.Drawing.Point(87, 46)
        Me.txtAllow.MaxLength = 15
        Me.txtAllow.Name = "txtAllow"
        Me.txtAllow.Size = New System.Drawing.Size(247, 20)
        Me.txtAllow.TabIndex = 12
        '
        'txtDestination
        '
        Me.txtDestination.Location = New System.Drawing.Point(87, 74)
        Me.txtDestination.MaxLength = 25
        Me.txtDestination.Name = "txtDestination"
        Me.txtDestination.Size = New System.Drawing.Size(247, 20)
        Me.txtDestination.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(6, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 22)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "This Allows:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(336, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 22)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Pupose:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDesignation
        '
        Me.txtDesignation.Location = New System.Drawing.Point(412, 46)
        Me.txtDesignation.MaxLength = 25
        Me.txtDesignation.Name = "txtDesignation"
        Me.txtDesignation.Size = New System.Drawing.Size(269, 20)
        Me.txtDesignation.TabIndex = 18
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(336, 44)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 22)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Designation:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSRNNo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtDate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(201, 71)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SRN Data"
        '
        'txtSRNNo
        '
        Me.txtSRNNo.Location = New System.Drawing.Point(74, 15)
        Me.txtSRNNo.Name = "txtSRNNo"
        Me.txtSRNNo.ReadOnly = True
        Me.txtSRNNo.Size = New System.Drawing.Size(105, 20)
        Me.txtSRNNo.TabIndex = 1
        Me.txtSRNNo.TabStop = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(2, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SRN No."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtDate
        '
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDate.Location = New System.Drawing.Point(74, 44)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(105, 20)
        Me.dtDate.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(5, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 22)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "SRN Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fraGoodsRecFrom
        '
        Me.fraGoodsRecFrom.Controls.Add(Me.rdbtnNR)
        Me.fraGoodsRecFrom.Controls.Add(Me.optHeadOffice)
        Me.fraGoodsRecFrom.Location = New System.Drawing.Point(12, 97)
        Me.fraGoodsRecFrom.Name = "fraGoodsRecFrom"
        Me.fraGoodsRecFrom.Size = New System.Drawing.Size(201, 41)
        Me.fraGoodsRecFrom.TabIndex = 8
        Me.fraGoodsRecFrom.TabStop = False
        Me.fraGoodsRecFrom.Text = "Goods Return Type"
        '
        'rdbtnNR
        '
        Me.rdbtnNR.AutoSize = True
        Me.rdbtnNR.Checked = True
        Me.rdbtnNR.Location = New System.Drawing.Point(98, 16)
        Me.rdbtnNR.Name = "rdbtnNR"
        Me.rdbtnNR.Size = New System.Drawing.Size(100, 17)
        Me.rdbtnNR.TabIndex = 1
        Me.rdbtnNR.TabStop = True
        Me.rdbtnNR.Text = "Non-Returnable"
        Me.rdbtnNR.UseVisualStyleBackColor = True
        '
        'optHeadOffice
        '
        Me.optHeadOffice.AutoSize = True
        Me.optHeadOffice.Checked = True
        Me.optHeadOffice.Location = New System.Drawing.Point(15, 16)
        Me.optHeadOffice.Name = "optHeadOffice"
        Me.optHeadOffice.Size = New System.Drawing.Size(77, 17)
        Me.optHeadOffice.TabIndex = 0
        Me.optHeadOffice.TabStop = True
        Me.optHeadOffice.Text = "Returnable"
        Me.optHeadOffice.UseVisualStyleBackColor = True
        '
        'txtUnit
        '
        Me.txtUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUnit.Location = New System.Drawing.Point(493, 211)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.ReadOnly = True
        Me.txtUnit.Size = New System.Drawing.Size(80, 20)
        Me.txtUnit.TabIndex = 2
        Me.txtUnit.TabStop = False
        Me.txtUnit.Visible = False
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Location = New System.Drawing.Point(110, 211)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(383, 20)
        Me.txtDescription.TabIndex = 1
        Me.txtDescription.TabStop = False
        Me.txtDescription.Visible = False
        '
        'txtItemID
        '
        Me.txtItemID.Location = New System.Drawing.Point(10, 211)
        Me.txtItemID.Name = "txtItemID"
        Me.txtItemID.Size = New System.Drawing.Size(100, 20)
        Me.txtItemID.TabIndex = 0
        Me.txtItemID.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Location = New System.Drawing.Point(601, 323)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 22)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Total Quantity"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Visible = False
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(710, 323)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(83, 22)
        Me.txtTotal.TabIndex = 10
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotal.Visible = False
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItemID, Me.colDescription, Me.colUOM, Me.colNumber, Me.colEDR, Me.colRemarks})
        Me.Grid.Location = New System.Drawing.Point(7, 19)
        Me.Grid.Name = "Grid"
        Me.Grid.RowHeadersVisible = False
        Me.Grid.Size = New System.Drawing.Size(786, 326)
        Me.Grid.TabIndex = 8
        '
        'colItemID
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        Me.colItemID.DefaultCellStyle = DataGridViewCellStyle7
        Me.colItemID.HeaderText = "Item Code"
        Me.colItemID.Name = "colItemID"
        Me.colItemID.ReadOnly = True
        '
        'colDescription
        '
        Me.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        Me.colDescription.DefaultCellStyle = DataGridViewCellStyle8
        Me.colDescription.HeaderText = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.ReadOnly = True
        '
        'colUOM
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        Me.colUOM.DefaultCellStyle = DataGridViewCellStyle9
        Me.colUOM.HeaderText = "Unit"
        Me.colUOM.Name = "colUOM"
        Me.colUOM.ReadOnly = True
        Me.colUOM.Width = 80
        '
        'colNumber
        '
        Me.colNumber.HeaderText = "Number"
        Me.colNumber.Name = "colNumber"
        '
        'colEDR
        '
        Me.colEDR.HeaderText = "EDR"
        Me.colEDR.Name = "colEDR"
        '
        'colRemarks
        '
        Me.colRemarks.HeaderText = "Remarks"
        Me.colRemarks.Name = "colRemarks"
        '
        'txtBrand
        '
        Me.txtBrand.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBrand.Location = New System.Drawing.Point(573, 211)
        Me.txtBrand.Name = "txtBrand"
        Me.txtBrand.Size = New System.Drawing.Size(140, 20)
        Me.txtBrand.TabIndex = 3
        Me.txtBrand.Visible = False
        '
        'txtQty
        '
        Me.txtQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQty.Location = New System.Drawing.Point(588, 185)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(80, 20)
        Me.txtQty.TabIndex = 4
        Me.txtQty.Visible = False
        '
        'fraDetail
        '
        Me.fraDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraDetail.Controls.Add(Me.cmdEditItem)
        Me.fraDetail.Controls.Add(Me.cmdRemoveItem)
        Me.fraDetail.Controls.Add(Me.cmdAddItem)
        Me.fraDetail.Controls.Add(Me.txtQty)
        Me.fraDetail.Controls.Add(Me.txtBrand)
        Me.fraDetail.Controls.Add(Me.txtUnit)
        Me.fraDetail.Controls.Add(Me.txtDescription)
        Me.fraDetail.Controls.Add(Me.txtItemID)
        Me.fraDetail.Controls.Add(Me.Label5)
        Me.fraDetail.Controls.Add(Me.txtTotal)
        Me.fraDetail.Controls.Add(Me.Grid)
        Me.fraDetail.Location = New System.Drawing.Point(12, 167)
        Me.fraDetail.Name = "fraDetail"
        Me.fraDetail.Size = New System.Drawing.Size(799, 351)
        Me.fraDetail.TabIndex = 11
        Me.fraDetail.TabStop = False
        Me.fraDetail.Text = "Detail"
        '
        'cmdEditItem
        '
        Me.cmdEditItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEditItem.Image = CType(resources.GetObject("cmdEditItem.Image"), System.Drawing.Image)
        Me.cmdEditItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEditItem.Location = New System.Drawing.Point(550, 245)
        Me.cmdEditItem.Name = "cmdEditItem"
        Me.cmdEditItem.Size = New System.Drawing.Size(76, 28)
        Me.cmdEditItem.TabIndex = 7
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
        Me.cmdRemoveItem.Location = New System.Drawing.Point(714, 245)
        Me.cmdRemoveItem.Name = "cmdRemoveItem"
        Me.cmdRemoveItem.Size = New System.Drawing.Size(76, 28)
        Me.cmdRemoveItem.TabIndex = 6
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
        Me.cmdAddItem.Location = New System.Drawing.Point(632, 245)
        Me.cmdAddItem.Name = "cmdAddItem"
        Me.cmdAddItem.Size = New System.Drawing.Size(76, 28)
        Me.cmdAddItem.TabIndex = 5
        Me.cmdAddItem.Text = "Add"
        Me.cmdAddItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAddItem.UseVisualStyleBackColor = True
        Me.cmdAddItem.Visible = False
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Image = CType(resources.GetObject("cmdPrint.Image"), System.Drawing.Image)
        Me.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPrint.Location = New System.Drawing.Point(818, 389)
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
        Me.cmdClose.Location = New System.Drawing.Point(817, 479)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(109, 39)
        Me.cmdClose.TabIndex = 17
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdFind
        '
        Me.cmdFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFind.Image = CType(resources.GetObject("cmdFind.Image"), System.Drawing.Image)
        Me.cmdFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdFind.Location = New System.Drawing.Point(818, 434)
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
        Me.cmdEdit.Location = New System.Drawing.Point(818, 254)
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
        Me.cmdCancel.Location = New System.Drawing.Point(817, 344)
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
        Me.cmdSave.Location = New System.Drawing.Point(818, 299)
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
        Me.cmdAdd.Location = New System.Drawing.Point(818, 209)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(108, 39)
        Me.cmdAdd.TabIndex = 9
        Me.cmdAdd.Text = "New"
        Me.cmdAdd.UseVisualStyleBackColor = True
        Me.cmdAdd.Visible = False
        '
        'frmOutwardGatePass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(938, 539)
        Me.Controls.Add(Me.fraGatePass)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.fraDetail)
        Me.Controls.Add(Me.cmdAdd)
        Me.Name = "frmOutwardGatePass"
        Me.Text = "Outward GatePass"
        Me.fraGatePass.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.fraGoodsRecFrom.ResumeLayout(False)
        Me.fraGoodsRecFrom.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraDetail.ResumeLayout(False)
        Me.fraDetail.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraGatePass As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDestination As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtDesignation As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAllow As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtOGPNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSRNNo As System.Windows.Forms.TextBox
    Friend WithEvents txtUnit As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtItemID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents txtBrand As System.Windows.Forms.TextBox
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents cmdAddItem As System.Windows.Forms.Button
    Friend WithEvents fraDetail As System.Windows.Forms.GroupBox
    Friend WithEvents cmdEditItem As System.Windows.Forms.Button
    Friend WithEvents cmdRemoveItem As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents fraGoodsRecFrom As System.Windows.Forms.GroupBox
    Friend WithEvents optHeadOffice As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbtnNR As System.Windows.Forms.RadioButton
    Friend WithEvents txtPurpose As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents colItemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEDR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
