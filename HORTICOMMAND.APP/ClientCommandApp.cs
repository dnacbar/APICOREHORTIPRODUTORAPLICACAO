using HORTICOMMAND.APP.CONVERTER;
using HORTICOMMAND.DOMAIN.INTERFACES.APP;
using APPDTOCOREHORTICOMMAND.SIGNATURE;
using HORTICROSSCUTTINGCORE.EXTENSION;
using HORTICROSSCUTTINGCORE.FILE;
using SERVICECOREHORTICOMMAND.ISERVICE;
using System.IO;
using System.Threading.Tasks;
using HORTICOMMAND.VALIDATION.APPLICATION;

namespace HORTICOMMAND.APP
{
    public sealed class ClientCommandApp : IClientCommandApp
    {
        private readonly CreateClientSignatureValidation _createClientSignatureValidation;
        private readonly UpdateClientSignatureValidation _updateClientSignatureValidation;

        private readonly IClientDomainService _clientDomainService;

        public ClientCommandApp(CreateClientSignatureValidation createClientSignatureValidation,
                                UpdateClientSignatureValidation updateClientSignatureValidation,
                                IClientDomainService clientDomainService)
        {
            _createClientSignatureValidation = createClientSignatureValidation;
            _updateClientSignatureValidation = updateClientSignatureValidation;

            _clientDomainService = clientDomainService;
        }

        public async Task CreateClient(ClientCommandSignature signature)
        {
            _createClientSignatureValidation.ValidateHorti(signature);

            var clientDomain = signature.ToCreateClientDomain();
            await _clientDomainService.ClientServiceCreate(clientDomain);

            Directory.CreateDirectory(Path.Combine(Path.GetPathRoot(Directory.GetCurrentDirectory()), "CLIENT", clientDomain.IdClient.ToString()));
        }

        public async Task UpdateClient(ClientCommandSignature signature)
        {
            _updateClientSignatureValidation.ValidateHorti(signature);

            await _clientDomainService.ClientServiceUpdate(signature.ToUpdateClientDomain());

            CreateClientImage(signature);
        }

        private void CreateClientImage(ClientCommandSignature signature)
        {
            if (signature.ImageByte == null)
                return;

            if (!Directory.Exists(Path.Combine(Path.GetPathRoot(Directory.GetCurrentDirectory()), "CLIENT", signature.Id.ToString())))
                return;

            FileIO.CreateImage(Path.Combine(Path.GetPathRoot(Directory.GetCurrentDirectory()), "CLIENT", signature.Id.ToString(), signature.Id + ".png"), signature.ImageByte);
        }
    }
}