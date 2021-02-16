using DATAACCESSCOREHORTICOMMAND.ICOMMAND;
using HORTICOMMAND.REPOSITORY;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace DATAACCESSCOREHORTICOMMAND.COMMAND
{
    public sealed class ProducerRepository : _BaseRepository<IProducer>, IProducerRepository
    {
        public ProducerRepository(DBHORTICONTEXT DBHORTICONTEXT) : base(DBHORTICONTEXT) { }

        public async Task CreateProducer(IProducer producer)
        {
            await CreateEntity(producer);
        }

        public async Task UpdateProducer(IProducer producer)
        {
            await UpdateEntity(producer);
        }
    }
}
