using DOMAINCOREHORTICOMMAND;
using FluentValidation;
using System;

namespace VALIDATIONCOREHORTICOMMAND.DOMAIN
{
    public class ClientDomainServiceValidation : AbstractValidator<Client>
    {
        public ClientDomainServiceValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.PhoneObject).Must(x => string.IsNullOrEmpty(x.Phone) ? true : x.IsValid());
            RuleFor(x => x.FederalDocument).Must(x => string.IsNullOrEmpty(x.Document) ? true : x.IsValid());
            RuleFor(x => x.EmailObject).Must(x => string.IsNullOrEmpty(x.Email) ? true : x.IsValid());
            RuleFor(x => x.DtCreation).Equal(DateTime.Today);
        }
    }
}
