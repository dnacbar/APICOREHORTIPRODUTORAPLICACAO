using HORTICROSSCUTTINGCORE.EXTENSION;
using DATAACCESSCOREHORTICOMMAND.ICOMMAND;
using HORTICOMMAND.DOMAIN.MODEL;
using FluentValidation;
using SERVICECOREHORTICOMMAND.ISERVICE;
using System;
using System.Threading.Tasks;
using HORTICOMMAND.VALIDATION.DOMAIN;

namespace SERVICECOREHORTICOMMAND.SERVICE
{
    public class UserDomainService : IUserDomainService
    {
        private readonly CreateUserDomainServiceValidation _createUserDomainServiceValidation;
        private readonly UpdateUserDomainServiceValidation _updateUserDomainServiceValidation;

        private readonly IUserRepository _userRepository;
        
        public UserDomainService(CreateUserDomainServiceValidation createUserDomainServiceValidation,
                                 UpdateUserDomainServiceValidation updateUserDomainServiceValidation,
                                 IUserRepository userRepository)
        {
            _createUserDomainServiceValidation = createUserDomainServiceValidation;
            _updateUserDomainServiceValidation = updateUserDomainServiceValidation;
            _userRepository = userRepository;
        }

        public async Task UserServiceCreate(Userhorti userhorti)
        {
            _createUserDomainServiceValidation.ValidateHorti(userhorti);

            await _userRepository.CreateUser(userhorti);
        }

        public async Task UserServiceDelete(Userhorti userhorti)
        {
            if (string.IsNullOrEmpty(userhorti.DsLogin))
                throw new ValidationException("USER NOT EXISTS!");

            await _userRepository.DeleteUser(userhorti);
        }

        public async Task UserServiceUpdate(Userhorti userhorti)
        {
            _updateUserDomainServiceValidation.ValidateHorti(userhorti);

            await _userRepository.UpdateUser(userhorti);
        }
    }
}
