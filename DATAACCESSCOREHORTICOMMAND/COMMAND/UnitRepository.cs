using DATAACCESSCOREHORTICOMMAND.ICOMMAND;
using DATACOREHORTICOMMAND;
using DOMAINCOREHORTICOMMAND;
using System.Threading.Tasks;

namespace DATAACCESSCOREHORTICOMMAND.COMMAND
{
    public sealed class UnitRepository : _BaseRepository<Unit>, IUnitRepository
    {
        public UnitRepository(DBHORTICONTEXT DBHORTICONTEXT) : base(DBHORTICONTEXT) { }

        public async Task CreateUnit(Unit unit)
        {
            await CreateEntity(unit);
        }

        public async Task DeleteUnit(Unit unit)
        {
            await DeleteEntity(unit);
        }

        public async Task UpdateUnit(Unit unit)
        {
            await UpdateEntity(unit);
        }
    }
}
