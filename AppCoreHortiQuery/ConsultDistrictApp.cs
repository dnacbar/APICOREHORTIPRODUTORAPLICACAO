using APPCOREHORTIQUERY.CONVERTERS;
using APPCOREHORTIQUERY.INTERFACES;
using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using DATACOREHORTIQUERY.IQUERIES;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPCOREHORTIQUERY
{
    public class ConsultDistrictApp : IConsultDistrictApp
    {
        private readonly IDiscrictRepository _discrictRepository;

        public ConsultDistrictApp(IDiscrictRepository discrictRepository)
        {
            _discrictRepository = discrictRepository;
        }

        public async Task<ConsultDistrictResult> GetDistrictById(ConsultDistrictSignature signature)
        {
            return (await _discrictRepository.DistrictById(signature)).ToDistrictResult();
        }

        public Task<IEnumerable<ConsultDistrictResult>> GetListOfDistricts()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ConsultDistrictResult>> GetListOfDistrictsByName(ConsultDistrictSignature signature)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ConsultDistrictResult>> GetListOfDistrictsByQuantity(ConsultByQuantitySignature signature)
        {
            throw new System.NotImplementedException();
        }
    }
}
