using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxZKFPEngXControl;
using FingerPrint_LT.Services;

namespace FingerPrint_LT
{
    public partial class EnrollmentForm : Form
    {
        private AxZKFPEngX ZkFprint = new AxZKFPEngX();
        private bool Check;

        Service service = new Service();

        public EnrollmentForm()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtBranchID.Text = GetOperatorID.BranchName;
            txtClientID.Text = GetOperatorID.ClientID;
            txtAccountID.Text = GetOperatorID.AccountID;
            cboClientTypeID.Text = GetOperatorID.ClientTypeID;
            txtProductID.Text = GetOperatorID.ProductID;
            txtName.Text = GetOperatorID.ClientName;
            txtBranchID.Enabled = false;
            txtClientID.Enabled = false;
            txtProductID.Enabled = false;
            txtName.Enabled = false;
            cboClientTypeID.Enabled = false;

            Controls.Add(ZkFprint);
            InitialAxZkfp();

            ZkFprint.CancelEnroll();
            ZkFprint.EnrollCount = 3;
            ZkFprint.BeginEnroll();
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
                    deviceSerial.Text += " " + ZkFprint.SensorSN + " Count: " + ZkFprint.SensorCount.ToString() + " Index: " + ZkFprint.SensorIndex.ToString();
                    ShowHintInfo("Device successfully connected");
                }

            }
            catch (Exception ex)
            {
                ShowHintInfo("Device init err, error: " + ex.Message);
            }
        }

        private void zkFprint_OnImageReceived(object sender, IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            try
            {
                Graphics g = fpicture.CreateGraphics();
                Bitmap bmp = new Bitmap(fpicture.Width, fpicture.Height);
                g = Graphics.FromImage(bmp);
                int dc = g.GetHdc().ToInt32();
                ZkFprint.PrintImageAt(dc, 0, 0, bmp.Width, bmp.Height);
                g.Dispose();
                fpicture.Image = bmp;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
         
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
            ShowHintInfo(strTemp);
        }
        MemoryStream fingerprintData = new MemoryStream();
        private void zkFprint_OnEnroll(object sender, IZKFPEngXEvents_OnEnrollEvent e)
        {
            try
            {
                if (e.actionResult)
                {

                    //mspdl42JgBJjwRfnlWHBDASWXcEPcRUrwQ/oODPBBAA9UUEIEcEpwQbvSFFBCBwaXMEMA74bwQnmwkdBChPFMIEJB1FUgQuYDDWBD+UcUEEDdU8YgRLeyxyBE+EyFYEG4zo/gQV5ODBBA3GfP0EE6yxeQQWEJ1GBCAkVR8EK6cwvQRYSSixBD3M+EkEHZkVuQQqTU3fBBytWY0EOLzZpwQYWUzkBHC1VLoFZS1YjgQ5ZX1RVCwAQbm5ubm9ydXYBAwcJCg0ODw8AEG9ubW5wcnV3AgUICgwPEBIRABBub29vcHN2dncBBQgKCwwNDQAQbm1tb3J0dncDBQgLDRARExMAEHBwcHBzdHV1dXYBBQgICQoMABBtbG1vcnR2AQQHCQ0QFBQVFgAQcXFxcnR1dXR0dXcDBQcICgsAEGtqa25xdHcCBgkMDxMVFxcYABBxcHBydHVzcnN0dgIFBggKDQAQaGhpbXFzdwUIDA4RFBcYGhsBEG9vcHFycXByc3N1AgQGCA0AEGNjZ2xydQMIDRESFRYZGh0dAg9tbm5ucG9wb3BwdQEEBgAQX2Bja3F3Bg0SFRYXGBwfIiIDDmtram1rbGlqaXB0AgAQW1xgaXECCxMXGhocHSAhIyQFDGpsampnaGhtABBXWF1mcAMPGBsfICEiJCQlJgAA/wAQVlZcYWsDGiQjJSYnJygoKSgAAP8AEFVXXV5iZC0zMTAtLy0tLS4sAQ9YXVxZTj45NzUyMjExLjE="

                    AppData.EnrolledFingers = "6";
                    AppData.ReaderSerialNumber = ZkFprint.SensorSN.ToString();
                    string template = ZkFprint.EncodeTemplate1(e.aTemplate);
                    //txtTemplate.Text = template;
                    byte[] bytes = Encoding.ASCII.GetBytes(template);
                    //GetOperatorID.cboImageTypeID = cboClientTypeID.SelectedValue.ToString();
                    service.AddEditBiometric(bytes, GetOperatorID.ClientID, AppData.ReaderSerialNumber, AppData.EnrolledFingers,
                                "I");
                    ShowHintInfo("Registration successful. You can verify now");
                    //btnRegister.Enabled = false;
                    //btnVerify.Enabled = true;
                    this.Close();
                }
                else
                {
                    ShowHintInfo("Error, please register again.");
                    ZkFprint.CancelEnroll();
                    ZkFprint.EnrollCount = 3;
                    ZkFprint.BeginEnroll();

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void zkFprint_OnCapture(object sender, IZKFPEngXEvents_OnCaptureEvent e)
        {
            string template = ZkFprint.EncodeTemplate1(e.aTemplate);


            if (ZkFprint.VerFingerFromStr(ref template, "", false, ref Check))
            {
                ShowHintInfo("Verified");
            }
            else
                ShowHintInfo("Not Verified");

        }



        private void ShowHintInfo(String s)
        {
            prompt.Text = s;
        }


        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (ZkFprint.IsRegister)
            {
                ZkFprint.CancelEnroll();
            }
            ZkFprint.OnCapture += zkFprint_OnCapture;
            ZkFprint.BeginCapture();
            ShowHintInfo("Please give fingerprint sample.");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            ZkFprint.CancelEnroll();
            ZkFprint.EnrollCount = 3;
            ZkFprint.BeginEnroll();
            ShowHintInfo("Please give fingerprint sample.");

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            fpicture.Image = null;
        }

    }
}
