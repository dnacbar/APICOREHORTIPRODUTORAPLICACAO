using HORTICOMMAND.DOMAIN.INTERFACES.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACES.APP
{
    public interface IDistrictCommandApp
    {
        Task CreateDistrict(IDistrictCommandSignature signature);
        Task DeleteDistrict(IDistrictCommandSignature signature);
        Task UpdateDistrict(IDistrictCommandSignature signature);
    }
}
