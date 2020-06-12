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
                DsUnit = signature.Unit,
                DsAbreviation = signature.Abreviation,
                DtCreation = DateTime.Now
            };
        }

        public static Unit ToDeleteUnitDomain(this UnitCommandSignature signature)
        {
            return new Unit { IdUnit = signature.Id };
        }

        public static Unit ToUpdateUnitDomain(this UnitCommandSignature signature)
        {
            return new Unit
            {
                IdUnit = signature.Id,
                DsUnit = signature.Unit,
                DsAbreviation = signature.Abreviation
            };
        }
    }
}
