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
                DsPassword = signature.Password.ToEncryptPasswordText()
            };
        }

        public static Userhorti ToDeleteUserDomain(this UserCommandSignature signature)
        {
            return new Userhorti
            {
                DsLogin = signature.Login,
                BoActive = false
            };
        }

        public static Userhorti ToUpdateUserDomain(this UserCommandSignature signature)
        {
            return new Userhorti
            { 
                DsLogin = signature.Login,
                DsPassword = signature.Password.ToEncryptPasswordText(),
                DtAtualization = DateTime.Now,
                BoActive = true
            };
        }
    }
}
