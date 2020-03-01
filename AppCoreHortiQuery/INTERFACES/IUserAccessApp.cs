using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using System.Threading.Tasks;

namespace APPCOREHORTIQUERY.INTERFACES
{
    public interface IUserAccessApp
    {
        Task<UserClientInformationResult> ValidateUserAccessClient(UserAccessSignature signature);
        Task<UserProducerInformationResult> ValidateUserAccessProducer(UserAccessSignature signature);
    }
}
