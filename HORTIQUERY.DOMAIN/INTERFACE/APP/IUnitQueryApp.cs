using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACE.APP
{
    public interface IUnitQueryApp
    {
        Task<IEnumerable<IUnitResult>> GetFullListOfUnits();
        Task<IEnumerable<IUnitResult>> GetListOfUnits(IUnitQuerySignature signature);
        Task<IUnitResult> GetUnitByIdOrName(IUnitQuerySignature signature);
    }
}
