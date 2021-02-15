using DOMAINCOREHORTICOMMAND;
using System.Threading.Tasks;

namespace DATAACCESSCOREHORTICOMMAND.ICOMMAND
{
    public interface IProducerRepository
    {
        Task CreateProducer(Producer producer);
        Task UpdateProducer(Producer producer);
    }
}
