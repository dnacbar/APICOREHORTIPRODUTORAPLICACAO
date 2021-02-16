using DATAACCESSCOREHORTICOMMAND.ICOMMAND;
using HORTICOMMAND.REPOSITORY;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace DATAACCESSCOREHORTICOMMAND.COMMAND
{
    public sealed class DistrictRepository : _BaseRepository<IDistrict>, IDistrictRepository
    {
        public DistrictRepository(DBHORTICONTEXT DBHORTICONTEXT) : base(DBHORTICONTEXT) { }

        public async Task CreateDistrict(IDistrict district)
        {
            await CreateEntity(district);
        }

        public async Task DeleteDistrict(IDistrict district)
        {
            await DeleteEntity(district);
        }

        public async Task UpdateDistrict(IDistrict district)
        {
            await UpdateEntity(district);
        }
    }
}
