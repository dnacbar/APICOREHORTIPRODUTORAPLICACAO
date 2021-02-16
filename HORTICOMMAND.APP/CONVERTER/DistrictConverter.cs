using APPDTOCOREHORTICOMMAND.SIGNATURE;
using HORTICOMMAND.DOMAIN.MODEL;
using System;

namespace HORTICOMMAND.APP.CONVERTER
{
    public static class DistrictConverter
    {
        public static IDistrict ToCreateDistrictDomain(this IDistrictCommandSignature signature)
        {
            return new IDistrict
            {
                IdDistrict = Guid.NewGuid(),
                DsDistrict = signature.District
            };
        }

        public static IDistrict ToDeleteDistrictDomain(this IDistrictCommandSignature signature)
        {
            return new IDistrict { IdDistrict = signature.Id.Value };
        }

        public static IDistrict ToUpdateDistrictDomain(this IDistrictCommandSignature signature)
        {
            return new IDistrict
            {
                IdDistrict = signature.Id.Value,
                DsDistrict = signature.District,
                DtAtualization = DateTime.Now
            };
        }
    }
}
