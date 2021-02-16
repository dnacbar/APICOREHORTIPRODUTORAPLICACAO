using HORTICOMMAND.DOMAIN.MODEL;
using FluentValidation;
using System;

namespace HORTICOMMAND.VALIDATION.APPLICATION
{
    public sealed class CreateDistrictDomainServiceValidation : AbstractValidator<IDistrict>
    {
        public CreateDistrictDomainServiceValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.IdDistrict).NotEmpty();
            RuleFor(x => x.DsDistrict).MaximumLength(50);
        }
    }

    public sealed class UpdateDistrictDomainServiceValidation : AbstractValidator<IDistrict>
    {
        public UpdateDistrictDomainServiceValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.IdDistrict).NotEmpty();
            RuleFor(x => x.DsDistrict).MaximumLength(50);
            RuleFor(x => x.DtAtualization.Date).Equal(DateTime.Today);
        }
    }
}
