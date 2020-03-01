using System;

namespace CROSSCUTTINGCOREHORTI.ENCRYPTING
{
    public static class EncryptText
    {
        public static string ToEncryptPasswordText(this string strPassword, string strMd5Hash)
        {
            var strReturn = string.Empty;

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

        public static string ToDecryptPassworText(this string strPassword, string strEncryptPassword)
        {
            var strReturn = string.Empty;

            var intRemove = (int)Math.Floor((decimal)(strEncryptPassword.Length - strPassword.Length) / strPassword.Length);

            for (int i = 0; i < strPassword.Length; i++)
            {
                strReturn += strEncryptPassword.Substring((intRemove * (i + 1)) + i, 1);
            }

            return strReturn;
        }
    }
}
