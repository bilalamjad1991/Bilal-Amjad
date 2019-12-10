namespace SciTechManagement.PayRoll
{
    partial class BonusAndCommision
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BonusAndCommision));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveCommission = new System.Windows.Forms.Button();
            this.txtRetention = new System.Windows.Forms.TextBox();
            this.txtNewSale = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaveBonus = new System.Windows.Forms.Button();
            this.rdbtnMonthly = new System.Windows.Forms.RadioButton();
            this.rdbtnQuaterly = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbtnBiannually = new System.Windows.Forms.RadioButton();
            this.rdbtnAnnually = new System.Windows.Forms.RadioButton();
            this.cmbBonusRate = new System.Windows.Forms.ComboBox();
            this.cmbBonus = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bonusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bonusTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bonusAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bonusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bonusDataSet = new SciTechManagement.BonusDataSet();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.NewSale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Retention = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commissionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.commissionDataSet = new SciTechManagement.CommissionDataSet();
            this.commissionTableAdapter = new SciTechManagement.CommissionDataSetTableAdapters.CommissionTableAdapter();
            this.bonusTableAdapter = new SciTechManagement.BonusDataSetTableAdapters.BonusTableAdapter();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusDataSet)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commissionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commissionDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveCommission);
            this.groupBox1.Controls.Add(this.txtRetention);
            this.groupBox1.Controls.Add(this.txtNewSale);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 152);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Commission ";
            // 
            // btnSaveCommission
            // 
            this.btnSaveCommission.Location = new System.Drawing.Point(161, 104);
            this.btnSaveCommission.Name = "btnSaveCommission";
            this.btnSaveCommission.Size = new System.Drawing.Size(82, 31);
            this.btnSaveCommission.TabIndex = 8;
            this.btnSaveCommission.Text = "Save";
            this.btnSaveCommission.UseVisualStyleBackColor = true;
            this.btnSaveCommission.Click += new System.EventHandler(this.btnSaveCommission_Click);
            // 
            // txtRetention
            // 
            this.txtRetention.Location = new System.Drawing.Point(86, 72);
            this.txtRetention.Name = "txtRetention";
            this.txtRetention.Size = new System.Drawing.Size(103, 20);
            this.txtRetention.TabIndex = 3;
            this.txtRetention.TextChanged += new System.EventHandler(this.txtRetention_TextChanged);
            // 
            // txtNewSale
            // 
            this.txtNewSale.Location = new System.Drawing.Point(86, 36);
            this.txtNewSale.MaxLength = 9;
            this.txtNewSale.Name = "txtNewSale";
            this.txtNewSale.Size = new System.Drawing.Size(157, 20);
            this.txtNewSale.TabIndex = 2;
            this.txtNewSale.TextChanged += new System.EventHandler(this.txtNewSale_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "% of Sales";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Retention:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "New Customer:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSaveBonus);
            this.groupBox2.Controls.Add(this.rdbtnMonthly);
            this.groupBox2.Controls.Add(this.rdbtnQuaterly);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.rdbtnBiannually);
            this.groupBox2.Controls.Add(this.rdbtnAnnually);
            this.groupBox2.Controls.Add(this.cmbBonusRate);
            this.groupBox2.Controls.Add(this.cmbBonus);
            this.groupBox2.Location = new System.Drawing.Point(295, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(357, 152);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bonus";
            // 
            // btnSaveBonus
            // 
            this.btnSaveBonus.Location = new System.Drawing.Point(253, 104);
            this.btnSaveBonus.Name = "btnSaveBonus";
            this.btnSaveBonus.Size = new System.Drawing.Size(82, 31);
            this.btnSaveBonus.TabIndex = 7;
            this.btnSaveBonus.Text = "Save";
            this.btnSaveBonus.UseVisualStyleBackColor = true;
            this.btnSaveBonus.Click += new System.EventHandler(this.btnSaveBonus_Click);
            // 
            // rdbtnMonthly
            // 
            this.rdbtnMonthly.AutoSize = true;
            this.rdbtnMonthly.Location = new System.Drawing.Point(273, 28);
            this.rdbtnMonthly.Name = "rdbtnMonthly";
            this.rdbtnMonthly.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdbtnMonthly.Size = new System.Drawing.Size(62, 17);
            this.rdbtnMonthly.TabIndex = 4;
            this.rdbtnMonthly.TabStop = true;
            this.rdbtnMonthly.Text = "Monthly";
            this.rdbtnMonthly.UseVisualStyleBackColor = true;
            // 
            // rdbtnQuaterly
            // 
            this.rdbtnQuaterly.AutoSize = true;
            this.rdbtnQuaterly.Location = new System.Drawing.Point(199, 28);
            this.rdbtnQuaterly.Name = "rdbtnQuaterly";
            this.rdbtnQuaterly.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdbtnQuaterly.Size = new System.Drawing.Size(64, 17);
            this.rdbtnQuaterly.TabIndex = 3;
            this.rdbtnQuaterly.TabStop = true;
            this.rdbtnQuaterly.Text = "Quaterly";
            this.rdbtnQuaterly.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X";
            // 
            // rdbtnBiannually
            // 
            this.rdbtnBiannually.AutoSize = true;
            this.rdbtnBiannually.Location = new System.Drawing.Point(106, 28);
            this.rdbtnBiannually.Name = "rdbtnBiannually";
            this.rdbtnBiannually.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdbtnBiannually.Size = new System.Drawing.Size(66, 17);
            this.rdbtnBiannually.TabIndex = 2;
            this.rdbtnBiannually.TabStop = true;
            this.rdbtnBiannually.Text = "Biannual";
            this.rdbtnBiannually.UseVisualStyleBackColor = true;
            // 
            // rdbtnAnnually
            // 
            this.rdbtnAnnually.AutoSize = true;
            this.rdbtnAnnually.Location = new System.Drawing.Point(24, 28);
            this.rdbtnAnnually.Name = "rdbtnAnnually";
            this.rdbtnAnnually.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdbtnAnnually.Size = new System.Drawing.Size(65, 17);
            this.rdbtnAnnually.TabIndex = 1;
            this.rdbtnAnnually.TabStop = true;
            this.rdbtnAnnually.Text = "Annually";
            this.rdbtnAnnually.UseVisualStyleBackColor = true;
            // 
            // cmbBonusRate
            // 
            this.cmbBonusRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBonusRate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbBonusRate.FormattingEnabled = true;
            this.cmbBonusRate.Location = new System.Drawing.Point(199, 68);
            this.cmbBonusRate.Name = "cmbBonusRate";
            this.cmbBonusRate.Size = new System.Drawing.Size(136, 21);
            this.cmbBonusRate.TabIndex = 6;
            // 
            // cmbBonus
            // 
            this.cmbBonus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBonus.FormattingEnabled = true;
            this.cmbBonus.Location = new System.Drawing.Point(24, 68);
            this.cmbBonus.Name = "cmbBonus";
            this.cmbBonus.Size = new System.Drawing.Size(138, 21);
            this.cmbBonus.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(295, 163);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(357, 100);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bonusNameDataGridViewTextBoxColumn,
            this.bonusTypeDataGridViewTextBoxColumn,
            this.bonusAmountDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bonusBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(351, 81);
            this.dataGridView1.TabIndex = 0;
            // 
            // bonusNameDataGridViewTextBoxColumn
            // 
            this.bonusNameDataGridViewTextBoxColumn.DataPropertyName = "BonusName";
            this.bonusNameDataGridViewTextBoxColumn.HeaderText = "Bonus Name";
            this.bonusNameDataGridViewTextBoxColumn.Name = "bonusNameDataGridViewTextBoxColumn";
            this.bonusNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.bonusNameDataGridViewTextBoxColumn.Width = 105;
            // 
            // bonusTypeDataGridViewTextBoxColumn
            // 
            this.bonusTypeDataGridViewTextBoxColumn.DataPropertyName = "BonusType";
            this.bonusTypeDataGridViewTextBoxColumn.HeaderText = "Bonus Type";
            this.bonusTypeDataGridViewTextBoxColumn.Name = "bonusTypeDataGridViewTextBoxColumn";
            this.bonusTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bonusAmountDataGridViewTextBoxColumn
            // 
            this.bonusAmountDataGridViewTextBoxColumn.DataPropertyName = "BonusAmount";
            this.bonusAmountDataGridViewTextBoxColumn.HeaderText = "Bonus Amount";
            this.bonusAmountDataGridViewTextBoxColumn.Name = "bonusAmountDataGridViewTextBoxColumn";
            this.bonusAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bonusBindingSource
            // 
            this.bonusBindingSource.DataMember = "Bonus";
            this.bonusBindingSource.DataSource = this.bonusDataSet;
            // 
            // bonusDataSet
            // 
            this.bonusDataSet.DataSetName = "BonusDataSet";
            this.bonusDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView2);
            this.groupBox4.Location = new System.Drawing.Point(12, 163);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(277, 100);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NewSale,
            this.Retention});
            this.dataGridView2.DataSource = this.commissionBindingSource;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 16);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(271, 81);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            // 
            // NewSale
            // 
            this.NewSale.DataPropertyName = "NewSale";
            this.NewSale.HeaderText = "New Customer";
            this.NewSale.Name = "NewSale";
            this.NewSale.ReadOnly = true;
            this.NewSale.Width = 125;
            // 
            // Retention
            // 
            this.Retention.DataPropertyName = "Retention";
            this.Retention.HeaderText = "Retention";
            this.Retention.Name = "Retention";
            this.Retention.ReadOnly = true;
            // 
            // commissionBindingSource
            // 
            this.commissionBindingSource.DataMember = "Commission";
            this.commissionBindingSource.DataSource = this.commissionDataSet;
            // 
            // commissionDataSet
            // 
            this.commissionDataSet.DataSetName = "CommissionDataSet";
            this.commissionDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // commissionTableAdapter
            // 
            this.commissionTableAdapter.ClearBeforeFill = true;
            // 
            // bonusTableAdapter
            // 
            this.bonusTableAdapter.ClearBeforeFill = true;
            // 
            // BonusAndCommision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(664, 270);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BonusAndCommision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bonus & Commision";
            this.Load += new System.EventHandler(this.BonusAndCommision_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusDataSet)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commissionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commissionDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbBonusRate;
        private System.Windows.Forms.ComboBox cmbBonus;
        private System.Windows.Forms.TextBox txtNewSale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRetention;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSaveBonus;
        private System.Windows.Forms.RadioButton rdbtnMonthly;
        private System.Windows.Forms.RadioButton rdbtnQuaterly;
        private System.Windows.Forms.RadioButton rdbtnBiannually;
        private System.Windows.Forms.RadioButton rdbtnAnnually;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveCommission;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private CommissionDataSet commissionDataSet;
        private System.Windows.Forms.BindingSource commissionBindingSource;
        private CommissionDataSetTableAdapters.CommissionTableAdapter commissionTableAdapter;
        private BonusDataSet bonusDataSet;
        private System.Windows.Forms.BindingSource bonusBindingSource;
        private BonusDataSetTableAdapters.BonusTableAdapter bonusTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn bonusNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bonusTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bonusAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewSale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Retention;
        private System.Windows.Forms.Label label2;
    }
}