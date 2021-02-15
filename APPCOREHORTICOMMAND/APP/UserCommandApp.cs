using APPCOREHORTICOMMAND.APP.CONVERTER;
using APPCOREHORTICOMMAND.IAPP;
using APPDTOCOREHORTICOMMAND.SIGNATURE;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using CROSSCUTTINGCOREHORTI.EXTENSION;
using DATACOREHORTIQUERY.IQUERIES;
using FluentValidation;
using SERVICECOREHORTICOMMAND.ISERVICE;
using System.Threading.Tasks;
using VALIDATIONCOREHORTICOMMAND.APPLICATION;

namespace APPCOREHORTICOMMAND.APP
{
    public class UserCommandApp : IUserCommandApp
    {
        private readonly CreateUserSignatureValidation _createUserSignatureValidation;
        private readonly DeleteUserSignatureValidation _deleteUserSignatureValidation;
        private readonly UpdateUserSignatureValidation _updateUserSignatureValidation;

        private readonly IClientCommandApp _clientCommandApp;
        private readonly IProducerCommandApp _producerCommandApp;
        private readonly IUserDomainService _userDomainService;

        public UserCommandApp(CreateUserSignatureValidation createUserSignatureValidation,
                              DeleteUserSignatureValidation deleteUserSignatureValidation,
                              UpdateUserSignatureValidation updateUserSignatureValidation,
                              IClientCommandApp clientCommandApp,
                              IProducerCommandApp producerCommandApp,
                              IUserDomainService userDomainService)
        {
            _createUserSignatureValidation = createUserSignatureValidation;
            _deleteUserSignatureValidation = deleteUserSignatureValidation;
            _updateUserSignatureValidation = updateUserSignatureValidation;

            _clientCommandApp = clientCommandApp;
            _producerCommandApp = producerCommandApp;
            _userDomainService = userDomainService;
        }

        public async Task CreateUser(UserCommandSignature signature)
        {
            _createUserSignatureValidation.ValidateHorti(signature);

            await _userDomainService.UserServiceCreate(signature.ToCreateUserDomain());

            if (signature.IsProducer)
            {
                await _producerCommandApp.CreateProducer(new ProducerCommandSignature
                {
                    Email = signature.Login,
                    Producer = signature.UserName,
                    Phone = signature.Phone
                });
            }
            else
            {
                await _clientCommandApp.CreateClient(new ClientCommandSignature
                {
                    Email = signature.Login,
                    Client = signature.UserName,
                    Phone = signature.Phone
                });
            }
        }

        public async Task InactiveUser(UserCommandSignature signature)
        {
            _deleteUserSignatureValidation.ValidateHorti(signature);

            await _userDomainService.UserServiceDelete(signature.ToDeleteUserDomain());
        }

        public async Task UpdateUser(UserCommandSignature signature)
        {
            _updateUserSignatureValidation.ValidateHorti(signature);

            await _userDomainService.UserServiceUpdate(signature.ToUpdateUserDomain());
        }
    }
}
