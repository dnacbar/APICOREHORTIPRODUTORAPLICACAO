using DOMAINCOREHORTICOMMAND.DOMAINOBJECT;
using System;

namespace DOMAINCOREHORTICOMMAND
{
    public class Producer
    {
        public Guid IdProducer { get; set; }
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
        public string DsFederalInscription { get; set; }
        public string DsStateInscription { get; set; }
        public string DsMunicipalInscription { get; set; }
        public string DsDescription { get; set; }
        public string DsEmail { get; set; }
        public string DsPhone { get; set; }

        public PhoneObject Phone => new PhoneObject(DsPhone);
        public EmailObject Email => new EmailObject(DsEmail);

        public virtual City IdCityNavigation { get; set; }
        public virtual District IdDistrictNavigation { get; set; }
        public virtual Userhorti DsEmailNavigation { get; set; }
    }
}
