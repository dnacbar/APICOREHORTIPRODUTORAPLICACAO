using APPDTOCOREHORTICOMMAND.SIGNATURE;
using HORTICROSSCUTTINGCORE.ENCRYPTING;
using HORTICOMMAND.DOMAIN.MODEL;
using System;

namespace HORTICOMMAND.APP.CONVERTER
{
    public static class UserConverter
    {
        public static Userhorti ToCreateUserDomain(this IUserCommandSignature signature)
        {
            return new Userhorti
            {
                DsLogin = signature.Login,
                DsPassword = signature.Password.ToEncryptPasswordText()
            };
        }

        public static Userhorti ToDeleteUserDomain(this IUserCommandSignature signature)
        {
            return new Userhorti
            {
                DsLogin = signature.Login,
                BoActive = false
            };
        }

        public static Userhorti ToUpdateUserDomain(this IUserCommandSignature signature)
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
