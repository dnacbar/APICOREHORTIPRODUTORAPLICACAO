using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.IQUERIES
{
    public interface IDiscrictRepository
    {
        Task<IDistrict> DistrictByIdOrName(ConsultDistrictSignature signature);
        Task<IEnumerable<IDistrict>> FullListOfDistricts();
        Task<IEnumerable<IDistrict>> ListOfDistricts(ConsultDistrictSignature signature);
    }
}
