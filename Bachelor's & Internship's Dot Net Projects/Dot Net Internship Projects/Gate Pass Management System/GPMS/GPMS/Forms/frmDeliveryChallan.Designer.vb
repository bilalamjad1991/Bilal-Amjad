<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeliveryChallan
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDeliveryChallan))
        Me.fraDeliveryChallan = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtVehicleNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtDeliveryDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDCNo = New System.Windows.Forms.TextBox()
        Me.fraDetail = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdLoadIndent = New System.Windows.Forms.Button()
        Me.txtIndentNo = New System.Windows.Forms.TextBox()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.colIndentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUOM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBrand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdFind = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.fraDeliveryChallan.SuspendLayout()
        Me.fraDetail.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraDeliveryChallan
        '
        Me.fraDeliveryChallan.Controls.Add(Me.Label3)
        Me.fraDeliveryChallan.Controls.Add(Me.txtVehicleNo)
        Me.fraDeliveryChallan.Controls.Add(Me.Label2)
        Me.fraDeliveryChallan.Controls.Add(Me.dtDeliveryDate)
        Me.fraDeliveryChallan.Controls.Add(Me.Label1)
        Me.fraDeliveryChallan.Controls.Add(Me.txtDCNo)
        Me.fraDeliveryChallan.Location = New System.Drawing.Point(13, 13)
        Me.fraDeliveryChallan.Name = "fraDeliveryChallan"
        Me.fraDeliveryChallan.Size = New System.Drawing.Size(913, 56)
        Me.fraDeliveryChallan.TabIndex = 1
        Me.fraDeliveryChallan.TabStop = False
        Me.fraDeliveryChallan.Text = "Delivery Challan"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(659, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 22)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Vehicle No."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtVehicleNo
        '
        Me.txtVehicleNo.Location = New System.Drawing.Point(768, 21)
        Me.txtVehicleNo.Name = "txtVehicleNo"
        Me.txtVehicleNo.Size = New System.Drawing.Size(134, 22)
        Me.txtVehicleNo.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(314, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 22)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Delivery Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtDeliveryDate
        '
        Me.dtDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDeliveryDate.Location = New System.Drawing.Point(423, 22)
        Me.dtDeliveryDate.Name = "dtDeliveryDate"
        Me.dtDeliveryDate.Size = New System.Drawing.Size(116, 22)
        Me.dtDeliveryDate.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(27, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "D.C. No."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDCNo
        '
        Me.txtDCNo.Location = New System.Drawing.Point(136, 22)
        Me.txtDCNo.Name = "txtDCNo"
        Me.txtDCNo.ReadOnly = True
        Me.txtDCNo.Size = New System.Drawing.Size(134, 22)
        Me.txtDCNo.TabIndex = 1
        Me.txtDCNo.TabStop = False
        '
        'fraDetail
        '
        Me.fraDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraDetail.Controls.Add(Me.Label5)
        Me.fraDetail.Controls.Add(Me.txtTotal)
        Me.fraDetail.Controls.Add(Me.Label4)
        Me.fraDetail.Controls.Add(Me.cmdLoadIndent)
        Me.fraDetail.Controls.Add(Me.txtIndentNo)
        Me.fraDetail.Controls.Add(Me.Grid)
        Me.fraDetail.Location = New System.Drawing.Point(13, 76)
        Me.fraDetail.Name = "fraDetail"
        Me.fraDetail.Size = New System.Drawing.Size(799, 380)
        Me.fraDetail.TabIndex = 2
        Me.fraDetail.TabStop = False
        Me.fraDetail.Text = "Detail"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Location = New System.Drawing.Point(550, 352)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 22)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Total Amount"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(659, 352)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(134, 22)
        Me.txtTotal.TabIndex = 5
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(119, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 22)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Indent No."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdLoadIndent
        '
        Me.cmdLoadIndent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLoadIndent.Location = New System.Drawing.Point(7, 21)
        Me.cmdLoadIndent.Name = "cmdLoadIndent"
        Me.cmdLoadIndent.Size = New System.Drawing.Size(108, 29)
        Me.cmdLoadIndent.TabIndex = 0
        Me.cmdLoadIndent.Text = "Load Indent"
        Me.cmdLoadIndent.UseVisualStyleBackColor = True
        '
        'txtIndentNo
        '
        Me.txtIndentNo.Location = New System.Drawing.Point(228, 26)
        Me.txtIndentNo.Name = "txtIndentNo"
        Me.txtIndentNo.ReadOnly = True
        Me.txtIndentNo.Size = New System.Drawing.Size(134, 22)
        Me.txtIndentNo.TabIndex = 2
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIndentNo, Me.colItemID, Me.colDescription, Me.colUOM, Me.colBrand, Me.colQty, Me.colUnitRate, Me.colAmount})
        Me.Grid.Location = New System.Drawing.Point(7, 56)
        Me.Grid.Name = "Grid"
        Me.Grid.RowHeadersVisible = False
        Me.Grid.Size = New System.Drawing.Size(786, 292)
        Me.Grid.TabIndex = 3
        '
        'colIndentNo
        '
        Me.colIndentNo.HeaderText = "IndentNo"
        Me.colIndentNo.Name = "colIndentNo"
        Me.colIndentNo.ReadOnly = True
        Me.colIndentNo.Visible = False
        '
        'colItemID
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.colItemID.DefaultCellStyle = DataGridViewCellStyle1
        Me.colItemID.HeaderText = "Item Code"
        Me.colItemID.Name = "colItemID"
        Me.colItemID.ReadOnly = True
        '
        'colDescription
        '
        Me.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        Me.colDescription.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDescription.HeaderText = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.ReadOnly = True
        '
        'colUOM
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
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
        '
        'colQty
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colQty.DefaultCellStyle = DataGridViewCellStyle5
        Me.colQty.HeaderText = "Quantity"
        Me.colQty.Name = "colQty"
        Me.colQty.Width = 80
        '
        'colUnitRate
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colUnitRate.DefaultCellStyle = DataGridViewCellStyle6
        Me.colUnitRate.HeaderText = "UnitRate"
        Me.colUnitRate.Name = "colUnitRate"
        Me.colUnitRate.Width = 80
        '
        'colAmount
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle7
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Image = CType(resources.GetObject("cmdPrint.Image"), System.Drawing.Image)
        Me.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPrint.Location = New System.Drawing.Point(819, 327)
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
        Me.cmdClose.Location = New System.Drawing.Point(818, 417)
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
        Me.cmdFind.Location = New System.Drawing.Point(819, 372)
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
        Me.cmdEdit.Location = New System.Drawing.Point(818, 282)
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
        Me.cmdCancel.Location = New System.Drawing.Point(818, 237)
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
        Me.cmdSave.Location = New System.Drawing.Point(819, 192)
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
        Me.cmdAdd.Location = New System.Drawing.Point(819, 147)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(108, 39)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.Text = "New"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'frmDeliveryChallan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(938, 468)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.fraDetail)
        Me.Controls.Add(Me.fraDeliveryChallan)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmDeliveryChallan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delivery Challan"
        Me.fraDeliveryChallan.ResumeLayout(False)
        Me.fraDeliveryChallan.PerformLayout()
        Me.fraDetail.ResumeLayout(False)
        Me.fraDetail.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraDeliveryChallan As System.Windows.Forms.GroupBox
    Friend WithEvents txtDCNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtVehicleNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtDeliveryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fraDetail As System.Windows.Forms.GroupBox
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdLoadIndent As System.Windows.Forms.Button
    Friend WithEvents txtIndentNo As System.Windows.Forms.TextBox
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents colIndentNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBrand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
End Class
