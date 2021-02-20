using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;

namespace HORTICOMMAND.DOMAIN.MODEL.EXTENSION
{
    public static class UnitExtension
    {
        public static Unit GetUnit(this IUnitCommandSignature signature)
        {
            return new Unit
            {
                IdUnit = signature.Id.GetValueOrDefault(),
                DsUnit = signature.Unit,
                DsAbreviation = signature.Abreviation,
                DtAtualization = DateTime.Now
            };
        }
    }
}
