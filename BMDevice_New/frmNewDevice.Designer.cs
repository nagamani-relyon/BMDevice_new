namespace BMDevice_New
{
    partial class frmNewDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewDevice));
            this.dgvDeviceIps = new System.Windows.Forms.DataGridView();
            this.grbDeviceIP = new System.Windows.Forms.GroupBox();
            this.txtDevPort = new System.Windows.Forms.TextBox();
            this.txtDevIp = new System.Windows.Forms.TextBox();
            this.txtDevNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTestConn = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbError = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.axCZKEM1 = new Axzkemkeeper.AxCZKEM();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceIps)).BeginInit();
            this.grbDeviceIP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axCZKEM1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDeviceIps
            // 
            this.dgvDeviceIps.AllowUserToAddRows = false;
            this.dgvDeviceIps.AllowUserToDeleteRows = false;
            this.dgvDeviceIps.AllowUserToResizeColumns = false;
            this.dgvDeviceIps.AllowUserToResizeRows = false;
            this.dgvDeviceIps.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDeviceIps.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDeviceIps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeviceIps.Location = new System.Drawing.Point(6, 66);
            this.dgvDeviceIps.MultiSelect = false;
            this.dgvDeviceIps.Name = "dgvDeviceIps";
            this.dgvDeviceIps.ReadOnly = true;
            this.dgvDeviceIps.RowHeadersVisible = false;
            this.dgvDeviceIps.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDeviceIps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeviceIps.Size = new System.Drawing.Size(357, 182);
            this.dgvDeviceIps.TabIndex = 0;
            this.dgvDeviceIps.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeviceIps_CellClick);
            // 
            // grbDeviceIP
            // 
            this.grbDeviceIP.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grbDeviceIP.Controls.Add(this.txtDevPort);
            this.grbDeviceIP.Controls.Add(this.txtDevIp);
            this.grbDeviceIP.Controls.Add(this.txtDevNo);
            this.grbDeviceIP.Controls.Add(this.label3);
            this.grbDeviceIP.Controls.Add(this.label2);
            this.grbDeviceIP.Controls.Add(this.label1);
            this.grbDeviceIP.Enabled = false;
            this.grbDeviceIP.Location = new System.Drawing.Point(6, 6);
            this.grbDeviceIP.Name = "grbDeviceIP";
            this.grbDeviceIP.Size = new System.Drawing.Size(357, 55);
            this.grbDeviceIP.TabIndex = 2;
            this.grbDeviceIP.TabStop = false;
            this.grbDeviceIP.Text = "Device Details";
            // 
            // txtDevPort
            // 
            this.txtDevPort.Location = new System.Drawing.Point(158, 19);
            this.txtDevPort.Name = "txtDevPort";
            this.txtDevPort.Size = new System.Drawing.Size(61, 20);
            this.txtDevPort.TabIndex = 11;
            // 
            // txtDevIp
            // 
            this.txtDevIp.Location = new System.Drawing.Point(259, 19);
            this.txtDevIp.Name = "txtDevIp";
            this.txtDevIp.Size = new System.Drawing.Size(83, 20);
            this.txtDevIp.TabIndex = 10;
            // 
            // txtDevNo
            // 
            this.txtDevNo.Location = new System.Drawing.Point(71, 19);
            this.txtDevNo.Name = "txtDevNo";
            this.txtDevNo.Size = new System.Drawing.Size(39, 20);
            this.txtDevNo.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Port :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "IP :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Device No. :";
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Gainsboro;
            this.btnNew.Location = new System.Drawing.Point(6, 278);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(70, 23);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(77, 278);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTestConn
            // 
            this.btnTestConn.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTestConn.Enabled = false;
            this.btnTestConn.Location = new System.Drawing.Point(293, 252);
            this.btnTestConn.Name = "btnTestConn";
            this.btnTestConn.Size = new System.Drawing.Size(70, 23);
            this.btnTestConn.TabIndex = 5;
            this.btnTestConn.Text = "&Test Conn.";
            this.btnTestConn.UseVisualStyleBackColor = false;
            this.btnTestConn.Click += new System.EventHandler(this.btnTestConn_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Gainsboro;
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(221, 278);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Gainsboro;
            this.btnClose.Location = new System.Drawing.Point(293, 278);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(12, 257);
            this.lbError.Margin = new System.Windows.Forms.Padding(3, 0, 3, 666);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(0, 13);
            this.lbError.TabIndex = 8;
            this.lbError.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Gainsboro;
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(149, 278);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(70, 23);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // axCZKEM1
            // 
            this.axCZKEM1.Enabled = true;
            this.axCZKEM1.Location = new System.Drawing.Point(451, 137);
            this.axCZKEM1.Name = "axCZKEM1";
            this.axCZKEM1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axCZKEM1.OcxState")));
            this.axCZKEM1.Size = new System.Drawing.Size(192, 192);
            this.axCZKEM1.TabIndex = 10;
            // 
            // frmNewDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(369, 306);
            this.Controls.Add(this.axCZKEM1);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnTestConn);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.grbDeviceIP);
            this.Controls.Add(this.dgvDeviceIps);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewDevice";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Device Details";
            this.Load += new System.EventHandler(this.frmNewDevice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceIps)).EndInit();
            this.grbDeviceIP.ResumeLayout(false);
            this.grbDeviceIP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axCZKEM1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDeviceIps;
        private System.Windows.Forms.GroupBox grbDeviceIP;
        private System.Windows.Forms.TextBox txtDevPort;
        private System.Windows.Forms.TextBox txtDevIp;
        private System.Windows.Forms.TextBox txtDevNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTestConn;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Button btnEdit;
        private Axzkemkeeper.AxCZKEM axCZKEM1;
    }
}