using HORTICOMMAND.DOMAIN.MODEL;
using FluentValidation;
using System;

namespace HORTICOMMAND.VALIDATION.DOMAIN
{
    public sealed class CreateClientDomainServiceValidation : AbstractValidator<Client>
    {
        public CreateClientDomainServiceValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.IdClient).NotEmpty();
            RuleFor(x => x.DsClient).NotEmpty().MaximumLength(100);
            RuleFor(x => x.PhoneObject).Must(x => string.IsNullOrEmpty(x.Phone) ? true : x.IsValid());
            RuleFor(x => x.FederalDocument).Must(x => string.IsNullOrEmpty(x.Document) ? true : x.IsValid());
            RuleFor(x => x.EmailObject).Must(x => string.IsNullOrEmpty(x.Email) ? true : x.IsValid());
        }
    }

    public sealed class UpdateClientDomainServiceValidation : AbstractValidator<Client>
    {
        public UpdateClientDomainServiceValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.IdClient).NotEmpty();
            RuleFor(x => x.DsClient).NotEmpty().MaximumLength(100);
            RuleFor(x => x.PhoneObject).Must(x => string.IsNullOrEmpty(x.Phone) ? true : x.IsValid());
            RuleFor(x => x.FederalDocument).Must(x => string.IsNullOrEmpty(x.Document) ? true : x.IsValid());
            RuleFor(x => x.EmailObject).Must(x => string.IsNullOrEmpty(x.Email) ? true : x.IsValid());
            RuleFor(x => x.DtAtualization.Date).Equal(DateTime.Today);
        }
    }
}
