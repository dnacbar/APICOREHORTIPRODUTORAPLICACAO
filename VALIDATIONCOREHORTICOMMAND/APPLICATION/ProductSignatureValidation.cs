using APPDTOCOREHORTICOMMAND.SIGNATURE;
using FluentValidation;
using System;

namespace VALIDATIONCOREHORTICOMMAND.APPLICATION
{
    public sealed class CreateProductSignatureValidation : AbstractValidator<ProductCommandSignature>
    {
        public CreateProductSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Product).NotEmpty();
            RuleFor(x => x.Value).GreaterThanOrEqualTo(0);
            RuleFor(x => x.DateDiscount).GreaterThan(DateTime.Today);
        }
    }

    public sealed class DeleteProductSignatureValidation : AbstractValidator<ProductCommandSignature>
    {
        public DeleteProductSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }

    public sealed class UpdateProductSignatureValidation : AbstractValidator<ProductCommandSignature>
    {
        public UpdateProductSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Product).NotEmpty();
            RuleFor(x => x.DateDiscount.Value.Date).GreaterThan(DateTime.Today);
            RuleFor(x => x.Value).GreaterThanOrEqualTo(0);
        }
    }
}
