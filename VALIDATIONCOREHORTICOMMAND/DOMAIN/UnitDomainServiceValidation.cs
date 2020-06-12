using DOMAINCOREHORTICOMMAND;
using FluentValidation;

namespace VALIDATIONCOREHORTICOMMAND.DOMAIN
{
    public sealed class UnitDomainServiceValidation : AbstractValidator<Unit>
    {
        public UnitDomainServiceValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.DsUnit).NotEmpty();
        }
    }
}
