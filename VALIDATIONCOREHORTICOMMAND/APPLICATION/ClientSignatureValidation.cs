using APPDTOCOREHORTICOMMAND.SIGNATURE;
using FluentValidation;

namespace VALIDATIONCOREHORTICOMMAND.APPLICATION
{
    public sealed class CreateClientSignatureValidation : AbstractValidator<ClientCommandSignature>
    {
        public CreateClientSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.EmailObject).NotEmpty().Must(x => x.IsValid());
            RuleFor(x => x.PhoneObject).Must(x => string.IsNullOrEmpty(x.Phone) ? true : x.IsValid());
            RuleFor(x => x.FederalDocument).Must(x => string.IsNullOrEmpty(x.Document) ? true : x.IsValid());
        }
    }

    public sealed class DeleteClientSignatureValidation : AbstractValidator<ClientCommandSignature>
    {
        public DeleteClientSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.EmailObject).NotEmpty().Must(x => x.IsValid());
        }
    }

    public sealed class UpdateClientSignatureValidation : AbstractValidator<ClientCommandSignature>
    {
        public UpdateClientSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.EmailObject).NotEmpty().Must(x => x.IsValid());
            RuleFor(x => x.PhoneObject).Must(x => string.IsNullOrEmpty(x.Phone) ? true : x.IsValid());
            RuleFor(x => x.FederalDocument).Must(x => string.IsNullOrEmpty(x.Document) ? true : x.IsValid());
        }
    }
}