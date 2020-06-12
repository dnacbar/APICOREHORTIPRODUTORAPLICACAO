using APPCOREHORTICOMMAND.APP.CONVERTER;
using APPCOREHORTICOMMAND.IAPP;
using APPDTOCOREHORTICOMMAND.SIGNATURE;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using CROSSCUTTINGCOREHORTI.EXTENSION;
using DATACOREHORTIQUERY.IQUERIES;
using FluentValidation;
using SERVICECOREHORTICOMMAND.ISERVICE;
using System;
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
        private readonly IUserAccessRepository _userAccessRepository;
        private readonly IUserDomainService _userDomainService;

        public UserCommandApp(CreateUserSignatureValidation createUserSignatureValidation,
                              DeleteUserSignatureValidation deleteUserSignatureValidation,
                              UpdateUserSignatureValidation updateUserSignatureValidation,
                              IClientCommandApp clientCommandApp,
                              IUserAccessRepository userAccessRepository,
                              IUserDomainService userDomainService)
        {
            _createUserSignatureValidation = createUserSignatureValidation;
            _deleteUserSignatureValidation = deleteUserSignatureValidation;
            _updateUserSignatureValidation = updateUserSignatureValidation;

            _clientCommandApp = clientCommandApp;
            _userAccessRepository = userAccessRepository;
            _userDomainService = userDomainService;
        }

        public async Task CreateUser(UserCommandSignature signature)
        {
            _createUserSignatureValidation.ValidateHorti(signature);

            if (!await ValidateUserNotExists(signature))
                throw new ValidationException("USER ALREADY EXISTS!");


            await _userDomainService.UserServiceCreate(signature.ToCreateUserDomain());

            // PRODUCER OR CLIENT
            if (signature.IsProducer)
            {

            }
            else
            {
                await _clientCommandApp.CreateClient(new ClientCommandSignature { Email = signature.Login, Client = signature.UserName });
            }
        }

        public async Task DeleteUser(UserCommandSignature signature)
        {
            _deleteUserSignatureValidation.ValidateHorti(signature);

            if (await ValidateUserNotExists(signature))
                throw new ValidationException("USER NOT FOUND!");

            await _userDomainService.UserServiceDelete(signature.ToCreateUserDomain());
        }

        public async Task UpdateUser(UserCommandSignature signature)
        {
            _updateUserSignatureValidation.ValidateHorti(signature);

            if (await ValidateUserNotExists(signature))
                throw new ValidationException("USER NOT FOUND!");

            await _userDomainService.UserServiceUpdate(signature.ToCreateUserDomain());
        }

        private async Task<bool> ValidateUserNotExists(UserCommandSignature signature)
        {
            return (await _userAccessRepository.GetUserAccessHorti(new UserAccessSignature { DsLogin = signature.Login })) == null;
        }
    }
}
