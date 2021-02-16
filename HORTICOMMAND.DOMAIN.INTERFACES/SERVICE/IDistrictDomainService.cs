using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACES.SERVICE
{
    public interface IDistrictDomainService
    {
        Task DistrictServiceCreate(District district);
        Task DistrictServiceDelete(District district);
        Task DistrictServiceUpdate(District district);
    }
}
