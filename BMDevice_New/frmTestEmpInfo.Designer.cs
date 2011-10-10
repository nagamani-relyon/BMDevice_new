namespace BMDevice_New
{
    partial class frmTestEmpInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestEmpInfo));
            this.btnGetEmpInfo = new System.Windows.Forms.Button();
            this.axCZKEM1 = new Axzkemkeeper.AxCZKEM();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbuserInfo = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbInsert = new System.Windows.Forms.Label();
            this.txtEmpid = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbDeleted = new System.Windows.Forms.Label();
            this.cmbUserId = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.axCZKEM1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetEmpInfo
            // 
            this.btnGetEmpInfo.Location = new System.Drawing.Point(105, 12);
            this.btnGetEmpInfo.Name = "btnGetEmpInfo";
            this.btnGetEmpInfo.Size = new System.Drawing.Size(152, 31);
            this.btnGetEmpInfo.TabIndex = 1;
            this.btnGetEmpInfo.Text = "Get Employee Info";
            this.btnGetEmpInfo.UseVisualStyleBackColor = true;
            this.btnGetEmpInfo.Click += new System.EventHandler(this.btnGetEmpInfo_Click);
            // 
            // axCZKEM1
            // 
            this.axCZKEM1.Enabled = true;
            this.axCZKEM1.Location = new System.Drawing.Point(592, 51);
            this.axCZKEM1.Name = "axCZKEM1";
            this.axCZKEM1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axCZKEM1.OcxState")));
            this.axCZKEM1.Size = new System.Drawing.Size(192, 192);
            this.axCZKEM1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.lbuserInfo);
            this.panel1.Location = new System.Drawing.Point(2, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(354, 420);
            this.panel1.TabIndex = 3;
            // 
            // lbuserInfo
            // 
            this.lbuserInfo.AutoSize = true;
            this.lbuserInfo.Location = new System.Drawing.Point(63, 11);
            this.lbuserInfo.Name = "lbuserInfo";
            this.lbuserInfo.Size = new System.Drawing.Size(0, 13);
            this.lbuserInfo.TabIndex = 0;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(53, 167);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(123, 30);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "Register User";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(53, 66);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(113, 30);
            this.btnDeleteUser.TabIndex = 5;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbInsert);
            this.groupBox1.Controls.Add(this.txtEmpid);
            this.groupBox1.Controls.Add(this.btnRegister);
            this.groupBox1.Location = new System.Drawing.Point(362, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 221);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(90, 121);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(115, 20);
            this.txtPass.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Password : ";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(90, 86);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(115, 20);
            this.txtName.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Name    : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "EMP ID : ";
            // 
            // lbInsert
            // 
            this.lbInsert.AutoSize = true;
            this.lbInsert.Location = new System.Drawing.Point(53, 204);
            this.lbInsert.Name = "lbInsert";
            this.lbInsert.Size = new System.Drawing.Size(0, 13);
            this.lbInsert.TabIndex = 5;
            // 
            // txtEmpid
            // 
            this.txtEmpid.Location = new System.Drawing.Point(90, 43);
            this.txtEmpid.Name = "txtEmpid";
            this.txtEmpid.Size = new System.Drawing.Size(115, 20);
            this.txtEmpid.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbDeleted);
            this.groupBox2.Controls.Add(this.cmbUserId);
            this.groupBox2.Controls.Add(this.btnDeleteUser);
            this.groupBox2.Location = new System.Drawing.Point(362, 310);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 130);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // lbDeleted
            // 
            this.lbDeleted.AutoSize = true;
            this.lbDeleted.Location = new System.Drawing.Point(36, 99);
            this.lbDeleted.Name = "lbDeleted";
            this.lbDeleted.Size = new System.Drawing.Size(0, 13);
            this.lbDeleted.TabIndex = 6;
            // 
            // cmbUserId
            // 
            this.cmbUserId.FormattingEnabled = true;
            this.cmbUserId.Location = new System.Drawing.Point(22, 20);
            this.cmbUserId.Name = "cmbUserId";
            this.cmbUserId.Size = new System.Drawing.Size(183, 21);
            this.cmbUserId.TabIndex = 0;
            // 
            // frmTestEmpInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 474);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.axCZKEM1);
            this.Controls.Add(this.btnGetEmpInfo);
            this.Name = "frmTestEmpInfo";
            this.Text = "frmTestEmpInfo";
            ((System.ComponentModel.ISupportInitialize)(this.axCZKEM1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetEmpInfo;
        private Axzkemkeeper.AxCZKEM axCZKEM1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbuserInfo;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEmpid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbUserId;
        private System.Windows.Forms.Label lbInsert;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbDeleted;
    }
}