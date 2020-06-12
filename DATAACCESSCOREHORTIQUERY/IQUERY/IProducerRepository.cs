using APPDTOCOREHORTIQUERY.SIGNATURE;
using DOMAINCOREHORTICOMMAND;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.IQUERIES
{
    public interface IProducerRepository
    {
        Task<IEnumerable<Producer>> FullListOfProducers();
        Task<IEnumerable<Producer>> ListOfProducers(ConsultProducerSignature signature);
        Task<Producer> ProducerByIdOrEmail(ConsultProducerSignature signature);
    }
}
