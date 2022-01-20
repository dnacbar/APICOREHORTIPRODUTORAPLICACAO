using HORTIQUERY.DOMAIN.INTERFACE.APP;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY;
using HORTIQUERY.DOMAIN.MODEL.EXTENSION;
using HORTIQUERY.DOMAIN.MODEL.RESULT;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.APP
{
    public class DistrictQueryApp : IDistrictQueryApp
    {
        private readonly IDiscrictRepository _discrictRepository;

        public DistrictQueryApp(IDiscrictRepository discrictRepository)
        {
            _discrictRepository = discrictRepository;
        }

        public async Task<IDistrictResult> GetDistrictByIdOrName(IDistrictQuerySignature signature)
        {
            return new DistrictResult(await _discrictRepository.DistrictByIdOrName(signature));
        }

        public async Task<IEnumerable<IDistrictResult>> GetFullListOfDistricts()
        {
            return (await _discrictRepository.FullListOfDistricts()).GetListOfDistrictResult();
        }

        public async Task<IEnumerable<IDistrictResult>> GetListOfDistricts(IDistrictQuerySignature signature)
        {
            return (await _discrictRepository.ListOfDistricts(signature)).GetListOfDistrictResult();
        }
    }
}
