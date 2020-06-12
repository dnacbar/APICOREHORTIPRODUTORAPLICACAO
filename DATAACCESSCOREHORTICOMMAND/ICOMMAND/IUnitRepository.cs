using DOMAINCOREHORTICOMMAND;
using System.Threading.Tasks;

namespace DATAACCESSCOREHORTICOMMAND.ICOMMAND
{
    public interface IUnitRepository
    {
        Task CreateUnit(Unit unit);
        Task DeleteUnit(Unit unit);
        Task UpdateUnit(Unit unit);
    }
}
