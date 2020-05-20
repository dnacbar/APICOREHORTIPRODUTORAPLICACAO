using APPCOREHORTIQUERY.CONVERTER;
using APPCOREHORTIQUERY.IAPP;
using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using DATACOREHORTIQUERY.IQUERIES;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPCOREHORTIQUERY.APP
{
    public class DistrictQueryApp : IDistrictQueryApp
    {
        private readonly IDiscrictRepository _discrictRepository;

        public DistrictQueryApp(IDiscrictRepository discrictRepository)
        {
            _discrictRepository = discrictRepository;
        }

        public async Task<DistrictResult> GetDistrictByIdOrName(ConsultDistrictSignature signature)
        {
            return (await _discrictRepository.DistrictByIdOrName(signature)).ToDistrictResult();
        }

        public async Task<IEnumerable<DistrictResult>> GetFullListOfDistricts()
        {
            return (await _discrictRepository.FullListOfDistricts()).ToHashSetDistrictResult();
        }

        public async Task<IEnumerable<DistrictResult>> GetListOfDistricts(ConsultDistrictSignature signature)
        {
            return (await _discrictRepository.ListOfDistricts(signature)).ToHashSetDistrictResult();
        }
    }
}
