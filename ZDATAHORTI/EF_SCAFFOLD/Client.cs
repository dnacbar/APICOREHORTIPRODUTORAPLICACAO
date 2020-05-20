using System;
using System.Collections.Generic;

namespace Z_DATAHORTI.EF_SCAFOLD
{
    public partial class Client
    {
        public Guid IdClient { get; set; }
        public string DsEmail { get; set; }
        public string DsClient { get; set; }
        public bool? BoActive { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }
        public int? IdCity { get; set; }
        public Guid? IdDistrict { get; set; }
        public string DsPhone { get; set; }
        public string DsFederalinscription { get; set; }

        public virtual Userhorti DsEmailNavigation { get; set; }
        public virtual City IdCityNavigation { get; set; }
        public virtual District IdDistrictNavigation { get; set; }
    }
}
