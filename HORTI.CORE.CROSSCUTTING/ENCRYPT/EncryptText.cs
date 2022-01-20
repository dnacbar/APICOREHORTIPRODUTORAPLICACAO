using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HORTI.CORE.CROSSCUTTING.ENCRYPTING
{
    public static class EncryptText
    {
        private const int DefautLengthPassword = 64;
        public static string ToEncryptPasswordText(this string strPassword)
        {
            if (string.IsNullOrEmpty(strPassword.Trim()))
                return string.Empty;

            var strReturn = string.Empty;

            var strMd5Hash = CreateMd5Hash(strPassword);
            var strGuid = Guid.NewGuid().ToString().Replace("-", "").ToUpperInvariant();

            for (int i = 0; i < strGuid.Length; i++)
            {
                strReturn += strGuid.Substring(i, 1) + strMd5Hash.Substring(i, 1);
            }

            var intInsert = (int)Math.Floor((decimal)strReturn.Length / strPassword.Length);

            for (int i = 0; i < strPassword.Length; i++)
            {
                strReturn = strReturn.Insert((intInsert * (i + 1)) + i, strPassword.Substring(i, 1));
            }

            return strReturn;
        }

        public static bool ToDecryptPasswordText(this string strPassword, string strEncryptedPassword)
        {
            if (string.IsNullOrEmpty(strPassword?.Trim()) || string.IsNullOrEmpty(strEncryptedPassword?.Trim()))
                return false;

            var intPassword = strEncryptedPassword.Length - DefautLengthPassword;

            if (strPassword.Length != intPassword)
                return false;

            var strReturn = string.Empty;

            var intRemove = (int)Math.Floor((decimal) DefautLengthPassword / intPassword);

            for (int i = 0; i < intPassword; i++)
            {
                strReturn += strEncryptedPassword.Substring((intRemove * (i + 1)) + i, 1);
            }

            return strReturn == strPassword;
        }

        private static string CreateMd5Hash(string strMd5Hash)
        {
            using (var md5Hash = MD5.Create())
            {
                // CONVERT THE INPUT STRING TO A BYTE ARRAY AND COMPUTE THE HASH
                var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(strMd5Hash));

                var sBuilder = new StringBuilder();

                // LOOP THROUGH EACH BYTE OF THE HASHED DATA 
                // AND FORMAT EACH ONE AS A HEXADECIMAL STRING
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // RETURN THE HEXADECIMAL STRING
                return sBuilder.ToString();
            }
        }
    }
}
