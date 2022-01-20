using HORTI.CORE.CROSSCUTTING.DBBASEEF;
using HORTICOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTICOMMAND.REPOSITORY
{
    public sealed class DistrictRepository : _BaseEFCommandRepository<District>, IDistrictRepository
    {
        public DistrictRepository(DBHORTICONTEXT DBHORTICONTEXT) : base(DBHORTICONTEXT) { }

        public Task CreateDistrict(District district)
        {
            return CreateEntity(district);
        }

        public Task DeleteDistrict(District district)
        {
            return DeleteEntity(district);
        }

        public Task UpdateDistrict(District district)
        {
            return UpdateEntity(district);
        }
    }
}
