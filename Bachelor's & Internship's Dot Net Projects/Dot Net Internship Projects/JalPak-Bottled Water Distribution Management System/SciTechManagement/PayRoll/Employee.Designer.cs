namespace SciTechManagement.PayRoll
{
    partial class Employee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employee));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.chkbxBonus = new System.Windows.Forms.CheckBox();
            this.chkbxCommission = new System.Windows.Forms.CheckBox();
            this.cmbEmpType = new System.Windows.Forms.ComboBox();
            this.txtBaseSalary = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.txtEmpEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmpAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmpContact = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmpID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Emp_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emp_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emp_JoinDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emp_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emp_Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emp_Contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emp_Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emp_Dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emp_BaseSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emp_Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emp_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeeDetailsDataSet = new SciTechManagement.EmployeeDetailsDataSet();
            this.employeeTableAdapter = new SciTechManagement.EmployeeDetailsDataSetTableAdapters.EmployeeTableAdapter();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDetailsDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cmbArea);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.chkbxBonus);
            this.groupBox1.Controls.Add(this.chkbxCommission);
            this.groupBox1.Controls.Add(this.cmbEmpType);
            this.groupBox1.Controls.Add(this.txtBaseSalary);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.cmbDept);
            this.groupBox1.Controls.Add(this.txtEmpEmail);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtEmpAddress);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtEmpContact);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEmpName);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEmpID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(919, 359);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee Details";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(642, 122);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(11, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(332, 174);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(332, 147);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(332, 121);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(332, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(332, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "*";
            // 
            // cmbArea
            // 
            this.cmbArea.Location = new System.Drawing.Point(458, 118);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(181, 20);
            this.cmbArea.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(458, 58);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(181, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // chkbxBonus
            // 
            this.chkbxBonus.AutoSize = true;
            this.chkbxBonus.Location = new System.Drawing.Point(459, 173);
            this.chkbxBonus.Name = "chkbxBonus";
            this.chkbxBonus.Size = new System.Drawing.Size(56, 17);
            this.chkbxBonus.TabIndex = 10;
            this.chkbxBonus.Text = "Bonus";
            this.chkbxBonus.UseVisualStyleBackColor = true;
            // 
            // chkbxCommission
            // 
            this.chkbxCommission.AutoSize = true;
            this.chkbxCommission.Location = new System.Drawing.Point(372, 173);
            this.chkbxCommission.Name = "chkbxCommission";
            this.chkbxCommission.Size = new System.Drawing.Size(81, 17);
            this.chkbxCommission.TabIndex = 9;
            this.chkbxCommission.Text = "Commission";
            this.chkbxCommission.UseVisualStyleBackColor = true;
            // 
            // cmbEmpType
            // 
            this.cmbEmpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpType.FormattingEnabled = true;
            this.cmbEmpType.Location = new System.Drawing.Point(165, 54);
            this.cmbEmpType.Name = "cmbEmpType";
            this.cmbEmpType.Size = new System.Drawing.Size(164, 21);
            this.cmbEmpType.TabIndex = 1;
            this.cmbEmpType.SelectedIndexChanged += new System.EventHandler(this.cmbEmpType_SelectedIndexChanged);
            // 
            // txtBaseSalary
            // 
            this.txtBaseSalary.Location = new System.Drawing.Point(165, 171);
            this.txtBaseSalary.MaxLength = 8;
            this.txtBaseSalary.Name = "txtBaseSalary";
            this.txtBaseSalary.Size = new System.Drawing.Size(164, 20);
            this.txtBaseSalary.TabIndex = 8;
            this.txtBaseSalary.TextChanged += new System.EventHandler(this.txtBaseSalary_TextChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(429, 322);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 31);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(554, 322);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 31);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(300, 322);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 31);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(165, 322);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 31);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbDept
            // 
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.Location = new System.Drawing.Point(165, 142);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(164, 21);
            this.cmbDept.TabIndex = 7;
            // 
            // txtEmpEmail
            // 
            this.txtEmpEmail.Location = new System.Drawing.Point(458, 88);
            this.txtEmpEmail.Name = "txtEmpEmail";
            this.txtEmpEmail.Size = new System.Drawing.Size(181, 20);
            this.txtEmpEmail.TabIndex = 4;
            this.txtEmpEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpEmail_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(388, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Area:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(388, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Email:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(85, 171);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Base Salary:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Department:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(388, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Date:";
            // 
            // txtEmpAddress
            // 
            this.txtEmpAddress.Location = new System.Drawing.Point(165, 201);
            this.txtEmpAddress.Multiline = true;
            this.txtEmpAddress.Name = "txtEmpAddress";
            this.txtEmpAddress.Size = new System.Drawing.Size(476, 103);
            this.txtEmpAddress.TabIndex = 11;
            this.txtEmpAddress.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpAddress_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(85, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Address:";
            // 
            // txtEmpContact
            // 
            this.txtEmpContact.Location = new System.Drawing.Point(165, 114);
            this.txtEmpContact.MaxLength = 11;
            this.txtEmpContact.Name = "txtEmpContact";
            this.txtEmpContact.Size = new System.Drawing.Size(164, 20);
            this.txtEmpContact.TabIndex = 5;
            this.txtEmpContact.TextChanged += new System.EventHandler(this.txtEmpContact_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Contact No:";
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(165, 86);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(164, 20);
            this.txtEmpName.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(85, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            // 
            // txtEmpID
            // 
            this.txtEmpID.Location = new System.Drawing.Point(165, 24);
            this.txtEmpID.Name = "txtEmpID";
            this.txtEmpID.ReadOnly = true;
            this.txtEmpID.Size = new System.Drawing.Size(122, 20);
            this.txtEmpID.TabIndex = 1;
            this.txtEmpID.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee ID:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 377);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(919, 260);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Emp_ID,
            this.Emp_Type,
            this.Emp_JoinDate,
            this.Emp_Name,
            this.Emp_Email,
            this.Emp_Contact,
            this.Emp_Area,
            this.Emp_Dept,
            this.Emp_BaseSalary,
            this.Emp_Bonus,
            this.Emp_Address});
            this.dataGridView1.DataSource = this.employeeBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(919, 260);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Emp_ID
            // 
            this.Emp_ID.DataPropertyName = "Emp_ID";
            this.Emp_ID.HeaderText = "Employee ID";
            this.Emp_ID.Name = "Emp_ID";
            this.Emp_ID.ReadOnly = true;
            // 
            // Emp_Type
            // 
            this.Emp_Type.DataPropertyName = "Emp_Type";
            this.Emp_Type.HeaderText = "Employee Type";
            this.Emp_Type.Name = "Emp_Type";
            this.Emp_Type.ReadOnly = true;
            // 
            // Emp_JoinDate
            // 
            this.Emp_JoinDate.DataPropertyName = "Emp_JoinDate";
            this.Emp_JoinDate.HeaderText = "Join Date";
            this.Emp_JoinDate.Name = "Emp_JoinDate";
            this.Emp_JoinDate.ReadOnly = true;
            // 
            // Emp_Name
            // 
            this.Emp_Name.DataPropertyName = "Emp_Name";
            this.Emp_Name.HeaderText = "Name";
            this.Emp_Name.Name = "Emp_Name";
            this.Emp_Name.ReadOnly = true;
            // 
            // Emp_Email
            // 
            this.Emp_Email.DataPropertyName = "Emp_Email";
            this.Emp_Email.HeaderText = "Email";
            this.Emp_Email.Name = "Emp_Email";
            this.Emp_Email.ReadOnly = true;
            // 
            // Emp_Contact
            // 
            this.Emp_Contact.DataPropertyName = "Emp_Contact";
            this.Emp_Contact.HeaderText = "Contact NO";
            this.Emp_Contact.Name = "Emp_Contact";
            this.Emp_Contact.ReadOnly = true;
            // 
            // Emp_Area
            // 
            this.Emp_Area.DataPropertyName = "Emp_Area";
            this.Emp_Area.HeaderText = "Area Asigned";
            this.Emp_Area.Name = "Emp_Area";
            this.Emp_Area.ReadOnly = true;
            // 
            // Emp_Dept
            // 
            this.Emp_Dept.DataPropertyName = "Emp_Dept";
            this.Emp_Dept.HeaderText = "Department";
            this.Emp_Dept.Name = "Emp_Dept";
            this.Emp_Dept.ReadOnly = true;
            // 
            // Emp_BaseSalary
            // 
            this.Emp_BaseSalary.DataPropertyName = "Emp_BaseSalary";
            this.Emp_BaseSalary.HeaderText = "Base Salary";
            this.Emp_BaseSalary.Name = "Emp_BaseSalary";
            this.Emp_BaseSalary.ReadOnly = true;
            // 
            // Emp_Bonus
            // 
            this.Emp_Bonus.DataPropertyName = "Emp_Bonus";
            this.Emp_Bonus.HeaderText = "Bonus";
            this.Emp_Bonus.Name = "Emp_Bonus";
            this.Emp_Bonus.ReadOnly = true;
            // 
            // Emp_Address
            // 
            this.Emp_Address.DataPropertyName = "Emp_Address";
            this.Emp_Address.HeaderText = "Address";
            this.Emp_Address.Name = "Emp_Address";
            this.Emp_Address.ReadOnly = true;
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataMember = "Employee";
            this.employeeBindingSource.DataSource = this.employeeDetailsDataSet;
            // 
            // employeeDetailsDataSet
            // 
            this.employeeDetailsDataSet.DataSetName = "EmployeeDetailsDataSet";
            this.employeeDetailsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // employeeTableAdapter
            // 
            this.employeeTableAdapter.ClearBeforeFill = true;
            // 
            // Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(943, 649);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Employee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee";
            this.Load += new System.EventHandler(this.Employee_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDetailsDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEmpID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmpContact;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmpAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbEmpType;
        private System.Windows.Forms.TextBox txtBaseSalary;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmpEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkbxBonus;
        private System.Windows.Forms.CheckBox chkbxCommission;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private EmployeeDetailsDataSet employeeDetailsDataSet;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private EmployeeDetailsDataSetTableAdapters.EmployeeTableAdapter employeeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emp_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emp_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emp_JoinDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emp_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emp_Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emp_Contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emp_Area;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emp_Dept;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emp_BaseSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emp_Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emp_Address;
        private System.Windows.Forms.TextBox cmbArea;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}