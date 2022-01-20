using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY
{
    public interface IUnitRepository
    {
        Task<List<Unit>> FullListOfUnits();
        Task<List<Unit>> ListOfUnits(IUnitQuerySignature signature);
        Task<Unit> UnitByIdOrName(IUnitQuerySignature signature);
    }
}
