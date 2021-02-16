using HORTICOMMAND.DOMAIN.INTERFACES.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACES.APP
{
    public interface IProducerCommandApp
    {
        Task CreateProducer(IProducerCommandSignature signature);
        Task UpdateProducer(IProducerCommandSignature signature);
    }
}
