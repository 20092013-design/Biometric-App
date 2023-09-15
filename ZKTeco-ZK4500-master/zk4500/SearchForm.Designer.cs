namespace FingerPrint_LT
{
    partial class SearchForm
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
            this.gdSearchForm = new System.Windows.Forms.DataGridView();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gdSearchForm)).BeginInit();
            this.SuspendLayout();
            // 
            // gdSearchForm
            // 
            this.gdSearchForm.AllowUserToAddRows = false;
            this.gdSearchForm.AllowUserToDeleteRows = false;
            this.gdSearchForm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdSearchForm.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.gdSearchForm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gdSearchForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdSearchForm.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.gdSearchForm.Location = new System.Drawing.Point(13, 90);
            this.gdSearchForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gdSearchForm.Name = "gdSearchForm";
            this.gdSearchForm.ReadOnly = true;
            this.gdSearchForm.RowHeadersWidth = 62;
            this.gdSearchForm.Size = new System.Drawing.Size(524, 363);
            this.gdSearchForm.TabIndex = 18;
            this.gdSearchForm.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdSearchForm_CellDoubleClick);
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchValue.Location = new System.Drawing.Point(140, 36);
            this.txtSearchValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(316, 30);
            this.txtSearchValue.TabIndex = 27;
            this.txtSearchValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchValue_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(76, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 22);
            this.label2.TabIndex = 28;
            this.label2.Text = "Value";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(567, 472);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearchValue);
            this.Controls.Add(this.gdSearchForm);
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdSearchForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gdSearchForm;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.Label label2;
    }
}