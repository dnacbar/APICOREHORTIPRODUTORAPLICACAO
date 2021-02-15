using System;

namespace CROSSCUTTINGCOREHORTI.ENCRYPTING
{
    public static class EncryptText
    {
        public static string ToEncryptPasswordText(this string strPassword)
        {
            var strReturn = string.Empty;

            var strMd5Hash = EncryptMD5Hash.CreateMd5Hash(strPassword).Result;
            var strGuid = Guid.NewGuid().ToString().Replace("-", "").ToUpperInvariant();
            try
            {
                for (int i = 0; i < strGuid.Length; i++)
                {
                    strReturn += strGuid.Substring(i, 1) + strMd5Hash.Substring(i, 1);
                }

                var intInsert = (int)Math.Floor((decimal)strReturn.Length / strPassword.Length);

                for (int i = 0; i < strPassword.Length; i++)
                {
                    strReturn = strReturn.Insert((intInsert * (i + 1)) + i, strPassword.Substring(i, 1));
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return strReturn;
        }

        public static string ToDecryptPassworText(this string strPassword, string strEncryptedPassword)
        {
            var strReturn = string.Empty;

            var intRemove = (int)Math.Floor((decimal)(strEncryptedPassword.Length - strPassword.Length) / strPassword.Length);

            for (int i = 0; i < strPassword.Length; i++)
            {
                strReturn += strEncryptedPassword.Substring((intRemove * (i + 1)) + i, 1);
            }

            return strReturn;
        }
    }
}
