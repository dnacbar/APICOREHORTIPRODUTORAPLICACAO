using APPDTOCOREHORTICOMMAND.SIGNATURE;
using FluentValidation;

namespace HORTICOMMAND.VALIDATION.APPLICATION
{
    public sealed class CreateProducerSignatureValidation : AbstractValidator<IProducerCommandSignature>
    {
        public CreateProducerSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.EmailObject).NotEmpty().Must(x => x.IsValid());
            RuleFor(x => x.PhoneObject).Must(x => string.IsNullOrEmpty(x.Phone) ? true : x.IsValid());
            RuleFor(x => x.FederalDocument).Must(x => string.IsNullOrEmpty(x.Document) ? true : x.IsValid());
        }
    }

    public sealed class UpdateProducerSignatureValidation : AbstractValidator<IProducerCommandSignature>
    {
        public UpdateProducerSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.EmailObject).NotEmpty().Must(x => x.IsValid());
            RuleFor(x => x.PhoneObject).Must(x => string.IsNullOrEmpty(x.Phone) ? true : x.IsValid());
            RuleFor(x => x.FederalDocument).Must(x => string.IsNullOrEmpty(x.Document) ? true : x.IsValid());
        }
    }
}