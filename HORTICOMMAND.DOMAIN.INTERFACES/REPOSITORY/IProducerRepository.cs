using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACES.REPOSITORY
{
    public interface IProducerRepository
    {
        Task CreateProducer(Producer producer);
        Task UpdateProducer(Producer producer);
    }
}
