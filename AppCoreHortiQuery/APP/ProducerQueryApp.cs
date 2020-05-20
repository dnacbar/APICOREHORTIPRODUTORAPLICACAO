using APPCOREHORTIQUERY.CONVERTER;
using APPCOREHORTIQUERY.IAPP;
using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using DATACOREHORTIQUERY.IQUERIES;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPCOREHORTIQUERY.APP
{
    public class ProducerQueryApp : IProducerQueryApp
    {
        private readonly IProducerRepository _producerRepository;

        public ProducerQueryApp(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public async Task<IEnumerable<ProducerResult>> GetFullListOfProducers()
        {
            return (await _producerRepository.FullListOfProducers()).ToHashSetProducerResult();
        }

        public async Task<IEnumerable<ProducerResult>> GetListOfProducers(ConsultProducerSignature signature)
        {
            return (await _producerRepository.ListOfProducers(signature)).ToHashSetProducerResult();
        }

        public async Task<ProducerResult> GetProducerByIdOrEmail(ConsultProducerSignature signature)
        {
            return (await _producerRepository.ProducerByIdOrEmail(signature)).ToProducerResult();
        }
    }
}
