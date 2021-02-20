using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACE.SERVICE
{
    public interface IProducerDomainService
    {
        Task ProducerServiceCreate(Producer producer);
        Task ProducerServiceUpdate(Producer producer);
    }
}
