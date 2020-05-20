using APPCOREHORTICOMMAND.APP.CONVERTER;
using APPCOREHORTICOMMAND.IAPP;
using APPDTOCOREHORTICOMMAND.SIGNATURE;
using CROSSCUTTINGCOREHORTI.EXTENSION;
using SERVICECOREHORTICOMMAND.ISERVICE;
using System.Threading.Tasks;
using VALIDATIONCOREHORTICOMMAND.APPLICATION;

namespace APPCOREHORTICOMMAND.APP
{
    public sealed class UnitCommandApp : IUnitCommandApp
    {
        private readonly IUnitDomainService _unitDomainService;
        private readonly CreateUnitSignatureValidation _createUnitSignatureValidation;
        private readonly DeleteUnitSignatureValidation _deleteUnitSignatureValidation;
        private readonly UpdateUnitSignatureValidation _updateUnitSignatureValidation;

        public UnitCommandApp(IUnitDomainService unitDomainService,
                              CreateUnitSignatureValidation createUnitSignatureValidation,
                              DeleteUnitSignatureValidation deleteUnitSignatureValidation,
                              UpdateUnitSignatureValidation updateUnitSignatureValidation)
        {
            _unitDomainService = unitDomainService;
            _createUnitSignatureValidation = createUnitSignatureValidation;
            _deleteUnitSignatureValidation = deleteUnitSignatureValidation;
            _updateUnitSignatureValidation = updateUnitSignatureValidation;
        }

        public async Task CreateUnit(UnitCommandSignature signature)
        {
            _createUnitSignatureValidation.ValidateHorti(signature);

            await _unitDomainService.UnitServiceAdd(signature.ToCreateUnitDomain());
        }

        public async Task DeleteUnit(UnitCommandSignature signature)
        {
            _deleteUnitSignatureValidation.ValidateHorti(signature);

            await _unitDomainService.UnitServiceDelete(signature.ToDeleteUnitDomain());
        }

        public async Task UpdateUnit(UnitCommandSignature signature)
        {
            _updateUnitSignatureValidation.ValidateHorti(signature);

            await _unitDomainService.UnitServiceUpdate(signature.ToUpdateUnitDomain());
        }
    }
}
