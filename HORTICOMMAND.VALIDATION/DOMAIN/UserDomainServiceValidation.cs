using HORTICOMMAND.DOMAIN.MODEL;
using FluentValidation;
using System;

namespace HORTICOMMAND.VALIDATION.DOMAIN
{
    public class CreateUserDomainServiceValidation : AbstractValidator<Userhorti>
    {
        public CreateUserDomainServiceValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Email).NotNull().Must(x => x.IsValid());
            RuleFor(x => x.DsPassword).NotEmpty();
        }
    }

    public class UpdateUserDomainServiceValidation : AbstractValidator<Userhorti>
    {
        public UpdateUserDomainServiceValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Email).NotNull().Must(x => x.IsValid());
            RuleFor(x => x.DsPassword).NotEmpty();
            RuleFor(x => x.DtAtualization.Date).Equal(DateTime.Today);
        }
    }
}
