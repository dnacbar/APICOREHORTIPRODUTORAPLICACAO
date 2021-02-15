using APPDTOCOREHORTICOMMAND.SIGNATURE;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using DATACOREHORTIQUERY.IQUERIES;
using FluentValidation;
using System;
using System.Threading.Tasks;

namespace VALIDATIONCOREHORTICOMMAND.APPLICATION
{
    public sealed class CreateClientSignatureValidation : AbstractValidator<ClientCommandSignature>
    {
        public CreateClientSignatureValidation()
        {
            RuleFor(x => x).NotEmpty();
            RuleFor(x => x.EmailObject).NotEmpty().Must(x => x.IsValid());
            RuleFor(x => x.PhoneObject).Must(x => string.IsNullOrEmpty(x.Phone) ? true : x.IsValid());
        }
    }

    public sealed class UpdateClientSignatureValidation : AbstractValidator<ClientCommandSignature>
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
            return await _clientRepository.ClientByIdOrEmail(new ConsultClientSignature { IdClient = idClient, DsEmail = dsEmail }) != null;
        }
    }
}