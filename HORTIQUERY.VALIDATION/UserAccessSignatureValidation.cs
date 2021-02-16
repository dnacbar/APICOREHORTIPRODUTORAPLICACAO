using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using FluentValidation;

namespace VALIDATIONCOREHORTIQUERY
{
    public class UserAccessSignatureValidation : AbstractValidator<UserAccessSignature>
    {
        public UserAccessSignatureValidation()
        {
            RuleFor(x => x.DsLogin).NotNull().NotEmpty();
            RuleFor(x => x.DsPassword).NotNull().NotEmpty();
        }
    }
}
