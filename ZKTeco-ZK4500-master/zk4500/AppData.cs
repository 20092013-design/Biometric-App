using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Supreme.Utilities;

namespace FingerPrint_LT
{
    public delegate void OnChangeHandler();

    // Keeps application-wide data shared among forms and provides notifications about changes
    //
    // Everywhere in this application a "document-view" model is used, and this class provides
    // a "document" part, whereas forms implement a "view" parts.
    // Each form interested in this data keeps a reference to it and synchronizes it with own 
    // controls using the OnChange() event and the Update() notificator method.
    //


    #region ServiceField
    public static class ServiceField
    {
        public static string MessageID;
        public static string WorkingDate;
        public static string ErrorMessage;

    }
    #endregion

    #region GetOperatorID
    public static class GetOperatorID
    {
        public static string UserID;
        public static bool Verify;
        public static bool GetPhoto;
        public static string OperatorID;
        public static string OperatorIDFromDB;
        public static string ClientID;
        public static string AccountID = null;
        public static string AccountName = null;
        public static string VerificationBranchID;
        public static string BranchName;
        public static string ProductID;
        public static Int32 Enrolled;
        public static string LocalIPAddress;
        public static string Level;
        public static string InitialLevel;
        public static string ClientName;
        public static string GuarantorID;
        public static string ApplicationID;
        public static string ClientTypeID;
        public static string ClientType;
        public static string cboImageTypeID;
        public static string TrxBranchID;
        public static string SearchID;
        public static string SearchValue;
        public static string ResultID;
        public static string ResultValue;
        public static string TrxTypeID;
        public static string ModuleID;
        public static string CurrencyID;

        
    }
    #endregion

    #region AppData
    public class AppData
    {
        public static byte[] imagedata;
        public static string workingDate;
        public static string BranchID;
        public static string BiometricStatusID;
        public static string BranchName;
        public static DataTable SystemBranchStatus;
        public static DataTable ClientDetails;
        public static DataTable AccountDetails;
        public static DataTable ErrorMessage;
        public static string ErrorID;
        public static string EnrolledFingers = string.Empty;
        public static string ReaderSerialNumber = string.Empty;
        public static DataTable SystemCodeDetail;
        public static string ImageString;
        public static byte[] ImageByte;

        public static SqlConnection ConnectionString()
        {
            var EncryptedconStr = ConfigurationManager.AppSettings["connectionString"].ToString();
           // var decryptedconStr = SupremeUtility.Decrypt(EncryptedconStr, true);
            SqlConnection con = new SqlConnection(EncryptedconStr);
            return con;
        }
        public static string GetBaseUrl()
        {
            return ConfigurationManager.AppSettings["BaseUrl"].ToString();

        }
        public static IDbConnection DapperConnection()
        {
            IDbConnection _db = ConnectionString();
            return _db;
        }


        public static string GetBankID()
        {
            return ConfigurationManager.AppSettings["BankID"].ToString();

        }

        public static string InitializeImage()
        {
            return ConfigurationManager.AppSettings["InitializeImage"].ToString();

        }

        public static int ClientIDLength()
        {
            return Convert.ToInt32(ConfigurationManager.AppSettings["ClientIDLength"]);

        }

        public const int MaxFingers = 10;
        // shared data
        public int EnrolledFingersMask = 0;
        public int MaxEnrollFingerCount = MaxFingers;
        public bool IsEventHandlerSucceeds = true;
        public bool IsFeatureSetMatched = false;
        public int FalseAcceptRate = 0;

        // data change notification
        public void Update() { OnChange(); }        // just fires the OnChange() event
        public event OnChangeHandler OnChange;
    }
    #endregion
}
  