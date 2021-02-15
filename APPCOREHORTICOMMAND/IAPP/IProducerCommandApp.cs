using APPDTOCOREHORTICOMMAND.SIGNATURE;
using System.Threading.Tasks;

namespace APPCOREHORTICOMMAND.IAPP
{
    public interface IProducerCommandApp
    {
        Task CreateProducer(ProducerCommandSignature signature);
        Task UpdateProducer(ProducerCommandSignature signature);
    }
}
