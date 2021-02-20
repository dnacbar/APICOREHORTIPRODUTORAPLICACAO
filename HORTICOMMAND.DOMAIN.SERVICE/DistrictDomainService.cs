using FluentValidation;
using HORTI.CORE.CROSSCUTTING.EXTENSION;
using HORTICOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTICOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTICOMMAND.DOMAIN.MODEL;
using HORTICOMMAND.VALIDATION.APPLICATION;
using System;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.SERVICE
{
    public sealed class DistrictDomainService : IDistrictDomainService
    {
        private readonly CreateDistrictDomainServiceValidation _createDistrictDomainServiceValidation;
        private readonly UpdateDistrictDomainServiceValidation _updateDistrictDomainServiceValidation;

        private readonly IDistrictRepository _districtRepository;

        public DistrictDomainService(CreateDistrictDomainServiceValidation createDistrictDomainServiceValidation,
                                     UpdateDistrictDomainServiceValidation updateDistrictDomainServiceValidation,
                                     IDistrictRepository districtRepository)
        {
            _createDistrictDomainServiceValidation = createDistrictDomainServiceValidation;
            _updateDistrictDomainServiceValidation = updateDistrictDomainServiceValidation;
            _districtRepository = districtRepository;
        }

        public async Task DistrictServiceCreate(District district)
        {
            _createDistrictDomainServiceValidation.ValidateHorti(district);

            await _districtRepository.CreateDistrict(district);
        }

        public async Task DistrictServiceDelete(District district)
        {
            if (district.IdDistrict == Guid.Empty)
                throw new ValidationException("DISTRICT NOT EXISTS!");

            await _districtRepository.DeleteDistrict(district);
        }

        public async Task DistrictServiceUpdate(District district)
        {
            _updateDistrictDomainServiceValidation.ValidateHorti(district);

            await _districtRepository.UpdateDistrict(district);
        }
    }
}
