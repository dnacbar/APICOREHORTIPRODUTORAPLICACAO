using HORTIQUERY.DOMAIN.INTERFACES.MODEL.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACES.APP
{
    public interface IUnitQueryApp
    {
        Task<IEnumerable<IUnitResult>> GetFullListOfUnits();
        Task<IEnumerable<IUnitResult>> GetListOfUnits(ConsultUnitSignature signature);
        Task<IUnitResult> GetUnitById(ConsultUnitSignature signature);
    }
}
