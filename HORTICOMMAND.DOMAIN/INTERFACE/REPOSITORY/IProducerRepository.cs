using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACE.REPOSITORY
{
    public interface IProducerRepository
    {
        Task CreateProducer(Producer producer);
        Task UpdateProducer(Producer producer);
    }
}
