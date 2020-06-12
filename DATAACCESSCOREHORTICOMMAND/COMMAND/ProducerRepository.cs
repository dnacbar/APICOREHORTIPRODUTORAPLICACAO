using DATAACCESSCOREHORTICOMMAND.ICOMMAND;
using DATACOREHORTICOMMAND;
using DOMAINCOREHORTICOMMAND;
using System.Threading.Tasks;

namespace DATAACCESSCOREHORTICOMMAND.COMMAND
{
    public sealed class ProducerRepository : _BaseRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(DBHORTICONTEXT DBHORTICONTEXT) : base(DBHORTICONTEXT) { }

        public async Task CreateProducer(Producer producer)
        {
            await CreateEntity(producer);
        }

        public async Task DeleteProducer(Producer producer)
        {
            await DeleteEntity(producer, true);
        }

        public async Task UpdateProducer(Producer producer)
        {
            await UpdateEntity(producer);
        }
    }
}
