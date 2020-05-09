using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPCOREHORTIQUERY.INTERFACES
{
    public interface IConsultDistrictApp
    {
        Task<DistrictResult> GetDistrictByIdOrName(ConsultDistrictSignature signature);
        Task<IEnumerable<DistrictResult>> GetFullListOfDistricts();
        Task<IEnumerable<DistrictResult>> GetListOfDistricts(ConsultDistrictSignature signature);
    }
}
