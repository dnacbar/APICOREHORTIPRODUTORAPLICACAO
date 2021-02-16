using HORTICOMMAND.DOMAIN.MODEL;
using FluentValidation;
using System;

namespace HORTICOMMAND.VALIDATION.DOMAIN
{
    public class CreateProductDomainServiceValidation : AbstractValidator<IProduct>
    {
        public CreateProductDomainServiceValidation()
        {
            RuleFor(x => x).NotEmpty().Must(x => x.ValidatePercentDiscount());
            RuleFor(x => x.IdProduct).NotEmpty();
            RuleFor(x => x.DsProduct).NotEmpty();
            RuleFor(x => x.NmValue).GreaterThanOrEqualTo(0);
            RuleFor(x => x.DtDiscount.Value.Date).GreaterThan(DateTime.Today);
        }
    }

    public class UpdateProductDomainServiceValidation : AbstractValidator<IProduct>
    {
        public UpdateProductDomainServiceValidation()
        {
            RuleFor(x => x).NotEmpty().Must(x => x.ValidatePercentDiscount());
            RuleFor(x => x.IdProduct).NotEmpty();
            RuleFor(x => x.DsProduct).NotEmpty();
            RuleFor(x => x.NmValue).GreaterThanOrEqualTo(0);
            RuleFor(x => x.DtDiscount.Value.Date).GreaterThan(DateTime.Today);
            RuleFor(x => x.DtAtualization).Equal(DateTime.Today);
        }
    }
}
