using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY
{
    public interface IDiscrictRepository
    {
        Task<District> DistrictByIdOrName(IDistrictQuerySignature signature);
        Task<IEnumerable<District>> FullListOfDistricts();
        Task<IEnumerable<District>> ListOfDistricts(IDistrictQuerySignature signature);
    }
}
