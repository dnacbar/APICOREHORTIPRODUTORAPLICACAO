using APPDTOCOREHORTIQUERY.SIGNATURE;
using DOMAINCOREHORTICOMMAND;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.IQUERIES
{
    public interface IProducerRepository
    {
        Task<Producer> ProducerByIdOrEmail(ConsultProducerSignature signature);
    }
}
