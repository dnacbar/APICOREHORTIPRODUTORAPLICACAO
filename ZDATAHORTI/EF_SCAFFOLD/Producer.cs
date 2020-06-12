using System;
using System.Collections.Generic;

namespace Z_DATAHORTI.EF_SCAFFOLD
{
    public partial class Producer
    {
        public Guid IdProducer { get; set; }
        public string DsEmail { get; set; }
        public string DsProducer { get; set; }
        public bool? BoActive { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }
        public string DsFantasyname { get; set; }
        public int? IdCity { get; set; }
        public Guid? IdDistrict { get; set; }
        public string DsZip { get; set; }
        public string DsAddress { get; set; }
        public string DsNumber { get; set; }
        public string DsComplement { get; set; }
        public string DsFederalinscription { get; set; }
        public string DsStateinscription { get; set; }
        public string DsMunicipalinscription { get; set; }
        public string DsDescription { get; set; }
        public string DsPhone { get; set; }

        public virtual Userhorti DsEmailNavigation { get; set; }
        public virtual City IdCityNavigation { get; set; }
        public virtual District IdDistrictNavigation { get; set; }
    }
}
