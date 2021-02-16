using HORTICOMMAND.APP.CONVERTER;
using HORTICOMMAND.DOMAIN.INTERFACES.APP;
using APPDTOCOREHORTICOMMAND.SIGNATURE;
using HORTICROSSCUTTINGCORE.EXTENSION;
using SERVICECOREHORTICOMMAND.ISERVICE;
using System.Threading.Tasks;
using HORTICOMMAND.VALIDATION.APPLICATION;

namespace HORTICOMMAND.APP
{
    public sealed class DistrictCommandApp : IDistrictCommandApp
    {
        //private readonly CreateUnitSignatureValidation _createUnitSignatureValidation;
        //private readonly DeleteUnitSignatureValidation _deleteUnitSignatureValidation;
        //private readonly UpdateUnitSignatureValidation _updateUnitSignatureValidation;

        private readonly IDistrictDomainService _districtDomainService;

        public DistrictCommandApp(//CreateUnitSignatureValidation createUnitSignatureValidation,
                                  //DeleteUnitSignatureValidation deleteUnitSignatureValidation,
                                  //UpdateUnitSignatureValidation updateUnitSignatureValidation,
                                  IDistrictDomainService districtDomainService)
        {
            //_createUnitSignatureValidation = createUnitSignatureValidation;
            //_deleteUnitSignatureValidation = deleteUnitSignatureValidation;
            //_updateUnitSignatureValidation = updateUnitSignatureValidation;

            _districtDomainService = districtDomainService;
        }

        public async Task CreateDistrict(IDistrictCommandSignature signature)
        {
            //_createUnitSignatureValidation.ValidateHorti(signature);

            await _districtDomainService.DistrictServiceCreate(signature.ToCreateDistrictDomain());
        }

        public async Task DeleteDistrict(IDistrictCommandSignature signature)
        {
            //_deleteUnitSignatureValidation.ValidateHorti(signature);

            await _districtDomainService.DistrictServiceDelete(signature.ToDeleteDistrictDomain());
        }

        public async Task UpdateDistrict(IDistrictCommandSignature signature)
        {
            //_updateUnitSignatureValidation.ValidateHorti(signature);

            await _districtDomainService.DistrictServiceUpdate(signature.ToUpdateDistrictDomain());
        }
    }
}
