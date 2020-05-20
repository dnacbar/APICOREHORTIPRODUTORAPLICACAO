using DATAACCESSCOREHORTICOMMAND.ICOMMAND;
using DATACOREHORTICOMMAND;
using DOMAINCOREHORTICOMMAND;
using System.Threading.Tasks;

namespace DATAACCESSCOREHORTICOMMAND.COMMAND
{
    public sealed class DistrictRepository : _BaseRepository<District>, IDistrictRepository
    {
        public DistrictRepository(DBHORTICONTEXT DBHORTICONTEXT) : base(DBHORTICONTEXT) { }

        public async Task CreateDistrict(District district)
        {
            await CreateEntity(district);
        }

        public async Task DeleteDistrict(District district)
        {
            await DeleteEntity(district);
        }

        public async Task UpdateDistrict(District district)
        {
            await UpdateEntity(district);
        }
    }
}
