using System;
using System.Collections.Generic;

namespace Z_DATAHORTI.EF_SCAFFOLD
{
    public partial class Unit
    {
        public Unit()
        {
            Product = new HashSet<Product>();
        }

        public byte IdUnit { get; set; }
        public string DsUnit { get; set; }
        public string DsAbreviation { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
