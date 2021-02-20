using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACE.APP
{
    public interface IUserAccessApp
    {
        Task<IClientResult> ValidateUserAccessClient(IUserAccessQuerySignature signature);
        Task<IProducerResult> ValidateUserAccessProducer(IUserAccessQuerySignature signature);
    }
}
