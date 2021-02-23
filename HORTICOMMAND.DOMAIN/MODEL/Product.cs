using HORTICOMMAND.DOMAIN.INTERFACE.MODEL;
using System;

namespace HORTICOMMAND.DOMAIN.MODEL
{
    public class Product : IProduct
    {
        public Guid IdProduct { get; set; }
        public string DsProduct { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }
        public decimal NmValue { get; set; }
        public byte? NmPercentDiscount { get; set; }
        public DateTime? DtDiscount { get; set; }
        public byte? IdUnit { get; set; }
        public bool? BoStock { get; set; }
        public string DsDescription { get; set; }

        public virtual Unit IdUnitNavigation { get; set; }

        public decimal ProductValueWithDiscount()
        {
            return NmPercentDiscount.HasValue ? CalculateDiscount() : NmValue;
        }

        public bool ValidatePercentDiscount()
        {
            if (DtDiscount.HasValue && !NmPercentDiscount.HasValue)
                return false;

            return (NmPercentDiscount.Value <= 100 ? true : false)
                && DtDiscount.Value >= DateTime.Now;
        }

        private decimal CalculateDiscount()
        {
            return NmValue - (NmValue * NmPercentDiscount.Value / 100);
        }
    }
}
