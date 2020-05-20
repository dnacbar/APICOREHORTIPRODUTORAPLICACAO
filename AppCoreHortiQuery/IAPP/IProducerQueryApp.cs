using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPCOREHORTIQUERY.IAPP
{
    public interface IProducerQueryApp
    {
        Task<ProducerResult> GetProducerByIdOrEmail(ConsultProducerSignature signature);
        Task<IEnumerable<ProducerResult>> GetFullListOfProducers();
        Task<IEnumerable<ProducerResult>> GetListOfProducers(ConsultProducerSignature signature);

    }
}
