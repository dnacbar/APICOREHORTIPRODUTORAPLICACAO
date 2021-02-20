using FluentValidation;
using HORTI.CORE.CROSSCUTTING.EXTENSION;
using HORTICOMMAND.DOMAIN.MODEL;
using System;

namespace HORTICOMMAND.VALIDATION.DOMAIN
{
    public sealed class CreateProducerDomainServiceValidation : AbstractValidator<Producer>
    {
        public CreateProducerDomainServiceValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.IdProducer).NotEmpty();
            RuleFor(x => x.DsProducer).NotEmpty().MaximumLength(100);
            RuleFor(x => x.PhoneObject).Must(x => string.IsNullOrEmpty(x.Phone) ? true : x.IsValid());
            RuleFor(x => x.FederalDocument).Must(x => string.IsNullOrEmpty(x.Document) ? true : x.IsValid());
            RuleFor(x => x.EmailObject).Must(x => string.IsNullOrEmpty(x.Email) ? true : x.IsValid());
            RuleFor(x => x.DsZip).Must(x => string.IsNullOrEmpty(x) ? true : x.IsOnlyNumber());
        }
    }

    public sealed class UpdateProducerDomainServiceValidation : AbstractValidator<Producer>
    {
        public UpdateProducerDomainServiceValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.IdProducer).NotEmpty();
            RuleFor(x => x.DsProducer).NotEmpty().MaximumLength(100);
            RuleFor(x => x.PhoneObject).Must(x => string.IsNullOrEmpty(x.Phone) ? true : x.IsValid());
            RuleFor(x => x.FederalDocument).Must(x => string.IsNullOrEmpty(x.Document) ? true : x.IsValid());
            RuleFor(x => x.EmailObject).Must(x => string.IsNullOrEmpty(x.Email) ? true : x.IsValid());
            RuleFor(x => x.DsZip).Must(x => string.IsNullOrEmpty(x) ? true : x.IsOnlyNumber());
            RuleFor(x => x.DtAtualization.Date).Equal(DateTime.Today);
        }
    }
}
