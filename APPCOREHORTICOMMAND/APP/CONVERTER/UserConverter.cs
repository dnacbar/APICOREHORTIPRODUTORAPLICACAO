using APPDTOCOREHORTICOMMAND.SIGNATURE;
using CROSSCUTTINGCOREHORTI.ENCRYPTING;
using DOMAINCOREHORTICOMMAND;
using System;

namespace APPCOREHORTICOMMAND.APP.CONVERTER
{
    public static class UserConverter
    {
        public static Userhorti ToCreateUserDomain(this UserCommandSignature signature)
        {
            return new Userhorti
            {
                DsLogin = signature.Login,
                DsPassword = signature.Password.ToEncryptPasswordText(),
                DtCreation = DateTime.Now
            };
        }
    }
}
