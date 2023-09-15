using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrint_LT.Model
{
    public class LoginModel
    {
        public string OurBranchID { get; set; }
        public string operatorID { get; set; }
        public string password { get; set; }
        public string loginType { get; set; }
    }
    public class LoginResponse
    {
        public string statusCode { get; set; }
        public string statusMessage { get; set; }
        public string messageID { get; set; }
        public string levelID { get; set; }
        public string workingDate { get; set; }
        public string userName { get; set; }
        public string enrollmentRight { get; set; }
        public string verificationRight { get; set; }
        public string editenrollmentRight { get; set; }
        public string Message { get; set; }

    }
    public class AddEditFingerPrintRequestBodyModel
    {
        public string OurBranchID { get; set; }
        public string OperatorID { get; set; }
        public string ClientID { get; set; }
        public string AccountID { get; set; }
        public string ClientTypeID { get; set; }
        public string ImageTypeID { get; set; }
        public byte[] FingerPrint { get; set; }
        public int FingerNo { get; set; }
        public string ReaderSerialNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int NewRecord { get; set; }

    }
    public class AddEditFingerPrintResponseInfoModel
    {
        public string statusCode { get; set; }
        public string statusMessage { get; set; }
        public string status { get; set; }
        public string Message { get; set; }

    }

    public class GeneralResponse
    {
        public string statusCode { get; set; }
        public string statusMessage { get; set; }
        public string status { get; set; }
        public string Message { get; set; }

    }
    public class BiometricStatusModel
    {
        public string OurBranchID { get; set; }
        public string BiometricStatusID { get; set; }
        public string BiometricTypeID { get; set; }
        public string ImageTypeID { get; set; }
        public string SearchID { get; set; }
        public string SearchValue { get; set; }
        public string OperatorID { get; set; }
    }

    public class VerifyFingerPrintModel
    {
        public string OurBranchID { get; set; }
        public string ClientID { get; set; }
        public string ClientType { get; set; }
        public string AccountID { get; set; }
        public string OperatorID { get; set; }
        public string BiometricStatusID { get; set; }
        public string ImageTypeID { get; set; }
        public string IPAddress { get; set; }
    }

    public class SearchModel
    {
        public string OurBranchID { get; set; }
        public string TableID { get; set; }
        public string AdvFilterString { get; set; }
        public string WhereStmt { get; set; }
        public int PrevOrNext { get; set; }
        public string RefID { get; set; }
        public string OperatorID { get; set; }
        public string ModuleID { get; set; }
        public string SearchKey { get; set; }
        public string LanguageID { get; set; }

    }
    public class SystemBranchesModel
    {
        public string BankID { get; set; }
       

    }
    public class SystemBranchResponseModel
    {
        public string ourBranchID { get; set; }
        public string branchName { get; set; }
    }

    public class SearchResultResponseModel
    {
        public string subCodeID { get; set; }
        public string description { get; set; }
    }

    public class BiometricStatusResponse
    {
        public string serialNo { get; set; }
        public string ourBranchID { get; set; }
        public string clientID { get; set; }
        public string accountID { get; set; }
        public string productID { get; set; }
        public string accountName { get; set; }
        public string enrollmentStatus { get; set; }
        public string accountTypeID { get; set; }
    }
    public class GetFingerPrintModel
    {
        public string OurBranchID { get; set; }
        public string ClientID { get; set; }
        public string AccountID { get; set; }
        public string ImageTypeID { get; set; }
        public string ClientTypeID { get; set; }
        public int FingerNo { get; set; }

    }
    public class BiometricAunthModel
    {
        public string ComputerID { get; set; }
        public string BiometricType { get; set; }
       

    }
    public class BiometricAunthResponseModel
    {
        public string FingerNo { get; set; }
        public string FingerPrint { get; set; }

        public string statusCode { get; set; }

        public string Message { get; set; }

    }
    public class GetUserDetailRequestBodyModel
    {
        public string OperatorID { get; set; }

    }
    public class GetUserDetailResponseInfoModel
    {
        public string statusCode { get; set; }
        public string statusMessage { get; set; }
        public string Message { get; set; }
        public string OurBranchID { get; set; }
        public string IpAddress { get; set; }
        public string AccountID { get; set; }
        public string ComputerName { get; set; }
        public string ClientID { get; set; }
        public string OperatorID { get; set; }
    }

}
