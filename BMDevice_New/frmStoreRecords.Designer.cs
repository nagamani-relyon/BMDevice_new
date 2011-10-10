namespace BMDevice_New
{
    partial class frmStoreRecords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStoreRecords));
            this.grpEmp = new System.Windows.Forms.GroupBox();
            this.txtEmp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEmpId = new System.Windows.Forms.CheckBox();
            this.grpDate = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbError = new System.Windows.Forms.Label();
            this.cmbDeviceIp = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGetRecords = new System.Windows.Forms.Button();
            this.axCZKEM1 = new Axzkemkeeper.AxCZKEM();
            this.grpEmp.SuspendLayout();
            this.grpDate.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axCZKEM1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpEmp
            // 
            this.grpEmp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpEmp.Controls.Add(this.txtEmp);
            this.grpEmp.Controls.Add(this.label1);
            this.grpEmp.Enabled = false;
            this.grpEmp.Location = new System.Drawing.Point(6, 68);
            this.grpEmp.Name = "grpEmp";
            this.grpEmp.Size = new System.Drawing.Size(156, 52);
            this.grpEmp.TabIndex = 0;
            this.grpEmp.TabStop = false;
            // 
            // txtEmp
            // 
            this.txtEmp.Location = new System.Drawing.Point(59, 21);
            this.txtEmp.Name = "txtEmp";
            this.txtEmp.Size = new System.Drawing.Size(85, 20);
            this.txtEmp.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Emp Id :";
            // 
            // chkEmpId
            // 
            this.chkEmpId.AutoSize = true;
            this.chkEmpId.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkEmpId.Location = new System.Drawing.Point(6, 54);
            this.chkEmpId.Name = "chkEmpId";
            this.chkEmpId.Size = new System.Drawing.Size(78, 17);
            this.chkEmpId.TabIndex = 1;
            this.chkEmpId.Text = "By EMP ID";
            this.chkEmpId.UseVisualStyleBackColor = false;
            this.chkEmpId.CheckedChanged += new System.EventHandler(this.chkEmpId_CheckedChanged);
            // 
            // grpDate
            // 
            this.grpDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpDate.Controls.Add(this.label3);
            this.grpDate.Controls.Add(this.dtpDate);
            this.grpDate.Enabled = false;
            this.grpDate.Location = new System.Drawing.Point(168, 68);
            this.grpDate.Name = "grpDate";
            this.grpDate.Size = new System.Drawing.Size(156, 52);
            this.grpDate.TabIndex = 1;
            this.grpDate.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Date :";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "yyyy-MM-dd";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(62, 20);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(85, 20);
            this.dtpDate.TabIndex = 2;
            this.dtpDate.Value = new System.DateTime(2011, 8, 8, 0, 0, 0, 0);
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkDate.Location = new System.Drawing.Point(168, 54);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(64, 17);
            this.chkDate.TabIndex = 0;
            this.chkDate.Text = "By Date";
            this.chkDate.UseVisualStyleBackColor = false;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Controls.Add(this.lbError);
            this.groupBox3.Controls.Add(this.cmbDeviceIp);
            this.groupBox3.Controls.Add(this.grpDate);
            this.groupBox3.Controls.Add(this.chkDate);
            this.groupBox3.Controls.Add(this.chkEmpId);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.grpEmp);
            this.groupBox3.Controls.Add(this.btnGetRecords);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(335, 140);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Records";
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(7, 125);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(0, 13);
            this.lbError.TabIndex = 10;
            // 
            // cmbDeviceIp
            // 
            this.cmbDeviceIp.FormattingEnabled = true;
            this.cmbDeviceIp.Location = new System.Drawing.Point(82, 26);
            this.cmbDeviceIp.Name = "cmbDeviceIp";
            this.cmbDeviceIp.Size = new System.Drawing.Size(119, 21);
            this.cmbDeviceIp.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Device Ip :";
            // 
            // btnGetRecords
            // 
            this.btnGetRecords.BackColor = System.Drawing.Color.Gainsboro;
            this.btnGetRecords.Location = new System.Drawing.Point(224, 26);
            this.btnGetRecords.Name = "btnGetRecords";
            this.btnGetRecords.Size = new System.Drawing.Size(100, 21);
            this.btnGetRecords.TabIndex = 1;
            this.btnGetRecords.Text = "Get Records";
            this.btnGetRecords.UseVisualStyleBackColor = false;
            this.btnGetRecords.Click += new System.EventHandler(this.btnGetRecords_Click);
            // 
            // axCZKEM1
            // 
            this.axCZKEM1.Enabled = true;
            this.axCZKEM1.Location = new System.Drawing.Point(365, 51);
            this.axCZKEM1.Name = "axCZKEM1";
            this.axCZKEM1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axCZKEM1.OcxState")));
            this.axCZKEM1.Size = new System.Drawing.Size(192, 192);
            this.axCZKEM1.TabIndex = 3;
            // 
            // frmStoreRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(347, 151);
            this.Controls.Add(this.axCZKEM1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStoreRecords";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save Records";
            this.Load += new System.EventHandler(this.frmStoreRecords_Load);
            this.grpEmp.ResumeLayout(false);
            this.grpEmp.PerformLayout();
            this.grpDate.ResumeLayout(false);
            this.grpDate.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axCZKEM1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpEmp;
        private System.Windows.Forms.CheckBox chkEmpId;
        private System.Windows.Forms.GroupBox grpDate;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnGetRecords;
        private System.Windows.Forms.TextBox txtEmp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cmbDeviceIp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbError;
        private Axzkemkeeper.AxCZKEM axCZKEM1;
    }
}