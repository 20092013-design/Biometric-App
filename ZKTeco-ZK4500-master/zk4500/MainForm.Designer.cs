using FingerPrint_LT.Properties;

namespace FingerPrint_LT
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lblMessageDetails = new System.Windows.Forms.Label();
            this.MenuStrip2 = new System.Windows.Forms.MenuStrip();
            this.btnEnrollment = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSupervision = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoanApproval = new System.Windows.Forms.ToolStripMenuItem();
            this.verificationHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cashTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gdBiometricDetail = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cboClientTypeID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSearchID = new System.Windows.Forms.ComboBox();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboImageTypeID = new System.Windows.Forms.ComboBox();
            this.lblImageType = new System.Windows.Forms.Label();
            this.gbData = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.MenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdBiometricDetail)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbData.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessageDetails
            // 
            this.lblMessageDetails.AutoSize = true;
            this.lblMessageDetails.Location = new System.Drawing.Point(66, 640);
            this.lblMessageDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessageDetails.Name = "lblMessageDetails";
            this.lblMessageDetails.Size = new System.Drawing.Size(0, 20);
            this.lblMessageDetails.TabIndex = 3;
            // 
            // MenuStrip2
            // 
            this.MenuStrip2.AutoSize = false;
            this.MenuStrip2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MenuStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MenuStrip2.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.MenuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEnrollment,
            this.btnSupervision,
            this.btnEdit,
            this.tsExit,
            this.btnLoanApproval,
            this.verificationHistoryToolStripMenuItem,
            this.cashTransactionToolStripMenuItem});
            this.MenuStrip2.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip2.Name = "MenuStrip2";
            this.MenuStrip2.Size = new System.Drawing.Size(1456, 92);
            this.MenuStrip2.TabIndex = 14;
            this.MenuStrip2.Text = "MenuStrip2";
            // 
            // btnEnrollment
            // 
            this.btnEnrollment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnrollment.Image = global::FingerPrint_LT.Properties.Resources.enrollment;
            this.btnEnrollment.Name = "btnEnrollment";
            this.btnEnrollment.Size = new System.Drawing.Size(121, 88);
            this.btnEnrollment.Text = "Enrollment";
            this.btnEnrollment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEnrollment.Click += new System.EventHandler(this.tspEmployeeProfile_Click);
            // 
            // btnSupervision
            // 
            this.btnSupervision.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupervision.Image = ((System.Drawing.Image)(resources.GetObject("btnSupervision.Image")));
            this.btnSupervision.Name = "btnSupervision";
            this.btnSupervision.Size = new System.Drawing.Size(131, 88);
            this.btnSupervision.Text = "Supervision";
            this.btnSupervision.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSupervision.Click += new System.EventHandler(this.btnSupervision_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(166, 88);
            this.btnEdit.Text = "Edit FingerPrint";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // tsExit
            // 
            this.tsExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsExit.Image = ((System.Drawing.Image)(resources.GetObject("tsExit.Image")));
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(97, 88);
            this.tsExit.Text = "Log Out";
            this.tsExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsExit.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // btnLoanApproval
            // 
            this.btnLoanApproval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnLoanApproval.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoanApproval.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLoanApproval.Name = "btnLoanApproval";
            this.btnLoanApproval.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnLoanApproval.RightToLeftAutoMirrorImage = true;
            this.btnLoanApproval.Size = new System.Drawing.Size(248, 88);
            this.btnLoanApproval.Text = "Loan Approval/Guarantor";
            this.btnLoanApproval.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLoanApproval.Visible = false;
            this.btnLoanApproval.Click += new System.EventHandler(this.loanApprovalGuarantorToolStripMenuItem_Click);
            // 
            // verificationHistoryToolStripMenuItem
            // 
            this.verificationHistoryToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.verificationHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.verificationHistoryToolStripMenuItem.Name = "verificationHistoryToolStripMenuItem";
            this.verificationHistoryToolStripMenuItem.Size = new System.Drawing.Size(186, 88);
            this.verificationHistoryToolStripMenuItem.Text = "Verification history";
            this.verificationHistoryToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.verificationHistoryToolStripMenuItem.Visible = false;
            this.verificationHistoryToolStripMenuItem.Click += new System.EventHandler(this.verificationHistoryToolStripMenuItem_Click);
            // 
            // cashTransactionToolStripMenuItem
            // 
            this.cashTransactionToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashTransactionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cashTransactionToolStripMenuItem.Image")));
            this.cashTransactionToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cashTransactionToolStripMenuItem.Name = "cashTransactionToolStripMenuItem";
            this.cashTransactionToolStripMenuItem.Size = new System.Drawing.Size(172, 88);
            this.cashTransactionToolStripMenuItem.Text = "Cash Transaction";
            this.cashTransactionToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cashTransactionToolStripMenuItem.Click += new System.EventHandler(this.cashTransactionToolStripMenuItem_Click);
            // 
            // gdBiometricDetail
            // 
            this.gdBiometricDetail.AllowUserToAddRows = false;
            this.gdBiometricDetail.AllowUserToDeleteRows = false;
            this.gdBiometricDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdBiometricDetail.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.gdBiometricDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gdBiometricDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdBiometricDetail.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.gdBiometricDetail.Location = new System.Drawing.Point(24, 33);
            this.gdBiometricDetail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gdBiometricDetail.Name = "gdBiometricDetail";
            this.gdBiometricDetail.ReadOnly = true;
            this.gdBiometricDetail.RowHeadersWidth = 62;
            this.gdBiometricDetail.Size = new System.Drawing.Size(1282, 496);
            this.gdBiometricDetail.TabIndex = 17;
            this.gdBiometricDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdBiometricDetail_CellContentClick);
            this.gdBiometricDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdBiometricDetail_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(60, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 22);
            this.label1.TabIndex = 20;
            this.label1.Text = "Search";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cboClientTypeID
            // 
            this.cboClientTypeID.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClientTypeID.FormattingEnabled = true;
            this.cboClientTypeID.Location = new System.Drawing.Point(197, 59);
            this.cboClientTypeID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboClientTypeID.Name = "cboClientTypeID";
            this.cboClientTypeID.Size = new System.Drawing.Size(316, 30);
            this.cboClientTypeID.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(26, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 22);
            this.label2.TabIndex = 22;
            this.label2.Text = "Client Type ID";
            // 
            // cmbSearchID
            // 
            this.cmbSearchID.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchID.FormattingEnabled = true;
            this.cmbSearchID.Items.AddRange(new object[] {
            "ClientID",
            "Name",
            "AccountID"});
            this.cmbSearchID.Location = new System.Drawing.Point(197, 93);
            this.cmbSearchID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSearchID.Name = "cmbSearchID";
            this.cmbSearchID.Size = new System.Drawing.Size(316, 30);
            this.cmbSearchID.TabIndex = 23;
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchValue.Location = new System.Drawing.Point(512, 92);
            this.txtSearchValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(472, 30);
            this.txtSearchValue.TabIndex = 24;
            this.txtSearchValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchValue_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboImageTypeID);
            this.groupBox1.Controls.Add(this.lblImageType);
            this.groupBox1.Controls.Add(this.txtSearchValue);
            this.groupBox1.Controls.Add(this.cmbSearchID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboClientTypeID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(414, 98);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(992, 132);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // cboImageTypeID
            // 
            this.cboImageTypeID.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboImageTypeID.FormattingEnabled = true;
            this.cboImageTypeID.Location = new System.Drawing.Point(197, 25);
            this.cboImageTypeID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboImageTypeID.Name = "cboImageTypeID";
            this.cboImageTypeID.Size = new System.Drawing.Size(316, 30);
            this.cboImageTypeID.TabIndex = 25;
            this.cboImageTypeID.SelectedIndexChanged += new System.EventHandler(this.cboImageTypeID_SelectedIndexChanged);
            // 
            // lblImageType
            // 
            this.lblImageType.AutoSize = true;
            this.lblImageType.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageType.ForeColor = System.Drawing.Color.Black;
            this.lblImageType.Location = new System.Drawing.Point(26, 28);
            this.lblImageType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImageType.Name = "lblImageType";
            this.lblImageType.Size = new System.Drawing.Size(101, 22);
            this.lblImageType.TabIndex = 26;
            this.lblImageType.Text = "Image Type";
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.gdBiometricDetail);
            this.gbData.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbData.Location = new System.Drawing.Point(0, 262);
            this.gbData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbData.Name = "gbData";
            this.gbData.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbData.Size = new System.Drawing.Size(1417, 597);
            this.gbData.TabIndex = 27;
            this.gbData.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(70, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(223, 66);
            this.button1.TabIndex = 28;
            this.button1.Text = "Verify";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1456, 1039);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MenuStrip2);
            this.Controls.Add(this.lblMessageDetails);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bugadde";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MenuStrip2.ResumeLayout(false);
            this.MenuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdBiometricDetail)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbData.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
		private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Label lblMessageDetails;
        internal System.Windows.Forms.MenuStrip MenuStrip2;
        internal System.Windows.Forms.ToolStripMenuItem btnEnrollment;
        internal System.Windows.Forms.ToolStripMenuItem btnSupervision;
        internal System.Windows.Forms.ToolStripMenuItem tsExit;
        private System.Windows.Forms.DataGridView gdBiometricDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboClientTypeID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSearchID;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem btnEdit;
        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.ToolStripMenuItem btnLoanApproval;
        private System.Windows.Forms.ToolStripMenuItem verificationHistoryToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboImageTypeID;
        private System.Windows.Forms.Label lblImageType;
        private System.Windows.Forms.ToolStripMenuItem cashTransactionToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}

