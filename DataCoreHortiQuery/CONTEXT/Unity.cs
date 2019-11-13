using System;
using System.Collections.Generic;

namespace DataCoreHortiQuery.CONTEXT
{
    public partial class Unity
    {
        public Guid IdUnity { get; set; }
        public string DsName { get; set; }
        public string DsUnity { get; set; }
        public bool? BoActive { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }
    }
}
