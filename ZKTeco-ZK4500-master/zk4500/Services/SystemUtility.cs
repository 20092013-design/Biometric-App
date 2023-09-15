using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrint_LT.Services
{
    public class SupremeUtility
    {
        public static IEnumerable<object> SerializeDapperRow(Dapper.SqlMapper.GridReader multi)
        {
            IEnumerable<object> mod = multi.Read().Select(dic => dic as IDictionary<string, object>).
                   Select(r => r.ToDictionary(d => d.Key, d => d.Value?.ToString()));
            return mod;
        }

        public static string EncodePassword(string value)
        {
            byte[] data = Array.ConvertAll<char, byte>(value.ToCharArray(), delegate (char ch) { return (byte)ch; });
            SHA256 shaM = new SHA256Managed();
            byte[] result = shaM.ComputeHash(data);
            return Convert.ToBase64String(result);
        }

        static public string EncryptText(string strInputText)
        {
            byte[] data = Array.ConvertAll<char, byte>(strInputText.ToCharArray(), delegate (char ch) { return (byte)ch; });
            SHA256 shaM = new SHA256Managed();
            byte[] result = shaM.ComputeHash(data);
            return Convert.ToBase64String(result);
        }



        //public class TokenServices
        //{
        //    public const string ResetPasswordTokenPurpose = "RP";
        //    private const string ConfirmLoginTokenPurpose = "LC";
        //    public static TokenValidation ValidateToken(string validToken)
        //    {
        //        try
        //        {
        //            var loginResult = SystemSecurity.TokenAuthenticate(validToken);
        //            UserInfoModel userModel = new UserInfoModel();
        //            //userModel.UserID = loginResult.UserID;
        //            userModel.UserName = loginResult.OperatorID.ToUpper();
        //            userModel.SecurityStamp = loginResult.SecurityStamp;

        //            var validation = SystemTokenServices.ValidateToken(ConfirmLoginTokenPurpose, userModel, validToken);

        //            return validation;
        //        }
        //        catch (Exception ee)
        //        {
        //            var result = new TokenValidation();
        //            result.Errors.Add(TokenValidationStatus.Expired);
        //            SystemUtilitiesServices.WriteErrorLog(ref ee);
        //            return result;
        //        }
        //    }

        public static string ConvertStringToHex(string asciiString)
        {
            string hex = "";
            foreach (char c in asciiString)
            {
                int tmp = c;
                hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
            }
            return hex;
        }

        public static string ConvertHexToString(string HexValue)
        {
            string StrValue = "";
            while (HexValue.Length > 0)
            {
                StrValue += System.Convert.ToChar(System.Convert.ToUInt32(HexValue.Substring(0, 2), 16)).ToString();
                HexValue = HexValue.Substring(2, HexValue.Length - 2);
            }
            return StrValue;
        }
    }
}
