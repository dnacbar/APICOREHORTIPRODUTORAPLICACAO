using HORTI.CORE.CROSSCUTTING.DBBASEEF;
using HORTICOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTICOMMAND.REPOSITORY
{
    public sealed class DistrictRepository : _BaseEFCommandRepository<District>, IDistrictRepository
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
