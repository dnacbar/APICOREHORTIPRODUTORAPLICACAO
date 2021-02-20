using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACE.SERVICE
{
    public interface IDistrictDomainService
    {
        Task DistrictServiceCreate(District district);
        Task DistrictServiceDelete(District district);
        Task DistrictServiceUpdate(District district);
    }
}
