using HORTI.CORE.CROSSCUTTING.ENCRYPTING;
using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;

namespace HORTICOMMAND.DOMAIN.MODEL.EXTENSION
{
    public static class UserExtension
    {
        public static Userhorti GetUserhorti(this IUserCommandSignature signature)
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
