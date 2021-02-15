using DOMAINCOREHORTICOMMAND;
using FluentValidation;
using System;

namespace VALIDATIONCOREHORTICOMMAND.APPLICATION
{
    public sealed class CreateDistrictDomainServiceValidation : AbstractValidator<District>
    {
        public CreateDistrictDomainServiceValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.IdDistrict).NotEmpty();
            RuleFor(x => x.DsDistrict).MaximumLength(50);
        }
    }

    public sealed class UpdateDistrictDomainServiceValidation : AbstractValidator<District>
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
