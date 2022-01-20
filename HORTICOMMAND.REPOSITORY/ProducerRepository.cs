using HORTI.CORE.CROSSCUTTING.DBBASEEF;
using HORTICOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTICOMMAND.REPOSITORY
{
    public sealed class ProducerRepository : _BaseEFCommandRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(DBHORTICONTEXT DBHORTICONTEXT) : base(DBHORTICONTEXT) { }

        public Task CreateProducer(Producer producer)
        {
            return CreateEntity(producer);
        }

        public Task UpdateProducer(Producer producer)
        {
            return UpdateEntity(producer);
        }
    }
}
