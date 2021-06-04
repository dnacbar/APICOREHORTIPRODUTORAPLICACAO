using FluentValidation;
using HORTICOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTICOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTICOMMAND.DOMAIN.MODEL;
using System;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.SERVICE
{
    public sealed class DistrictDomainService : IDistrictDomainService
    {
        private readonly IDistrictRepository _districtRepository;

        public DistrictDomainService(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        public async Task DistrictServiceCreate(District district)
        {
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
            await _districtRepository.UpdateDistrict(district);
        }
    }
}
