using APPDTOCOREHORTICOMMAND.SIGNATURE;
using System.Threading.Tasks;

namespace APPCOREHORTICOMMAND.IAPP
{
    public interface IUnitCommandApp
    {
        Task CreateUnit(UnitCommandSignature signature);
        Task DeleteUnit(UnitCommandSignature signature);
        Task UpdateUnit(UnitCommandSignature signature);
    }
}
