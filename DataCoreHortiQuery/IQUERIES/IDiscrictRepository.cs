using APPDTOCOREHORTIQUERY.SIGNATURE;
using DomainCoreHortiCommand;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.IQUERIES
{
    public interface IDiscrictRepository
    {
        Task<IEnumerable<District>> ListOfDistricts();
        Task<IEnumerable<District>> ListOfDistrictsByQuantity(ConsultByQuantitySignature signature);
        Task<District> DistrictById(ConsultDistrictByIdNameSignature signature);
        Task<IEnumerable<District>> ListOfDistrictsByName(ConsultDistrictByIdNameSignature signature);
    }
}
