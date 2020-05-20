using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPCOREHORTIQUERY.IAPP
{
    public interface IUnitQueryApp
    {
        Task<IEnumerable<UnitResult>> GetFullListOfUnits();
        Task<IEnumerable<UnitResult>> GetListOfUnits(ConsultUnitSignature signature);
        Task<UnitResult> GetUnitById(ConsultUnitSignature signature);
    }
}
