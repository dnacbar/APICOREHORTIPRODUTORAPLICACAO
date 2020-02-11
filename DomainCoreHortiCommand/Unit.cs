using System;
using System.Collections.Generic;

namespace DomainCoreHortiCommand
{
    public partial class Unit
    {
        public Guid IdUnit { get; set; }
        public string DsUnit { get; set; }
        public string DsAbreviation { get; set; }
        public bool? BoActive { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }
    }
}
