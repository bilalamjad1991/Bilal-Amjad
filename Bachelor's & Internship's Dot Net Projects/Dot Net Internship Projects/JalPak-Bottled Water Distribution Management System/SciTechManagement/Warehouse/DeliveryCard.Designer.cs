namespace SciTechManagement.Warehouse
{
    partial class DeliveryCard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryCard));
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRatePerBottle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCustomerContactNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustomerAddress = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bottles_Delivered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bottle_Received = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance_Bottles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount_Received = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Signature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBottlesDelivered = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBottleReceived = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBalanceBottles = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAmountReceived = new System.Windows.Forms.TextBox();
            this.cmbCustomerName = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBalanceAmount = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.deliveryListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer No:";
            // 
            // txtCustomerNo
            // 
            this.txtCustomerNo.Location = new System.Drawing.Point(163, 42);
            this.txtCustomerNo.Name = "txtCustomerNo";
            this.txtCustomerNo.ReadOnly = true;
            this.txtCustomerNo.Size = new System.Drawing.Size(127, 20);
            this.txtCustomerNo.TabIndex = 0;
            this.txtCustomerNo.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(530, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(618, 43);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(127, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.TabStop = false;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(530, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rate Per Bottle:";
            // 
            // txtRatePerBottle
            // 
            this.txtRatePerBottle.Enabled = false;
            this.txtRatePerBottle.Location = new System.Drawing.Point(618, 86);
            this.txtRatePerBottle.Name = "txtRatePerBottle";
            this.txtRatePerBottle.Size = new System.Drawing.Size(127, 20);
            this.txtRatePerBottle.TabIndex = 2;
            this.txtRatePerBottle.TextChanged += new System.EventHandler(this.txtRatePerBottle_TextChanged);
            this.txtRatePerBottle.Leave += new System.EventHandler(this.txtRatePerBottle_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Customer Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(530, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Contact No:";
            // 
            // txtCustomerContactNo
            // 
            this.txtCustomerContactNo.Location = new System.Drawing.Point(618, 126);
            this.txtCustomerContactNo.Name = "txtCustomerContactNo";
            this.txtCustomerContactNo.ReadOnly = true;
            this.txtCustomerContactNo.Size = new System.Drawing.Size(127, 20);
            this.txtCustomerContactNo.TabIndex = 1;
            this.txtCustomerContactNo.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Address:";
            // 
            // txtCustomerAddress
            // 
            this.txtCustomerAddress.Location = new System.Drawing.Point(163, 161);
            this.txtCustomerAddress.Multiline = true;
            this.txtCustomerAddress.Name = "txtCustomerAddress";
            this.txtCustomerAddress.ReadOnly = true;
            this.txtCustomerAddress.Size = new System.Drawing.Size(582, 56);
            this.txtCustomerAddress.TabIndex = 11;
            this.txtCustomerAddress.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Bottles_Delivered,
            this.Bottle_Received,
            this.Balance_Bottles,
            this.Amount,
            this.Amount_Received,
            this.Balance_Amount,
            this.Signature});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Size = new System.Drawing.Size(843, 302);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.TabStop = false;
            // 
            // Date
            // 
            dataGridViewCellStyle3.NullValue = null;
            this.Date.DefaultCellStyle = dataGridViewCellStyle3;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Bottles_Delivered
            // 
            this.Bottles_Delivered.HeaderText = "Bottles Delivered";
            this.Bottles_Delivered.Name = "Bottles_Delivered";
            this.Bottles_Delivered.ReadOnly = true;
            // 
            // Bottle_Received
            // 
            this.Bottle_Received.HeaderText = "Bottle Received";
            this.Bottle_Received.Name = "Bottle_Received";
            this.Bottle_Received.ReadOnly = true;
            // 
            // Balance_Bottles
            // 
            this.Balance_Bottles.HeaderText = "Balance Bottles";
            this.Balance_Bottles.Name = "Balance_Bottles";
            this.Balance_Bottles.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // Amount_Received
            // 
            this.Amount_Received.HeaderText = "Amount Received";
            this.Amount_Received.Name = "Amount_Received";
            this.Amount_Received.ReadOnly = true;
            // 
            // Balance_Amount
            // 
            this.Balance_Amount.HeaderText = "Balance Amount";
            this.Balance_Amount.Name = "Balance_Amount";
            this.Balance_Amount.ReadOnly = true;
            // 
            // Signature
            // 
            this.Signature.HeaderText = "Signature";
            this.Signature.Name = "Signature";
            this.Signature.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 326);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 302);
            this.panel1.TabIndex = 13;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(653, 290);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 30);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(68, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Bottles Delivered:";
            // 
            // txtBottlesDelivered
            // 
            this.txtBottlesDelivered.Location = new System.Drawing.Point(163, 230);
            this.txtBottlesDelivered.Name = "txtBottlesDelivered";
            this.txtBottlesDelivered.Size = new System.Drawing.Size(127, 20);
            this.txtBottlesDelivered.TabIndex = 3;
            this.txtBottlesDelivered.TextChanged += new System.EventHandler(this.txtBottlesDelivered_TextChanged);
            this.txtBottlesDelivered.Leave += new System.EventHandler(this.txtBottlesDelivered_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(302, 233);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Bottles Received:";
            // 
            // txtBottleReceived
            // 
            this.txtBottleReceived.Location = new System.Drawing.Point(393, 230);
            this.txtBottleReceived.Name = "txtBottleReceived";
            this.txtBottleReceived.Size = new System.Drawing.Size(127, 20);
            this.txtBottleReceived.TabIndex = 4;
            this.txtBottleReceived.TextChanged += new System.EventHandler(this.txtBottleReceived_TextChanged);
            this.txtBottleReceived.Leave += new System.EventHandler(this.txtBottleReceived_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(68, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Balance Bottles:";
            // 
            // txtBalanceBottles
            // 
            this.txtBalanceBottles.Location = new System.Drawing.Point(163, 265);
            this.txtBalanceBottles.Name = "txtBalanceBottles";
            this.txtBalanceBottles.ReadOnly = true;
            this.txtBalanceBottles.Size = new System.Drawing.Size(127, 20);
            this.txtBalanceBottles.TabIndex = 6;
            this.txtBalanceBottles.TextChanged += new System.EventHandler(this.txtBalanceBottles_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(302, 268);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Amount:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(393, 265);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(127, 20);
            this.txtAmount.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(525, 233);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Amount Received:";
            // 
            // txtAmountReceived
            // 
            this.txtAmountReceived.Location = new System.Drawing.Point(620, 230);
            this.txtAmountReceived.Name = "txtAmountReceived";
            this.txtAmountReceived.Size = new System.Drawing.Size(127, 20);
            this.txtAmountReceived.TabIndex = 5;
            this.txtAmountReceived.TextChanged += new System.EventHandler(this.txtAmountReceived_TextChanged);
            this.txtAmountReceived.Leave += new System.EventHandler(this.txtAmountReceived_Leave);
            // 
            // cmbCustomerName
            // 
            this.cmbCustomerName.FormattingEnabled = true;
            this.cmbCustomerName.Location = new System.Drawing.Point(163, 86);
            this.cmbCustomerName.Name = "cmbCustomerName";
            this.cmbCustomerName.Size = new System.Drawing.Size(357, 21);
            this.cmbCustomerName.TabIndex = 0;
            this.cmbCustomerName.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerName_SelectedIndexChanged);
            this.cmbCustomerName.Leave += new System.EventHandler(this.cmbCustomerName_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(530, 268);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Balance Amount:";
            // 
            // txtBalanceAmount
            // 
            this.txtBalanceAmount.Location = new System.Drawing.Point(620, 265);
            this.txtBalanceAmount.Name = "txtBalanceAmount";
            this.txtBalanceAmount.ReadOnly = true;
            this.txtBalanceAmount.Size = new System.Drawing.Size(127, 20);
            this.txtBalanceAmount.TabIndex = 8;
            this.txtBalanceAmount.TextChanged += new System.EventHandler(this.txtBalanceAmount_TextChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(556, 290);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(91, 30);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(68, 126);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Employee:";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(163, 123);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(357, 21);
            this.cmbEmployee.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deliveryListToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(843, 24);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // deliveryListToolStripMenuItem
            // 
            this.deliveryListToolStripMenuItem.Name = "deliveryListToolStripMenuItem";
            this.deliveryListToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.deliveryListToolStripMenuItem.Text = "Delivery List";
            this.deliveryListToolStripMenuItem.Click += new System.EventHandler(this.deliveryListToolStripMenuItem_Click);
            // 
            // DeliveryCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(843, 628);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtBalanceAmount);
            this.Controls.Add(this.cmbCustomerName);
            this.Controls.Add(this.txtAmountReceived);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtBalanceBottles);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBottleReceived);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBottlesDelivered);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtCustomerAddress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCustomerContactNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRatePerBottle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCustomerNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "DeliveryCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delivery Card";
            this.Load += new System.EventHandler(this.DeliveryCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRatePerBottle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCustomerContactNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCustomerAddress;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bottles_Delivered;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bottle_Received;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance_Bottles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount_Received;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Signature;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBottlesDelivered;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBottleReceived;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBalanceBottles;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAmountReceived;
        private System.Windows.Forms.ComboBox cmbCustomerName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBalanceAmount;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deliveryListToolStripMenuItem;
    }
}