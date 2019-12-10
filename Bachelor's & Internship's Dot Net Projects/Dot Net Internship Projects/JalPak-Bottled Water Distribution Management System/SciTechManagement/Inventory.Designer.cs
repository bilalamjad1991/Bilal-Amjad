namespace SciTechManagement
{
    partial class Inventory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateInventoried = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventoryDataSet3 = new SciTechManagement.InventoryDataSet3();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtSearchItemInventoried = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnUpdateItem = new System.Windows.Forms.Button();
            this.cmbSearchItemName = new System.Windows.Forms.TextBox();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchItemCost = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSearchItemColor = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSearchItemSize = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSearchBrandName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSearchItemCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimeAddInventoried = new System.Windows.Forms.DateTimePicker();
            this.txtAddItemCodee = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmbAddItemName = new System.Windows.Forms.TextBox();
            this.btnClearForm = new System.Windows.Forms.Button();
            this.btnAddNewItem = new System.Windows.Forms.Button();
            this.richtxtAddItemDescription = new System.Windows.Forms.RichTextBox();
            this.txtIAddtemCost = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAddItemColor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtItemQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddBrandName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.itemsTableAdapter = new SciTechManagement.InventoryDataSet3TableAdapters.ItemsTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryDataSet3)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 606);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.BrandName,
            this.ItemName,
            this.Quantity,
            this.Description,
            this.DateInventoried,
            this.Cost,
            this.Color});
            this.dataGridView2.DataSource = this.itemsBindingSource;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView2.Location = new System.Drawing.Point(0, 351);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(870, 255);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.TabStop = false;
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Width = 95;
            // 
            // BrandName
            // 
            this.BrandName.DataPropertyName = "BrandName";
            this.BrandName.HeaderText = "BrandName";
            this.BrandName.Name = "BrandName";
            this.BrandName.ReadOnly = true;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "ItemName";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 125;
            // 
            // DateInventoried
            // 
            this.DateInventoried.DataPropertyName = "DateInventoried";
            this.DateInventoried.HeaderText = "DateInventoried";
            this.DateInventoried.Name = "DateInventoried";
            this.DateInventoried.ReadOnly = true;
            // 
            // Cost
            // 
            this.Cost.DataPropertyName = "Cost";
            this.Cost.HeaderText = "Purchase Price";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            // 
            // Color
            // 
            this.Color.DataPropertyName = "Color";
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            this.Color.ReadOnly = true;
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataMember = "Items";
            this.itemsBindingSource.DataSource = this.inventoryDataSet3;
            // 
            // inventoryDataSet3
            // 
            this.inventoryDataSet3.DataSetName = "InventoryDataSet3";
            this.inventoryDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.txtSearchItemInventoried);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.btnUpdateItem);
            this.groupBox2.Controls.Add(this.cmbSearchItemName);
            this.groupBox2.Controls.Add(this.btnClearSearch);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.txtSearchItemCost);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtSearchItemColor);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtSearchItemSize);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtSearchBrandName);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtSearchItemCode);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(546, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 323);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search for Items";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(119, 177);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(150, 13);
            this.label20.TabIndex = 17;
            this.label20.Text = "Format : MM   /  DD  /   YYYY";
            // 
            // txtSearchItemInventoried
            // 
            this.txtSearchItemInventoried.Location = new System.Drawing.Point(121, 154);
            this.txtSearchItemInventoried.Name = "txtSearchItemInventoried";
            this.txtSearchItemInventoried.Size = new System.Drawing.Size(145, 20);
            this.txtSearchItemInventoried.TabIndex = 16;
            this.txtSearchItemInventoried.Leave += new System.EventHandler(this.txtSearchItemInventoried_Leave);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(121, 221);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(145, 20);
            this.txtDescription.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(22, 221);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "Description:";
            // 
            // btnUpdateItem
            // 
            this.btnUpdateItem.Location = new System.Drawing.Point(6, 274);
            this.btnUpdateItem.Name = "btnUpdateItem";
            this.btnUpdateItem.Size = new System.Drawing.Size(92, 35);
            this.btnUpdateItem.TabIndex = 11;
            this.btnUpdateItem.Text = "Update Item";
            this.btnUpdateItem.UseVisualStyleBackColor = true;
            this.btnUpdateItem.Click += new System.EventHandler(this.btnUpdateItem_Click);
            // 
            // cmbSearchItemName
            // 
            this.cmbSearchItemName.Location = new System.Drawing.Point(121, 75);
            this.cmbSearchItemName.Name = "cmbSearchItemName";
            this.cmbSearchItemName.Size = new System.Drawing.Size(145, 20);
            this.cmbSearchItemName.TabIndex = 3;
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Location = new System.Drawing.Point(104, 274);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(92, 35);
            this.btnClearSearch.TabIndex = 10;
            this.btnClearSearch.Text = "Clear Search";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(201, 274);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 35);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchItemCost
            // 
            this.txtSearchItemCost.Location = new System.Drawing.Point(121, 193);
            this.txtSearchItemCost.MaxLength = 7;
            this.txtSearchItemCost.Name = "txtSearchItemCost";
            this.txtSearchItemCost.Size = new System.Drawing.Size(145, 20);
            this.txtSearchItemCost.TabIndex = 7;
            this.txtSearchItemCost.TextChanged += new System.EventHandler(this.txtSearchItemCost_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 196);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "Purchase Price:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 157);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Date Inventoried:";
            // 
            // txtSearchItemColor
            // 
            this.txtSearchItemColor.Location = new System.Drawing.Point(121, 128);
            this.txtSearchItemColor.Name = "txtSearchItemColor";
            this.txtSearchItemColor.Size = new System.Drawing.Size(145, 20);
            this.txtSearchItemColor.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 134);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Color:";
            // 
            // txtSearchItemSize
            // 
            this.txtSearchItemSize.Location = new System.Drawing.Point(121, 102);
            this.txtSearchItemSize.Name = "txtSearchItemSize";
            this.txtSearchItemSize.Size = new System.Drawing.Size(145, 20);
            this.txtSearchItemSize.TabIndex = 4;
            this.txtSearchItemSize.TextChanged += new System.EventHandler(this.txtSearchItemSize_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Quantity:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Item Name:";
            // 
            // txtSearchBrandName
            // 
            this.txtSearchBrandName.Location = new System.Drawing.Point(121, 51);
            this.txtSearchBrandName.Name = "txtSearchBrandName";
            this.txtSearchBrandName.Size = new System.Drawing.Size(145, 20);
            this.txtSearchBrandName.TabIndex = 2;
            this.txtSearchBrandName.TextChanged += new System.EventHandler(this.txtSearchBrandName_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Brand Name:";
            // 
            // txtSearchItemCode
            // 
            this.txtSearchItemCode.Location = new System.Drawing.Point(121, 26);
            this.txtSearchItemCode.Name = "txtSearchItemCode";
            this.txtSearchItemCode.Size = new System.Drawing.Size(145, 20);
            this.txtSearchItemCode.TabIndex = 1;
            this.txtSearchItemCode.TextChanged += new System.EventHandler(this.txtSearchItemCode_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Code:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimeAddInventoried);
            this.groupBox1.Controls.Add(this.txtAddItemCodee);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.cmbAddItemName);
            this.groupBox1.Controls.Add(this.btnClearForm);
            this.groupBox1.Controls.Add(this.btnAddNewItem);
            this.groupBox1.Controls.Add(this.richtxtAddItemDescription);
            this.groupBox1.Controls.Add(this.txtIAddtemCost);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtAddItemColor);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtItemQuantity);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAddBrandName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 323);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add New Item";
            // 
            // dateTimeAddInventoried
            // 
            this.dateTimeAddInventoried.CustomFormat = "mm/dd/yyyy";
            this.dateTimeAddInventoried.Location = new System.Drawing.Point(353, 52);
            this.dateTimeAddInventoried.Name = "dateTimeAddInventoried";
            this.dateTimeAddInventoried.Size = new System.Drawing.Size(145, 20);
            this.dateTimeAddInventoried.TabIndex = 6;
            // 
            // txtAddItemCodee
            // 
            this.txtAddItemCodee.AutoSize = true;
            this.txtAddItemCodee.Location = new System.Drawing.Point(77, 29);
            this.txtAddItemCodee.Name = "txtAddItemCodee";
            this.txtAddItemCodee.Size = new System.Drawing.Size(0, 13);
            this.txtAddItemCodee.TabIndex = 3;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(499, 82);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(11, 13);
            this.label22.TabIndex = 33;
            this.label22.Text = "*";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(499, 58);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(11, 13);
            this.label21.TabIndex = 33;
            this.label21.Text = "*";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(231, 105);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(11, 13);
            this.label19.TabIndex = 33;
            this.label19.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(231, 79);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(11, 13);
            this.label18.TabIndex = 33;
            this.label18.Text = "*";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(231, 54);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(11, 13);
            this.label17.TabIndex = 33;
            this.label17.Text = "*";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(200, 274);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 35);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmbAddItemName
            // 
            this.cmbAddItemName.Location = new System.Drawing.Point(80, 76);
            this.cmbAddItemName.Name = "cmbAddItemName";
            this.cmbAddItemName.Size = new System.Drawing.Size(145, 20);
            this.cmbAddItemName.TabIndex = 3;
            // 
            // btnClearForm
            // 
            this.btnClearForm.Location = new System.Drawing.Point(301, 274);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(95, 35);
            this.btnClearForm.TabIndex = 10;
            this.btnClearForm.Text = "Clear";
            this.btnClearForm.UseVisualStyleBackColor = true;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // btnAddNewItem
            // 
            this.btnAddNewItem.Location = new System.Drawing.Point(402, 274);
            this.btnAddNewItem.Name = "btnAddNewItem";
            this.btnAddNewItem.Size = new System.Drawing.Size(95, 35);
            this.btnAddNewItem.TabIndex = 9;
            this.btnAddNewItem.Text = "Add Item";
            this.btnAddNewItem.UseVisualStyleBackColor = true;
            this.btnAddNewItem.Click += new System.EventHandler(this.btnAddNewItem_Click);
            // 
            // richtxtAddItemDescription
            // 
            this.richtxtAddItemDescription.Location = new System.Drawing.Point(20, 148);
            this.richtxtAddItemDescription.Name = "richtxtAddItemDescription";
            this.richtxtAddItemDescription.Size = new System.Drawing.Size(478, 120);
            this.richtxtAddItemDescription.TabIndex = 8;
            this.richtxtAddItemDescription.Text = "";
            // 
            // txtIAddtemCost
            // 
            this.txtIAddtemCost.Location = new System.Drawing.Point(353, 79);
            this.txtIAddtemCost.Name = "txtIAddtemCost";
            this.txtIAddtemCost.Size = new System.Drawing.Size(145, 20);
            this.txtIAddtemCost.TabIndex = 7;
            this.txtIAddtemCost.TextChanged += new System.EventHandler(this.txtIAddtemCost_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(252, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Purchase Price:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(252, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Date Inventoried:";
            // 
            // txtAddItemColor
            // 
            this.txtAddItemColor.Location = new System.Drawing.Point(353, 26);
            this.txtAddItemColor.Name = "txtAddItemColor";
            this.txtAddItemColor.Size = new System.Drawing.Size(145, 20);
            this.txtAddItemColor.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(252, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Color:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Description:";
            // 
            // txtItemQuantity
            // 
            this.txtItemQuantity.Location = new System.Drawing.Point(80, 102);
            this.txtItemQuantity.MaxLength = 7;
            this.txtItemQuantity.Name = "txtItemQuantity";
            this.txtItemQuantity.Size = new System.Drawing.Size(145, 20);
            this.txtItemQuantity.TabIndex = 4;
            this.txtItemQuantity.TextChanged += new System.EventHandler(this.txtItemQuantity_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Quantity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Item Name:";
            // 
            // txtAddBrandName
            // 
            this.txtAddBrandName.Location = new System.Drawing.Point(80, 51);
            this.txtAddBrandName.Name = "txtAddBrandName";
            this.txtAddBrandName.Size = new System.Drawing.Size(145, 20);
            this.txtAddBrandName.TabIndex = 2;
            this.txtAddBrandName.TextChanged += new System.EventHandler(this.txtAddBrandName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Brand Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code: ";
            // 
            // itemsTableAdapter
            // 
            this.itemsTableAdapter.ClearBeforeFill = true;
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(897, 629);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Inventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryDataSet3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAddItemColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtItemQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddBrandName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClearForm;
        private System.Windows.Forms.Button btnAddNewItem;
        private System.Windows.Forms.RichTextBox richtxtAddItemDescription;
        private System.Windows.Forms.TextBox txtIAddtemCost;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSearchItemCost;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSearchItemColor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSearchItemSize;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSearchBrandName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSearchItemCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox cmbAddItemName;
        private System.Windows.Forms.TextBox cmbSearchItemName;
        private System.Windows.Forms.Button btnUpdateItem;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label16;
        private InventoryDataSet3 inventoryDataSet3;
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private InventoryDataSet3TableAdapters.ItemsTableAdapter itemsTableAdapter;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateInventoried;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.Label txtAddItemCodee;
        private System.Windows.Forms.TextBox txtSearchItemInventoried;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker dateTimeAddInventoried;
    }
}

