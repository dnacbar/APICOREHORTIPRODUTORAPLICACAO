using APPCOREHORTIQUERY.CONVERTERS;
using APPCOREHORTIQUERY.INTERFACES;
using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using CROSSCUTTINGCOREHORTI.ENCRYPTING;
using DATACOREHORTIQUERY.IQUERIES;
using FluentValidation;
using System.Threading.Tasks;
using VALIDATIONCOREHORTIQUERY;

namespace APPCOREHORTIQUERY
{
    public sealed class UserAccessApp : IUserAccessApp
    {
        private readonly IClientRepository _clientRepository;
        private readonly IProducerRepository _producerRepository;
        private readonly IUserAccessRepository _userAccessRepository;

        private readonly UserAccessSignatureValidation _userAccessSignatureValidation;

        public UserAccessApp(IClientRepository clientRepository,
                             IProducerRepository producerRepository,
                             IUserAccessRepository userAccessRepository,
                             UserAccessSignatureValidation userAccessSignatureValidation)
        {
            _clientRepository = clientRepository;
            _producerRepository = producerRepository;
            _userAccessRepository = userAccessRepository;
            _userAccessSignatureValidation = userAccessSignatureValidation;
        }

        public async Task<UserClientInformationResult> ValidateUserAccessClient(UserAccessSignature signature)
        {
            _userAccessSignatureValidation.ValidateAndThrow(signature);

            var userClientReturn = new UserClientInformationResult();

            var userHorti = await _userAccessRepository.GetUserAccessHorti(signature);

            if (userHorti == null)
                return userClientReturn;

            var strDecryptPassword = signature.DsPassword.ToDecryptPassworText(userHorti.DsPassword);

            if (signature.DsPassword.Equals(strDecryptPassword))
            {
                userClientReturn = (await _clientRepository.GetClientByEmail(new ConsultClientSignature
                {
                    DsEmail = signature.DsLogin
                }))?.ToUserClientInformationResult();
            }

            return userClientReturn;
        }

        public async Task<UserProducerInformationResult> ValidateUserAccessProducer(UserAccessSignature signature)
        {
            var userProducerReturn = new UserProducerInformationResult();

            var userHorti = await _userAccessRepository.GetUserAccessHorti(signature);

            if (userHorti == null)
                return userProducerReturn;

            var strDecryptPassword = signature.DsPassword.ToDecryptPassworText(userHorti.DsPassword);

            if (signature.DsPassword.Equals(strDecryptPassword))
            {
                userProducerReturn = (await _producerRepository.GetProducerByEmail(new ConsultProducerSignature
                {
                    DsEmail = signature.DsLogin
                }))?.ToUserProducerInformationResult();
            }

            return userProducerReturn;
        }
    }
}
