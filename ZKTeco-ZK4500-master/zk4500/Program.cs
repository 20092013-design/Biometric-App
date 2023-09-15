using FingerPrint_LT.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FingerPrint_LT
{
    static class Program
    {

        static Service service = new Service();
        /// <summary>
        /// The main entry point for the application.
        /// </summary> 
        [STAThread]
        static void Main()
        {


            bool instanceCountOne = false;

            //using (Mutex mtex = new Mutex(true, "MyRunningApp", out instanceCountOne))
            //{
            //    if (instanceCountOne)
            //    {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                  //  service.AddEditBiometricAunth();

                    if (GetOperatorID.Level != null)
                        Application.Run(new Form1());
                    else
                        Application.Run(new Login());
                //}
                //else
                //{
                //    MessageBox.Show("An application instance is already running");

                //}
           // }


        }
    }
}
