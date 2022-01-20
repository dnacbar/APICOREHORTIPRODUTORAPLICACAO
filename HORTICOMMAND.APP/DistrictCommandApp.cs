using HORTICOMMAND.APP.VALIDATION.APPLICATION;
using HORTICOMMAND.APP.VALIDATION.EXTENSION;
using HORTICOMMAND.DOMAIN.INTERFACE.APP;
using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTICOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTICOMMAND.APP
{
    public sealed class DistrictCommandApp : IDistrictCommandApp
    {
        private readonly CreateDistrictSignatureValidation _createDistrictSignatureValidation;
        private readonly DeleteDistrictSignatureValidation _deleteDistrictSignatureValidation;
        private readonly UpdateDistrictSignatureValidation _updateDistrictSignatureValidation;

        private readonly IDistrictDomainService _districtDomainService;

        public DistrictCommandApp(CreateDistrictSignatureValidation createDistrictSignatureValidation,
                                  DeleteDistrictSignatureValidation deleteDistrictSignatureValidation,
                                  UpdateDistrictSignatureValidation updateDistrictSignatureValidation,
                                  IDistrictDomainService districtDomainService)
        {
            _createDistrictSignatureValidation = createDistrictSignatureValidation;
            _deleteDistrictSignatureValidation = deleteDistrictSignatureValidation;
            _updateDistrictSignatureValidation = updateDistrictSignatureValidation;
            _districtDomainService = districtDomainService;
        }

        public async Task CreateDistrict(IDistrictCommandSignature signature)
        {
            _createDistrictSignatureValidation.ValidateHorti(signature);

            await _districtDomainService.DistrictServiceCreate(new District(signature));
        }

        public async Task DeleteDistrict(IDistrictCommandSignature signature)
        {
            _deleteDistrictSignatureValidation.ValidateHorti(signature);

            await _districtDomainService.DistrictServiceDelete(new District(signature));
        }

        public async Task UpdateDistrict(IDistrictCommandSignature signature)
        {
            _updateDistrictSignatureValidation.ValidateHorti(signature);

            await _districtDomainService.DistrictServiceUpdate(new District(signature));
        }
    }
}
