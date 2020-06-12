using APPCOREHORTICOMMAND.APP.CONVERTER;
using APPCOREHORTICOMMAND.IAPP;
using APPDTOCOREHORTICOMMAND.SIGNATURE;
using CROSSCUTTINGCOREHORTI.EXTENSION;
using SERVICECOREHORTICOMMAND.ISERVICE;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VALIDATIONCOREHORTICOMMAND.APPLICATION;

namespace APPCOREHORTICOMMAND.APP
{
    public sealed class ClientCommandApp : IClientCommandApp
    {
        private readonly CreateClientSignatureValidation _createClientSignatureValidation;
        private readonly DeleteClientSignatureValidation _deleteClientSignatureValidation;
        private readonly UpdateClientSignatureValidation _updateClientSignatureValidation;

        private readonly IClientDomainService _clientDomainService;

        public ClientCommandApp(CreateClientSignatureValidation createClientSignatureValidation,
                                DeleteClientSignatureValidation deleteClientSignatureValidation,
                                UpdateClientSignatureValidation updateClientSignatureValidation,
                                IClientDomainService clientDomainService)
        {
            _createClientSignatureValidation = createClientSignatureValidation;
            _deleteClientSignatureValidation = deleteClientSignatureValidation;
            _updateClientSignatureValidation = updateClientSignatureValidation;

            _clientDomainService = clientDomainService;
        }

        public async Task CreateClient(ClientCommandSignature signature)
        {
            _createClientSignatureValidation.ValidateHorti(signature);

            await _clientDomainService.ClientServiceCreate(signature.ToCreateClientDomain());
        }

        public Task DeleteClient(ClientCommandSignature signature)
        {
            throw new NotImplementedException();
        }

        public Task UpdateClient(ClientCommandSignature signature)
        {
            throw new NotImplementedException();
        }
    }
}
