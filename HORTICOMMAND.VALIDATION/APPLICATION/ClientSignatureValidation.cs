using FluentValidation;
using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY;
using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using System;
using System.Threading.Tasks;

namespace HORTICOMMAND.VALIDATION.APPLICATION
{
    public sealed class CreateClientSignatureValidation : AbstractValidator<IClientCommandSignature>
    {
        public CreateClientSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.EmailObject).NotEmpty().Must(x => x.IsValid());
            RuleFor(x => x.PhoneObject).Must(x => string.IsNullOrEmpty(x.Phone) ? true : x.IsValid());
        }
    }

    public sealed class UpdateClientSignatureValidation : AbstractValidator<IClientCommandSignature>
    {
        private readonly IClientRepository _clientRepository;

        public UpdateClientSignatureValidation(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;

            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.EmailObject).NotEmpty().Must(x => x.IsValid());
            RuleFor(x => x.PhoneObject).Must(x => string.IsNullOrEmpty(x.Phone) ? true : x.IsValid());
            RuleFor(x => x.FederalDocument).Must(x => string.IsNullOrEmpty(x.Document) ? true : x.IsValid());
            RuleFor(x => x).MustAsync(async (x, y) => await ValidateClientExists(x.Id.Value, x.Email));
        }

        private async Task<bool> ValidateClientExists(Guid idClient, string dsEmail)
        {
            return await _clientRepository.ClientByIdOrEmail(new ClientQuerySignature { Id = idClient, Email = dsEmail }) != null;
        }
    }
}