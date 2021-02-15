using APPDTOCOREHORTICOMMAND.SIGNATURE;
using DOMAINCOREHORTICOMMAND;
using System;

namespace APPCOREHORTICOMMAND.APP.CONVERTER
{
    public static class DistrictConverter
    {
        public static District ToCreateDistrictDomain(this DistrictCommandSignature signature)
        {
            return new District
            {
                IdDistrict = Guid.NewGuid(),
                DsDistrict = signature.District
            };
        }

        public static District ToDeleteDistrictDomain(this DistrictCommandSignature signature)
        {
            return new District { IdDistrict = signature.Id.Value };
        }

        public static District ToUpdateDistrictDomain(this DistrictCommandSignature signature)
        {
            return new District
            {
                IdDistrict = signature.Id.Value,
                DsDistrict = signature.District,
                DtAtualization = DateTime.Now
            };
        }
    }
}
