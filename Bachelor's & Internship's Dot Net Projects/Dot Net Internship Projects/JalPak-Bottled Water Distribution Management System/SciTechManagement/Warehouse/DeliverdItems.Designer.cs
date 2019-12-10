namespace SciTechManagement.Warehouse
{
    partial class DeliverdItems
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
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBalanceBottles = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBottleReceived = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBottlesDelivered = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bottles_Delivered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bottle_Received = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance_Bottles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount_Received = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Signature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRatePerBottle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(435, 156);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(127, 20);
            this.txtAmount.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(344, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Amount:";
            // 
            // txtBalanceBottles
            // 
            this.txtBalanceBottles.Location = new System.Drawing.Point(157, 156);
            this.txtBalanceBottles.Name = "txtBalanceBottles";
            this.txtBalanceBottles.Size = new System.Drawing.Size(127, 20);
            this.txtBalanceBottles.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "Balance Bottles:";
            // 
            // txtBottleReceived
            // 
            this.txtBottleReceived.Location = new System.Drawing.Point(435, 121);
            this.txtBottleReceived.Name = "txtBottleReceived";
            this.txtBottleReceived.Size = new System.Drawing.Size(127, 20);
            this.txtBottleReceived.TabIndex = 40;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(344, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Bottles Received:";
            // 
            // txtBottlesDelivered
            // 
            this.txtBottlesDelivered.Location = new System.Drawing.Point(157, 121);
            this.txtBottlesDelivered.Name = "txtBottlesDelivered";
            this.txtBottlesDelivered.Size = new System.Drawing.Size(127, 20);
            this.txtBottlesDelivered.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(62, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Bottles Delivered:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(647, 150);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 30);
            this.btnAdd.TabIndex = 36;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 256);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(833, 412);
            this.panel1.TabIndex = 35;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(833, 412);
            this.dataGridView1.TabIndex = 12;
            // 
            // Date
            // 
            dataGridViewCellStyle2.NullValue = null;
            this.Date.DefaultCellStyle = dataGridViewCellStyle2;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // Bottles_Delivered
            // 
            this.Bottles_Delivered.HeaderText = "Bottles Delivered";
            this.Bottles_Delivered.Name = "Bottles_Delivered";
            // 
            // Bottle_Received
            // 
            this.Bottle_Received.HeaderText = "Bottle Received";
            this.Bottle_Received.Name = "Bottle_Received";
            // 
            // Balance_Bottles
            // 
            this.Balance_Bottles.HeaderText = "Balance Bottles";
            this.Balance_Bottles.Name = "Balance_Bottles";
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // Amount_Received
            // 
            this.Amount_Received.HeaderText = "Amount Received";
            this.Amount_Received.Name = "Amount_Received";
            // 
            // Balance_Amount
            // 
            this.Balance_Amount.HeaderText = "Balance Amount";
            this.Balance_Amount.Name = "Balance_Amount";
            // 
            // Signature
            // 
            this.Signature.HeaderText = "Signature";
            this.Signature.Name = "Signature";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(157, 15);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(157, 20);
            this.txtCustomerName.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Customer Name:";
            // 
            // txtRatePerBottle
            // 
            this.txtRatePerBottle.Location = new System.Drawing.Point(618, 15);
            this.txtRatePerBottle.Name = "txtRatePerBottle";
            this.txtRatePerBottle.Size = new System.Drawing.Size(127, 20);
            this.txtRatePerBottle.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(530, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Rate Per Bottle:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(385, 15);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(127, 20);
            this.dateTimePicker1.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Month:";
            // 
            // DeliverdItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 668);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtBalanceBottles);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBottleReceived);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBottlesDelivered);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRatePerBottle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DeliverdItems";
            this.Text = "DeliverdItems";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBalanceBottles;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBottleReceived;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBottlesDelivered;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bottles_Delivered;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bottle_Received;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance_Bottles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount_Received;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Signature;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRatePerBottle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
    }
}