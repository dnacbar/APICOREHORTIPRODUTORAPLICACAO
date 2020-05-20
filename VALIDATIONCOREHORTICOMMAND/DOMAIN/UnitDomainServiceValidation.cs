using DOMAINCOREHORTICOMMAND;
using FluentValidation;

namespace VALIDATIONCOREHORTICOMMAND.DOMAIN
{
    public sealed class UnitDomainServiceValidation : AbstractValidator<Unit>
    {
        public UnitDomainServiceValidation()
        {
            RuleFor(x => x).NotNull().Must(x => !string.IsNullOrEmpty(x.DsUnit));
        }
    }
}
