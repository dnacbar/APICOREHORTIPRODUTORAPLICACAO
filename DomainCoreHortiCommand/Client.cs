using DOMAINCOREHORTICOMMAND.DOMAINOBJECT;
using System;

namespace DOMAINCOREHORTICOMMAND
{
    public class Client
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
        public string DsFederalInscription { get; set; }

        public EmailObject EmailObject => new EmailObject(DsEmail);
        public PhoneObject PhoneObject => new PhoneObject(DsPhone);
        public DocumentObject FederalDocument => new DocumentObject(DsFederalInscription);

        public virtual City IdCityNavigation { get; set; }
        public virtual Userhorti DsEmailNavigation { get; set; }
        public virtual District IdDistrictNavigation { get; set; }
    }
}
