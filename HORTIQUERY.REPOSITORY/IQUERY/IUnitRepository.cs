using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.IQUERIES
{
    public interface IUnitRepository
    {
        Task<IEnumerable<Unit>> FullListOfUnits();
        Task<IEnumerable<Unit>> ListOfUnits(ConsultUnitSignature signature);
        Task<Unit> UnitById(ConsultUnitSignature signature);
    }
}
