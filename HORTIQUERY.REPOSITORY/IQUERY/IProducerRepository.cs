using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.IQUERIES
{
    public interface IProducerRepository
    {
        Task<IEnumerable<IProducer>> FullListOfProducers();
        Task<IEnumerable<IProducer>> ListOfProducers(ConsultProducerSignature signature);
        Task<IProducer> ProducerByIdOrEmail(ConsultProducerSignature signature);
    }
}
