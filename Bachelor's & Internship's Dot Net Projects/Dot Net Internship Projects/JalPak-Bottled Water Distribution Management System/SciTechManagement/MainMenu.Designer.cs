namespace SciTechManagement
{
    partial class MainMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMultipleItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsSoldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todayToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thisMonthToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thisYearToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsInventoriedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thisMonthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thisYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brandNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateInventoriedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateSoldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventoryDataSet = new SciTechManagement.InventoryDataSet();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchItemCost = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSearchItemInventoried = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSearchItemColor = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSearchItemSize = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbSearchItemName = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSearchBrandName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSearchItemCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearForm = new System.Windows.Forms.Button();
            this.btnAddNewItem = new System.Windows.Forms.Button();
            this.richtxtAddItemDescription = new System.Windows.Forms.RichTextBox();
            this.txtIAddtemCost = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimeAddInventoried = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAddItemColor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtItemSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAddItemName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddBrandName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddItemCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.itemsTableAdapter = new SciTechManagement.InventoryDataSetTableAdapters.ItemsTableAdapter();
            this.lnkbtnLogout = new System.Windows.Forms.LinkLabel();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryDataSet)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.customerListToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(894, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMultipleItemsToolStripMenuItem,
            this.updateItemToolStripMenuItem,
            this.deleteItemToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addMultipleItemsToolStripMenuItem
            // 
            this.addMultipleItemsToolStripMenuItem.Name = "addMultipleItemsToolStripMenuItem";
            this.addMultipleItemsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.addMultipleItemsToolStripMenuItem.Text = "Add Multiple Items";
            // 
            // updateItemToolStripMenuItem
            // 
            this.updateItemToolStripMenuItem.Name = "updateItemToolStripMenuItem";
            this.updateItemToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.updateItemToolStripMenuItem.Text = "Update Item";
            // 
            // deleteItemToolStripMenuItem
            // 
            this.deleteItemToolStripMenuItem.Name = "deleteItemToolStripMenuItem";
            this.deleteItemToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.deleteItemToolStripMenuItem.Text = "Delete Item";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemsSoldToolStripMenuItem,
            this.itemsInventoriedToolStripMenuItem,
            this.allItemsToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // itemsSoldToolStripMenuItem
            // 
            this.itemsSoldToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todayToolStripMenuItem1,
            this.thisMonthToolStripMenuItem1,
            this.thisYearToolStripMenuItem1});
            this.itemsSoldToolStripMenuItem.Name = "itemsSoldToolStripMenuItem";
            this.itemsSoldToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.itemsSoldToolStripMenuItem.Text = "Items Sold";
            // 
            // todayToolStripMenuItem1
            // 
            this.todayToolStripMenuItem1.Name = "todayToolStripMenuItem1";
            this.todayToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.todayToolStripMenuItem1.Text = "Today";
            // 
            // thisMonthToolStripMenuItem1
            // 
            this.thisMonthToolStripMenuItem1.Name = "thisMonthToolStripMenuItem1";
            this.thisMonthToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.thisMonthToolStripMenuItem1.Text = "This Month";
            // 
            // thisYearToolStripMenuItem1
            // 
            this.thisYearToolStripMenuItem1.Name = "thisYearToolStripMenuItem1";
            this.thisYearToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.thisYearToolStripMenuItem1.Text = "This Year";
            // 
            // itemsInventoriedToolStripMenuItem
            // 
            this.itemsInventoriedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todayToolStripMenuItem,
            this.thisMonthToolStripMenuItem,
            this.thisYearToolStripMenuItem});
            this.itemsInventoriedToolStripMenuItem.Name = "itemsInventoriedToolStripMenuItem";
            this.itemsInventoriedToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.itemsInventoriedToolStripMenuItem.Text = "Items Inventoried";
            // 
            // todayToolStripMenuItem
            // 
            this.todayToolStripMenuItem.Name = "todayToolStripMenuItem";
            this.todayToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.todayToolStripMenuItem.Text = "Today";
            // 
            // thisMonthToolStripMenuItem
            // 
            this.thisMonthToolStripMenuItem.Name = "thisMonthToolStripMenuItem";
            this.thisMonthToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.thisMonthToolStripMenuItem.Text = "This Month";
            // 
            // thisYearToolStripMenuItem
            // 
            this.thisYearToolStripMenuItem.Name = "thisYearToolStripMenuItem";
            this.thisYearToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.thisYearToolStripMenuItem.Text = "This Year";
            // 
            // allItemsToolStripMenuItem
            // 
            this.allItemsToolStripMenuItem.Name = "allItemsToolStripMenuItem";
            this.allItemsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.allItemsToolStripMenuItem.Text = "All Items";
            this.allItemsToolStripMenuItem.Click += new System.EventHandler(this.allItemsToolStripMenuItem_Click);
            // 
            // customerListToolStripMenuItem
            // 
            this.customerListToolStripMenuItem.Name = "customerListToolStripMenuItem";
            this.customerListToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.customerListToolStripMenuItem.Text = "Customer List";
            this.customerListToolStripMenuItem.Click += new System.EventHandler(this.customerListToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 584);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.brandNameDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.sizeDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.dateInventoriedDataGridViewTextBoxColumn,
            this.dateSoldDataGridViewTextBoxColumn,
            this.costDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.itemsBindingSource;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView2.Location = new System.Drawing.Point(0, 351);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(870, 233);
            this.dataGridView2.TabIndex = 2;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            // 
            // brandNameDataGridViewTextBoxColumn
            // 
            this.brandNameDataGridViewTextBoxColumn.DataPropertyName = "BrandName";
            this.brandNameDataGridViewTextBoxColumn.HeaderText = "BrandName";
            this.brandNameDataGridViewTextBoxColumn.Name = "brandNameDataGridViewTextBoxColumn";
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            // 
            // sizeDataGridViewTextBoxColumn
            // 
            this.sizeDataGridViewTextBoxColumn.DataPropertyName = "Size";
            this.sizeDataGridViewTextBoxColumn.HeaderText = "Size";
            this.sizeDataGridViewTextBoxColumn.Name = "sizeDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // dateInventoriedDataGridViewTextBoxColumn
            // 
            this.dateInventoriedDataGridViewTextBoxColumn.DataPropertyName = "DateInventoried";
            this.dateInventoriedDataGridViewTextBoxColumn.HeaderText = "DateInventoried";
            this.dateInventoriedDataGridViewTextBoxColumn.Name = "dateInventoriedDataGridViewTextBoxColumn";
            // 
            // dateSoldDataGridViewTextBoxColumn
            // 
            this.dateSoldDataGridViewTextBoxColumn.DataPropertyName = "DateSold";
            this.dateSoldDataGridViewTextBoxColumn.HeaderText = "DateSold";
            this.dateSoldDataGridViewTextBoxColumn.Name = "dateSoldDataGridViewTextBoxColumn";
            // 
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            this.costDataGridViewTextBoxColumn.HeaderText = "Cost";
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataMember = "Items";
            this.itemsBindingSource.DataSource = this.inventoryDataSet;
            // 
            // inventoryDataSet
            // 
            this.inventoryDataSet.DataSetName = "InventoryDataSet";
            this.inventoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClearSearch);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.txtSearchItemCost);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtSearchItemInventoried);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtSearchItemColor);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtSearchItemSize);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cmbSearchItemName);
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
            // btnClearSearch
            // 
            this.btnClearSearch.Location = new System.Drawing.Point(84, 274);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(95, 35);
            this.btnClearSearch.TabIndex = 15;
            this.btnClearSearch.Text = "Clear Search";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(185, 274);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 35);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearchItemCost
            // 
            this.txtSearchItemCost.Location = new System.Drawing.Point(121, 180);
            this.txtSearchItemCost.Name = "txtSearchItemCost";
            this.txtSearchItemCost.Size = new System.Drawing.Size(145, 20);
            this.txtSearchItemCost.TabIndex = 13;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 183);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "Cost:";
            // 
            // txtSearchItemInventoried
            // 
            this.txtSearchItemInventoried.Location = new System.Drawing.Point(121, 154);
            this.txtSearchItemInventoried.Name = "txtSearchItemInventoried";
            this.txtSearchItemInventoried.Size = new System.Drawing.Size(145, 20);
            this.txtSearchItemInventoried.TabIndex = 11;
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
            this.txtSearchItemColor.TabIndex = 9;
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
            this.txtSearchItemSize.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Size:";
            // 
            // cmbSearchItemName
            // 
            this.cmbSearchItemName.FormattingEnabled = true;
            this.cmbSearchItemName.Location = new System.Drawing.Point(121, 75);
            this.cmbSearchItemName.Name = "cmbSearchItemName";
            this.cmbSearchItemName.Size = new System.Drawing.Size(145, 21);
            this.cmbSearchItemName.TabIndex = 5;
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
            this.txtSearchBrandName.TabIndex = 3;
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
            this.groupBox1.Controls.Add(this.btnClearForm);
            this.groupBox1.Controls.Add(this.btnAddNewItem);
            this.groupBox1.Controls.Add(this.richtxtAddItemDescription);
            this.groupBox1.Controls.Add(this.txtIAddtemCost);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dateTimeAddInventoried);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtAddItemColor);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtItemSize);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbAddItemName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAddBrandName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtAddItemCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 323);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add New Item";
            // 
            // btnClearForm
            // 
            this.btnClearForm.Location = new System.Drawing.Point(301, 274);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(95, 35);
            this.btnClearForm.TabIndex = 18;
            this.btnClearForm.Text = "Clear Form";
            this.btnClearForm.UseVisualStyleBackColor = true;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // btnAddNewItem
            // 
            this.btnAddNewItem.Location = new System.Drawing.Point(402, 274);
            this.btnAddNewItem.Name = "btnAddNewItem";
            this.btnAddNewItem.Size = new System.Drawing.Size(95, 35);
            this.btnAddNewItem.TabIndex = 17;
            this.btnAddNewItem.Text = "Add Item";
            this.btnAddNewItem.UseVisualStyleBackColor = true;
            this.btnAddNewItem.Click += new System.EventHandler(this.btnAddNewItem_Click);
            // 
            // richtxtAddItemDescription
            // 
            this.richtxtAddItemDescription.Location = new System.Drawing.Point(20, 148);
            this.richtxtAddItemDescription.Name = "richtxtAddItemDescription";
            this.richtxtAddItemDescription.Size = new System.Drawing.Size(478, 120);
            this.richtxtAddItemDescription.TabIndex = 16;
            this.richtxtAddItemDescription.Text = "";
            // 
            // txtIAddtemCost
            // 
            this.txtIAddtemCost.Location = new System.Drawing.Point(353, 79);
            this.txtIAddtemCost.Name = "txtIAddtemCost";
            this.txtIAddtemCost.Size = new System.Drawing.Size(145, 20);
            this.txtIAddtemCost.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(252, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Cost:";
            // 
            // dateTimeAddInventoried
            // 
            this.dateTimeAddInventoried.CustomFormat = "mm/dd/yyyy";
            this.dateTimeAddInventoried.Location = new System.Drawing.Point(353, 54);
            this.dateTimeAddInventoried.Name = "dateTimeAddInventoried";
            this.dateTimeAddInventoried.Size = new System.Drawing.Size(145, 20);
            this.dateTimeAddInventoried.TabIndex = 13;
            this.dateTimeAddInventoried.Value = new System.DateTime(2014, 10, 1, 11, 38, 51, 0);
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
            this.txtAddItemColor.TabIndex = 10;
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
            // txtItemSize
            // 
            this.txtItemSize.Location = new System.Drawing.Point(80, 102);
            this.txtItemSize.Name = "txtItemSize";
            this.txtItemSize.Size = new System.Drawing.Size(111, 20);
            this.txtItemSize.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Size:";
            // 
            // cmbAddItemName
            // 
            this.cmbAddItemName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAddItemName.FormattingEnabled = true;
            this.cmbAddItemName.Location = new System.Drawing.Point(80, 76);
            this.cmbAddItemName.Name = "cmbAddItemName";
            this.cmbAddItemName.Size = new System.Drawing.Size(145, 21);
            this.cmbAddItemName.TabIndex = 5;
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
            this.txtAddBrandName.TabIndex = 3;
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
            // txtAddItemCode
            // 
            this.txtAddItemCode.Location = new System.Drawing.Point(80, 26);
            this.txtAddItemCode.Name = "txtAddItemCode";
            this.txtAddItemCode.Size = new System.Drawing.Size(145, 20);
            this.txtAddItemCode.TabIndex = 1;
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
            // lnkbtnLogout
            // 
            this.lnkbtnLogout.AutoSize = true;
            this.lnkbtnLogout.Location = new System.Drawing.Point(820, 11);
            this.lnkbtnLogout.Name = "lnkbtnLogout";
            this.lnkbtnLogout.Size = new System.Drawing.Size(40, 13);
            this.lnkbtnLogout.TabIndex = 2;
            this.lnkbtnLogout.TabStop = true;
            this.lnkbtnLogout.Text = "Logout";
            this.lnkbtnLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkbtnLogout_LinkClicked);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 639);
            this.Controls.Add(this.lnkbtnLogout);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryDataSet)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMultipleItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsSoldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsInventoriedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thisMonthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thisYearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allItemsToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.DateTimePicker dateTimeAddInventoried;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAddItemColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtItemSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbAddItemName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddBrandName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddItemCode;
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
        private System.Windows.Forms.ComboBox cmbSearchItemName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSearchBrandName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSearchItemCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dataGridView2;
        private InventoryDataSet inventoryDataSet;
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private InventoryDataSetTableAdapters.ItemsTableAdapter itemsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn brandNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateInventoriedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateSoldDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtSearchItemInventoried;
        private System.Windows.Forms.ToolStripMenuItem customerListToolStripMenuItem;
        private System.Windows.Forms.LinkLabel lnkbtnLogout;
        private System.Windows.Forms.ToolStripMenuItem todayToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem thisMonthToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem thisYearToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

