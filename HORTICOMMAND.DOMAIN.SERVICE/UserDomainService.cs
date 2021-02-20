using FluentValidation;
using HORTI.CORE.CROSSCUTTING.EXTENSION;
using HORTICOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTICOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTICOMMAND.DOMAIN.MODEL;
using HORTICOMMAND.VALIDATION.DOMAIN;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.SERVICE
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
