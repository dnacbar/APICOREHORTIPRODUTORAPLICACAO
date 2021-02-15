using DOMAINCOREHORTICOMMAND;
using System.Threading.Tasks;

namespace SERVICECOREHORTICOMMAND.ISERVICE
{
    public interface IProducerDomainService
    {
        Task ProducerServiceCreate(Producer producer);
        Task ProducerServiceUpdate(Producer producer);
    }
}
