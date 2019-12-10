<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInwardGatePass
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInwardGatePass))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fraGatePass = New System.Windows.Forms.GroupBox()
        Me.cmbGM = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbStorekeeper = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtGateIncharge = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtPersonDelivered = New System.Windows.Forms.TextBox()
        Me.fraGoodsRecFrom = New System.Windows.Forms.GroupBox()
        Me.optReturn = New System.Windows.Forms.RadioButton()
        Me.fraReturn = New System.Windows.Forms.GroupBox()
        Me.cmdPickOutGatePass = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtOutGatePassNo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtOutDate = New System.Windows.Forms.DateTimePicker()
        Me.optHeadOffice = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtTime = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtBiltyDate = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtBiltyNo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRefNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtVehicleNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtGatePassNo = New System.Windows.Forms.TextBox()
        Me.fraDetail = New System.Windows.Forms.GroupBox()
        Me.cmdEditItem = New System.Windows.Forms.Button()
        Me.cmdRemoveItem = New System.Windows.Forms.Button()
        Me.cmdAddItem = New System.Windows.Forms.Button()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.txtBrand = New System.Windows.Forms.TextBox()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtItemID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.colItemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUOM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBrand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdFind = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.fraGatePass.SuspendLayout()
        Me.fraGoodsRecFrom.SuspendLayout()
        Me.fraReturn.SuspendLayout()
        Me.fraDetail.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraGatePass
        '
        Me.fraGatePass.Controls.Add(Me.cmbGM)
        Me.fraGatePass.Controls.Add(Me.Label15)
        Me.fraGatePass.Controls.Add(Me.Label14)
        Me.fraGatePass.Controls.Add(Me.cmbStorekeeper)
        Me.fraGatePass.Controls.Add(Me.Label4)
        Me.fraGatePass.Controls.Add(Me.txtRemarks)
        Me.fraGatePass.Controls.Add(Me.Label13)
        Me.fraGatePass.Controls.Add(Me.txtGateIncharge)
        Me.fraGatePass.Controls.Add(Me.Label12)
        Me.fraGatePass.Controls.Add(Me.txtPersonDelivered)
        Me.fraGatePass.Controls.Add(Me.fraGoodsRecFrom)
        Me.fraGatePass.Controls.Add(Me.Label11)
        Me.fraGatePass.Controls.Add(Me.dtTime)
        Me.fraGatePass.Controls.Add(Me.Label10)
        Me.fraGatePass.Controls.Add(Me.dtBiltyDate)
        Me.fraGatePass.Controls.Add(Me.Label9)
        Me.fraGatePass.Controls.Add(Me.txtBiltyNo)
        Me.fraGatePass.Controls.Add(Me.Label6)
        Me.fraGatePass.Controls.Add(Me.txtRefNo)
        Me.fraGatePass.Controls.Add(Me.Label3)
        Me.fraGatePass.Controls.Add(Me.txtVehicleNo)
        Me.fraGatePass.Controls.Add(Me.Label2)
        Me.fraGatePass.Controls.Add(Me.dtDate)
        Me.fraGatePass.Controls.Add(Me.Label1)
        Me.fraGatePass.Controls.Add(Me.txtGatePassNo)
        Me.fraGatePass.Location = New System.Drawing.Point(13, 13)
        Me.fraGatePass.Name = "fraGatePass"
        Me.fraGatePass.Size = New System.Drawing.Size(913, 170)
        Me.fraGatePass.TabIndex = 1
        Me.fraGatePass.TabStop = False
        Me.fraGatePass.Text = "Inward Gatepass"
        '
        'cmbGM
        '
        Me.cmbGM.FormattingEnabled = True
        Me.cmbGM.Location = New System.Drawing.Point(545, 106)
        Me.cmbGM.Name = "cmbGM"
        Me.cmbGM.Size = New System.Drawing.Size(110, 21)
        Me.cmbGM.TabIndex = 24
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(487, 111)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(25, 13)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "GM"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(685, 111)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 13)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Store Keeper"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbStorekeeper
        '
        Me.cmbStorekeeper.FormattingEnabled = True
        Me.cmbStorekeeper.Location = New System.Drawing.Point(763, 108)
        Me.cmbStorekeeper.Name = "cmbStorekeeper"
        Me.cmbStorekeeper.Size = New System.Drawing.Size(144, 21)
        Me.cmbStorekeeper.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(466, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 22)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Remarks"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(545, 133)
        Me.txtRemarks.MaxLength = 25
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(362, 22)
        Me.txtRemarks.TabIndex = 20
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(662, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 22)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Gate Incharge"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtGateIncharge
        '
        Me.txtGateIncharge.Location = New System.Drawing.Point(763, 48)
        Me.txtGateIncharge.MaxLength = 25
        Me.txtGateIncharge.Name = "txtGateIncharge"
        Me.txtGateIncharge.Size = New System.Drawing.Size(144, 22)
        Me.txtGateIncharge.TabIndex = 18
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(662, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 22)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Delivery Person"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPersonDelivered
        '
        Me.txtPersonDelivered.Location = New System.Drawing.Point(763, 21)
        Me.txtPersonDelivered.MaxLength = 25
        Me.txtPersonDelivered.Name = "txtPersonDelivered"
        Me.txtPersonDelivered.Size = New System.Drawing.Size(144, 22)
        Me.txtPersonDelivered.TabIndex = 16
        '
        'fraGoodsRecFrom
        '
        Me.fraGoodsRecFrom.Controls.Add(Me.optReturn)
        Me.fraGoodsRecFrom.Controls.Add(Me.fraReturn)
        Me.fraGoodsRecFrom.Controls.Add(Me.optHeadOffice)
        Me.fraGoodsRecFrom.Location = New System.Drawing.Point(211, 14)
        Me.fraGoodsRecFrom.Name = "fraGoodsRecFrom"
        Me.fraGoodsRecFrom.Size = New System.Drawing.Size(249, 115)
        Me.fraGoodsRecFrom.TabIndex = 8
        Me.fraGoodsRecFrom.TabStop = False
        Me.fraGoodsRecFrom.Text = "Goods Received From"
        '
        'optReturn
        '
        Me.optReturn.AutoSize = True
        Me.optReturn.Location = New System.Drawing.Point(15, 35)
        Me.optReturn.Name = "optReturn"
        Me.optReturn.Size = New System.Drawing.Size(57, 17)
        Me.optReturn.TabIndex = 1
        Me.optReturn.Text = "Return"
        Me.optReturn.UseVisualStyleBackColor = True
        '
        'fraReturn
        '
        Me.fraReturn.Controls.Add(Me.cmdPickOutGatePass)
        Me.fraReturn.Controls.Add(Me.Label7)
        Me.fraReturn.Controls.Add(Me.txtOutGatePassNo)
        Me.fraReturn.Controls.Add(Me.Label8)
        Me.fraReturn.Controls.Add(Me.dtOutDate)
        Me.fraReturn.Enabled = False
        Me.fraReturn.Location = New System.Drawing.Point(8, 35)
        Me.fraReturn.Name = "fraReturn"
        Me.fraReturn.Size = New System.Drawing.Size(234, 75)
        Me.fraReturn.TabIndex = 2
        Me.fraReturn.TabStop = False
        '
        'cmdPickOutGatePass
        '
        Me.cmdPickOutGatePass.Location = New System.Drawing.Point(203, 19)
        Me.cmdPickOutGatePass.Name = "cmdPickOutGatePass"
        Me.cmdPickOutGatePass.Size = New System.Drawing.Size(25, 23)
        Me.cmdPickOutGatePass.TabIndex = 4
        Me.cmdPickOutGatePass.Text = "..."
        Me.cmdPickOutGatePass.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(18, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 22)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Out Gatepass #"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOutGatePassNo
        '
        Me.txtOutGatePassNo.Location = New System.Drawing.Point(112, 19)
        Me.txtOutGatePassNo.Name = "txtOutGatePassNo"
        Me.txtOutGatePassNo.ReadOnly = True
        Me.txtOutGatePassNo.Size = New System.Drawing.Size(84, 22)
        Me.txtOutGatePassNo.TabIndex = 1
        Me.txtOutGatePassNo.TabStop = False
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(21, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 22)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Out Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtOutDate
        '
        Me.dtOutDate.Enabled = False
        Me.dtOutDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtOutDate.Location = New System.Drawing.Point(111, 46)
        Me.dtOutDate.Name = "dtOutDate"
        Me.dtOutDate.Size = New System.Drawing.Size(117, 22)
        Me.dtOutDate.TabIndex = 3
        '
        'optHeadOffice
        '
        Me.optHeadOffice.AutoSize = True
        Me.optHeadOffice.Checked = True
        Me.optHeadOffice.Location = New System.Drawing.Point(15, 16)
        Me.optHeadOffice.Name = "optHeadOffice"
        Me.optHeadOffice.Size = New System.Drawing.Size(82, 17)
        Me.optHeadOffice.TabIndex = 0
        Me.optHeadOffice.TabStop = True
        Me.optHeadOffice.Text = "Head Office"
        Me.optHeadOffice.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(9, 106)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 22)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Time In"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtTime
        '
        Me.dtTime.CustomFormat = "hh:mm"
        Me.dtTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtTime.Location = New System.Drawing.Point(88, 106)
        Me.dtTime.Name = "dtTime"
        Me.dtTime.ShowUpDown = True
        Me.dtTime.Size = New System.Drawing.Size(105, 22)
        Me.dtTime.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(463, 78)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 22)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Bilty Date"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtBiltyDate
        '
        Me.dtBiltyDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtBiltyDate.Location = New System.Drawing.Point(545, 78)
        Me.dtBiltyDate.Name = "dtBiltyDate"
        Me.dtBiltyDate.Size = New System.Drawing.Size(110, 22)
        Me.dtBiltyDate.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(463, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 22)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Bilty No."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBiltyNo
        '
        Me.txtBiltyNo.Location = New System.Drawing.Point(545, 49)
        Me.txtBiltyNo.MaxLength = 15
        Me.txtBiltyNo.Name = "txtBiltyNo"
        Me.txtBiltyNo.Size = New System.Drawing.Size(110, 22)
        Me.txtBiltyNo.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(9, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 22)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Reference No."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRefNo
        '
        Me.txtRefNo.Location = New System.Drawing.Point(88, 50)
        Me.txtRefNo.MaxLength = 15
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(105, 22)
        Me.txtRefNo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(463, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 22)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Vehicle No."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtVehicleNo
        '
        Me.txtVehicleNo.Location = New System.Drawing.Point(545, 21)
        Me.txtVehicleNo.MaxLength = 15
        Me.txtVehicleNo.Name = "txtVehicleNo"
        Me.txtVehicleNo.Size = New System.Drawing.Size(110, 22)
        Me.txtVehicleNo.TabIndex = 10
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
        Me.dtDate.Size = New System.Drawing.Size(105, 22)
        Me.dtDate.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Gate Pass No."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtGatePassNo
        '
        Me.txtGatePassNo.Location = New System.Drawing.Point(88, 22)
        Me.txtGatePassNo.Name = "txtGatePassNo"
        Me.txtGatePassNo.ReadOnly = True
        Me.txtGatePassNo.Size = New System.Drawing.Size(105, 22)
        Me.txtGatePassNo.TabIndex = 1
        Me.txtGatePassNo.TabStop = False
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
        Me.fraDetail.Location = New System.Drawing.Point(13, 189)
        Me.fraDetail.Name = "fraDetail"
        Me.fraDetail.Size = New System.Drawing.Size(799, 309)
        Me.fraDetail.TabIndex = 2
        Me.fraDetail.TabStop = False
        Me.fraDetail.Text = "Detail"
        '
        'cmdEditItem
        '
        Me.cmdEditItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEditItem.Image = CType(resources.GetObject("cmdEditItem.Image"), System.Drawing.Image)
        Me.cmdEditItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEditItem.Location = New System.Drawing.Point(550, 15)
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
        Me.cmdRemoveItem.Location = New System.Drawing.Point(714, 14)
        Me.cmdRemoveItem.Name = "cmdRemoveItem"
        Me.cmdRemoveItem.Size = New System.Drawing.Size(76, 28)
        Me.cmdRemoveItem.TabIndex = 6
        Me.cmdRemoveItem.Text = "Remove"
        Me.cmdRemoveItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdRemoveItem.UseVisualStyleBackColor = True
        '
        'cmdAddItem
        '
        Me.cmdAddItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAddItem.Image = CType(resources.GetObject("cmdAddItem.Image"), System.Drawing.Image)
        Me.cmdAddItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAddItem.Location = New System.Drawing.Point(632, 14)
        Me.cmdAddItem.Name = "cmdAddItem"
        Me.cmdAddItem.Size = New System.Drawing.Size(76, 28)
        Me.cmdAddItem.TabIndex = 5
        Me.cmdAddItem.Text = "Add"
        Me.cmdAddItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAddItem.UseVisualStyleBackColor = True
        '
        'txtQty
        '
        Me.txtQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQty.Location = New System.Drawing.Point(710, 48)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(80, 22)
        Me.txtQty.TabIndex = 4
        '
        'txtBrand
        '
        Me.txtBrand.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBrand.Location = New System.Drawing.Point(570, 48)
        Me.txtBrand.Name = "txtBrand"
        Me.txtBrand.Size = New System.Drawing.Size(140, 22)
        Me.txtBrand.TabIndex = 3
        '
        'txtUnit
        '
        Me.txtUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUnit.Location = New System.Drawing.Point(490, 48)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.ReadOnly = True
        Me.txtUnit.Size = New System.Drawing.Size(80, 22)
        Me.txtUnit.TabIndex = 2
        Me.txtUnit.TabStop = False
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Location = New System.Drawing.Point(107, 48)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(383, 22)
        Me.txtDescription.TabIndex = 1
        Me.txtDescription.TabStop = False
        '
        'txtItemID
        '
        Me.txtItemID.Location = New System.Drawing.Point(7, 48)
        Me.txtItemID.Name = "txtItemID"
        Me.txtItemID.Size = New System.Drawing.Size(100, 22)
        Me.txtItemID.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Location = New System.Drawing.Point(601, 281)
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
        Me.txtTotal.Location = New System.Drawing.Point(710, 281)
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
        Me.Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItemID, Me.colDescription, Me.colUOM, Me.colBrand, Me.colQty})
        Me.Grid.Location = New System.Drawing.Point(7, 75)
        Me.Grid.Name = "Grid"
        Me.Grid.RowHeadersVisible = False
        Me.Grid.Size = New System.Drawing.Size(786, 202)
        Me.Grid.TabIndex = 8
        '
        'colItemID
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.colItemID.DefaultCellStyle = DataGridViewCellStyle1
        Me.colItemID.HeaderText = "Item Code"
        Me.colItemID.Name = "colItemID"
        Me.colItemID.ReadOnly = True
        '
        'colDescription
        '
        Me.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        Me.colDescription.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDescription.HeaderText = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.ReadOnly = True
        '
        'colUOM
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        Me.colUOM.DefaultCellStyle = DataGridViewCellStyle3
        Me.colUOM.HeaderText = "Unit"
        Me.colUOM.Name = "colUOM"
        Me.colUOM.ReadOnly = True
        Me.colUOM.Width = 80
        '
        'colBrand
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.colBrand.DefaultCellStyle = DataGridViewCellStyle4
        Me.colBrand.HeaderText = "Brand"
        Me.colBrand.Name = "colBrand"
        Me.colBrand.ReadOnly = True
        Me.colBrand.Width = 140
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
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Image = CType(resources.GetObject("cmdPrint.Image"), System.Drawing.Image)
        Me.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPrint.Location = New System.Drawing.Point(819, 369)
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
        Me.cmdClose.Location = New System.Drawing.Point(818, 459)
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
        Me.cmdFind.Location = New System.Drawing.Point(819, 414)
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
        Me.cmdEdit.Location = New System.Drawing.Point(818, 324)
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
        Me.cmdCancel.Location = New System.Drawing.Point(818, 279)
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
        Me.cmdSave.Location = New System.Drawing.Point(819, 234)
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
        Me.cmdAdd.Location = New System.Drawing.Point(819, 189)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(108, 39)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.Text = "New"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'frmInwardGatePass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(938, 510)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.fraDetail)
        Me.Controls.Add(Me.fraGatePass)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInwardGatePass"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inward Gatepass"
        Me.fraGatePass.ResumeLayout(False)
        Me.fraGatePass.PerformLayout()
        Me.fraGoodsRecFrom.ResumeLayout(False)
        Me.fraGoodsRecFrom.PerformLayout()
        Me.fraReturn.ResumeLayout(False)
        Me.fraReturn.PerformLayout()
        Me.fraDetail.ResumeLayout(False)
        Me.fraDetail.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraGatePass As System.Windows.Forms.GroupBox
    Friend WithEvents txtGatePassNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtVehicleNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fraDetail As System.Windows.Forms.GroupBox
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRefNo As System.Windows.Forms.TextBox
    Friend WithEvents fraGoodsRecFrom As System.Windows.Forms.GroupBox
    Friend WithEvents optReturn As System.Windows.Forms.RadioButton
    Friend WithEvents fraReturn As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPickOutGatePass As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtOutGatePassNo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtOutDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents optHeadOffice As System.Windows.Forms.RadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtBiltyDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtBiltyNo As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtGateIncharge As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPersonDelivered As System.Windows.Forms.TextBox
    Friend WithEvents cmdEditItem As System.Windows.Forms.Button
    Friend WithEvents cmdRemoveItem As System.Windows.Forms.Button
    Friend WithEvents cmdAddItem As System.Windows.Forms.Button
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents txtBrand As System.Windows.Forms.TextBox
    Friend WithEvents txtUnit As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtItemID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents colItemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBrand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbStorekeeper As System.Windows.Forms.ComboBox
    Friend WithEvents cmbGM As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
