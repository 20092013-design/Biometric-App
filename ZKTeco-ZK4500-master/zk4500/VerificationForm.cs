using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml.Linq;
using AxZKFPEngXControl;
using FingerPrint_LT.Model;
using FingerPrint_LT.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FingerPrint_LT
{
  public partial class VerificationForm : Form {
        private AxZKFPEngX ZkFprint = new AxZKFPEngX();
        private bool Check;
        private bool verify;

        private AppData Data;

        public VerificationForm(AppData data)
    {
        #region InitializeComponent
        
        InitializeComponent();
         Data = data;
         txtOperatorID.Text = GetOperatorID.ClientID;
         trxName.Text = GetOperatorID.ClientName;
         txtBranchID.Text = GetOperatorID.BranchName;
         txtAccountID.Text = GetOperatorID.AccountID + " :-" + GetOperatorID.ProductID;
         txtBranchID.Enabled = false;
         txtAccountID.Enabled = false;
         txtOperatorID.Enabled = false;
         trxName.Enabled = false;

            this.BackColor = ColorTranslator.FromHtml("#FDFFB8");
            groupBox1.BackColor = ColorTranslator.FromHtml("#FDFFB8");
            groupBox2.BackColor = ColorTranslator.FromHtml("#FDFFB8");
            fpicture.BackColor = ColorTranslator.FromHtml("#FDFFB8");

            #endregion
        }

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

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (ZkFprint.IsRegister)
            {
                ZkFprint.CancelEnroll();
            }
            ZkFprint.OnCapture += zkFprint_OnCapture;
            ZkFprint.BeginCapture();
            MessageBox.Show("Please give fingerprint sample.");
        }

        #region Verification
        SqlConnection conn = AppData.ConnectionString();
     
      string FingerNo = string.Empty;
      Service service = new Service();


        private void zkFprint_OnImageReceived(object sender, IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            Graphics g = fpicture.CreateGraphics();
            Bitmap bmp = new Bitmap(fpicture.Width, fpicture.Height);
            g = Graphics.FromImage(bmp);
            int dc = g.GetHdc().ToInt32();
            ZkFprint.PrintImageAt(dc, 0, 0, bmp.Width, bmp.Height);
            g.Dispose();
            fpicture.Image = bmp;
        }

        private void zkFprint_OnCapture(object sender, IZKFPEngXEvents_OnCaptureEvent e)
        {
            if (GetOperatorID.Verify)
            {

            string template = ZkFprint.EncodeTemplate1(e.aTemplate);

            AppData.imagedata = null;
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlDataReader read = (null);
                try
                {

            
                GetFingerPrintModel getFingerPrintModel = new GetFingerPrintModel();
                BiometricAunthResponseModel BiometricResponse = new BiometricAunthResponseModel();

                getFingerPrintModel.OurBranchID = GetOperatorID.VerificationBranchID;
                getFingerPrintModel.ClientTypeID = GetOperatorID.ClientTypeID;
                getFingerPrintModel.ImageTypeID = GetOperatorID.cboImageTypeID;
                getFingerPrintModel.ClientID = GetOperatorID.ClientID;
                getFingerPrintModel.AccountID = GetOperatorID.AccountID;
                getFingerPrintModel.FingerNo = 6;
              //int.Parse(string.IsNullOrEmpty(AppData.EnrolledFingers) ? "6" : AppData.EnrolledFingers);

                var result_ = GetData("BIO/api/Biometric/GetFingerPrint", getFingerPrintModel);

                BiometricResponse = (BiometricAunthResponseModel)(new JavaScriptSerializer()).Deserialize(result_, typeof(BiometricAunthResponseModel));


                if (BiometricResponse.statusCode != "200")
                {
                    throw new Exception(BiometricResponse.Message);
                }

                //AppData.imagedata =BiometricResponse.FingerPrint;
                FingerNo = BiometricResponse.FingerNo.ToString();

                //string result = System.Text.Encoding.UTF8.GetString(AppData.imagedata);
                 string result= BiometricResponse.FingerPrint; ;

                var OriginalImage = AppData.ImageString;

                if (result != null)
                {
                    if (ZkFprint.VerFingerFromStr(ref template, result, false, ref Check))
                    {
                        lblMessage.Text = "Verified:-" + FingerNo;
                        lblMessage.ForeColor = Color.Blue;

                        service.Verify(GetOperatorID.ClientID, GetOperatorID.AccountID);

                        ZkFprint.CancelEnroll();

                        if (GetOperatorID.AccountID.Length < 4)
                            Application.Exit();
                        else
                            this.Close();

                        GetOperatorID.Verify = false;
                    }
                    else
                    {

                        lblMessage.Text = "Failed, Kindly try again.";
                        lblMessage.ForeColor = Color.Red;

                        ZkFprint.CancelEnroll();
                    }

                    //reminderMessage = Convert.ToString(read["ReconciledBy"]);
                }


                }
                catch (Exception ex)
                {

                    lblMessage.Text = ex.Message;
                    lblMessage.ForeColor = Color.Red;
                }


                //using (SqlCommand cmd = new SqlCommand("p_GetfingerPrint", conn))
                //{
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@OurBranchID", SqlDbType.VarChar).Value = GetOperatorID.VerificationBranchID;
                //    cmd.Parameters.AddWithValue("@ClientTypeID", SqlDbType.VarChar).Value = GetOperatorID.ClientTypeID;
                //    cmd.Parameters.AddWithValue("@ImageTypeID", SqlDbType.VarChar).Value = GetOperatorID.cboImageTypeID;
                //    cmd.Parameters.AddWithValue("@ClientID", SqlDbType.VarChar).Value = GetOperatorID.ClientID;
                //    cmd.Parameters.AddWithValue("@AccountID", SqlDbType.VarChar).Value = GetOperatorID.ClientID;
                //    cmd.Parameters.AddWithValue("@FingerNo", SqlDbType.VarChar).Value = 6;

                //    try
                //    {
                //        if (conn.State != ConnectionState.Open)
                //        {
                //            conn.Open();
                //        }
                //        read = cmd.ExecuteReader();
                //while (read.Read())
                //    {
                //        AppData.imagedata = (byte[])read["FingerPrint"];
                //        FingerNo = read["FingerNo"].ToString();

                //            string result = System.Text.Encoding.UTF8.GetString(AppData.imagedata);

                //            if (result != null)
                //            {
                //                if (ZkFprint.VerFingerFromStr(ref template, result, false, ref Check))
                //                {
                //                    lblMessage.Text = "Verified:-" + FingerNo;
                //                    lblMessage.ForeColor = Color.Blue;

                //                    service.Verify(GetOperatorID.ClientID, GetOperatorID.AccountID);

                //                    ZkFprint.CancelEnroll();

                //                    if (GetOperatorID.AccountID.Length < 4)
                //                        Application.Exit();
                //                    else
                //                        this.Close();

                //                    GetOperatorID.Verify = false;
                //                }
                //                else
                //                {

                //                    lblMessage.Text = "Failed, Kindly try again.";
                //                    lblMessage.ForeColor = Color.Red;

                //                    ZkFprint.CancelEnroll();
                //                }

                //                //reminderMessage = Convert.ToString(read["ReconciledBy"]);
                //            }
                //            else
                //            {
                //                MessageBox.Show("Login was unsuccessful. Use Finger No:-" + FingerNo);

                //            }
                //    }

                //    if (conn.State == ConnectionState.Open)
                //    {
                //        conn.Close();
                //    }

                //}
                //catch (Exception ex)
                //{
                //    conn.Close();
                //    MessageBox.Show(ex.Message.ToString());
                //}
                //}

            }

        }







        private void CloseButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetOperatorID.Level == "PS" || GetOperatorID.Level == "PG" || GetOperatorID.Level == "V")
                    this.Close();
                else

                    Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

       
        #endregion

        private void VerificationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (GetOperatorID.Level != "PS")
                    Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private void btnVerify_Click_1(object sender, EventArgs e)
        {
            //if (ZkFprint.IsRegister)
            //{
            //    ZkFprint.CancelEnroll();
            //}
            ZkFprint.OnCapture += zkFprint_OnCapture;
            ZkFprint.BeginCapture();
            MessageBox.Show("Please give fingerprint sample.");

        }

        private void VerificationForm_Load(object sender, EventArgs e)
        {
            txtBranchID.Text = GetOperatorID.BranchName;
            txtOperatorID.Text = GetOperatorID.ClientID;
            txtAccountID.Text = GetOperatorID.AccountID;
            txtAccountID.Enabled = true;

            Controls.Add(ZkFprint);
            InitialAxZkfp();

            ZkFprint.OnCapture += zkFprint_OnCapture;
            ZkFprint.BeginCapture();

            verify = true;
            //MessageBox.Show("Please give fingerprint sample.");
        }

        private void zkFprint_OnFeatureInfo(object sender, IZKFPEngXEvents_OnFeatureInfoEvent e)
        {

            String strTemp = string.Empty;
            if (ZkFprint.EnrollIndex != 1)
            {
                if (ZkFprint.IsRegister)
                {
                    if (ZkFprint.EnrollIndex - 1 > 0)
                    {
                        int eindex = ZkFprint.EnrollIndex - 1;
                        strTemp = "Please scan again ..." + eindex;
                    }
                }
            }
            //MessageBox.Show(strTemp);
        }

        private void zkFprint_OnEnroll(object sender, IZKFPEngXEvents_OnEnrollEvent e)
        {
            if (e.actionResult)
            {

                //mspdl42JgBJjwRfnlWHBDASWXcEPcRUrwQ/oODPBBAA9UUEIEcEpwQbvSFFBCBwaXMEMA74bwQnmwkdBChPFMIEJB1FUgQuYDDWBD+UcUEEDdU8YgRLeyxyBE+EyFYEG4zo/gQV5ODBBA3GfP0EE6yxeQQWEJ1GBCAkVR8EK6cwvQRYSSixBD3M+EkEHZkVuQQqTU3fBBytWY0EOLzZpwQYWUzkBHC1VLoFZS1YjgQ5ZX1RVCwAQbm5ubm9ydXYBAwcJCg0ODw8AEG9ubW5wcnV3AgUICgwPEBIRABBub29vcHN2dncBBQgKCwwNDQAQbm1tb3J0dncDBQgLDRARExMAEHBwcHBzdHV1dXYBBQgICQoMABBtbG1vcnR2AQQHCQ0QFBQVFgAQcXFxcnR1dXR0dXcDBQcICgsAEGtqa25xdHcCBgkMDxMVFxcYABBxcHBydHVzcnN0dgIFBggKDQAQaGhpbXFzdwUIDA4RFBcYGhsBEG9vcHFycXByc3N1AgQGCA0AEGNjZ2xydQMIDRESFRYZGh0dAg9tbm5ucG9wb3BwdQEEBgAQX2Bja3F3Bg0SFRYXGBwfIiIDDmtram1rbGlqaXB0AgAQW1xgaXECCxMXGhocHSAhIyQFDGpsampnaGhtABBXWF1mcAMPGBsfICEiJCQlJgAA/wAQVlZcYWsDGiQjJSYnJygoKSgAAP8AEFVXXV5iZC0zMTAtLy0tLS4sAQ9YXVxZTj45NzUyMjExLjE="

                AppData.EnrolledFingers = "6";
                AppData.ReaderSerialNumber = "Data";
                string template = ZkFprint.EncodeTemplate1(e.aTemplate);
                //txtTemplate.Text = template;
                byte[] bytes = Encoding.ASCII.GetBytes(template);
                service.AddEditBiometric(bytes, GetOperatorID.ClientID, AppData.ReaderSerialNumber, AppData.EnrolledFingers,
                            "I");
                MessageBox.Show("Registration successful. You can verify now");
              //  btnRegister.Enabled = false;
                //btnVerify.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error, please register again.");

            }
        }

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        private void InitialAxZkfp()
        {
            try
            {

                ZkFprint.OnImageReceived += zkFprint_OnImageReceived;
                ZkFprint.OnFeatureInfo += zkFprint_OnFeatureInfo;
                //zkFprint.OnFingerTouching 
                //zkFprint.OnFingerLeaving
                ZkFprint.OnEnroll += zkFprint_OnEnroll;

                if (ZkFprint.InitEngine() == 0)
                {
                    ZkFprint.FPEngineVersion = "9";
                    ZkFprint.EnrollCount = 3;
                   // lblMessage.Text += " " + ZkFprint.SensorSN + " Count: " + ZkFprint.SensorCount.ToString() + " Index: " + ZkFprint.SensorIndex.ToString();
                   // MessageBox.Show("Device successfully connected");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Device init err, error: " + ex.Message);
            }
        }
    }
}