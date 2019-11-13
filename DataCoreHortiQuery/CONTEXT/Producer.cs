using System;
using System.Collections.Generic;

namespace DataCoreHortiQuery.CONTEXT
{
    public partial class Producer
    {
        public Guid IdProducer { get; set; }
        public string DsName { get; set; }
        public bool? BoActive { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }
        public string DsFantasyname { get; set; }
        public int? CdCity { get; set; }
        public Guid? CdDistrict { get; set; }
        public string DsZip { get; set; }
        public string DsAdress { get; set; }
        public string DsNumber { get; set; }
        public string DsComplement { get; set; }
        public string DsFederalinscription { get; set; }
        public string DsStateinscription { get; set; }
        public string DsMunicipalinscription { get; set; }
        public string DsDescription { get; set; }
        public DateTime? DtBirth { get; set; }
        public string DsEmail { get; set; }
        public string DsPhone { get; set; }

        public virtual City CdCityNavigation { get; set; }
        public virtual District CdDistrictNavigation { get; set; }
    }
}
