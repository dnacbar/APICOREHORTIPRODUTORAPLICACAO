using HORTI.CORE.CROSSCUTTING.ENUM;
using HORTI.CORE.CROSSCUTTING.VALUEOBJECT;
using System;

namespace HORTICOMMAND.DOMAIN.MODEL
{
    public class Producer
    {
        public Producer() { }

        public Producer(EnumCultureInfo cultureInfo = EnumCultureInfo.Brazilian)
        {
            CultureInfo = cultureInfo;
        }

        public Guid IdProducer { get; set; }
        public string DsProducer { get; set; }
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

        public virtual City IdCityNavigation { get; set; }
        public virtual District IdDistrictNavigation { get; set; }

        public PhoneObject PhoneObject => new PhoneObject(DsPhone, CultureInfo);
        public EmailObject EmailObject => new EmailObject(DsEmail);
        public DocumentObject FederalDocument => new DocumentObject(DsFederalInscription, CultureInfo);

        private EnumCultureInfo CultureInfo { get; set; }
    }
}
