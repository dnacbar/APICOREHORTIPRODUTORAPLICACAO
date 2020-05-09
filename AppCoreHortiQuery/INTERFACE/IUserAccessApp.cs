using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using System.Threading.Tasks;

namespace APPCOREHORTIQUERY.INTERFACES
{
    public interface IUserAccessApp
    {
        Task<UserClientResult> ValidateUserAccessClient(UserAccessSignature signature);
        Task<UserProducerResult> ValidateUserAccessProducer(UserAccessSignature signature);
    }
}
