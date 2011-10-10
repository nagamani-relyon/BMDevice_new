namespace BMDevice_New
{
    partial class frmBMDeviceMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBMDeviceMain));
            this.lbTimer = new System.Windows.Forms.Label();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.btnChange = new System.Windows.Forms.Button();
            this.pnlrdbn = new System.Windows.Forms.Panel();
            this.rdbnEmpId = new System.Windows.Forms.RadioButton();
            this.rdbnRefNo = new System.Windows.Forms.RadioButton();
            this.rdbnCardId = new System.Windows.Forms.RadioButton();
            this.lbError = new System.Windows.Forms.Label();
            this.txtTimer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lbRunStatus = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnMapUrl = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNewDevice = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.lbinserted = new System.Windows.Forms.Label();
            this.lbRead = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axCZKEM1 = new Axzkemkeeper.AxCZKEM();
            this.pnlSettings.SuspendLayout();
            this.pnlrdbn.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axCZKEM1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTimer
            // 
            this.lbTimer.AutoSize = true;
            this.lbTimer.Location = new System.Drawing.Point(88, 8);
            this.lbTimer.Name = "lbTimer";
            this.lbTimer.Size = new System.Drawing.Size(157, 13);
            this.lbTimer.TabIndex = 2;
            this.lbTimer.Text = "Starts Reading in 00:00 minutes";
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSettings.Controls.Add(this.btnChange);
            this.pnlSettings.Controls.Add(this.pnlrdbn);
            this.pnlSettings.Controls.Add(this.lbError);
            this.pnlSettings.Controls.Add(this.txtTimer);
            this.pnlSettings.Controls.Add(this.label6);
            this.pnlSettings.Controls.Add(this.btnSave);
            this.pnlSettings.Controls.Add(this.label1);
            this.pnlSettings.Location = new System.Drawing.Point(6, 6);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(355, 66);
            this.pnlSettings.TabIndex = 1;
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.Gainsboro;
            this.btnChange.Location = new System.Drawing.Point(192, 34);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 9;
            this.btnChange.Text = "&Change";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // pnlrdbn
            // 
            this.pnlrdbn.Controls.Add(this.rdbnEmpId);
            this.pnlrdbn.Controls.Add(this.rdbnRefNo);
            this.pnlrdbn.Controls.Add(this.rdbnCardId);
            this.pnlrdbn.Enabled = false;
            this.pnlrdbn.Location = new System.Drawing.Point(107, 8);
            this.pnlrdbn.Name = "pnlrdbn";
            this.pnlrdbn.Size = new System.Drawing.Size(237, 22);
            this.pnlrdbn.TabIndex = 1;
            // 
            // rdbnEmpId
            // 
            this.rdbnEmpId.AutoSize = true;
            this.rdbnEmpId.Checked = true;
            this.rdbnEmpId.Location = new System.Drawing.Point(3, 3);
            this.rdbnEmpId.Name = "rdbnEmpId";
            this.rdbnEmpId.Size = new System.Drawing.Size(58, 17);
            this.rdbnEmpId.TabIndex = 1;
            this.rdbnEmpId.TabStop = true;
            this.rdbnEmpId.Text = "Emp Id";
            this.rdbnEmpId.UseVisualStyleBackColor = true;
            // 
            // rdbnRefNo
            // 
            this.rdbnRefNo.AutoSize = true;
            this.rdbnRefNo.Location = new System.Drawing.Point(85, 3);
            this.rdbnRefNo.Name = "rdbnRefNo";
            this.rdbnRefNo.Size = new System.Drawing.Size(62, 17);
            this.rdbnRefNo.TabIndex = 2;
            this.rdbnRefNo.Text = "Ref. No";
            this.rdbnRefNo.UseVisualStyleBackColor = true;
            // 
            // rdbnCardId
            // 
            this.rdbnCardId.AutoSize = true;
            this.rdbnCardId.Location = new System.Drawing.Point(175, 3);
            this.rdbnCardId.Name = "rdbnCardId";
            this.rdbnCardId.Size = new System.Drawing.Size(59, 17);
            this.rdbnCardId.TabIndex = 3;
            this.rdbnCardId.Text = "Card Id";
            this.rdbnCardId.UseVisualStyleBackColor = true;
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(105, 59);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(0, 13);
            this.lbError.TabIndex = 8;
            // 
            // txtTimer
            // 
            this.txtTimer.Enabled = false;
            this.txtTimer.Location = new System.Drawing.Point(107, 36);
            this.txtTimer.Name = "txtTimer";
            this.txtTimer.Size = new System.Drawing.Size(76, 20);
            this.txtTimer.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Time Interval      :";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(273, 34);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "S&ave";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Refer Emp Id As : ";
            // 
            // pnlStatus
            // 
            this.pnlStatus.AutoScroll = true;
            this.pnlStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.lbRunStatus);
            this.pnlStatus.Location = new System.Drawing.Point(6, 150);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(355, 242);
            this.pnlStatus.TabIndex = 2;
            // 
            // lbRunStatus
            // 
            this.lbRunStatus.AutoSize = true;
            this.lbRunStatus.Location = new System.Drawing.Point(10, 10);
            this.lbRunStatus.Name = "lbRunStatus";
            this.lbRunStatus.Size = new System.Drawing.Size(121, 13);
            this.lbRunStatus.TabIndex = 0;
            this.lbRunStatus.Text = "Application Run Status :";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(367, 367);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlButtons.Controls.Add(this.btnMapUrl);
            this.pnlButtons.Controls.Add(this.btnStart);
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnAddNewDevice);
            this.pnlButtons.Location = new System.Drawing.Point(-1, 397);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(369, 28);
            this.pnlButtons.TabIndex = 3;
            // 
            // btnMapUrl
            // 
            this.btnMapUrl.BackColor = System.Drawing.Color.Gainsboro;
            this.btnMapUrl.Location = new System.Drawing.Point(112, 3);
            this.btnMapUrl.Name = "btnMapUrl";
            this.btnMapUrl.Size = new System.Drawing.Size(100, 23);
            this.btnMapUrl.TabIndex = 3;
            this.btnMapUrl.Text = "Map &Url->Device";
            this.btnMapUrl.UseVisualStyleBackColor = false;
            this.btnMapUrl.Click += new System.EventHandler(this.btnMapUrl_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Gainsboro;
            this.btnStart.Location = new System.Drawing.Point(218, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(64, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Gainsboro;
            this.btnClose.Location = new System.Drawing.Point(288, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddNewDevice
            // 
            this.btnAddNewDevice.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAddNewDevice.Location = new System.Drawing.Point(7, 3);
            this.btnAddNewDevice.Name = "btnAddNewDevice";
            this.btnAddNewDevice.Size = new System.Drawing.Size(97, 23);
            this.btnAddNewDevice.TabIndex = 0;
            this.btnAddNewDevice.Text = "&Manage Devices";
            this.btnAddNewDevice.UseVisualStyleBackColor = false;
            this.btnAddNewDevice.Click += new System.EventHandler(this.btnAddNewDevice_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbTimer);
            this.panel1.Location = new System.Drawing.Point(6, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 29);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Web URL :";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Company   :";
            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlDetails.Controls.Add(this.label3);
            this.pnlDetails.Controls.Add(this.label2);
            this.pnlDetails.Location = new System.Drawing.Point(377, 65);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(67, 50);
            this.pnlDetails.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.lbinserted);
            this.panel2.Controls.Add(this.lbRead);
            this.panel2.Location = new System.Drawing.Point(6, 109);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(355, 36);
            this.panel2.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gainsboro;
            this.button2.Location = new System.Drawing.Point(127, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Save &Records";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbinserted
            // 
            this.lbinserted.AutoSize = true;
            this.lbinserted.Location = new System.Drawing.Point(235, 11);
            this.lbinserted.Name = "lbinserted";
            this.lbinserted.Size = new System.Drawing.Size(95, 13);
            this.lbinserted.TabIndex = 1;
            this.lbinserted.Text = "Inseted records : 0";
            // 
            // lbRead
            // 
            this.lbRead.AutoSize = true;
            this.lbRead.Location = new System.Drawing.Point(10, 11);
            this.lbRead.Name = "lbRead";
            this.lbRead.Size = new System.Drawing.Size(86, 13);
            this.lbRead.TabIndex = 0;
            this.lbRead.Text = "Read records : 0";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipTitle = "Relyon BM Device Reader";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Relyon BM Device Reader";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(115, 70);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // axCZKEM1
            // 
            this.axCZKEM1.Enabled = true;
            this.axCZKEM1.Location = new System.Drawing.Point(377, 130);
            this.axCZKEM1.Name = "axCZKEM1";
            this.axCZKEM1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axCZKEM1.OcxState")));
            this.axCZKEM1.Size = new System.Drawing.Size(192, 192);
            this.axCZKEM1.TabIndex = 6;
            // 
            // frmBMDeviceMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(367, 428);
            this.Controls.Add(this.axCZKEM1);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBMDeviceMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relyon BM Device Reader 1.00";
            this.Load += new System.EventHandler(this.frmBMDeviceMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBMDeviceMain_FormClosing);
            this.Resize += new System.EventHandler(this.frmBMDeviceMain_Resize);
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.pnlrdbn.ResumeLayout(false);
            this.pnlrdbn.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axCZKEM1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnAddNewDevice;
        private System.Windows.Forms.Button btnMapUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbnCardId;
        private System.Windows.Forms.RadioButton rdbnRefNo;
        private System.Windows.Forms.RadioButton rdbnEmpId;
        private System.Windows.Forms.Label lbTimer;
        private System.Windows.Forms.Label lbRunStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTimer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Panel pnlrdbn;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        //private Axzkemkeeper.AxCZKEM axCZKEM1;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbinserted;
        private System.Windows.Forms.Label lbRead;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private Axzkemkeeper.AxCZKEM axCZKEM1;
    }
}

