﻿using HORTI.CORE.CROSSCUTTING.FILE;
using HORTICOMMAND.APP.VALIDATION.APPLICATION;
using HORTICOMMAND.APP.VALIDATION.EXTENSION;
using HORTICOMMAND.DOMAIN.INTERFACE.APP;
using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTICOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTICOMMAND.DOMAIN.MODEL;
using System.IO;
using System.Threading.Tasks;

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

        public async Task CreateClient(IClientCommandSignature signature)
        {
            _createClientSignatureValidation.ValidateHorti(signature);

            var clientDomain = new Client(signature);
            await _clientDomainService.ClientServiceCreate(clientDomain);

            Directory.CreateDirectory(Path.Combine(Path.GetPathRoot(Directory.GetCurrentDirectory()), "CLIENT", clientDomain.IdClient.ToString()));
        }

        public async Task UpdateClient(IClientCommandSignature signature)
        {
            _updateClientSignatureValidation.ValidateHorti(signature);

            await _clientDomainService.ClientServiceUpdate(new Client(signature));

            CreateClientImage(signature);
        }

        private void CreateClientImage(IClientCommandSignature signature)
        {
            if (signature.ImageByte == null)
                return;

            if (!Directory.Exists(Path.Combine(Path.GetPathRoot(Directory.GetCurrentDirectory()), "CLIENT", signature.Id.ToString())))
                return;

            FileIO.CreateImage(Path.Combine(Path.GetPathRoot(Directory.GetCurrentDirectory()), "CLIENT", signature.Id.ToString(), signature.Id + ".png"), signature.ImageByte);
        }
    }
}