using HORTIQUERY.DOMAIN.INTERFACES.MODEL.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACES.APP
{
    public interface IUserAccessApp
    {
        Task<ClientResult> ValidateUserAccessClient(UserAccessSignature signature);
        Task<ProducerResult> ValidateUserAccessProducer(UserAccessSignature signature);
    }
}
