using APPCOREHORTIQUERY.CONVERTERS;
using APPCOREHORTIQUERY.INTERFACES;
using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using CROSSCUTTINGCOREHORTI.ENCRYPTING;
using CROSSCUTTINGCOREHORTI.EXTENSION;
using DATACOREHORTIQUERY.IQUERIES;
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

        public async Task<UserClientResult> ValidateUserAccessClient(UserAccessSignature signature)
        {
            _userAccessSignatureValidation.ValidateHorti(signature);

            var userClientReturn = new UserClientResult();

            var userHorti = await _userAccessRepository.GetUserAccessHorti(signature);

            if (userHorti == null)
                return null;

            var strDecryptPassword = signature.DsPassword.ToDecryptPassworText(userHorti.DsPassword);

            if (signature.DsPassword.Equals(strDecryptPassword))
            {
                userClientReturn = (await _clientRepository.ClientByIdOrEmail(new ConsultClientSignature
                {
                    DsEmail = signature.DsLogin
                }))?.ToUserClientInformationResult();
            }

            return userClientReturn;
        }

        public async Task<UserProducerInformationResult> ValidateUserAccessProducer(UserAccessSignature signature)
        {
            _userAccessSignatureValidation.Validate(signature);

            var userProducerReturn = new UserProducerInformationResult();

            var userHorti = await _userAccessRepository.GetUserAccessHorti(signature);

            if (userHorti == null)
                return userProducerReturn;

            var strDecryptPassword = signature.DsPassword.ToDecryptPassworText(userHorti.DsPassword);

            if (signature.DsPassword.Equals(strDecryptPassword))
            {
                userProducerReturn = (await _producerRepository.ProducerByIdOrEmail(new ConsultProducerSignature
                {
                    DsEmail = signature.DsLogin
                }))?.ToUserProducerInformationResult();
            }

            return userProducerReturn;
        }
    }
}
