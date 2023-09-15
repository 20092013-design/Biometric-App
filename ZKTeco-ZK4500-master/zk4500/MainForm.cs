using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using FingerPrint_LT.Model;
using FingerPrint_LT.Services;

namespace FingerPrint_LT {

  // The main application form.
  public partial class MainForm : Form {

     Service service = new Service();

    public MainForm()
    {
            #region InitializeComponent  

            GetOperatorID.Verify = false;
            GetOperatorID.GetPhoto = false;
            GetOperatorID.LocalIPAddress =GetLocalIPAddress();
          Data = new AppData();                             // Create the application data object
                                                            //Data.OnChange += delegate { ExchangeData(false); };	// Track data changes to keep the form synchronized
                                                            //ExchangeData(false);

            if (GetOperatorID.Level == "V")
            {
                service.GetUserDetails();

                //SqlConnection oConnection
                //              = AppData.ConnectionString();
                //oConnection.Open();
                //try
                //{
                //    SqlCommand oCommand = new SqlCommand(
                //      "SELECT TOP 1 OurBranchID, IpAddress,AccountID,ComputerName,ClientID,OperatorID FROM dbo.t_BiometricIPAddress " +
                //      " WHERE Verified = 0 AND OperatorID = '" + GetOperatorID.OperatorID +
                //      "' ORDER BY RowID Desc,CreatedOn Desc ",
                //      oConnection);
                //    SqlDataReader objReader = oCommand.ExecuteReader();
                //    try
                //    {
                //        while (objReader.Read())
                //        {

                //            GetOperatorID.OperatorIDFromDB = objReader["OperatorID"].ToString();
                //            GetOperatorID.AccountID = objReader["AccountID"].ToString();
                //            GetOperatorID.ClientName = objReader["ComputerName"].ToString();
                //            GetOperatorID.ClientID = objReader["ClientID"].ToString();
                //            GetOperatorID.AccountName = objReader["ComputerName"].ToString();
                //            GetOperatorID.LocalIPAddress = objReader["OperatorID"].ToString();
                //            GetOperatorID.Level = "PS";

                //        }


                //    }
                //    finally
                //    {
                //        objReader.Close();
                //    }
                //}
                //finally
                //{
                //    oConnection.Close();
                //}
                InitializeComponent();
                groupBox1.Visible = false;
                gbData.Visible = false;
                MenuStrip2.Visible = false;

                GetOperatorID.Level = "PS";
                GetOperatorID.Verify = true;
                button1.Visible = true;
                new VerificationForm(Data).ShowDialog(); 
                
                // process verification
            }
            else
            {
            InitializeComponent();

            service.GeneralFill(cboClientTypeID, service.GeneralSearch("SystemSubCodeID", "ID='ClientTypeID'"), "SubCodeID", "Description");


            service.GeneralFill(cboImageTypeID, service.GeneralSearch("SystemSubCodeID", "ID='ImageTypeID'"), "SubCodeID", "Description");

            GetOperatorID.cboImageTypeID = cboImageTypeID.SelectedValue.ToString();
                cboImageTypeID.SelectedIndex = 0;
            cboClientTypeID.SelectedIndex = 4;
            cmbSearchID.SelectedIndex = 0;

            gbData.Location = new Point(
            this.ClientSize.Width / 2 - gbData.Size.Width / 2,
            this.ClientSize.Height / 2 - gbData.Size.Height / 2);
            gbData.Anchor = AnchorStyles.None;

            gdBiometricDetail.Location = new Point(
            gbData.Width / 2 - gdBiometricDetail.Size.Width / 2,
            gbData.Height / 2 - gdBiometricDetail.Size.Height / 2);
            gdBiometricDetail.Anchor = AnchorStyles.None;
            gdBiometricDetail.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            gdBiometricDetail.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gdBiometricDetail.ColumnHeadersDefaultCellStyle.Font = new Font(gdBiometricDetail.ColumnHeadersDefaultCellStyle.Font, FontStyle.Regular);
           // gdBiometricDetail.Columns[0].HeaderCell.Style.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            gdBiometricDetail.EnableHeadersVisualStyles = false;


            btnSupervision_Click(null, null);
           
        }
            this.BackColor = ColorTranslator.FromHtml("#FDFFB8");
            groupBox1.BackColor = ColorTranslator.FromHtml("#FDFFB8");
            gbData.BackColor = ColorTranslator.FromHtml("#FDFFB8");
            MenuStrip2.BackColor = ColorTranslator.FromHtml("#FDFFB8");


            #endregion
        }

        #region MainForm

        SqlConnection conn = AppData.ConnectionString();

        public string GetData(string apiPath, Object urlParameter)
        {
            string result = "";
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(AppData.GetBaseUrl());
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.PostAsJsonAsync(apiPath, urlParameter).Result;

            using (HttpContent content = response.Content)
            {
                if (response.IsSuccessStatusCode)
                {
                    result = content.ReadAsStringAsync().Result;
                }
            }
            return result;
        }
        public static string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        throw new Exception(System.Environment.MachineName);
    }

        // Simple dialog data exchange (DDX) implementation.
   private void ExchangeData(bool read) {
      if (read) {	// read values from the form's controls to the data object
        Data.EnrolledFingersMask = 0;
        Data.MaxEnrollFingerCount = 5;
        Data.Update();
      } else {	// read valuse from the data object to the form's controls
        //Mask.Value = Data.EnrolledFingersMask;
        //MaxFingers.Value = Data.MaxEnrollFingerCount;
      }
    }

       
    private void EnrollButton_Click(object sender, EventArgs e) {
      ExchangeData(true);       // transfer values from the main form to the data object
       service.AddEditBiometricAunth();
      if(lblMessageDetails.Text!="")
        {
            return;
        }
      //Enroller.ShowDialog();	// process enrollment
    }

    private void VerifyButton_Click(object sender, EventArgs e) {
      ExchangeData(true);       // transfer values from the main form to the data object
      service.AddEditBiometricAunth();
      if (lblMessageDetails.Text != "")
      {
        return;
      }
          //Verifier.ShowDialog();	// process verification
    }

    private void QuitButton_Click(object sender, EventArgs e) {

            Application.Exit();
        }

    private AppData Data;					// keeps application-wide data
    //private EnrollmentForm Enroller;
    //private VerificationForm Verifier;
        #endregion

  
        private void mnuCaptureUsers_Click(object sender, EventArgs e)
         {
             try
             {
                 //Enroller = new EnrollmentForm(Data);
                 //Enroller.ShowDialog();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message.ToString());
             }
        }

        private void mnuCaptureCustomers_Click(object sender, EventArgs e)
        {
            btnEnrollment.BackColor = Color.LightGreen;
             try
             {

                new Form1();
                //Enroller = new EnrollmentForm(Data);
                //Enroller.ShowDialog();
            }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message.ToString());
             }
        }
        

        private void tsExit_Click(object sender, EventArgs e)
        {
            Application.Restart();  
            //Application.Exit();
        }

        private void tspEmployeeProfile_Click(object sender, EventArgs e)
        {

            btnEnrollment.BackColor = Color.LightGreen;
            btnEdit.BackColor = default(Color);
            btnSupervision.BackColor = default(Color);
            AppData.BiometricStatusID = "PE";

            GetOperatorID.cboImageTypeID = cboImageTypeID.SelectedValue.ToString();
            if (cmbSearchID.Text != string.Empty)

                service.RefreshBiomtric(gdBiometricDetail, AppData.BiometricStatusID, cmbSearchID.Text, cboClientTypeID.SelectedValue.ToString(), txtSearchValue.Text);
        }

        private void btnSupervision_Click(object sender, EventArgs e)
        {
            btnSupervision.BackColor = Color.LightGreen;
            btnEdit.BackColor = default(Color);
            btnEnrollment.BackColor = default(Color);
            
            GetOperatorID.cboImageTypeID = cboImageTypeID.SelectedValue.ToString();
            AppData.BiometricStatusID = "PS";
            if (cmbSearchID.Text != string.Empty)
                service.RefreshBiomtric(gdBiometricDetail, AppData.BiometricStatusID, cmbSearchID.Text, cboClientTypeID.SelectedValue.ToString(), txtSearchValue.Text);
        }

        private void txtSearchValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetOperatorID.cboImageTypeID = cboImageTypeID.SelectedValue.ToString();
                service.RefreshBiomtric(gdBiometricDetail, AppData.BiometricStatusID, cmbSearchID.Text, cboClientTypeID.SelectedValue.ToString(), txtSearchValue.Text);
        
            }
        }

        private void gdBiometricDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                GetOperatorID.Level = string.Empty;
                if (e.RowIndex < 0)
                {
                    return;
                }
                GetOperatorID.cboImageTypeID = cboImageTypeID.SelectedValue.ToString();
                if (gdBiometricDetail.SelectedCells.Count > 0)
                {
                    int selectedrowindex = e.RowIndex;

                    gdBiometricDetail.Rows[selectedrowindex].Selected = true;

                    DataGridViewRow selectedRow = gdBiometricDetail.Rows[selectedrowindex];

                    GetOperatorID.Level = AppData.BiometricStatusID;

                    if  (GetOperatorID.Level == "PG")
                    {
                        GetOperatorID.ClientID = Convert.ToString(selectedRow.Cells["GuarantorID"].Value);
                        GetOperatorID.AccountID = Convert.ToString(selectedRow.Cells["ApplicationID"].Value);
                        GetOperatorID.GuarantorID = Convert.ToString(selectedRow.Cells["GuarantorID"].Value);
                        GetOperatorID.ApplicationID = Convert.ToString(selectedRow.Cells["ApplicationID"].Value);
                        GetOperatorID.ClientType = "G";
                        GetOperatorID.ClientName = Convert.ToString(selectedRow.Cells["GuaranterName"].Value);
                    }
                    else
                    {

                        GetOperatorID.ClientID = Convert.ToString(selectedRow.Cells["ClientID"].Value);
                        GetOperatorID.ClientName = Convert.ToString(selectedRow.Cells["AccountName"].Value);
                        GetOperatorID.ClientTypeID = Convert.ToString(selectedRow.Cells["AccountTypeID"].Value);
                        GetOperatorID.AccountID = Convert.ToString(selectedRow.Cells["AccountID"].Value);
                        GetOperatorID.ClientTypeID = "I";
                        GetOperatorID.ProductID = Convert.ToString(selectedRow.Cells["ProductID"].Value);

                    }

                    if (AppData.BiometricStatusID == "PG")
                        GetOperatorID.Level = "PS";

                    GetOperatorID.ClientTypeID = cboClientTypeID.SelectedValue.ToString();
                    GetOperatorID.ClientType = cboClientTypeID.SelectedValue.ToString();
                    GetOperatorID.cboImageTypeID = cboImageTypeID.SelectedValue.ToString();


                    if (GetOperatorID.cboImageTypeID != "B" & GetOperatorID.Level != "PS")
                    {
                        GetOperatorID.GetPhoto = true;
                        new Camera().ShowDialog();  // process verification
                    }
                    else if (GetOperatorID.cboImageTypeID != "B" & GetOperatorID.Level == "PS")
                    {
                        GetOperatorID.GetPhoto = true;
                        new VerificationImage(Data).ShowDialog();  // process verification
                    }
                    else if (GetOperatorID.Level == "PS" || GetOperatorID.Level == "PG")
                    {
                        
                        GetOperatorID.Verify= true;
                        new VerificationForm(Data).ShowDialog();  // process verification
                    }
                    else
                    {
                        new EnrollmentForm().ShowDialog(); // process verification
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            btnEdit.BackColor = Color.LightGreen;
            btnSupervision.BackColor = default(Color);
            btnEnrollment.BackColor = default(Color);
            cashTransactionToolStripMenuItem.BackColor = default(Color);
            AppData.BiometricStatusID = "ES";
            if (cmbSearchID.Text != string.Empty)
                service.RefreshBiomtric(gdBiometricDetail, AppData.BiometricStatusID, cmbSearchID.Text, cboClientTypeID.SelectedValue.ToString(), txtSearchValue.Text);
        
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();
        }

        private void loanApprovalGuarantorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLoanApproval.BackColor = Color.LightGreen;
            btnEdit.BackColor = default(Color);
            btnSupervision.BackColor = default(Color);
            btnEnrollment.BackColor = default(Color);
            cashTransactionToolStripMenuItem.BackColor = default(Color);
            AppData.BiometricStatusID = "PG";
            if (cmbSearchID.Text != string.Empty)

                service.GetGuarantor(gdBiometricDetail, AppData.BiometricStatusID, cmbSearchID.Text, cboClientTypeID.SelectedValue.ToString(), txtSearchValue.Text);
        }

        private void approvalDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEnrollment.BackColor = Color.LightGreen;
            btnEdit.BackColor = default(Color);
            btnSupervision.BackColor = default(Color);
            cashTransactionToolStripMenuItem.BackColor = default(Color);
            AppData.BiometricStatusID = "PE";
            if (cmbSearchID.Text != string.Empty)

                service.GetGuarantor(gdBiometricDetail, AppData.BiometricStatusID, cmbSearchID.Text, cboClientTypeID.SelectedValue.ToString(), txtSearchValue.Text);

        }

        private void verificationHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLoanApproval.BackColor = Color.LightGreen;
            btnEdit.BackColor = default(Color);
            btnEnrollment.BackColor = default(Color);
            cashTransactionToolStripMenuItem.BackColor = default(Color);

            AppData.BiometricStatusID = "PG";
            if (cmbSearchID.Text != string.Empty)
                service.GetGuarantor(gdBiometricDetail, AppData.BiometricStatusID, cmbSearchID.Text, cboClientTypeID.SelectedValue.ToString(), txtSearchValue.Text);

        }

        private void cboImageTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetOperatorID.cboImageTypeID = cboImageTypeID.SelectedValue.ToString();
            service.RefreshBiomtric(gdBiometricDetail, AppData.BiometricStatusID, cmbSearchID.Text, cboClientTypeID.SelectedValue.ToString(), txtSearchValue.Text);

        }

        private void cashTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cashTransactionToolStripMenuItem.BackColor = Color.LightGreen;
            btnEdit.BackColor = default(Color);
            btnSupervision.BackColor = default(Color);
            btnEnrollment.BackColor = default(Color);
            AppData.BiometricStatusID = "PE";

            new CashTransaction().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#FDFFB8");
            GetOperatorID.Level = "V";
            //SqlConnection oConnection
            //                  = AppData.ConnectionString();
            //oConnection.Open();
            //try
            //{

            service.GetUserDetails();

                //SqlCommand oCommand = new SqlCommand(
                //  "SELECT TOP 1 OurBranchID, IpAddress,AccountID,ComputerName,ClientID,OperatorID FROM dbo.t_BiometricIPAddress " +
                //  " WHERE Verified = 0 AND OperatorID = '" + GetOperatorID.OperatorID +
                //  "' ORDER BY RowID Desc,CreatedOn Desc ",
                //  oConnection);
                //SqlDataReader objReader = oCommand.ExecuteReader();
                //try
                //{
                //    while (objReader.Read())
                //    {

                //        GetOperatorID.OperatorIDFromDB = objReader["OperatorID"].ToString();
                //        GetOperatorID.AccountID = objReader["AccountID"].ToString();
                //        GetOperatorID.ClientName = objReader["ComputerName"].ToString();
                //        GetOperatorID.ClientID = objReader["ClientID"].ToString();
                //        GetOperatorID.AccountName = objReader["ComputerName"].ToString();
                //        GetOperatorID.LocalIPAddress = objReader["OperatorID"].ToString();
                //        GetOperatorID.Level = "PS";

                //    }


                GetOperatorID.Verify = true;
                //}
                //    finally
                //    {
                //        objReader.Close();
                //    }
                //}
                //finally
                //{
                //    oConnection.Close();
                //}
                InitializeComponent();
                groupBox1.Visible = false;
                gbData.Visible = false;
                MenuStrip2.Visible = false;

                GetOperatorID.Verify = true;
                button1.Visible = true;
                new VerificationForm(Data).ShowDialog();
                this.BackColor = ColorTranslator.FromHtml("#FDFFB8");

            //}
}
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gdBiometricDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}