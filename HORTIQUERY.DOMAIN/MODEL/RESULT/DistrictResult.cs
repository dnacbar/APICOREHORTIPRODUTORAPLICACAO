using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using System;

namespace HORTIQUERY.DOMAIN.MODEL.RESULT
{
    public class DistrictResult : IDistrictResult
    {
        public DistrictResult(District district)
        {
            Id = district.IdDistrict;
            District = district.DsDistrict;
        }

        public Guid Id { get; set; }
        public string District { get; set; }
    }
}
