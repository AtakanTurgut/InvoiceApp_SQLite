namespace EmployeeLite.Forms
{
    partial class MainForm
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
            this.gbEmployee = new System.Windows.Forms.GroupBox();
            this.grdEmployee = new System.Windows.Forms.DataGridView();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeleteEmployee = new System.Windows.Forms.Button();
            this.gbEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // gbEmployee
            // 
            this.gbEmployee.Controls.Add(this.grdEmployee);
            this.gbEmployee.Location = new System.Drawing.Point(12, 24);
            this.gbEmployee.Name = "gbEmployee";
            this.gbEmployee.Size = new System.Drawing.Size(1095, 383);
            this.gbEmployee.TabIndex = 0;
            this.gbEmployee.TabStop = false;
            this.gbEmployee.Text = "Employees";
            // 
            // grdEmployee
            // 
            this.grdEmployee.AllowUserToAddRows = false;
            this.grdEmployee.AllowUserToDeleteRows = false;
            this.grdEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEmployee.Location = new System.Drawing.Point(3, 18);
            this.grdEmployee.Name = "grdEmployee";
            this.grdEmployee.ReadOnly = true;
            this.grdEmployee.RowHeadersWidth = 51;
            this.grdEmployee.RowTemplate.Height = 24;
            this.grdEmployee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdEmployee.Size = new System.Drawing.Size(1089, 362);
            this.grdEmployee.TabIndex = 0;
            this.grdEmployee.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdEmployee_CellDoubleClick);
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.BackColor = System.Drawing.Color.LightGreen;
            this.btnAddEmployee.Location = new System.Drawing.Point(172, 408);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(470, 36);
            this.btnAddEmployee.TabIndex = 0;
            this.btnAddEmployee.Text = "Add Employee";
            this.btnAddEmployee.UseVisualStyleBackColor = false;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LightGray;
            this.btnRefresh.Location = new System.Drawing.Point(648, 408);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(456, 36);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.BackColor = System.Drawing.Color.LightCoral;
            this.btnDeleteEmployee.Location = new System.Drawing.Point(12, 408);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Size = new System.Drawing.Size(154, 36);
            this.btnDeleteEmployee.TabIndex = 2;
            this.btnDeleteEmployee.Text = "Delete Employee";
            this.btnDeleteEmployee.UseVisualStyleBackColor = false;
            this.btnDeleteEmployee.Click += new System.EventHandler(this.btnDeleteEmployee_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 450);
            this.Controls.Add(this.btnDeleteEmployee);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAddEmployee);
            this.Controls.Add(this.gbEmployee);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employees";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbEmployee.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEmployee;
        private System.Windows.Forms.DataGridView grdEmployee;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDeleteEmployee;
    }
}