using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using System.Threading.Tasks;

namespace APPCOREHORTIQUERY.IAPP
{
    public interface IUserAccessApp
    {
        Task<ClientResult> ValidateUserAccessClient(UserAccessSignature signature);
        Task<ProducerResult> ValidateUserAccessProducer(UserAccessSignature signature);
    }
}
