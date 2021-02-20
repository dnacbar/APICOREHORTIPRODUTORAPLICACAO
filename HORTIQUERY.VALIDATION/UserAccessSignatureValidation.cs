using FluentValidation;
using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;

namespace VALIDATIONCOREHORTIQUERY
{
    public class UserAccessSignatureValidation : AbstractValidator<IUserAccessQuerySignature>
    {
        public UserAccessSignatureValidation()
        {
            RuleFor(x => x.Login).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}
