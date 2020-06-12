using APPDTOCOREHORTIQUERY.SIGNATURE;
using DOMAINCOREHORTICOMMAND;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.IQUERIES
{
    public interface IDiscrictRepository
    {
        Task<District> DistrictByIdOrName(ConsultDistrictSignature signature);
        Task<IEnumerable<District>> FullListOfDistricts();
        Task<IEnumerable<District>> ListOfDistricts(ConsultDistrictSignature signature);
    }
}
