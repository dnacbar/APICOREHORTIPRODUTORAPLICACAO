using System;
using System.Collections.Generic;

namespace DataCoreHortiQuery.CONTEXT
{
    public partial class Product
    {
        public Guid IdProduct { get; set; }
        public string DsName { get; set; }
        public bool? BoActive { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }
        public decimal NmValue { get; set; }
        public byte? NmDiscount { get; set; }
        public DateTime? DtDiscount { get; set; }
        public Guid? CdUnity { get; set; }
        public bool? BoStock { get; set; }
    }
}
