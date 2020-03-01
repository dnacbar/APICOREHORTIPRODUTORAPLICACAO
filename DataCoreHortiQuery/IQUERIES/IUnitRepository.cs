using APPDTOCOREHORTIQUERY.SIGNATURE;
using DOMAINCOREHORTICOMMAND;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.IQUERIES
{
    public interface IUnitRepository
    {
        Task<IEnumerable<Unit>> ListOfUnits();
        Task<IEnumerable<Unit>> ListOfUnitsByName(ConsultUnitSignature signature);
        Task<Unit> UnitById(ConsultUnitSignature signature);
    }
}
