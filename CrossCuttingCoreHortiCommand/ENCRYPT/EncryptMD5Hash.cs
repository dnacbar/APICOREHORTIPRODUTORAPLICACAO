using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CROSSCUTTINGCOREHORTI.ENCRYPTING
{
    public static class EncryptMD5Hash
    {
        public static async Task<bool> VerifyHash(string strMd5Hash, string strToCompare)
        {
            var strMd5HashToCompare = await CreateMd5Hash(strToCompare);

            // CREATE A STRINGCOMPARER TO COMPARE THE HASHES
            var comparer = StringComparer.OrdinalIgnoreCase;

            return Convert.ToBoolean(comparer.Compare(strMd5Hash, strMd5HashToCompare));
        }

        public static async Task<string> CreateMd5Hash(string strMd5Hash)
        {
            using (var md5Hash = MD5.Create())
            {
                // CONVERT THE INPUT STRING TO A BYTE ARRAY AND COMPUTE THE HASH
                var data = await Task.Run(() => md5Hash.ComputeHash(Encoding.UTF8.GetBytes(strMd5Hash)));

                var sBuilder = new StringBuilder();

                // LOOP THROUGH EACH BYTE OF THE HASHED DATA 
                // AND FORMAT EACH ONE AS A HEXADECIMAL STRING
                Parallel.For(0, data.Length, (i) =>
                {
                    sBuilder.Append(data[i].ToString("x2"));
                });

                // RETURN THE HEXADECIMAL STRING
                return sBuilder.ToString();
            }
        }
    }
}
