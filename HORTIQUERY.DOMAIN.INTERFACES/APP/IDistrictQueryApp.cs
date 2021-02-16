using HORTIQUERY.DOMAIN.INTERFACES.MODEL.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACES.APP
{
    public interface IDistrictQueryApp
    {
        Task<IDistrictResult> GetDistrictByIdOrName(ConsultDistrictSignature signature);
        Task<IEnumerable<IDistrictResult>> GetFullListOfDistricts();
        Task<IEnumerable<IDistrictResult>> GetListOfDistricts(ConsultDistrictSignature signature);
    }
}
