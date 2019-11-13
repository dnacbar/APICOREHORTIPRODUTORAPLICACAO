using System;
using DominioCoreBasicoCommand;

namespace HortiProducerDomainCoreCommand
{
    public sealed class Product : Entity
    {
        public decimal NmValue { get; set; }
        public short? NmDiscount { get; set; }
        public DateTime? DtDiscount { get; set; }
        public Guid? IdUnity { get; set; }
        public bool BoStock { get; set; }
    }
}
