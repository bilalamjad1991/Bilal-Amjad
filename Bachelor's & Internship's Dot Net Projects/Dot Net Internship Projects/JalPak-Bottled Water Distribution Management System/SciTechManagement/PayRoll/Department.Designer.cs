namespace SciTechManagement.PayRoll
{
    partial class Department
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Department));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDeptID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdateDept = new System.Windows.Forms.Button();
            this.btnDeleteDept = new System.Windows.Forms.Button();
            this.btnSaveDept = new System.Windows.Forms.Button();
            this.txtDeptManager = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDeptName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Dept_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dept_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dept_Manager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.departmentDataSet = new SciTechManagement.DepartmentDataSet();
            this.panel1 = new System.Windows.Forms.Panel();
            this.departmentTableAdapter = new SciTechManagement.DepartmentDataSetTableAdapters.DepartmentTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDeptID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnUpdateDept);
            this.groupBox1.Controls.Add(this.btnDeleteDept);
            this.groupBox1.Controls.Add(this.btnSaveDept);
            this.groupBox1.Controls.Add(this.txtDeptManager);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDeptName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 186);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Department";
            // 
            // txtDeptID
            // 
            this.txtDeptID.AutoSize = true;
            this.txtDeptID.Location = new System.Drawing.Point(176, 61);
            this.txtDeptID.Name = "txtDeptID";
            this.txtDeptID.Size = new System.Drawing.Size(0, 13);
            this.txtDeptID.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(378, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(378, 87);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "*";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(224, 146);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(72, 30);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdateDept
            // 
            this.btnUpdateDept.Location = new System.Drawing.Point(147, 146);
            this.btnUpdateDept.Name = "btnUpdateDept";
            this.btnUpdateDept.Size = new System.Drawing.Size(72, 30);
            this.btnUpdateDept.TabIndex = 6;
            this.btnUpdateDept.Text = "Update";
            this.btnUpdateDept.UseVisualStyleBackColor = true;
            this.btnUpdateDept.Click += new System.EventHandler(this.btnUpdateDept_Click);
            // 
            // btnDeleteDept
            // 
            this.btnDeleteDept.Location = new System.Drawing.Point(300, 146);
            this.btnDeleteDept.Name = "btnDeleteDept";
            this.btnDeleteDept.Size = new System.Drawing.Size(72, 30);
            this.btnDeleteDept.TabIndex = 5;
            this.btnDeleteDept.Text = "Delete";
            this.btnDeleteDept.UseVisualStyleBackColor = true;
            this.btnDeleteDept.Click += new System.EventHandler(this.btnDeleteDept_Click);
            // 
            // btnSaveDept
            // 
            this.btnSaveDept.Location = new System.Drawing.Point(70, 146);
            this.btnSaveDept.Name = "btnSaveDept";
            this.btnSaveDept.Size = new System.Drawing.Size(72, 30);
            this.btnSaveDept.TabIndex = 4;
            this.btnSaveDept.Text = "Save";
            this.btnSaveDept.UseVisualStyleBackColor = true;
            this.btnSaveDept.Click += new System.EventHandler(this.btnSaveDept_Click);
            // 
            // txtDeptManager
            // 
            this.txtDeptManager.Location = new System.Drawing.Point(173, 110);
            this.txtDeptManager.Name = "txtDeptManager";
            this.txtDeptManager.Size = new System.Drawing.Size(199, 20);
            this.txtDeptManager.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Manager Name:";
            // 
            // txtDeptName
            // 
            this.txtDeptName.Location = new System.Drawing.Point(173, 84);
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.Size = new System.Drawing.Size(199, 20);
            this.txtDeptName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Department Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Department ID:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Dept_ID,
            this.Dept_Name,
            this.Dept_Manager});
            this.dataGridView1.DataSource = this.departmentBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(514, 164);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Dept_ID
            // 
            this.Dept_ID.DataPropertyName = "Dept_ID";
            this.Dept_ID.HeaderText = "Department ID";
            this.Dept_ID.Name = "Dept_ID";
            this.Dept_ID.ReadOnly = true;
            // 
            // Dept_Name
            // 
            this.Dept_Name.DataPropertyName = "Dept_Name";
            this.Dept_Name.HeaderText = "Department Name";
            this.Dept_Name.Name = "Dept_Name";
            this.Dept_Name.ReadOnly = true;
            this.Dept_Name.Width = 170;
            // 
            // Dept_Manager
            // 
            this.Dept_Manager.DataPropertyName = "Dept_Manager";
            this.Dept_Manager.HeaderText = "Department Manager";
            this.Dept_Manager.Name = "Dept_Manager";
            this.Dept_Manager.ReadOnly = true;
            this.Dept_Manager.Width = 200;
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataMember = "Department";
            this.departmentBindingSource.DataSource = this.departmentDataSet;
            // 
            // departmentDataSet
            // 
            this.departmentDataSet.DataSetName = "DepartmentDataSet";
            this.departmentDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 214);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 170);
            this.panel1.TabIndex = 1;
            // 
            // departmentTableAdapter
            // 
            this.departmentTableAdapter.ClearBeforeFill = true;
            // 
            // Department
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(541, 396);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Department";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Department";
            this.Load += new System.EventHandler(this.Department_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveDept;
        private System.Windows.Forms.TextBox txtDeptManager;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDeptName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private DepartmentDataSet departmentDataSet;
        private System.Windows.Forms.BindingSource departmentBindingSource;
        private DepartmentDataSetTableAdapters.DepartmentTableAdapter departmentTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dept_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dept_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dept_Manager;
        private System.Windows.Forms.Button btnDeleteDept;
        private System.Windows.Forms.Button btnUpdateDept;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label txtDeptID;
    }
}