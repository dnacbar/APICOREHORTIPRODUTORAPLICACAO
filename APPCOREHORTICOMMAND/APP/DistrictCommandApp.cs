using APPCOREHORTICOMMAND.APP.CONVERTER;
using APPCOREHORTICOMMAND.IAPP;
using APPDTOCOREHORTICOMMAND.SIGNATURE;
using CROSSCUTTINGCOREHORTI.EXTENSION;
using SERVICECOREHORTICOMMAND.ISERVICE;
using System.Threading.Tasks;
using VALIDATIONCOREHORTICOMMAND.APPLICATION;

namespace APPCOREHORTICOMMAND.APP
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

        public async Task CreateDistrict(DistrictCommandSignature signature)
        {
            //_createUnitSignatureValidation.ValidateHorti(signature);

            await _districtDomainService.DistrictServiceCreate(signature.ToCreateDistrictDomain());
        }

        public async Task DeleteDistrict(DistrictCommandSignature signature)
        {
            //_deleteUnitSignatureValidation.ValidateHorti(signature);

            await _districtDomainService.DistrictServiceDelete(signature.ToDeleteDistrictDomain());
        }

        public async Task UpdateDistrict(DistrictCommandSignature signature)
        {
            //_updateUnitSignatureValidation.ValidateHorti(signature);

            await _districtDomainService.DistrictServiceUpdate(signature.ToUpdateDistrictDomain());
        }
    }
}
