using System;
using System.Collections.Generic;

namespace DomainCoreHortiCommand
{
    public partial class Client
    {
        public Guid IdClient { get; set; }
        public string DsName { get; set; }
        public bool? BoActive { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }
        public int? CdCity { get; set; }
        public string DsEmail { get; set; }
        public string DsPhone { get; set; }

        public virtual City CdCityNavigation { get; set; }
        public virtual Userhorti DsEmailNavigation { get; set; }
    }
}
