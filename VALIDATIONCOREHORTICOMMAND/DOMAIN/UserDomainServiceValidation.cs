using DOMAINCOREHORTICOMMAND;
using FluentValidation;

namespace VALIDATIONCOREHORTICOMMAND.DOMAIN
{
    public class UserDomainServiceValidation : AbstractValidator<Userhorti>
    {
        public UserDomainServiceValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Email).NotNull().Must(x => x.IsValid());
            RuleFor(x => x.DsPassword).NotEmpty();
        }
    }
}
