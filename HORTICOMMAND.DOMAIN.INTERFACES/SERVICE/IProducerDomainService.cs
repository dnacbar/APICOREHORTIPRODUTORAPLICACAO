using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACES.SERVICE
{
    public interface IProducerDomainService
    {
        Task ProducerServiceCreate(Producer producer);
        Task ProducerServiceUpdate(Producer producer);
    }
}
