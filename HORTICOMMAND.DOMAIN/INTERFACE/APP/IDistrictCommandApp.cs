using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACE.APP
{
    public interface IDistrictCommandApp
    {
        Task CreateDistrict(IDistrictCommandSignature signature);
        Task DeleteDistrict(IDistrictCommandSignature signature);
        Task UpdateDistrict(IDistrictCommandSignature signature);
    }
}
