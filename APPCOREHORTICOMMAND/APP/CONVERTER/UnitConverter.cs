using APPDTOCOREHORTICOMMAND.SIGNATURE;
using DOMAINCOREHORTICOMMAND;
using System;

namespace APPCOREHORTICOMMAND.APP.CONVERTER
{
    public static class UnitConverter
    {
        public static Unit ToCreateUnitDomain(this UnitCommandSignature signature)
        {
            return new Unit
            {
                DsUnit = signature.DsUnit,
                DsAbreviation = signature.DsAbreviation
            };
        }

        public static Unit ToDeleteUnitDomain(this UnitCommandSignature signature)
        {
            return new Unit { IdUnit = signature.IdUnit };
        }

        public static Unit ToUpdateUnitDomain(this UnitCommandSignature signature)
        {
            return new Unit
            {
                IdUnit = signature.IdUnit,
                DsUnit = signature.DsUnit,
                DsAbreviation = signature.DsAbreviation,
                DtAtualization = DateTime.Now,
                DtCreation = DateTime.Now
            };
        }
    }
}
