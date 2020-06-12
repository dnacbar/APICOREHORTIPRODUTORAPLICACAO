using CROSSCUTTINGCOREHORTI.EXTENSION;
using DATAACCESSCOREHORTICOMMAND.ICOMMAND;
using DOMAINCOREHORTICOMMAND;
using SERVICECOREHORTICOMMAND.ISERVICE;
using System;
using System.Threading.Tasks;
using VALIDATIONCOREHORTICOMMAND.DOMAIN;

namespace SERVICECOREHORTICOMMAND.SERVICE
{
    public class UserDomainService : IUserDomainService
    {
        private readonly UserDomainServiceValidation _userDomainServiceValidation;
        private readonly IUserRepository _userRepository;
        
        public UserDomainService(UserDomainServiceValidation userDomainServiceValidation,
                                 IUserRepository userRepository)
        {
            _userDomainServiceValidation = userDomainServiceValidation;
            _userRepository = userRepository;
        }

        public async Task UserServiceCreate(Userhorti userhorti)
        {
            _userDomainServiceValidation.ValidateHorti(userhorti);

            await _userRepository.CreateUser(userhorti);
        }

        public async Task UserServiceDelete(Userhorti userhorti)
        {
            await _userRepository.DeleteUser(userhorti);
        }

        public async Task UserServiceUpdate(Userhorti userhorti)
        {
            _userDomainServiceValidation.ValidateHorti(userhorti);

            await _userRepository.UpdateUser(userhorti);
        }
    }
}
