using DOMAINCOREHORTICOMMAND;
using System.Threading.Tasks;

namespace SERVICECOREHORTICOMMAND.ISERVICE
{
    public interface IDistrictDomainService
    {
        Task DistrictServiceCreate(District district);
        Task DistrictServiceDelete(District district);
        Task DistrictServiceUpdate(District district);
    }
}
