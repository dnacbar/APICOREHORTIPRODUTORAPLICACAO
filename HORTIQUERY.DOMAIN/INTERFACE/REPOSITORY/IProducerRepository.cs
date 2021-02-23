using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY
{
    public interface IProducerRepository
    {
        Task<IEnumerable<Producer>> FullListOfProducers();
        Task<IEnumerable<Producer>> ListOfProducers(IProducerQuerySignature signature);
        Task<Producer> ProducerByIdOrName(IProducerQuerySignature signature);
    }
}
