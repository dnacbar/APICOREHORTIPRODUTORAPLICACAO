using APPDTOCOREHORTIQUERY.SIGNATURE;
using DOMAINCOREHORTICOMMAND;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.IQUERIES
{
    public interface IDiscrictRepository
    {
        Task<IEnumerable<District>> ListOfDistricts();
        Task<IEnumerable<District>> ListOfDistrictsByQuantity(ConsultByQuantitySignature signature);
        Task<District> DistrictById(ConsultDistrictSignature signature);
        Task<IEnumerable<District>> ListOfDistrictsByName(ConsultDistrictSignature signature);
    }
}
