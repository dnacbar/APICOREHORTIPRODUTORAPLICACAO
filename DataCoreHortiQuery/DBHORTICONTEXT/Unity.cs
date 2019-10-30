using System;
using System.Collections.Generic;

namespace DataCoreHortiQuery.DBHORTICONTEXT
{
    public partial class Unity
    {
        public Unity()
        {
            Product = new HashSet<Product>();
        }

        public Guid IdUnity { get; set; }
        public string DsName { get; set; }
        public bool? BoActive { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
