using HORTICOMMAND.DOMAIN.MODEL.ENUM;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;

namespace HORTIQUERY.DOMAIN.MODEL.EXTENSION
{
    public static class SignatureExtension
    {
        public static void ValidateSignature(this ISignature signature, EnumException enumException)
        {
            //if (signature is null)
            //    throw new FluentValidation.ValidationException(enumException.ToString());
        }
    }
}
