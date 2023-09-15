using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Management;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml.Linq;
using FingerPrint_LT.Model;
using FingerPrint_LT.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace FingerPrint_LT
{
    public partial class Login : Form
    {
        Service service = new Service();
        public Login()
        {
            #region InitializeComponent
            InitializeComponent();
            //service.GetLogo();
           // pbLogo.Image = service.ConvertToImage();
            txtWorkingDate.Enabled = false;
          
            try
            {
           
            
            service.GeneralFill(cmbBranchID, service.BindBranchID(),"OurBranchID", "BranchName");
           
                cmbBranchID.SelectedIndex = 1;
                //DataRow[] dr = AppData.SystemBranchStatus.Select("OurBranchID = " + cmbBranchID.SelectedValue.ToString());
                //txtWorkingDate.Text = Convert.ToDateTime(dr[0]["SODDate"]).ToString("yyyy-MM-dd");
                var date =DateTime.Now;
                txtWorkingDate.Text = Convert.ToDateTime(date).ToString("yyyy-MM-dd");
                AppData.BranchID = cmbBranchID.SelectedValue.ToString();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            this.BackColor = ColorTranslator.FromHtml("#FDFFB8");
            gbLogin.BackColor = ColorTranslator.FromHtml("#FDFFB8");
            //Login.BackColor = ColorTranslator.FromHtml("#FDFFB8");
           // MenuStrip2.BackColor = ColorTranslator.FromHtml("#FDFFB8");
            #endregion
        }

        #region Login
        class OvalPictureBox : PictureBox
        {
            public OvalPictureBox()
            {
                this.BackColor = Color.DarkGray;
            }
            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);
                using (var gp = new GraphicsPath())
                {
                    gp.AddEllipse(new Rectangle(0, 0, this.Width - 1, this.Height - 1));
                    this.Region = new Region(gp);
                }
            }

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (cmbBranchID.Text == string.Empty)
            {
                MessageBox.Show("Please Select Login Branch");
                return;
            }else if (txtUserName.Text == string.Empty)
            {
                MessageBox.Show("User name field cannot be empty");
                return;
            }
            
            service.loginDetails(txtUserName.Text, txtPassword.Text);

            if (ServiceField.ErrorMessage == string.Empty)
            {
                GetOperatorID.UserID = txtUserName.Text;
                GetOperatorID.OperatorID = txtUserName.Text;
                AppData.BranchName = cmbBranchID.Text;
                GetOperatorID.BranchName = cmbBranchID.Text;
                AppData.BranchID = cmbBranchID.SelectedValue.ToString();
                GetOperatorID.VerificationBranchID = cmbBranchID.SelectedValue.ToString();
                this.Hide();
                
                    new MainForm().Show();
                // this.Dispose();
            }
            else
            {
                MessageBox.Show(ServiceField.ErrorMessage);
                txtPassword.Text = string.Empty;
            }
        }
        

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            service.loginDetails(txtUserName.Text, txtPassword.Text);
           
            if (ServiceField.ErrorMessage == string.Empty)
            {
                this.Hide();
                GetOperatorID.UserID = txtUserName.Text;
                GetOperatorID.OperatorID = txtUserName.Text;
                new MainForm().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(ServiceField.ErrorMessage);
                Application.Exit();
            }
        }

        private void cmbBranchID_SelectionChangeCommitted(object sender, EventArgs e)
        {
           

            DataRow[] dr = AppData.SystemBranchStatus.Select("OurBranchID = " + cmbBranchID.SelectedValue.ToString());
            txtWorkingDate.Text= Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"); ;//Convert.ToDateTime(dr[0]["SODDate"]).ToString("yyyy-MM-dd");
            AppData.BranchID = cmbBranchID.SelectedValue.ToString();
            GetOperatorID.VerificationBranchID = cmbBranchID.SelectedValue.ToString();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void gbLogin_Enter(object sender, EventArgs e)
        {

        }
    }
}
