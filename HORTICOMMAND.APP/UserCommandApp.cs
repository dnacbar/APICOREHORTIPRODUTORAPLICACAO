using HORTI.CORE.CROSSCUTTING.EXTENSION;
using HORTICOMMAND.DOMAIN.INTERFACE.APP;
using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTICOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTICOMMAND.DOMAIN.MODEL.SIGNATURE;
using HORTICOMMAND.VALIDATION.APPLICATION;
using System.Threading.Tasks;
using HORTICOMMAND.DOMAIN.MODEL.EXTENSION;

namespace HORTICOMMAND.APP
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

        public async Task CreateUser(IUserCommandSignature signature)
        {
            _createUserSignatureValidation.ValidateHorti(signature);

            await _userDomainService.UserServiceCreate(signature.GetUserhorti());

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

        public async Task InactiveUser(IUserCommandSignature signature)
        {
            _deleteUserSignatureValidation.ValidateHorti(signature);

            await _userDomainService.UserServiceDelete(signature.GetUserhorti());
        }

        public async Task UpdateUser(IUserCommandSignature signature)
        {
            _updateUserSignatureValidation.ValidateHorti(signature);

            await _userDomainService.UserServiceUpdate(signature.GetUserhorti());
        }
    }
}
