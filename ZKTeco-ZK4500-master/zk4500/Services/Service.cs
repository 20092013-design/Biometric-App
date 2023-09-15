using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing; 
using Dapper;
using System.Reflection;
//using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http;
using FingerPrint_LT.Model;
using System.Web.Script.Serialization;

namespace FingerPrint_LT.Services
{

    public class Service
    {

        static IDbConnection _db = AppData.DapperConnection();

        #region dbHelper
        SqlConnection conn = AppData.ConnectionString();
        SqlDataAdapter sda = new SqlDataAdapter();
        DataTable dt;

        MemoryStream fingerprintData = new MemoryStream();

        static public string EncryptText(string strInputText)
        {
            byte[] data = Array.ConvertAll<char, byte>(strInputText.ToCharArray(), delegate (char ch) { return (byte)ch; });
            SHA256 shaM = new SHA256Managed();
            byte[] result = shaM.ComputeHash(data);
            return Convert.ToBase64String(result);
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
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        public  IEnumerable<object> FetchTrxAcDetails()
        {

            var multi = _db.QueryMultiple("p_GetTrxAcDetails",
             new
             {
                 TrxBranchID = GetOperatorID.TrxBranchID,
                 OurBranchID = GetOperatorID.VerificationBranchID,
                 AccountID   = GetOperatorID.AccountID,
                 TrxTypeID   = GetOperatorID.TrxTypeID,
                 OperatorID  = GetOperatorID.OperatorID,
                 ModuleID    = "3000",
                 CurrencyID  = GetOperatorID.CurrencyID,
                 IncludeCharges = 0
             }, commandType: CommandType.StoredProcedure);


            var mod = SupremeUtility.SerializeDapperRow(multi);


            return mod;

        }
        static public string EncryptPass(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }


        public static byte[] ImageToByte(Image img)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Close();

                byteArray = stream.ToArray();
            }
            return byteArray;
        }

        public void AddEditBiometric(Byte[] bytes, string ClientID, string ReaderSerialNumber, string EnrolledFingers, string ClientTypeID)
        {
            try
            {
               
                AddEditFingerPrintRequestBodyModel addeditfingerprint =new  AddEditFingerPrintRequestBodyModel();
                AddEditFingerPrintResponseInfoModel fingerprintResponseModel = new AddEditFingerPrintResponseInfoModel();

                addeditfingerprint.OurBranchID = AppData.BranchID;
                addeditfingerprint.OperatorID = GetOperatorID.OperatorID;
                addeditfingerprint.ClientID = GetOperatorID.ClientID;
                addeditfingerprint.AccountID = GetOperatorID.AccountID;
                addeditfingerprint.ClientTypeID = ClientTypeID;
                addeditfingerprint.ImageTypeID = GetOperatorID.cboImageTypeID;
                addeditfingerprint.FingerPrint = bytes;
                addeditfingerprint.FingerNo = 6;
                //int.Parse(string.IsNullOrEmpty(AppData.EnrolledFingers) ? "6" : AppData.EnrolledFingers);
                addeditfingerprint.ReaderSerialNumber = ReaderSerialNumber;
                addeditfingerprint.CreatedOn = DateTime.Now;
                addeditfingerprint.ModifiedOn = DateTime.Now;
                addeditfingerprint.NewRecord = 1;

                AppData.ImageString = System.Text.Encoding.UTF8.GetString(bytes);
                AppData.ImageByte = bytes;

                var result = GetData("BIO/api/Biometric/AddEditFingerPrint", addeditfingerprint);


                fingerprintResponseModel = (AddEditFingerPrintResponseInfoModel)(new JavaScriptSerializer()).Deserialize(result, typeof(AddEditFingerPrintResponseInfoModel));


                if (fingerprintResponseModel.statusCode != "200")
                {
                    throw new Exception(fingerprintResponseModel.Message);
                }

                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void RefreshBiomtric(DataGridView gdBiometricDetail, string Status, string SearchID, string ClientTypeID, string SearchValue)
        {
            try
            {

                BiometricStatusModel biometricStatusModel = new BiometricStatusModel();
                List<BiometricStatusResponse> biometricStatus = new List<BiometricStatusResponse>();

                biometricStatusModel.OurBranchID = AppData.BranchID;
                biometricStatusModel.BiometricStatusID = Status;
                biometricStatusModel.BiometricTypeID = ClientTypeID;
                biometricStatusModel.ImageTypeID = GetOperatorID.cboImageTypeID;
                biometricStatusModel.SearchID = SearchID;
                biometricStatusModel.SearchValue = SearchValue;
                biometricStatusModel.OperatorID = GetOperatorID.OperatorID;

                var result = GetData("BIO/api/Biometric/BioMetricStatus", biometricStatusModel);

                biometricStatus = (List< BiometricStatusResponse >)(new JavaScriptSerializer()).Deserialize(result, typeof(List<BiometricStatusResponse>));

                dt = ToDataTable(biometricStatus);
                gdBiometricDetail.DataSource = dt.DefaultView;
                gdBiometricDetail.Show();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void Search(DataGridView gdBiometricDetail, string WhereStmt, string SearchID,string SearchValue)
        {
            try
            {
                dt = new DataTable();

                SearchModel searchModel = new SearchModel();
                List<SearchResultResponseModel> searchResult = new List<SearchResultResponseModel>();

                searchModel.WhereStmt = WhereStmt;
                searchModel.TableID = SearchID;
                searchModel.AdvFilterString = SearchValue;
                searchModel.OperatorID = GetOperatorID.UserID;
                searchModel.OurBranchID = AppData.BranchID;
                searchModel.LanguageID = "en";
                searchModel.SearchKey = "";
                searchModel.ModuleID = "";
                searchModel.RefID = "";
                searchModel.PrevOrNext = 0;

                var result = GetData("BIO/api/Biometric/GetSearchResult", searchModel);
                searchResult = (List<SearchResultResponseModel>)(new JavaScriptSerializer()).Deserialize(result, typeof(List<SearchResultResponseModel>));

                dt = ToDataTable(searchResult);

                gdBiometricDetail.DataSource = dt.DefaultView;
                gdBiometricDetail.Show();
            }
            catch (SqlException ex)
        {
            MessageBox.Show(ex.Message.ToString());
        }
    }

        public void GetGuarantor(DataGridView gdBiometricDetail, string Status, string SearchID, string ClientTypeID, string SearchValue)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("p_GetLoanGuarantor", conn);
                cmd.Parameters.Add("@OurBranchID", SqlDbType.NVarChar).Value = AppData.BranchID;
                cmd.Parameters.Add("@BiometricStatusID", SqlDbType.NVarChar).Value = Status;
                cmd.Parameters.Add("@BiometricTypeID", SqlDbType.NVarChar).Value = ClientTypeID;
                cmd.Parameters.Add("@SearchID", SqlDbType.NVarChar).Value = SearchID;
                cmd.Parameters.Add("@SearchValue", SqlDbType.NVarChar).Value = SearchValue;
                cmd.Parameters.Add("@OperatorID", SqlDbType.NVarChar).Value = GetOperatorID.OperatorID;

                cmd.CommandType = CommandType.StoredProcedure;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                conn.Close();
                gdBiometricDetail.DataSource = dt.DefaultView;
                gdBiometricDetail.Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        public void AddEditBiometricAunth()
        {
            SqlDataReader read = (null);

            using (SqlCommand cmd = new SqlCommand("p_GetBiometricAunth", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ComputerID", SqlDbType.NVarChar).Value = GetLocalIPAddress();
                cmd.Parameters.Add("@BiometricType", SqlDbType.NVarChar).Value = 'I';

                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    read = cmd.ExecuteReader();

                    while (read.Read())
                    {

                        GetOperatorID.VerificationBranchID = read["OurBranchID"].ToString();
                        AppData.BranchID = read["OurBranchID"].ToString();
                        GetOperatorID.BranchName = read["BranchName"].ToString();
                        GetOperatorID.ClientID = read["ClientID"].ToString();
                        GetOperatorID.AccountID = read["AccountID"].ToString();
                        GetOperatorID.ClientName = read["ClientName"].ToString();
                        GetOperatorID.OperatorID = read["OperatorID"].ToString();
                        GetOperatorID.Enrolled = Convert.ToInt32(read["Enrolled"].ToString());
                        GetOperatorID.ProductID = read["ProductID"].ToString();
                        GetOperatorID.ClientTypeID = read["ClientTypeID"].ToString();
                        GetOperatorID.Level = read["Level"].ToString();
                    }
                }
                catch (SqlException ex)
                {
                    conn.Close();
                    return;
                }
                conn.Close();
            }
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

        public void GeneralFill(ComboBox tb, DataTable dt, string value, string data)
        {
            try
            {

                AppData.SystemBranchStatus = dt;//service.GeneralDataTable("pc_SystemBranchStatus");
                DataTable dtDataFromDB = dt;
                tb.DataSource = dtDataFromDB;
                tb.DisplayMember = data;
                tb.ValueMember = value;


            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        public DataTable BindBranchID()
        {
            DataTable dt = new DataTable();
            try
            {
                SystemBranchesModel systemBranchesModel = new SystemBranchesModel();
                List<SystemBranchResponseModel> systemBrancheResponse = new List<SystemBranchResponseModel>();

                systemBranchesModel.BankID = AppData.GetBankID();

                var result = GetData("BIO/api/Biometric/SearchSystemBranches", systemBranchesModel);

                systemBrancheResponse = (List<SystemBranchResponseModel>)(new JavaScriptSerializer()).Deserialize(result, typeof(List<SystemBranchResponseModel>));


                return ToDataTable(systemBrancheResponse); 

            }
            catch (Exception)
            {
                throw;
            }
        }




        public DataTable GeneralDataTable(string procedureName)
        {
            dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LanguageID", SqlDbType.VarChar).Value = "en";
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataTable GeneralSearch(string TableID, string AdvFilterString)
        {
            dt = new DataTable();
            try
            {
                SearchModel searchModel = new SearchModel();
                List<SearchResultResponseModel> searchResult = new List<SearchResultResponseModel>();

                searchModel.WhereStmt = "";
                searchModel.TableID = TableID;
                searchModel.AdvFilterString = AdvFilterString;
                searchModel.OperatorID = GetOperatorID.UserID;
                searchModel.OurBranchID = AppData.BranchID;
                searchModel.LanguageID = "en";
                searchModel.SearchKey = "";
                searchModel.ModuleID = "";
                searchModel.RefID = "";
                searchModel.PrevOrNext = 0;

                var result = GetData("BIO/api/Biometric/GetSearchResult", searchModel);
                searchResult = (List<SearchResultResponseModel>)(new JavaScriptSerializer()).Deserialize(result, typeof(List<SearchResultResponseModel>));
                return ToDataTable(searchResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Verify(string txtClientID, string txtAccountID)
        {

            try
            {
                VerifyFingerPrintModel verifyFingerPrintModel = new VerifyFingerPrintModel();
                GeneralResponse response = new GeneralResponse();

                verifyFingerPrintModel.OurBranchID = AppData.BranchID;
                verifyFingerPrintModel.ClientID = txtClientID;
                verifyFingerPrintModel.ClientType = GetOperatorID.ClientType;
                verifyFingerPrintModel.AccountID = txtAccountID;
                verifyFingerPrintModel.OperatorID = GetOperatorID.OperatorID;
                verifyFingerPrintModel.BiometricStatusID = GetOperatorID.Level;
                verifyFingerPrintModel.ImageTypeID = GetOperatorID.cboImageTypeID;
                verifyFingerPrintModel.IPAddress = GetLocalIPAddress();

                var result = GetData("BIO/api/Biometric/VerifyFingerPrint", verifyFingerPrintModel);

                response = (GeneralResponse)(new JavaScriptSerializer()).Deserialize(result, typeof(GeneralResponse));

                if(response.statusCode != "200")
                {
                    throw new Exception(response.Message);
                }

            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }

        }


        public Image ConvertToImage()
        {
            using (MemoryStream ms = new MemoryStream(AppData.imagedata, 0, AppData.imagedata.Length))
            {
                ms.Write(AppData.imagedata, 0, AppData.imagedata.Length);

                //Set image variable value using memory stream.
                return Image.FromStream(ms, true);
            }
        }

        public void GetUserDetails()
        {
            GetUserDetailRequestBodyModel getUserDetailRequestBodyModel = new GetUserDetailRequestBodyModel();
            GetUserDetailResponseInfoModel getUserDetailResponseInfoModel = new GetUserDetailResponseInfoModel();

            getUserDetailRequestBodyModel.OperatorID = GetOperatorID.OperatorID;

            var result = GetData("BIO/api/Biometric/GetUserDetail", getUserDetailRequestBodyModel);

            getUserDetailResponseInfoModel = (GetUserDetailResponseInfoModel)(new JavaScriptSerializer()).Deserialize(result, typeof(GetUserDetailResponseInfoModel));

            GetOperatorID.OperatorIDFromDB = getUserDetailResponseInfoModel.OperatorID;
            GetOperatorID.AccountID = getUserDetailResponseInfoModel.AccountID;
            GetOperatorID.ClientName = getUserDetailResponseInfoModel.ComputerName;
            GetOperatorID.ClientID = getUserDetailResponseInfoModel.ClientID;
            GetOperatorID.AccountName = getUserDetailResponseInfoModel.ComputerName;
            GetOperatorID.LocalIPAddress = getUserDetailResponseInfoModel.IpAddress;
            GetOperatorID.Level = "PS";
            GetOperatorID.ClientType = "I";
            GetOperatorID.ClientTypeID = "I";
            GetOperatorID.cboImageTypeID = "B";

            if (getUserDetailResponseInfoModel.statusCode != "200")
            {
                throw new Exception(getUserDetailResponseInfoModel.Message);
            }

        }
        public void GetLogo()
        {
            AppData.imagedata = null;
            SqlDataReader read = (null);

            GetFingerPrintModel getFingerPrintModel= new GetFingerPrintModel();

            getFingerPrintModel.OurBranchID = GetOperatorID.VerificationBranchID;
            getFingerPrintModel.ClientID = "Sys";
            getFingerPrintModel.AccountID = null;
            getFingerPrintModel.ImageTypeID = "L";





            //using (SqlCommand cmd = new SqlCommand("p_GetfingerPrint", conn))
            //{
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@OurBranchID", SqlDbType.VarChar).Value = GetOperatorID.VerificationBranchID;
            //    cmd.Parameters.AddWithValue("@ClientID", SqlDbType.VarChar).Value = "Sys";
            //    cmd.Parameters.AddWithValue("@AccountID", SqlDbType.VarChar).Value = null;
            //    cmd.Parameters.AddWithValue("@ImageTypeID", SqlDbType.VarChar).Value = 'L';

            //try
            //{
            //    if (conn.State != ConnectionState.Open)
            //    {
            //        conn.Open();
            //    }
            //    read = cmd.ExecuteReader();
            //    while (read.Read())
            //    {

            //    }
            //    if (read.NextResult())
            //    {
            //        while (read.Read())
            //        {
            //            AppData.imagedata = (byte[])read["Image"];
            //        }
            //    }

            //    conn.Close();
            //}
            //catch (Exception ex)
            //{
            //    conn.Close();
            //    MessageBox.Show(ex.Message.ToString());
            //}
            //}
        }

        public void loginDetails(string txtUsernameID, string txtPasswordID)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            ServiceField.ErrorMessage = string.Empty;
            SqlDataReader read = (null);

            LoginResponse loginResponse = new LoginResponse();
            LoginModel loginModel = new LoginModel();

            loginModel.OurBranchID = AppData.BranchID;
            loginModel.operatorID = txtUsernameID; 
            loginModel.password = EncryptText(txtUsernameID.ToUpper() + txtPasswordID);
            loginModel.loginType = "E";

            var result = GetData("BIO/api/Biometric/BioLogin", loginModel);

            loginResponse = (LoginResponse)(new JavaScriptSerializer()).Deserialize(result, typeof(LoginResponse));

            ServiceField.MessageID = loginResponse.messageID;
            ServiceField.WorkingDate = loginResponse.workingDate;
            GetOperatorID.Level = loginResponse.levelID;
            GetOperatorID.InitialLevel = loginResponse.levelID;

            if(loginResponse.statusCode!="200")
            {
                ServiceField.ErrorMessage = loginResponse.Message;
            }


        }
        #endregion
    }





}
