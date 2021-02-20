using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY
{
    public interface IUnitRepository
    {
        Task<IEnumerable<Unit>> FullListOfUnits();
        Task<IEnumerable<Unit>> ListOfUnits(IUnitQuerySignature signature);
        Task<Unit> UnitById(IUnitQuerySignature signature);
    }
}
