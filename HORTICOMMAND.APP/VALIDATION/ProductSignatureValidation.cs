using FluentValidation;
using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;

namespace HORTICOMMAND.APP.VALIDATION.APPLICATION
{
    public sealed class CreateProductSignatureValidation : AbstractValidator<IProductCommandSignature>
    {
        public CreateProductSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Product).NotEmpty();
            RuleFor(x => x.Value).GreaterThanOrEqualTo(0);
            RuleFor(x => x.DateDiscount).GreaterThan(DateTime.Today);
        }
    }

    public sealed class DeleteProductSignatureValidation : AbstractValidator<IProductCommandSignature>
    {
        public DeleteProductSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }

    public sealed class UpdateProductSignatureValidation : AbstractValidator<IProductCommandSignature>
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
