using CROSSCUTTINGCOREHORTI.EXTENSION;
using DATAACCESSCOREHORTICOMMAND.ICOMMAND;
using DOMAINCOREHORTICOMMAND;
using SERVICECOREHORTICOMMAND.ISERVICE;
using System.Threading.Tasks;
using VALIDATIONCOREHORTICOMMAND.DOMAIN;

namespace SERVICECOREHORTICOMMAND.SERVICE
{
    public class ProducerDomainService : IProducerDomainService
    {
        private readonly CreateProducerDomainServiceValidation _createProducerDomainServiceValidation;
        private readonly UpdateProducerDomainServiceValidation _updateProducerDomainServiceValidation;

        private readonly IProducerRepository _producerRepository;

        public ProducerDomainService(CreateProducerDomainServiceValidation createProducerDomainServiceValidation,
                                     UpdateProducerDomainServiceValidation updateProducerDomainServiceValidation,
                                     IProducerRepository producerRepository)
        {
            _createProducerDomainServiceValidation = createProducerDomainServiceValidation;
            _updateProducerDomainServiceValidation = updateProducerDomainServiceValidation;

            _producerRepository = producerRepository;
        }

        public async Task ProducerServiceCreate(Producer producer)
        {
            _createProducerDomainServiceValidation.ValidateHorti(producer);

            await _producerRepository.CreateProducer(producer);
        }

        public async Task ProducerServiceUpdate(Producer producer)
        {
            _updateProducerDomainServiceValidation.ValidateHorti(producer);

            await _producerRepository.UpdateProducer(producer);
        }
    }
}
