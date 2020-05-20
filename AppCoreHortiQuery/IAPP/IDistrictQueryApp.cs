using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPCOREHORTIQUERY.IAPP
{
    public interface IDistrictQueryApp
    {
        Task<DistrictResult> GetDistrictByIdOrName(ConsultDistrictSignature signature);
        Task<IEnumerable<DistrictResult>> GetFullListOfDistricts();
        Task<IEnumerable<DistrictResult>> GetListOfDistricts(ConsultDistrictSignature signature);
    }
}
