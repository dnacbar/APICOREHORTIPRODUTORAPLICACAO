using CROSSCUTTINGCOREHORTI.EXTENSION;
using DATAACCESSCOREHORTICOMMAND.ICOMMAND;
using DOMAINCOREHORTICOMMAND;
using SERVICECOREHORTICOMMAND.ISERVICE;
using System.Threading.Tasks;
using VALIDATIONCOREHORTICOMMAND.DOMAIN;

namespace SERVICECOREHORTICOMMAND.SERVICE
{
    public sealed class UnitDomainService : IUnitDomainService
    {
        private readonly UnitDomainServiceValidation _unitDomainServiceValidation;
        private readonly IUnitRepository _unitRepository;

        public UnitDomainService(UnitDomainServiceValidation unitDomainServiceValidation,
                                 IUnitRepository unitRepository)
        {
            _unitDomainServiceValidation = unitDomainServiceValidation;
            _unitRepository = unitRepository;
        }

        public async Task UnitServiceAdd(Unit unit)
        {
            _unitDomainServiceValidation.ValidateHorti(unit);

            await _unitRepository.CreateUnit(unit);
        }

        public async Task UnitServiceDelete(Unit unit)
        {
            await _unitRepository.DeleteUnit(unit);
        }

        public async Task UnitServiceUpdate(Unit unit)
        {
            _unitDomainServiceValidation.ValidateHorti(unit);

            await _unitRepository.UpdateUnit(unit);
        }
    }
}
