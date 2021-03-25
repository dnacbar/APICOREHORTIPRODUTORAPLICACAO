using System;
using System.Collections.Generic;

#nullable disable

namespace Z_DATAHORTI.EF_SCAFFOLD
{
    public partial class Product
    {
        public Guid IdProduct { get; set; }
        public string DsProduct { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }
        public decimal NmValue { get; set; }
        public byte? NmPercentdiscount { get; set; }
        public DateTime? DtDiscount { get; set; }
        public byte? IdUnit { get; set; }
        public bool? BoStock { get; set; }
        public string DsDescription { get; set; }

        public virtual Unit IdUnitNavigation { get; set; }
    }
}
