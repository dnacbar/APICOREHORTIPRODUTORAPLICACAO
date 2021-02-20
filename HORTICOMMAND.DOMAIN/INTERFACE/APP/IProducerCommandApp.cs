using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACE.APP
{
    public interface IProducerCommandApp
    {
        Task CreateProducer(IProducerCommandSignature signature);
        Task UpdateProducer(IProducerCommandSignature signature);
    }
}
