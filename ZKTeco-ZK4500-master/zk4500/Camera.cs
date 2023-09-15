using FingerPrint_LT.Services;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FingerPrint_LT
{
    public partial class Camera : Form
    {
        public Camera()
        {
            InitializeComponent();
        }

        Service service = new Service();
        private void Camera_Load(object sender, EventArgs e)
        {
            txtOperatorID.Text = GetOperatorID.ClientID;
            trxName.Text = GetOperatorID.ClientName;
            txtBranchID.Text = GetOperatorID.BranchName;
            txtAccountID.Text = GetOperatorID.AccountID + " :-" + GetOperatorID.ProductID;
            txtBranchID.Enabled = false;
            txtAccountID.Enabled = false;
            txtOperatorID.Enabled = false;
            trxName.Enabled = false;

            try
            {
                // find device.
                var devices = UsbCamera.FindDevices();
                DataTable tbl = new DataTable();

                var NoOfDevices = 0;
                Service.ComboboxItem item = new Service.ComboboxItem();
                foreach (string s in devices)
                {
                    
                    item.Text = devices[NoOfDevices].ToString();
                    item.Value = s;
                    NoOfDevices=NoOfDevices+1;

                }

                

                cboCameraID.Items.Add(item);

               // cboCameraID.SelectedIndex = 0;

                //foreach (string s in devices)
                //{
                //    DataRow row = tbl.NewRow();
                //    string[] numb = s.Split(',');
                //    row["Col1"] = numb[0];
                //    row["Col2"] = numb[1];

                //    tbl.Rows.Add(row);
                //}

                AppData.ReaderSerialNumber = devices[NoOfDevices-1].ToString();


                //service.GeneralFill(cboCameraID, tbl, "Col1", "Col2");

                if (devices.Length == 0) return; // no device.

  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+" : Ensure the USB Camera is well connected ");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get video format.
            var cameraIndex = 1;
            var formats = UsbCamera.GetVideoFormat(cameraIndex);

            // select the format you want.
            foreach (var item in formats) Console.WriteLine(item);
            var format = formats[0];

            // create instance.
            var camera = new UsbCamera(cameraIndex, format);
            // this closing event handler make sure that the instance is not subject to garbage collection.
            this.FormClosing += (s, ev) => camera.Release(); // release when close.

            // to show preview, there are 3 ways.
            // 1. use SetPreviewControl. (works light, recommended.)
            camera.SetPreviewControl(pictureBox1.Handle, pictureBox1.ClientSize);
            pictureBox1.Resize += (s, ev) => camera.SetPreviewSize(pictureBox1.ClientSize); // support resize.

            // 2. use Timer and GetBitmap().
            /*var timer = new System.Timers.Timer(1000 / 30) { SynchronizingObject = this };
            timer.Elapsed += (s, ev) => pictureBox1.Image = camera.GetBitmap();
            timer.Start();
            this.FormClosing += (s, ev) => timer.Stop();*/

            // 3. subscribe PreviewCaptured.
            /*camera.PreviewCaptured += (bmp) =>
            {
                // called by worker thread, you have to call cross-thread control in a thread-safe way.
                pictureBox1.Invoke((Action)(() =>
                {
                    pictureBox1.Image = bmp;
                }));
            };*/

            // start.
            camera.Start();

            // get bitmap.
            button1.Click += (s, ev) => pictureBox2.Image = camera.GetBitmap();

            //button1.Click += (s, ev) => camera.StillImageTrigger();
            //camera.StillImageCaptured += bmp => pictureBox2.Image = bmp;

            // still image
            //if (camera.StillImageAvailable)
            //{
            //    button1.Click += (s, ev) => camera.StillImageTrigger();
            //    camera.StillImageCaptured += bmp => pictureBox2.Image = bmp;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

            byte[] bytes = ImageToByte(pictureBox2.Image);
            service.AddEditBiometric(bytes, GetOperatorID.ClientID, AppData.ReaderSerialNumber, AppData.EnrolledFingers,
                        GetOperatorID.cboImageTypeID);
            lblMessage.Text = "Image Saved Successfully. Pending Supervision";
            //btnRegister.Enabled = false;
            //btnVerify.Enabled = true;
            this.Close();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        private void cboCameraID_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
    }
}
