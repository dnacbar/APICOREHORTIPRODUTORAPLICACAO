using DOMAINCOREHORTICOMMAND;
using FluentValidation;
using System;

namespace VALIDATIONCOREHORTICOMMAND.DOMAIN
{
    public class ProductDomainServiceValidation : AbstractValidator<Product>
    {
        public ProductDomainServiceValidation()
        {
            RuleFor(x => x).NotNull().Must(x => x.ValidatePercentDiscount());
            RuleFor(x => x.IdProduct).NotEmpty();
            RuleFor(x => x.DsProduct).NotEmpty();
            RuleFor(x => x.NmValue).GreaterThanOrEqualTo(0);
            RuleFor(x => x.DtDiscount.Value.Date).GreaterThan(DateTime.Today);
        }
    }
}
