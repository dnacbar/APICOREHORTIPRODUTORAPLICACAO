using HORTIQUERY.DOMAIN.INTERFACES.MODEL.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACES.APP
{
    public interface IProducerQueryApp
    {
        Task<ProducerResult> GetProducerByIdOrEmail(ConsultProducerSignature signature);
        Task<IEnumerable<ProducerResult>> GetFullListOfProducers();
        Task<IEnumerable<ProducerResult>> GetListOfProducers(ConsultProducerSignature signature);

    }
}
