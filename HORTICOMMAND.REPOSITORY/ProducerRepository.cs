using HORTI.CORE.CROSSCUTTING.DBBASEEF;
using HORTICOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTICOMMAND.REPOSITORY
{
    public sealed class ProducerRepository : _BaseEFCommandRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(DBHORTICONTEXT DBHORTICONTEXT) : base(DBHORTICONTEXT) { }

        public async Task CreateProducer(Producer producer)
        {
            await CreateEntity(producer);
        }

        public async Task UpdateProducer(Producer producer)
        {
            await UpdateEntity(producer);
        }
    }
}
