using HORTIQUERY.DOMAIN.INTERFACE.APP;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY;
using HORTIQUERY.DOMAIN.MODEL.EXTENSION;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.APP
{
    public class ProducerQueryApp : IProducerQueryApp
    {
        private readonly IProducerRepository _producerRepository;

        public ProducerQueryApp(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public async Task<IEnumerable<IProducerResult>> GetFullListOfProducers()
        {
            return (await _producerRepository.FullListOfProducers()).GetListOfProducerResult();
        }

        public async Task<IEnumerable<IProducerResult>> GetListOfProducers(IProducerQuerySignature signature)
        {
            return (await _producerRepository.ListOfProducers(signature)).GetListOfProducerResult();
        }

        public async Task<IProducerResult> GetProducerByIdOrName(IProducerQuerySignature signature)
        {
            return (await _producerRepository.ProducerByIdOrName(signature)).GetProducerResult();
        }
    }
}
