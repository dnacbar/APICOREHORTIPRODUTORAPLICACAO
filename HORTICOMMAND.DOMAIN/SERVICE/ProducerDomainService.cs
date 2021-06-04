using HORTICOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTICOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.SERVICE
{
    public class ProducerDomainService : IProducerDomainService
    {
        private readonly IProducerRepository _producerRepository;

        public ProducerDomainService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public async Task ProducerServiceCreate(Producer producer)
        {
            await _producerRepository.CreateProducer(producer);
        }

        public async Task ProducerServiceUpdate(Producer producer)
        {
            await _producerRepository.UpdateProducer(producer);
        }
    }
}
