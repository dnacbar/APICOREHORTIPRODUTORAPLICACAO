using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY
{
    public interface IDiscrictRepository
    {
        Task<District> DistrictByIdOrName(IDistrictQuerySignature signature);
        Task<List<District>> FullListOfDistricts();
        Task<List<District>> ListOfDistricts(IDistrictQuerySignature signature);
    }
}
