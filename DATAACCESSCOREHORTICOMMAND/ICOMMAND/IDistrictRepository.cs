using DOMAINCOREHORTICOMMAND;
using System.Threading.Tasks;

namespace DATAACCESSCOREHORTICOMMAND.ICOMMAND
{
    public interface IDistrictRepository
    {
        Task CreateDistrict(District district);
        Task DeleteDistrict(District district);
        Task UpdateDistrict(District district);
    }
}
