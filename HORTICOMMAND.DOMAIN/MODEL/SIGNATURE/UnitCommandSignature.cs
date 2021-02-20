using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;

namespace HORTICOMMAND.DOMAIN.MODEL.SIGNATURE
{
    public sealed class UnitCommandSignature : IUnitCommandSignature
    {
        public byte? Id { get; set; }
        public string Unit { get; set; }
        public string Abreviation { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateAtualization { get; set; }
    }
}
