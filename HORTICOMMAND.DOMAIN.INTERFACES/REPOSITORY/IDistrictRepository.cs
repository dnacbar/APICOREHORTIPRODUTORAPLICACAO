using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACES.REPOSITORY
{
    public interface IDistrictRepository
    {
        Task CreateDistrict(District district);
        Task DeleteDistrict(District district);
        Task UpdateDistrict(District district);
    }
}
