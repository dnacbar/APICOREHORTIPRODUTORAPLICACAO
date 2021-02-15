using APPDTOCOREHORTICOMMAND.SIGNATURE;
using System.Threading.Tasks;

namespace APPCOREHORTICOMMAND.IAPP
{
    public interface IDistrictCommandApp
    {
        Task CreateDistrict(DistrictCommandSignature signature);
        Task DeleteDistrict(DistrictCommandSignature signature);
        Task UpdateDistrict(DistrictCommandSignature signature);
    }
}
