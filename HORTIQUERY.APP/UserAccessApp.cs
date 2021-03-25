using HORTI.CORE.CROSSCUTTING.ENCRYPTING;
using HORTI.CORE.CROSSCUTTING.EXTENSION;
using HORTIQUERY.DOMAIN.INTERFACE.APP;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY;
using HORTIQUERY.DOMAIN.MODEL.EXTENSION;
using HORTIQUERY.DOMAIN.MODEL.RESULT;
using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using System.Threading.Tasks;
using VALIDATIONCOREHORTIQUERY;

namespace HORTIQUERY.APP
{
    public sealed class UserAccessApp : IUserAccessApp
    {
        //private readonly IClientRepository _clientRepository;
        //private readonly IProducerRepository _producerRepository;
        //private readonly IUserAccessRepository _userAccessRepository;

        //private readonly UserAccessSignatureValidation _userAccessSignatureValidation;

        public UserAccessApp()//IClientRepository clientRepository,
                              //IProducerRepository producerRepository,
                              //IUserAccessRepository userAccessRepository)
                             //UserAccessSignatureValidation userAccessSignatureValidation)
        {
            //_clientRepository = clientRepository;
            //_producerRepository = producerRepository;
            //_userAccessRepository = userAccessRepository;
            //_userAccessSignatureValidation = userAccessSignatureValidation;
        }

        public async Task<IClientResult> ValidateUserAccessClient(IUserAccessQuerySignature signature)
        {
            //_userAccessSignatureValidation.ValidateHorti(signature);
            //var userHorti = await _userAccessRepository.GetUserHortiAccess(signature);
            //

            IClientResult result = new ClientResult();

            //if (userHorti == null)
            //    return result;
            //
            //var strDecryptPassword = signature.Password.ToDecryptPassworText(userHorti.DsPassword);
            //
            //if (signature.Password.Equals(strDecryptPassword))
            //{
            //    result = (await _clientRepository.ClientByIdOrName(new ClientQuerySignature
            //    {
            //        Email = signature.Login
            //    }))?.GetClientResult();
            //}

            return result;
        }

        public async Task<IProducerResult> ValidateUserAccessProducer(IUserAccessQuerySignature signature)
        {
            //_userAccessSignatureValidation.ValidateHorti(signature);
            //var userHorti = await _userAccessRepository.GetUserHortiAccess(signature);

            IProducerResult result = new ProducerResult();

            //if (userHorti == null)
            //    return result;
            //
            //var strDecryptPassword = signature.Password.ToDecryptPassworText(userHorti.DsPassword);
            //
            //if (signature.Password.Equals(strDecryptPassword))
            //{
            //    result = (await _producerRepository.ProducerByIdOrName(new ProducerQuerySignature
            //    {
            //        Email = signature.Login
            //    }))?.GetProducerResult();
            //}

            return result;
        }
    }
}
