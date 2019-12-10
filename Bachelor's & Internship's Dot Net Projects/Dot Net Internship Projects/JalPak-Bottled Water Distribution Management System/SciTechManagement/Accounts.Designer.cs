namespace SciTechManagement
{
    partial class Accounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Accounts));
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMainAccounts = new System.Windows.Forms.ComboBox();
            this.cmbAccounts = new System.Windows.Forms.ComboBox();
            this.cmbTitle = new System.Windows.Forms.ComboBox();
            this.ActYes = new System.Windows.Forms.RadioButton();
            this.ActNo = new System.Windows.Forms.RadioButton();
            this.LeafYes = new System.Windows.Forms.RadioButton();
            this.LeafNo = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddAccounts = new System.Windows.Forms.Button();
            this.btnAddTitle = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Main Accounts:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(83, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Leaf Level:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Active:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Accounts:";
            // 
            // cmbMainAccounts
            // 
            this.cmbMainAccounts.FormattingEnabled = true;
            this.cmbMainAccounts.Location = new System.Drawing.Point(200, 61);
            this.cmbMainAccounts.Name = "cmbMainAccounts";
            this.cmbMainAccounts.Size = new System.Drawing.Size(121, 21);
            this.cmbMainAccounts.TabIndex = 20;
            this.cmbMainAccounts.SelectedIndexChanged += new System.EventHandler(this.cmbMainAccounts_SelectedIndexChanged);
            // 
            // cmbAccounts
            // 
            this.cmbAccounts.FormattingEnabled = true;
            this.cmbAccounts.Location = new System.Drawing.Point(200, 103);
            this.cmbAccounts.Name = "cmbAccounts";
            this.cmbAccounts.Size = new System.Drawing.Size(121, 21);
            this.cmbAccounts.TabIndex = 21;
            this.cmbAccounts.SelectedIndexChanged += new System.EventHandler(this.cmbAccounts_SelectedIndexChanged);
            // 
            // cmbTitle
            // 
            this.cmbTitle.FormattingEnabled = true;
            this.cmbTitle.Location = new System.Drawing.Point(200, 147);
            this.cmbTitle.Name = "cmbTitle";
            this.cmbTitle.Size = new System.Drawing.Size(121, 21);
            this.cmbTitle.TabIndex = 22;
            // 
            // ActYes
            // 
            this.ActYes.AutoSize = true;
            this.ActYes.Location = new System.Drawing.Point(7, 13);
            this.ActYes.Name = "ActYes";
            this.ActYes.Size = new System.Drawing.Size(43, 17);
            this.ActYes.TabIndex = 23;
            this.ActYes.TabStop = true;
            this.ActYes.Text = "Yes";
            this.ActYes.UseVisualStyleBackColor = true;
            // 
            // ActNo
            // 
            this.ActNo.AutoSize = true;
            this.ActNo.Location = new System.Drawing.Point(55, 13);
            this.ActNo.Name = "ActNo";
            this.ActNo.Size = new System.Drawing.Size(39, 17);
            this.ActNo.TabIndex = 24;
            this.ActNo.TabStop = true;
            this.ActNo.Text = "No";
            this.ActNo.UseVisualStyleBackColor = true;
            // 
            // LeafYes
            // 
            this.LeafYes.AutoSize = true;
            this.LeafYes.Location = new System.Drawing.Point(6, 12);
            this.LeafYes.Name = "LeafYes";
            this.LeafYes.Size = new System.Drawing.Size(43, 17);
            this.LeafYes.TabIndex = 25;
            this.LeafYes.TabStop = true;
            this.LeafYes.Text = "Yes";
            this.LeafYes.UseVisualStyleBackColor = true;
            // 
            // LeafNo
            // 
            this.LeafNo.AutoSize = true;
            this.LeafNo.Location = new System.Drawing.Point(55, 12);
            this.LeafNo.Name = "LeafNo";
            this.LeafNo.Size = new System.Drawing.Size(39, 17);
            this.LeafNo.TabIndex = 26;
            this.LeafNo.TabStop = true;
            this.LeafNo.Text = "No";
            this.LeafNo.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ActYes);
            this.groupBox1.Controls.Add(this.ActNo);
            this.groupBox1.Location = new System.Drawing.Point(200, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(100, 34);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LeafYes);
            this.groupBox2.Controls.Add(this.LeafNo);
            this.groupBox2.Location = new System.Drawing.Point(201, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(99, 32);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            // 
            // btnAddAccounts
            // 
            this.btnAddAccounts.Location = new System.Drawing.Point(348, 103);
            this.btnAddAccounts.Name = "btnAddAccounts";
            this.btnAddAccounts.Size = new System.Drawing.Size(75, 23);
            this.btnAddAccounts.TabIndex = 29;
            this.btnAddAccounts.Text = "+";
            this.btnAddAccounts.UseVisualStyleBackColor = true;
            this.btnAddAccounts.Click += new System.EventHandler(this.btnAddAccounts_Click);
            // 
            // btnAddTitle
            // 
            this.btnAddTitle.Location = new System.Drawing.Point(348, 144);
            this.btnAddTitle.Name = "btnAddTitle";
            this.btnAddTitle.Size = new System.Drawing.Size(75, 23);
            this.btnAddTitle.TabIndex = 30;
            this.btnAddTitle.Text = "+";
            this.btnAddTitle.UseVisualStyleBackColor = true;
            this.btnAddTitle.Click += new System.EventHandler(this.btnAddTitle_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(156, 274);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(256, 274);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 32;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Accounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(455, 337);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddTitle);
            this.Controls.Add(this.btnAddAccounts);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbTitle);
            this.Controls.Add(this.cmbAccounts);
            this.Controls.Add(this.cmbMainAccounts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Accounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accounts";
            this.Activated += new System.EventHandler(this.Accounts_Activated);
            this.Load += new System.EventHandler(this.Accounts_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMainAccounts;
        private System.Windows.Forms.ComboBox cmbAccounts;
        private System.Windows.Forms.ComboBox cmbTitle;
        private System.Windows.Forms.RadioButton ActYes;
        private System.Windows.Forms.RadioButton ActNo;
        private System.Windows.Forms.RadioButton LeafYes;
        private System.Windows.Forms.RadioButton LeafNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddAccounts;
        private System.Windows.Forms.Button btnAddTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
    }
}