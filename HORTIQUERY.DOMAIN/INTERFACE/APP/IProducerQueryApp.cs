using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACE.APP
{
    public interface IProducerQueryApp
    {
        Task<IProducerResult> GetProducerByIdOrEmail(IProducerQuerySignature signature);
        Task<IEnumerable<IProducerResult>> GetFullListOfProducers();
        Task<IEnumerable<IProducerResult>> GetListOfProducers(IProducerQuerySignature signature);

    }
}
