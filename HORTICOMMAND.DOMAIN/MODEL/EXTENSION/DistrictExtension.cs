using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;

namespace HORTICOMMAND.DOMAIN.MODEL.EXTENSION
{
    public static class DistrictExtension
    {
        public static District GetDistrict(this IDistrictCommandSignature signature)
        {
            return new District
            {
                IdDistrict = signature.Id.GetValueOrDefault(),
                DsDistrict = signature.District,
                DtAtualization = DateTime.Now
            };
        }
    }
}
