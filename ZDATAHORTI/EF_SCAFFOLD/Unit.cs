using System;
using System.Collections.Generic;

namespace Z_DATAHORTI.EF_SCAFOLD
{
    public partial class Unit
    {
        public byte IdUnit { get; set; }
        public string DsUnit { get; set; }
        public string DsAbreviation { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }
    }
}
