using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACE.APP
{
    public interface IDistrictQueryApp
    {
        Task<IDistrictResult> GetDistrictByIdOrName(IDistrictQuerySignature signature);
        Task<IEnumerable<IDistrictResult>> GetFullListOfDistricts();
        Task<IEnumerable<IDistrictResult>> GetListOfDistricts(IDistrictQuerySignature signature);
    }
}
