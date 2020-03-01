using System;

namespace DOMAINCOREHORTICOMMAND
{
    public partial class Product
    {
        public Guid IdProduct { get; set; }
        public string DsProduct { get; set; }
        public bool? BoActive { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }
        public decimal NmValue { get; set; }
        public byte? NmDiscount { get; set; }
        public DateTime? DtDiscount { get; set; }
        public int? IdUnit { get; set; }
        public bool? BoStock { get; set; }

        public virtual Unit IdUnitNavigation { get; set; }
    }
}
