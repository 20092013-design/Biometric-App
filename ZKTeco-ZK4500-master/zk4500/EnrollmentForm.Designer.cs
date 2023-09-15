namespace FingerPrint_LT
{
    partial class EnrollmentForm
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
            System.Windows.Forms.Label lblPrompt;
            this.prompt = new System.Windows.Forms.Label();
            this.fpicture = new System.Windows.Forms.PictureBox();
            this.deviceSerial = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gpClientDetails = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAccountID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtBranchID = new System.Windows.Forms.TextBox();
            this.lblBranchID = new System.Windows.Forms.Label();
            this.cboClientTypeID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFingerNo = new System.Windows.Forms.TextBox();
            this.lblClientID = new System.Windows.Forms.Label();
            this.txtClientID = new System.Windows.Forms.TextBox();
            lblPrompt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fpicture)).BeginInit();
            this.gpClientDetails.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPrompt
            // 
            lblPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            lblPrompt.Location = new System.Drawing.Point(42, 347);
            lblPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new System.Drawing.Size(287, 84);
            lblPrompt.TabIndex = 25;
            lblPrompt.Text = "To Enroll your thump print, touch fingerprint reader with any finger.";
            // 
            // prompt
            // 
            this.prompt.AutoSize = true;
            this.prompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prompt.Location = new System.Drawing.Point(148, 443);
            this.prompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.prompt.Name = "prompt";
            this.prompt.Size = new System.Drawing.Size(207, 22);
            this.prompt.TabIndex = 3;
            this.prompt.Text = "Plug in the scanner ...";
            // 
            // fpicture
            // 
            this.fpicture.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpicture.Location = new System.Drawing.Point(29, 33);
            this.fpicture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fpicture.Name = "fpicture";
            this.fpicture.Size = new System.Drawing.Size(320, 300);
            this.fpicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.fpicture.TabIndex = 21;
            this.fpicture.TabStop = false;
            // 
            // deviceSerial
            // 
            this.deviceSerial.AutoSize = true;
            this.deviceSerial.Location = new System.Drawing.Point(682, 527);
            this.deviceSerial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.deviceSerial.Name = "deviceSerial";
            this.deviceSerial.Size = new System.Drawing.Size(109, 20);
            this.deviceSerial.TabIndex = 3;
            this.deviceSerial.Text = "Device Serial: ";
            this.deviceSerial.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(773, 566);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Template: ";
            this.label1.Visible = false;
            // 
            // gpClientDetails
            // 
            this.gpClientDetails.Controls.Add(this.comboBox2);
            this.gpClientDetails.Controls.Add(this.label7);
            this.gpClientDetails.Controls.Add(this.comboBox1);
            this.gpClientDetails.Controls.Add(this.label6);
            this.gpClientDetails.Controls.Add(this.groupBox2);
            this.gpClientDetails.Controls.Add(this.label5);
            this.gpClientDetails.Controls.Add(this.txtProductID);
            this.gpClientDetails.Controls.Add(this.label4);
            this.gpClientDetails.Controls.Add(this.txtAccountID);
            this.gpClientDetails.Controls.Add(this.label3);
            this.gpClientDetails.Controls.Add(this.txtName);
            this.gpClientDetails.Controls.Add(this.txtBranchID);
            this.gpClientDetails.Controls.Add(this.lblBranchID);
            this.gpClientDetails.Controls.Add(this.cboClientTypeID);
            this.gpClientDetails.Controls.Add(this.label2);
            this.gpClientDetails.Controls.Add(this.txtFingerNo);
            this.gpClientDetails.Controls.Add(this.lblClientID);
            this.gpClientDetails.Controls.Add(this.txtClientID);
            this.gpClientDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gpClientDetails.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpClientDetails.Location = new System.Drawing.Point(21, 12);
            this.gpClientDetails.Name = "gpClientDetails";
            this.gpClientDetails.Size = new System.Drawing.Size(908, 494);
            this.gpClientDetails.TabIndex = 23;
            this.gpClientDetails.TabStop = false;
            this.gpClientDetails.Text = "Client Enrollment";
            // 
            // comboBox2
            // 
            this.comboBox2.DisplayMember = "Left";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(131, 346);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(212, 34);
            this.comboBox2.TabIndex = 28;
            this.comboBox2.ValueMember = "Thump,Index,Middle,Ring,Picky";
            this.comboBox2.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(28, 346);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 22);
            this.label7.TabIndex = 27;
            this.label7.Text = "Finger";
            this.label7.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "Left";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(131, 306);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(212, 34);
            this.comboBox1.TabIndex = 26;
            this.comboBox1.ValueMember = "Left,Right";
            this.comboBox1.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(28, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 22);
            this.label6.TabIndex = 25;
            this.label6.Text = "Hand Side";
            this.label6.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(lblPrompt);
            this.groupBox2.Controls.Add(this.fpicture);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(421, 17);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(368, 436);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thump Print";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(28, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 22);
            this.label5.TabIndex = 20;
            this.label5.Text = "Product ID";
            // 
            // txtProductID
            // 
            this.txtProductID.Enabled = false;
            this.txtProductID.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductID.Location = new System.Drawing.Point(131, 229);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(212, 30);
            this.txtProductID.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(28, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 22);
            this.label4.TabIndex = 18;
            this.label4.Text = "Account ID";
            // 
            // txtAccountID
            // 
            this.txtAccountID.AcceptsTab = true;
            this.txtAccountID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtAccountID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAccountID.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.txtAccountID.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountID.Location = new System.Drawing.Point(131, 193);
            this.txtAccountID.Name = "txtAccountID";
            this.txtAccountID.Size = new System.Drawing.Size(212, 30);
            this.txtAccountID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(65, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 22);
            this.label3.TabIndex = 16;
            this.label3.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(131, 265);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(212, 30);
            this.txtName.TabIndex = 3;
            // 
            // txtBranchID
            // 
            this.txtBranchID.Enabled = false;
            this.txtBranchID.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchID.Location = new System.Drawing.Point(131, 85);
            this.txtBranchID.Name = "txtBranchID";
            this.txtBranchID.Size = new System.Drawing.Size(212, 30);
            this.txtBranchID.TabIndex = 0;
            // 
            // lblBranchID
            // 
            this.lblBranchID.AutoSize = true;
            this.lblBranchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranchID.ForeColor = System.Drawing.Color.Blue;
            this.lblBranchID.Location = new System.Drawing.Point(36, 87);
            this.lblBranchID.Name = "lblBranchID";
            this.lblBranchID.Size = new System.Drawing.Size(89, 22);
            this.lblBranchID.TabIndex = 13;
            this.lblBranchID.Text = "Branch ID";
            // 
            // cboClientTypeID
            // 
            this.cboClientTypeID.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClientTypeID.FormattingEnabled = true;
            this.cboClientTypeID.Location = new System.Drawing.Point(131, 121);
            this.cboClientTypeID.Name = "cboClientTypeID";
            this.cboClientTypeID.Size = new System.Drawing.Size(212, 30);
            this.cboClientTypeID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(1, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 22);
            this.label2.TabIndex = 11;
            this.label2.Text = "Client Type ID";
            // 
            // txtFingerNo
            // 
            this.txtFingerNo.Enabled = false;
            this.txtFingerNo.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFingerNo.Location = new System.Drawing.Point(4, 389);
            this.txtFingerNo.Name = "txtFingerNo";
            this.txtFingerNo.Size = new System.Drawing.Size(96, 30);
            this.txtFingerNo.TabIndex = 4;
            this.txtFingerNo.Visible = false;
            // 
            // lblClientID
            // 
            this.lblClientID.AutoSize = true;
            this.lblClientID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientID.ForeColor = System.Drawing.Color.Blue;
            this.lblClientID.Location = new System.Drawing.Point(47, 157);
            this.lblClientID.Name = "lblClientID";
            this.lblClientID.Size = new System.Drawing.Size(78, 22);
            this.lblClientID.TabIndex = 5;
            this.lblClientID.Text = "Client ID";
            // 
            // txtClientID
            // 
            this.txtClientID.AcceptsTab = true;
            this.txtClientID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtClientID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtClientID.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.txtClientID.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientID.Location = new System.Drawing.Point(131, 157);
            this.txtClientID.Name = "txtClientID";
            this.txtClientID.Size = new System.Drawing.Size(212, 30);
            this.txtClientID.TabIndex = 2;
            // 
            // EnrollmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(941, 577);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deviceSerial);
            this.Controls.Add(this.prompt);
            this.Controls.Add(this.gpClientDetails);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EnrollmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FingerPrint_LT";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpicture)).EndInit();
            this.gpClientDetails.ResumeLayout(false);
            this.gpClientDetails.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label prompt;
        private System.Windows.Forms.PictureBox fpicture;
        private System.Windows.Forms.Label deviceSerial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpClientDetails;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAccountID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtBranchID;
        private System.Windows.Forms.Label lblBranchID;
        private System.Windows.Forms.ComboBox cboClientTypeID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFingerNo;
        private System.Windows.Forms.Label lblClientID;
        private System.Windows.Forms.TextBox txtClientID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
    }
}

